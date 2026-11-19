-- Facturación de las deudas anteriores de un predio en un año y mes.
-- Una facturación junta todas las deudas de ese periodo que aún no tienen recibo.

create table if not exists public.fac_facturaciones (
  id uuid primary key default gen_random_uuid(),
  predio_id uuid not null references public.pad_predios (id) on delete restrict,
  anio integer not null,
  mes integer not null check (mes between 1 and 12),
  numero text not null,
  monto_total numeric(12, 2) not null check (monto_total > 0),
  fecha date not null default current_date,
  estado text not null default 'generada' check (estado in ('generada', 'anulada')),
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now(),
  unique (numero),
  unique (predio_id, anio, mes)
);

create index if not exists fac_facturaciones_periodo_idx
  on public.fac_facturaciones (anio, mes, estado);

create table if not exists public.fac_facturacion_detalle (
  id uuid primary key default gen_random_uuid(),
  facturacion_id uuid not null references public.fac_facturaciones (id) on delete cascade,
  deuda_anterior_id uuid not null references public.fac_deudas_anteriores (id) on delete restrict,
  tipo_servicio_id uuid not null references public.cat_tipos_servicio (id) on delete restrict,
  monto numeric(12, 2) not null check (monto > 0),
  unique (deuda_anterior_id)
);

create index if not exists fac_facturacion_detalle_facturacion_idx
  on public.fac_facturacion_detalle (facturacion_id);

drop trigger if exists fac_facturaciones_set_updated_at on public.fac_facturaciones;
create trigger fac_facturaciones_set_updated_at
before update on public.fac_facturaciones
for each row execute function public.set_updated_at();

alter table public.fac_facturaciones enable row level security;
alter table public.fac_facturacion_detalle enable row level security;

drop policy if exists "authenticated read fac_facturaciones" on public.fac_facturaciones;
create policy "authenticated read fac_facturaciones"
  on public.fac_facturaciones for select to authenticated using (true);

drop policy if exists "authenticated read fac_facturacion_detalle" on public.fac_facturacion_detalle;
create policy "authenticated read fac_facturacion_detalle"
  on public.fac_facturacion_detalle for select to authenticated using (true);

create or replace function public.listar_deudas_a_facturar(
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
    jsonb_agg(to_jsonb(t) order by t.usuario, t.predio),
    '[]'::jsonb
  )
  from (
    select
      p.id as predio_id,
      p.nombre as predio,
      p.numero as numero,
      btrim(concat_ws(' ', u.apellido_paterno, u.apellido_materno, u.nombres)) as usuario,
      coalesce(s.nombre, '') as sector,
      coalesce(c.nombre, '') as calle,
      count(d.id)::int as deudas,
      sum(d.saldo)::numeric(12, 2) as monto,
      p_anio as anio,
      p_mes as mes
    from public.fac_deudas_anteriores d
    join public.pad_predios p on p.id = d.predio_id
    join public.pad_usuarios u on u.id = p.usuario_id
    left join public.cat_sectores s on s.id = p.sector_id
    left join public.cat_calles c on c.id = p.calle_id
    where d.anio = p_anio
      and d.mes = p_mes
      and d.saldo > 0
      and p.estado = 'activo'
      and (p_sector_id is null or p.sector_id = p_sector_id)
      and (p_calle_id is null or p.calle_id = p_calle_id)
      and not exists (
        select 1
        from public.fac_facturacion_detalle fd
        where fd.deuda_anterior_id = d.id
      )
    group by
      p.id,
      p.nombre,
      p.numero,
      u.apellido_paterno,
      u.apellido_materno,
      u.nombres,
      s.nombre,
      c.nombre
  ) as t;
$$;

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
      f.anio,
      f.mes,
      f.monto_total as monto,
      f.fecha,
      (
        select count(*)::int
        from public.fac_facturacion_detalle fd
        where fd.facturacion_id = f.id
      ) as deudas
    from public.fac_facturaciones f
    join public.pad_predios p on p.id = f.predio_id
    join public.pad_usuarios u on u.id = p.usuario_id
    left join public.cat_sectores s on s.id = p.sector_id
    left join public.cat_calles c on c.id = p.calle_id
    where f.anio = p_anio
      and f.mes = p_mes
      and f.estado = 'generada'
      and (p_sector_id is null or p.sector_id = p_sector_id)
      and (p_calle_id is null or p.calle_id = p_calle_id)
  ) as t;
$$;

create or replace function public.generar_facturacion(
  p_anio integer,
  p_mes integer,
  p_predio_ids uuid[]
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
      predio_id, anio, mes, numero, monto_total, fecha, estado
    )
    values (
      rec.predio_id,
      p_anio,
      p_mes,
      'F' || p_anio::text || '-' || lpad(v_num::text, 6, '0'),
      v_monto,
      current_date,
      'generada'
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

revoke all on function public.listar_deudas_a_facturar(integer, integer, uuid, uuid) from public;
revoke all on function public.listar_facturaciones(integer, integer, uuid, uuid) from public;
revoke all on function public.generar_facturacion(integer, integer, uuid[]) from public;

grant execute on function public.listar_deudas_a_facturar(integer, integer, uuid, uuid) to authenticated;
grant execute on function public.listar_facturaciones(integer, integer, uuid, uuid) to authenticated;
grant execute on function public.generar_facturacion(integer, integer, uuid[]) to authenticated;

notify pgrst, 'reload schema';
