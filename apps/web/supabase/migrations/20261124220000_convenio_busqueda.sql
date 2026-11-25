-- Cada palabra de la búsqueda debe aparecer en el DNI, los apellidos o los nombres.

create or replace function public.listar_predios_convenio_medidor(
  p_anio integer,
  p_sector_id uuid default null,
  p_calle_id uuid default null,
  p_busqueda text default null
)
returns jsonb
language plpgsql
stable
security invoker
set search_path = public
as $$
declare
  v_servicio_id uuid;
  v_servicio text;
  v_monto numeric(12, 2);
  v_busqueda text := nullif(replace(replace(btrim(coalesce(p_busqueda, '')), '%', ''), '_', ''), '');
  v_predios jsonb;
begin
  if p_anio is null or p_anio < 1900 then
    raise exception 'Indicá el año del convenio';
  end if;

  select s.id, s.nombre
  into v_servicio_id, v_servicio
  from public.cat_tipos_servicio s
  where s.estado = 'activo'
    and (
      s.categoria::text = 'medidor'
      or (s.categoria::text = 'unico' and s.nombre ilike '%medidor%')
      or (s.categoria::text = 'unico' and s.nombre ilike '%conexi%')
    )
  order by
    case
      when s.categoria::text = 'medidor' then 0
      when s.nombre ilike '%medidor%' then 1
      else 2
    end,
    s.nombre
  limit 1;

  if v_servicio_id is null then
    raise exception 'No hay un costo de medidor en el catálogo';
  end if;

  select c.monto
  into v_monto
  from public.cat_costos_tarifa c
  join public.cat_tarifas t on t.id = c.tarifa_id
  where c.tipo_servicio_id = v_servicio_id
    and t.anio = p_anio
  order by t.activa desc, t.nombre
  limit 1;

  if v_monto is null or v_monto <= 0 then
    raise exception 'El costo de medidor no tiene valor en el año %', p_anio;
  end if;

  select coalesce(jsonb_agg(to_jsonb(t) order by t.usuario, t.predio), '[]'::jsonb)
  into v_predios
  from (
    select
      p.id as predio_id,
      p.nombre as predio,
      p.numero,
      btrim(concat_ws(' ', u.apellido_paterno, u.apellido_materno, u.nombres)) as usuario,
      coalesce(s.nombre, '') as sector,
      coalesce(c.nombre, '') as calle
    from public.pad_predios p
    join public.pad_usuarios u on u.id = p.usuario_id
    left join public.cat_sectores s on s.id = p.sector_id
    left join public.cat_calles c on c.id = p.calle_id
    where p.estado = 'activo'
      and (p_sector_id is null or p.sector_id = p_sector_id)
      and (p_calle_id is null or p.calle_id = p_calle_id)
      and (
        v_busqueda is null
        or not exists (
          select 1
          from regexp_split_to_table(v_busqueda, '\s+') as tok
          where regexp_replace(tok, '[,.;:]+', '', 'g') <> ''
            and concat_ws(
              ' ',
              u.nombres,
              u.apellido_paterno,
              u.apellido_materno,
              u.dni,
              u.ruc,
              p.nombre,
              p.numero
            ) not ilike '%' || regexp_replace(tok, '[,.;:]+', '', 'g') || '%'
        )
      )
      and not exists (
        select 1
        from public.fac_deudas_anteriores d
        where d.predio_id = p.id
          and d.tipo_servicio_id = v_servicio_id
      )
  ) as t;

  return jsonb_build_object(
    'servicio_id', v_servicio_id,
    'servicio', v_servicio,
    'anio', p_anio,
    'monto', v_monto,
    'predios', v_predios
  );
end;
$$;

notify pgrst, 'reload schema';
