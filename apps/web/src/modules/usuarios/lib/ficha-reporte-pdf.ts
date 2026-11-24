import { jsPDF } from 'jspdf'
import { EMISOR_RECIBO } from '@/modules/facturacion/lib/recibo-document'
import type { ColumnaReporte, ReporteFicha } from '@/modules/usuarios/lib/ficha-reporte'

const BLUE: [number, number, number] = [29, 79, 156]
const MARGIN = 12
const WIDTH = 186
const PAGE_BOTTOM = 285

function pdfSafe(value: string) {
  return value.replaceAll('³', '3')
}

function band(doc: jsPDF, text: string, y: number) {
  doc.setFillColor(...BLUE)
  doc.rect(MARGIN, y, WIDTH, 6, 'F')
  doc.setTextColor(255)
  doc.setFont('helvetica', 'bold')
  doc.setFontSize(9)
  doc.text(pdfSafe(text), MARGIN + 2, y + 4.2)
  doc.setTextColor(20)
  return y + 8
}

function columnWidths(columnas: ColumnaReporte[]) {
  const total = columnas.reduce((sum, columna) => sum + columna.peso, 0) || 1
  return columnas.map((columna) => (WIDTH * columna.peso) / total)
}

export function downloadReporteFichaPdf(reporte: ReporteFicha) {
  const doc = new jsPDF({ unit: 'mm', format: 'a4' })
  let y = drawHeader(doc, reporte)

  for (const bloque of reporte.bloques) {
    y = ensure(doc, reporte, y, 16)
    y = band(doc, bloque.titulo.toUpperCase(), y)
    if (bloque.nota) {
      doc.setFont('helvetica', 'normal')
      doc.setFontSize(9)
      doc.text(pdfSafe(bloque.nota), MARGIN, y)
      y += 5
    }
    if (bloque.pares) {
      for (const par of bloque.pares) {
        y = ensure(doc, reporte, y, 6)
        doc.setFont('helvetica', 'bold')
        doc.setFontSize(9)
        doc.text(pdfSafe(par.etiqueta), MARGIN, y)
        doc.setFont('helvetica', 'normal')
        const lineas = doc.splitTextToSize(pdfSafe(par.valor), 120)
        doc.text(lineas, MARGIN + 42, y)
        y += Math.max(5, lineas.length * 4)
      }
      y += 2
    }
    if (bloque.columnas) {
      y = drawTable(doc, reporte, y, bloque.columnas, bloque.filas ?? [])
    }
  }

  if (reporte.saldo) {
    y = ensure(doc, reporte, y, 8)
    doc.setTextColor(...([197, 22, 22] as [number, number, number]))
    doc.setFont('helvetica', 'bold')
    doc.setFontSize(12)
    doc.text(pdfSafe(`SALDO PENDIENTE: ${reporte.saldo}`), MARGIN, y)
    doc.setTextColor(20)
  }

  doc.save(`${reporte.archivo}.pdf`)
}

function drawHeader(doc: jsPDF, reporte: ReporteFicha) {
  doc.setFont('helvetica', 'bold')
  doc.setFontSize(11)
  doc.setTextColor(20)
  doc.text(EMISOR_RECIBO.titulo, 105, 14, { align: 'center' })
  doc.setFontSize(10)
  doc.text(EMISOR_RECIBO.lugar, 105, 19, { align: 'center' })

  doc.setDrawColor(20)
  doc.roundedRect(MARGIN, 23, 108, 24, 2, 2)
  doc.setFontSize(9)
  const identidad = [
    `USUARIO:  ${reporte.usuario}`,
    `DOCUMENTO:  ${reporte.documento}`,
    `DIRECCIÓN:  ${reporte.direccion}`,
    `EMISIÓN:  ${reporte.emision}`,
  ]
  identidad.forEach((linea, index) => {
    const texto = doc.splitTextToSize(pdfSafe(linea), 102)[0] ?? ''
    doc.text(String(texto), MARGIN + 3, 29 + index * 5)
  })

  doc.setFontSize(13)
  doc.text('REPORTE', 162, 32, { align: 'center' })
  doc.setFontSize(11)
  doc.text(pdfSafe(reporte.titulo.toUpperCase()), 162, 39, { align: 'center' })
  return 52
}

function ensure(doc: jsPDF, reporte: ReporteFicha, y: number, needed: number) {
  if (y + needed <= PAGE_BOTTOM) return y
  doc.addPage()
  doc.setFont('helvetica', 'bold')
  doc.setFontSize(9)
  doc.setTextColor(20)
  doc.text(pdfSafe(`${reporte.titulo} · continúa`), MARGIN, 14)
  return 20
}

function drawTable(
  doc: jsPDF,
  reporte: ReporteFicha,
  startY: number,
  columnas: ColumnaReporte[],
  filas: string[][],
) {
  if (filas.length === 0) {
    doc.setFont('helvetica', 'normal')
    doc.setFontSize(9)
    doc.text('Sin registros.', MARGIN, startY)
    return startY + 6
  }

  const widths = columnWidths(columnas)
  let y = startY

  const header = () => {
    y = ensure(doc, reporte, y, 8)
    doc.setFillColor(243, 243, 243)
    doc.rect(MARGIN, y - 4, WIDTH, 6, 'F')
    doc.setFont('helvetica', 'bold')
    doc.setFontSize(8)
    doc.setTextColor(20)
    let x = MARGIN
    columnas.forEach((columna, index) => {
      const label = pdfSafe(columna.titulo)
      const textX = columna.align === 'right' ? x + widths[index] - doc.getTextWidth(label) - 1 : x + 1
      doc.text(label, textX, y)
      x += widths[index]
    })
    y += 5
  }

  header()
  doc.setFont('helvetica', 'normal')
  doc.setFontSize(8)
  for (const fila of filas) {
    const wrapped = fila.map((celda, index) =>
      doc.splitTextToSize(pdfSafe(celda || '—'), Math.max(widths[index] - 2, 8)),
    )
    const lines = Math.max(...wrapped.map((item) => item.length), 1)
    const height = lines * 3.6 + 1.4
    if (y + height > PAGE_BOTTOM) {
      doc.addPage()
      doc.setFont('helvetica', 'bold')
      doc.setFontSize(9)
      doc.text(pdfSafe(`${reporte.titulo} · continúa`), MARGIN, 14)
      y = 20
      header()
    }
    doc.setFont('helvetica', 'normal')
    doc.setFontSize(8)
    let x = MARGIN
    wrapped.forEach((lineas, index) => {
      const columna = columnas[index]
      lineas.forEach((linea: string, lineIndex: number) => {
        const textX =
          columna.align === 'right'
            ? x + widths[index] - doc.getTextWidth(linea) - 1
            : x + 1
        doc.text(linea, textX, y + lineIndex * 3.6)
      })
      x += widths[index]
    })
    y += height
  }
  return y + 2
}
