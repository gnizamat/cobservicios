-- Listado de pagos: caja de cobranza, anulación con clave y trazabilidad.
-- Anular no borra el recibo: lo marca anulado, reabre las facturas y deja el evento.

create table if not exists public.cob_cajas (
  id uuid primary key default gen_random_uuid(),
  nombre text not null,
  activa boolean not null default true,
  created_at timestamptz not null default now(),
  unique (nombre)
);

insert into public.cob_cajas (nombre)
select 'Caja principal'
where not exists (select 1 from public.cob_cajas);

alter table public.cob_pagos
  add column if not exists caja_id uuid references public.cob_cajas (id) on delete restrict;

update public.cob_pagos
set caja_id = (select id from public.cob_cajas order by nombre limit 1)
where caja_id is null;

alter table public.cob_pagos
  alter column caja_id set not null;

create index if not exists cob_pagos_fecha_idx
  on public.cob_pagos (fecha desc, numero desc);

alter table public.cob_pago_facturaciones
  add column if not exists vigente boolean not null default true;

do $$
declare
  r record;
begin
  for r in
    select conname
    from pg_constraint
    where conrelid = 'public.cob_pago_facturaciones'::regclass
      and contype = 'u'
      and pg_get_constraintdef(oid) ilike '%facturacion_id%'
  loop
    execute format(
      'alter table public.cob_pago_facturaciones drop constraint %I',
      r.conname
    );
  end loop;
end $$;

create unique index if not exists cob_pago_facturaciones_vigente_uidx
  on public.cob_pago_facturaciones (facturacion_id)
  where vigente;

create table if not exists public.cob_pago_deudas (
  pago_id uuid not null references public.cob_pagos (id) on delete restrict,
  deuda_anterior_id uuid not null references public.fac_deudas_anteriores (id) on delete restrict,
  saldo numeric(12, 2) not null check (saldo >= 0),
  interes numeric(12, 2) not null check (interes >= 0),
  primary key (pago_id, deuda_anterior_id)
);

insert into public.cob_pago_deudas (pago_id, deuda_anterior_id, saldo, interes)
select l.pago_id, d.id, d.monto, d.interes
from public.cob_pago_facturaciones l
join public.fac_facturacion_detalle fd on fd.facturacion_id = l.facturacion_id
join public.fac_deudas_anteriores d on d.id = fd.deuda_anterior_id
on conflict do nothing;

create table if not exists public.cob_pago_eventos (
  id uuid primary key default gen_random_uuid(),
  pago_id uuid not null references public.cob_pagos (id) on delete restrict,
  accion text not null check (accion in ('cobro', 'anulacion')),
  actor_id uuid,
  actor_email text not null default '',
  motivo text not null default '',
  detalle jsonb not null default '{}'::jsonb,
  created_at timestamptz not null default now()
);

create index if not exists cob_pago_eventos_pago_idx
  on public.cob_pago_eventos (pago_id, created_at desc);

alter table public.cob_cajas enable row level security;
alter table public.cob_pago_deudas enable row level security;
alter table public.cob_pago_eventos enable row level security;

drop policy if exists "authenticated read cob_cajas" on public.cob_cajas;
create policy "authenticated read cob_cajas"
  on public.cob_cajas for select to authenticated using (true);

drop policy if exists "authenticated read cob_pago_deudas" on public.cob_pago_deudas;
create policy "authenticated read cob_pago_deudas"
  on public.cob_pago_deudas for select to authenticated using (true);

drop policy if exists "authenticated read cob_pago_eventos" on public.cob_pago_eventos;
create policy "authenticated read cob_pago_eventos"
  on public.cob_pago_eventos for select to authenticated using (true);

