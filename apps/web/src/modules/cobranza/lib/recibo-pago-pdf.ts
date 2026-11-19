import { jsPDF } from 'jspdf'
import { code39Bars } from '@/modules/facturacion/lib/code39'
import { formatFecha, mesLabel } from '@/modules/cobranza/labels'
import { AVISO_PAGO, montoRecibo } from '@/modules/cobranza/lib/recibo-pago-document'
import { solesEnLetras } from '@/modules/cobranza/lib/soles-letras'
import type { ReciboPago } from '@/modules/cobranza/api/cobranza-api'

const BLUE: [number, number, number] = [29, 79, 156]

function drawBarcode(doc: jsPDF, value: string, x: number, y: number, maxWidth: number, height: number) {
  const bars = code39Bars(value)
  const units = bars.reduce((sum, bar) => sum + bar.width, 0)
  const scale = maxWidth / units
  doc.setFillColor(17, 17, 17)
  let cursor = x
  for (const bar of bars) {
    const width = bar.width * scale
    if (bar.black) doc.rect(cursor, y, width, height, 'F')
    cursor += width
  }
}

async function logoData(url: string | null) {
  if (!url) return null
  try {
    const response = await fetch(url)
    if (!response.ok) return null
    const blob = await response.blob()
    return await new Promise<string>((resolve, reject) => {
      const reader = new FileReader()
      reader.onload = () => resolve(String(reader.result))
      reader.onerror = () => reject(reader.error)
      reader.readAsDataURL(blob)
    })
  } catch {
    return null
  }
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

export async function downloadReciboPagoPdf(recibo: ReciboPago) {
  const doc = new jsPDF({ unit: 'mm', format: 'a4' })
  const logo = await logoData(recibo.emisor.logoUrl)
  if (logo) {
    const format = logo.startsWith('data:image/png') ? 'PNG' : 'JPEG'
    doc.addImage(logo, format, 12, 10, 16, 16)
  }

  doc.setFont('helvetica', 'bold')
  doc.setFontSize(11)
  doc.text(recibo.emisor.nombre, 108, 14, { align: 'center', maxWidth: 110 })
  let headY = 20
  if (recibo.emisor.abreviatura) {
    doc.setFontSize(10)
    doc.text(recibo.emisor.abreviatura, 108, headY, { align: 'center' })
    headY += 5
  }
  doc.setFontSize(10)
  doc.text(`JASS LOCAL: ${recibo.sector || '—'}`, 108, headY, { align: 'center' })
  headY += 5
  doc.setFont('helvetica', 'normal')
  doc.setFontSize(9)
  if (recibo.emisor.direccion) {
    doc.text(recibo.emisor.direccion, 108, headY, { align: 'center', maxWidth: 100 })
    headY += 4
  }
  if (recibo.emisor.celular) doc.text(`Cel. ${recibo.emisor.celular}`, 108, headY, { align: 'center' })

  doc.setDrawColor(20)
  doc.rect(148, 10, 50, 28)
  doc.setFont('helvetica', 'bold')
  doc.setFontSize(8)
  doc.text('N° RECIBO:', 173, 15, { align: 'center' })
  doc.setFontSize(10)
  doc.text(recibo.numero, 173, 21, { align: 'center' })
  drawBarcode(doc, recibo.numero, 151, 24, 44, 10)

  doc.setFontSize(14)
  doc.text('RECIBO DE PAGO SERVICIO', 105, 46, { align: 'center' })
  doc.setFontSize(10)
  doc.text(`FECHA PAGO: ${formatFecha(recibo.fecha)}`, 14, 54)
  doc.text(`AÑO: ${recibo.anio}`, 196, 54, { align: 'right' })

  let y = band(doc, 'DATOS DEL USUARIO Y PREDIO', 58)
  doc.setFontSize(9)
  const filas: Array<[string, string, string, string]> = [
    ['CODIGO:', recibo.codigo, 'C. POBLADO:', recibo.sector],
    ['USUARIO:', recibo.usuario, 'DNI:', recibo.documento],
    ['PREDIO:', recibo.predio, 'N° CASA:', recibo.numeroCasa],
    ['MANZANA:', recibo.manzana, 'LOTE:', recibo.lote],
    ['CALLE:', recibo.calle, 'SECTOR:', recibo.sector],
  ]
  for (const [leftLabel, leftValue, rightLabel, rightValue] of filas) {
    doc.setFont('helvetica', 'bold')
    doc.text(leftLabel, 14, y)
    doc.text(rightLabel, 112, y)
    doc.setFont('helvetica', 'normal')
    doc.text(leftValue, 36, y, { maxWidth: 70 })
    doc.text(rightValue, 136, y, { maxWidth: 60 })
    y += 5
  }

  y += 2
  doc.setFillColor(...BLUE)
  doc.rect(12, y, 186, 6, 'F')
  doc.setTextColor(255)
  doc.setFont('helvetica', 'bold')
  doc.setFontSize(8)
  const headers = ['N° FACTURA', 'AÑO', 'MES', 'SERVICIO', 'VOLUMEN M3', 'MONTO S/']
  const columns = [14, 48, 62, 90, 150, 176]
  headers.forEach((header, index) => doc.text(header, columns[index], y + 4.2))
  doc.setTextColor(20)
  y += 10
  doc.setFont('helvetica', 'normal')
  doc.setFontSize(8.5)
  for (const linea of recibo.lineas) {
    if (y > 250) {
      doc.addPage()
      y = 16
    }
    doc.text(linea.factura, columns[0], y)
    doc.text(String(linea.anio), columns[1], y)
    doc.text(mesLabel(linea.mes), columns[2], y)
    doc.text(linea.servicio || '—', columns[3], y, { maxWidth: 55 })
    doc.text(linea.volumen > 0 ? montoRecibo(linea.volumen) : '—', columns[4], y)
    doc.text(montoRecibo(linea.monto), columns[5], y)
    y += 5
  }

  y += 2
  doc.setFont('helvetica', 'bold')
  doc.setFontSize(10)
  doc.text(`MONTO PAGADO S/:  ${montoRecibo(recibo.monto)}`, 196, y, { align: 'right' })
  y += 8
  doc.text(solesEnLetras(recibo.monto), 14, y)
  y += 8
  doc.setTextColor(...BLUE)
  doc.setFontSize(9)
  const aviso = doc.splitTextToSize(AVISO_PAGO, 180)
  doc.text(aviso, 105, y, { align: 'center' })

  doc.save(`${recibo.numero}.pdf`)
}
