-- Cobranza de facturas pendientes: el pago marca la factura como cobrada
-- y deja en cero el saldo de las deudas que la componen.

do $$
declare
  r record;
begin
  for r in
    select conname
    from pg_constraint
    where conrelid = 'public.fac_facturaciones'::regclass
      and contype = 'c'
      and pg_get_constraintdef(oid) ilike '%estado%'
  loop
    execute format('alter table public.fac_facturaciones drop constraint %I', r.conname);
  end loop;
end $$;

alter table public.fac_facturaciones
  add constraint fac_facturaciones_estado_check
  check (estado in ('generada', 'cobrada', 'anulada'));

create table if not exists public.cob_pagos (
  id uuid primary key default gen_random_uuid(),
  predio_id uuid not null references public.pad_predios (id) on delete restrict,
  numero text not null,
  fecha date not null default current_date,
  tipo_pago text not null check (tipo_pago in ('efectivo', 'deposito', 'transferencia', 'yape')),
  referencia text not null default '',
  monto numeric(12, 2) not null check (monto > 0),
  interes numeric(12, 2) not null default 0 check (interes >= 0),
  anulado boolean not null default false,
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now(),
  unique (numero)
);

create index if not exists cob_pagos_predio_idx
  on public.cob_pagos (predio_id, fecha desc);

create table if not exists public.cob_pago_facturaciones (
  id uuid primary key default gen_random_uuid(),
  pago_id uuid not null references public.cob_pagos (id) on delete cascade,
  facturacion_id uuid not null references public.fac_facturaciones (id) on delete restrict,
  monto numeric(12, 2) not null check (monto > 0),
  unique (facturacion_id)
);

create index if not exists cob_pago_facturaciones_pago_idx
  on public.cob_pago_facturaciones (pago_id);

drop trigger if exists cob_pagos_set_updated_at on public.cob_pagos;
create trigger cob_pagos_set_updated_at
before update on public.cob_pagos
for each row execute function public.set_updated_at();

alter table public.cob_pagos enable row level security;
alter table public.cob_pago_facturaciones enable row level security;

drop policy if exists "authenticated read cob_pagos" on public.cob_pagos;
create policy "authenticated read cob_pagos"
  on public.cob_pagos for select to authenticated using (true);

drop policy if exists "authenticated read cob_pago_facturaciones" on public.cob_pago_facturaciones;
create policy "authenticated read cob_pago_facturaciones"
  on public.cob_pago_facturaciones for select to authenticated using (true);

create or replace function public.listar_predios_a_cobrar(
  p_sector_id uuid default null,
  p_calle_id uuid default null,
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
    jsonb_agg(to_jsonb(t) order by t.usuario, t.predio),
    '[]'::jsonb
  )
  from (
    select
      p.id as predio_id,
      p.nombre as predio,
      p.numero,
      btrim(concat_ws(' ', u.apellido_paterno, u.apellido_materno, u.nombres)) as usuario,
      case
        when coalesce(u.dni, '') <> '' then 'DNI ' || u.dni
        when coalesce(u.ruc, '') <> '' then 'RUC ' || u.ruc
        else ''
      end as documento,
      coalesce(s.nombre, '') as sector,
      coalesce(c.nombre, '') as calle,
      count(f.id)::int as facturas,
      sum(f.monto_total)::numeric(12, 2) as monto
    from public.fac_facturaciones f
    join public.pad_predios p on p.id = f.predio_id
    join public.pad_usuarios u on u.id = p.usuario_id
    left join public.cat_sectores s on s.id = p.sector_id
    left join public.cat_calles c on c.id = p.calle_id
    cross join term
    where f.estado = 'generada'
      and (p_sector_id is null or p.sector_id = p_sector_id)
      and (p_calle_id is null or p.calle_id = p_calle_id)
      and (
        term.value is null
        or u.nombres ilike '%' || term.value || '%'
        or u.apellido_paterno ilike '%' || term.value || '%'
        or u.apellido_materno ilike '%' || term.value || '%'
        or coalesce(u.dni, '') ilike '%' || term.value || '%'
        or coalesce(u.ruc, '') ilike '%' || term.value || '%'
        or p.nombre ilike '%' || term.value || '%'
        or p.numero ilike '%' || term.value || '%'
      )
    group by
      p.id,
      p.nombre,
      p.numero,
      u.apellido_paterno,
      u.apellido_materno,
      u.nombres,
      u.dni,
      u.ruc,
      s.nombre,
      c.nombre
  ) as t;
$$;

create or replace function public.cobrar_facturaciones(
  p_predio_id uuid,
  p_facturacion_ids uuid[],
  p_tipo_pago text,
  p_referencia text,
  p_fecha date
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
begin
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
    predio_id, numero, fecha, tipo_pago, referencia, monto, interes
  )
  values (
    p_predio_id, v_numero, p_fecha, v_tipo, v_ref, v_monto, v_interes
  )
  returning id into v_pago;

  insert into public.cob_pago_facturaciones (pago_id, facturacion_id, monto)
  select v_pago, f.id, f.monto_total
  from public.fac_facturaciones f
  where f.id = any (p_facturacion_ids);

  update public.fac_facturaciones
  set estado = 'cobrada'
  where id = any (p_facturacion_ids);

  update public.fac_deudas_anteriores d
  set saldo = 0,
      interes = 0
  from public.fac_facturacion_detalle fd
  where fd.deuda_anterior_id = d.id
    and fd.facturacion_id = any (p_facturacion_ids);

  return jsonb_build_object(
    'id', v_pago,
    'numero', v_numero,
    'monto', v_monto,
    'interes', v_interes,
    'facturas', v_esperadas
  );
end;
$$;

revoke all on function public.listar_predios_a_cobrar(uuid, uuid, text) from public;
revoke all on function public.cobrar_facturaciones(uuid, uuid[], text, text, date) from public;

grant execute on function public.listar_predios_a_cobrar(uuid, uuid, text) to authenticated;
grant execute on function public.cobrar_facturaciones(uuid, uuid[], text, text, date) to authenticated;

notify pgrst, 'reload schema';
