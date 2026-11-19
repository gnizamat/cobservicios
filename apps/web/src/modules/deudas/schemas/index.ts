import { z } from 'zod'

const amount = z
  .string()
  .trim()
  .refine((value) => value !== '' && Number.isFinite(Number(value)), 'Ingresá un número')
  .refine((value) => Number(value) >= 0, 'No puede ser negativo')

const monto = amount.refine((value) => Number(value) > 0, 'El monto debe ser mayor a cero')

export const deudaAnteriorFormSchema = z.object({
  predio_id: z.string().trim().min(1, 'Seleccioná un predio'),
  anio: z.string().trim().regex(/^\d{4}$/, 'Seleccioná el año de tarifa'),
  mes: z.string().regex(/^(?:[1-9]|1[0-2])$/, 'Seleccioná el mes'),
  tipo_servicio_id: z.string().trim().min(1, 'Seleccioná el tipo de servicio'),
  monto,
  interes: amount,
  volumen: amount,
  fecha_registro: z.string().trim().regex(/^\d{4}-\d{2}-\d{2}$/, 'Ingresá la fecha'),
  concepto: z.string().trim().max(200, 'Máximo 200 caracteres'),
})

export type DeudaAnteriorFormValues = z.infer<typeof deudaAnteriorFormSchema>

export interface DeudaAnteriorPayload {
  predio_id: string
  tarifa_id: string
  tipo_servicio_id: string
  anio: number
  mes: number
  monto: number
  interes: number
  saldo: number
  volumen: number
  fecha_registro: string
  concepto: string
}

function roundMoney(value: number) {
  return Math.round(value * 100) / 100
}

function roundVolume(value: number) {
  return Math.round(value * 1000) / 1000
}

export type DeudaFieldError = {
  field: 'anio' | 'tipo_servicio_id'
  message: string
}

export function prepareDeudaAnterior(
  values: DeudaAnteriorFormValues,
  tarifas: Array<{ id: string; anio: number }>,
  costos: Array<{ anio: number; tipo_servicio_id: string }>,
  registradas: Array<{ anio: number; mes: number; tipo_servicio_id: string }>,
): { payload: DeudaAnteriorPayload } | DeudaFieldError {
  const tarifa = tarifas.find((item) => String(item.anio) === values.anio)
  if (!tarifa) return { field: 'anio', message: 'No hay una tarifa cargada para ese año.' }

  const tieneCosto = costos.some(
    (item) => String(item.anio) === values.anio && item.tipo_servicio_id === values.tipo_servicio_id,
  )
  if (!tieneCosto) {
    return { field: 'tipo_servicio_id', message: 'Ese tipo de tarifa no tiene costo en el año.' }
  }

  const duplicada = registradas.some(
    (row) =>
      row.anio === Number(values.anio) &&
      row.mes === Number(values.mes) &&
      row.tipo_servicio_id === values.tipo_servicio_id,
  )
  if (duplicada) {
    return {
      field: 'tipo_servicio_id',
      message: 'Ya hay una deuda de ese tipo de tarifa para el mismo año y mes.',
    }
  }

  return { payload: toDeudaAnteriorPayload(values, tarifa.id) }
}

export function toDeudaAnteriorPayload(
  values: DeudaAnteriorFormValues,
  tarifaId: string,
): DeudaAnteriorPayload {
  const montoValue = roundMoney(Number(values.monto))
  return {
    predio_id: values.predio_id,
    tarifa_id: tarifaId,
    tipo_servicio_id: values.tipo_servicio_id,
    anio: Number(values.anio),
    mes: Number(values.mes),
    monto: montoValue,
    interes: roundMoney(Number(values.interes)),
    saldo: montoValue,
    volumen: roundVolume(Number(values.volumen)),
    fecha_registro: values.fecha_registro,
    concepto: values.concepto.trim(),
  }
}
