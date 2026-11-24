-- Credencial de la consulta de DNI. El token no se lee desde el cliente.

create table public.cfg_integracion_dni (
  id boolean primary key default true check (id),
  proveedor text not null default 'decolecta' check (proveedor in ('decolecta')),
  token text not null default '',
  activa boolean not null default false,
  updated_at timestamptz not null default now()
);

insert into public.cfg_integracion_dni (id)
values (true)
on conflict (id) do nothing;

comment on table public.cfg_integracion_dni is
  'Integración para autocompletar nombres a partir del DNI. No verifica identidad.';

alter table public.cfg_integracion_dni enable row level security;
revoke all on table public.cfg_integracion_dni from public, anon, authenticated;

create or replace function public.leer_integracion_dni()
returns jsonb
language plpgsql
stable
security definer
set search_path = public
as $$
declare
  v_row public.cfg_integracion_dni%rowtype;
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión';
  end if;
  if not public.es_administrador() then
    raise exception 'Solo un administrador puede ver las integraciones';
  end if;

  select * into v_row from public.cfg_integracion_dni where id;

  return jsonb_build_object(
    'proveedor', coalesce(v_row.proveedor, 'decolecta'),
    'activa', coalesce(v_row.activa, false),
    'tiene_token', coalesce(v_row.token, '') <> '',
    'updated_at', v_row.updated_at
  );
end;
$$;

create or replace function public.guardar_integracion_dni(
  p_proveedor text,
  p_token text,
  p_activa boolean
)
returns jsonb
language plpgsql
security definer
set search_path = public
as $$
declare
  v_token text;
  v_activa boolean;
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión';
  end if;
  if not public.es_administrador() then
    raise exception 'Solo un administrador puede guardar las integraciones';
  end if;
  if coalesce(btrim(p_proveedor), 'decolecta') <> 'decolecta' then
    raise exception 'Elegí un servicio disponible';
  end if;

  select token into v_token from public.cfg_integracion_dni where id;
  if btrim(coalesce(p_token, '')) <> '' then
    v_token := btrim(p_token);
  end if;
  v_token := coalesce(v_token, '');
  v_activa := coalesce(p_activa, false);

  if v_activa and v_token = '' then
    raise exception 'Pegá el token del proveedor antes de activar la integración';
  end if;

  insert into public.cfg_integracion_dni (id, proveedor, token, activa, updated_at)
  values (true, 'decolecta', v_token, v_activa, now())
  on conflict (id) do update
  set proveedor = excluded.proveedor,
      token = excluded.token,
      activa = excluded.activa,
      updated_at = excluded.updated_at;

  return public.leer_integracion_dni();
end;
$$;

create or replace function public.eliminar_credencial_dni()
returns jsonb
language plpgsql
security definer
set search_path = public
as $$
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión';
  end if;
  if not public.es_administrador() then
    raise exception 'Solo un administrador puede eliminar la credencial';
  end if;

  update public.cfg_integracion_dni
  set token = '',
      activa = false,
      updated_at = now()
  where id;

  return public.leer_integracion_dni();
end;
$$;

revoke all on function public.leer_integracion_dni() from public;
revoke all on function public.guardar_integracion_dni(text, text, boolean) from public;
revoke all on function public.eliminar_credencial_dni() from public;
grant execute on function public.leer_integracion_dni() to authenticated;
grant execute on function public.guardar_integracion_dni(text, text, boolean) to authenticated;
grant execute on function public.eliminar_credencial_dni() to authenticated;

update public.sys_roles
set permisos = permisos || array['integraciones']
where 'sistema' = any(permisos)
  and not ('integraciones' = any(permisos));

notify pgrst, 'reload schema';
