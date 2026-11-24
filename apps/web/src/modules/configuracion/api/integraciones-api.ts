import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { supabase } from '@/shared/lib/supabase'
import type { Json } from '@/shared/types/database'

export interface IntegracionDni {
  proveedor: 'decolecta'
  activa: boolean
  tieneToken: boolean
  updatedAt: string | null
}

const queryKey = ['configuracion', 'integracion-dni'] as const

function mapIntegracion(value: Json): IntegracionDni {
  const row = (value ?? {}) as {
    proveedor?: string
    activa?: boolean
    tiene_token?: boolean
    updated_at?: string | null
  }
  return {
    proveedor: 'decolecta',
    activa: row.activa === true,
    tieneToken: row.tiene_token === true,
    updatedAt: row.updated_at ?? null,
  }
}

export async function leerIntegracionDni() {
  const { data, error } = await supabase.rpc('leer_integracion_dni')
  if (error) throw error
  return mapIntegracion(data)
}

export function useIntegracionDni() {
  return useQuery({
    queryKey,
    queryFn: leerIntegracionDni,
  })
}

export function useGuardarIntegracionDni() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: async (input: { proveedor: 'decolecta'; token: string; activa: boolean }) => {
      const { data, error } = await supabase.rpc('guardar_integracion_dni', {
        p_proveedor: input.proveedor,
        p_token: input.token,
        p_activa: input.activa,
      })
      if (error) throw error
      return mapIntegracion(data)
    },
    onSuccess: (data) => {
      client.setQueryData(queryKey, data)
    },
  })
}

export function useEliminarCredencialDni() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: async () => {
      const { data, error } = await supabase.rpc('eliminar_credencial_dni')
      if (error) throw error
      return mapIntegracion(data)
    },
    onSuccess: (data) => {
      client.setQueryData(queryKey, data)
    },
  })
}
