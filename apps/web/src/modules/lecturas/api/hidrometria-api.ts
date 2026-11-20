import { asHidrometriaError, embedOne } from '@/modules/lecturas/api/errors'
import type {
  ControlPayload,
  LecturaPayload,
  MedidorPayload,
  VolumenPayload,
} from '@/modules/lecturas/schemas'
import { supabase } from '@/shared/lib/supabase'
import type {
  CatTipoServicio,
  HidControl,
  HidEstructura,
  HidLectura,
  HidMedidor,
  HidVolumenSinLectura,
  TipoPersona,
} from '@/shared/types/database'

export type UsuarioPredio = {
  id: string
  nombres: string
  apellido_paterno: string
  apellido_materno: string
  dni: string | null
  tipo_persona: TipoPersona
}

export type MarcaMedidor = {
  id: string
  nombre: string
}

export type MedidorAsignado = {
  id: string
  codigo: string
  marca_id: string | null
  marca: string
  fecha_instalacion: string
}

export type PredioOption = {
  id: string
  nombre: string
  numero: string
  manzana: string
  lote: string
  calle: { nombre: string } | null
  usuario: UsuarioPredio | null
  medidor: MedidorAsignado | null
}

export type PredioBusqueda = {
  items: PredioOption[]
  total: number
}

export type ServicioOption = Pick<CatTipoServicio, 'id' | 'codigo' | 'nombre'>

export type LecturaListItem = HidLectura & {
  predio: PredioOption | null
  servicio: ServicioOption | null
}

export type VolumenListItem = HidVolumenSinLectura & {
  predio: PredioOption | null
  servicio: ServicioOption | null
}

export type ControlListItem = HidControl & {
  estructura: Pick<HidEstructura, 'id' | 'codigo' | 'nombre'> | null
}

type PredioRow = Omit<PredioOption, 'calle' | 'usuario' | 'medidor'> & {
  calle: PredioOption['calle'] | Array<NonNullable<PredioOption['calle']>> | null
  usuario?: UsuarioPredio | UsuarioPredio[] | null
}

function mapPredio(value: PredioRow | PredioRow[] | null | undefined): PredioOption | null {
  const predio = embedOne(value)
  if (!predio) return null
  return {
    id: predio.id,
    nombre: predio.nombre,
    numero: predio.numero,
    manzana: predio.manzana,
    lote: predio.lote,
    calle: embedOne(predio.calle),
    usuario: embedOne(predio.usuario),
    medidor: null,
  }
}

const predioSelect =
  'id, nombre, numero, manzana, lote, calle:cat_calles(nombre), usuario:pad_usuarios(id, nombres, apellido_paterno, apellido_materno, dni, tipo_persona)'

export type TerritorioLectura = {
  sectores: Array<{ id: string; nombre: string }>
  calles: Array<{ id: string; nombre: string; sector_id: string | null }>
}

export async function listTerritorioLectura(): Promise<TerritorioLectura> {
  const [sectores, calles] = await Promise.all([
    supabase.from('cat_sectores').select('id, nombre').order('nombre'),
    supabase.from('cat_calles').select('id, nombre, sector_id').order('nombre'),
  ])
  if (sectores.error) throw asHidrometriaError(sectores.error)
  if (calles.error) throw asHidrometriaError(calles.error)
  return { sectores: sectores.data ?? [], calles: calles.data ?? [] }
}

