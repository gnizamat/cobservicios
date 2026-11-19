-- Datos de la JASS: identidad, contacto, logo y punto en el mapa.

create table if not exists public.org_jass (
  id boolean primary key default true check (id),
  nombre text not null,
  abreviatura text not null default '',
  celular text not null default '',
  direccion text not null default '',
  email text not null default '',
  logo_path text not null default '',
  latitud numeric(9, 6),
  longitud numeric(9, 6),
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

insert into public.org_jass (nombre, abreviatura, direccion, latitud, longitud)
values (
  'Junta Administradora de Servicios de Saneamiento Pedregal',
  'JASS Pedregal',
  'Pedregal',
  -5.194700,
  -80.616500
)
on conflict (id) do nothing;

drop trigger if exists org_jass_set_updated_at on public.org_jass;
create trigger org_jass_set_updated_at
before update on public.org_jass
for each row execute function public.set_updated_at();

alter table public.org_jass enable row level security;

drop policy if exists "authenticated read org_jass" on public.org_jass;
create policy "authenticated read org_jass"
  on public.org_jass for select to authenticated using (true);

drop policy if exists "authenticated write org_jass" on public.org_jass;
create policy "authenticated write org_jass"
  on public.org_jass for all to authenticated using (true) with check (true);

insert into storage.buckets (id, name, public, file_size_limit, allowed_mime_types)
values (
  'organizacion',
  'organizacion',
  true,
  2097152,
  array['image/png', 'image/jpeg', 'image/webp']
)
on conflict (id) do update
set
  public = excluded.public,
  file_size_limit = excluded.file_size_limit,
  allowed_mime_types = excluded.allowed_mime_types;

drop policy if exists "organizacion public read" on storage.objects;
create policy "organizacion public read"
  on storage.objects for select
  to public
  using (bucket_id = 'organizacion');

drop policy if exists "organizacion authenticated insert" on storage.objects;
create policy "organizacion authenticated insert"
  on storage.objects for insert
  to authenticated
  with check (bucket_id = 'organizacion');

drop policy if exists "organizacion authenticated update" on storage.objects;
create policy "organizacion authenticated update"
  on storage.objects for update
  to authenticated
  using (bucket_id = 'organizacion');

drop policy if exists "organizacion authenticated delete" on storage.objects;
create policy "organizacion authenticated delete"
  on storage.objects for delete
  to authenticated
  using (bucket_id = 'organizacion');
