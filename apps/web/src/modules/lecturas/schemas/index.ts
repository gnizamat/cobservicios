import { z } from 'zod'

const amount = z
  .string()
  .trim()
  .refine((value) => value !== '' && Number.isFinite(Number(value)), 'Ingresá un número')
  .refine((value) => Number(value) >= 0, 'No puede ser negativo')

const anio = z.string().trim().regex(/^\d{4}$/, 'Ingresá un año de 4 dígitos')
const mes = z.string().regex(/^(?:[1-9]|1[0-2])$/, 'Seleccioná el mes')
const referencia = z.string().trim().max(300, 'Máximo 300 caracteres')
const fecha = z.string().trim().regex(/^\d{4}-\d{2}-\d{2}$/, 'Ingresá la fecha')
const hora = z.string().trim().regex(/^\d{2}:\d{2}(:\d{2})?$/, 'Ingresá la hora')

const predioServicio = {
  predio_id: z.string().trim().min(1, 'Seleccioná el predio'),
  tipo_servicio_id: z.string().trim().min(1, 'Seleccioná el servicio'),
  anio,
  mes,
  referencia,
}

export const lecturaFormSchema = z.object({
  ...predioServicio,
  fecha_lectura: fecha,
  lectura_m3: amount,
  lectura_lt: amount,
  colaborador_id: z.string().trim(),
})

export type LecturaFormValues = z.infer<typeof lecturaFormSchema>

export interface LecturaPayload {
  predio_id: string
  tipo_servicio_id: string
  anio: number
  mes: number
  fecha_lectura: string
  lectura_m3: number
  lectura_lt: number
  volumen_m3: number
  referencia: string
  colaborador_id: string | null
}

export function toLecturaPayload(values: LecturaFormValues, volumenM3: number): LecturaPayload {
  return {
    predio_id: values.predio_id,
    tipo_servicio_id: values.tipo_servicio_id,
    anio: Number(values.anio),
    mes: Number(values.mes),
    fecha_lectura: values.fecha_lectura,
    lectura_m3: Number(values.lectura_m3),
    lectura_lt: Number(values.lectura_lt),
    volumen_m3: Math.round(volumenM3 * 1000) / 1000,
    referencia: values.referencia.trim(),
    colaborador_id: values.colaborador_id || null,
  }
}

export const volumenFormSchema = z.object({
  ...predioServicio,
  volumen_m3: amount,
})

export type VolumenFormValues = z.infer<typeof volumenFormSchema>

export interface VolumenPayload {
  predio_id: string
  tipo_servicio_id: string
  anio: number
  mes: number
  volumen_m3: number
  referencia: string
}

export function toVolumenPayload(values: VolumenFormValues): VolumenPayload {
  return {
    predio_id: values.predio_id,
    tipo_servicio_id: values.tipo_servicio_id,
    anio: Number(values.anio),
    mes: Number(values.mes),
    volumen_m3: Number(values.volumen_m3),
    referencia: values.referencia.trim(),
  }
}

export const controlFormSchema = z
  .object({
    estructura_id: z.string().trim().min(1, 'Seleccioná la estructura'),
    anio,
    mes,
    fecha_lectura: fecha,
    hora_inicio: hora,
    hora_fin: hora,
    lectura_inicial: amount,
    lectura_final: amount,
    cloro_inicial: amount,
    cloro_final: amount,
    referencia,
  })
  .refine((values) => Number(values.lectura_final) >= Number(values.lectura_inicial), {
    message: 'La lectura final no puede ser menor que la inicial.',
    path: ['lectura_final'],
  })

export type ControlFormValues = z.infer<typeof controlFormSchema>

export interface ControlPayload {
  estructura_id: string
  anio: number
  mes: number
  fecha_lectura: string
  hora_inicio: string
  hora_fin: string
  lectura_inicial: number
  lectura_final: number
  volumen_m3: number
  cloro_inicial: number
  cloro_final: number
  referencia: string
}

export const medidorFormSchema = z.object({
  codigo: z
    .string()
    .trim()
    .min(1, 'El código del medidor es obligatorio')
    .max(40, 'Máximo 40 caracteres'),
  marca_id: z.string().trim().min(1, 'Seleccioná la marca'),
  fecha_instalacion: fecha,
})

export type MedidorFormValues = z.infer<typeof medidorFormSchema>

export interface MedidorPayload {
  predio_id: string
  codigo: string
  marca_id: string
  fecha_instalacion: string
  estado: 'activo'
}

export function toMedidorPayload(predioId: string, values: MedidorFormValues): MedidorPayload {
  return {
    predio_id: predioId,
    codigo: values.codigo.trim().toUpperCase(),
    marca_id: values.marca_id,
    fecha_instalacion: values.fecha_instalacion,
    estado: 'activo',
  }
}

export function toControlPayload(values: ControlFormValues): ControlPayload {
  const lecturaInicial = Number(values.lectura_inicial)
  const lecturaFinal = Number(values.lectura_final)
  return {
    estructura_id: values.estructura_id,
    anio: Number(values.anio),
    mes: Number(values.mes),
    fecha_lectura: values.fecha_lectura,
    hora_inicio: values.hora_inicio.slice(0, 5),
    hora_fin: values.hora_fin.slice(0, 5),
    lectura_inicial: lecturaInicial,
    lectura_final: lecturaFinal,
    volumen_m3: lecturaFinal - lecturaInicial,
    cloro_inicial: Number(values.cloro_inicial),
    cloro_final: Number(values.cloro_final),
    referencia: values.referencia.trim(),
  }
}
