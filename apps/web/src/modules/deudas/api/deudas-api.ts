import { asDeudaError, embedOne } from '@/modules/deudas/api/errors'
import type { DeudaAnteriorPayload } from '@/modules/deudas/schemas'
import type {
  CostoTarifaOption,
  DeudaAnteriorListItem,
  PredioBusqueda,
  PredioDeudaOption,
  GenerarDeudasFijasResultado,
  PredioConvenio,
  PredioDeudaFija,
  TarifaAnio,
  UsuarioPredio,
} from '@/modules/deudas/types'
import { supabase } from '@/shared/lib/supabase'
import type { CategoriaServicio, Json } from '@/shared/types/database'

type PredioRow = Omit<PredioDeudaOption, 'calle' | 'usuario'> & {
  calle: PredioDeudaOption['calle'] | Array<NonNullable<PredioDeudaOption['calle']>> | null
  usuario?: UsuarioPredio | UsuarioPredio[] | null
}

type CostoRow = {
  id: string
  tarifa_id: string
  tipo_servicio_id: string
  valor: number | string
  monto: number | string
  tarifa:
    | { id: string; anio: number; nombre: string }
    | Array<{ id: string; anio: number; nombre: string }>
    | null
  servicio:
    | { id: string; codigo: string; nombre: string; categoria: CategoriaServicio }
    | Array<{ id: string; codigo: string; nombre: string; categoria: CategoriaServicio }>
    | null
}

type DeudaRow = Omit<DeudaAnteriorListItem, 'servicio' | 'tarifa' | 'monto' | 'interes' | 'saldo' | 'volumen'> & {
  monto: number | string
  interes: number | string
  saldo: number | string
  volumen: number | string
  servicio: DeudaAnteriorListItem['servicio'] | Array<NonNullable<DeudaAnteriorListItem['servicio']>> | null
  tarifa: DeudaAnteriorListItem['tarifa'] | Array<NonNullable<DeudaAnteriorListItem['tarifa']>> | null
}

const predioSelect =
  'id, nombre, numero, manzana, lote, calle:cat_calles(nombre), usuario:pad_usuarios(id, nombres, apellido_paterno, apellido_materno, dni, tipo_persona)'

function mapPredio(value: PredioRow | PredioRow[] | null | undefined): PredioDeudaOption | null {
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
  }
}

function num(value: number | string) {
  return Number(value)
}

export type TerritorioDeuda = {
  sectores: Array<{ id: string; nombre: string }>
  calles: Array<{ id: string; nombre: string; sector_id: string | null }>
}

export async function listTerritorioDeuda(): Promise<TerritorioDeuda> {
  const [sectores, calles] = await Promise.all([
    supabase.from('cat_sectores').select('id, nombre').eq('activo', true).order('nombre'),
    supabase.from('cat_calles').select('id, nombre, sector_id').order('nombre'),
  ])
  if (sectores.error) throw asDeudaError(sectores.error)
  if (calles.error) throw asDeudaError(calles.error)
  return { sectores: sectores.data ?? [], calles: calles.data ?? [] }
}

export async function searchPredios(
  search: string,
  page: number,
  pageSize: number,
  filtros: { sectorId?: string; calleId?: string } = {},
): Promise<PredioBusqueda> {
  const offset = Math.max(page - 1, 0) * pageSize
  const sectorId = filtros.sectorId && filtros.sectorId !== 'all' ? filtros.sectorId : null
  const calleId = filtros.calleId && filtros.calleId !== 'all' ? filtros.calleId : null
  const { data: match, error } = await supabase.rpc('buscar_predio_ids', {
    p_search: search.trim(),
    p_estado: 'activo',
    p_tipo_predio_id: null,
    p_sector_id: sectorId,
    p_calle_id: calleId,
    p_limit: pageSize,
    p_offset: offset,
  })
  if (error) throw asDeudaError(error)
  const ids = match?.ids ?? []
  const total = match?.total ?? 0
  if (ids.length === 0) return { items: [], total }

  const { data, error: listError } = await supabase.from('pad_predios').select(predioSelect).in('id', ids)
  if (listError) throw asDeudaError(listError)

  const byId = new Map<string, PredioDeudaOption>()
  for (const row of data ?? []) {
    const mapped = mapPredio(row)
    if (mapped) byId.set(mapped.id, mapped)
  }

  return {
    total,
    items: ids.map((id) => byId.get(id)).filter((row): row is PredioDeudaOption => row != null),
  }
}

