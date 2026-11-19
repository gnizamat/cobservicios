import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import {
  listHistorialPredio,
  listPrediosDeUsuario,
  listTransferencias,
  registrarTransferencia,
  searchUsuariosActivos,
} from '@/modules/transferencias/api/transferencias-api'
import {
  transferenciasQueryKeys,
  type TransferenciasListQuery,
} from '@/modules/transferencias/api/query-keys'
import type { TransferenciaFormValues } from '@/modules/transferencias/schemas'

export function useUsuariosActivos(term: string, enabled: boolean) {
  return useQuery({
    queryKey: transferenciasQueryKeys.usuarios(term),
    queryFn: () => searchUsuariosActivos(term),
    enabled,
  })
}

export function usePrediosDeUsuario(usuarioId?: string) {
  return useQuery({
    queryKey: transferenciasQueryKeys.prediosDeUsuario(usuarioId ?? ''),
    queryFn: () => listPrediosDeUsuario(usuarioId!),
    enabled: Boolean(usuarioId),
  })
}

export function useHistorialPredio(predioId?: string) {
  return useQuery({
    queryKey: transferenciasQueryKeys.historialPredio(predioId ?? ''),
    queryFn: () => listHistorialPredio(predioId!),
    enabled: Boolean(predioId),
  })
}

export function useTransferencias(query: TransferenciasListQuery) {
  return useQuery({
    queryKey: transferenciasQueryKeys.list(query),
    queryFn: () => listTransferencias(query),
    placeholderData: (previous) => previous,
  })
}

export function useRegistrarTransferencia() {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (input: TransferenciaFormValues) => registrarTransferencia(input),
    onSuccess: async () => {
      await Promise.all([
        queryClient.invalidateQueries({ queryKey: transferenciasQueryKeys.all }),
        queryClient.invalidateQueries({ queryKey: ['predios'] }),
      ])
    },
  })
}
