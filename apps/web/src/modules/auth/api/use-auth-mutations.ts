import { useMutation, useQueryClient } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
import { signInWithPassword, signOut } from '@/modules/auth/api/auth-api'
import type { LoginInput } from '@/modules/auth/schemas'
import { authQueryKeys } from '@/modules/auth/api/query-keys'

export function useSignIn() {
  const navigate = useNavigate()
  const queryClient = useQueryClient()

  return useMutation({
    mutationFn: (input: LoginInput) => signInWithPassword(input),
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: authQueryKeys.session() })
      navigate('/', { replace: true })
    },
  })
}

export function useSignOut() {
  const navigate = useNavigate()
  const queryClient = useQueryClient()

  return useMutation({
    mutationFn: () => signOut(),
    onSuccess: async () => {
      queryClient.setQueryData(authQueryKeys.session(), null)
      await queryClient.invalidateQueries({ queryKey: authQueryKeys.session() })
      navigate('/acceso', { replace: true })
    },
  })
}
