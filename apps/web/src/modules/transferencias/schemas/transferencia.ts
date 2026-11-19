import { z } from 'zod'

export const transferenciaFormSchema = z
  .object({
    usuario_origen_id: z.string().uuid('Seleccioná el usuario de origen'),
    usuario_destino_id: z.string().uuid('Seleccioná el usuario destino'),
    referencia: z
      .string()
      .trim()
      .max(500, 'La referencia admite hasta 500 caracteres'),
    predio_ids: z
      .array(z.string().uuid())
      .min(1, 'Pasá al menos un predio al usuario destino'),
  })
  .superRefine((data, ctx) => {
    if (
      data.usuario_origen_id &&
      data.usuario_destino_id &&
      data.usuario_origen_id === data.usuario_destino_id
    ) {
      ctx.addIssue({
        code: 'custom',
        message: 'El origen y el destino deben ser distintos',
        path: ['usuario_destino_id'],
      })
    }
  })

export type TransferenciaFormValues = z.infer<typeof transferenciaFormSchema>
