-- Colaboradores de hidrometría y los centros poblados donde trabajan.
-- Un colaborador puede estar asignado a uno o varios centros.

create table if not exists public.hid_colaboradores (
  id uuid primary key default gen_random_uuid(),
  dni text not null,
  apellido_paterno text not null default '',
  apellido_materno text not null default '',
  nombres text not null,
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now(),
  constraint hid_colaboradores_dni_chk check (dni ~ '^[0-9]{8}$'),
  constraint hid_colaboradores_nombres_chk check (char_length(btrim(nombres)) >= 2),
  constraint hid_colaboradores_apellido_chk check (char_length(btrim(apellido_paterno)) >= 2),
  constraint hid_colaboradores_dni_key unique (dni)
);

comment on table public.hid_colaboradores is
  'Personas que toman lecturas u otras tareas de hidrometría, con su DNI y nombres.';

create table if not exists public.hid_colaborador_sectores (
  colaborador_id uuid not null references public.hid_colaboradores (id) on delete cascade,
  sector_id uuid not null references public.cat_sectores (id) on delete restrict,
  primary key (colaborador_id, sector_id)
);

create index if not exists hid_colaborador_sectores_sector_id_idx
  on public.hid_colaborador_sectores (sector_id);

comment on table public.hid_colaborador_sectores is
  'Centros poblados asignados a cada colaborador de hidrometría.';

drop trigger if exists hid_colaboradores_set_updated_at on public.hid_colaboradores;
create trigger hid_colaboradores_set_updated_at
  before update on public.hid_colaboradores
  for each row execute function public.set_updated_at();

alter table public.hid_colaboradores enable row level security;
alter table public.hid_colaborador_sectores enable row level security;

drop policy if exists "authenticated read hid_colaboradores" on public.hid_colaboradores;
create policy "authenticated read hid_colaboradores"
  on public.hid_colaboradores
  for select
  to authenticated
  using (true);

drop policy if exists "authenticated read hid_colaborador_sectores" on public.hid_colaborador_sectores;
create policy "authenticated read hid_colaborador_sectores"
  on public.hid_colaborador_sectores
  for select
  to authenticated
  using (true);

grant select on public.hid_colaboradores to authenticated;
grant select on public.hid_colaborador_sectores to authenticated;

create or replace function public.guardar_colaborador_hidrometria(
  p_id uuid,
  p_dni text,
  p_apellido_paterno text,
  p_apellido_materno text,
  p_nombres text,
  p_sector_ids uuid[]
)
returns uuid
language plpgsql
security definer
set search_path = public
as $$
declare
  v_id uuid := p_id;
  v_dni text := btrim(coalesce(p_dni, ''));
  v_paterno text := btrim(coalesce(p_apellido_paterno, ''));
  v_materno text := btrim(coalesce(p_apellido_materno, ''));
  v_nombres text := btrim(coalesce(p_nombres, ''));
  v_pedidos integer;
  v_sectores uuid[];
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión';
  end if;

  if v_dni !~ '^[0-9]{8}$' then
    raise exception 'El DNI debe tener 8 dígitos';
  end if;

  if char_length(v_nombres) < 2 then
    raise exception 'Indicá los nombres';
  end if;

  if char_length(v_paterno) < 2 then
    raise exception 'Indicá los apellidos';
  end if;

  select count(distinct pedido.id)
  into v_pedidos
  from unnest(coalesce(p_sector_ids, array[]::uuid[])) as pedido(id)
  where pedido.id is not null;

  select coalesce(array_agg(distinct s.id), array[]::uuid[])
  into v_sectores
  from unnest(coalesce(p_sector_ids, array[]::uuid[])) as pedido(id)
  join public.cat_sectores s on s.id = pedido.id
  where pedido.id is not null;

  if coalesce(v_pedidos, 0) < 1 then
    raise exception 'Asigná al menos un centro poblado';
  end if;

  if coalesce(v_pedidos, 0) <> coalesce(array_length(v_sectores, 1), 0) then
    raise exception 'Hay un centro poblado que no existe';
  end if;

  if exists (
    select 1
    from public.hid_colaboradores
    where dni = v_dni
      and id is distinct from v_id
  ) then
    raise exception 'Ya existe un colaborador con ese DNI';
  end if;

  if v_id is null then
    insert into public.hid_colaboradores (dni, apellido_paterno, apellido_materno, nombres)
    values (v_dni, v_paterno, v_materno, v_nombres)
    returning id into v_id;
  else
    update public.hid_colaboradores
    set dni = v_dni,
        apellido_paterno = v_paterno,
        apellido_materno = v_materno,
        nombres = v_nombres
    where id = v_id;

    if not found then
      raise exception 'No se encontró el colaborador';
    end if;
  end if;

  delete from public.hid_colaborador_sectores
  where colaborador_id = v_id
    and not (sector_id = any (v_sectores));

  insert into public.hid_colaborador_sectores (colaborador_id, sector_id)
  select v_id, sector_id
  from unnest(v_sectores) as sector_id
  on conflict do nothing;

  return v_id;
end;
$$;

revoke all on function public.guardar_colaborador_hidrometria(uuid, text, text, text, text, uuid[]) from public;
grant execute on function public.guardar_colaborador_hidrometria(uuid, text, text, text, text, uuid[]) to authenticated;

-- Quien ya administra Configuración ve la opción nueva sin volver a marcar el rol.
update public.sys_roles
set permisos = permisos || array['config-hidrometria']
where not ('config-hidrometria' = any (permisos))
  and permisos && array[
    'Configuración',
    'configuracion',
    'Administración',
    'organizacion',
    'sistema',
    'config-cobranza',
    'integraciones'
  ];

notify pgrst, 'reload schema';
