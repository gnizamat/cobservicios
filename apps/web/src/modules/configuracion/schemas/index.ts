import { z } from 'zod'

const optionalEmail = z
  .string()
  .trim()
  .max(160, 'Máximo 160 caracteres')
  .refine((value) => value === '' || z.email().safeParse(value).success, 'Ingresá un correo válido')

export const datosJassSchema = z.object({
  nombre: z.string().trim().min(1, 'El nombre es obligatorio').max(180, 'Máximo 180 caracteres'),
  abreviatura: z.string().trim().min(1, 'La abreviatura es obligatoria').max(40, 'Máximo 40 caracteres'),
  celular: z.string().trim().max(20, 'Máximo 20 caracteres'),
  direccion: z.string().trim().max(200, 'Máximo 200 caracteres'),
  email: optionalEmail,
})

export type DatosJassValues = z.infer<typeof datosJassSchema>

const coordinate = z
  .string()
  .trim()
  .refine((value) => value === '' || Number.isFinite(Number(value)), 'Ingresá un número')

export const ubicacionSchema = z
  .object({
    latitud: coordinate,
    longitud: coordinate,
  })
  .refine((values) => (values.latitud === '') === (values.longitud === ''), {
    message: 'Completá latitud y longitud.',
    path: ['latitud'],
  })
  .refine((values) => values.latitud === '' || Math.abs(Number(values.latitud)) <= 90, {
    message: 'La latitud va entre -90 y 90.',
    path: ['latitud'],
  })
  .refine((values) => values.longitud === '' || Math.abs(Number(values.longitud)) <= 180, {
    message: 'La longitud va entre -180 y 180.',
    path: ['longitud'],
  })

export type UbicacionValues = z.infer<typeof ubicacionSchema>
