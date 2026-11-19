import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import {
  createPredio,
  getPredio,
  getUsuarioTitular,
  listPredioCatalogs,
  listPredios,
  searchUsuariosTitular,
  updatePredio,
  type PrediosListQuery,
} from '@/modules/predios/api/predios-api'
import { prediosQueryKeys } from '@/modules/predios/api/query-keys'
import type { PredioPayload } from '@/modules/predios/schemas'

export function usePredios(query: PrediosListQuery = {}) {
  return useQuery({
    queryKey: prediosQueryKeys.list(query),
    queryFn: () => listPredios(query),
    placeholderData: (previous) => previous,
  })
}

export function usePredio(id?: string) {
  return useQuery({
    queryKey: prediosQueryKeys.detail(id ?? ''),
    queryFn: () => getPredio(id!),
    enabled: Boolean(id),
  })
}

export function useUsuariosTitular(term: string, enabled: boolean) {
  return useQuery({
    queryKey: prediosQueryKeys.usuariosTitular(term),
    queryFn: () => searchUsuariosTitular(term),
    enabled,
  })
}

export function useUsuarioTitular(id: string) {
  return useQuery({
    queryKey: prediosQueryKeys.usuarioTitular(id),
    queryFn: () => getUsuarioTitular(id),
    enabled: Boolean(id),
  })
}

export function usePredioCatalogs() {
  return useQuery({
    queryKey: prediosQueryKeys.catalogs(),
    queryFn: () => listPredioCatalogs(),
  })
}

export function useCreatePredio() {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (payload: PredioPayload) => createPredio(payload),
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: prediosQueryKeys.all })
    },
  })
}

export function useUpdatePredio(id: string) {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (payload: PredioPayload) => updatePredio(id, payload),
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: prediosQueryKeys.all })
    },
  })
}
