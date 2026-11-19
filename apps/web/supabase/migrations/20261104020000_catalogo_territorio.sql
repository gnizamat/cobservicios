-- Territorio y catálogo: calles con referencia, tipos de servicio, tarifas anuales y costos.

alter table public.cat_calles
  add column if not exists referencia text not null default '';

update public.cat_calles
set referencia = case nombre
  when 'Av. Principal' then 'Ingreso principal del sector'
  when 'Jr. Los Álamos' then 'Paralela a la avenida'
  when 'Calle El Pedregal' then 'Zona alta'
  else referencia
end
where referencia = '';

insert into public.cat_calles (sector_id, nombre, referencia)
select s.id, c.nombre, c.referencia
from public.cat_sectores s
join (
  values
    ('S02', 'Jr. Las Flores', 'Cuadra 1 al 4'),
    ('S02', 'Av. Los Pinos', 'Frente al local comunal'),
    ('S02', 'Pasaje Unión', 'Entre Las Flores y Los Pinos'),
    ('S03', 'Calle San Martín', 'Ingreso norte'),
    ('S03', 'Jr. Bolognesi', 'Paralela a San Martín')
) as c(codigo, nombre, referencia) on c.codigo = s.codigo
where not exists (
  select 1
  from public.cat_calles existing
  where existing.nombre = c.nombre
    and existing.sector_id = s.id
);

create type public.categoria_servicio as enum (
  'fijo',
  'unico',
  'volumen',
  'alcantarillado',
  'medidor'
);

create table if not exists public.cat_tipos_servicio (
  id uuid primary key default gen_random_uuid(),
  codigo text not null unique,
  nombre text not null,
  categoria public.categoria_servicio not null default 'fijo',
  estado public.estado_registro not null default 'activo',
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

create table if not exists public.cat_tarifas (
  id uuid primary key default gen_random_uuid(),
  anio integer not null unique,
  nombre text not null,
  modalidad text not null default 'Contraentrega',
  unidad_recaudacion text not null default 'Soles por metro cúbico (S/. * m3)',
  activa boolean not null default false,
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

create unique index if not exists cat_tarifas_una_activa
  on public.cat_tarifas ((true))
  where activa;

create table if not exists public.cat_costos_tarifa (
  id uuid primary key default gen_random_uuid(),
  tarifa_id uuid not null references public.cat_tarifas (id) on delete cascade,
  tipo_servicio_id uuid not null references public.cat_tipos_servicio (id) on delete restrict,
  valor numeric(12, 4) not null default 0,
  monto numeric(12, 2) not null default 0,
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now(),
  unique (tarifa_id, tipo_servicio_id)
);

drop trigger if exists cat_tipos_servicio_set_updated_at on public.cat_tipos_servicio;
create trigger cat_tipos_servicio_set_updated_at
before update on public.cat_tipos_servicio
for each row execute function public.set_updated_at();

drop trigger if exists cat_tarifas_set_updated_at on public.cat_tarifas;
create trigger cat_tarifas_set_updated_at
before update on public.cat_tarifas
for each row execute function public.set_updated_at();

drop trigger if exists cat_costos_tarifa_set_updated_at on public.cat_costos_tarifa;
create trigger cat_costos_tarifa_set_updated_at
before update on public.cat_costos_tarifa
for each row execute function public.set_updated_at();

alter table public.cat_tipos_servicio enable row level security;
alter table public.cat_tarifas enable row level security;
alter table public.cat_costos_tarifa enable row level security;

create policy "authenticated read cat_tipos_servicio"
  on public.cat_tipos_servicio for select to authenticated using (true);
create policy "authenticated write cat_tipos_servicio"
  on public.cat_tipos_servicio for all to authenticated using (true) with check (true);

create policy "authenticated read cat_tarifas"
  on public.cat_tarifas for select to authenticated using (true);
create policy "authenticated write cat_tarifas"
  on public.cat_tarifas for all to authenticated using (true) with check (true);

create policy "authenticated read cat_costos_tarifa"
  on public.cat_costos_tarifa for select to authenticated using (true);
create policy "authenticated write cat_costos_tarifa"
  on public.cat_costos_tarifa for all to authenticated using (true) with check (true);

insert into public.cat_tipos_servicio (codigo, nombre, categoria) values
  ('AGUA', 'Agua potable', 'fijo'),
  ('CUOTA', 'Cuota familiar', 'fijo'),
  ('CONEX', 'Conexión domiciliaria', 'unico'),
  ('VOL', 'Agua por volumen', 'volumen'),
  ('ALC', 'Alcantarillado', 'alcantarillado'),
  ('MED', 'Mantenimiento de medidor', 'medidor')
on conflict (codigo) do nothing;

insert into public.cat_tarifas (anio, nombre, modalidad, unidad_recaudacion, activa) values
  (2024, 'Tarifa 2024', 'Contraentrega', 'Soles por metro cúbico (S/. * m3)', false),
  (2025, 'Tarifa 2025', 'Contraentrega', 'Soles por metro cúbico (S/. * m3)', false),
  (2026, 'Tarifa 2026', 'Contraentrega', 'Soles por metro cúbico (S/. * m3)', true)
on conflict (anio) do nothing;

insert into public.cat_costos_tarifa (tarifa_id, tipo_servicio_id, valor, monto)
select t.id, s.id, v.valor, v.monto
from (
  values
    (2025, 'AGUA', 0::numeric, 12.00::numeric),
    (2025, 'CUOTA', 0::numeric, 4.00::numeric),
    (2025, 'CONEX', 0::numeric, 120.00::numeric),
    (2025, 'VOL', 1.00::numeric, 0::numeric),
    (2025, 'ALC', 0::numeric, 6.00::numeric),
    (2025, 'MED', 0::numeric, 2.50::numeric),
    (2026, 'AGUA', 0::numeric, 15.00::numeric),
    (2026, 'CUOTA', 0::numeric, 5.00::numeric),
    (2026, 'CONEX', 0::numeric, 150.00::numeric),
    (2026, 'VOL', 1.20::numeric, 0::numeric),
    (2026, 'ALC', 0::numeric, 8.00::numeric),
    (2026, 'MED', 0::numeric, 3.50::numeric)
) as v(anio, codigo, valor, monto)
join public.cat_tarifas t on t.anio = v.anio
join public.cat_tipos_servicio s on s.codigo = v.codigo
where not exists (
  select 1
  from public.cat_costos_tarifa existing
  where existing.tarifa_id = t.id
    and existing.tipo_servicio_id = s.id
);
