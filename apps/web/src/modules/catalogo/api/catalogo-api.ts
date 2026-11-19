import { asCatalogError, embedOne } from '@/modules/catalogo/api/errors'
import type {
  CallePayload,
  CostoPayload,
  SectorPayload,
  ServicioPayload,
  TarifaPayload,
} from '@/modules/catalogo/schemas'
import { supabase } from '@/shared/lib/supabase'
import type {
  CatCalle,
  CatCostoTarifa,
  CatCostoTarifaHistorial,
  CatSector,
  CatTarifa,
  CatTipoServicio,
  CategoriaServicio,
} from '@/shared/types/database'

export type CalleListItem = CatCalle & {
  sector: Pick<CatSector, 'id' | 'codigo' | 'nombre'> | null
}

export type CostoListItem = CatCostoTarifa & {
  tarifa: Pick<CatTarifa, 'id' | 'anio' | 'nombre' | 'activa'> | null
  servicio: Pick<CatTipoServicio, 'id' | 'codigo' | 'nombre' | 'categoria'> | null
}

export async function listSectores(): Promise<CatSector[]> {
  const { data, error } = await supabase
    .from('cat_sectores')
    .select('*')
    .order('codigo', { ascending: true })
  if (error) throw asCatalogError(error)
  return data ?? []
}

export async function saveSector(
  id: string | null,
  payload: SectorPayload,
): Promise<CatSector> {
  const query = id
    ? supabase.from('cat_sectores').update(payload).eq('id', id)
    : supabase.from('cat_sectores').insert(payload)
  const { data, error } = await query.select('*').single()
  if (error) throw asCatalogError(error)
  return data
}

export async function listCalles(): Promise<CalleListItem[]> {
  const { data, error } = await supabase
    .from('cat_calles')
    .select('*, sector:cat_sectores ( id, codigo, nombre )')
    .order('nombre', { ascending: true })
  if (error) throw asCatalogError(error)
  return (data ?? []).map((row) => ({
    ...row,
    sector: embedOne(row.sector),
  }))
}

export async function saveCalle(
  id: string | null,
  payload: CallePayload,
): Promise<CatCalle> {
  const query = id
    ? supabase.from('cat_calles').update(payload).eq('id', id)
    : supabase.from('cat_calles').insert(payload)
  const { data, error } = await query.select('*').single()
  if (error) throw asCatalogError(error)
  return data
}

export async function listServicios(): Promise<CatTipoServicio[]> {
  const { data, error } = await supabase
    .from('cat_tipos_servicio')
    .select('*')
    .order('codigo', { ascending: true })
  if (error) throw asCatalogError(error)
  return data ?? []
}

export async function saveServicio(
  id: string | null,
  payload: ServicioPayload,
): Promise<CatTipoServicio> {
  const query = id
    ? supabase.from('cat_tipos_servicio').update(payload).eq('id', id)
    : supabase.from('cat_tipos_servicio').insert(payload)
  const { data, error } = await query.select('*').single()
  if (error) throw asCatalogError(error)
  return data
}

export async function listTarifas(): Promise<CatTarifa[]> {
  const { data, error } = await supabase
    .from('cat_tarifas')
    .select('*')
    .order('anio', { ascending: false })
  if (error) throw asCatalogError(error)
  return data ?? []
}

export async function saveTarifa(
  id: string | null,
  payload: TarifaPayload,
): Promise<CatTarifa> {
  if (payload.activa) {
    let clear = supabase.from('cat_tarifas').update({ activa: false }).eq('activa', true)
    if (id) clear = clear.neq('id', id)
    const { error: clearError } = await clear
    if (clearError) throw asCatalogError(clearError)
  }

  const query = id
    ? supabase.from('cat_tarifas').update(payload).eq('id', id)
    : supabase.from('cat_tarifas').insert(payload)
  const { data, error } = await query.select('*').single()
  if (error) throw asCatalogError(error)
  return data
}

export async function listCostos(): Promise<CostoListItem[]> {
  const { data, error } = await supabase
    .from('cat_costos_tarifa')
    .select(
      '*, tarifa:cat_tarifas ( id, anio, nombre, activa ), servicio:cat_tipos_servicio ( id, codigo, nombre, categoria )',
    )
    .order('created_at', { ascending: true })
  if (error) throw asCatalogError(error)
  return (data ?? []).map((row) => ({
    ...row,
    valor: Number(row.valor),
    monto: Number(row.monto),
    tarifa: embedOne(row.tarifa),
    servicio: embedOne(row.servicio),
  }))
}

export async function listHistorialCostos(
  costoId: string,
): Promise<CatCostoTarifaHistorial[]> {
  const { data, error } = await supabase
    .from('cat_costos_tarifa_historial')
    .select('*')
    .eq('costo_id', costoId)
    .order('created_at', { ascending: false })
  if (error) throw asCatalogError(error)
  return (data ?? []).map((row) => ({
    ...row,
    monto_anterior: Number(row.monto_anterior),
    monto_nuevo: Number(row.monto_nuevo),
    valor_anterior: Number(row.valor_anterior),
    valor_nuevo: Number(row.valor_nuevo),
  }))
}

export async function saveCosto(
  id: string | null,
  payload: CostoPayload,
): Promise<CatCostoTarifa> {
  const query = id
    ? supabase.from('cat_costos_tarifa').update(payload).eq('id', id)
    : supabase.from('cat_costos_tarifa').insert(payload)
  const { data, error } = await query.select('*').single()
  if (error) throw asCatalogError(error)
  return data
}

export function categoriaServicioLabel(categoria: CategoriaServicio | string) {
  switch (categoria) {
    case 'fijo':
      return 'Fijo'
    case 'unico':
      return 'Único'
    case 'volumen':
      return 'Volumen'
    case 'alcantarillado':
      return 'Alcantarillado'
    case 'medidor':
      return 'Medidor'
    default:
      return categoria
  }
}
