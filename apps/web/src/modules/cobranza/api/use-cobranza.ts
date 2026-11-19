import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import {
  anularPago,
  cobrarFacturaciones,
  getCobranzaPredio,
  getReciboPago,
  listCajas,
  listPagos,
  listPrediosACobrar,
  listTerritorioCobranza,
  type FiltroCobranza,
  type FiltroPagos,
} from '@/modules/cobranza/api/cobranza-api'
import { cobranzaQueryKeys } from '@/modules/cobranza/api/query-keys'

export function useTerritorioCobranza() {
  return useQuery({
    queryKey: cobranzaQueryKeys.territorio,
    queryFn: listTerritorioCobranza,
  })
}

export function usePrediosACobrar(filtros: FiltroCobranza) {
  return useQuery({
    queryKey: cobranzaQueryKeys.predios(filtros.sectorId, filtros.calleId, filtros.search),
    queryFn: () => listPrediosACobrar(filtros),
  })
}

export function useCobranzaPredio(predioId: string | null) {
  return useQuery({
    queryKey: cobranzaQueryKeys.facturas(predioId ?? ''),
    queryFn: () => getCobranzaPredio(predioId ?? ''),
    enabled: Boolean(predioId),
  })
}

export function useReciboPago(id: string | null) {
  return useQuery({
    queryKey: cobranzaQueryKeys.recibo(id ?? ''),
    queryFn: () => getReciboPago(id ?? ''),
    enabled: Boolean(id),
  })
}

export function useCajas() {
  return useQuery({
    queryKey: cobranzaQueryKeys.cajas,
    queryFn: listCajas,
  })
}

export function usePagos(filtros: FiltroPagos) {
  return useQuery({
    queryKey: cobranzaQueryKeys.pagos(
      filtros.sectorId,
      filtros.cajaId,
      filtros.desde,
      filtros.hasta,
      filtros.search,
    ),
    queryFn: () => listPagos(filtros),
  })
}

export function useAnularPago() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: anularPago,
    onSuccess: async () => {
      await Promise.all([
        client.invalidateQueries({ queryKey: cobranzaQueryKeys.all }),
        client.invalidateQueries({ queryKey: ['facturacion'] }),
        client.invalidateQueries({ queryKey: ['deudas'] }),
        client.invalidateQueries({ queryKey: ['usuarios'] }),
      ])
    },
  })
}

export function useCobrarFacturaciones() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: cobrarFacturaciones,
    onSuccess: async () => {
      await Promise.all([
        client.invalidateQueries({ queryKey: cobranzaQueryKeys.all }),
        client.invalidateQueries({ queryKey: ['facturacion'] }),
        client.invalidateQueries({ queryKey: ['deudas'] }),
        client.invalidateQueries({ queryKey: ['usuarios'] }),
      ])
    },
  })
}
