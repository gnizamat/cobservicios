-- Historial de montos al editar un costo de tarifa.

create table if not exists public.cat_costos_tarifa_historial (
  id uuid primary key default gen_random_uuid(),
  costo_id uuid not null references public.cat_costos_tarifa (id) on delete cascade,
  tarifa_id uuid not null,
  tipo_servicio_id uuid not null,
  monto_anterior numeric(12, 2) not null,
  monto_nuevo numeric(12, 2) not null,
  valor_anterior numeric(12, 4) not null,
  valor_nuevo numeric(12, 4) not null,
  created_at timestamptz not null default now(),
  created_by uuid references auth.users (id) on delete set null
);

create index if not exists cat_costos_tarifa_historial_costo_idx
  on public.cat_costos_tarifa_historial (costo_id, created_at desc);

create or replace function public.registrar_historial_costo_tarifa()
returns trigger
language plpgsql
security definer
set search_path = public
as $$
begin
  if new.monto is distinct from old.monto then
    insert into public.cat_costos_tarifa_historial (
      costo_id,
      tarifa_id,
      tipo_servicio_id,
      monto_anterior,
      monto_nuevo,
      valor_anterior,
      valor_nuevo,
      created_by
    ) values (
      new.id,
      new.tarifa_id,
      new.tipo_servicio_id,
      old.monto,
      new.monto,
      old.valor,
      new.valor,
      auth.uid()
    );
  end if;
  return new;
end;
$$;

drop trigger if exists cat_costos_tarifa_historial on public.cat_costos_tarifa;
create trigger cat_costos_tarifa_historial
before update on public.cat_costos_tarifa
for each row execute function public.registrar_historial_costo_tarifa();

alter table public.cat_costos_tarifa_historial enable row level security;

create policy "authenticated read cat_costos_tarifa_historial"
  on public.cat_costos_tarifa_historial
  for select to authenticated
  using (true);
