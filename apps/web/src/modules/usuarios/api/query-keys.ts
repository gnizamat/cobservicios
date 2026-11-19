import type { UsuariosListQuery } from '@/modules/usuarios/api/usuarios-api'

export const usuariosQueryKeys = {
  all: ['usuarios'] as const,
  list: (query: UsuariosListQuery = {}) =>
    [...usuariosQueryKeys.all, 'list', query] as const,
  detail: (id: string) => [...usuariosQueryKeys.all, 'detail', id] as const,
  ficha: (id: string) => [...usuariosQueryKeys.all, 'ficha', id] as const,
}