create or replace function public.listar_pagos(
  p_sector_id uuid default null,
  p_caja_id uuid default null,
  p_desde date default null,
  p_hasta date default null,
  p_search text default null
)
returns jsonb
language sql
stable
security invoker
set search_path = public
as $$
  with term as (
    select nullif(
      regexp_replace(btrim(coalesce(p_search, '')), '[%_\\]', '', 'g'),
      ''
    ) as value
  )
  select coalesce(
    jsonb_agg(to_jsonb(t) order by t.fecha desc, t.numero desc),
    '[]'::jsonb
  )
  from (
    select
      p.id,
      p.numero,
      p.fecha,
      p.tipo_pago,
      p.referencia,
      p.monto,
      p.interes,
      p.anulado,
      p.caja_id,
      coalesce(cj.nombre, '') as caja,
      pr.nombre as predio,
      coalesce(pr.numero, '') as numero_predio,
      btrim(concat_ws(' ', u.apellido_paterno, u.apellido_materno, u.nombres)) as usuario,
      case
        when coalesce(u.dni, '') <> '' then 'DNI ' || u.dni
        when coalesce(u.ruc, '') <> '' then 'RUC ' || u.ruc
        else ''
      end as documento,
      coalesce(s.nombre, '') as sector,
      coalesce(c.nombre, '') as calle,
      coalesce(ev.actor_email, '') as anulado_por,
      ev.motivo as motivo_anulacion,
      ev.created_at as anulado_en,
      coalesce(fac.numeros, '') as facturas
    from public.cob_pagos p
    join public.pad_predios pr on pr.id = p.predio_id
    join public.pad_usuarios u on u.id = pr.usuario_id
    left join public.cat_sectores s on s.id = pr.sector_id
    left join public.cat_calles c on c.id = pr.calle_id
    left join public.cob_cajas cj on cj.id = p.caja_id
    left join lateral (
      select e.actor_email, e.motivo, e.created_at
      from public.cob_pago_eventos e
      where e.pago_id = p.id
        and e.accion = 'anulacion'
      order by e.created_at desc
      limit 1
    ) ev on true
    left join lateral (
      select string_agg(f.numero, ', ' order by f.numero) as numeros
      from public.cob_pago_facturaciones l
      join public.fac_facturaciones f on f.id = l.facturacion_id
      where l.pago_id = p.id
    ) fac on true
    cross join term
    where (p_sector_id is null or pr.sector_id = p_sector_id)
      and (p_caja_id is null or p.caja_id = p_caja_id)
      and (p_desde is null or p.fecha >= p_desde)
      and (p_hasta is null or p.fecha <= p_hasta)
      and (
        term.value is null
        or p.numero ilike '%' || term.value || '%'
        or u.nombres ilike '%' || term.value || '%'
        or u.apellido_paterno ilike '%' || term.value || '%'
        or u.apellido_materno ilike '%' || term.value || '%'
        or coalesce(u.dni, '') ilike '%' || term.value || '%'
        or coalesce(u.ruc, '') ilike '%' || term.value || '%'
        or pr.nombre ilike '%' || term.value || '%'
        or coalesce(pr.numero, '') ilike '%' || term.value || '%'
      )
  ) as t;
$$;

drop function if exists public.cobrar_facturaciones(uuid, uuid[], text, text, date);

