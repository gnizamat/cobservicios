-- Credencial del modelo de lenguaje. La clave no sale de la base.

create table public.cfg_integracion_ia (
  id boolean primary key default true check (id),
  proveedor text not null default 'openai' check (proveedor in ('openai')),
  token text not null default '',
  modelo text not null default 'gpt-4.1-mini',
  updated_at timestamptz not null default now()
);

insert into public.cfg_integracion_ia (id)
values (true)
on conflict (id) do nothing;

comment on table public.cfg_integracion_ia is
  'Proveedor y modelo de lenguaje. La clave de API no se devuelve al navegador.';

alter table public.cfg_integracion_ia enable row level security;
revoke all on table public.cfg_integracion_ia from public, anon, authenticated;

create or replace function public.leer_integracion_ia()
returns jsonb
language plpgsql
stable
security definer
set search_path = public
as $$
declare
  v_row public.cfg_integracion_ia%rowtype;
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión';
  end if;
  if not public.es_administrador() then
    raise exception 'Solo un administrador puede ver las integraciones';
  end if;

  select * into v_row from public.cfg_integracion_ia where id;

  return jsonb_build_object(
    'proveedor', coalesce(v_row.proveedor, 'openai'),
    'modelo', coalesce(nullif(btrim(v_row.modelo), ''), 'gpt-4.1-mini'),
    'tiene_token', coalesce(v_row.token, '') <> '',
    'sufijo', case
      when length(coalesce(v_row.token, '')) >= 8 then right(v_row.token, 4)
      else ''
    end,
    'updated_at', v_row.updated_at
  );
end;
$$;

create or replace function public.guardar_integracion_ia(
  p_proveedor text,
  p_token text,
  p_modelo text
)
returns jsonb
language plpgsql
security definer
set search_path = public
as $$
declare
  v_token text;
  v_modelo text;
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión';
  end if;
  if not public.es_administrador() then
    raise exception 'Solo un administrador puede guardar las integraciones';
  end if;
  if coalesce(btrim(p_proveedor), 'openai') <> 'openai' then
    raise exception 'Elegí un servicio disponible';
  end if;

  v_modelo := btrim(coalesce(p_modelo, ''));
  if v_modelo = '' or v_modelo !~ '^[A-Za-z0-9][A-Za-z0-9._:-]{0,63}$' then
    raise exception 'Escribí el nombre del modelo';
  end if;

  if coalesce(p_token, '') ~ '[\r\n]' or length(coalesce(p_token, '')) > 400 then
    raise exception 'La clave no es válida';
  end if;

  select token into v_token from public.cfg_integracion_ia where id;
  if btrim(coalesce(p_token, '')) <> '' then
    v_token := btrim(p_token);
  end if;
  v_token := coalesce(v_token, '');

  if v_token = '' then
    raise exception 'Pegá la clave de OpenAI antes de guardar';
  end if;

  insert into public.cfg_integracion_ia (id, proveedor, token, modelo, updated_at)
  values (true, 'openai', v_token, v_modelo, now())
  on conflict (id) do update
  set proveedor = excluded.proveedor,
      token = excluded.token,
      modelo = excluded.modelo,
      updated_at = excluded.updated_at;

  return public.leer_integracion_ia();
end;
$$;

create or replace function public.eliminar_credencial_ia()
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

  update public.cfg_integracion_ia
  set token = '',
      updated_at = now()
  where id;

  return public.leer_integracion_ia();
end;
$$;

revoke all on function public.leer_integracion_ia() from public;
revoke all on function public.guardar_integracion_ia(text, text, text) from public;
revoke all on function public.eliminar_credencial_ia() from public;
grant execute on function public.leer_integracion_ia() to authenticated;
grant execute on function public.guardar_integracion_ia(text, text, text) to authenticated;
grant execute on function public.eliminar_credencial_ia() to authenticated;

notify pgrst, 'reload schema';
