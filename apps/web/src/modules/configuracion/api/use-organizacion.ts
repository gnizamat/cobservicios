import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import {
  getOrganizacion,
  removeLogo,
  saveDatosJass,
  saveUbicacion,
  uploadLogo,
} from '@/modules/configuracion/api/organizacion-api'
import { organizacionQueryKeys } from '@/modules/configuracion/api/query-keys'

export function useOrganizacion() {
  return useQuery({
    queryKey: organizacionQueryKeys.jass,
    queryFn: getOrganizacion,
  })
}

function useOrganizacionMutation<TVariables>(
  mutationFn: (variables: TVariables) => Promise<unknown>,
) {
  const queryClient = useQueryClient()
  return useMutation({
    mutationFn,
    onSuccess: async () => {
      await queryClient.invalidateQueries({ queryKey: organizacionQueryKeys.jass })
    },
  })
}

export function useSaveDatosJass() {
  return useOrganizacionMutation(saveDatosJass)
}

export function useSaveUbicacion() {
  return useOrganizacionMutation(saveUbicacion)
}

export function useUploadLogo() {
  return useOrganizacionMutation(uploadLogo)
}

export function useRemoveLogo() {
  return useOrganizacionMutation(removeLogo)
}
