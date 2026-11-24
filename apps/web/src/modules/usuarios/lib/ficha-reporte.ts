import type { UsuarioFicha } from '@/modules/usuarios/api/ficha-api'
import {
  buildMovimientos,
  documentoFicha,
  formatFecha,
  formatMoney,
  formatVolume,
  medidoresLabel,
  nombreFicha,
  periodoLabel,
  sexoLabel,
  sumSaldo,
  texto,
  tipoPagoFicha,
  tipoPersonaLabel,
  ubicacionPredio,
  type MovimientoFicha,
} from '@/modules/usuarios/lib/ficha-view'

export type SeccionReporte =
  | 'ficha'
  | 'predios'
  | 'lecturas'
  | 'deudas'
  | 'pagos'
  | 'facturacion'
  | 'movimientos'

export interface ColumnaReporte {
  titulo: string
  align: 'left' | 'right'
  peso: number
}

export interface BloqueReporte {
  titulo: string
  pares?: Array<{ etiqueta: string; valor: string }>
  columnas?: ColumnaReporte[]
  filas?: string[][]
  nota?: string
}

export interface ReporteFicha {
  titulo: string
  archivo: string
  usuario: string
  documento: string
  direccion: string
  emision: string
  saldo: string | null
  bloques: BloqueReporte[]
}

const fechaEmision = new Intl.DateTimeFormat('es-PE', {
  day: '2-digit',
  month: '2-digit',
  year: 'numeric',
})

function estadoLabel(estado: string) {
  if (estado === 'activo') return 'Activo'
  if (estado === 'inactivo') return 'Inactivo'
  if (estado === 'generada') return 'Generada'
  if (estado === 'cobrada') return 'Cobrada'
  if (estado === 'anulada') return 'Anulada'
  return estado || '—'
}

function predioNombre(ficha: UsuarioFicha, predioId: string) {
  return ficha.predios.find((predio) => predio.id === predioId)?.nombre ?? '—'
}

function filasPredios(ficha: UsuarioFicha) {
  return ficha.predios.map((predio) => [
    predio.nombre,
    ubicacionPredio(predio) || '—',
    predio.tipo || '—',
    medidoresLabel(predio) || '—',
    estadoLabel(predio.estado),
  ])
}

const columnasPredios: ColumnaReporte[] = [
  { titulo: 'Predio', align: 'left', peso: 1.2 },
  { titulo: 'Ubicación', align: 'left', peso: 2 },
  { titulo: 'Tipo', align: 'left', peso: 1 },
  { titulo: 'Medidor', align: 'left', peso: 1.1 },
  { titulo: 'Estado', align: 'left', peso: 0.8 },
]

