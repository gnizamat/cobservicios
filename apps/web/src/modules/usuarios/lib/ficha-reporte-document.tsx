import { EMISOR_RECIBO } from '@/modules/facturacion/lib/recibo-document'
import type { ReporteFicha } from '@/modules/usuarios/lib/ficha-reporte'

export const fichaReporteCss = `
  .ficha-reporte { width: 190mm; max-width: 100%; margin: 0 auto; color: #1a1a1a; background: #fff; font-family: Arial, Helvetica, sans-serif; font-size: 11px; line-height: 1.35; }
  .ficha-reporte * { box-sizing: border-box; }
  .ficha-reporte-head { display: flex; gap: 10px; align-items: center; justify-content: center; text-align: center; margin-bottom: 8px; }
  .ficha-reporte-logo { width: 42px; height: 42px; flex: none; }
  .ficha-reporte-head strong { display: block; font-size: 13px; letter-spacing: 0.02em; }
  .ficha-reporte-head span { display: block; font-size: 12px; font-weight: 700; }
  .ficha-reporte-top { display: grid; grid-template-columns: 1.15fr 0.85fr; gap: 12px; align-items: stretch; margin-bottom: 8px; }
  .ficha-reporte-identidad { border: 1.5px solid #1a1a1a; border-radius: 8px; padding: 6px 8px; }
  .ficha-reporte-identidad p { margin: 0 0 2px; }
  .ficha-reporte-titulo { display: flex; flex-direction: column; align-items: center; justify-content: center; text-align: center; font-weight: 800; font-size: 16px; letter-spacing: 0.03em; }
  .ficha-reporte-titulo small { display: block; margin-top: 2px; font-size: 12px; font-weight: 700; }
  .ficha-reporte h3 { margin: 8px 0 0; padding: 3px 6px; background: #1d4f9c; color: #fff; font-size: 11px; letter-spacing: 0.04em; }
  .ficha-reporte-nota { margin: 4px 0; font-size: 11px; }
  .ficha-reporte-pares { width: 100%; border-collapse: collapse; margin: 4px 0 8px; }
  .ficha-reporte-pares td { padding: 2px 4px; vertical-align: top; }
  .ficha-reporte-pares .etiqueta { width: 28%; font-weight: 700; }
  .ficha-reporte table.datos { width: 100%; border-collapse: collapse; margin: 4px 0 8px; }
  .ficha-reporte table.datos th, .ficha-reporte table.datos td { border: 1px solid #bbb; padding: 3px 4px; text-align: left; vertical-align: top; }
  .ficha-reporte table.datos th { background: #f3f3f3; font-size: 10px; }
  .ficha-reporte .num { text-align: right; font-variant-numeric: tabular-nums; white-space: nowrap; }
  .ficha-reporte-vacio { margin: 6px 4px 10px; color: #444; }
  .ficha-reporte-saldo { margin: 8px 0 0; color: #c51616; font-weight: 800; font-size: 14px; }
  @page { size: A4; margin: 10mm; }
  @media print { body { margin: 0; } .ficha-reporte { width: auto; } }
`

function Logo() {
  return (
    <svg className="ficha-reporte-logo" viewBox="0 0 64 64" aria-hidden="true">
      <path d="M32 6c-2 8-14 18-14 32a14 14 0 0 0 28 0C46 24 34 14 32 6z" fill="#1d4f9c" />
      <path d="M28 38c2 6 8 8 10 4" fill="none" stroke="#fff" strokeWidth="3" />
    </svg>
  )
}

export function FichaReporteDocument({ reporte }: { reporte: ReporteFicha }) {
  return (
    <article className="ficha-reporte">
      <header className="ficha-reporte-head">
        <Logo />
        <div>
          <strong>{EMISOR_RECIBO.titulo}</strong>
          <span>{EMISOR_RECIBO.lugar}</span>
        </div>
      </header>

      <div className="ficha-reporte-top">
        <div className="ficha-reporte-identidad">
          <p>
            <b>USUARIO:</b> {reporte.usuario}
          </p>
          <p>
            <b>DOCUMENTO:</b> {reporte.documento}
          </p>
          <p>
            <b>DIRECCIÓN:</b> {reporte.direccion}
          </p>
          <p>
            <b>FECHA DE EMISIÓN:</b> {reporte.emision}
          </p>
        </div>
        <div className="ficha-reporte-titulo">
          REPORTE
          <small>{reporte.titulo.toUpperCase()}</small>
        </div>
      </div>

      {reporte.bloques.map((bloque) => (
        <section key={bloque.titulo}>
          <h3>{bloque.titulo.toUpperCase()}</h3>
          {bloque.nota ? <p className="ficha-reporte-nota">{bloque.nota}</p> : null}
          {bloque.pares ? (
            <table className="ficha-reporte-pares">
              <tbody>
                {bloque.pares.map((par) => (
                  <tr key={par.etiqueta}>
                    <td className="etiqueta">{par.etiqueta}</td>
                    <td>{par.valor}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          ) : null}
          {bloque.columnas ? (
            bloque.filas && bloque.filas.length > 0 ? (
              <table className="datos">
                <thead>
                  <tr>
                    {bloque.columnas.map((columna) => (
                      <th key={columna.titulo} className={columna.align === 'right' ? 'num' : undefined}>
                        {columna.titulo}
                      </th>
                    ))}
                  </tr>
                </thead>
                <tbody>
                  {bloque.filas.map((fila, index) => (
                    <tr key={`${bloque.titulo}-${index}`}>
                      {fila.map((celda, columna) => (
                        <td
                          key={`${bloque.titulo}-${index}-${columna}`}
                          className={bloque.columnas?.[columna]?.align === 'right' ? 'num' : undefined}
                        >
                          {celda}
                        </td>
                      ))}
                    </tr>
                  ))}
                </tbody>
              </table>
            ) : (
              <p className="ficha-reporte-vacio">Sin registros.</p>
            )
          ) : null}
        </section>
      ))}

      {reporte.saldo ? <p className="ficha-reporte-saldo">SALDO PENDIENTE: {reporte.saldo}</p> : null}
    </article>
  )
}

export function imprimirReporteFicha(titulo: string, bodyHtml: string) {
  const iframe = document.createElement('iframe')
  iframe.setAttribute('aria-hidden', 'true')
  iframe.style.cssText = 'position:fixed;width:0;height:0;border:0;right:0;bottom:0'
  document.body.appendChild(iframe)
  const doc = iframe.contentDocument
  const win = iframe.contentWindow
  if (!doc || !win) {
    iframe.remove()
    return
  }
  const safeTitle = titulo.replace(/[&<>"]/g, '')
  doc.open()
  doc.write(
    `<!doctype html><html><head><meta charset="utf-8"><title>${safeTitle}</title><style>${fichaReporteCss}</style></head><body>${bodyHtml}</body></html>`,
  )
  doc.close()
  win.onafterprint = () => window.setTimeout(() => iframe.remove(), 300)
  window.setTimeout(() => {
    win.focus()
    win.print()
  }, 200)
}
