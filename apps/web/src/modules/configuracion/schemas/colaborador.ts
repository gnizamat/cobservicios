import { z } from 'zod'

export const colaboradorFormSchema = z.object({
  dni: z
    .string()
    .trim()
    .regex(/^\d{8}$/, 'El DNI debe tener 8 dígitos'),
  apellido_paterno: z
    .string()
    .trim()
    .min(2, 'Indicá los apellidos')
    .max(80, 'Máximo 80 caracteres'),
  apellido_materno: z.string().trim().max(80, 'Máximo 80 caracteres'),
  nombres: z.string().trim().min(2, 'Indicá los nombres').max(120, 'Máximo 120 caracteres'),
  sector_ids: z.array(z.string().uuid()).min(1, 'Asigná al menos un centro poblado'),
})

export type ColaboradorFormValues = z.infer<typeof colaboradorFormSchema>

export function textoColaborador(valor: string) {
  return valor
    .toLocaleUpperCase('es-PE')
    .replace(/[^\p{L}\s.'-]/gu, '')
    .replace(/[^\S\n]{2,}/g, ' ')
}

export function toColaboradorPayload(values: ColaboradorFormValues) {
  return {
    dni: values.dni.trim(),
    apellido_paterno: textoColaborador(values.apellido_paterno).trim(),
    apellido_materno: textoColaborador(values.apellido_materno).trim(),
    nombres: textoColaborador(values.nombres).trim(),
    sector_ids: [...new Set(values.sector_ids)],
  }
}
