import { jsPDF } from 'jspdf'
import { code39Bars } from '@/modules/facturacion/lib/code39'
import { AVISO_RECIBO, EMISOR_RECIBO } from '@/modules/facturacion/lib/recibo-document'
import { formatAmount, formatDate, mesLabel } from '@/modules/facturacion/labels'
import type { ReciboFactura } from '@/modules/facturacion/types'

const BLUE: [number, number, number] = [29, 79, 156]
const RED: [number, number, number] = [197, 22, 22]

function amount(value: number | null) {
  if (value == null) return ''
  return formatAmount(value)
}

function band(doc: jsPDF, text: string, y: number) {
  doc.setFillColor(...BLUE)
  doc.rect(12, y, 186, 6, 'F')
  doc.setTextColor(255)
  doc.setFont('helvetica', 'bold')
  doc.setFontSize(9)
  doc.text(text, 14, y + 4.2)
  doc.setTextColor(20)
  return y + 8
}

function drawBarcode(doc: jsPDF, value: string, x: number, y: number) {
  const bars = code39Bars(value)
  doc.setFillColor(20, 20, 20)
  let cursor = x
  for (const bar of bars) {
    const width = bar.width * 0.42
    if (bar.black) doc.rect(cursor, y, width, 10, 'F')
    cursor += width
  }
}

