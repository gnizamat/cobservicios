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
    'pad_usuarios',
    `select format(
       'insert into public.pad_usuarios (id, tipo_persona, nombres, apellido_paterno, apellido_materno, dni, ruc, sexo, direccion, email, celular, estado, created_at, updated_at) values (%L, %L::public.tipo_persona, %L, %L, %L, %L, %L, %L::public.sexo, %L, %L, %L, %L::public.estado_registro, %L, %L) on conflict (id) do nothing;',
       id,
       tipo_persona::text,
       nombres,
       apellido_paterno,
       apellido_materno,
       dni,
       ruc,
       sexo::text,
       direccion,
       email,
       celular,
       estado::text,
       created_at,
       updated_at
     )
     from public.pad_usuarios
     order by created_at, id;`,
  ),
  section(
    'pad_predios',
    `select format(
       'insert into public.pad_predios (id, usuario_id, tipo_predio_id, sector_id, calle_id, nombre, numero, manzana, lote, partida_registral, unidad_catastral, titulo, fecha_documento, coord_este, coord_norte, estado, created_at, updated_at) values (%L, %L, %L, %L, %L, %L, %L, %L, %L, %L, %L, %L, %L, %L, %L, %L::public.estado_registro, %L, %L) on conflict (id) do nothing;',
       id,
       usuario_id,
       tipo_predio_id,
       sector_id,
       calle_id,
       nombre,
       numero,
       manzana,
       lote,
       partida_registral,
       unidad_catastral,
       titulo,
       fecha_documento,
       coord_este,
       coord_norte,
       estado::text,
       created_at,
       updated_at
     )
     from public.pad_predios
     order by created_at, id;`,
  ),
]

const header = `-- Usuarios y predios del padron local.
-- Idempotente por id. Cada predio nuevo dispara el historial de titularidad.
-- Contiene datos personales: no publicar este archivo.

begin;

`

const out = join(webRoot, 'supabase', 'seeds', 'usuarios_predios.sql')
mkdirSync(dirname(out), { recursive: true })
writeFileSync(out, `${header}${sections.join('\n')}commit;\n`)
console.log(out)
