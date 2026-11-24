-- Consulta de DNI en Decolecta. El token no sale de la base.

create extension if not exists http with schema extensions;

create or replace function public.consulta_dni_activa()
returns boolean
language sql
stable
security definer
set search_path = public
as $$
  select coalesce(
    (
      select activa and token <> ''
      from public.cfg_integracion_dni
      where id
    ),
    false
  )
  where auth.uid() is not null;
$$;

create or replace function public.consultar_dni(p_dni text)
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
  if p_dni is null or p_dni !~ '^[0-9]{8}$' then
    raise exception 'El DNI debe tener 8 dígitos';
  end if;

  select token, activa
  into v_token, v_activa
  from public.cfg_integracion_dni
  where id;

  if coalesce(v_activa, false) is not true or coalesce(v_token, '') = '' then
    raise exception 'La consulta de DNI está desactivada';
  end if;

  perform extensions.http_set_curlopt('CURLOPT_TIMEOUT_MS', '12000');
  begin
    v_respuesta := extensions.http((
      'GET',
      'https://api.decolecta.com/v1/reniec/dni?numero=' || p_dni,
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
      raise exception 'No se pudo consultar el DNI';
  end;
  perform extensions.http_reset_curlopt();

  if v_respuesta.status in (401, 403) then
    raise exception 'El token de Decolecta no es válido';
  end if;
  if v_respuesta.status <> 200 or coalesce(v_respuesta.content, '') = '' then
    raise exception 'No se encontró ese DNI';
  end if;

  begin
    v_cuerpo := v_respuesta.content::jsonb;
  exception
    when others then
      raise exception 'No se pudo consultar el DNI';
  end;

  if coalesce(v_cuerpo->>'first_name', '') = '' then
    raise exception 'No se encontró ese DNI';
  end if;

  return jsonb_build_object(
    'nombres', v_cuerpo->>'first_name',
    'apellido_paterno', coalesce(v_cuerpo->>'first_last_name', ''),
    'apellido_materno', coalesce(v_cuerpo->>'second_last_name', '')
  );
end;
$$;

revoke all on function public.consulta_dni_activa() from public;
revoke all on function public.consultar_dni(text) from public;
grant execute on function public.consulta_dni_activa() to authenticated;
grant execute on function public.consultar_dni(text) to authenticated;

notify pgrst, 'reload schema';
