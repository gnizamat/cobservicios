-- Alcance de un usuario del sistema: un centro poblado, o la sede central (todos).

alter table public.sys_usuario_perfil
  add column if not exists sector_id uuid references public.cat_sectores (id) on delete restrict;

comment on column public.sys_usuario_perfil.sector_id is
  'Centro poblado asignado. Nulo: sede central, administra todos los centros poblados.';

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
          coalesce(r.codigo, '') as rol_codigo,
          p.sector_id,
          coalesce(s.nombre, '') as sector
        from auth.users u
        left join public.sys_usuario_perfil p on p.user_id = u.id
        left join public.sys_roles r on r.id = p.rol_id
        left join public.cat_sectores s on s.id = p.sector_id
        where u.deleted_at is null
          and coalesce(u.is_anonymous, false) = false
      ) as t
    ),
    '[]'::jsonb
  );
end;
$$;

drop function if exists public.actualizar_usuario_sistema(uuid, text, uuid, boolean);

create function public.actualizar_usuario_sistema(
  p_user_id uuid,
  p_nombre text,
  p_rol_id uuid,
  p_activo boolean,
  p_sector_id uuid
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

  if p_sector_id is not null and not exists (
    select 1 from public.cat_sectores where id = p_sector_id
  ) then
    raise exception 'Elegí un centro poblado';
  end if;

  if p_user_id = auth.uid() and p_activo = false then
    raise exception 'No podés desactivar tu propia cuenta';
  end if;

  update public.sys_usuario_perfil
  set nombre = v_nombre,
      rol_id = p_rol_id,
      activo = p_activo,
      sector_id = p_sector_id
  where user_id = p_user_id;

  if not found then
    raise exception 'No se encontró el usuario';
  end if;

  update auth.users
  set banned_until = case when p_activo then null else 'infinity'::timestamptz end
  where id = p_user_id;

  return jsonb_build_object(
    'id', p_user_id,
    'activo', p_activo,
    'sector_id', p_sector_id
  );
end;
$$;

revoke all on function public.actualizar_usuario_sistema(uuid, text, uuid, boolean, uuid) from public;
grant execute on function public.actualizar_usuario_sistema(uuid, text, uuid, boolean, uuid) to authenticated;

notify pgrst, 'reload schema';
