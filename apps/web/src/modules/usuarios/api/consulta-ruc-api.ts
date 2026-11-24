import { useMutation, useQuery } from '@tanstack/react-query'
import { supabase } from '@/shared/lib/supabase'

export interface EmpresaRuc {
  razonSocial: string
  direccion: string
}

export function useConsultaRucActiva() {
  return useQuery({
    queryKey: ['usuarios', 'consulta-ruc-activa'],
    queryFn: async () => {
      const { data, error } = await supabase.rpc('consulta_ruc_activa')
      if (error) throw error
      return data === true
    },
    staleTime: 30_000,
  })
}

export function useConsultarRuc() {
  return useMutation({
    mutationFn: async (ruc: string): Promise<EmpresaRuc> => {
      const { data, error } = await supabase.rpc('consultar_ruc', { p_ruc: ruc })
      if (error) throw error
      const empresa = (data ?? {}) as {
        razon_social?: string
        direccion?: string
      }
      return {
        razonSocial: empresa.razon_social?.trim() ?? '',
        direccion: empresa.direccion?.trim() ?? '',
      }
    },
  })
}
