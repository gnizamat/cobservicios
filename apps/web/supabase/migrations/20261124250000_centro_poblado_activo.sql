-- Un centro poblado inactivo deja de verse en las ventanas
-- que listan sus usuarios, predios, calles, cajas y usuarios del sistema.

alter table public.cat_sectores
  add column if not exists activo boolean not null default true;

comment on column public.cat_sectores.activo is
  'Si está inactivo, sus predios, calles, cajas y usuarios asignados no aparecen en las ventanas de trabajo.';

create or replace function public.centro_poblado_activo(p_sector_id uuid)
returns boolean
language sql
stable
security definer
set search_path = public
as $$
  select p_sector_id is null
    or exists (
      select 1
      from public.cat_sectores s
      where s.id = p_sector_id
        and s.activo
    );
$$;

revoke all on function public.centro_poblado_activo(uuid) from public;
grant execute on function public.centro_poblado_activo(uuid) to authenticated;

drop policy if exists "authenticated read pad_predios" on public.pad_predios;
drop policy if exists "authenticated write pad_predios" on public.pad_predios;
create policy "authenticated read pad_predios"
  on public.pad_predios for select to authenticated
  using (public.centro_poblado_activo(sector_id));
create policy "authenticated insert pad_predios"
  on public.pad_predios for insert to authenticated
  with check (public.centro_poblado_activo(sector_id));
create policy "authenticated update pad_predios"
  on public.pad_predios for update to authenticated
  using (public.centro_poblado_activo(sector_id))
  with check (public.centro_poblado_activo(sector_id));
create policy "authenticated delete pad_predios"
  on public.pad_predios for delete to authenticated
  using (public.centro_poblado_activo(sector_id));

drop policy if exists "authenticated read cat_calles" on public.cat_calles;
drop policy if exists "authenticated write cat_calles" on public.cat_calles;
create policy "authenticated read cat_calles"
  on public.cat_calles for select to authenticated
  using (public.centro_poblado_activo(sector_id));
create policy "authenticated insert cat_calles"
  on public.cat_calles for insert to authenticated
  with check (public.centro_poblado_activo(sector_id));
create policy "authenticated update cat_calles"
  on public.cat_calles for update to authenticated
  using (public.centro_poblado_activo(sector_id))
  with check (public.centro_poblado_activo(sector_id));
create policy "authenticated delete cat_calles"
  on public.cat_calles for delete to authenticated
  using (public.centro_poblado_activo(sector_id));

drop policy if exists "authenticated read cob_cajas" on public.cob_cajas;
create policy "authenticated read cob_cajas"
  on public.cob_cajas for select to authenticated
  using (public.centro_poblado_activo(sector_id));

drop policy if exists "authenticated insert cob_cajas" on public.cob_cajas;
create policy "authenticated insert cob_cajas"
  on public.cob_cajas for insert to authenticated
  with check (public.centro_poblado_activo(sector_id));

drop policy if exists "authenticated update cob_cajas" on public.cob_cajas;
create policy "authenticated update cob_cajas"
  on public.cob_cajas for update to authenticated
  using (public.centro_poblado_activo(sector_id))
  with check (public.centro_poblado_activo(sector_id));

create or replace view public.pad_usuarios_centro_activo
with (security_invoker = false) as
select u.*
from public.pad_usuarios u
where not exists (
  select 1
  from public.pad_predios p
  where p.usuario_id = u.id
)
or exists (
  select 1
  from public.pad_predios p
  left join public.cat_sectores s on s.id = p.sector_id
  where p.usuario_id = u.id
    and (p.sector_id is null or s.activo)
);

grant select on public.pad_usuarios_centro_activo to authenticated;

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
          and (p.sector_id is null or s.activo)
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
    select 1 from public.cat_sectores where id = p_sector_id and activo
  ) then
    raise exception 'Elegí un centro poblado activo';
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

notify pgrst, 'reload schema';
