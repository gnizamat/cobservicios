import { code39Bars } from '@/modules/facturacion/lib/code39'
import { formatAmount, formatDate, mesLabel } from '@/modules/facturacion/labels'
import type { ReciboFactura } from '@/modules/facturacion/types'

export const EMISOR_RECIBO = {
  titulo: 'JUNTA ADMINISTRADORA DE SERVICIO DE AGUA POTABLE',
  lugar: 'CP. NUEVO TALLAN',
}

export const AVISO_RECIBO =
  'Amig@ usuario: al segundo mes consecutivo de deuda se efectúa el corte del servicio. Verificá tus conexiones de agua para evitar fugas.'

export const reciboCss = `
  .recibo { width: 190mm; max-width: 100%; margin: 0 auto; color: #1a1a1a; background: #fff; font-family: Arial, Helvetica, sans-serif; font-size: 11px; line-height: 1.35; }
  .recibo * { box-sizing: border-box; }
  .recibo-head { display: flex; gap: 10px; align-items: center; justify-content: center; text-align: center; margin-bottom: 8px; }
  .recibo-logo { width: 42px; height: 42px; flex: none; }
  .recibo-head strong { display: block; font-size: 13px; letter-spacing: 0.02em; }
  .recibo-head span { display: block; font-size: 12px; font-weight: 700; }
  .recibo-top { display: grid; grid-template-columns: 1fr 1fr; gap: 12px; align-items: stretch; margin-bottom: 8px; }
  .recibo-periodo { border: 1.5px solid #1a1a1a; border-radius: 8px; padding: 6px 8px; }
  .recibo-periodo b { font-size: 13px; }
  .recibo-calle { margin-top: 4px; font-weight: 700; letter-spacing: 0.04em; }
  .recibo-titulo { display: flex; flex-direction: column; align-items: center; justify-content: center; text-align: center; font-weight: 800; font-size: 16px; letter-spacing: 0.03em; }
  .recibo-titulo small { display: block; margin-top: 2px; font-size: 13px; }
  .recibo h3 { margin: 0; padding: 3px 6px; background: #1d4f9c; color: #fff; font-size: 11px; letter-spacing: 0.04em; }
  .recibo-datos, .recibo-lecturas, .recibo-stub table { width: 100%; border-collapse: collapse; margin-bottom: 8px; }
  .recibo-datos td { padding: 2px 4px; vertical-align: top; }
  .recibo-datos .etiqueta { width: 18%; color: #333; font-weight: 700; }
  .recibo-cols { display: grid; grid-template-columns: 1fr 1fr; gap: 8px; margin-bottom: 8px; }
  .recibo-panel { border: 1px solid #c5c5c5; min-height: 92px; }
  .recibo-linea, .recibo-total { display: flex; justify-content: space-between; gap: 8px; padding: 2px 6px; }
  .recibo-total { font-weight: 800; border-top: 1px solid #1a1a1a; margin-top: 4px; }
  .recibo-lecturas th, .recibo-lecturas td { border: 1px solid #bbb; padding: 3px 4px; text-align: center; }
  .recibo-lecturas th { background: #f3f3f3; font-size: 10px; }
  .recibo-saldo { margin: 8px 0; color: #c51616; font-weight: 800; font-size: 14px; }
  .recibo-aviso { color: #c51616; font-weight: 700; text-align: center; margin: 10px 12px; }
  .recibo-fechas { display: flex; justify-content: space-between; gap: 12px; margin-bottom: 8px; font-weight: 700; }
  .recibo-corte { border: none; border-top: 1px dashed #666; margin: 12px 0; }
  .recibo-stub { border: 1px solid #1a1a1a; padding: 6px; }
  .recibo-pagar { float: right; width: 46%; border: 1.5px solid #1a1a1a; }
  .recibo-pagar div { display: flex; justify-content: space-between; padding: 3px 6px; }
  .recibo-pagar .final { font-weight: 800; border-top: 1px solid #1a1a1a; }
  .recibo-barcode { display: block; width: 180px; height: 36px; margin-top: 6px; }
  @page { size: A4; margin: 10mm; }
  @media print { body { margin: 0; } .recibo { width: auto; } }
`

function amount(value: number | null) {
  if (value == null) return ''
  return formatAmount(value)
}

function Barcode({ value }: { value: string }) {
  const bars = code39Bars(value)
  const width = bars.reduce((sum, bar) => sum + bar.width, 0)
  let x = 0
  return (
    <svg className="recibo-barcode" viewBox={`0 0 ${width} 42`} role="img" aria-label={value}>
      {bars.map((bar, index) => {
        const rect = bar.black ? (
          <rect key={index} x={x} y="0" width={bar.width} height="42" fill="#111" />
        ) : null
        x += bar.width
        return rect
      })}
    </svg>
  )
}

function Logo() {
  return (
    <svg className="recibo-logo" viewBox="0 0 64 64" aria-hidden="true">
      <path
        d="M32 6c-2 8-14 18-14 32a14 14 0 0 0 28 0C46 24 34 14 32 6z"
        fill="#1d4f9c"
      />
      <path d="M28 38c2 6 8 8 10 4" fill="none" stroke="#fff" strokeWidth="3" />
    </svg>
  )
}

