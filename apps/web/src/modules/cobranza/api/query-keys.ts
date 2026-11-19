export const cobranzaQueryKeys = {
  all: ['cobranza'] as const,
  territorio: ['cobranza', 'territorio'] as const,
  predios: (sectorId: string, calleId: string, search: string) =>
    ['cobranza', 'predios', sectorId, calleId, search] as const,
  facturas: (predioId: string) => ['cobranza', 'facturas', predioId] as const,
  recibo: (id: string) => ['cobranza', 'recibo', id] as const,
  cajas: ['cobranza', 'cajas'] as const,
  pagos: (sectorId: string, cajaId: string, desde: string, hasta: string, search: string) =>
    ['cobranza', 'pagos', sectorId, cajaId, desde, hasta, search] as const,
}
