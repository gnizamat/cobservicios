import type { UsuarioPayload } from '@/modules/usuarios/schemas'
import { supabase } from '@/shared/lib/supabase'
import type { PadUsuario } from '@/shared/types/database'
import {
  normalizeListQuery,
  sanitizeSearchTerm,
  type ListEstadoFilter,
  type PaginatedResult,
} from '@/shared/types/list'

export type UsuarioTipoFilter = 'all' | 'natural' | 'juridica' | 'institucional'

export interface UsuariosListQuery {
  search?: string
  estado?: ListEstadoFilter
  tipoPersona?: UsuarioTipoFilter
  page?: number
  pageSize?: number
}

export async function listUsuarios(
  params: UsuariosListQuery | string = {},
): Promise<PaginatedResult<PadUsuario>> {
  const queryInput =
    typeof params === 'string' ? { search: params } : params
  const { page, pageSize, search, estado, from, to } = normalizeListQuery(queryInput)
  const tipoPersona = queryInput.tipoPersona ?? 'all'
  const term = sanitizeSearchTerm(search)

  let query = supabase
    .from('pad_usuarios_centro_activo')
    .select('*', { count: 'exact' })
    .order('apellido_paterno', { ascending: true })
    .order('nombres', { ascending: true })
    .range(from, to)

  if (term) {
    query = query.or(
      `nombres.ilike.%${term}%,apellido_paterno.ilike.%${term}%,apellido_materno.ilike.%${term}%,dni.ilike.%${term}%,ruc.ilike.%${term}%,celular.ilike.%${term}%,email.ilike.%${term}%`,
    )
  }

  if (estado !== 'all') {
    query = query.eq('estado', estado)
  }

  if (tipoPersona !== 'all') {
    query = query.eq('tipo_persona', tipoPersona)
  }

  const { data, error, count } = await query
  if (error) throw error

  return {
    items: data ?? [],
    total: count ?? 0,
    page,
    pageSize,
  }
}

export async function getUsuario(id: string): Promise<PadUsuario> {
  const { data, error } = await supabase
    .from('pad_usuarios')
    .select('*')
    .eq('id', id)
    .single()
  if (error) throw error
  return data
}

export async function createUsuario(payload: UsuarioPayload): Promise<PadUsuario> {
  const { data, error } = await supabase
    .from('pad_usuarios')
    .insert(payload)
    .select('*')
    .single()
  if (error) throw error
  return data
}

export async function updateUsuario(
  id: string,
  payload: UsuarioPayload,
): Promise<PadUsuario> {
  const { data, error } = await supabase
    .from('pad_usuarios')
    .update(payload)
    .eq('id', id)
    .select('*')
    .single()
  if (error) throw error
  return data
}
