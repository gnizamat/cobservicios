import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import {
  listBancos,
  listCajasConfig,
  listConceptosMulta,
  listDocumentos,
  listIntereses,
  saveBanco,
  saveCaja,
  saveConceptoMulta,
  saveDocumento,
  saveInteres,
  type BancoInput,
  type CajaInput,
  type ConceptoMultaInput,
  type DocumentoInput,
  type InteresInput,
} from '@/modules/configuracion/api/cobranza-config-api'
import { organizacionQueryKeys } from '@/modules/configuracion/api/query-keys'

export function useConceptosMulta() {
  return useQuery({
    queryKey: organizacionQueryKeys.conceptosMulta,
    queryFn: listConceptosMulta,
  })
}

export function useSaveConceptoMulta() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: ({ id, input }: { id: string | null; input: ConceptoMultaInput }) =>
      saveConceptoMulta(id, input),
    onSuccess: () =>
      client.invalidateQueries({ queryKey: organizacionQueryKeys.conceptosMulta }),
  })
}

export function useInteresesConfig() {
  return useQuery({
    queryKey: organizacionQueryKeys.intereses,
    queryFn: listIntereses,
  })
}

export function useSaveInteresConfig() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: ({ id, input }: { id: string | null; input: InteresInput }) => saveInteres(id, input),
    onSuccess: () => client.invalidateQueries({ queryKey: organizacionQueryKeys.intereses }),
  })
}

export function useBancos() {
  return useQuery({
    queryKey: organizacionQueryKeys.bancos,
    queryFn: listBancos,
  })
}

export function useSaveBanco() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: ({ id, input }: { id: string | null; input: BancoInput }) => saveBanco(id, input),
    onSuccess: () => client.invalidateQueries({ queryKey: organizacionQueryKeys.bancos }),
  })
}

export function useCajasConfig() {
  return useQuery({
    queryKey: organizacionQueryKeys.cajas,
    queryFn: listCajasConfig,
  })
}

export function useSaveCajaConfig() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: ({ id, input }: { id: string | null; input: CajaInput }) => saveCaja(id, input),
    onSuccess: () => {
      client.invalidateQueries({ queryKey: organizacionQueryKeys.cajas })
      client.invalidateQueries({ queryKey: ['cobranza', 'cajas'] })
    },
  })
}

export function useDocumentos() {
  return useQuery({
    queryKey: organizacionQueryKeys.documentos,
    queryFn: listDocumentos,
  })
}

export function useSaveDocumento() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: ({ id, input }: { id: string | null; input: DocumentoInput }) =>
      saveDocumento(id, input),
    onSuccess: () => client.invalidateQueries({ queryKey: organizacionQueryKeys.documentos }),
  })
}
