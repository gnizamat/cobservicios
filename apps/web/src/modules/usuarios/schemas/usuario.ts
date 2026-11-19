import { z } from 'zod'

export const usuarioFormSchema = z
  .object({
    tipo_persona: z.enum(['natural', 'juridica', 'institucional']),
    nombres: z.string().trim().min(1, 'El nombre es obligatorio'),
    apellido_paterno: z.string().trim(),
    apellido_materno: z.string().trim(),
    dni: z.string().trim(),
    ruc: z.string().trim(),
    sexo: z.enum(['M', 'F', '']),
    direccion: z.string().trim(),
    email: z.string().trim(),
    celular: z.string().trim(),
    estado: z.enum(['activo', 'inactivo']),
  })
  .superRefine((data, ctx) => {
    if (data.tipo_persona === 'natural') {
      if (!data.dni) {
        ctx.addIssue({ code: 'custom', message: 'DNI obligatorio', path: ['dni'] })
      } else if (!/^\d{8}$/.test(data.dni)) {
        ctx.addIssue({ code: 'custom', message: 'DNI debe tener 8 dígitos', path: ['dni'] })
      }
      if (!data.apellido_paterno) {
        ctx.addIssue({
          code: 'custom',
          message: 'Apellido paterno obligatorio',
          path: ['apellido_paterno'],
        })
      }
      if (!data.sexo) {
        ctx.addIssue({ code: 'custom', message: 'Sexo obligatorio', path: ['sexo'] })
      }
    }

    if (data.tipo_persona === 'juridica') {
      if (!data.ruc) {
        ctx.addIssue({ code: 'custom', message: 'RUC obligatorio', path: ['ruc'] })
      } else if (!/^\d{11}$/.test(data.ruc)) {
        ctx.addIssue({ code: 'custom', message: 'RUC debe tener 11 dígitos', path: ['ruc'] })
      }
    }

    if (data.email && !z.email().safeParse(data.email).success) {
      ctx.addIssue({ code: 'custom', message: 'Correo inválido', path: ['email'] })
    }
  })

export type UsuarioFormValues = z.infer<typeof usuarioFormSchema>

export type UsuarioPayload = {
  tipo_persona: UsuarioFormValues['tipo_persona']
  nombres: string
  apellido_paterno: string
  apellido_materno: string
  dni: string | null
  ruc: string | null
  sexo: 'M' | 'F' | null
  direccion: string
  email: string | null
  celular: string | null
  estado: UsuarioFormValues['estado']
}

export function textoMayusculas(valor: string, soloLetras = false) {
  const mayusculas = valor.toLocaleUpperCase('es-PE')
  if (!soloLetras) return mayusculas
  return mayusculas.replace(/[^\p{L}\s.'-]/gu, '').replace(/[^\S\n]{2,}/g, ' ')
}

export function toUsuarioPayload(data: UsuarioFormValues): UsuarioPayload {
  const soloLetras = data.tipo_persona === 'natural'
  const emptyToNull = (value: string) => {
    const trimmed = value.trim()
    return trimmed.length === 0 ? null : trimmed
  }

  return {
    tipo_persona: data.tipo_persona,
    nombres: textoMayusculas(data.nombres, soloLetras).trim(),
    apellido_paterno: textoMayusculas(data.apellido_paterno, true).trim(),
    apellido_materno: textoMayusculas(data.apellido_materno, true).trim(),
    dni: emptyToNull(data.dni),
    ruc: emptyToNull(data.ruc),
    sexo: data.sexo === '' ? null : data.sexo,
    direccion: textoMayusculas(data.direccion).trim(),
    email: emptyToNull(textoMayusculas(data.email)),
    celular: emptyToNull(data.celular),
    estado: data.estado,
  }
}

/** @deprecated use usuarioFormSchema */
export const usuarioSchema = usuarioFormSchema
