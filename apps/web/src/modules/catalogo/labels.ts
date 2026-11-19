import type { CategoriaServicio } from '@/shared/types/database'

export function includesSearch(
  query: string,
  parts: Array<string | number | null | undefined>,
) {
  const normalized = query.trim().toLowerCase()
  if (!normalized) return true
  return parts.some((part) => String(part ?? '').toLowerCase().includes(normalized))
}

const amountFormatter = new Intl.NumberFormat('es-PE', {
  minimumFractionDigits: 2,
  maximumFractionDigits: 2,
})

export function formatAmount(value: number) {
  return amountFormatter.format(value)
}

const dateTimeFormatter = new Intl.DateTimeFormat('es-PE', {
  dateStyle: 'medium',
  timeStyle: 'short',
})

export function formatDateTime(value: string) {
  const date = new Date(value)
  if (Number.isNaN(date.getTime())) return value
  return dateTimeFormatter.format(date)
}

export function montoCambio(anterior: number, siguiente: number) {
  return Math.round(anterior * 100) !== Math.round(siguiente * 100)
}

export const CATEGORIAS_SERVICIO: { value: CategoriaServicio; label: string }[] = [
  { value: 'fijo', label: 'Fijo' },
  { value: 'unico', label: 'Único' },
  { value: 'volumen', label: 'Volumen' },
  { value: 'alcantarillado', label: 'Alcantarillado' },
  { value: 'medidor', label: 'Medidor' },
]
