-- Al registrar o corregir una lectura se graba la deuda de volumen
-- del mismo predio, año y mes: metros cúbicos y monto según la tarifa.

create or replace function public.sync_deuda_volumen(
  p_predio_id uuid,
  p_anio integer,
  p_mes integer,
  p_tipo_servicio_id uuid,
  p_tarifa_id uuid,
  p_concepto text,
  p_volumen numeric,
  p_monto numeric,
  p_fecha date
)
returns void
language plpgsql
security invoker
set search_path = public
as $$
declare
  v_id uuid;
  v_monto numeric(12, 2);
  v_volumen numeric(12, 3);
  v_facturada boolean;
begin
  select d.id, d.monto, d.volumen
  into v_id, v_monto, v_volumen
  from public.fac_deudas_anteriores d
  where d.predio_id = p_predio_id
    and d.anio = p_anio
    and d.mes = p_mes
    and d.tipo_servicio_id = p_tipo_servicio_id;

  v_facturada := v_id is not null and exists (
    select 1
    from public.fac_facturacion_detalle fd
    where fd.deuda_anterior_id = v_id
  );

  if p_monto <= 0 then
    if v_id is null then
      return;
    end if;
    if v_facturada then
      raise exception 'Esa deuda ya está en un recibo. No se puede dejar el volumen en cero.';
    end if;
    delete from public.fac_deudas_anteriores where id = v_id;
    return;
  end if;

  if p_tarifa_id is null then
    raise exception 'No hay tarifa de volumen para ese año.';
  end if;

  if v_id is null then
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
      p_predio_id,
      p_tarifa_id,
      p_tipo_servicio_id,
      p_anio,
      p_mes,
      p_monto,
      p_monto,
      p_volumen,
      0,
      coalesce(p_concepto, ''),
      p_fecha
    );
    return;
  end if;

  if v_facturada then
    if v_monto is distinct from p_monto or v_volumen is distinct from p_volumen then
      raise exception 'Esa deuda ya está en un recibo. No se puede cambiar el volumen ni el monto.';
    end if;
    return;
  end if;

  update public.fac_deudas_anteriores
  set
    tarifa_id = p_tarifa_id,
    monto = p_monto,
    saldo = p_monto,
    volumen = p_volumen,
    concepto = coalesce(p_concepto, ''),
    fecha_registro = p_fecha
  where id = v_id;
end;
$$;

create or replace function public.registrar_lectura(
  p_id uuid,
  p_predio_id uuid,
  p_tipo_servicio_id uuid,
  p_anio integer,
  p_mes integer,
  p_fecha_lectura date,
  p_lectura_m3 numeric,
  p_lectura_lt numeric,
  p_volumen_m3 numeric,
  p_referencia text
)
returns jsonb
language plpgsql
security invoker
set search_path = public
as $$
declare
  v_lectura public.hid_lecturas;
  v_old_predio uuid;
  v_old_anio integer;
  v_old_mes integer;
  v_servicio uuid;
  v_nombre text;
  v_tarifa uuid;
  v_valor numeric;
  v_volumen numeric(12, 3);
  v_monto numeric(12, 2);
begin
  if p_volumen_m3 < 0 then
    raise exception 'El volumen no puede ser negativo.';
  end if;

  v_volumen := round(p_volumen_m3, 3);

  if p_id is not null then
    select predio_id, anio, mes
    into v_old_predio, v_old_anio, v_old_mes
    from public.hid_lecturas
    where id = p_id;

    if not found then
      raise exception 'La lectura que querés editar ya no existe.';
    end if;

    update public.hid_lecturas
    set
      predio_id = p_predio_id,
      tipo_servicio_id = p_tipo_servicio_id,
      anio = p_anio,
      mes = p_mes,
      fecha_lectura = p_fecha_lectura,
      lectura_m3 = p_lectura_m3,
      lectura_lt = p_lectura_lt,
      volumen_m3 = v_volumen,
      referencia = coalesce(p_referencia, '')
    where id = p_id
    returning * into v_lectura;
  else
    insert into public.hid_lecturas (
      predio_id,
      tipo_servicio_id,
      anio,
      mes,
      fecha_lectura,
      lectura_m3,
      lectura_lt,
      volumen_m3,
      referencia
    )
    values (
      p_predio_id,
      p_tipo_servicio_id,
      p_anio,
      p_mes,
      p_fecha_lectura,
      p_lectura_m3,
      p_lectura_lt,
      v_volumen,
      coalesce(p_referencia, '')
    )
    returning * into v_lectura;
  end if;

  select s.id, s.nombre
  into v_servicio, v_nombre
  from public.cat_tipos_servicio s
  where s.categoria = 'volumen'
  order by (s.codigo = 'VOL') desc, s.codigo
  limit 1;

  if v_servicio is null then
    raise exception 'No hay un servicio de volumen para generar la deuda.';
  end if;

  select t.id, c.valor
  into v_tarifa, v_valor
  from public.cat_tarifas t
  join public.cat_costos_tarifa c
    on c.tarifa_id = t.id
   and c.tipo_servicio_id = v_servicio
  where t.anio = p_anio;

  v_valor := coalesce(v_valor, 0);
  v_monto := round(v_volumen * v_valor, 2);

  if v_volumen > 0 and (v_tarifa is null or v_valor <= 0 or v_monto <= 0) then
    raise exception 'No hay tarifa de volumen para ese año.';
  end if;

  perform public.sync_deuda_volumen(
    p_predio_id,
    p_anio,
    p_mes,
    v_servicio,
    v_tarifa,
    v_nombre,
    v_volumen,
    v_monto,
    p_fecha_lectura
  );

  if p_id is not null
     and (
       v_old_predio is distinct from p_predio_id
       or v_old_anio is distinct from p_anio
       or v_old_mes is distinct from p_mes
     ) then
    perform public.sync_deuda_volumen(
      v_old_predio,
      v_old_anio,
      v_old_mes,
      v_servicio,
      null,
      v_nombre,
      0,
      0,
      p_fecha_lectura
    );
  end if;

  return jsonb_build_object(
    'lectura', to_jsonb(v_lectura),
    'deuda_generada', v_monto > 0,
    'deuda_monto', v_monto,
    'deuda_volumen', v_volumen
  );
end;
$$;

revoke all on function public.sync_deuda_volumen(uuid, integer, integer, uuid, uuid, text, numeric, numeric, date) from public;
revoke all on function public.registrar_lectura(uuid, uuid, uuid, integer, integer, date, numeric, numeric, numeric, text) from public;
grant execute on function public.sync_deuda_volumen(uuid, integer, integer, uuid, uuid, text, numeric, numeric, date) to authenticated;
grant execute on function public.registrar_lectura(uuid, uuid, uuid, integer, integer, date, numeric, numeric, numeric, text) to authenticated;

notify pgrst, 'reload schema';
