-- Permite reemplazar el padrón: el historial y las transferencias
-- referencian predios y usuarios con ON DELETE RESTRICT.

create policy "authenticated write pad_transferencias"
  on public.pad_transferencias for all to authenticated using (true) with check (true);

create policy "authenticated write pad_predio_historial"
  on public.pad_predio_historial for all to authenticated using (true) with check (true);
