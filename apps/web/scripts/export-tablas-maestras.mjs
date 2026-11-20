import { execFileSync } from 'node:child_process'
import { mkdirSync, writeFileSync } from 'node:fs'
import { dirname, join } from 'node:path'
import { fileURLToPath } from 'node:url'

const webRoot = join(dirname(fileURLToPath(import.meta.url)), '..')

function query(sql) {
  return execFileSync(
    'docker',
    ['exec', '-i', 'supabase_db_web', 'psql', '-U', 'postgres', '-d', 'postgres', '-At', '-v', 'ON_ERROR_STOP=1'],
    { input: sql, encoding: 'utf8' },
  ).trim()
}

function section(title, sql) {
  const body = query(sql)
  return `-- ${title}\n${body.length ? body : '-- sin registros'}\n`
}

const sections = [
  section(
    'cat_sectores',
    `select format('insert into public.cat_sectores (id, codigo, nombre, created_at) values (%L, %L, %L, %L);', id, codigo, nombre, created_at) from public.cat_sectores order by codigo;`,
  ),
  section(
    'cat_calles',
    `select format('insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values (%L, %L, %L, %L, %L);', id, sector_id, nombre, referencia, created_at) from public.cat_calles order by nombre;`,
  ),
  section(
    'cat_tipos_predio',
    `select format('insert into public.cat_tipos_predio (id, codigo, nombre) values (%L, %L, %L);', id, codigo, nombre) from public.cat_tipos_predio order by codigo;`,
  ),
  section(
    'cat_tipos_servicio',
    `select format('insert into public.cat_tipos_servicio (id, codigo, nombre, categoria, estado, created_at, updated_at) values (%L, %L, %L, %L::public.categoria_servicio, %L::public.estado_registro, %L, %L);', id, codigo, nombre, categoria::text, estado::text, created_at, updated_at) from public.cat_tipos_servicio order by codigo;`,
  ),
  section(
    'cat_tarifas',
    `select format('insert into public.cat_tarifas (id, anio, nombre, modalidad, unidad_recaudacion, activa, created_at, updated_at) values (%L, %s, %L, %L, %L, %L, %L, %L);', id, anio, nombre, modalidad, unidad_recaudacion, activa, created_at, updated_at) from public.cat_tarifas order by anio;`,
  ),
  section(
    'cat_costos_tarifa',
    `select format('insert into public.cat_costos_tarifa (id, tarifa_id, tipo_servicio_id, valor, monto, created_at, updated_at) values (%L, %L, %L, %s, %s, %L, %L);', id, tarifa_id, tipo_servicio_id, valor, monto, created_at, updated_at) from public.cat_costos_tarifa order by created_at;`,
  ),
  section(
    'cat_costos_tarifa_historial',
    `select format('insert into public.cat_costos_tarifa_historial (id, costo_id, tarifa_id, tipo_servicio_id, monto_anterior, monto_nuevo, valor_anterior, valor_nuevo, created_at, created_by) values (%L, %L, %L, %L, %s, %s, %s, %s, %L, null);', id, costo_id, tarifa_id, tipo_servicio_id, monto_anterior, monto_nuevo, valor_anterior, valor_nuevo, created_at) from public.cat_costos_tarifa_historial order by created_at;`,
  ),
  section(
    'cat_documentos',
    `select format('insert into public.cat_documentos (id, codigo, nombre, estado, created_at, updated_at) values (%L, %L, %L, %L::public.estado_registro, %L, %L);', id, codigo, nombre, estado::text, created_at, updated_at) from public.cat_documentos order by codigo;`,
  ),
  section(
    'cat_bancos',
    `select format('insert into public.cat_bancos (id, nombre, cuenta, estado, created_at, updated_at) values (%L, %L, %L, %L::public.estado_registro, %L, %L);', id, nombre, cuenta, estado::text, created_at, updated_at) from public.cat_bancos order by nombre;`,
  ),
  section(
    'cat_conceptos_multa',
    `select format('insert into public.cat_conceptos_multa (id, nombre, monto, estado, created_at, updated_at) values (%L, %L, %s, %L::public.estado_registro, %L, %L);', id, nombre, monto, estado::text, created_at, updated_at) from public.cat_conceptos_multa order by nombre;`,
  ),
  section(
    'cat_intereses',
    `select format('insert into public.cat_intereses (id, nombre, porcentaje, estado, created_at, updated_at) values (%L, %L, %s, %L::public.estado_registro, %L, %L);', id, nombre, porcentaje, estado::text, created_at, updated_at) from public.cat_intereses order by nombre;`,
  ),
  section(
    'hid_marcas_medidor',
    `select format('insert into public.hid_marcas_medidor (id, nombre, created_at) values (%L, %L, %L);', id, nombre, created_at) from public.hid_marcas_medidor order by nombre;`,
  ),
  section(
    'cob_cajas',
    `select format('insert into public.cob_cajas (id, nombre, activa, created_at) values (%L, %L, %L, %L);', id, nombre, activa, created_at) from public.cob_cajas order by nombre;`,
  ),
  section(
    'org_jass',
    `select format('insert into public.org_jass (id, nombre, abreviatura, celular, direccion, email, logo_path, latitud, longitud, created_at, updated_at) values (true, %L, %L, %L, %L, %L, %L, %s, %s, %L, %L) on conflict (id) do update set nombre = excluded.nombre, abreviatura = excluded.abreviatura, celular = excluded.celular, direccion = excluded.direccion, email = excluded.email, logo_path = excluded.logo_path, latitud = excluded.latitud, longitud = excluded.longitud;', nombre, abreviatura, celular, direccion, email, logo_path, latitud, longitud, created_at, updated_at) from public.org_jass;`,
  ),
  section(
    'app_meta',
    `select format('insert into public.app_meta (key, value, updated_at) values (%L, %L, %L) on conflict (key) do update set value = excluded.value;', key, value, updated_at) from public.app_meta order by key;`,
  ),
]

const header = `-- Tablas maestras de JASS Nuevo Tallan.
-- Reemplaza el catalogo de ejemplo. Se detiene si ya hay padron, facturas, pagos, medidores o asambleas.

begin;

do $$
begin
  if exists (select 1 from public.pad_predios)
     or exists (select 1 from public.pad_usuarios)
     or exists (select 1 from public.fac_facturaciones)
     or exists (select 1 from public.fac_deudas_anteriores)
     or exists (select 1 from public.cob_pagos)
     or exists (select 1 from public.hid_medidores)
     or exists (select 1 from public.hid_lecturas)
     or exists (select 1 from public.asm_asambleas)
  then
    raise exception 'Hay datos operativos que dependen del catalogo. No se reemplazan las tablas maestras.';
  end if;
end $$;

delete from public.cat_costos_tarifa_historial;
delete from public.cat_costos_tarifa;
delete from public.cat_tarifas;
delete from public.cat_calles;
delete from public.cat_sectores;
delete from public.cat_tipos_servicio;
delete from public.cat_tipos_predio;
delete from public.cat_documentos;
delete from public.hid_marcas_medidor;
delete from public.cob_cajas;
delete from public.cat_bancos;
delete from public.cat_conceptos_multa;
delete from public.cat_intereses;

`

const out = join(webRoot, 'supabase', 'seeds', 'tablas_maestras.sql')
mkdirSync(dirname(out), { recursive: true })
writeFileSync(out, `${header}${sections.join('\n')}commit;\n`)
console.log(out)
