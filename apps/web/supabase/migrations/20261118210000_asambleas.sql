-- Registro de asambleas y padrón de usuarios hábiles para la asistencia.

create table if not exists public.asm_asambleas (
  id uuid primary key default gen_random_uuid(),
  sector_id uuid not null references public.cat_sectores (id) on delete restrict,
  descripcion text not null,
  anio integer not null check (anio between 2000 and 2100),
  tipo text not null check (tipo in ('ordinaria', 'extraordinaria')),
  ambito text not null check (ambito in ('principal', 'anexo')),
  fecha date not null,
  estado public.estado_registro not null default 'inactivo',
  padron_generado_en timestamptz,
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now()
);

create table if not exists public.asm_padron (
  id uuid primary key default gen_random_uuid(),
  asamblea_id uuid not null references public.asm_asambleas (id) on delete cascade,
  usuario_id uuid not null references public.pad_usuarios (id) on delete restrict,
  predio_id uuid references public.pad_predios (id) on delete set null,
  correlativo integer not null,
  nombre text not null,
  documento text not null default '',
  deuda numeric(12, 2) not null default 0 check (deuda >= 0),
  habil boolean not null default false,
  asistencia boolean not null default false,
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now(),
  unique (asamblea_id, usuario_id)
);

create index if not exists asm_asambleas_sector_anio_idx
  on public.asm_asambleas (sector_id, anio desc, fecha desc);

create index if not exists asm_padron_asamblea_idx
  on public.asm_padron (asamblea_id, correlativo);

drop trigger if exists asm_asambleas_set_updated_at on public.asm_asambleas;
create trigger asm_asambleas_set_updated_at
before update on public.asm_asambleas
for each row execute function public.set_updated_at();

drop trigger if exists asm_padron_set_updated_at on public.asm_padron;
create trigger asm_padron_set_updated_at
before update on public.asm_padron
for each row execute function public.set_updated_at();

alter table public.asm_asambleas enable row level security;
alter table public.asm_padron enable row level security;

drop policy if exists "authenticated read asm_asambleas" on public.asm_asambleas;
create policy "authenticated read asm_asambleas"
  on public.asm_asambleas for select to authenticated using (true);

drop policy if exists "authenticated write asm_asambleas" on public.asm_asambleas;
create policy "authenticated write asm_asambleas"
  on public.asm_asambleas for all to authenticated using (true) with check (true);

drop policy if exists "authenticated read asm_padron" on public.asm_padron;
create policy "authenticated read asm_padron"
  on public.asm_padron for select to authenticated using (true);

drop policy if exists "authenticated write asm_padron" on public.asm_padron;
create policy "authenticated write asm_padron"
  on public.asm_padron for all to authenticated using (true) with check (true);

grant select, insert, update, delete on public.asm_asambleas to authenticated;
grant select, insert, update, delete on public.asm_padron to authenticated;

-- Un usuario es hábil cuando tiene predio activo en el centro poblado
-- y no arrastra saldo ni interés en esos predios.
create or replace function public.generar_padron_asamblea(p_asamblea_id uuid)
returns integer
language plpgsql
as $$
declare
  v_sector uuid;
  v_total integer;
begin
  select sector_id into v_sector
  from public.asm_asambleas
  where id = p_asamblea_id;

  if v_sector is null then
    raise exception 'La asamblea no existe';
  end if;

  with candidatos as (
    select
      u.id as usuario_id,
      (
        select p.id
        from public.pad_predios p
        where p.usuario_id = u.id
          and p.sector_id = v_sector
          and p.estado = 'activo'
        order by p.nombre, p.numero
        limit 1
      ) as predio_id,
      trim(both ' ' from concat_ws(' ', u.apellido_paterno, u.apellido_materno, u.nombres)) as nombre,
      coalesce(nullif(u.dni, ''), nullif(u.ruc, ''), '') as documento,
      coalesce((
        select sum(d.saldo + d.interes)
        from public.fac_deudas_anteriores d
        join public.pad_predios p on p.id = d.predio_id
        where p.usuario_id = u.id
          and p.sector_id = v_sector
          and p.estado = 'activo'
      ), 0)::numeric(12, 2) as deuda
    from public.pad_usuarios u
    where u.estado = 'activo'
      and exists (
        select 1
        from public.pad_predios p
        where p.usuario_id = u.id
          and p.sector_id = v_sector
          and p.estado = 'activo'
      )
  ),
  numerados as (
    select
      candidatos.*,
      row_number() over (order by nombre, documento)::integer as correlativo,
      (deuda = 0) as habil
    from candidatos
  )
  insert into public.asm_padron (
    asamblea_id,
    usuario_id,
    predio_id,
    correlativo,
    nombre,
    documento,
    deuda,
    habil
  )
  select
    p_asamblea_id,
    usuario_id,
    predio_id,
    correlativo,
    nombre,
    documento,
    deuda,
    habil
  from numerados
  on conflict (asamblea_id, usuario_id) do update
  set predio_id = excluded.predio_id,
      correlativo = excluded.correlativo,
      nombre = excluded.nombre,
      documento = excluded.documento,
      deuda = excluded.deuda,
      habil = excluded.habil;

  delete from public.asm_padron p
  where p.asamblea_id = p_asamblea_id
    and not exists (
      select 1
      from public.pad_usuarios u
      join public.pad_predios pr on pr.usuario_id = u.id
      where u.id = p.usuario_id
        and u.estado = 'activo'
        and pr.estado = 'activo'
        and pr.sector_id = v_sector
    );

  update public.asm_asambleas
  set padron_generado_en = now()
  where id = p_asamblea_id;

  select count(*)::integer into v_total
  from public.asm_padron
  where asamblea_id = p_asamblea_id;

  return v_total;
end;
$$;

grant execute on function public.generar_padron_asamblea(uuid) to authenticated;

notify pgrst, 'reload schema';
