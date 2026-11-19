import { z } from 'zod'
import type { CategoriaServicio, EstadoRegistro } from '@/shared/types/database'

const requiredName = z.string().trim().min(1, 'El nombre es obligatorio').max(160)

export const sectorFormSchema = z.object({
  codigo: z
    .string()
    .trim()
    .min(1, 'El código es obligatorio')
    .max(20, 'Máximo 20 caracteres'),
  nombre: requiredName,
})

export type SectorFormValues = z.infer<typeof sectorFormSchema>

export interface SectorPayload {
  codigo: string
  nombre: string
}

export function toSectorPayload(values: SectorFormValues): SectorPayload {
  return {
    codigo: values.codigo.trim().toUpperCase(),
    nombre: values.nombre.trim(),
  }
}

export const calleFormSchema = z.object({
  sector_id: z.string().trim().min(1, 'Seleccioná un sector'),
  nombre: requiredName,
  referencia: z.string().trim().max(200),
})

export type CalleFormValues = z.infer<typeof calleFormSchema>

export interface CallePayload {
  sector_id: string
  nombre: string
  referencia: string
}

export function toCallePayload(values: CalleFormValues): CallePayload {
  return {
    sector_id: values.sector_id,
    nombre: values.nombre.trim(),
    referencia: values.referencia.trim(),
  }
}

export const servicioFormSchema = z.object({
  codigo: z
    .string()
    .trim()
    .min(1, 'El código es obligatorio')
    .max(20, 'Máximo 20 caracteres'),
  nombre: requiredName,
  categoria: z.enum(['fijo', 'unico', 'volumen', 'alcantarillado', 'medidor']),
  estado: z.enum(['activo', 'inactivo']),
})

export type ServicioFormValues = z.infer<typeof servicioFormSchema>

export interface ServicioPayload {
  codigo: string
  nombre: string
  categoria: CategoriaServicio
  estado: EstadoRegistro
}

export function toServicioPayload(values: ServicioFormValues): ServicioPayload {
  return {
    codigo: values.codigo.trim().toUpperCase(),
    nombre: values.nombre.trim(),
    categoria: values.categoria,
    estado: values.estado,
  }
}

export const tarifaFormSchema = z.object({
  anio: z
    .string()
    .trim()
    .regex(/^(19|20)\d{2}$/, 'Ingresá un año de 4 dígitos'),
  nombre: requiredName,
  modalidad: z.string().trim().min(1, 'La modalidad es obligatoria').max(80),
  unidad_recaudacion: z
    .string()
    .trim()
    .min(1, 'La unidad de recaudación es obligatoria')
    .max(120),
  activa: z.enum(['activa', 'inactiva']),
})

export type TarifaFormValues = z.infer<typeof tarifaFormSchema>

export interface TarifaPayload {
  anio: number
  nombre: string
  modalidad: string
  unidad_recaudacion: string
  activa: boolean
}

export function toTarifaPayload(values: TarifaFormValues): TarifaPayload {
  return {
    anio: Number(values.anio),
    nombre: values.nombre.trim(),
    modalidad: values.modalidad.trim(),
    unidad_recaudacion: values.unidad_recaudacion.trim(),
    activa: values.activa === 'activa',
  }
}

const amount = z
  .string()
  .trim()
  .refine((value) => value !== '' && Number.isFinite(Number(value)), 'Ingresá un número')
  .refine((value) => Number(value) >= 0, 'No puede ser negativo')

export const costoFormSchema = z.object({
  tarifa_id: z.string().trim().min(1, 'Seleccioná el año de tarifa'),
  tipo_servicio_id: z.string().trim().min(1, 'Seleccioná el tipo de servicio'),
  valor: amount,
  monto: amount,
})

export type CostoFormValues = z.infer<typeof costoFormSchema>

export interface CostoPayload {
  tarifa_id: string
  tipo_servicio_id: string
  valor: number
  monto: number
}

export function toCostoPayload(values: CostoFormValues): CostoPayload {
  return {
    tarifa_id: values.tarifa_id,
    tipo_servicio_id: values.tipo_servicio_id,
    valor: Number(values.valor),
    monto: Number(values.monto),
  }
}

export function amountInput(value: number | string) {
  const parsed = Number(value)
  if (!Number.isFinite(parsed)) return ''
  return String(parsed)
}
