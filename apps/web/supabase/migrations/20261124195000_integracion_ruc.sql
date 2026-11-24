-- Credencial y consulta de RUC en Decolecta. El token no sale de la base.

create table public.cfg_integracion_ruc (
  id boolean primary key default true check (id),
  proveedor text not null default 'decolecta' check (proveedor in ('decolecta')),
  token text not null default '',
  activa boolean not null default false,
  updated_at timestamptz not null default now()
);

insert into public.cfg_integracion_ruc (id)
values (true)
on conflict (id) do nothing;

comment on table public.cfg_integracion_ruc is
  'Integración para autocompletar la razón social a partir del RUC. No verifica identidad.';

alter table public.cfg_integracion_ruc enable row level security;
revoke all on table public.cfg_integracion_ruc from public, anon, authenticated;

create or replace function public.leer_integracion_ruc()
returns jsonb
language plpgsql
stable
security definer
set search_path = public
as $$
declare
  v_row public.cfg_integracion_ruc%rowtype;
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión';
  end if;
  if not public.es_administrador() then
    raise exception 'Solo un administrador puede ver las integraciones';
  end if;

  select * into v_row from public.cfg_integracion_ruc where id;

  return jsonb_build_object(
    'proveedor', coalesce(v_row.proveedor, 'decolecta'),
    'activa', coalesce(v_row.activa, false),
    'tiene_token', coalesce(v_row.token, '') <> '',
    'updated_at', v_row.updated_at
  );
end;
$$;

create or replace function public.guardar_integracion_ruc(
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

  select token into v_token from public.cfg_integracion_ruc where id;
  if btrim(coalesce(p_token, '')) <> '' then
    v_token := btrim(p_token);
  end if;
  v_token := coalesce(v_token, '');
  v_activa := coalesce(p_activa, false);

  if v_activa and v_token = '' then
    raise exception 'Pegá el token del proveedor antes de activar la integración';
  end if;

  insert into public.cfg_integracion_ruc (id, proveedor, token, activa, updated_at)
  values (true, 'decolecta', v_token, v_activa, now())
  on conflict (id) do update
  set proveedor = excluded.proveedor,
      token = excluded.token,
      activa = excluded.activa,
      updated_at = excluded.updated_at;

  return public.leer_integracion_ruc();
end;
$$;

create or replace function public.eliminar_credencial_ruc()
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

  update public.cfg_integracion_ruc
  set token = '',
      activa = false,
      updated_at = now()
  where id;

  return public.leer_integracion_ruc();
end;
$$;

create or replace function public.consulta_ruc_activa()
returns boolean
language sql
stable
security definer
set search_path = public
as $$
  select coalesce(
    (
      select activa and token <> ''
      from public.cfg_integracion_ruc
      where id
    ),
    false
  )
  where auth.uid() is not null;
$$;

create or replace function public.consultar_ruc(p_ruc text)
returns jsonb
language plpgsql
security definer
set search_path = public, extensions
as $$
declare
  v_token text;
  v_activa boolean;
  v_respuesta extensions.http_response;
  v_cuerpo jsonb;
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión';
  end if;
  if p_ruc is null or p_ruc !~ '^[0-9]{11}$' then
    raise exception 'El RUC debe tener 11 dígitos';
  end if;

  select token, activa
  into v_token, v_activa
  from public.cfg_integracion_ruc
  where id;

  if coalesce(v_activa, false) is not true or coalesce(v_token, '') = '' then
    raise exception 'La consulta de RUC está desactivada';
  end if;

  perform extensions.http_set_curlopt('CURLOPT_TIMEOUT_MS', '12000');
  begin
    v_respuesta := extensions.http((
      'GET',
      'https://api.decolecta.com/v1/sunat/ruc?numero=' || p_ruc,
      array[
        extensions.http_header('Authorization', 'Bearer ' || v_token),
        extensions.http_header('Accept', 'application/json')
      ],
      null,
      null
    )::extensions.http_request);
  exception
    when others then
      perform extensions.http_reset_curlopt();
      raise exception 'No se pudo consultar el RUC';
  end;
  perform extensions.http_reset_curlopt();

  if v_respuesta.status in (401, 403) then
    raise exception 'El token de Decolecta no es válido';
  end if;
  if v_respuesta.status <> 200 or coalesce(v_respuesta.content, '') = '' then
    raise exception 'No se encontró ese RUC';
  end if;

  begin
    v_cuerpo := v_respuesta.content::jsonb;
  exception
    when others then
      raise exception 'No se pudo consultar el RUC';
  end;

  if coalesce(v_cuerpo->>'razon_social', '') = '' then
    raise exception 'No se encontró ese RUC';
  end if;

  return jsonb_build_object(
    'razon_social', v_cuerpo->>'razon_social',
    'direccion', coalesce(v_cuerpo->>'direccion', '')
  );
end;
$$;

revoke all on function public.leer_integracion_ruc() from public;
revoke all on function public.guardar_integracion_ruc(text, text, boolean) from public;
revoke all on function public.eliminar_credencial_ruc() from public;
revoke all on function public.consulta_ruc_activa() from public;
revoke all on function public.consultar_ruc(text) from public;
grant execute on function public.leer_integracion_ruc() to authenticated;
grant execute on function public.guardar_integracion_ruc(text, text, boolean) to authenticated;
grant execute on function public.eliminar_credencial_ruc() to authenticated;
grant execute on function public.consulta_ruc_activa() to authenticated;
grant execute on function public.consultar_ruc(text) to authenticated;

notify pgrst, 'reload schema';
