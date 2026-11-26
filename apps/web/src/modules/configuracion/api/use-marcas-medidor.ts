import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import {
  listMarcasMedidorConfig,
  saveMarcaMedidor,
  type MarcaMedidorInput,
} from '@/modules/configuracion/api/marcas-medidor-api'
import { organizacionQueryKeys } from '@/modules/configuracion/api/query-keys'

export function useMarcasMedidorConfig() {
  return useQuery({
    queryKey: organizacionQueryKeys.marcasMedidor,
    queryFn: listMarcasMedidorConfig,
  })
}

export function useSaveMarcaMedidor() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: ({ id, input }: { id: string | null; input: MarcaMedidorInput }) =>
      saveMarcaMedidor(id, input),
    onSuccess: async () => {
      await client.invalidateQueries({ queryKey: organizacionQueryKeys.marcasMedidor })
      await client.invalidateQueries({ queryKey: ['lecturas', 'marcas'] })
    },
  })
}
