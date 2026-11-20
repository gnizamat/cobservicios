-- Cada caja pertenece a un centro poblado. Nulo = sede central de la JASS.

alter table public.cob_cajas
  add column if not exists sector_id uuid references public.cat_sectores (id) on delete restrict;

comment on column public.cob_cajas.sector_id is
  'Centro poblado de la caja. Nulo significa sede central de la JASS.';

alter table public.cob_cajas drop constraint if exists cob_cajas_nombre_key;

create unique index if not exists cob_cajas_nombre_sector_key
  on public.cob_cajas (nombre, sector_id) nulls not distinct;

notify pgrst, 'reload schema';