export async function searchPredios(
  search: string,
  page: number,
  pageSize: number,
  filtros: { sectorId?: string; calleId?: string } = {},
): Promise<PredioBusqueda> {
  const term = search.trim()
  const offset = Math.max(page - 1, 0) * pageSize
  const sectorId = filtros.sectorId && filtros.sectorId !== 'all' ? filtros.sectorId : null
  const calleId = filtros.calleId && filtros.calleId !== 'all' ? filtros.calleId : null
  const { data: match, error } = await supabase.rpc('buscar_predio_ids', {
    p_search: term,
    p_estado: 'activo',
    p_tipo_predio_id: null,
    p_sector_id: sectorId,
    p_calle_id: calleId,
    p_limit: pageSize,
    p_offset: offset,
  })
  if (error) throw asHidrometriaError(error)
  const ids = match?.ids ?? []
  const total = match?.total ?? 0
  if (ids.length === 0) return { items: [], total }

  const [{ data, error: listError }, { data: medidores, error: medidorError }] = await Promise.all([
    supabase.from('pad_predios').select(predioSelect).in('id', ids),
    supabase
      .from('hid_medidores')
      .select('id, predio_id, codigo, marca_id, marca, fecha_instalacion')
      .in('predio_id', ids)
      .eq('estado', 'activo'),
  ])
  if (listError) throw asHidrometriaError(listError)
  if (medidorError) throw asHidrometriaError(medidorError)

  const medidorPorPredio = new Map(
    (medidores ?? []).map((medidor) => [
      medidor.predio_id,
      {
        id: medidor.id,
        codigo: medidor.codigo,
        marca_id: medidor.marca_id,
        marca: medidor.marca,
        fecha_instalacion: medidor.fecha_instalacion,
      },
    ]),
  )
  const byId = new Map<string, PredioOption>()
  for (const row of data ?? []) {
    const mapped = mapPredio(row)
    if (!mapped) continue
    mapped.medidor = medidorPorPredio.get(mapped.id) ?? null
    byId.set(mapped.id, mapped)
  }

  return {
    total,
    items: ids
      .map((id) => byId.get(id))
      .filter((row): row is PredioOption => row != null),
  }
}

export async function saveMedidor(
  id: string | null,
  payload: MedidorPayload,
): Promise<HidMedidor> {
  const query = id
    ? supabase.from('hid_medidores').update(payload).eq('id', id)
    : supabase.from('hid_medidores').insert(payload)
  const { data, error } = await query.select('*').single()
  if (error) {
    if (error.code === '23505' && error.message.includes('codigo')) {
      throw new Error('Ya existe un medidor activo con ese código.')
    }
    if (error.code === '23505') {
      throw new Error('Ese predio ya tiene un medidor activo.')
    }
    throw asHidrometriaError(error)
  }
  return data
}

export async function listMarcasMedidor(): Promise<MarcaMedidor[]> {
  const { data, error } = await supabase
    .from('hid_marcas_medidor')
    .select('id, nombre')
    .order('nombre', { ascending: true })
  if (error) throw asHidrometriaError(error)
  return data ?? []
}

export type ValorM3Activo = {
  anio: number
  nombre: string
  valor: number
}

export async function listValoresVolumen(): Promise<ValorM3Activo[]> {
  const { data, error } = await supabase
    .from('cat_costos_tarifa')
    .select('valor, monto, tarifa:cat_tarifas(anio, nombre), servicio:cat_tipos_servicio(codigo, categoria)')
  if (error) throw asHidrometriaError(error)

  const elegidos = new Map<number, ValorM3Activo & { preferida: boolean }>()
  for (const row of data ?? []) {
    const tarifa = embedOne(row.tarifa)
    const servicio = embedOne(row.servicio)
    if (!tarifa || servicio?.categoria !== 'volumen') continue
    const valor = Number(row.valor ?? 0)
    const monto = Number(row.monto ?? 0)
    const item = {
      anio: tarifa.anio,
      nombre: tarifa.nombre,
      valor: valor > 0 ? valor : monto,
      preferida: servicio.codigo === 'VOL',
    }
    const actual = elegidos.get(tarifa.anio)
    if (!actual || (item.preferida && !actual.preferida)) elegidos.set(tarifa.anio, item)
  }

  return [...elegidos.values()].map(({ anio, nombre, valor }) => ({ anio, nombre, valor }))
}

export async function listServicioOptions(): Promise<ServicioOption[]> {
  const { data, error } = await supabase
    .from('cat_tipos_servicio')
    .select('id, codigo, nombre')
    .order('codigo', { ascending: true })
  if (error) throw asHidrometriaError(error)
  return data ?? []
}

export async function listEstructuras(): Promise<HidEstructura[]> {
  const { data, error } = await supabase
    .from('hid_estructuras')
    .select('*')
    .order('codigo', { ascending: true })
  if (error) throw asHidrometriaError(error)
  return data ?? []
}

