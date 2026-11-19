-- Catálogos de la configuración de cobranza: multas, intereses, bancos y documentos.
-- Las cajas ya existen; se habilita su alta y edición.

create table if not exists public.cat_conceptos_multa (
  id uuid primary key default gen_random_uuid(),
  nombre text not null,
  monto numeric(12, 2) not null default 0 check (monto >= 0),
  estado public.estado_registro not null default 'activo',
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now(),
  unique (nombre)
);

create table if not exists public.cat_intereses (
  id uuid primary key default gen_random_uuid(),
  nombre text not null,
  porcentaje numeric(8, 4) not null default 0 check (porcentaje >= 0),
  estado public.estado_registro not null default 'activo',
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now(),
  unique (nombre)
);

create table if not exists public.cat_bancos (
  id uuid primary key default gen_random_uuid(),
  nombre text not null,
  cuenta text not null default '',
  estado public.estado_registro not null default 'activo',
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now(),
  unique (nombre)
);

create table if not exists public.cat_documentos (
  id uuid primary key default gen_random_uuid(),
  codigo text not null,
  nombre text not null,
  estado public.estado_registro not null default 'activo',
  created_at timestamptz not null default now(),
  updated_at timestamptz not null default now(),
  unique (codigo)
);

insert into public.cat_documentos (codigo, nombre)
values
  ('REC', 'Recibo'),
  ('FAC', 'Factura')
on conflict (codigo) do nothing;

do $$
declare
  tabla text;
begin
  foreach tabla in array array[
    'cat_conceptos_multa',
    'cat_intereses',
    'cat_bancos',
    'cat_documentos'
  ]
  loop
    execute format('drop trigger if exists %I on public.%I', tabla || '_set_updated_at', tabla);
    execute format(
      'create trigger %I before update on public.%I for each row execute function public.set_updated_at()',
      tabla || '_set_updated_at',
      tabla
    );
    execute format('alter table public.%I enable row level security', tabla);
    execute format('drop policy if exists "authenticated read %1$s" on public.%1$I', tabla);
    execute format(
      'create policy "authenticated read %1$s" on public.%1$I for select to authenticated using (true)',
      tabla
    );
    execute format('drop policy if exists "authenticated write %1$s" on public.%1$I', tabla);
    execute format(
      'create policy "authenticated write %1$s" on public.%1$I for all to authenticated using (true) with check (true)',
      tabla
    );
    execute format('grant select, insert, update on public.%I to authenticated', tabla);
  end loop;
end $$;

drop policy if exists "authenticated insert cob_cajas" on public.cob_cajas;
create policy "authenticated insert cob_cajas"
  on public.cob_cajas for insert to authenticated with check (true);

drop policy if exists "authenticated update cob_cajas" on public.cob_cajas;
create policy "authenticated update cob_cajas"
  on public.cob_cajas for update to authenticated using (true) with check (true);

grant insert, update on public.cob_cajas to authenticated;

notify pgrst, 'reload schema';