export async function listTarifasAnio(): Promise<TarifaAnio[]> {
  const { data, error } = await supabase
    .from('cat_tarifas')
    .select('id, anio, nombre, activa')
    .order('anio', { ascending: false })
  if (error) throw asDeudaError(error)
  return data ?? []
}

export async function listCostosTarifa(): Promise<CostoTarifaOption[]> {
  const { data, error } = await supabase.from('cat_costos_tarifa').select(
    'id, tarifa_id, tipo_servicio_id, valor, monto, tarifa:cat_tarifas(id, anio, nombre), servicio:cat_tipos_servicio(id, codigo, nombre, categoria)',
  )
  if (error) throw asDeudaError(error)

  return ((data ?? []) as CostoRow[])
    .map((row) => {
      const tarifa = embedOne(row.tarifa)
      const servicio = embedOne(row.servicio)
      if (!tarifa || !servicio) return null
      return {
        id: row.id,
        tarifa_id: row.tarifa_id,
        tipo_servicio_id: row.tipo_servicio_id,
        anio: tarifa.anio,
        valor: num(row.valor),
        monto: num(row.monto),
        servicio_nombre: servicio.nombre,
        servicio_codigo: servicio.codigo,
        categoria: servicio.categoria,
      }
    })
    .filter((row): row is CostoTarifaOption => row != null)
    .sort((left, right) => right.anio - left.anio || left.servicio_nombre.localeCompare(right.servicio_nombre, 'es'))
}

export async function listDeudasAnteriores(predioId: string): Promise<DeudaAnteriorListItem[]> {
  const { data, error } = await supabase
    .from('fac_deudas_anteriores')
    .select(deudaSelect)
    .eq('predio_id', predioId)
    .order('anio', { ascending: false })
    .order('mes', { ascending: false })
  if (error) throw asDeudaError(error)

  return ((data ?? []) as DeudaRow[]).map(mapDeuda)
}

const deudaSelect =
  '*, servicio:cat_tipos_servicio(id, codigo, nombre, categoria), tarifa:cat_tarifas(id, anio, nombre)'

function mapDeuda(row: DeudaRow): DeudaAnteriorListItem {
  return {
    ...row,
    monto: num(row.monto),
    interes: num(row.interes),
    saldo: num(row.saldo),
    volumen: num(row.volumen),
    servicio: embedOne(row.servicio),
    tarifa: embedOne(row.tarifa),
  }
}

export async function saveDeudaAnterior(payload: DeudaAnteriorPayload): Promise<DeudaAnteriorListItem> {
  const [row] = await saveDeudasAnteriores([payload])
  if (!row) throw new Error('No se pudo registrar la deuda.')
  return row
}

export async function saveDeudasAnteriores(
  payloads: DeudaAnteriorPayload[],
): Promise<DeudaAnteriorListItem[]> {
  if (payloads.length === 0) return []
  const { data, error } = await supabase.from('fac_deudas_anteriores').insert(payloads).select(deudaSelect)
  if (error) throw asDeudaError(error)
  return ((data ?? []) as DeudaRow[]).map(mapDeuda)
}

export async function deleteDeudaAnterior(id: string): Promise<void> {
  const { error } = await supabase.from('fac_deudas_anteriores').delete().eq('id', id)
  if (error) throw asDeudaError(error)
}

function asObjectRows(value: Json | null): Array<Record<string, Json | undefined>> {
  if (!Array.isArray(value)) return []
  return value.filter(
    (row): row is Record<string, Json | undefined> =>
      row != null && typeof row === 'object' && !Array.isArray(row),
  )
}

function jsonText(value: Json | undefined) {
  return value == null ? '' : String(value)
}

