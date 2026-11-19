import { reciboCss } from '@/modules/facturacion/lib/recibo-document'

export function imprimirRecibo(title: string, bodyHtml: string) {
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
  const safeTitle = title.replace(/[&<>"]/g, '')
  doc.open()
  doc.write(
    `<!doctype html><html><head><meta charset="utf-8"><title>${safeTitle}</title><style>${reciboCss}</style></head><body>${bodyHtml}</body></html>`,
  )
  doc.close()
  win.onafterprint = () => window.setTimeout(() => iframe.remove(), 300)
  window.setTimeout(() => {
    win.focus()
    win.print()
  }, 200)
}
