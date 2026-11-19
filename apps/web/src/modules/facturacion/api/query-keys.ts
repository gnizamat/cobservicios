export const facturacionQueryKeys = {
  territorio: ['facturacion', 'territorio'] as const,
  tarifas: ['facturacion', 'tarifas'] as const,
  pendientes: (anio: number, mes: number, sectorId: string, calleId: string) =>
    ['facturacion', 'pendientes', anio, mes, sectorId, calleId] as const,
  generadas: (anio: number, mes: number, sectorId: string, calleId: string) =>
    ['facturacion', 'generadas', anio, mes, sectorId, calleId] as const,
  recibo: (id: string) => ['facturacion', 'recibo', id] as const,
}
