/**
 * Migra padUsuario / padPredio desde SQL Server legado hacia Supabase local.
 *
 * Uso:
 *   node scripts/migrate-padron.mjs
 *
 * Requiere:
 *   - SQL Server con DB_JASS_NVOTALLAN restaurada (npm run db:legacy:up && db:legacy:restore)
 *   - Supabase local arriba
 */
import { createClient } from '@supabase/supabase-js'
import { readFileSync, writeFileSync, mkdirSync } from 'node:fs'
import { join, dirname } from 'node:path'
import { fileURLToPath } from 'node:url'
import { spawnSync } from 'node:child_process'

const __dirname = dirname(fileURLToPath(import.meta.url))
const webRoot = join(__dirname, '..')
const outDir = join(webRoot, 'scripts', '.migrate-cache')

const SA_PASSWORD = 'Cobser_Legacy_2022!'
const CONTAINER = 'cobservicios-sqlserver-legacy'
const SQLCMD = '/opt/mssql-tools18/bin/sqlcmd'
const DB = 'DB_JASS_NVOTALLAN'

function loadEnvLocal() {
  const raw = readFileSync(join(webRoot, '.env.local'), 'utf8')
  return Object.fromEntries(
    raw
      .split(/\r?\n/)
      .filter((line) => line && !line.startsWith('#') && line.includes('='))
      .map((line) => {
        const i = line.indexOf('=')
        return [line.slice(0, i), line.slice(i + 1)]
      }),
  )
}

function sqlcmd(query, { asCsv = false } = {}) {
  const args = [
    'exec',
    CONTAINER,
    SQLCMD,
    '-S',
    'localhost',
    '-U',
    'sa',
    '-P',
    SA_PASSWORD,
    '-C',
    '-d',
    DB,
    '-W',
    '-h',
    '-1',
    ...(asCsv ? ['-s', '|'] : []),
    '-Q',
    `SET NOCOUNT ON; ${query}`,
  ]
  const result = spawnSync('docker', args, { encoding: 'utf8', maxBuffer: 64 * 1024 * 1024 })
  if (result.status !== 0) {
    throw new Error(result.stderr || result.stdout || 'sqlcmd failed')
  }
  return result.stdout
}

function parsePipeCsv(text) {
  return text
    .split(/\r?\n/)
    .map((line) => line.trimEnd())
    .filter((line) => line.length > 0 && !line.startsWith('Msg ') && !/rows affected/i.test(line))
    .map((line) => line.split('|').map((cell) => cell.trim()))
}

function mapTipoPersona(value) {
  const v = String(value ?? '1').trim()
  if (v === '2') return 'juridica'
  if (v === '3') return 'institucional'
  return 'natural'
}

function mapSexo(value) {
  const v = String(value ?? '').trim().toUpperCase()
  if (v === 'M' || v === 'F') return v
  if (v === '1' || v === 'MASCULINO') return 'M'
  if (v === '2' || v === 'FEMENINO') return 'F'
  return null
}

function mapEstado(value) {
  const v = String(value ?? '1').trim()
  return v === '0' || v.toLowerCase() === 'inactivo' ? 'inactivo' : 'activo'
}

function emptyToNull(value) {
  const v = String(value ?? '').trim()
  return v.length === 0 || v.toLowerCase() === 'null' ? null : v
}

function sqlText(expression) {
  return `REPLACE(REPLACE(REPLACE(ISNULL(${expression},''), '|', '/'), CHAR(13), ' '), CHAR(10), ' ')`
}

async function wipe(supabase, table) {
  const { error } = await supabase
    .from(table)
    .delete()
    .neq('id', '00000000-0000-0000-0000-000000000000')
  if (error) throw new Error(`No se pudo vaciar ${table}: ${error.message}`)
}

function displayUsuario(row) {
  return [row.nombres, row.apellido_paterno, row.apellido_materno].filter(Boolean).join(' ').trim()
}