export function ReciboDocument({ recibo }: { recibo: ReciboFactura }) {
  const periodo = `${mesLabel(recibo.mes)} ${recibo.anio}`
  const predio = [recibo.predio, recibo.numeroPredio].filter(Boolean).join(' ')
  return (
    <article className="recibo">
      <header className="recibo-head">
        <Logo />
        <div>
          <strong>{EMISOR_RECIBO.titulo}</strong>
          <span>{EMISOR_RECIBO.lugar}</span>
        </div>
      </header>

      <div className="recibo-top">
        <div className="recibo-periodo">
          <div>
            PERIODO: <b>{periodo}</b>
          </div>
          <div>
            RECIBO N°: <b>{recibo.numero}</b>
          </div>
          <div className="recibo-calle">{recibo.calle.toUpperCase()}</div>
        </div>
        <div className="recibo-titulo">
          RECIBO DE FACTURACION
          <small>SERVICIO AGUA</small>
        </div>
      </div>

      <h3>DATOS DEL USUARIO Y PREDIO</h3>
      <table className="recibo-datos">
        <tbody>
          <tr>
            <td className="etiqueta">CODIGO:</td>
            <td>{recibo.codigo}</td>
            <td className="etiqueta">CP:</td>
            <td>{recibo.sector}</td>
          </tr>
          <tr>
            <td className="etiqueta">USUARIO:</td>
            <td>{recibo.usuario}</td>
            <td className="etiqueta">DOCUMENTO:</td>
            <td>{recibo.documento}</td>
          </tr>
          <tr>
            <td className="etiqueta">PREDIO:</td>
            <td>{predio}</td>
            <td className="etiqueta">N° CASA:</td>
            <td>{recibo.numeroPredio}</td>
          </tr>
          <tr>
            <td className="etiqueta">MANZANA:</td>
            <td>{recibo.manzana}</td>
            <td className="etiqueta">LOTE:</td>
            <td>{recibo.lote}</td>
          </tr>
        </tbody>
      </table>

      <div className="recibo-cols">
        <section className="recibo-panel">
          <h3>DATOS DE SUMINISTRO Y CONSUMO</h3>
          {recibo.lineas.map((linea) => (
            <div className="recibo-linea" key={`costo-${linea.servicio}`}>
              <span>Costo servicio S/: {linea.servicio}</span>
              <b>{formatAmount(linea.costo)}</b>
            </div>
          ))}
          <div className="recibo-linea">
            <span>Lectura actual</span>
            <b>{amount(recibo.lecturaActual)}</b>
          </div>
        </section>
        <section className="recibo-panel">
          <h3>IMPORTES FACTURADOS</h3>
          <div className="recibo-linea">
            <span>Volumen (m³)</span>
            <b>{formatAmount(recibo.volumen)}</b>
          </div>
          {recibo.lineas.map((linea) => (
            <div className="recibo-linea" key={`monto-${linea.servicio}`}>
              <span>Monto fact. S/: {linea.servicio}</span>
              <b>{formatAmount(linea.monto)}</b>
            </div>
          ))}
          <div className="recibo-linea">
            <span>Redondeo (S/)</span>
            <b>0.00</b>
          </div>
          <div className="recibo-total">
            <span>Total facturado mes (S/)</span>
            <span>{formatAmount(recibo.monto)}</span>
          </div>
        </section>
      </div>

      <table className="recibo-lecturas">
        <thead>
          <tr>
            <th>U. lectura</th>
            <th>Año</th>
            <th>Mes</th>
            <th>Lectura (m³)</th>
            <th>Dif. lectura (m³)</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>{amount(recibo.lecturaAnterior)}</td>
            <td>{recibo.lecturaActual == null ? '' : recibo.anio}</td>
            <td>{recibo.lecturaActual == null ? '' : mesLabel(recibo.mes)}</td>
            <td>{amount(recibo.lecturaActual)}</td>
            <td>{amount(recibo.diferencia)}</td>
          </tr>
        </tbody>
      </table>

      <div className="recibo-saldo">SALDO ANTERIOR S/: {formatAmount(recibo.saldoAnterior)}</div>
      <p className="recibo-aviso">{AVISO_RECIBO}</p>
      <div className="recibo-fechas">
        <span>FECHA DE EMISION: {formatDate(recibo.fecha)}</span>
        <span>FECHA DE VENCIMIENTO: {formatDate(recibo.vencimiento)}</span>
      </div>
      <hr className="recibo-corte" />

      <section className="recibo-stub">
        <div className="recibo-pagar">
          <div>
            <span>RECIBO N°</span>
            <b>{recibo.numero}</b>
          </div>
          <div>
            <span>PERIODO</span>
            <b>{periodo}</b>
          </div>
          <div>
            <span>TOTAL RECIBO DEL MES S/</span>
            <b>{formatAmount(recibo.monto)}</b>
          </div>
          <div className="final">
            <span>TOTAL A PAGAR S/</span>
            <b>{formatAmount(recibo.totalPagar)}</b>
          </div>
        </div>
        <div>
          <div>USUARIO: {recibo.usuario}</div>
          <div>DOCUMENTO: {recibo.documento}</div>
          <div>{recibo.calle.toUpperCase()}</div>
          <div>
            MANZANA: {recibo.manzana || '—'} &nbsp; LOTE: {recibo.lote || '—'}
          </div>
          <Barcode value={recibo.numero} />
        </div>
      </section>
    </article>
  )
}
