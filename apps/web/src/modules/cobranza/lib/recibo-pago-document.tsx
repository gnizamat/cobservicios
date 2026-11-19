import { code39Bars } from '@/modules/facturacion/lib/code39'
import { formatFecha, mesLabel } from '@/modules/cobranza/labels'
import { solesEnLetras } from '@/modules/cobranza/lib/soles-letras'
import type { ReciboPago } from '@/modules/cobranza/api/cobranza-api'

export const AVISO_PAGO =
  'Amig@ usuari@: al tercer mes consecutivo de deuda se efectúa el corte del servicio de agua. Paga puntualmente tus servicios y evita molestias. El agua es vida, cuídala. No la desperdicies.'

const amount = new Intl.NumberFormat('es-PE', {
  minimumFractionDigits: 2,
  maximumFractionDigits: 2,
})

export function montoRecibo(value: number) {
  return amount.format(value)
}

export const reciboPagoCss = `
  .pago { width: 190mm; max-width: 100%; margin: 0 auto; color: #1a1a1a; background: #fff; font-family: Arial, Helvetica, sans-serif; font-size: 11px; line-height: 1.35; }
  .pago * { box-sizing: border-box; }
  .pago-head { display: grid; grid-template-columns: 52px 1fr 58mm; gap: 10px; align-items: start; }
  .pago-logo { width: 52px; height: 52px; object-fit: contain; }
  .pago-emisor { text-align: center; }
  .pago-emisor strong, .pago-emisor span, .pago-emisor small { display: block; }
  .pago-emisor strong { font-size: 13px; letter-spacing: 0.02em; }
  .pago-emisor span { margin-top: 2px; font-size: 12px; font-weight: 700; }
  .pago-emisor small { margin-top: 2px; font-size: 11px; }
  .pago-nro { border: 1.5px solid #1a1a1a; padding: 6px 8px 4px; text-align: center; }
  .pago-nro b { display: block; margin-top: 2px; font-size: 13px; letter-spacing: 0.03em; }
  .pago-barcode { display: block; width: 100%; height: 38px; margin-top: 4px; }
  .pago-titulo { margin: 10px 0 6px; text-align: center; font-size: 16px; font-weight: 800; letter-spacing: 0.04em; }
  .pago-fechas { display: flex; justify-content: space-between; gap: 12px; margin-bottom: 8px; font-weight: 700; }
  .pago h3 { margin: 0; padding: 3px 6px; background: #1d4f9c; color: #fff; font-size: 11px; letter-spacing: 0.04em; }
  .pago-datos { width: 100%; border-collapse: collapse; margin-bottom: 8px; }
  .pago-datos td { padding: 2px 4px; vertical-align: top; }
  .pago-datos .etiqueta { width: 14%; font-weight: 700; }
  .pago-lineas { width: 100%; border-collapse: collapse; margin-bottom: 6px; }
  .pago-lineas th { background: #1d4f9c; color: #fff; padding: 3px 4px; font-size: 10px; text-align: left; }
  .pago-lineas td { padding: 3px 4px; border-bottom: 1px solid #d0d0d0; }
  .pago-lineas .num, .pago-total { text-align: right; font-variant-numeric: tabular-nums; }
  .pago-total { margin: 4px 0 8px; text-align: right; font-weight: 800; }
  .pago-letras { margin: 8px 0; font-weight: 800; letter-spacing: 0.02em; }
  .pago-aviso { margin: 12px 8px 0; color: #1d4ed8; font-weight: 700; text-align: center; }
  @page { size: A4; margin: 10mm; }
  @media print { body { margin: 0; } .pago { width: auto; } }
`

