-- Deuda fija del mes: predios activos que todavía no tienen ese servicio en el año y mes.

create or replace function public.listar_predios_deuda_fija(
  p_anio integer,
  p_mes integer,
  p_tipo_servicio_id uuid,
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
    jsonb_agg(to_jsonb(t) order by t.usuario, t.predio),
    '[]'::jsonb
  )
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
      and not exists (
        select 1
        from public.fac_deudas_anteriores d
        where d.predio_id = p.id
          and d.anio = p_anio
          and d.mes = p_mes
          and d.tipo_servicio_id = p_tipo_servicio_id
      )
  ) as t;
$$;

create or replace function public.generar_deudas_fijas(
  p_anio integer,
  p_mes integer,
  p_tipo_servicio_id uuid,
  p_predio_ids uuid[]
)
returns jsonb
language plpgsql
security definer
set search_path = public
as $$
declare
  v_categoria text;
  v_servicio text;
  v_tarifa uuid;
  v_monto numeric(12, 2);
  v_predio uuid;
  v_count integer := 0;
begin
  if p_anio is null or p_anio < 1900 or p_mes is null or p_mes < 1 or p_mes > 12 then
    raise exception 'Indicá un año y un mes válidos';
  end if;

  if p_tipo_servicio_id is null then
    raise exception 'Seleccioná el tipo de servicio';
  end if;

  if p_predio_ids is null or cardinality(p_predio_ids) = 0 then
    raise exception 'Seleccioná al menos un predio';
  end if;

  select categoria::text, nombre
  into v_categoria, v_servicio
  from public.cat_tipos_servicio
  where id = p_tipo_servicio_id
    and estado = 'activo';

  if v_categoria is null then
    raise exception 'El servicio seleccionado no existe';
  end if;

  if v_categoria <> 'fijo' then
    raise exception 'Solo se generan deudas de servicios fijos';
  end if;

  select id
  into v_tarifa
  from public.cat_tarifas
  where anio = p_anio
  order by activa desc, nombre
  limit 1;

  if v_tarifa is null then
    raise exception 'No hay tarifa para el año %', p_anio;
  end if;

  select monto
  into v_monto
  from public.cat_costos_tarifa
  where tarifa_id = v_tarifa
    and tipo_servicio_id = p_tipo_servicio_id;

  if v_monto is null or v_monto <= 0 then
    raise exception 'Ese servicio no tiene un valor fijo en el año seleccionado';
  end if;

  perform pg_advisory_xact_lock(hashtext(p_tipo_servicio_id::text), p_anio * 100 + p_mes);

  foreach v_predio in array p_predio_ids loop
    if not exists (
      select 1
      from public.pad_predios
      where id = v_predio
        and estado = 'activo'
    ) then
      continue;
    end if;

    if exists (
      select 1
      from public.fac_deudas_anteriores
      where predio_id = v_predio
        and anio = p_anio
        and mes = p_mes
        and tipo_servicio_id = p_tipo_servicio_id
    ) then
      continue;
    end if;

    insert into public.fac_deudas_anteriores (
      predio_id,
      tarifa_id,
      tipo_servicio_id,
      anio,
      mes,
      monto,
      saldo,
      volumen,
      interes,
      concepto,
      fecha_registro
    )
    values (
      v_predio,
      v_tarifa,
      p_tipo_servicio_id,
      p_anio,
      p_mes,
      v_monto,
      v_monto,
      0,
      0,
      v_servicio,
      current_date
    );

    v_count := v_count + 1;
  end loop;

  return jsonb_build_object(
    'generadas', v_count,
    'monto', v_monto,
    'total', v_count * v_monto
  );
end;
$$;

revoke all on function public.listar_predios_deuda_fija(integer, integer, uuid, uuid, uuid) from public;
revoke all on function public.generar_deudas_fijas(integer, integer, uuid, uuid[]) from public;
grant execute on function public.listar_predios_deuda_fija(integer, integer, uuid, uuid, uuid) to authenticated;
grant execute on function public.generar_deudas_fijas(integer, integer, uuid, uuid[]) to authenticated;

notify pgrst, 'reload schema';
