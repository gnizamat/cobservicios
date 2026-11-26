import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import {
  listColaboradores,
  saveColaborador,
  type ColaboradorInput,
} from '@/modules/configuracion/api/colaboradores-api'
import { organizacionQueryKeys } from '@/modules/configuracion/api/query-keys'

export function useColaboradores() {
  return useQuery({
    queryKey: organizacionQueryKeys.colaboradores,
    queryFn: listColaboradores,
  })
}

export function useSaveColaborador() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: ({ id, input }: { id: string | null; input: ColaboradorInput }) =>
      saveColaborador(id, input),
    onSuccess: () => client.invalidateQueries({ queryKey: organizacionQueryKeys.colaboradores }),
  })
}
