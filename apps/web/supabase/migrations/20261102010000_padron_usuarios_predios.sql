-- Padrón: usuarios de servicio y predios (migración desde dominio COBSER)

create type public.tipo_persona as enum ('natural', 'juridica', 'institucional');
create type public.sexo as enum ('M', 'F');
create type public.estado_registro as enum ('activo', 'inactivo');

create table if not exists public.cat_sectores (
  id uuid primary key default gen_random_uuid(),
  codigo text not null unique,
  nombre text not null,
  created_at timestamptz not null default now()
);

create table if not exists public.cat_calles (
  id uuid primary key default gen_random_uuid(),
  sector_id uuid references public.cat_sectores (id) on delete set null,
  nombre text not null,
  created_at timestamptz not null default now()
);

create table if not exists public.cat_tipos_predio (
  id uuid primary key default gen_random_uuid(),
  codigo text not null unique,
  nombre text not null
);

create table if not exists public.pad_usuarios (
  id uuid primary key default gen_random_uuid(),
  tipo_persona public.tipo_persona not null default 'natural',
  nombres text not null,
  apellido_paterno text not null default '',
  apellido_materno text not null default '',
  dni text,
  ruc text,
  sexo public.sexo,
  direccion text not null default '',
  email text,
  celular text,
  estado public.estado_registro not null default 'activo',
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now(),
  constraint pad_usuarios_dni_unique unique (dni),
  constraint pad_usuarios_ruc_unique unique (ruc)
);

create table if not exists public.pad_predios (
  id uuid primary key default gen_random_uuid(),
  usuario_id uuid not null references public.pad_usuarios (id) on delete restrict,
  tipo_predio_id uuid references public.cat_tipos_predio (id) on delete set null,
  sector_id uuid references public.cat_sectores (id) on delete set null,
  calle_id uuid references public.cat_calles (id) on delete set null,
  nombre text not null,
  numero text not null default '',
  manzana text not null default '',
  lote text not null default '',
  partida_registral text not null default '',
  unidad_catastral text not null default '',
  titulo text not null default '',
  fecha_documento date,
  coord_este text not null default '',
  coord_norte text not null default '',
  estado public.estado_registro not null default 'activo',
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

create index if not exists pad_usuarios_nombre_idx
  on public.pad_usuarios (nombres, apellido_paterno, apellido_materno);

create index if not exists pad_predios_usuario_idx
  on public.pad_predios (usuario_id);

create or replace function public.set_updated_at()
returns trigger
language plpgsql
as $$
begin
  new.updated_at = now();
  return new;
end;
$$;

drop trigger if exists pad_usuarios_set_updated_at on public.pad_usuarios;
create trigger pad_usuarios_set_updated_at
before update on public.pad_usuarios
for each row execute function public.set_updated_at();

drop trigger if exists pad_predios_set_updated_at on public.pad_predios;
create trigger pad_predios_set_updated_at
before update on public.pad_predios
for each row execute function public.set_updated_at();

alter table public.cat_sectores enable row level security;
alter table public.cat_calles enable row level security;
alter table public.cat_tipos_predio enable row level security;
alter table public.pad_usuarios enable row level security;
alter table public.pad_predios enable row level security;

create policy "authenticated read cat_sectores"
  on public.cat_sectores for select to authenticated using (true);
create policy "authenticated write cat_sectores"
  on public.cat_sectores for all to authenticated using (true) with check (true);

create policy "authenticated read cat_calles"
  on public.cat_calles for select to authenticated using (true);
create policy "authenticated write cat_calles"
  on public.cat_calles for all to authenticated using (true) with check (true);

create policy "authenticated read cat_tipos_predio"
  on public.cat_tipos_predio for select to authenticated using (true);
create policy "authenticated write cat_tipos_predio"
  on public.cat_tipos_predio for all to authenticated using (true) with check (true);

create policy "authenticated read pad_usuarios"
  on public.pad_usuarios for select to authenticated using (true);
create policy "authenticated write pad_usuarios"
  on public.pad_usuarios for all to authenticated using (true) with check (true);

create policy "authenticated read pad_predios"
  on public.pad_predios for select to authenticated using (true);
create policy "authenticated write pad_predios"
  on public.pad_predios for all to authenticated using (true) with check (true);

insert into public.cat_sectores (codigo, nombre) values
  ('S01', 'Sector 1'),
  ('S02', 'Sector 2'),
  ('S03', 'Sector 3')
on conflict (codigo) do nothing;

insert into public.cat_tipos_predio (codigo, nombre) values
  ('DOM', 'Doméstico'),
  ('COM', 'Comercial'),
  ('IND', 'Industrial'),
  ('EST', 'Estatal')
on conflict (codigo) do nothing;

insert into public.cat_calles (sector_id, nombre)
select s.id, c.nombre
from public.cat_sectores s
cross join (values ('Av. Principal'), ('Jr. Los Álamos'), ('Calle El Pedregal')) as c(nombre)
where s.codigo = 'S01'
  and not exists (
    select 1 from public.cat_calles existing
    where existing.nombre = c.nombre and existing.sector_id = s.id
  );
