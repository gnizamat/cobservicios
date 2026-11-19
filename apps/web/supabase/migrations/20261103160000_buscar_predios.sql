-- Búsqueda de predios por datos del predio y del titular (DNI, nombres y apellidos).
-- Cada palabra del término debe aparecer en alguno de esos campos.

create or replace function public.buscar_predio_ids(
  p_search text default null,
  p_estado text default null,
  p_tipo_predio_id uuid default null,
  p_limit integer default 20,
  p_offset integer default 0
)
returns jsonb
language sql
stable
security invoker
set search_path = public
as $$
  with matched as (
    select p.id, p.nombre
    from public.pad_predios p
    join public.pad_usuarios u on u.id = p.usuario_id
    cross join lateral (
      select
        replace(replace(btrim(coalesce(p_search, '')), '%', ''), '_', '') as term,
        concat_ws(
          ' ',
          u.nombres,
          u.apellido_paterno,
          u.apellido_materno,
          u.apellido_paterno,
          u.apellido_materno,
          u.nombres,
          u.apellido_materno,
          u.apellido_paterno,
          u.dni
        ) as titular_blob
    ) as busqueda
    where (p_estado is null or p.estado::text = p_estado)
      and (p_tipo_predio_id is null or p.tipo_predio_id = p_tipo_predio_id)
      and (
        nullif(busqueda.term, '') is null
        or p.nombre ilike '%' || busqueda.term || '%'
        or p.numero ilike '%' || busqueda.term || '%'
        or p.manzana ilike '%' || busqueda.term || '%'
        or p.lote ilike '%' || busqueda.term || '%'
        or p.partida_registral ilike '%' || busqueda.term || '%'
        or p.unidad_catastral ilike '%' || busqueda.term || '%'
        or busqueda.titular_blob ilike '%' || busqueda.term || '%'
        or not exists (
          select 1
          from regexp_split_to_table(busqueda.term, '\s+') as tok
          where tok <> ''
            and busqueda.titular_blob not ilike '%' || tok || '%'
        )
      )
  )
  select jsonb_build_object(
    'total', (select count(*)::int from matched),
    'ids', coalesce((
      select jsonb_agg(page.id order by page.nombre)
      from (
        select id, nombre
        from matched
        order by nombre
        limit greatest(coalesce(p_limit, 20), 0)
        offset greatest(coalesce(p_offset, 0), 0)
      ) as page
    ), '[]'::jsonb)
  );
$$;

revoke all on function public.buscar_predio_ids(text, text, uuid, integer, integer) from public;
grant execute on function public.buscar_predio_ids(text, text, uuid, integer, integer) to authenticated;