export async function listPrediosDeudaFija(filtros: {
  anio: number
  mes: number
  tipoServicioId: string
  sectorId?: string
  calleId?: string
}): Promise<PredioDeudaFija[]> {
  const { data, error } = await supabase.rpc('listar_predios_deuda_fija', {
    p_anio: filtros.anio,
    p_mes: filtros.mes,
    p_tipo_servicio_id: filtros.tipoServicioId,
    p_sector_id: filtros.sectorId && filtros.sectorId !== 'all' ? filtros.sectorId : null,
    p_calle_id: filtros.calleId && filtros.calleId !== 'all' ? filtros.calleId : null,
  })
  if (error) throw asDeudaError(error)
  return asObjectRows(data).map((row) => ({
    predio_id: jsonText(row.predio_id),
    predio: jsonText(row.predio),
    numero: jsonText(row.numero),
    usuario: jsonText(row.usuario),
    sector: jsonText(row.sector),
    calle: jsonText(row.calle),
  }))
}

export interface ConvenioMedidorLista {
  servicioId: string
  servicio: string
  anio: number
  monto: number
  predios: PredioConvenio[]
}

export interface GenerarConvenioResultado {
  servicio: string
  monto: number
  cuotas: number
  cuota: number
  ultima: number
  predios: number
  generadas: number
}

export async function listPrediosConvenioMedidor(filtros: {
  anio: number
  sectorId?: string
  calleId?: string
  busqueda?: string
}): Promise<ConvenioMedidorLista> {
  const { data, error } = await supabase.rpc('listar_predios_convenio_medidor', {
    p_anio: filtros.anio,
    p_sector_id: filtros.sectorId && filtros.sectorId !== 'all' ? filtros.sectorId : null,
    p_calle_id: filtros.calleId && filtros.calleId !== 'all' ? filtros.calleId : null,
    p_busqueda: filtros.busqueda?.trim() ? filtros.busqueda.trim() : null,
  })
  if (error) throw asDeudaError(error)
  const payload = data && typeof data === 'object' && !Array.isArray(data) ? data : {}
  const predios = payload.predios
  return {
    servicioId: jsonText(payload.servicio_id),
    servicio: jsonText(payload.servicio),
    anio: Number(payload.anio) || filtros.anio,
    monto: Number(payload.monto) || 0,
    predios: asObjectRows(Array.isArray(predios) ? predios : []).map((row) => ({
      predio_id: jsonText(row.predio_id),
      predio: jsonText(row.predio),
      numero: jsonText(row.numero),
      usuario: jsonText(row.usuario),
      dni: jsonText(row.dni),
      ruc: jsonText(row.ruc),
      sector: jsonText(row.sector),
      calle: jsonText(row.calle),
    })),
  }
}

export async function generarConvenioMedidor(input: {
  fecha: string
  cuotas: number
  predioIds: string[]
}): Promise<GenerarConvenioResultado> {
  const { data, error } = await supabase.rpc('generar_convenio_medidor', {
    p_fecha: input.fecha,
    p_cuotas: input.cuotas,
    p_predio_ids: input.predioIds,
  })
  if (error) throw asDeudaError(error)
  const payload = data && typeof data === 'object' && !Array.isArray(data) ? data : {}
  return {
    servicio: jsonText(payload.servicio),
    monto: Number(payload.monto) || 0,
    cuotas: Number(payload.cuotas) || input.cuotas,
    cuota: Number(payload.cuota) || 0,
    ultima: Number(payload.ultima) || 0,
    predios: Number(payload.predios) || 0,
    generadas: Number(payload.generadas) || 0,
  }
}

export async function generarDeudasFijas(input: {
  anio: number
  mes: number
  tipoServicioId: string
  predioIds: string[]
}): Promise<GenerarDeudasFijasResultado> {
  const { data, error } = await supabase.rpc('generar_deudas_fijas', {
    p_anio: input.anio,
    p_mes: input.mes,
    p_tipo_servicio_id: input.tipoServicioId,
    p_predio_ids: input.predioIds,
  })
  if (error) throw asDeudaError(error)
  const payload = data && typeof data === 'object' && !Array.isArray(data) ? data : {}
  return {
    generadas: Number(payload.generadas) || 0,
    monto: Number(payload.monto) || 0,
    total: Number(payload.total) || 0,
  }
}
