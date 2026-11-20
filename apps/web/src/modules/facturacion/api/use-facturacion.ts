import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import {
  eliminarFacturacion,
  generarFacturacion,
  getRecibo,
  listDeudasAFacturar,
  listFacturacionesGeneradas,
  listTarifasFacturacion,
  listTerritorioFacturacion,
} from '@/modules/facturacion/api/facturacion-api'
import { facturacionQueryKeys } from '@/modules/facturacion/api/query-keys'
import type { FiltroFacturacion } from '@/modules/facturacion/api/facturacion-api'

export function useTerritorioFacturacion() {
  return useQuery({
    queryKey: facturacionQueryKeys.territorio,
    queryFn: listTerritorioFacturacion,
  })
}

export function useTarifasFacturacion() {
  return useQuery({
    queryKey: facturacionQueryKeys.tarifas,
    queryFn: listTarifasFacturacion,
  })
}

export function useDeudasAFacturar(filtros: FiltroFacturacion) {
  return useQuery({
    queryKey: facturacionQueryKeys.pendientes(
      filtros.anio,
      filtros.mes,
      filtros.sectorId ?? 'all',
      filtros.calleId ?? 'all',
    ),
    queryFn: () => listDeudasAFacturar(filtros),
    enabled: filtros.anio > 0 && filtros.mes >= 1 && filtros.mes <= 12,
  })
}

export function useFacturacionesGeneradas(filtros: FiltroFacturacion) {
  return useQuery({
    queryKey: facturacionQueryKeys.generadas(
      filtros.anio,
      filtros.mes,
      filtros.sectorId ?? 'all',
      filtros.calleId ?? 'all',
    ),
    queryFn: () => listFacturacionesGeneradas(filtros),
    enabled: filtros.anio > 0 && filtros.mes >= 1 && filtros.mes <= 12,
  })
}

export function useRecibo(id: string | null) {
  return useQuery({
    queryKey: facturacionQueryKeys.recibo(id ?? 'none'),
    queryFn: () => getRecibo(id ?? ''),
    enabled: Boolean(id),
  })
}

export function useEliminarFacturacion() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: eliminarFacturacion,
    onSuccess: () => {
      void client.invalidateQueries({ queryKey: ['facturacion', 'pendientes'] })
      void client.invalidateQueries({ queryKey: ['facturacion', 'generadas'] })
    },
  })
}

export function useGenerarFacturacion() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: ({ anio, mes, predioIds }: { anio: number; mes: number; predioIds: string[] }) =>
      generarFacturacion(anio, mes, predioIds),
    onSuccess: () => {
      void client.invalidateQueries({ queryKey: ['facturacion', 'pendientes'] })
      void client.invalidateQueries({ queryKey: ['facturacion', 'generadas'] })
    },
  })
}
