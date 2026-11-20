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

export function mesLabel(mes: number | string) {
  return MESES.find((item) => item.value === String(mes))?.label ?? String(mes)
}

export function periodoLabel(anio: number, mes: number) {
  return `${mesLabel(mes)} ${anio}`
}

export function currentPeriod() {
  const now = new Date()
  const month = String(now.getMonth() + 1).padStart(2, '0')
  const day = String(now.getDate()).padStart(2, '0')
  return {
    anio: String(now.getFullYear()),
    mes: String(now.getMonth() + 1),
    fecha: `${now.getFullYear()}-${month}-${day}`,
  }
}

export function includesSearch(
  query: string,
  parts: Array<string | number | null | undefined>,
) {
  const normalized = query.trim().toLowerCase()
  if (!normalized) return true
  return parts.some((part) => String(part ?? '').toLowerCase().includes(normalized))
}

const volumeFormatter = new Intl.NumberFormat('es-PE', {
  minimumFractionDigits: 2,
  maximumFractionDigits: 3,
})

export function formatVolume(value: number | string) {
  const parsed = Number(value)
  if (!Number.isFinite(parsed)) return ''
  return volumeFormatter.format(parsed)
}

export function volumeInput(value: number | string) {
  const parsed = Number(value)
  if (!Number.isFinite(parsed)) return ''
  return String(parsed)
}

const moneyFormatter = new Intl.NumberFormat('es-PE', {
  style: 'currency',
  currency: 'PEN',
  minimumFractionDigits: 2,
  maximumFractionDigits: 2,
})

export function formatMoney(value: number) {
  if (!Number.isFinite(value)) return ''
  return moneyFormatter.format(value)
}

export function roundVolume(value: number) {
  return Math.round(value * 1000) / 1000
}

export function roundMoney(value: number) {
  return Math.round(value * 100) / 100
}

export type LecturaComparada = {
  id: string
  predio_id: string
  tipo_servicio_id: string
  anio: number
  mes: number
  lectura_m3: number
  lectura_lt: number
  fecha_lectura?: string
}

export function ultimaLecturaDe(
  lecturas: LecturaComparada[],
  filtro: { predioId: string; servicioId: string; excludeId?: string },
) {
  let elegida: LecturaComparada | null = null
  let orden = -1
  for (const lectura of lecturas) {
    if (lectura.predio_id !== filtro.predioId || lectura.tipo_servicio_id !== filtro.servicioId) continue
    if (filtro.excludeId && lectura.id === filtro.excludeId) continue
    const actual = lectura.anio * 12 + lectura.mes
    if (actual <= orden) continue
    orden = actual
    elegida = lectura
  }
  return elegida
}

export function periodoSiguiente(ultima: { anio: number; mes: number } | null) {
  if (!ultima) return currentPeriod()
  const mes = ultima.mes === 12 ? 1 : ultima.mes + 1
  const anio = ultima.mes === 12 ? ultima.anio + 1 : ultima.anio
  const dia = new Date(anio, mes, 0).getDate()
  return {
    anio: String(anio),
    mes: String(mes),
    fecha: `${anio}-${String(mes).padStart(2, '0')}-${String(dia).padStart(2, '0')}`,
  }
}

export function ultimaLecturaAntes(
  lecturas: LecturaComparada[],
  filtro: {
    predioId: string
    servicioId: string
    anio: number
    mes: number
    excludeId?: string
  },
) {
  const corte = filtro.anio * 12 + filtro.mes
  let elegida: LecturaComparada | null = null
  let orden = -1
  for (const lectura of lecturas) {
    if (lectura.predio_id !== filtro.predioId || lectura.tipo_servicio_id !== filtro.servicioId) continue
    if (filtro.excludeId && lectura.id === filtro.excludeId) continue
    const actual = lectura.anio * 12 + lectura.mes
    if (actual >= corte || actual <= orden) continue
    orden = actual
    elegida = lectura
  }
  return elegida
}

export function volumenPorDiferencia(
  nuevaM3: number,
  nuevaLt: number,
  ultimaM3: number,
  ultimaLt: number,
) {
  const litros = nuevaM3 * 1000 + nuevaLt - (ultimaM3 * 1000 + ultimaLt)
  return roundVolume(litros / 1000)
}

export function timeInput(value: string) {
  return value.slice(0, 5)
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

export function predioOptionLabel(predio: {
  nombre: string
  numero?: string
  manzana?: string
  lote?: string
  calle?: { nombre: string } | null
  usuario?: {
    nombres: string
    apellido_paterno: string
    apellido_materno: string
    tipo_persona: string
    dni?: string | null
  } | null
}) {
  const dni = predio.usuario?.dni?.trim()
  return [titularLabel(predio.usuario), dni ? `DNI ${dni}` : '', predioLabel(predio)]
    .filter(Boolean)
    .join(' · ')
}
