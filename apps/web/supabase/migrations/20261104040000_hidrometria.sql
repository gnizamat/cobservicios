-- Hidrometría: lecturas de medidor, volumen sin lectura y control de estructuras.

create table if not exists public.hid_estructuras (
  id uuid primary key default gen_random_uuid(),
  codigo text not null unique,
  nombre text not null,
  created_at timestamptz not null default now()
);

create table if not exists public.hid_lecturas (
  id uuid primary key default gen_random_uuid(),
  predio_id uuid not null references public.pad_predios (id) on delete restrict,
  tipo_servicio_id uuid not null references public.cat_tipos_servicio (id) on delete restrict,
  anio integer not null,
  mes integer not null check (mes between 1 and 12),
  fecha_lectura date not null default current_date,
  lectura_m3 numeric(12, 3) not null default 0,
  lectura_lt numeric(12, 3) not null default 0,
  volumen_m3 numeric(12, 3) not null default 0,
  referencia text not null default '',
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now(),
  unique (predio_id, tipo_servicio_id, anio, mes)
);

create table if not exists public.hid_volumenes_sin_lectura (
  id uuid primary key default gen_random_uuid(),
  predio_id uuid not null references public.pad_predios (id) on delete restrict,
  tipo_servicio_id uuid not null references public.cat_tipos_servicio (id) on delete restrict,
  anio integer not null,
  mes integer not null check (mes between 1 and 12),
  volumen_m3 numeric(12, 3) not null default 0,
  referencia text not null default '',
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now(),
  unique (predio_id, tipo_servicio_id, anio, mes)
);

create table if not exists public.hid_control (
  id uuid primary key default gen_random_uuid(),
  estructura_id uuid not null references public.hid_estructuras (id) on delete restrict,
  anio integer not null,
  mes integer not null check (mes between 1 and 12),
  fecha_lectura date not null default current_date,
  hora_inicio time not null,
  hora_fin time not null,
  lectura_inicial numeric(12, 3) not null default 0,
  lectura_final numeric(12, 3) not null default 0,
  volumen_m3 numeric(12, 3) not null default 0,
  cloro_inicial numeric(8, 3) not null default 0,
  cloro_final numeric(8, 3) not null default 0,
  referencia text not null default '',
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

drop trigger if exists hid_lecturas_set_updated_at on public.hid_lecturas;
create trigger hid_lecturas_set_updated_at
before update on public.hid_lecturas
for each row execute function public.set_updated_at();

drop trigger if exists hid_volumenes_sin_lectura_set_updated_at on public.hid_volumenes_sin_lectura;
create trigger hid_volumenes_sin_lectura_set_updated_at
before update on public.hid_volumenes_sin_lectura
for each row execute function public.set_updated_at();

drop trigger if exists hid_control_set_updated_at on public.hid_control;
create trigger hid_control_set_updated_at
before update on public.hid_control
for each row execute function public.set_updated_at();

alter table public.hid_estructuras enable row level security;
alter table public.hid_lecturas enable row level security;
alter table public.hid_volumenes_sin_lectura enable row level security;
alter table public.hid_control enable row level security;

create policy "authenticated read hid_estructuras"
  on public.hid_estructuras for select to authenticated using (true);
create policy "authenticated write hid_estructuras"
  on public.hid_estructuras for all to authenticated using (true) with check (true);

create policy "authenticated read hid_lecturas"
  on public.hid_lecturas for select to authenticated using (true);
create policy "authenticated write hid_lecturas"
  on public.hid_lecturas for all to authenticated using (true) with check (true);

create policy "authenticated read hid_volumenes_sin_lectura"
  on public.hid_volumenes_sin_lectura for select to authenticated using (true);
create policy "authenticated write hid_volumenes_sin_lectura"
  on public.hid_volumenes_sin_lectura for all to authenticated using (true) with check (true);

create policy "authenticated read hid_control"
  on public.hid_control for select to authenticated using (true);
create policy "authenticated write hid_control"
  on public.hid_control for all to authenticated using (true) with check (true);

insert into public.hid_estructuras (codigo, nombre) values
  ('RES', 'Reservorio principal'),
  ('BOM', 'Estación de bombeo')
on conflict (codigo) do nothing;
