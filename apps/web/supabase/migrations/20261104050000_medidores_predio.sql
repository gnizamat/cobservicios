-- Medidor asignado al predio. Una lectura exige un medidor activo.

create table if not exists public.hid_medidores (
  id uuid primary key default gen_random_uuid(),
  predio_id uuid not null references public.pad_predios (id) on delete restrict,
  codigo text not null,
  marca text not null default '',
  fecha_instalacion date not null default current_date,
  estado public.estado_registro not null default 'activo',
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

create unique index if not exists hid_medidores_un_activo_por_predio
  on public.hid_medidores (predio_id)
  where estado = 'activo';

create unique index if not exists hid_medidores_codigo_activo
  on public.hid_medidores (codigo)
  where estado = 'activo';

drop trigger if exists hid_medidores_set_updated_at on public.hid_medidores;
create trigger hid_medidores_set_updated_at
before update on public.hid_medidores
for each row execute function public.set_updated_at();

alter table public.hid_medidores enable row level security;

create policy "authenticated read hid_medidores"
  on public.hid_medidores for select to authenticated using (true);
create policy "authenticated write hid_medidores"
  on public.hid_medidores for all to authenticated using (true) with check (true);

create or replace function public.exigir_medidor_lectura()
returns trigger
language plpgsql
set search_path = public
as $$
begin
  if not exists (
    select 1
    from public.hid_medidores
    where predio_id = new.predio_id
      and estado = 'activo'
  ) then
    raise exception 'El predio no tiene un medidor activo asignado.'
      using errcode = 'P0001';
  end if;
  return new;
end;
$$;

drop trigger if exists hid_lecturas_exige_medidor on public.hid_lecturas;
create trigger hid_lecturas_exige_medidor
before insert or update on public.hid_lecturas
for each row execute function public.exigir_medidor_lectura();
