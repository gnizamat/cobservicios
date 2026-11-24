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

const queryKeyRuc = ['configuracion', 'integracion-ruc'] as const

export function useIntegracionRuc() {
  return useQuery({
    queryKey: queryKeyRuc,
    queryFn: async () => {
      const { data, error } = await supabase.rpc('leer_integracion_ruc')
      if (error) throw error
      return mapIntegracion(data)
    },
  })
}

export function useGuardarIntegracionRuc() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: async (input: { proveedor: 'decolecta'; token: string; activa: boolean }) => {
      const { data, error } = await supabase.rpc('guardar_integracion_ruc', {
        p_proveedor: input.proveedor,
        p_token: input.token,
        p_activa: input.activa,
      })
      if (error) throw error
      return mapIntegracion(data)
    },
    onSuccess: (data) => {
      client.setQueryData(queryKeyRuc, data)
    },
  })
}

export interface IntegracionIa {
  proveedor: 'openai'
  modelo: string
  tieneToken: boolean
  sufijo: string
  updatedAt: string | null
}

const queryKeyIa = ['configuracion', 'integracion-ia'] as const

function mapIntegracionIa(value: Json): IntegracionIa {
  const row = (value ?? {}) as {
    modelo?: string
    tiene_token?: boolean
    sufijo?: string
    updated_at?: string | null
  }
  return {
    proveedor: 'openai',
    modelo: row.modelo?.trim() || 'gpt-4.1-mini',
    tieneToken: row.tiene_token === true,
    sufijo: row.sufijo ?? '',
    updatedAt: row.updated_at ?? null,
  }
}

export function useIntegracionIa() {
  return useQuery({
    queryKey: queryKeyIa,
    queryFn: async () => {
      const { data, error } = await supabase.rpc('leer_integracion_ia')
      if (error) throw error
      return mapIntegracionIa(data)
    },
  })
}

export function useGuardarIntegracionIa() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: async (input: { proveedor: 'openai'; token: string; modelo: string }) => {
      const { data, error } = await supabase.rpc('guardar_integracion_ia', {
        p_proveedor: input.proveedor,
        p_token: input.token,
        p_modelo: input.modelo,
      })
      if (error) throw error
      return mapIntegracionIa(data)
    },
    onSuccess: (data) => {
      client.setQueryData(queryKeyIa, data)
    },
  })
}

export function useEliminarCredencialIa() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: async () => {
      const { data, error } = await supabase.rpc('eliminar_credencial_ia')
      if (error) throw error
      return mapIntegracionIa(data)
    },
    onSuccess: (data) => {
      client.setQueryData(queryKeyIa, data)
    },
  })
}

export function useEliminarCredencialRuc() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: async () => {
      const { data, error } = await supabase.rpc('eliminar_credencial_ruc')
      if (error) throw error
      return mapIntegracion(data)
    },
    onSuccess: (data) => {
      client.setQueryData(queryKeyRuc, data)
    },
  })
}
