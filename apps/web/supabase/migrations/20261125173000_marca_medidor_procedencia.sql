-- La marca de un medidor guarda también su procedencia.

alter table public.hid_marcas_medidor
  add column if not exists procedencia text not null default '';

comment on column public.hid_marcas_medidor.procedencia is
  'País o lugar de origen de la marca del medidor.';

grant select, insert, update on public.hid_marcas_medidor to authenticated;

notify pgrst, 'reload schema';
