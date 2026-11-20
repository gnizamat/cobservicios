-- Eliminar una facturación exige la contraseña del usuario en sesión
-- y deja el evento aunque el recibo ya no exista.
-- No se elimina si sus deudas están vinculadas a un pago.

create table if not exists public.fac_facturacion_eventos (
  id uuid primary key default gen_random_uuid(),
  facturacion_id uuid not null,
  numero text not null,
  accion text not null check (accion in ('eliminacion')),
  actor_id uuid,
  actor_email text not null default '',
  motivo text not null,
  detalle jsonb not null default '{}'::jsonb,
  created_at timestamptz not null default now()
);

create index if not exists fac_facturacion_eventos_factura_idx
  on public.fac_facturacion_eventos (facturacion_id, created_at desc);

alter table public.fac_facturacion_eventos enable row level security;

drop policy if exists "authenticated read fac_facturacion_eventos" on public.fac_facturacion_eventos;
create policy "authenticated read fac_facturacion_eventos"
  on public.fac_facturacion_eventos for select to authenticated using (true);

grant select on public.fac_facturacion_eventos to authenticated;

create or replace function public.listar_facturaciones(
  p_anio integer,
  p_mes integer,
  p_sector_id uuid default null,
  p_calle_id uuid default null
)
returns jsonb
language sql
stable
security invoker
set search_path = public
as $$
  select coalesce(
    jsonb_agg(to_jsonb(t) order by t.numero_factura),
    '[]'::jsonb
  )
  from (
    select
      f.id,
      f.numero as numero_factura,
      f.predio_id,
      p.nombre as predio,
      p.numero as numero_predio,
      btrim(concat_ws(' ', u.apellido_paterno, u.apellido_materno, u.nombres)) as usuario,
      coalesce(s.nombre, '') as sector,
      coalesce(c.nombre, '') as calle,
      f.anio,
      f.mes,
      f.monto_total as monto,
      f.fecha,
      (
        select count(*)::int
        from public.fac_facturacion_detalle fd
        where fd.facturacion_id = f.id
      ) as deudas,
      (
        exists (
          select 1
          from public.cob_pago_facturaciones l
          where l.facturacion_id = f.id
        )
        or exists (
          select 1
          from public.fac_facturacion_detalle fd
          join public.cob_pago_deudas pd on pd.deuda_anterior_id = fd.deuda_anterior_id
          where fd.facturacion_id = f.id
        )
      ) as tiene_pagos
    from public.fac_facturaciones f
    join public.pad_predios p on p.id = f.predio_id
    join public.pad_usuarios u on u.id = p.usuario_id
    left join public.cat_sectores s on s.id = p.sector_id
    left join public.cat_calles c on c.id = p.calle_id
    where f.anio = p_anio
      and f.mes = p_mes
      and f.estado = 'generada'
      and (p_sector_id is null or p.sector_id = p_sector_id)
      and (p_calle_id is null or p.calle_id = p_calle_id)
  ) as t;
$$;

create or replace function public.eliminar_facturacion(
  p_facturacion_id uuid,
  p_clave text,
  p_motivo text
)
returns jsonb
language plpgsql
security definer
set search_path = public, extensions
as $$
declare
  v_factura public.fac_facturaciones%rowtype;
  v_motivo text := btrim(coalesce(p_motivo, ''));
  v_email text := coalesce(auth.jwt() ->> 'email', '');
  v_deudas integer;
  v_detalle jsonb;
begin
  if auth.uid() is null then
    raise exception 'Tenés que iniciar sesión para eliminar la facturación';
  end if;

  if btrim(coalesce(p_clave, '')) = '' then
    raise exception 'Ingresá tu contraseña para eliminar la facturación';
  end if;

  if length(v_motivo) < 5 then
    raise exception 'Indicá el motivo de la eliminación';
  end if;

  if not exists (
    select 1
    from auth.users u
    where u.id = auth.uid()
      and u.encrypted_password = extensions.crypt(p_clave, u.encrypted_password)
  ) then
    raise exception 'La contraseña no es correcta';
  end if;

  select * into v_factura
  from public.fac_facturaciones
  where id = p_facturacion_id
  for update;

  if not found then
    raise exception 'No se encontró la facturación';
  end if;

  select count(*)::int
  into v_deudas
  from public.fac_facturacion_detalle
  where facturacion_id = p_facturacion_id;

  if v_deudas > 0 and (
    exists (
      select 1
      from public.cob_pago_facturaciones l
      where l.facturacion_id = p_facturacion_id
    )
    or exists (
      select 1
      from public.fac_facturacion_detalle fd
      join public.cob_pago_deudas pd on pd.deuda_anterior_id = fd.deuda_anterior_id
      where fd.facturacion_id = p_facturacion_id
    )
  ) then
    raise exception 'No se puede eliminar la facturación porque sus deudas están vinculadas a pagos';
  end if;

  select coalesce(
    jsonb_agg(
      jsonb_build_object(
        'deuda_id', fd.deuda_anterior_id,
        'servicio_id', fd.tipo_servicio_id,
        'monto', fd.monto
      )
      order by fd.monto desc
    ),
    '[]'::jsonb
  )
  into v_detalle
  from public.fac_facturacion_detalle fd
  where fd.facturacion_id = p_facturacion_id;

  insert into public.fac_facturacion_eventos (
    facturacion_id, numero, accion, actor_id, actor_email, motivo, detalle
  )
  values (
    v_factura.id,
    v_factura.numero,
    'eliminacion',
    auth.uid(),
    v_email,
    v_motivo,
    jsonb_build_object(
      'predio_id', v_factura.predio_id,
      'anio', v_factura.anio,
      'mes', v_factura.mes,
      'monto', v_factura.monto_total,
      'fecha', v_factura.fecha,
      'estado', v_factura.estado,
      'deudas', v_detalle
    )
  );

  delete from public.fac_facturaciones where id = p_facturacion_id;

  return jsonb_build_object(
    'id', v_factura.id,
    'numero', v_factura.numero
  );
end;
$$;

revoke all on function public.eliminar_facturacion(uuid, text, text) from public;
grant execute on function public.eliminar_facturacion(uuid, text, text) to authenticated;

notify pgrst, 'reload schema';
