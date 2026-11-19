import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import {
  actualizarUsuarioSistema,
  crearUsuarioSistema,
  getMarcaNombre,
  guardarMarcaNombre,
  listRoles,
  listUsuariosSistema,
} from '@/modules/configuracion/api/sistema-api'
import { organizacionQueryKeys } from '@/modules/configuracion/api/query-keys'

export function useRolesSistema() {
  return useQuery({
    queryKey: organizacionQueryKeys.roles,
    queryFn: listRoles,
  })
}

export function useUsuariosSistema() {
  return useQuery({
    queryKey: organizacionQueryKeys.usuariosSistema,
    queryFn: listUsuariosSistema,
  })
}

export function useActualizarUsuarioSistema() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: actualizarUsuarioSistema,
    onSuccess: async () => {
      await client.invalidateQueries({ queryKey: organizacionQueryKeys.usuariosSistema })
    },
  })
}

export function useCrearUsuarioSistema() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: crearUsuarioSistema,
    onSuccess: async () => {
      await client.invalidateQueries({ queryKey: organizacionQueryKeys.usuariosSistema })
    },
  })
}

export function useMarca() {
  return useQuery({
    queryKey: organizacionQueryKeys.marca,
    queryFn: getMarcaNombre,
  })
}

export function useGuardarMarca() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: guardarMarcaNombre,
    onSuccess: async () => {
      await client.invalidateQueries({ queryKey: organizacionQueryKeys.marca })
    },
  })
}
