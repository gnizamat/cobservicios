-- Transferencia de predios: titularidad histórica y trazabilidad de cada operación.

create schema if not exists private;

revoke all on schema private from public;
grant usage on schema private to authenticated, service_role;

create table if not exists public.pad_transferencias (
  id uuid primary key default gen_random_uuid(),
  usuario_origen_id uuid not null,
  usuario_destino_id uuid not null,
  referencia text not null default '',
  created_at timestamptz not null default now(),
  created_by uuid references auth.users (id) on delete set null,
  constraint pad_transferencias_usuario_origen_id_fkey
    foreign key (usuario_origen_id) references public.pad_usuarios (id) on delete restrict,
  constraint pad_transferencias_usuario_destino_id_fkey
    foreign key (usuario_destino_id) references public.pad_usuarios (id) on delete restrict,
  constraint pad_transferencias_usuarios_distintos
    check (usuario_origen_id <> usuario_destino_id)
);

create table if not exists public.pad_predio_historial (
  id uuid primary key default gen_random_uuid(),
  predio_id uuid not null references public.pad_predios (id) on delete restrict,
  usuario_id uuid not null references public.pad_usuarios (id) on delete restrict,
  transferencia_id uuid references public.pad_transferencias (id) on delete restrict,
  referencia text not null default '',
  vigente boolean not null default true,
  desde timestamptz not null default now(),
  hasta timestamptz,
  nombre_predio text not null default '',
  numero text not null default '',
  manzana text not null default '',
  lote text not null default '',
  calle_nombre text not null default '',
  created_at timestamptz not null default now(),
  constraint pad_predio_historial_vigencia_check
    check (
      (vigente and hasta is null)
      or (not vigente and hasta is not null)
    )
);

create unique index if not exists pad_predio_historial_vigente_uidx
  on public.pad_predio_historial (predio_id)
  where vigente;

create index if not exists pad_predio_historial_predio_idx
  on public.pad_predio_historial (predio_id, desde desc);

create index if not exists pad_predio_historial_transferencia_idx
  on public.pad_predio_historial (transferencia_id);

create index if not exists pad_transferencias_created_idx
  on public.pad_transferencias (created_at desc);

create or replace function private.registrar_titularidad_inicial()
returns trigger
language plpgsql
security definer
set search_path = public
as $$
declare
  v_calle text;
begin
  select c.nombre into v_calle
  from public.cat_calles c
  where c.id = new.calle_id;

  insert into public.pad_predio_historial (
    predio_id,
    usuario_id,
    referencia,
    vigente,
    desde,
    nombre_predio,
    numero,
    manzana,
    lote,
    calle_nombre
  ) values (
    new.id,
    new.usuario_id,
    'Alta de predio',
    true,
    coalesce(new.created_at, now()),
    new.nombre,
    new.numero,
    new.manzana,
    new.lote,
    coalesce(v_calle, '')
  );

  return new;
end;
$$;

create or replace function private.registrar_cambio_titular()
returns trigger
language plpgsql
security definer
set search_path = public
as $$
declare
  v_abierto uuid;
  v_calle text;
begin
  if old.usuario_id is not distinct from new.usuario_id then
    return new;
  end if;

  select h.id into v_abierto
  from public.pad_predio_historial h
  where h.predio_id = new.id
    and h.vigente
    and h.usuario_id = new.usuario_id
  limit 1;

  if v_abierto is not null then
    return new;
  end if;

  update public.pad_predio_historial
    set vigente = false,
        hasta = now()
    where predio_id = new.id
      and vigente;

  select c.nombre into v_calle
  from public.cat_calles c
  where c.id = new.calle_id;

  insert into public.pad_predio_historial (
    predio_id,
    usuario_id,
    referencia,
    vigente,
    desde,
    nombre_predio,
    numero,
    manzana,
    lote,
    calle_nombre
  ) values (
    new.id,
    new.usuario_id,
    'Cambio de titular en el padrón',
    true,
    now(),
    new.nombre,
    new.numero,
    new.manzana,
    new.lote,
    coalesce(v_calle, '')
  );

  return new;
end;
$$;

drop trigger if exists pad_predios_titularidad_inicial on public.pad_predios;
create trigger pad_predios_titularidad_inicial
after insert on public.pad_predios
for each row execute function private.registrar_titularidad_inicial();

drop trigger if exists pad_predios_cambio_titular on public.pad_predios;
create trigger pad_predios_cambio_titular
after update of usuario_id on public.pad_predios
for each row execute function private.registrar_cambio_titular();