function Barcode({ value }: { value: string }) {
  const bars = code39Bars(value)
  const width = bars.reduce((sum, bar) => sum + bar.width, 0)
  let x = 0
  return (
    <svg className="pago-barcode" viewBox={`0 0 ${width} 42`} role="img" aria-label={`Código de barras ${value}`}>
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

function Logo({ src }: { src: string | null }) {
  if (src) return <img className="pago-logo" src={src} alt="" />
  return (
    <svg className="pago-logo" viewBox="0 0 64 64" aria-hidden="true">
      <path d="M32 6c-2 8-14 18-14 32a14 14 0 0 0 28 0C46 24 34 14 32 6z" fill="#1d4f9c" />
      <path d="M28 38c2 6 8 8 10 4" fill="none" stroke="#fff" strokeWidth="3" />
    </svg>
  )
}

function texto(value: string) {
  return value.trim()
}

export function ReciboPagoDocument({ recibo }: { recibo: ReciboPago }) {
  return (
    <article className="pago">
      <header className="pago-head">
        <Logo src={recibo.emisor.logoUrl} />
        <div className="pago-emisor">
          <strong>{recibo.emisor.nombre}</strong>
          {recibo.emisor.abreviatura ? <span>{recibo.emisor.abreviatura}</span> : null}
          <span>JASS LOCAL: {texto(recibo.sector)}</span>
          {recibo.emisor.direccion ? <small>{recibo.emisor.direccion}</small> : null}
          {recibo.emisor.celular ? <small>Cel. {recibo.emisor.celular}</small> : null}
        </div>
        <div className="pago-nro">
          <div>N° RECIBO:</div>
          <b>{recibo.numero}</b>
          <Barcode value={recibo.numero} />
        </div>
      </header>

      <h2 className="pago-titulo">RECIBO DE PAGO SERVICIO</h2>
      <div className="pago-fechas">
        <span>FECHA PAGO: {formatFecha(recibo.fecha)}</span>
        <span>AÑO: {recibo.anio}</span>
      </div>

      <h3>DATOS DEL USUARIO Y PREDIO</h3>
      <table className="pago-datos">
        <tbody>
          <tr>
            <td className="etiqueta">CODIGO:</td>
            <td>{texto(recibo.codigo)}</td>
            <td className="etiqueta">C. POBLADO:</td>
            <td>{texto(recibo.sector)}</td>
          </tr>
          <tr>
            <td className="etiqueta">USUARIO:</td>
            <td>{texto(recibo.usuario)}</td>
            <td className="etiqueta">DNI:</td>
            <td>{texto(recibo.documento)}</td>
          </tr>
          <tr>
            <td className="etiqueta">PREDIO:</td>
            <td>{texto(recibo.predio)}</td>
            <td className="etiqueta">N° CASA:</td>
            <td>{texto(recibo.numeroCasa)}</td>
            <td className="etiqueta">MANZANA:</td>
            <td>{texto(recibo.manzana)}</td>
            <td className="etiqueta">LOTE:</td>
            <td>{texto(recibo.lote)}</td>
          </tr>
          <tr>
            <td className="etiqueta">CALLE:</td>
            <td colSpan={3}>{texto(recibo.calle)}</td>
            <td className="etiqueta">SECTOR:</td>
            <td colSpan={3}>{texto(recibo.sector)}</td>
          </tr>
        </tbody>
      </table>

      <table className="pago-lineas">
        <thead>
          <tr>
            <th>N° factura</th>
            <th>Año</th>
            <th>Mes</th>
            <th>Servicio</th>
            <th className="num">Volumen m³</th>
            <th className="num">Monto S/</th>
          </tr>
        </thead>
        <tbody>
          {recibo.lineas.map((linea, index) => (
            <tr key={`${linea.factura}-${linea.servicio}-${index}`}>
              <td>{linea.factura}</td>
              <td>{linea.anio}</td>
              <td>{mesLabel(linea.mes)}</td>
              <td>{linea.servicio || '—'}</td>
              <td className="num">{linea.volumen > 0 ? montoRecibo(linea.volumen) : '—'}</td>
              <td className="num">{montoRecibo(linea.monto)}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <p className="pago-total">MONTO PAGADO S/: {montoRecibo(recibo.monto)}</p>
      <p className="pago-letras">{solesEnLetras(recibo.monto)}</p>
      <p className="pago-aviso">{AVISO_PAGO}</p>
    </article>
  )
}
