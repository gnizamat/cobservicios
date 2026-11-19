import type { CategoriaServicio } from '@/shared/types/database'
import type { CostoTarifaOption } from '@/modules/deudas/types'

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

const CATEGORIAS: Record<CategoriaServicio, string> = {
  fijo: 'Fijo',
  unico: 'Único',
  volumen: 'Volumen',
  alcantarillado: 'Alcantarillado',
  medidor: 'Medidor',
}

const moneyFormatter = new Intl.NumberFormat('es-PE', {
  style: 'currency',
  currency: 'PEN',
  minimumFractionDigits: 2,
  maximumFractionDigits: 2,
})

const volumeFormatter = new Intl.NumberFormat('es-PE', {
  minimumFractionDigits: 2,
  maximumFractionDigits: 3,
})

export function mesLabel(mes: number | string) {
  return MESES.find((item) => item.value === String(mes))?.label ?? String(mes)
}

export function categoriaLabel(categoria: CategoriaServicio) {
  return CATEGORIAS[categoria]
}

export function formatMoney(value: number | string) {
  const parsed = Number(value)
  if (!Number.isFinite(parsed)) return ''
  return moneyFormatter.format(parsed)
}

export function formatVolume(value: number | string) {
  const parsed = Number(value)
  if (!Number.isFinite(parsed)) return ''
  return volumeFormatter.format(parsed)
}

export function moneyInput(value: number) {
  if (!Number.isFinite(value)) return ''
  return (Math.round(value * 100) / 100).toFixed(2)
}

export function montoSugerido(costo: Pick<CostoTarifaOption, 'categoria' | 'monto' | 'valor'>, volumen: string) {
  const volume = Number(volumen)
  if (costo.categoria === 'volumen' && Number(costo.monto) === 0) {
    const units = Number.isFinite(volume) ? volume : 0
    return moneyInput(Number(costo.valor) * units)
  }
  return moneyInput(Number(costo.monto))
}

export function todayIso() {
  const now = new Date()
  const month = String(now.getMonth() + 1).padStart(2, '0')
  const day = String(now.getDate()).padStart(2, '0')
  return `${now.getFullYear()}-${month}-${day}`
}

export function titularLabel(
  usuario:
    | {
        nombres: string
        apellido_paterno: string
        apellido_materno: string
        tipo_persona: string
      }
    | null
    | undefined,
) {
  if (!usuario) return 'Sin titular'
  if (usuario.tipo_persona !== 'natural') return usuario.nombres || 'Sin titular'
  const apellidos = [usuario.apellido_paterno, usuario.apellido_materno].filter(Boolean).join(' ')
  if (!apellidos) return usuario.nombres || 'Sin titular'
  return usuario.nombres ? `${apellidos}, ${usuario.nombres}` : apellidos
}

export function predioLabel(predio: {
  nombre: string
  numero?: string
  manzana?: string
  lote?: string
  calle?: { nombre: string } | null
}) {
  const lugar = [
    predio.calle?.nombre,
    predio.numero ? `N° ${predio.numero}` : '',
    predio.manzana ? `Mz ${predio.manzana}` : '',
    predio.lote ? `Lt ${predio.lote}` : '',
  ].filter(Boolean)
  return lugar.length > 0 ? `${predio.nombre} · ${lugar.join(' · ')}` : predio.nombre
}