create or replace function public.cobrar_facturaciones(
  p_predio_id uuid,
  p_facturacion_ids uuid[],
  p_tipo_pago text,
  p_referencia text,
  p_fecha date,
  p_caja_id uuid default null
)
returns jsonb
language plpgsql
security definer
set search_path = public
as $$
declare
  v_tipo text := lower(btrim(coalesce(p_tipo_pago, '')));
  v_ref text := btrim(coalesce(p_referencia, ''));
  v_esperadas integer;
  v_encontradas integer;
  v_monto numeric(12, 2);
  v_interes numeric(12, 2);
  v_num integer;
  v_numero text;
  v_pago uuid;
  v_anio integer;
  v_caja uuid := p_caja_id;
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión para cobrar';
  end if;

  if p_predio_id is null then
    raise exception 'Seleccioná un predio';
  end if;

  if p_facturacion_ids is null or cardinality(p_facturacion_ids) = 0 then
    raise exception 'Seleccioná al menos una facturación';
  end if;

  if v_tipo not in ('efectivo', 'deposito', 'transferencia', 'yape') then
    raise exception 'Elegí un tipo de pago';
  end if;

  if v_tipo <> 'efectivo' and v_ref = '' then
    raise exception 'Indicá la referencia del pago';
  end if;

  if p_fecha is null then
    raise exception 'Indicá la fecha de cobranza';
  end if;

  if v_caja is null then
    select id into v_caja
    from public.cob_cajas
    where activa
    order by nombre
    limit 1;
  end if;

  if v_caja is null or not exists (
    select 1 from public.cob_cajas where id = v_caja and activa
  ) then
    raise exception 'Elegí una caja activa';
  end if;

  select count(distinct x) into v_esperadas
  from unnest(p_facturacion_ids) as x;

  select count(*) into v_encontradas
  from public.fac_facturaciones f
  where f.id = any (p_facturacion_ids)
    and f.predio_id = p_predio_id
    and f.estado = 'generada';

  if v_encontradas <> v_esperadas then
    raise exception 'Alguna facturación ya fue cobrada o no pertenece a ese predio';
  end if;

  select coalesce(sum(f.monto_total), 0)
  into v_monto
  from public.fac_facturaciones f
  where f.id = any (p_facturacion_ids);

  select coalesce(sum(d.interes), 0)
  into v_interes
  from public.fac_facturacion_detalle fd
  join public.fac_deudas_anteriores d on d.id = fd.deuda_anterior_id
  where fd.facturacion_id = any (p_facturacion_ids);

  if v_monto <= 0 then
    raise exception 'El monto a cobrar debe ser mayor que cero';
  end if;

  v_anio := extract(year from p_fecha)::integer;
  perform pg_advisory_xact_lock(74822, v_anio);

  select coalesce(max((regexp_match(numero, '-([0-9]+)$'))[1]::integer), 0)
  into v_num
  from public.cob_pagos
  where numero like 'P' || v_anio::text || '-%';

  v_numero := 'P' || v_anio::text || '-' || lpad((v_num + 1)::text, 6, '0');

  insert into public.cob_pagos (
    predio_id, caja_id, numero, fecha, tipo_pago, referencia, monto, interes
  )
  values (
    p_predio_id, v_caja, v_numero, p_fecha, v_tipo, v_ref, v_monto, v_interes
  )
  returning id into v_pago;

  insert into public.cob_pago_facturaciones (pago_id, facturacion_id, monto)
  select v_pago, f.id, f.monto_total
  from public.fac_facturaciones f
  where f.id = any (p_facturacion_ids);

  insert into public.cob_pago_deudas (pago_id, deuda_anterior_id, saldo, interes)
  select v_pago, d.id, d.saldo, d.interes
  from public.fac_facturacion_detalle fd
  join public.fac_deudas_anteriores d on d.id = fd.deuda_anterior_id
  where fd.facturacion_id = any (p_facturacion_ids);

  update public.fac_facturaciones
  set estado = 'cobrada'
  where id = any (p_facturacion_ids);

  update public.fac_deudas_anteriores d
  set saldo = 0,
      interes = 0
  from public.fac_facturacion_detalle fd
  where fd.deuda_anterior_id = d.id
    and fd.facturacion_id = any (p_facturacion_ids);

  insert into public.cob_pago_eventos (pago_id, accion, actor_id, actor_email, detalle)
  values (
    v_pago,
    'cobro',
    auth.uid(),
    coalesce(auth.jwt() ->> 'email', ''),
    jsonb_build_object(
      'numero', v_numero,
      'monto', v_monto,
      'interes', v_interes,
      'caja_id', v_caja,
      'facturacion_ids', to_jsonb(p_facturacion_ids)
    )
  );

  return jsonb_build_object(
    'id', v_pago,
    'numero', v_numero,
    'monto', v_monto,
    'interes', v_interes,
    'facturas', v_esperadas
  );
end;
$$;

