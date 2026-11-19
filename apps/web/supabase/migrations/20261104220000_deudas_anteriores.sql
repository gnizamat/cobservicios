-- Deudas anteriores de un predio, una por año, mes y tipo de tarifa.

create table if not exists public.fac_deudas_anteriores (
  id uuid primary key default gen_random_uuid(),
  predio_id uuid not null references public.pad_predios (id) on delete restrict,
  tarifa_id uuid not null references public.cat_tarifas (id) on delete restrict,
  tipo_servicio_id uuid not null references public.cat_tipos_servicio (id) on delete restrict,
  anio integer not null,
  mes integer not null check (mes between 1 and 12),
  monto numeric(12, 2) not null check (monto > 0),
  interes numeric(12, 2) not null default 0 check (interes >= 0),
  saldo numeric(12, 2) not null check (saldo >= 0),
  volumen numeric(12, 3) not null default 0 check (volumen >= 0),
  fecha_registro date not null default current_date,
  concepto text not null default '',
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now(),
  unique (predio_id, anio, mes, tipo_servicio_id)
);

create index if not exists fac_deudas_anteriores_predio_idx
  on public.fac_deudas_anteriores (predio_id, anio desc, mes desc);

create or replace function public.fac_deuda_anterior_validar()
returns trigger
language plpgsql
as $$
declare
  anio_tarifa integer;
begin
  select anio into anio_tarifa
  from public.cat_tarifas
  where id = new.tarifa_id;

  if anio_tarifa is null then
    raise exception 'La tarifa seleccionada no existe';
  end if;

  if anio_tarifa <> new.anio then
    raise exception 'El año no corresponde a la tarifa seleccionada';
  end if;

  if not exists (
    select 1
    from public.cat_costos_tarifa
    where tarifa_id = new.tarifa_id
      and tipo_servicio_id = new.tipo_servicio_id
  ) then
    raise exception 'Ese tipo de tarifa no tiene costo en el año seleccionado';
  end if;

  if tg_op = 'INSERT' then
    new.saldo := new.monto;
  end if;

  return new;
end;
$$;

drop trigger if exists fac_deudas_anteriores_validar on public.fac_deudas_anteriores;
create trigger fac_deudas_anteriores_validar
before insert or update on public.fac_deudas_anteriores
for each row execute function public.fac_deuda_anterior_validar();

drop trigger if exists fac_deudas_anteriores_set_updated_at on public.fac_deudas_anteriores;
create trigger fac_deudas_anteriores_set_updated_at
before update on public.fac_deudas_anteriores
for each row execute function public.set_updated_at();

alter table public.fac_deudas_anteriores enable row level security;

create policy "authenticated read fac_deudas_anteriores"
  on public.fac_deudas_anteriores for select to authenticated using (true);
create policy "authenticated write fac_deudas_anteriores"
  on public.fac_deudas_anteriores for all to authenticated using (true) with check (true);
