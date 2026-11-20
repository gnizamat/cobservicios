-- Permisos de menú por rol. El administrador conserva Configuración del sistema.

create or replace function public.mis_permisos()
returns jsonb
language sql
stable
security definer
set search_path = public
as $$
  select jsonb_build_object(
    'codigo', r.codigo,
    'permisos', r.permisos
  )
  from public.sys_usuario_perfil p
  join public.sys_roles r on r.id = p.rol_id
  where p.user_id = auth.uid()
    and p.activo;
$$;

create or replace function public.guardar_permisos_rol(
  p_rol_id uuid,
  p_permisos text[]
)
returns void
language plpgsql
security definer
set search_path = public
as $$
declare
  v_codigo text;
  v_permisos text[];
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión';
  end if;

  if not public.es_administrador() then
    raise exception 'Solo un administrador puede cambiar los permisos';
  end if;

  select codigo into v_codigo
  from public.sys_roles
  where id = p_rol_id;

  if v_codigo is null then
    raise exception 'Elegí un rol';
  end if;

  select coalesce(array_agg(distinct permiso order by permiso), '{}')
  into v_permisos
  from (
    select btrim(permiso) as permiso
    from unnest(coalesce(p_permisos, '{}'::text[])) as permiso
    where btrim(permiso) <> ''
  ) as limpio;

  if v_codigo = 'administrador' and not ('sistema' = any (v_permisos)) then
    raise exception 'El administrador debe conservar Configuración del sistema';
  end if;

  update public.sys_roles
  set permisos = v_permisos
  where id = p_rol_id;
end;
$$;

update public.sys_roles
set permisos = array[
  'usuarios-servicio',
  'predios',
  'predios-servicios',
  'transferencia-predios',
  'asambleas',
  'sectores',
  'calles',
  'servicios',
  'tarifas',
  'costos-tarifas',
  'lecturas',
  'volumen-sin-lectura',
  'control-hidrometrico',
  'deudas-mensuales',
  'deudas-unicas',
  'deudas-volumen',
  'deudas-alcantarillado',
  'deudas-anteriores',
  'intereses',
  'facturacion',
  'cobranza-deudas',
  'cobranza-facturaciones',
  'cobranza-pagos',
  'otros-ingresos',
  'rpt-deudas',
  'rpt-facturaciones',
  'rpt-cobranzas',
  'rpt-lecturas',
  'organizacion',
  'sistema',
  'config-cobranza',
  'manual',
  'glosario'
]
where codigo = 'administrador';

update public.sys_roles
set permisos = array[
  'usuarios-servicio',
  'predios',
  'predios-servicios',
  'transferencia-predios',
  'asambleas',
  'lecturas',
  'volumen-sin-lectura',
  'control-hidrometrico',
  'deudas-mensuales',
  'deudas-unicas',
  'deudas-volumen',
  'deudas-alcantarillado',
  'deudas-anteriores',
  'intereses',
  'facturacion',
  'cobranza-deudas',
  'cobranza-facturaciones',
  'cobranza-pagos',
  'otros-ingresos'
]
where codigo = 'operador';

revoke all on function public.mis_permisos() from public;
revoke all on function public.guardar_permisos_rol(uuid, text[]) from public;

grant execute on function public.mis_permisos() to authenticated;
grant execute on function public.guardar_permisos_rol(uuid, text[]) to authenticated;

notify pgrst, 'reload schema';