export function buildReporteFicha(
  seccion: SeccionReporte,
  ficha: UsuarioFicha,
  movimientos: MovimientoFicha[] = buildMovimientos(ficha),
): ReporteFicha {
  const usuario = ficha.usuario
  const base = {
    usuario: nombreFicha(usuario),
    documento: documentoFicha(usuario),
    direccion: texto(usuario.direccion),
    emision: fechaEmision.format(new Date()),
    saldo: null as string | null,
  }

  if (seccion === 'ficha') {
    return {
      ...base,
      titulo: 'Ficha del usuario',
      archivo: 'reporte-ficha',
      bloques: [
        {
          titulo: 'Datos personales',
          pares: [
            { etiqueta: 'Tipo de persona', valor: tipoPersonaLabel(usuario.tipo_persona) },
            { etiqueta: 'Estado', valor: estadoLabel(usuario.estado) },
            { etiqueta: 'Nombres', valor: texto(usuario.nombres) },
            { etiqueta: 'Apellido paterno', valor: texto(usuario.apellido_paterno) },
            { etiqueta: 'Apellido materno', valor: texto(usuario.apellido_materno) },
            { etiqueta: 'Sexo', valor: sexoLabel(usuario.sexo) },
            { etiqueta: 'DNI', valor: texto(usuario.dni) },
            { etiqueta: 'RUC', valor: texto(usuario.ruc) },
          ],
        },
        {
          titulo: 'Contacto',
          pares: [
            { etiqueta: 'Dirección', valor: texto(usuario.direccion) },
            { etiqueta: 'Celular', valor: texto(usuario.celular) },
            { etiqueta: 'Correo', valor: texto(usuario.email) },
          ],
        },
        {
          titulo: 'Predios',
          nota: ficha.predios.length === 1 ? '1 predio' : `${ficha.predios.length} predios`,
          columnas: columnasPredios,
          filas: filasPredios(ficha),
        },
      ],
    }
  }

  if (seccion === 'predios') {
    return {
      ...base,
      titulo: 'Predios',
      archivo: 'reporte-predios',
      bloques: [
        {
          titulo: 'Predios del usuario',
          nota: ficha.predios.length === 1 ? '1 predio' : `${ficha.predios.length} predios`,
          columnas: columnasPredios,
          filas: filasPredios(ficha),
        },
      ],
    }
  }

  if (seccion === 'lecturas') {
    const filas = [...ficha.lecturas]
      .sort((a, b) => b.anio - a.anio || b.mes - a.mes || b.fecha.localeCompare(a.fecha))
      .map((lectura) => [
        predioNombre(ficha, lectura.predioId),
        periodoLabel(lectura.anio, lectura.mes),
        formatFecha(lectura.fecha),
        lectura.servicio || '—',
        formatVolume(lectura.lecturaM3),
        formatVolume(lectura.volumenM3),
      ])
    const volumen = ficha.lecturas.reduce((total, lectura) => total + lectura.volumenM3, 0)
    return {
      ...base,
      titulo: 'Lecturas',
      archivo: 'reporte-lecturas',
      bloques: [
        {
          titulo: 'Lecturas de medidor',
          nota:
            filas.length === 0
              ? 'Sin lecturas'
              : `${filas.length === 1 ? '1 lectura' : `${filas.length} lecturas`} · Volumen ${formatVolume(volumen)}`,
          columnas: [
            { titulo: 'Predio', align: 'left', peso: 1.3 },
            { titulo: 'Periodo', align: 'left', peso: 1.3 },
            { titulo: 'Fecha', align: 'left', peso: 1 },
            { titulo: 'Servicio', align: 'left', peso: 1.2 },
            { titulo: 'Lectura', align: 'right', peso: 0.9 },
            { titulo: 'Volumen', align: 'right', peso: 0.9 },
          ],
          filas,
        },
      ],
    }
  }

  if (seccion === 'deudas') {
    const monto = ficha.deudas.reduce((total, deuda) => total + deuda.monto, 0)
    const saldo = sumSaldo(ficha)
    return {
      ...base,
      titulo: 'Deudas',
      archivo: 'reporte-deudas',
      saldo: formatMoney(saldo),
      bloques: [
        {
          titulo: 'Deudas pendientes',
          nota: `Monto ${formatMoney(monto)} · Saldo pendiente ${formatMoney(saldo)}`,
          columnas: [
            { titulo: 'Periodo', align: 'left', peso: 1.3 },
            { titulo: 'Predio', align: 'left', peso: 1.2 },
            { titulo: 'Concepto', align: 'left', peso: 1.4 },
            { titulo: 'Volumen', align: 'right', peso: 0.8 },
            { titulo: 'Monto', align: 'right', peso: 0.9 },
            { titulo: 'Saldo', align: 'right', peso: 0.9 },
          ],
          filas: ficha.deudas.map((deuda) => [
            periodoLabel(deuda.anio, deuda.mes),
            predioNombre(ficha, deuda.predioId),
            deuda.concepto || '—',
            deuda.volumen > 0 ? formatVolume(deuda.volumen) : '—',
            formatMoney(deuda.monto),
            formatMoney(deuda.saldo),
          ]),
        },
      ],
    }
  }

  if (seccion === 'pagos') {
    const total = ficha.pagos.reduce((sum, pago) => sum + pago.monto, 0)
    return {
      ...base,
      titulo: 'Pagos',
      archivo: 'reporte-pagos',
      bloques: [
        {
          titulo: 'Pagos registrados',
          nota:
            ficha.pagos.length === 0
              ? 'Sin pagos'
              : `${ficha.pagos.length === 1 ? '1 pago' : `${ficha.pagos.length} pagos`} · Total ${formatMoney(total)}`,
          columnas: [
            { titulo: 'Fecha', align: 'left', peso: 1 },
            { titulo: 'Recibo', align: 'left', peso: 1.2 },
            { titulo: 'Predio', align: 'left', peso: 1.2 },
            { titulo: 'Tipo', align: 'left', peso: 1 },
            { titulo: 'Referencia', align: 'left', peso: 1.4 },
            { titulo: 'Monto', align: 'right', peso: 0.9 },
          ],
          filas: ficha.pagos.map((pago) => [
            formatFecha(pago.fecha),
            pago.numero,
            predioNombre(ficha, pago.predioId),
            tipoPagoFicha(pago.tipoPago),
            pago.referencia || '—',
            formatMoney(pago.monto),
          ]),
        },
      ],
    }
  }

  if (seccion === 'facturacion') {
    const total = ficha.facturas.reduce((sum, factura) => sum + factura.monto, 0)
    return {
      ...base,
      titulo: 'Facturación',
      archivo: 'reporte-facturacion',
      bloques: [
        {
          titulo: 'Facturas emitidas',
          nota:
            ficha.facturas.length === 0
              ? 'Sin facturas'
              : `${ficha.facturas.length === 1 ? '1 factura' : `${ficha.facturas.length} facturas`} · Total ${formatMoney(total)}`,
          columnas: [
            { titulo: 'Número', align: 'left', peso: 1.2 },
            { titulo: 'Periodo', align: 'left', peso: 1.2 },
            { titulo: 'Predio', align: 'left', peso: 1.1 },
            { titulo: 'Fecha', align: 'left', peso: 0.9 },
            { titulo: 'Conceptos', align: 'left', peso: 1.4 },
            { titulo: 'Monto', align: 'right', peso: 0.8 },
            { titulo: 'Estado', align: 'left', peso: 0.8 },
          ],
          filas: ficha.facturas.map((factura) => [
            factura.numero,
            periodoLabel(factura.anio, factura.mes),
            predioNombre(ficha, factura.predioId),
            formatFecha(factura.fecha),
            factura.conceptos || '—',
            formatMoney(factura.monto),
            estadoLabel(factura.estado),
          ]),
        },
      ],
    }
  }

  return {
    ...base,
    titulo: 'Movimientos',
    archivo: 'reporte-movimientos',
    bloques: [
      {
        titulo: 'Movimientos del padrón',
        nota:
          movimientos.length === 0
            ? 'Sin movimientos'
            : movimientos.length === 1
              ? '1 movimiento'
              : `${movimientos.length} movimientos`,
        columnas: [
          { titulo: 'Fecha', align: 'left', peso: 0.9 },
          { titulo: 'Movimiento', align: 'left', peso: 1.1 },
          { titulo: 'Predio', align: 'left', peso: 1.2 },
          { titulo: 'Detalle', align: 'left', peso: 2.4 },
        ],
        filas: movimientos.map((movimiento) => [
          formatFecha(movimiento.fecha),
          movimiento.tipo,
          movimiento.predio,
          movimiento.detalle,
        ]),
      },
    ],
  }
}
