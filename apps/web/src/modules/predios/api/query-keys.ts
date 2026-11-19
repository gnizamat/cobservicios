import type { PrediosListQuery } from '@/modules/predios/api/predios-api'

export const prediosQueryKeys = {
  all: ['predios'] as const,
  list: (query: PrediosListQuery = {}) =>
    [...prediosQueryKeys.all, 'list', query] as const,
  detail: (id: string) => [...prediosQueryKeys.all, 'detail', id] as const,
  catalogs: () => [...prediosQueryKeys.all, 'catalogs'] as const,
  usuariosTitular: (term: string) =>
    [...prediosQueryKeys.all, 'usuarios-titular', term] as const,
  usuarioTitular: (id: string) =>
    [...prediosQueryKeys.all, 'usuario-titular', id] as const,
}
