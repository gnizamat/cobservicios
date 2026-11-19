export const catalogoQueryKeys = {
  all: ['catalogo'] as const,
  sectores: ['catalogo', 'sectores'] as const,
  calles: ['catalogo', 'calles'] as const,
  servicios: ['catalogo', 'servicios'] as const,
  tarifas: ['catalogo', 'tarifas'] as const,
  costos: ['catalogo', 'costos'] as const,
  historialCostos: (costoId: string) =>
    ['catalogo', 'costos', 'historial', costoId] as const,
}
