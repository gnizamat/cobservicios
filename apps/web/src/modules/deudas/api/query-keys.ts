export const deudasQueryKeys = {
  predios: ['deudas', 'predios'] as const,
  territorio: ['deudas', 'territorio'] as const,
  catalogo: ['deudas', 'catalogo-tarifas'] as const,
  anteriores: (predioId: string) => ['deudas', 'anteriores', predioId] as const,
  mensuales: (anio: number, mes: number, servicioId: string, sectorId: string, calleId: string) =>
    ['deudas', 'mensuales', anio, mes, servicioId, sectorId, calleId] as const,
}
