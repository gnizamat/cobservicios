import type { PredioPayload } from '@/modules/predios/schemas'
import { supabase } from '@/shared/lib/supabase'
import type {
  CatCalle,
  CatSector,
  CatTipoPredio,
  PadPredio,
  PadUsuario,
} from '@/shared/types/database'
import {
  normalizeListQuery,
  sanitizeSearchTerm,
  type ListEstadoFilter,
  type PaginatedResult,
} from '@/shared/types/list'

export type PredioListItem = PadPredio & {
  usuario: Pick<
    PadUsuario,
    'id' | 'nombres' | 'apellido_paterno' | 'apellido_materno' | 'tipo_persona' | 'dni' | 'ruc'
  > | null
  sector: Pick<CatSector, 'id' | 'nombre'> | null
  calle: Pick<CatCalle, 'id' | 'nombre'> | null
  tipo_predio: Pick<CatTipoPredio, 'id' | 'nombre'> | null
}

export interface PrediosListQuery {
  search?: string
  estado?: ListEstadoFilter
  tipoPredioId?: string | 'all'
  sectorId?: string | 'all'
  calleId?: string | 'all'
  page?: number
  pageSize?: number
}

const PREDIO_LIST_SELECT = `
  *,
  usuario:pad_usuarios ( id, nombres, apellido_paterno, apellido_materno, tipo_persona, dni, ruc ),
  sector:cat_sectores ( id, nombre ),
  calle:cat_calles ( id, nombre ),
  tipo_predio:cat_tipos_predio ( id, nombre )
`

export async function listPredios(
  params: PrediosListQuery | string = {},
): Promise<PaginatedResult<PredioListItem>> {
  const queryInput = typeof params === 'string' ? { search: params } : params
  const { page, pageSize, search, estado, from, to } = normalizeListQuery(queryInput)
  const tipoPredioId = queryInput.tipoPredioId ?? 'all'
  const sectorId = queryInput.sectorId ?? 'all'
  const calleId = queryInput.calleId ?? 'all'
  const term = sanitizeSearchTerm(search)

  if (term) {
    const { data: match, error: matchError } = await supabase.rpc('buscar_predio_ids', {
      p_search: term,
      p_estado: estado === 'all' ? null : estado,
      p_tipo_predio_id: tipoPredioId === 'all' ? null : tipoPredioId,
      p_sector_id: sectorId === 'all' ? null : sectorId,
      p_calle_id: calleId === 'all' ? null : calleId,
      p_limit: pageSize,
      p_offset: from,
    })
    if (matchError) throw matchError

    const ids = match?.ids ?? []
    const total = match?.total ?? 0
    if (ids.length === 0) {
      return { items: [], total, page, pageSize }
    }

    const { data, error } = await supabase
      .from('pad_predios')
      .select(PREDIO_LIST_SELECT)
      .in('id', ids)
      .order('nombre', { ascending: true })
    if (error) throw error

    return {
      items: (data ?? []) as PredioListItem[],
      total,
      page,
      pageSize,
    }
  }

  let query = supabase
    .from('pad_predios')
    .select(PREDIO_LIST_SELECT, { count: 'exact' })
    .order('nombre', { ascending: true })
    .range(from, to)

  if (estado !== 'all') {
    query = query.eq('estado', estado)
  }

  if (tipoPredioId !== 'all') {
    query = query.eq('tipo_predio_id', tipoPredioId)
  }

  if (sectorId !== 'all') {
    query = query.eq('sector_id', sectorId)
  }

  if (calleId !== 'all') {
    query = query.eq('calle_id', calleId)
  }

  const { data, error, count } = await query
  if (error) throw error

  return {
    items: (data ?? []) as PredioListItem[],
    total: count ?? 0,
    page,
    pageSize,
  }
}

export async function getPredio(id: string): Promise<PadPredio> {
  const { data, error } = await supabase
    .from('pad_predios')
    .select('*')
    .eq('id', id)
    .single()
  if (error) throw error
  return data
}

export async function createPredio(payload: PredioPayload): Promise<PadPredio> {
  const { data, error } = await supabase
    .from('pad_predios')
    .insert(payload)
    .select('*')
    .single()
  if (error) throw error
  return data
}

export async function updatePredio(
  id: string,
  payload: PredioPayload,
): Promise<PadPredio> {
  const { data, error } = await supabase
    .from('pad_predios')
    .update(payload)
    .eq('id', id)
    .select('*')
    .single()
  if (error) throw error
  return data
}

const USUARIO_TITULAR_FIELDS =
  'id, tipo_persona, nombres, apellido_paterno, apellido_materno, dni, ruc'

export type UsuarioTitular = Pick<
  PadUsuario,
  'id' | 'tipo_persona' | 'nombres' | 'apellido_paterno' | 'apellido_materno' | 'dni' | 'ruc'
>

export async function searchUsuariosTitular(term: string): Promise<UsuarioTitular[]> {
  const tokens = sanitizeSearchTerm(term).split(' ').filter(Boolean)
  let query = supabase
    .from('pad_usuarios')
    .select(USUARIO_TITULAR_FIELDS)
    .eq('estado', 'activo')
    .order('apellido_paterno', { ascending: true })
    .order('apellido_materno', { ascending: true })
    .order('nombres', { ascending: true })
    .limit(15)

  for (const token of tokens) {
    query = query.or(
      `nombres.ilike.%${token}%,apellido_paterno.ilike.%${token}%,apellido_materno.ilike.%${token}%,dni.ilike.%${token}%`,
    )
  }

  const { data, error } = await query
  if (error) throw error
  return data ?? []
}

export async function getUsuarioTitular(id: string): Promise<UsuarioTitular | null> {
  const { data, error } = await supabase
    .from('pad_usuarios')
    .select(USUARIO_TITULAR_FIELDS)
    .eq('id', id)
    .maybeSingle()
  if (error) throw error
  return data
}

export async function listPredioCatalogs() {
  const [sectores, calles, tipos] = await Promise.all([
    supabase.from('cat_sectores').select('*').eq('activo', true).order('nombre'),
    supabase.from('cat_calles').select('*').order('nombre'),
    supabase.from('cat_tipos_predio').select('*').order('nombre'),
  ])

  if (sectores.error) throw sectores.error
  if (calles.error) throw calles.error
  if (tipos.error) throw tipos.error

  return {
    sectores: sectores.data ?? [],
    calles: calles.data ?? [],
    tipos: tipos.data ?? [],
  }
}
