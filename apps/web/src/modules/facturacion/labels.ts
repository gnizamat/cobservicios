export const MESES = [
  { value: '1', label: 'Enero' },
  { value: '2', label: 'Febrero' },
  { value: '3', label: 'Marzo' },
  { value: '4', label: 'Abril' },
  { value: '5', label: 'Mayo' },
  { value: '6', label: 'Junio' },
  { value: '7', label: 'Julio' },
  { value: '8', label: 'Agosto' },
  { value: '9', label: 'Septiembre' },
  { value: '10', label: 'Octubre' },
  { value: '11', label: 'Noviembre' },
  { value: '12', label: 'Diciembre' },
] as const

const moneyFormatter = new Intl.NumberFormat('es-PE', {
  style: 'currency',
  currency: 'PEN',
  minimumFractionDigits: 2,
  maximumFractionDigits: 2,
})

export function mesLabel(mes: number | string) {
  return MESES.find((item) => item.value === String(mes))?.label ?? String(mes)
}

export function formatMoney(value: number | string) {
  const parsed = Number(value)
  if (!Number.isFinite(parsed)) return ''
  return moneyFormatter.format(parsed)
}

const amountFormatter = new Intl.NumberFormat('es-PE', {
  minimumFractionDigits: 2,
  maximumFractionDigits: 2,
})

export function formatAmount(value: number | string) {
  const parsed = Number(value)
  if (!Number.isFinite(parsed)) return '0.00'
  return amountFormatter.format(parsed)
}

export function formatDate(iso: string) {
  const [year, month, day] = iso.slice(0, 10).split('-')
  if (!year || !month || !day) return iso
  return `${day}/${month}/${year}`
}

export function addDaysIso(iso: string, days: number) {
  const [year, month, day] = iso.slice(0, 10).split('-').map(Number)
  const date = new Date(year, (month || 1) - 1, day || 1)
  date.setDate(date.getDate() + days)
  const nextMonth = String(date.getMonth() + 1).padStart(2, '0')
  const nextDay = String(date.getDate()).padStart(2, '0')
  return `${date.getFullYear()}-${nextMonth}-${nextDay}`
}

export function predioFacturaLabel(nombre: string, numero: string) {
  const nro = numero.trim()
  return nro ? `${nombre} · ${nro}` : nombre
}
