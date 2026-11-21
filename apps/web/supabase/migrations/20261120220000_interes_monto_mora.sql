-- La mora puede cobrarse por porcentaje y, además, por un monto fijo en soles.

alter table public.cat_intereses
  add column if not exists monto numeric(12, 2) not null default 0;

alter table public.cat_intereses
  drop constraint if exists cat_intereses_monto_check;

alter table public.cat_intereses
  add constraint cat_intereses_monto_check check (monto >= 0);

comment on column public.cat_intereses.monto is
  'Monto fijo de mora en soles. Se suma al cálculo por porcentaje.';

notify pgrst, 'reload schema';
