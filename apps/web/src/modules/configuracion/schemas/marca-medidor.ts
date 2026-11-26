import { z } from 'zod'

export const marcaMedidorSchema = z.object({
  nombre: z.string().trim().min(2, 'Indicá la marca').max(80, 'Máximo 80 caracteres'),
  procedencia: z.string().trim().min(2, 'Indicá la procedencia').max(80, 'Máximo 80 caracteres'),
})

export type MarcaMedidorValues = z.infer<typeof marcaMedidorSchema>
