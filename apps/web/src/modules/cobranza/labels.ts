const MESES = [
  'Enero',
  'Febrero',
  'Marzo',
  'Abril',
  'Mayo',
  'Junio',
  'Julio',
  'Agosto',
  'Septiembre',
  'Octubre',
  'Noviembre',
  'Diciembre',
]

const money = new Intl.NumberFormat('es-PE', {
  style: 'currency',
  currency: 'PEN',
  minimumFractionDigits: 2,
  maximumFractionDigits: 2,
})

const volume = new Intl.NumberFormat('es-PE', {
  maximumFractionDigits: 3,
})

export const TIPOS_PAGO = [
  { value: 'efectivo', label: 'Efectivo' },
  { value: 'deposito', label: 'Depósito' },
  { value: 'transferencia', label: 'Transferencia' },
  { value: 'yape', label: 'Yape' },
] as const

export type TipoPago = (typeof TIPOS_PAGO)[number]['value']

export function mesLabel(mes: number) {
  return MESES[mes - 1] ?? String(mes)
}

export function formatMoney(value: number) {
  return money.format(value)
}

export function formatVolume(value: number) {
  if (value <= 0) return '—'
  return `${volume.format(value)} m³`
}

export function formatFecha(iso: string) {
  const [year, month, day] = iso.slice(0, 10).split('-')
  if (!year || !month || !day) return iso
  return `${day}/${month}/${year}`
}

export function fechaHoy() {
  return new Intl.DateTimeFormat('en-CA', { timeZone: 'America/Lima' }).format(new Date())
}

export function tipoPagoLabel(tipo: string) {
  return TIPOS_PAGO.find((item) => item.value === tipo)?.label ?? tipo
}

export function predioLabel(nombre: string, numero: string) {
  const nro = numero.trim()
  return nro ? `${nombre} · ${nro}` : nombre
}
