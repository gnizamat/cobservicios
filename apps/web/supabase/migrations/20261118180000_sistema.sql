-- Configuración del sistema: roles, perfiles de usuarios de acceso y marca.

create table if not exists public.sys_roles (
  id uuid primary key default gen_random_uuid(),
  codigo text not null,
  nombre text not null,
  descripcion text not null default '',
  permisos text[] not null default '{}',
  tablero text[] not null default '{}',
  created_at timestamptz not null default now(),
  unique (codigo)
);

insert into public.sys_roles (codigo, nombre, descripcion, permisos, tablero)
values
  (
    'administrador',
    'Administrador de JASS',
    'Configura la plataforma y opera todos los módulos.',
    array[
      'Padrón',
      'Territorio y catálogo',
      'Hidrometría',
      'Facturación y deudas',
      'Cobranza',
      'Reportes',
      'Configuración',
      'Administración'
    ],
    array['Usuarios', 'Predios', 'Facturación', 'Cobranza', 'Organización']
  ),
  (
    'operador',
    'Operador',
    'Registra lecturas, facturación y cobranza del día.',
    array['Padrón', 'Hidrometría', 'Facturación y deudas', 'Cobranza'],
    array['Lecturas', 'Facturación', 'Cobranza']
  )
on conflict (codigo) do nothing;

