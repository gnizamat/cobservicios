-- Catálogo de marcas de medidor. El medidor asignado referencia una marca.

create table if not exists public.hid_marcas_medidor (
  id uuid primary key default gen_random_uuid(),
  nombre text not null unique,
  created_at timestamptz not null default now()
);

alter table public.hid_marcas_medidor enable row level security;

create policy "authenticated read hid_marcas_medidor"
  on public.hid_marcas_medidor for select to authenticated using (true);
create policy "authenticated write hid_marcas_medidor"
  on public.hid_marcas_medidor for all to authenticated using (true) with check (true);

insert into public.hid_marcas_medidor (nombre) values
  ('Actaris'),
  ('Arad'),
  ('Badger'),
  ('Diehl'),
  ('Dorot'),
  ('Elster'),
  ('Itron'),
  ('Ningbo'),
  ('Sensus'),
  ('Zenner')
on conflict (nombre) do nothing;

alter table public.hid_medidores
  add column if not exists marca_id uuid references public.hid_marcas_medidor (id) on delete restrict;

update public.hid_medidores as medidor
set marca_id = marca.id
from public.hid_marcas_medidor as marca
where medidor.marca_id is null
  and lower(btrim(medidor.marca)) = lower(marca.nombre);

create or replace function public.aplicar_marca_medidor()
returns trigger
language plpgsql
set search_path = public
as $$
declare
  nombre_marca text;
begin
  if new.marca_id is null then
    raise exception 'Seleccioná una marca de medidor.'
      using errcode = 'P0001';
  end if;

  select nombre into nombre_marca
  from public.hid_marcas_medidor
  where id = new.marca_id;

  if nombre_marca is null then
    raise exception 'La marca de medidor no existe.'
      using errcode = 'P0001';
  end if;

  new.marca := nombre_marca;
  return new;
end;
$$;

drop trigger if exists hid_medidores_aplicar_marca on public.hid_medidores;
create trigger hid_medidores_aplicar_marca
before insert or update on public.hid_medidores
for each row execute function public.aplicar_marca_medidor();