export function downloadReciboPdf(recibo: ReciboFactura) {
  const doc = new jsPDF({ unit: 'mm', format: 'a4' })
  const periodo = `${mesLabel(recibo.mes)} ${recibo.anio}`
  const predio = [recibo.predio, recibo.numeroPredio].filter(Boolean).join(' ')
  doc.setFont('helvetica', 'bold')
  doc.setFontSize(11)
  doc.text(EMISOR_RECIBO.titulo, 105, 16, { align: 'center' })
  doc.setFontSize(10)
  doc.text(EMISOR_RECIBO.lugar, 105, 21, { align: 'center' })

  doc.setDrawColor(20)
  doc.roundedRect(12, 26, 88, 22, 2, 2)
  doc.setFontSize(10)
  doc.text(`PERIODO:  ${periodo}`, 15, 33)
  doc.text(`RECIBO N°:  ${recibo.numero}`, 15, 39)
  doc.setFontSize(9)
  doc.text(recibo.calle.toUpperCase(), 15, 45)
  doc.setFontSize(13)
  doc.text('RECIBO DE FACTURACION', 150, 34, { align: 'center' })
  doc.setFontSize(11)
  doc.text('SERVICIO AGUA', 150, 41, { align: 'center' })

  let y = band(doc, 'DATOS DEL USUARIO Y PREDIO', 52)
  doc.setFont('helvetica', 'normal')
  doc.setFontSize(9)
  const datos: Array<[string, string, string, string]> = [
    ['CODIGO:', recibo.codigo, 'CP:', recibo.sector],
    ['USUARIO:', recibo.usuario, 'DOCUMENTO:', recibo.documento],
    ['PREDIO:', predio, 'N° CASA:', recibo.numeroPredio],
    ['MANZANA:', recibo.manzana, 'LOTE:', recibo.lote],
  ]
  for (const [leftLabel, leftValue, rightLabel, rightValue] of datos) {
    doc.setFont('helvetica', 'bold')
    doc.text(leftLabel, 14, y)
    doc.text(rightLabel, 112, y)
    doc.setFont('helvetica', 'normal')
    doc.text(leftValue || '—', 36, y)
    doc.text(rightValue || '—', 136, y)
    y += 5
  }

  y += 1
  const panelTop = y
  band(doc, 'DATOS DE SUMINISTRO Y CONSUMO', y)
  let left = y + 8
  doc.setFontSize(8.5)
  for (const linea of recibo.lineas) {
    doc.text(`Costo servicio S/: ${linea.servicio}`, 14, left)
    doc.text(formatAmount(linea.costo), 96, left, { align: 'right' })
    left += 4.5
  }
  doc.text('Lectura actual', 14, left)
  doc.text(amount(recibo.lecturaActual), 96, left, { align: 'right' })

  doc.setFillColor(...BLUE)
  doc.rect(108, panelTop, 90, 6, 'F')
  doc.setTextColor(255)
  doc.setFont('helvetica', 'bold')
  doc.setFontSize(9)
  doc.text('IMPORTES FACTURADOS', 110, panelTop + 4.2)
  doc.setTextColor(20)
  doc.setFont('helvetica', 'normal')
  doc.setFontSize(8.5)
  let right = panelTop + 10
  doc.text('Volumen (m³)', 110, right)
  doc.text(formatAmount(recibo.volumen), 194, right, { align: 'right' })
  right += 4.5
  for (const linea of recibo.lineas) {
    doc.text(`Monto fact. S/: ${linea.servicio}`, 110, right)
    doc.text(formatAmount(linea.monto), 194, right, { align: 'right' })
    right += 4.5
  }
  doc.text('Redondeo (S/)', 110, right)
  doc.text('0.00', 194, right, { align: 'right' })
  right += 5
  doc.setFont('helvetica', 'bold')
  doc.text('Total facturado mes (S/)', 110, right)
  doc.text(formatAmount(recibo.monto), 194, right, { align: 'right' })

  y = Math.max(left, right) + 6
  doc.setFontSize(8)
  doc.setFont('helvetica', 'bold')
  const columns = ['U. lectura', 'Año', 'Mes', 'Lectura (m³)', 'Dif. lectura (m³)']
  columns.forEach((column, index) => doc.text(column, 14 + index * 37, y))
  y += 5
  doc.setFont('helvetica', 'normal')
  const values = [
    amount(recibo.lecturaAnterior),
    recibo.lecturaActual == null ? '' : String(recibo.anio),
    recibo.lecturaActual == null ? '' : mesLabel(recibo.mes),
    amount(recibo.lecturaActual),
    amount(recibo.diferencia),
  ]
  values.forEach((value, index) => doc.text(value, 14 + index * 37, y))

  y += 8
  doc.setTextColor(...RED)
  doc.setFont('helvetica', 'bold')
  doc.setFontSize(12)
  doc.text(`SALDO ANTERIOR S/:  ${formatAmount(recibo.saldoAnterior)}`, 14, y)
  y += 8
  doc.setFontSize(9)
  const aviso = doc.splitTextToSize(AVISO_RECIBO, 180)
  doc.text(aviso, 105, y, { align: 'center' })
  y += aviso.length * 4 + 4
  doc.setTextColor(20)
  doc.setFontSize(9)
  doc.text(`FECHA DE EMISION: ${formatDate(recibo.fecha)}`, 14, y)
  doc.text(`FECHA DE VENCIMIENTO: ${formatDate(recibo.vencimiento)}`, 120, y)
  y += 4
  doc.setDrawColor(120)
  doc.setLineDashPattern([1.2, 1.2], 0)
  doc.line(12, y, 198, y)
  doc.setLineDashPattern([], 0)
  y += 6

  doc.setDrawColor(20)
  doc.rect(12, y, 186, 36)
  doc.setFontSize(9)
  doc.text(`USUARIO: ${recibo.usuario}`, 15, y + 6)
  doc.text(`DOCUMENTO: ${recibo.documento || '—'}`, 15, y + 11)
  doc.text(recibo.calle.toUpperCase(), 15, y + 16)
  doc.text(`MANZANA: ${recibo.manzana || '—'}    LOTE: ${recibo.lote || '—'}`, 15, y + 21)
  drawBarcode(doc, recibo.numero, 15, y + 24)

  doc.rect(118, y + 4, 76, 28)
  doc.setFont('helvetica', 'normal')
  doc.text('RECIBO N°', 121, y + 10)
  doc.text(recibo.numero, 190, y + 10, { align: 'right' })
  doc.text('PERIODO', 121, y + 15)
  doc.text(periodo, 190, y + 15, { align: 'right' })
  doc.text('TOTAL DEL MES S/', 121, y + 20)
  doc.text(formatAmount(recibo.monto), 190, y + 20, { align: 'right' })
  doc.setFont('helvetica', 'bold')
  doc.text('TOTAL A PAGAR S/', 121, y + 27)
  doc.text(formatAmount(recibo.totalPagar), 190, y + 27, { align: 'right' })

  doc.save(`${recibo.numero}.pdf`)
}