export async function listLecturas(): Promise<LecturaListItem[]> {
  const { data, error } = await supabase
    .from('hid_lecturas')
    .select(
      `*, predio:pad_predios(${predioSelect}), servicio:cat_tipos_servicio(id, codigo, nombre)`,
    )
    .order('anio', { ascending: false })
    .order('mes', { ascending: false })
  if (error) throw asHidrometriaError(error)
  return (data ?? []).map((row) => ({
    ...row,
    predio: mapPredio(row.predio),
    servicio: embedOne(row.servicio),
  }))
}

export type LecturaGuardada = HidLectura & {
  deuda_generada: boolean
  deuda_monto: number
  deuda_volumen: number
}

export async function saveLectura(
  id: string | null,
  payload: LecturaPayload,
): Promise<LecturaGuardada> {
  const { data, error } = await supabase.rpc('registrar_lectura', {
    p_id: id,
    p_predio_id: payload.predio_id,
    p_tipo_servicio_id: payload.tipo_servicio_id,
    p_anio: payload.anio,
    p_mes: payload.mes,
    p_fecha_lectura: payload.fecha_lectura,
    p_lectura_m3: payload.lectura_m3,
    p_lectura_lt: payload.lectura_lt,
    p_volumen_m3: payload.volumen_m3,
    p_referencia: payload.referencia,
  })
  if (error) throw asHidrometriaError(error)

  const body = data as {
    lectura?: HidLectura
    deuda_generada?: boolean
    deuda_monto?: number | string
    deuda_volumen?: number | string
  } | null
  const lectura = body?.lectura
  if (!lectura?.id) throw new Error('No se pudo registrar la lectura.')

  return {
    ...lectura,
    anio: Number(lectura.anio),
    mes: Number(lectura.mes),
    lectura_m3: Number(lectura.lectura_m3),
    lectura_lt: Number(lectura.lectura_lt),
    volumen_m3: Number(lectura.volumen_m3),
    deuda_generada: Boolean(body?.deuda_generada),
    deuda_monto: Number(body?.deuda_monto ?? 0),
    deuda_volumen: Number(body?.deuda_volumen ?? lectura.volumen_m3),
  }
}

export async function deleteLectura(id: string): Promise<void> {
  const { error } = await supabase.rpc('eliminar_lectura', { p_id: id })
  if (error) throw asHidrometriaError(error)
}

export async function listVolumenes(): Promise<VolumenListItem[]> {
  const { data, error } = await supabase
    .from('hid_volumenes_sin_lectura')
    .select(
      `*, predio:pad_predios(${predioSelect}), servicio:cat_tipos_servicio(id, codigo, nombre)`,
    )
    .order('anio', { ascending: false })
    .order('mes', { ascending: false })
  if (error) throw asHidrometriaError(error)
  return (data ?? []).map((row) => ({
    ...row,
    predio: mapPredio(row.predio),
    servicio: embedOne(row.servicio),
  }))
}

export async function saveVolumen(
  id: string | null,
  payload: VolumenPayload,
): Promise<HidVolumenSinLectura> {
  const query = id
    ? supabase.from('hid_volumenes_sin_lectura').update(payload).eq('id', id)
    : supabase.from('hid_volumenes_sin_lectura').insert(payload)
  const { data, error } = await query.select('*').single()
  if (error) throw asHidrometriaError(error)
  return data
}

export async function listControles(): Promise<ControlListItem[]> {
  const { data, error } = await supabase
    .from('hid_control')
    .select('*, estructura:hid_estructuras(id, codigo, nombre)')
    .order('fecha_lectura', { ascending: false })
    .order('hora_inicio', { ascending: false })
  if (error) throw asHidrometriaError(error)
  return (data ?? []).map((row) => ({
    ...row,
    estructura: embedOne(row.estructura),
  }))
}

export async function saveControl(
  id: string | null,
  payload: ControlPayload,
): Promise<HidControl> {
  const query = id
    ? supabase.from('hid_control').update(payload).eq('id', id)
    : supabase.from('hid_control').insert(payload)
  const { data, error } = await query.select('*').single()
  if (error) throw asHidrometriaError(error)
  return data
}
