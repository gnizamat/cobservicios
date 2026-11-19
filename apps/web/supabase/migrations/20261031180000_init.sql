-- Placeholder initial migration for COBSERVICIOS web.
-- Domain tables will be added as modules are implemented.
-- Keep changes additive and enable RLS on business tables.

create extension if not exists "pgcrypto";

-- Example health/ping table for smoke tests (optional; safe to drop later)
create table if not exists public.app_meta (
  key text primary key,
  value text not null,
  updated_at timestamptz not null default now()
);

alter table public.app_meta enable row level security;

create policy "Allow read app_meta for anon"
  on public.app_meta
  for select
  to anon, authenticated
  using (true);

insert into public.app_meta (key, value)
values ('app', 'cobservicios-web')
on conflict (key) do nothing;
