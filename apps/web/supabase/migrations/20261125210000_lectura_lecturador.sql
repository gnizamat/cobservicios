-- La lectura guarda quién la tomó. El combo muestra los colaboradores del centro poblado.

alter table public.hid_lecturas
  add column if not exists colaborador_id uuid references public.hid_colaboradores (id) on delete set null;

create index if not exists hid_lecturas_colaborador_id_idx
  on public.hid_lecturas (colaborador_id);

comment on column public.hid_lecturas.colaborador_id is
  'Colaborador que registró la lectura del medidor.';

drop function if exists public.registrar_lectura(uuid, uuid, uuid, integer, integer, date, numeric, numeric, numeric, text);

create function public.registrar_lectura(
  p_id uuid,
  p_predio_id uuid,
  p_tipo_servicio_id uuid,
  p_anio integer,
  p_mes integer,
  p_fecha_lectura date,
  p_lectura_m3 numeric,
  p_lectura_lt numeric,
  p_volumen_m3 numeric,
  p_referencia text,
  p_colaborador_id uuid default null
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
  v_prev_m3 numeric;
  v_prev_lt numeric;
begin
  if p_colaborador_id is not null
     and not exists (
       select 1 from public.hid_colaboradores where id = p_colaborador_id
     ) then
    raise exception 'El lecturador seleccionado no existe.';
  end if;

  if p_id is not null then
    select predio_id, anio, mes
    into v_old_predio, v_old_anio, v_old_mes
    from public.hid_lecturas
    where id = p_id;

    if not found then
      raise exception 'La lectura que querés editar ya no existe.';
    end if;
  end if;

  select l.lectura_m3, l.lectura_lt
  into v_prev_m3, v_prev_lt
  from public.hid_lecturas l
  where l.predio_id = p_predio_id
    and l.tipo_servicio_id = p_tipo_servicio_id
    and (l.anio * 12 + l.mes) < (p_anio * 12 + p_mes)
    and (p_id is null or l.id <> p_id)
  order by l.anio desc, l.mes desc
  limit 1;

  if not found then
    v_volumen := 0;
  else
    v_volumen := round(
      (
        (p_lectura_m3 * 1000 + coalesce(p_lectura_lt, 0))
        - (v_prev_m3 * 1000 + coalesce(v_prev_lt, 0))
      ) / 1000,
      3
    );
  end if;

  if v_volumen < 0 then
    raise exception 'La lectura es menor que la última registrada.';
  end if;

  if p_id is not null then
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
      referencia = coalesce(p_referencia, ''),
      colaborador_id = p_colaborador_id
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
      referencia,
      colaborador_id
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
      coalesce(p_referencia, ''),
      p_colaborador_id
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

revoke all on function public.registrar_lectura(uuid, uuid, uuid, integer, integer, date, numeric, numeric, numeric, text, uuid) from public;
grant execute on function public.registrar_lectura(uuid, uuid, uuid, integer, integer, date, numeric, numeric, numeric, text, uuid) to authenticated;

notify pgrst, 'reload schema';
