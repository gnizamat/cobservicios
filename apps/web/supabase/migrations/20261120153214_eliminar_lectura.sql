-- Elimina una lectura y la deuda de volumen del mismo periodo
-- cuando esa deuda todavía no está en un recibo.

create or replace function public.eliminar_lectura(p_id uuid)
returns void
language plpgsql
security invoker
set search_path = public
as $$
declare
  v_predio uuid;
  v_anio integer;
  v_mes integer;
  v_fecha date;
  v_servicio uuid;
  v_nombre text;
begin
  select predio_id, anio, mes, fecha_lectura
  into v_predio, v_anio, v_mes, v_fecha
  from public.hid_lecturas
  where id = p_id;

  if not found then
    raise exception 'La lectura que querés eliminar ya no existe.';
  end if;

  select s.id, s.nombre
  into v_servicio, v_nombre
  from public.cat_tipos_servicio s
  where s.categoria = 'volumen'
  order by (s.codigo = 'VOL') desc, s.codigo
  limit 1;

  if v_servicio is not null then
    perform public.sync_deuda_volumen(
      v_predio,
      v_anio,
      v_mes,
      v_servicio,
      null,
      v_nombre,
      0,
      0,
      v_fecha
    );
  end if;

  delete from public.hid_lecturas where id = p_id;
end;
$$;

revoke all on function public.eliminar_lectura(uuid) from public;
grant execute on function public.eliminar_lectura(uuid) to authenticated;

notify pgrst, 'reload schema';
