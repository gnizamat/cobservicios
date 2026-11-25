import { useState } from 'react'
import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import {
  deleteDeudaAnterior,
  generarConvenioMedidor,
  generarDeudasFijas,
  listCostosTarifa,
  listDeudasAnteriores,
  listPrediosConvenioMedidor,
  listPrediosDeudaFija,
  listTarifasAnio,
  listTerritorioDeuda,
  saveDeudaAnterior,
  saveDeudasAnteriores,
  searchPredios,
} from '@/modules/deudas/api/deudas-api'
import { deudasQueryKeys } from '@/modules/deudas/api/query-keys'
import type { DeudaAnteriorPayload } from '@/modules/deudas/schemas'
import type { PredioDeudaOption } from '@/modules/deudas/types'

export function useTerritorioDeuda() {
  return useQuery({
    queryKey: deudasQueryKeys.territorio,
    queryFn: listTerritorioDeuda,
  })
}

export function usePagedPredios(search: string, sectorId = 'all', calleId = 'all') {
  const [page, setPage] = useState(1)
  const [pageSize, setPageSize] = useState(20)
  const [predioId, setPredioId] = useState<string | null>(null)
  const [pinned, setPinned] = useState<PredioDeudaOption | null>(null)
  const query = useQuery({
    queryKey: [...deudasQueryKeys.predios, search, sectorId, calleId, page, pageSize],
    queryFn: () => searchPredios(search, page, pageSize, { sectorId, calleId }),
  })
  const rows = query.data?.items ?? []
  const selected =
    (predioId
      ? (rows.find((row) => row.id === predioId) ?? (pinned?.id === predioId ? pinned : null))
      : null) ??
    rows[0] ??
    null

  return {
    query,
    rows,
    total: query.data?.total ?? 0,
    page,
    pageSize,
    setPage,
    changePageSize: (size: number) => {
      setPageSize(size)
      setPage(1)
    },
    resetPage: () => setPage(1),
    selected,
    select: (id: string) => {
      setPredioId(id)
      const row = rows.find((item) => item.id === id)
      if (row) setPinned(row)
    },
  }
}

export function useCatalogoTarifas() {
  return useQuery({
    queryKey: deudasQueryKeys.catalogo,
    queryFn: async () => {
      const [tarifas, costos] = await Promise.all([listTarifasAnio(), listCostosTarifa()])
      return { tarifas, costos }
    },
  })
}

export function useDeudasAnteriores(predioId: string | null) {
  return useQuery({
    queryKey: deudasQueryKeys.anteriores(predioId ?? 'none'),
    queryFn: () => listDeudasAnteriores(predioId ?? ''),
    enabled: Boolean(predioId),
  })
}

export function useSaveDeudaAnterior(predioId: string | null) {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (payload: DeudaAnteriorPayload) => saveDeudaAnterior(payload),
    onSuccess: async (row) => {
      await queryClient.invalidateQueries({
        queryKey: deudasQueryKeys.anteriores(predioId ?? row.predio_id),
      })
    },
  })
}

export function useSaveDeudasAnteriores(predioId: string | null) {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (payloads: DeudaAnteriorPayload[]) => saveDeudasAnteriores(payloads),
    onSuccess: async (rows) => {
      const id = predioId ?? rows[0]?.predio_id
      if (!id) return
      await queryClient.invalidateQueries({ queryKey: deudasQueryKeys.anteriores(id) })
    },
  })
}

export function usePrediosDeudaFija(filtros: {
  anio: number
  mes: number
  tipoServicioId: string
  sectorId: string
  calleId: string
}) {
  return useQuery({
    queryKey: deudasQueryKeys.mensuales(
      filtros.anio,
      filtros.mes,
      filtros.tipoServicioId,
      filtros.sectorId,
      filtros.calleId,
    ),
    queryFn: () => listPrediosDeudaFija(filtros),
    enabled: Boolean(filtros.tipoServicioId) && filtros.anio > 0 && filtros.mes >= 1 && filtros.mes <= 12,
  })
}

export function usePrediosConvenioMedidor(filtros: {
  anio: number
  sectorId: string
  calleId: string
  busqueda: string
}) {
  return useQuery({
    queryKey: deudasQueryKeys.convenios(filtros.anio, filtros.sectorId, filtros.calleId, filtros.busqueda),
    queryFn: () => listPrediosConvenioMedidor(filtros),
    enabled: filtros.anio > 1900,
  })
}

export function useGenerarConvenioMedidor() {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: generarConvenioMedidor,
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: ['deudas', 'convenios'] })
      await queryClient.invalidateQueries({ queryKey: ['deudas', 'anteriores'] })
    },
  })
}

export function useGenerarDeudasFijas() {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: generarDeudasFijas,
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: ['deudas', 'mensuales'] })
      await queryClient.invalidateQueries({ queryKey: ['deudas', 'anteriores'] })
    },
  })
}

export function useDeleteDeudaAnterior(predioId: string | null) {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (id: string) => deleteDeudaAnterior(id),
    onSuccess: async () => {
      if (!predioId) return
      await queryClient.invalidateQueries({ queryKey: deudasQueryKeys.anteriores(predioId) })
    },
  })
}
