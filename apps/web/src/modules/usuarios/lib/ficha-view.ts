import type {
  FichaPredio,
  UsuarioFicha,
} from '@/modules/usuarios/api/ficha-api'
import type { PadUsuario } from '@/shared/types/database'

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
  minimumFractionDigits: 0,
  maximumFractionDigits: 3,
})

export interface MovimientoFicha {
  id: string
  fecha: string
  tipo: string
  predio: string
  detalle: string
}

export function nombreFicha(usuario: PadUsuario) {
  if (usuario.tipo_persona !== 'natural') return usuario.nombres
  return [usuario.apellido_paterno, usuario.apellido_materno, usuario.nombres]
    .filter(Boolean)
    .join(' ')
}

export function tipoPersonaLabel(tipo: PadUsuario['tipo_persona']) {
  if (tipo === 'juridica') return 'Jurídica'
  if (tipo === 'institucional') return 'Institucional'
  return 'Natural'
}

export function sexoLabel(sexo: PadUsuario['sexo']) {
  if (sexo === 'M') return 'Masculino'
  if (sexo === 'F') return 'Femenino'
  return '—'
}

export function documentoFicha(usuario: PadUsuario) {
  if (usuario.dni) return `DNI ${usuario.dni}`
  if (usuario.ruc) return `RUC ${usuario.ruc}`
  return 'Sin documento'
}

export function texto(value: string | null | undefined) {
  const trimmed = value?.trim()
  return trimmed ? trimmed : '—'
}

export function formatMoney(value: number) {
  return money.format(value)
}

export function formatVolume(value: number) {
  return `${volume.format(value)} m³`
}

export function formatFecha(iso: string) {
  const [year, month, day] = iso.slice(0, 10).split('-')
  if (!year || !month || !day) return iso
  return `${day}/${month}/${year}`
}

export function periodoLabel(anio: number, mes: number) {
  return `${MESES[mes - 1] ?? mes} ${anio}`
}

export function ubicacionPredio(predio: Pick<FichaPredio, 'sector' | 'calle' | 'numero' | 'manzana' | 'lote'>) {
  return [
    predio.sector,
    predio.calle,
    predio.numero && `N° ${predio.numero}`,
    predio.manzana && `Mz ${predio.manzana}`,
    predio.lote && `Lt ${predio.lote}`,
  ]
    .filter(Boolean)
    .join(' · ')
}

export function medidoresLabel(predio: FichaPredio) {
  const activos = predio.medidores.filter((medidor) => medidor.estado === 'activo')
  const lista = (activos.length > 0 ? activos : predio.medidores).map((medidor) => medidor.codigo)
  return lista.join(', ')
}

export function tipoPagoFicha(tipo: string) {
  if (tipo === 'efectivo') return 'Efectivo'
  if (tipo === 'deposito') return 'Depósito'
  if (tipo === 'transferencia') return 'Transferencia'
  if (tipo === 'yape') return 'Yape'
  return tipo
}

export function sumSaldo(ficha: UsuarioFicha) {
  return ficha.deudas.reduce((total, deuda) => total + deuda.saldo, 0)
}

export function buildMovimientos(ficha: UsuarioFicha): MovimientoFicha[] {
  const predios = new Map(ficha.predios.map((predio) => [predio.id, predio.nombre]))
  const nombre = (predioId: string) => predios.get(predioId) ?? 'Predio'

  const movimientos: MovimientoFicha[] = [
    ...ficha.historial.map((fila) => ({
      id: `pad-${fila.id}`,
      fecha: fila.desde,
      tipo: fila.transferenciaId ? 'Transferencia' : 'Padrón',
      predio: fila.nombrePredio || nombre(fila.predioId),
      detalle: [
        fila.referencia || 'Movimiento de padrón',
        fila.vigente ? 'Vigente' : 'Cerrado',
      ].join(' · '),
    })),
    ...ficha.predios.flatMap((predio) =>
      predio.medidores.map((medidor) => ({
        id: `med-${medidor.id}`,
        fecha: medidor.fechaInstalacion,
        tipo: 'Medidor',
        predio: predio.nombre,
        detalle: [`Instalación ${medidor.codigo}`, medidor.marca].filter(Boolean).join(' · '),
      })),
    ),
    ...ficha.lecturas.map((lectura) => ({
      id: `lec-${lectura.id}`,
      fecha: lectura.fecha,
      tipo: 'Lectura',
      predio: nombre(lectura.predioId),
      detalle: [
        lectura.servicio,
        `Lectura ${formatVolume(lectura.lecturaM3)}`,
        `Volumen ${formatVolume(lectura.volumenM3)}`,
        periodoLabel(lectura.anio, lectura.mes),
        lectura.referencia,
      ]
        .filter(Boolean)
        .join(' · '),
    })),
    ...ficha.volumenes.map((item) => ({
      id: `vol-${item.id}`,
      fecha: item.fecha,
      tipo: 'Volumen',
      predio: nombre(item.predioId),
      detalle: [
        item.servicio,
        `Sin lectura ${formatVolume(item.volumenM3)}`,
        periodoLabel(item.anio, item.mes),
        item.referencia,
      ]
        .filter(Boolean)
        .join(' · '),
    })),
    ...ficha.deudas.map((deuda) => ({
      id: `deu-${deuda.id}`,
      fecha: deuda.fecha,
      tipo: 'Deuda',
      predio: nombre(deuda.predioId),
      detalle: [
        deuda.concepto,
        periodoLabel(deuda.anio, deuda.mes),
        formatMoney(deuda.monto),
        `Saldo ${formatMoney(deuda.saldo)}`,
        deuda.volumen > 0 ? formatVolume(deuda.volumen) : '',
      ]
        .filter(Boolean)
        .join(' · '),
    })),
    ...ficha.facturas.map((factura) => ({
      id: `fac-${factura.id}`,
      fecha: factura.fecha,
      tipo: 'Facturación',
      predio: nombre(factura.predioId),
      detalle: [
        factura.numero,
        periodoLabel(factura.anio, factura.mes),
        formatMoney(factura.monto),
        factura.conceptos,
      ]
        .filter(Boolean)
        .join(' · '),
    })),
    ...ficha.pagos.map((pago) => ({
      id: `pag-${pago.id}`,
      fecha: pago.fecha,
      tipo: 'Pago',
      predio: nombre(pago.predioId),
      detalle: [pago.numero, tipoPagoFicha(pago.tipoPago), formatMoney(pago.monto), pago.referencia]
        .filter(Boolean)
        .join(' · '),
    })),
  ]

  return movimientos.sort((a, b) => b.fecha.localeCompare(a.fecha))
}