create or replace function public.anular_pago(
  p_pago_id uuid,
  p_clave text,
  p_motivo text
)
returns jsonb
language plpgsql
security definer
set search_path = public, extensions
as $$
declare
  v_pago public.cob_pagos%rowtype;
  v_motivo text := btrim(coalesce(p_motivo, ''));
  v_email text := coalesce(auth.jwt() ->> 'email', '');
  v_facturas integer;
  v_detalle jsonb;
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión para eliminar el pago';
  end if;

  if btrim(coalesce(p_clave, '')) = '' then
    raise exception 'Ingresá tu contraseña para eliminar el pago';
  end if;

  if length(v_motivo) < 5 then
    raise exception 'Indicá el motivo de la eliminación';
  end if;

  if not exists (
    select 1
    from auth.users u
    where u.id = auth.uid()
      and u.encrypted_password = extensions.crypt(p_clave, u.encrypted_password)
  ) then
    raise exception 'La contraseña no es correcta';
  end if;

  select * into v_pago
  from public.cob_pagos
  where id = p_pago_id
  for update;

  if not found then
    raise exception 'No se encontró el pago';
  end if;

  if v_pago.anulado then
    raise exception 'Ese pago ya fue eliminado';
  end if;

  select coalesce(
    jsonb_agg(
      jsonb_build_object('id', f.id, 'numero', f.numero, 'monto', l.monto)
      order by f.numero
    ),
    '[]'::jsonb
  )
  into v_detalle
  from public.cob_pago_facturaciones l
  join public.fac_facturaciones f on f.id = l.facturacion_id
  where l.pago_id = p_pago_id
    and l.vigente;

  if exists (select 1 from public.cob_pago_deudas where pago_id = p_pago_id) then
    update public.fac_deudas_anteriores d
    set saldo = s.saldo,
        interes = s.interes
    from public.cob_pago_deudas s
    where s.pago_id = p_pago_id
      and s.deuda_anterior_id = d.id;
  else
    update public.fac_deudas_anteriores d
    set saldo = fd.monto
    from public.cob_pago_facturaciones l
    join public.fac_facturacion_detalle fd on fd.facturacion_id = l.facturacion_id
    where l.pago_id = p_pago_id
      and l.vigente
      and fd.deuda_anterior_id = d.id;
  end if;

  update public.fac_facturaciones f
  set estado = 'generada'
  from public.cob_pago_facturaciones l
  where l.pago_id = p_pago_id
    and l.vigente
    and l.facturacion_id = f.id
    and f.estado = 'cobrada';

  get diagnostics v_facturas = row_count;

  update public.cob_pago_facturaciones
  set vigente = false
  where pago_id = p_pago_id
    and vigente;

  update public.cob_pagos
  set anulado = true
  where id = p_pago_id;

  insert into public.cob_pago_eventos (
    pago_id, accion, actor_id, actor_email, motivo, detalle
  )
  values (
    p_pago_id,
    'anulacion',
    auth.uid(),
    v_email,
    v_motivo,
    jsonb_build_object(
      'numero', v_pago.numero,
      'monto', v_pago.monto,
      'fecha', v_pago.fecha,
      'caja_id', v_pago.caja_id,
      'facturas', v_detalle
    )
  );

  return jsonb_build_object(
    'id', p_pago_id,
    'numero', v_pago.numero,
    'facturas', v_facturas
  );
end;
$$;

revoke all on function public.listar_pagos(uuid, uuid, date, date, text) from public;
revoke all on function public.cobrar_facturaciones(uuid, uuid[], text, text, date, uuid) from public;
revoke all on function public.anular_pago(uuid, text, text) from public;

grant execute on function public.listar_pagos(uuid, uuid, date, date, text) to authenticated;
grant execute on function public.cobrar_facturaciones(uuid, uuid[], text, text, date, uuid) to authenticated;
grant execute on function public.anular_pago(uuid, text, text) to authenticated;

notify pgrst, 'reload schema';
