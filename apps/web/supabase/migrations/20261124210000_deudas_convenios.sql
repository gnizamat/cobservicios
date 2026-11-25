-- Convenio del costo del medidor: cuotas fijas desde la fecha elegida.
-- La cuota conserva el costo del año en que se firma, aunque el mes caiga en el año siguiente.

create or replace function public.fac_deuda_anterior_validar()
returns trigger
language plpgsql
as $$
declare
  anio_tarifa integer;
begin
  select anio into anio_tarifa
  from public.cat_tarifas
  where id = new.tarifa_id;

  if anio_tarifa is null then
    raise exception 'La tarifa seleccionada no existe';
  end if;

  if anio_tarifa <> new.anio
    and (new.concepto not like 'Convenio %' or anio_tarifa > new.anio) then
    raise exception 'El año no corresponde a la tarifa seleccionada';
  end if;

  if not exists (
    select 1
    from public.cat_costos_tarifa
    where tarifa_id = new.tarifa_id
      and tipo_servicio_id = new.tipo_servicio_id
  ) then
    raise exception 'Ese tipo de tarifa no tiene costo en el año seleccionado';
  end if;

  if tg_op = 'INSERT' then
    new.saldo := new.monto;
  end if;

  return new;
end;
$$;

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
  v_busqueda text := nullif(btrim(coalesce(p_busqueda, '')), '');
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
        or u.nombres ilike '%' || v_busqueda || '%'
        or u.apellido_paterno ilike '%' || v_busqueda || '%'
        or u.apellido_materno ilike '%' || v_busqueda || '%'
        or coalesce(u.dni, '') ilike '%' || v_busqueda || '%'
        or coalesce(u.ruc, '') ilike '%' || v_busqueda || '%'
        or p.nombre ilike '%' || v_busqueda || '%'
        or coalesce(p.numero, '') ilike '%' || v_busqueda || '%'
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

create or replace function public.generar_convenio_medidor(
  p_fecha date,
  p_cuotas integer,
  p_predio_ids uuid[]
)
returns jsonb
language plpgsql
security invoker
set search_path = public
as $$
declare
  v_servicio_id uuid;
  v_servicio text;
  v_monto numeric(12, 2);
  v_anio integer;
  v_mes integer;
  v_anio_cursor integer;
  v_mes_cursor integer;
  v_tarifa uuid;
  v_cents integer;
  v_base integer;
  v_resto integer;
  v_importe numeric(12, 2);
  v_predio uuid;
  v_predios integer := 0;
  v_generadas integer := 0;
  i integer;
begin
  if p_fecha is null then
    raise exception 'Indicá la fecha del convenio';
  end if;
  if p_cuotas is null or p_cuotas < 1 or p_cuotas > 36 then
    raise exception 'Las cuotas tienen que ser entre 1 y 36 meses';
  end if;
  if p_predio_ids is null or cardinality(p_predio_ids) = 0 then
    raise exception 'Seleccioná al menos un predio';
  end if;

  v_anio := extract(year from p_fecha)::integer;
  v_mes := extract(month from p_fecha)::integer;

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
    and t.anio = v_anio
  order by t.activa desc, t.nombre
  limit 1;

  if v_monto is null or v_monto <= 0 then
    raise exception 'El costo de medidor no tiene valor en el año %', v_anio;
  end if;

  select t.id
  into v_tarifa
  from public.cat_tarifas t
  join public.cat_costos_tarifa c on c.tarifa_id = t.id
  where t.anio = v_anio
    and c.tipo_servicio_id = v_servicio_id
  order by t.activa desc, t.nombre
  limit 1;

  v_cents := round(v_monto * 100)::integer;
  v_base := v_cents / p_cuotas;
  v_resto := v_cents - (v_base * p_cuotas);
  if v_base <= 0 then
    raise exception 'El costo no alcanza para tantas cuotas';
  end if;

  perform pg_advisory_xact_lock(hashtext('convenio-medidor'), v_anio);

  foreach v_predio in array p_predio_ids loop
    if not exists (
      select 1 from public.pad_predios where id = v_predio and estado = 'activo'
    ) then
      continue;
    end if;
    if exists (
      select 1
      from public.fac_deudas_anteriores
      where predio_id = v_predio
        and tipo_servicio_id = v_servicio_id
    ) then
      continue;
    end if;

    v_anio_cursor := v_anio;
    v_mes_cursor := v_mes;
    v_predios := v_predios + 1;

    for i in 1..p_cuotas loop
      v_importe := (case when i = p_cuotas then v_base + v_resto else v_base end)::numeric / 100;

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
        v_servicio_id,
        v_anio_cursor,
        v_mes_cursor,
        v_importe,
        v_importe,
        0,
        0,
        format('Convenio %s %s/%s', v_servicio, i, p_cuotas),
        p_fecha
      );

      v_generadas := v_generadas + 1;
      if v_mes_cursor = 12 then
        v_anio_cursor := v_anio_cursor + 1;
        v_mes_cursor := 1;
      else
        v_mes_cursor := v_mes_cursor + 1;
      end if;
    end loop;
  end loop;

  return jsonb_build_object(
    'servicio', v_servicio,
    'monto', v_monto,
    'cuotas', p_cuotas,
    'cuota', v_base::numeric / 100,
    'ultima', (v_base + v_resto)::numeric / 100,
    'predios', v_predios,
    'generadas', v_generadas
  );
end;
$$;

revoke all on function public.listar_predios_convenio_medidor(integer, uuid, uuid, text) from public;
revoke all on function public.generar_convenio_medidor(date, integer, uuid[]) from public;
grant execute on function public.listar_predios_convenio_medidor(integer, uuid, uuid, text) to authenticated;
grant execute on function public.generar_convenio_medidor(date, integer, uuid[]) to authenticated;

notify pgrst, 'reload schema';
