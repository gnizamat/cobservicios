-- Punto geográfico del predio urbano para el mapa del padrón.
-- Las coordenadas Este/Norte de catastro siguen en sus columnas de texto.

alter table public.pad_predios
  add column if not exists latitud numeric(9, 6),
  add column if not exists longitud numeric(9, 6);

comment on column public.pad_predios.latitud is
  'Latitud WGS84 del predio en el mapa.';
comment on column public.pad_predios.longitud is
  'Longitud WGS84 del predio en el mapa.';

update public.sys_roles
set permisos = permisos || array['mapa-predios']
where 'predios' = any(permisos)
  and not ('mapa-predios' = any(permisos));

notify pgrst, 'reload schema';
