import { z } from 'zod'

export const predioFormSchema = z.object({
  usuario_id: z.string().uuid('Seleccioná un usuario'),
  tipo_predio_id: z.string(),
  sector_id: z.string(),
  calle_id: z.string(),
  nombre: z.string().trim().min(1, 'El nombre del predio es obligatorio'),
  numero: z.string().trim(),
  manzana: z.string().trim(),
  lote: z.string().trim(),
  partida_registral: z.string().trim(),
  unidad_catastral: z.string().trim(),
  titulo: z.string().trim(),
  fecha_documento: z.string(),
  coord_este: z.string().trim(),
  coord_norte: z.string().trim(),
  estado: z.enum(['activo', 'inactivo']),
})

export type PredioFormValues = z.infer<typeof predioFormSchema>

export type PredioPayload = {
  usuario_id: string
  tipo_predio_id: string | null
  sector_id: string | null
  calle_id: string | null
  nombre: string
  numero: string
  manzana: string
  lote: string
  partida_registral: string
  unidad_catastral: string
  titulo: string
  fecha_documento: string | null
  coord_este: string
  coord_norte: string
  estado: PredioFormValues['estado']
}

export function toPredioPayload(data: PredioFormValues): PredioPayload {
  const emptyToNull = (value: string) => {
    const trimmed = value.trim()
    return trimmed.length === 0 ? null : trimmed
  }

  return {
    usuario_id: data.usuario_id,
    tipo_predio_id: emptyToNull(data.tipo_predio_id),
    sector_id: emptyToNull(data.sector_id),
    calle_id: emptyToNull(data.calle_id),
    nombre: data.nombre,
    numero: data.numero,
    manzana: data.manzana,
    lote: data.lote,
    partida_registral: data.partida_registral,
    unidad_catastral: data.unidad_catastral,
    titulo: data.titulo,
    fecha_documento: emptyToNull(data.fecha_documento),
    coord_este: data.coord_este,
    coord_norte: data.coord_norte,
    estado: data.estado,
  }
}

/** @deprecated use predioFormSchema */
export const predioSchema = predioFormSchema
