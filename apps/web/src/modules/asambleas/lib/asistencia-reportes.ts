import { jsPDF } from 'jspdf'

export interface ReporteTabla {
  titulo: string
  lineas: string[]
  columnas: string[]
  filas: string[][]
  nombreArchivo: string
}

function escapeHtml(value: string) {
  return value
    .replaceAll('&', '&amp;')
    .replaceAll('<', '&lt;')
    .replaceAll('>', '&gt;')
    .replaceAll('"', '&quot;')
}

function escapeXml(value: string) {
  return escapeHtml(value)
}

export function imprimirReporte(reporte: ReporteTabla) {
  const ventana = window.open('', '_blank', 'noopener,noreferrer')
  if (!ventana) return
  const encabezados = reporte.columnas
    .map((columna) => `<th>${escapeHtml(columna)}</th>`)
    .join('')
  const cuerpo = reporte.filas
    .map(
      (fila) =>
        `<tr>${fila.map((celda) => `<td>${escapeHtml(celda)}</td>`).join('')}</tr>`,
    )
    .join('')
  ventana.document.write(`<!doctype html>
<html lang="es">
<head>
  <meta charset="utf-8" />
  <title>${escapeHtml(reporte.titulo)}</title>
  <style>
    body { font-family: Arial, sans-serif; color: #111; margin: 24px; }
    h1 { font-size: 18px; margin: 0 0 8px; }
    p { margin: 0 0 4px; font-size: 12px; }
    table { width: 100%; border-collapse: collapse; margin-top: 16px; font-size: 11px; }
    th, td { border: 1px solid #c5c9d1; padding: 4px 6px; text-align: left; }
    th { background: #e8eef6; }
    @media print { body { margin: 12px; } }
  </style>
</head>
<body>
  <h1>${escapeHtml(reporte.titulo)}</h1>
  ${reporte.lineas.map((linea) => `<p>${escapeHtml(linea)}</p>`).join('')}
  <table>
    <thead><tr>${encabezados}</tr></thead>
    <tbody>${cuerpo}</tbody>
  </table>
</body>
</html>`)
  ventana.document.close()
  ventana.focus()
  ventana.print()
}

export function descargarExcel(reporte: ReporteTabla) {
  const encabezado = `<Row>${reporte.columnas
    .map((columna) => `<Cell><Data ss:Type="String">${escapeXml(columna)}</Data></Cell>`)
    .join('')}</Row>`
  const filas = reporte.filas
    .map(
      (fila) =>
        `<Row>${fila
          .map((celda) => `<Cell><Data ss:Type="String">${escapeXml(celda)}</Data></Cell>`)
          .join('')}</Row>`,
    )
    .join('')
  const xml = `<?xml version="1.0" encoding="UTF-8"?>
<?mso-application progid="Excel.Sheet"?>
<Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet" xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet">
  <Worksheet ss:Name="Asistencia">
    <Table>
      <Row><Cell><Data ss:Type="String">${escapeXml(reporte.titulo)}</Data></Cell></Row>
      ${reporte.lineas
        .map((linea) => `<Row><Cell><Data ss:Type="String">${escapeXml(linea)}</Data></Cell></Row>`)
        .join('')}
      <Row></Row>
      ${encabezado}
      ${filas}
    </Table>
  </Worksheet>
</Workbook>`
  const blob = new Blob([xml], { type: 'application/vnd.ms-excel;charset=utf-8' })
  const url = URL.createObjectURL(blob)
  const enlace = document.createElement('a')
  enlace.href = url
  enlace.download = `${reporte.nombreArchivo}.xls`
  enlace.click()
  URL.revokeObjectURL(url)
}

export function descargarPdf(reporte: ReporteTabla) {
  const doc = new jsPDF({ orientation: 'landscape', unit: 'mm', format: 'a4' })
  const margen = 10
  const ancho = 297 - margen * 2
  const altoPagina = 210
  const columnas = Math.max(reporte.columnas.length, 1)
  const anchoColumna = ancho / columnas
  let y = margen

  const titulo = () => {
    doc.setFont('helvetica', 'bold')
    doc.setFontSize(13)
    doc.text(reporte.titulo, margen, y)
    y += 6
    doc.setFont('helvetica', 'normal')
    doc.setFontSize(9)
    for (const linea of reporte.lineas) {
      doc.text(linea, margen, y)
      y += 4
    }
    y += 2
    pintarFila(reporte.columnas, true)
  }

  const pintarFila = (celdas: string[], encabezado: boolean) => {
    if (y > altoPagina - 12) {
      doc.addPage()
      y = margen
    }
    if (encabezado) {
      doc.setFillColor(232, 238, 246)
      doc.rect(margen, y - 4, ancho, 6, 'F')
      doc.setFont('helvetica', 'bold')
    } else {
      doc.setFont('helvetica', 'normal')
    }
    doc.setFontSize(8)
    celdas.forEach((celda, index) => {
      const texto = doc.splitTextToSize(celda || '—', anchoColumna - 2)[0] ?? ''
      doc.text(String(texto), margen + index * anchoColumna + 1, y)
    })
    y += 5
  }

  titulo()
  for (const fila of reporte.filas) {
    if (y > altoPagina - 12) {
      doc.addPage()
      y = margen
      pintarFila(reporte.columnas, true)
    }
    pintarFila(fila, false)
  }
  doc.save(`${reporte.nombreArchivo}.pdf`)
}
