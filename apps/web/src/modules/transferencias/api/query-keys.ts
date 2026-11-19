export interface TransferenciasListQuery {
  search: string
  page: number
  pageSize: number
}

export const transferenciasQueryKeys = {
  all: ['transferencias'] as const,
  usuarios: (term: string) =>
    [...transferenciasQueryKeys.all, 'usuarios', term] as const,
  prediosDeUsuario: (usuarioId: string) =>
    [...transferenciasQueryKeys.all, 'predios', usuarioId] as const,
  historialPredio: (predioId: string) =>
    [...transferenciasQueryKeys.all, 'historial-predio', predioId] as const,
  list: (query: TransferenciasListQuery) =>
    [...transferenciasQueryKeys.all, 'list', query] as const,
}
