export type ListEstadoFilter = 'all' | 'activo' | 'inactivo'

export interface PaginatedResult<T> {
  items: T[]
  total: number
  page: number
  pageSize: number
}

export interface ListQueryBase {
  search?: string
  estado?: ListEstadoFilter
  page?: number
  pageSize?: number
}

export function normalizeListQuery(query: ListQueryBase = {}) {
  const page = Math.max(1, query.page ?? 1)
  const pageSize = Math.min(100, Math.max(5, query.pageSize ?? 20))
  const search = (query.search ?? '').trim()
  const estado = query.estado ?? 'all'
  return { page, pageSize, search, estado, from: (page - 1) * pageSize, to: page * pageSize - 1 }
}

/** Evita romper filtros PostgREST `.or()` / `.ilike`. */
export function sanitizeSearchTerm(term: string) {
  return term.replace(/[%_,.()]/g, ' ').replace(/\s+/g, ' ').trim()
}
