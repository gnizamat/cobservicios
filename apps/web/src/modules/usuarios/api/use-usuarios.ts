import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { getFichaUsuario } from '@/modules/usuarios/api/ficha-api'
import {
  createUsuario,
  getUsuario,
  listUsuarios,
  updateUsuario,
  type UsuariosListQuery,
} from '@/modules/usuarios/api/usuarios-api'
import { usuariosQueryKeys } from '@/modules/usuarios/api/query-keys'
import type { UsuarioPayload } from '@/modules/usuarios/schemas'

export function useUsuarios(query: UsuariosListQuery = {}) {
  return useQuery({
    queryKey: usuariosQueryKeys.list(query),
    queryFn: () => listUsuarios(query),
    placeholderData: (previous) => previous,
  })
}

export function useUsuario(id?: string) {
  return useQuery({
    queryKey: usuariosQueryKeys.detail(id ?? ''),
    queryFn: () => getUsuario(id!),
    enabled: Boolean(id),
  })
}

export function useFichaUsuario(id?: string) {
  return useQuery({
    queryKey: usuariosQueryKeys.ficha(id ?? ''),
    queryFn: () => getFichaUsuario(id!),
    enabled: Boolean(id),
  })
}

export function useCreateUsuario() {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (payload: UsuarioPayload) => createUsuario(payload),
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: usuariosQueryKeys.all })
    },
  })
}

export function useUpdateUsuario(id: string) {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn: (payload: UsuarioPayload) => updateUsuario(id, payload),
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: usuariosQueryKeys.all })
    },
  })
}