async function main() {
  mkdirSync(outDir, { recursive: true })
  const env = loadEnvLocal()
  const supabase = createClient(env.VITE_SUPABASE_URL, env.VITE_SUPABASE_ANON_KEY)

  console.log('Exportando centros poblados, calles, usuarios y predios…')
  const centrosRaw = parsePipeCsv(
    sqlcmd(
      `SELECT CAST(idCP AS varchar(32)), ${sqlText('vNombre')}, ISNULL(CAST(cEstado AS varchar(8)),'1')
       FROM CentroPoblado ORDER BY idCP`,
      { asCsv: true },
    ),
  )
  const callesRaw = parsePipeCsv(
    sqlcmd(
      `SELECT CAST(idCalle AS varchar(32)), CAST(ISNULL(idCp,0) AS varchar(32)), ${sqlText('vNombre')}, ${sqlText('vReferencia')}
       FROM Calles ORDER BY idCalle`,
      { asCsv: true },
    ),
  )
  console.log(`Centros poblados: ${centrosRaw.length} · Calles: ${callesRaw.length}`)

  console.log('Exportando padUsuario desde SQL Server…')
  const usuariosRaw = parsePipeCsv(
    sqlcmd(
      `SELECT
        CAST(iIdUsuario AS varchar(32)),
        ISNULL(vIdJas,''),
        ISNULL(vUsuario,''),
        ISNULL(vApePaterno,''),
        ISNULL(vApeMaterno,''),
        ISNULL(vDni,''),
        ISNULL(vRuc,''),
        ISNULL(CAST(cTipoPersona AS varchar(8)),'1'),
        ISNULL(CAST(cSexo AS varchar(8)),''),
        ISNULL(vDireccion,''),
        ISNULL(vEmail,''),
        ISNULL(vCelular,''),
        ISNULL(CAST(cEstado AS varchar(8)),'1')
      FROM padUsuario
      ORDER BY iIdUsuario`,
      { asCsv: true },
    ),
  )

  console.log(`Usuarios exportados: ${usuariosRaw.length}`)

  console.log('Exportando padPredio desde SQL Server…')
  const prediosRaw = parsePipeCsv(
    sqlcmd(
      `SELECT
        CAST(idpredio AS varchar(32)),
        ISNULL(vIdJas,''),
        ISNULL(CAST(iIdusuario AS varchar(32)),''),
        ISNULL(CAST(idtpredio AS varchar(32)),''),
        ISNULL(CAST(idCP AS varchar(32)),''),
        ISNULL(CAST(idCalle AS varchar(32)),''),
        ${sqlText('vNombre')},
        ${sqlText('vNroPredio')},
        ${sqlText('MzPredio')},
        ${sqlText('lotePredio')},
        ${sqlText('vPartidaR')},
        ${sqlText('vUC')},
        ${sqlText('vTitulo')},
        ISNULL(CONVERT(varchar(10), dFechaDoc, 23),''),
        ISNULL(vCEste,''),
        ISNULL(vCNorte,''),
        ISNULL(CAST(cEstado AS varchar(8)), ISNULL(CAST(cEstadoPredio AS varchar(8)),'1'))
      FROM padPredio
      ORDER BY idpredio`,
      { asCsv: true },
    ),
  )
  console.log(`Predios exportados: ${prediosRaw.length}`)

  const usuariosMapped = usuariosRaw.map((cols) => {
    const [
      legacyId,
      idJas,
      nombres,
      apePat,
      apeMat,
      dni,
      ruc,
      tipo,
      sexo,
      direccion,
      email,
      celular,
      estado,
    ] = cols
    return {
      legacy_key: `${idJas}:${legacyId}`,
      tipo_persona: mapTipoPersona(tipo),
      nombres: emptyToNull(nombres) ?? 'SIN NOMBRE',
      apellido_paterno: emptyToNull(apePat) ?? '',
      apellido_materno: emptyToNull(apeMat) ?? '',
      dni: emptyToNull(dni),
      ruc: emptyToNull(ruc),
      sexo: mapSexo(sexo),
      direccion: emptyToNull(direccion) ?? '',
      email: emptyToNull(email),
      celular: emptyToNull(celular),
      estado: mapEstado(estado),
    }
  })

  // DNI/RUC únicos: si hay duplicados, conservar el primero y anular en siguientes
  const seenDni = new Set()
  const seenRuc = new Set()
  for (const u of usuariosMapped) {
    if (u.dni) {
      if (seenDni.has(u.dni)) u.dni = null
      else seenDni.add(u.dni)
    }
    if (u.ruc) {
      if (seenRuc.has(u.ruc)) u.ruc = null
      else seenRuc.add(u.ruc)
    }
  }

  writeFileSync(join(outDir, 'usuarios.json'), JSON.stringify(usuariosMapped, null, 2))

  // Auth session required by RLS (authenticated policies)
  const email = 'admin@cobservicios.local'
  const password = 'Cobser123!'
  const { error: signInError } = await supabase.auth.signInWithPassword({ email, password })
  if (signInError) {
    throw new Error(`No se pudo autenticar en Supabase: ${signInError.message}`)
  }

  console.log('Limpiando padrón anterior…')
  for (const table of [
    'hid_lecturas',
    'hid_volumenes_sin_lectura',
    'hid_medidores',
    'fac_deudas_anteriores',
    'pad_predio_historial',
    'pad_transferencias',
    'pad_predios',
    'pad_usuarios',
    'cat_calles',
    'cat_sectores',
  ]) {
    await wipe(supabase, table)
  }

  console.log('Cargando centros poblados y calles…')
  const cpMap = new Map()
  for (const [legacyId, nombre] of centrosRaw) {
    const codigo = `CP-${legacyId}`
    const { data, error } = await supabase
      .from('cat_sectores')
      .insert({ codigo, nombre: emptyToNull(nombre) ?? `Centro ${legacyId}` })
      .select('id')
      .single()
    if (error) throw new Error(`Centro poblado ${nombre}: ${error.message}`)
    cpMap.set(legacyId, data.id)
  }

  const calleMap = new Map()
  for (const [legacyId, idCp, nombre, referencia] of callesRaw) {
    const { data, error } = await supabase
      .from('cat_calles')
      .insert({
        sector_id: cpMap.get(idCp) ?? null,
        nombre: emptyToNull(nombre) ?? `Calle ${legacyId}`,
        referencia: emptyToNull(referencia) ?? '',
      })
      .select('id')
      .single()
    if (error) throw new Error(`Calle ${nombre}: ${error.message}`)
    calleMap.set(legacyId, data.id)
  }

  console.log('Insertando usuarios…')
  const legacyToUuid = new Map()
  const chunkSize = 200
  for (let i = 0; i < usuariosMapped.length; i += chunkSize) {
    const chunk = usuariosMapped.slice(i, i + chunkSize)
    const payload = chunk.map(({ legacy_key: _k, ...rest }) => rest)
    const { data, error } = await supabase.from('pad_usuarios').insert(payload).select('id, nombres, apellido_paterno, apellido_materno, dni, ruc')
    if (error) throw new Error(`Insert usuarios falló: ${error.message}`)

    // Map by order within chunk (stable insert order)
    chunk.forEach((src, idx) => {
      legacyToUuid.set(src.legacy_key, data[idx].id)
    })
    console.log(`  usuarios ${Math.min(i + chunkSize, usuariosMapped.length)}/${usuariosMapped.length}`)
  }

  writeFileSync(
    join(outDir, 'usuario-id-map.json'),
    JSON.stringify(Object.fromEntries(legacyToUuid), null, 2),
  )

  const { data: tipos } = await supabase.from('cat_tipos_predio').select('id, codigo')
  const tipoLegacyNum = {
    '1': tipos?.find((t) => t.codigo === 'DOM')?.id ?? null,
    '2': tipos?.find((t) => t.codigo === 'COM')?.id ?? null,
    '3': tipos?.find((t) => t.codigo === 'IND')?.id ?? null,
    '4': tipos?.find((t) => t.codigo === 'EST')?.id ?? null,
  }

  const prediosMapped = []
  let skippedNoUser = 0
  for (const cols of prediosRaw) {
    const [
      legacyPredioId,
      idJas,
      legacyUsuarioId,
      idtpredio,
      idCp,
      idCalle,
      nombre,
      numero,
      manzana,
      lote,
      partida,
      uc,
      titulo,
      fechaDoc,
      este,
      norte,
      estado,
    ] = cols

    const userKey = `${idJas}:${legacyUsuarioId}`
    const usuarioId = legacyToUuid.get(userKey)
    if (!usuarioId) {
      skippedNoUser += 1
      continue
    }

    prediosMapped.push({
      usuario_id: usuarioId,
      tipo_predio_id: tipoLegacyNum[String(idtpredio).trim()] ?? tipoLegacyNum['1'] ?? null,
      sector_id: cpMap.get(String(idCp).trim()) ?? null,
      calle_id: calleMap.get(String(idCalle).trim()) ?? null,
      nombre: emptyToNull(nombre) ?? `Predio ${legacyPredioId}`,
      numero: emptyToNull(numero) ?? '',
      manzana: emptyToNull(manzana) ?? '',
      lote: emptyToNull(lote) ?? '',
      partida_registral: emptyToNull(partida) ?? '',
      unidad_catastral: emptyToNull(uc) ?? '',
      titulo: emptyToNull(titulo) ?? '',
      fecha_documento: emptyToNull(fechaDoc),
      coord_este: emptyToNull(este) ?? '',
      coord_norte: emptyToNull(norte) ?? '',
      estado: mapEstado(estado),
    })
  }

  writeFileSync(join(outDir, 'predios.json'), JSON.stringify(prediosMapped, null, 2))
  console.log(`Predios a insertar: ${prediosMapped.length} (omitidos sin usuario: ${skippedNoUser})`)

  console.log('Insertando predios…')
  for (let i = 0; i < prediosMapped.length; i += chunkSize) {
    const chunk = prediosMapped.slice(i, i + chunkSize)
    const { error } = await supabase.from('pad_predios').insert(chunk)
    if (error) throw new Error(`Insert predios falló: ${error.message}`)
    console.log(`  predios ${Math.min(i + chunkSize, prediosMapped.length)}/${prediosMapped.length}`)
  }

  console.log('OK migración padrón DB_JASS_NVOTALLAN')
  console.log(`Centros poblados: ${cpMap.size}`)
  console.log(`Calles: ${calleMap.size}`)
  console.log(`Usuarios: ${usuariosMapped.length}`)
  console.log(`Predios: ${prediosMapped.length}`)
  console.log(`Ejemplo usuario: ${displayUsuario(usuariosMapped[0] ?? { nombres: '-' })}`)
}

main().catch((error) => {
  console.error(error)
  process.exit(1)
})