revoke all on function private.registrar_titularidad_inicial() from public, anon;
revoke all on function private.registrar_cambio_titular() from public, anon;
grant execute on function private.registrar_titularidad_inicial() to authenticated, service_role;
grant execute on function private.registrar_cambio_titular() to authenticated, service_role;

insert into public.pad_predio_historial (
  predio_id,
  usuario_id,
  referencia,
  vigente,
  desde,
  nombre_predio,
  numero,
  manzana,
  lote,
  calle_nombre
)
select
  p.id,
  p.usuario_id,
  'Titularidad inicial',
  true,
  p.created_at,
  p.nombre,
  p.numero,
  p.manzana,
  p.lote,
  coalesce(c.nombre, '')
from public.pad_predios p
left join public.cat_calles c on c.id = p.calle_id
where not exists (
  select 1
  from public.pad_predio_historial h
  where h.predio_id = p.id
    and h.vigente
);

create or replace function public.registrar_transferencia_predios(
  p_usuario_origen_id uuid,
  p_usuario_destino_id uuid,
  p_referencia text,
  p_predio_ids uuid[]
)
returns uuid
language plpgsql
security definer
set search_path = public
as $$
declare
  v_id uuid;
  v_referencia text;
  v_predio public.pad_predios%rowtype;
  v_calle text;
  v_count integer;
begin
  if auth.uid() is null then
    raise exception 'Se requiere sesión';
  end if;

  if p_usuario_origen_id is null or p_usuario_destino_id is null then
    raise exception 'Seleccioná el usuario de origen y el de destino';
  end if;

  if p_usuario_origen_id = p_usuario_destino_id then
    raise exception 'El usuario de origen y el de destino deben ser distintos';
  end if;

  if p_predio_ids is null or cardinality(p_predio_ids) = 0 then
    raise exception 'Pasá al menos un predio al usuario destino';
  end if;

  if cardinality(p_predio_ids) > 200 then
    raise exception 'No se pueden transferir más de 200 predios a la vez';
  end if;

  if exists (
    select 1
    from unnest(p_predio_ids) as pid
    group by pid
    having count(*) > 1
  ) then
    raise exception 'Hay predios repetidos en la transferencia';
  end if;

  if not exists (
    select 1
    from public.pad_usuarios
    where id = p_usuario_destino_id
      and estado = 'activo'
  ) then
    raise exception 'El usuario destino no está activo';
  end if;

  perform 1
  from public.pad_predios
  where id = any (p_predio_ids)
  for update;

  select count(*) into v_count
  from public.pad_predios
  where id = any (p_predio_ids)
    and usuario_id = p_usuario_origen_id
    and estado = 'activo';

  if v_count <> cardinality(p_predio_ids) then
    raise exception 'Uno o más predios no pertenecen al usuario de origen o no están activos';
  end if;

  v_referencia := coalesce(nullif(btrim(p_referencia), ''), '');

  insert into public.pad_transferencias (
    usuario_origen_id,
    usuario_destino_id,
    referencia,
    created_by
  ) values (
    p_usuario_origen_id,
    p_usuario_destino_id,
    v_referencia,
    auth.uid()
  )
  returning id into v_id;

  for v_predio in
    select *
    from public.pad_predios
    where id = any (p_predio_ids)
  loop
    select c.nombre into v_calle
    from public.cat_calles c
    where c.id = v_predio.calle_id;

    update public.pad_predio_historial
      set vigente = false,
          hasta = now()
      where predio_id = v_predio.id
        and vigente;

    insert into public.pad_predio_historial (
      predio_id,
      usuario_id,
      transferencia_id,
      referencia,
      vigente,
      desde,
      nombre_predio,
      numero,
      manzana,
      lote,
      calle_nombre
    ) values (
      v_predio.id,
      p_usuario_destino_id,
      v_id,
      v_referencia,
      true,
      now(),
      v_predio.nombre,
      v_predio.numero,
      v_predio.manzana,
      v_predio.lote,
      coalesce(v_calle, '')
    );

    update public.pad_predios
      set usuario_id = p_usuario_destino_id
      where id = v_predio.id;
  end loop;

  return v_id;
end;
$$;

revoke all on function public.registrar_transferencia_predios(uuid, uuid, text, uuid[]) from public, anon;
grant execute on function public.registrar_transferencia_predios(uuid, uuid, text, uuid[]) to authenticated;

alter table public.pad_transferencias enable row level security;
alter table public.pad_predio_historial enable row level security;

create policy "authenticated read pad_transferencias"
  on public.pad_transferencias for select to authenticated using (true);

create policy "authenticated read pad_predio_historial"
  on public.pad_predio_historial for select to authenticated using (true);
