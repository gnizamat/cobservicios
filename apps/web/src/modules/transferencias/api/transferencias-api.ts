import type { TransferenciaFormValues } from '@/modules/transferencias/schemas'
import type {
  PredioDeUsuario,
  PredioHistorialItem,
  TransferenciaListItem,
  UsuarioResumen,
} from '@/modules/transferencias/types'
import { supabase } from '@/shared/lib/supabase'
import {
  normalizeListQuery,
  sanitizeSearchTerm,
  type PaginatedResult,
} from '@/shared/types/list'

const USUARIO_FIELDS =
  'id, tipo_persona, nombres, apellido_paterno, apellido_materno, dni, ruc'

export async function searchUsuariosActivos(term: string): Promise<UsuarioResumen[]> {
  const clean = sanitizeSearchTerm(term)
  let query = supabase
    .from('pad_usuarios')
    .select(USUARIO_FIELDS)
    .eq('estado', 'activo')
    .order('apellido_paterno', { ascending: true })
    .order('nombres', { ascending: true })
    .limit(12)

  if (clean) {
    query = query.or(
      `nombres.ilike.%${clean}%,apellido_paterno.ilike.%${clean}%,apellido_materno.ilike.%${clean}%,dni.ilike.%${clean}%,ruc.ilike.%${clean}%`,
    )
  }

  const { data, error } = await query
  if (error) throw error
  return (data ?? []) as UsuarioResumen[]
}

type PredioRow = {
  id: string
  nombre: string
  numero: string
  manzana: string
  lote: string
  calle: { nombre: string } | null
}

export async function listPrediosDeUsuario(usuarioId: string): Promise<PredioDeUsuario[]> {
  const { data, error } = await supabase
    .from('pad_predios')
    .select('id, nombre, numero, manzana, lote, calle:cat_calles ( nombre )')
    .eq('usuario_id', usuarioId)
    .eq('estado', 'activo')
    .order('nombre', { ascending: true })

  if (error) throw error

  return ((data ?? []) as PredioRow[]).map((row) => ({
    id: row.id,
    nombre: row.nombre,
    numero: row.numero,
    manzana: row.manzana,
    lote: row.lote,
    calle_nombre: row.calle?.nombre ?? '',
  }))
}

export async function listHistorialPredio(predioId: string): Promise<PredioHistorialItem[]> {
  const { data, error } = await supabase
    .from('pad_predio_historial')
    .select(
      `
      id, predio_id, usuario_id, transferencia_id, referencia, vigente, desde, hasta,
      nombre_predio, numero, manzana, lote, calle_nombre,
      usuario:pad_usuarios ( ${USUARIO_FIELDS} )
    `,
    )
    .eq('predio_id', predioId)
    .order('desde', { ascending: false })

  if (error) throw error
  return (data ?? []) as PredioHistorialItem[]
}

const TRANSFERENCIA_SELECT = `
  id, referencia, created_at,
  origen:pad_usuarios!pad_transferencias_usuario_origen_id_fkey ( ${USUARIO_FIELDS} ),
  destino:pad_usuarios!pad_transferencias_usuario_destino_id_fkey ( ${USUARIO_FIELDS} ),
  predios:pad_predio_historial (
    id, predio_id, nombre_predio, numero, manzana, lote, calle_nombre
  )
`

async function findTransferenciaIds(term: string): Promise<string[]> {
  const pattern = `%${term}%`
  const [porReferencia, porPredio, porUsuario] = await Promise.all([
    supabase.from('pad_transferencias').select('id').ilike('referencia', pattern).limit(200),
    supabase
      .from('pad_predio_historial')
      .select('transferencia_id')
      .ilike('nombre_predio', pattern)
      .not('transferencia_id', 'is', null)
      .limit(200),
    supabase
      .from('pad_usuarios')
      .select('id')
      .or(
        `nombres.ilike.${pattern},apellido_paterno.ilike.${pattern},apellido_materno.ilike.${pattern},dni.ilike.${pattern},ruc.ilike.${pattern}`,
      )
      .limit(40),
  ])

  if (porReferencia.error) throw porReferencia.error
  if (porPredio.error) throw porPredio.error
  if (porUsuario.error) throw porUsuario.error

  const ids = new Set<string>()
  for (const row of porReferencia.data ?? []) ids.add(row.id)
  for (const row of porPredio.data ?? []) {
    if (row.transferencia_id) ids.add(row.transferencia_id)
  }

  const userIds = (porUsuario.data ?? []).map((row) => row.id)
  if (userIds.length > 0) {
    const lista = userIds.join(',')
    const { data, error } = await supabase
      .from('pad_transferencias')
      .select('id')
      .or(`usuario_origen_id.in.(${lista}),usuario_destino_id.in.(${lista})`)
      .limit(200)
    if (error) throw error
    for (const row of data ?? []) ids.add(row.id)
  }

  return [...ids]
}

export async function listTransferencias(params: {
  search?: string
  page?: number
  pageSize?: number
}): Promise<PaginatedResult<TransferenciaListItem>> {
  const { page, pageSize, search, from, to } = normalizeListQuery(params)
  const term = sanitizeSearchTerm(search)

  if (term) {
    const ids = await findTransferenciaIds(term)
    if (ids.length === 0) {
      return { items: [], total: 0, page, pageSize }
    }

    const { data, error, count } = await supabase
      .from('pad_transferencias')
      .select(TRANSFERENCIA_SELECT, { count: 'exact' })
      .in('id', ids)
      .order('created_at', { ascending: false })
      .range(from, to)

    if (error) throw error
    return {
      items: (data ?? []) as TransferenciaListItem[],
      total: count ?? 0,
      page,
      pageSize,
    }
  }

  const { data, error, count } = await supabase
    .from('pad_transferencias')
    .select(TRANSFERENCIA_SELECT, { count: 'exact' })
    .order('created_at', { ascending: false })
    .range(from, to)

  if (error) throw error
  return {
    items: (data ?? []) as TransferenciaListItem[],
    total: count ?? 0,
    page,
    pageSize,
  }
}

export async function registrarTransferencia(
  input: TransferenciaFormValues,
): Promise<string> {
  const { data, error } = await supabase.rpc('registrar_transferencia_predios', {
    p_usuario_origen_id: input.usuario_origen_id,
    p_usuario_destino_id: input.usuario_destino_id,
    p_referencia: input.referencia,
    p_predio_ids: input.predio_ids,
  })
  if (error) throw error
  return data
}
