import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import {
  listCalles,
  listCostos,
  listHistorialCostos,
  listSectores,
  listServicios,
  listTarifas,
  saveCalle,
  saveCosto,
  saveSector,
  saveServicio,
  saveTarifa,
} from '@/modules/catalogo/api/catalogo-api'
import { catalogoQueryKeys } from '@/modules/catalogo/api/query-keys'
import type {
  CallePayload,
  CostoPayload,
  SectorPayload,
  ServicioPayload,
  TarifaPayload,
} from '@/modules/catalogo/schemas'

function useCatalogSave<TPayload, TResult extends { id: string }>(
  key: readonly string[],
  save: (id: string | null, payload: TPayload) => Promise<TResult>,
) {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (input: { id: string | null; payload: TPayload }) =>
      save(input.id, input.payload),
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: key })
    },
  })
}

export function useSectores() {
  return useQuery({
    queryKey: catalogoQueryKeys.sectores,
    queryFn: listSectores,
  })
}

export function useSaveSector() {
  return useCatalogSave<SectorPayload, Awaited<ReturnType<typeof saveSector>>>(
    catalogoQueryKeys.sectores,
    saveSector,
  )
}

export function useCalles() {
  return useQuery({
    queryKey: catalogoQueryKeys.calles,
    queryFn: listCalles,
  })
}

export function useSaveCalle() {
  return useCatalogSave<CallePayload, Awaited<ReturnType<typeof saveCalle>>>(
    catalogoQueryKeys.calles,
    saveCalle,
  )
}

export function useServicios() {
  return useQuery({
    queryKey: catalogoQueryKeys.servicios,
    queryFn: listServicios,
  })
}

export function useSaveServicio() {
  return useCatalogSave<ServicioPayload, Awaited<ReturnType<typeof saveServicio>>>(
    catalogoQueryKeys.servicios,
    saveServicio,
  )
}

export function useTarifas() {
  return useQuery({
    queryKey: catalogoQueryKeys.tarifas,
    queryFn: listTarifas,
  })
}

export function useSaveTarifa() {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (input: { id: string | null; payload: TarifaPayload }) =>
      saveTarifa(input.id, input.payload),
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: catalogoQueryKeys.tarifas })
      await queryClient.invalidateQueries({ queryKey: catalogoQueryKeys.costos })
    },
  })
}

export function useCostos() {
  return useQuery({
    queryKey: catalogoQueryKeys.costos,
    queryFn: listCostos,
  })
}

export function useSaveCosto() {
  return useCatalogSave<CostoPayload, Awaited<ReturnType<typeof saveCosto>>>(
    catalogoQueryKeys.costos,
    saveCosto,
  )
}

export function useHistorialCostos(costoId?: string | null) {
  return useQuery({
    queryKey: catalogoQueryKeys.historialCostos(costoId ?? ''),
    queryFn: () => listHistorialCostos(costoId!),
    enabled: Boolean(costoId),
  })
}
