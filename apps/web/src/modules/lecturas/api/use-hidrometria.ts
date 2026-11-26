import { useState } from 'react'
import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import {
  deleteLectura,
  listControles,
  listEstructuras,
  listValoresVolumen,
  listLecturas,
  listLecturadores,
  listMarcasMedidor,
  listTerritorioLectura,
  listServicioOptions,
  listVolumenes,
  saveControl,
  saveLectura,
  saveMedidor,
  saveVolumen,
  searchPredios,
  type PredioOption,
} from '@/modules/lecturas/api/hidrometria-api'
import { lecturasQueryKeys } from '@/modules/lecturas/api/query-keys'
import type {
  ControlPayload,
  LecturaPayload,
  MedidorPayload,
  VolumenPayload,
} from '@/modules/lecturas/schemas'

function useHidrometriaSave<TPayload, TResult extends { id: string }>(
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

export function useTerritorioLectura() {
  return useQuery({
    queryKey: lecturasQueryKeys.territorio,
    queryFn: listTerritorioLectura,
  })
}

export function usePredioBusqueda(
  search: string,
  page: number,
  pageSize: number,
  sectorId = 'all',
  calleId = 'all',
) {
  return useQuery({
    queryKey: [...lecturasQueryKeys.predios, search, sectorId, calleId, page, pageSize],
    queryFn: () => searchPredios(search, page, pageSize, { sectorId, calleId }),
  })
}

export function usePagedPredios(search: string, sectorId = 'all', calleId = 'all') {
  const [page, setPage] = useState(1)
  const [pageSize, setPageSize] = useState(20)
  const [predioId, setPredioId] = useState<string | null>(null)
  const [pinned, setPinned] = useState<PredioOption | null>(null)
  const query = usePredioBusqueda(search, page, pageSize, sectorId, calleId)
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

export function useSaveMedidor() {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (input: { id: string | null; payload: MedidorPayload }) =>
      saveMedidor(input.id, input.payload),
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: lecturasQueryKeys.predios })
    },
  })
}

export function useLecturadores() {
  return useQuery({
    queryKey: lecturasQueryKeys.lecturadores,
    queryFn: listLecturadores,
  })
}

export function useMarcasMedidor() {
  return useQuery({
    queryKey: lecturasQueryKeys.marcas,
    queryFn: listMarcasMedidor,
  })
}

export function useServicioOptions() {
  return useQuery({
    queryKey: lecturasQueryKeys.servicios,
    queryFn: listServicioOptions,
  })
}

export function useValoresVolumen() {
  return useQuery({
    queryKey: lecturasQueryKeys.valorM3,
    queryFn: listValoresVolumen,
  })
}

export function useEstructuras() {
  return useQuery({
    queryKey: lecturasQueryKeys.estructuras,
    queryFn: listEstructuras,
  })
}

export function useLecturas() {
  return useQuery({
    queryKey: lecturasQueryKeys.lecturas,
    queryFn: listLecturas,
  })
}

export function useSaveLectura() {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (input: { id: string | null; payload: LecturaPayload }) =>
      saveLectura(input.id, input.payload),
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: lecturasQueryKeys.lecturas })
      await queryClient.invalidateQueries({ queryKey: ['deudas'] })
    },
  })
}

export function useDeleteLectura() {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (id: string) => deleteLectura(id),
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: lecturasQueryKeys.lecturas })
      await queryClient.invalidateQueries({ queryKey: ['deudas'] })
    },
  })
}

export function useVolumenes() {
  return useQuery({
    queryKey: lecturasQueryKeys.volumenes,
    queryFn: listVolumenes,
  })
}

export function useSaveVolumen() {
  return useHidrometriaSave<VolumenPayload, Awaited<ReturnType<typeof saveVolumen>>>(
    lecturasQueryKeys.volumenes,
    saveVolumen,
  )
}

export function useControles() {
  return useQuery({
    queryKey: lecturasQueryKeys.controles,
    queryFn: listControles,
  })
}

export function useSaveControl() {
  return useHidrometriaSave<ControlPayload, Awaited<ReturnType<typeof saveControl>>>(
    lecturasQueryKeys.controles,
    saveControl,
  )
}
