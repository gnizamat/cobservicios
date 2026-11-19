import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import type { PadronItem } from '@/modules/asambleas/api/asambleas-api'
import {
  deleteAsamblea,
  generarPadron,
  listAsambleas,
  listPadron,
  listSectoresAsamblea,
  marcarAsistencia,
  saveAsamblea,
  setEstadoAsamblea,
  type AsambleaInput,
} from '@/modules/asambleas/api/asambleas-api'
import type { EstadoRegistro } from '@/shared/types/database'

export const asambleasQueryKeys = {
  sectores: ['asambleas', 'sectores'] as const,
  lista: ['asambleas', 'lista'] as const,
  padron: (id: string) => ['asambleas', 'padron', id] as const,
}

export function useSectoresAsamblea() {
  return useQuery({
    queryKey: asambleasQueryKeys.sectores,
    queryFn: listSectoresAsamblea,
  })
}

export function useAsambleas() {
  return useQuery({
    queryKey: asambleasQueryKeys.lista,
    queryFn: listAsambleas,
  })
}

export function useSaveAsamblea() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: ({ id, input }: { id: string | null; input: AsambleaInput }) =>
      saveAsamblea(id, input),
    onSuccess: () => client.invalidateQueries({ queryKey: asambleasQueryKeys.lista }),
  })
}

export function useEstadoAsamblea() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: ({ id, estado }: { id: string; estado: EstadoRegistro }) =>
      setEstadoAsamblea(id, estado),
    onSuccess: () => client.invalidateQueries({ queryKey: asambleasQueryKeys.lista }),
  })
}

export function useDeleteAsamblea() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: deleteAsamblea,
    onSuccess: () => client.invalidateQueries({ queryKey: asambleasQueryKeys.lista }),
  })
}

export function usePadron(asambleaId: string | null) {
  return useQuery({
    queryKey: asambleasQueryKeys.padron(asambleaId ?? 'none'),
    queryFn: () => listPadron(asambleaId as string),
    enabled: Boolean(asambleaId),
  })
}

export function useMarcarAsistencia(asambleaId: string | null) {
  const client = useQueryClient()
  return useMutation({
    mutationFn: ({ id, asistencia }: { id: string; asistencia: boolean }) =>
      marcarAsistencia(id, asistencia),
    onMutate: async (variables) => {
      if (!asambleaId) return { prev: undefined }
      const key = asambleasQueryKeys.padron(asambleaId)
      await client.cancelQueries({ queryKey: key })
      const prev = client.getQueryData<PadronItem[]>(key)
      client.setQueryData<PadronItem[]>(key, (rows) =>
        (rows ?? []).map((row) =>
          row.id === variables.id ? { ...row, asistencia: variables.asistencia } : row,
        ),
      )
      return { prev }
    },
    onError: (_error, _variables, context) => {
      if (!asambleaId || !context?.prev) return
      client.setQueryData(asambleasQueryKeys.padron(asambleaId), context.prev)
    },
  })
}

export function useGenerarPadron() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: generarPadron,
    onSuccess: (_total, asambleaId) => {
      client.invalidateQueries({ queryKey: asambleasQueryKeys.padron(asambleaId) })
      client.invalidateQueries({ queryKey: asambleasQueryKeys.lista })
    },
  })
}
