-- Cada facturación queda asociada a una caja activa.

alter table public.fac_facturaciones
  add column if not exists caja_id uuid references public.cob_cajas (id) on delete restrict;

update public.fac_facturaciones f
set caja_id = (
  select c.id
  from public.cob_cajas c
  order by c.activa desc, c.created_at
  limit 1
)
where f.caja_id is null;

do $$
begin
  if exists (select 1 from public.fac_facturaciones where caja_id is null) then
    raise exception 'Hay facturaciones sin caja y no existe ninguna caja para asignarlas';
  end if;
end $$;

alter table public.fac_facturaciones
  alter column caja_id set not null;

create index if not exists fac_facturaciones_caja_id_idx
  on public.fac_facturaciones (caja_id);

drop function if exists public.generar_facturacion(integer, integer, uuid[]);

create function public.generar_facturacion(
  p_anio integer,
  p_mes integer,
  p_predio_ids uuid[],
  p_caja_id uuid
)
returns jsonb
language plpgsql
security definer
set search_path = public
as $$
declare
  rec record;
  v_id uuid;
  v_num integer;
  v_monto numeric(12, 2);
  v_deudas integer;
  v_count integer := 0;
  v_total numeric(12, 2) := 0;
begin
  if p_anio is null or p_anio < 1900 or p_mes is null or p_mes < 1 or p_mes > 12 then
    raise exception 'Indicá un año y un mes válidos';
  end if;

  if p_predio_ids is null or cardinality(p_predio_ids) = 0 then
    raise exception 'Seleccioná al menos un predio';
  end if;

  if p_caja_id is null or not exists (
    select 1 from public.cob_cajas c where c.id = p_caja_id and c.activa
  ) then
    raise exception 'Elegí una caja activa';
  end if;

  perform pg_advisory_xact_lock(74821, p_anio);

  select coalesce(max((regexp_match(numero, '-([0-9]+)$'))[1]::integer), 0)
  into v_num
  from public.fac_facturaciones
  where anio = p_anio;

  for rec in
    select p.id as predio_id
    from public.pad_predios p
    where p.id = any (p_predio_ids)
      and p.estado = 'activo'
      and not exists (
        select 1
        from public.fac_facturaciones f
        where f.predio_id = p.id
          and f.anio = p_anio
          and f.mes = p_mes
          and f.estado = 'generada'
      )
    order by p.nombre
  loop
    select coalesce(sum(d.saldo), 0), count(*)::integer
    into v_monto, v_deudas
    from public.fac_deudas_anteriores d
    where d.predio_id = rec.predio_id
      and d.anio = p_anio
      and d.mes = p_mes
      and d.saldo > 0
      and not exists (
        select 1
        from public.fac_facturacion_detalle fd
        where fd.deuda_anterior_id = d.id
      );

    if v_monto <= 0 or v_deudas = 0 then
      continue;
    end if;

    v_num := v_num + 1;

    insert into public.fac_facturaciones (
      predio_id, anio, mes, numero, monto_total, fecha, estado, caja_id
    )
    values (
      rec.predio_id,
      p_anio,
      p_mes,
      'F' || p_anio::text || '-' || lpad(v_num::text, 6, '0'),
      v_monto,
      current_date,
      'generada',
      p_caja_id
    )
    returning id into v_id;

    insert into public.fac_facturacion_detalle (
      facturacion_id, deuda_anterior_id, tipo_servicio_id, monto
    )
    select v_id, d.id, d.tipo_servicio_id, d.saldo
    from public.fac_deudas_anteriores d
    where d.predio_id = rec.predio_id
      and d.anio = p_anio
      and d.mes = p_mes
      and d.saldo > 0
      and not exists (
        select 1
        from public.fac_facturacion_detalle fd
        where fd.deuda_anterior_id = d.id
      );

    v_count := v_count + 1;
    v_total := v_total + v_monto;
  end loop;

  return jsonb_build_object('generadas', v_count, 'monto', v_total);
end;
$$;

revoke all on function public.generar_facturacion(integer, integer, uuid[], uuid) from public;
grant execute on function public.generar_facturacion(integer, integer, uuid[], uuid) to authenticated;

create or replace function public.listar_facturaciones(
  p_anio integer,
  p_mes integer,
  p_sector_id uuid default null,
  p_calle_id uuid default null
)
returns jsonb
language sql
stable
security invoker
set search_path = public
as $$
  select coalesce(
    jsonb_agg(to_jsonb(t) order by t.numero_factura),
    '[]'::jsonb
  )
  from (
    select
      f.id,
      f.numero as numero_factura,
      f.predio_id,
      p.nombre as predio,
      p.numero as numero_predio,
      btrim(concat_ws(' ', u.apellido_paterno, u.apellido_materno, u.nombres)) as usuario,
      coalesce(s.nombre, '') as sector,
      coalesce(c.nombre, '') as calle,
      coalesce(cj.nombre, '') as caja,
      f.anio,
      f.mes,
      f.monto_total as monto,
      f.fecha,
      (
        select count(*)::int
        from public.fac_facturacion_detalle fd
        where fd.facturacion_id = f.id
      ) as deudas,
      (
        exists (
          select 1
          from public.cob_pago_facturaciones l
          where l.facturacion_id = f.id
        )
        or exists (
          select 1
          from public.fac_facturacion_detalle fd
          join public.cob_pago_deudas pd on pd.deuda_anterior_id = fd.deuda_anterior_id
          where fd.facturacion_id = f.id
        )
      ) as tiene_pagos
    from public.fac_facturaciones f
    join public.pad_predios p on p.id = f.predio_id
    join public.pad_usuarios u on u.id = p.usuario_id
    left join public.cat_sectores s on s.id = p.sector_id
    left join public.cat_calles c on c.id = p.calle_id
    join public.cob_cajas cj on cj.id = f.caja_id
    where f.anio = p_anio
      and f.mes = p_mes
      and f.estado = 'generada'
      and (p_sector_id is null or p.sector_id = p_sector_id)
      and (p_calle_id is null or p.calle_id = p_calle_id)
  ) as t;
$$;

notify pgrst, 'reload schema';