create table if not exists public.sys_usuario_perfil (
  user_id uuid primary key references auth.users (id) on delete cascade,
  nombre text not null default '',
  rol_id uuid not null references public.sys_roles (id) on delete restrict,
  activo boolean not null default true,
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

drop trigger if exists sys_usuario_perfil_set_updated_at on public.sys_usuario_perfil;
create trigger sys_usuario_perfil_set_updated_at
before update on public.sys_usuario_perfil
for each row execute function public.set_updated_at();

insert into public.sys_usuario_perfil (user_id, nombre, rol_id)
select
  u.id,
  coalesce(
    nullif(btrim(u.raw_user_meta_data ->> 'nombre'), ''),
    split_part(u.email, '@', 1)
  ),
  (select id from public.sys_roles where codigo = 'administrador')
from auth.users u
where u.deleted_at is null
on conflict (user_id) do nothing;

insert into public.app_meta (key, value)
values ('marca_nombre', 'COBSERVICIOS')
on conflict (key) do nothing;

create or replace function public.sys_crear_perfil_usuario()
returns trigger
language plpgsql
security definer
set search_path = public
as $$
declare
  v_rol uuid;
  v_codigo text := coalesce(nullif(btrim(new.raw_user_meta_data ->> 'rol'), ''), 'operador');
  v_nombre text := btrim(coalesce(new.raw_user_meta_data ->> 'nombre', ''));
begin
  if v_nombre = '' then
    v_nombre := split_part(coalesce(new.email, ''), '@', 1);
  end if;

  select id into v_rol from public.sys_roles where codigo = v_codigo;
  if v_rol is null then
    select id into v_rol from public.sys_roles where codigo = 'operador';
  end if;

  insert into public.sys_usuario_perfil (user_id, nombre, rol_id)
  values (new.id, v_nombre, v_rol)
  on conflict (user_id) do nothing;

  return new;
end;
$$;

drop trigger if exists sys_crear_perfil_usuario on auth.users;
create trigger sys_crear_perfil_usuario
after insert on auth.users
for each row execute function public.sys_crear_perfil_usuario();

create or replace function public.es_administrador()
returns boolean
language sql
stable
security definer
set search_path = public
as $$
  select exists (
    select 1
    from public.sys_usuario_perfil p
    join public.sys_roles r on r.id = p.rol_id
    where p.user_id = auth.uid()
      and p.activo
      and r.codigo = 'administrador'
  );
$$;

create or replace function public.listar_usuarios_sistema()
returns jsonb
language plpgsql
stable
security definer
set search_path = public
as $$
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión';
  end if;

  if not public.es_administrador() then
    raise exception 'Solo un administrador puede ver los usuarios del sistema';
  end if;

  return coalesce(
    (
      select jsonb_agg(to_jsonb(t) order by t.email)
      from (
        select
          u.id,
          u.email,
          coalesce(p.nombre, '') as nombre,
          coalesce(p.activo, true) as activo,
          coalesce(r.nombre, '') as rol,
          r.id as rol_id,
          coalesce(r.codigo, '') as rol_codigo
        from auth.users u
        left join public.sys_usuario_perfil p on p.user_id = u.id
        left join public.sys_roles r on r.id = p.rol_id
        where u.deleted_at is null
          and coalesce(u.is_anonymous, false) = false
      ) as t
    ),
    '[]'::jsonb
  );
end;
$$;

create or replace function public.actualizar_usuario_sistema(
  p_user_id uuid,
  p_nombre text,
  p_rol_id uuid,
  p_activo boolean
)
returns jsonb
language plpgsql
security definer
set search_path = public
as $$
declare
  v_nombre text := btrim(coalesce(p_nombre, ''));
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión';
  end if;

  if not public.es_administrador() then
    raise exception 'Solo un administrador puede cambiar usuarios del sistema';
  end if;

  if p_user_id is null then
    raise exception 'Seleccioná un usuario';
  end if;

  if length(v_nombre) < 2 then
    raise exception 'Indicá el nombre del usuario';
  end if;

  if not exists (select 1 from public.sys_roles where id = p_rol_id) then
    raise exception 'Elegí un rol';
  end if;

  if p_user_id = auth.uid() and p_activo = false then
    raise exception 'No podés desactivar tu propia cuenta';
  end if;

  update public.sys_usuario_perfil
  set nombre = v_nombre,
      rol_id = p_rol_id,
      activo = p_activo
  where user_id = p_user_id;

  if not found then
    raise exception 'No se encontró el usuario';
  end if;

  update auth.users
  set banned_until = case when p_activo then null else 'infinity'::timestamptz end
  where id = p_user_id;

  return jsonb_build_object('id', p_user_id, 'activo', p_activo);
end;
$$;

create or replace function public.guardar_marca_plataforma(p_nombre text)
returns text
language plpgsql
security definer
set search_path = public
as $$
declare
  v_nombre text := btrim(coalesce(p_nombre, ''));
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión';
  end if;

  if not public.es_administrador() then
    raise exception 'Solo un administrador puede cambiar la marca';
  end if;

  if length(v_nombre) < 2 then
    raise exception 'Indicá el nombre de la plataforma';
  end if;

  insert into public.app_meta (key, value)
  values ('marca_nombre', v_nombre)
  on conflict (key) do update
  set value = excluded.value,
      updated_at = now();

  return v_nombre;
end;
$$;

alter table public.sys_roles enable row level security;
alter table public.sys_usuario_perfil enable row level security;

drop policy if exists "authenticated read sys_roles" on public.sys_roles;
create policy "authenticated read sys_roles"
  on public.sys_roles for select to authenticated using (true);

drop policy if exists "authenticated read sys_usuario_perfil" on public.sys_usuario_perfil;
create policy "authenticated read sys_usuario_perfil"
  on public.sys_usuario_perfil for select to authenticated using (true);

grant select on public.sys_roles to authenticated;
grant select on public.sys_usuario_perfil to authenticated;

revoke all on function public.es_administrador() from public;
revoke all on function public.listar_usuarios_sistema() from public;
revoke all on function public.actualizar_usuario_sistema(uuid, text, uuid, boolean) from public;
revoke all on function public.guardar_marca_plataforma(text) from public;

grant execute on function public.listar_usuarios_sistema() to authenticated;
grant execute on function public.actualizar_usuario_sistema(uuid, text, uuid, boolean) to authenticated;
grant execute on function public.guardar_marca_plataforma(text) to authenticated;

notify pgrst, 'reload schema';
