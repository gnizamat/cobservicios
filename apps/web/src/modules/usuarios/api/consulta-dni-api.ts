import { useMutation, useQuery } from '@tanstack/react-query'
import { supabase } from '@/shared/lib/supabase'

export interface PersonaDni {
  nombres: string
  apellidoPaterno: string
  apellidoMaterno: string
}

export function useConsultaDniActiva() {
  return useQuery({
    queryKey: ['usuarios', 'consulta-dni-activa'],
    queryFn: async () => {
      const { data, error } = await supabase.rpc('consulta_dni_activa')
      if (error) throw error
      return data === true
    },
    staleTime: 30_000,
  })
}

export function useConsultarDni() {
  return useMutation({
    mutationFn: async (dni: string): Promise<PersonaDni> => {
      const { data, error } = await supabase.rpc('consultar_dni', { p_dni: dni })
      if (error) throw error
      const persona = (data ?? {}) as {
        nombres?: string
        apellido_paterno?: string
        apellido_materno?: string
      }
      return {
        nombres: persona.nombres?.trim() ?? '',
        apellidoPaterno: persona.apellido_paterno?.trim() ?? '',
        apellidoMaterno: persona.apellido_materno?.trim() ?? '',
      }
    },
  })
}
