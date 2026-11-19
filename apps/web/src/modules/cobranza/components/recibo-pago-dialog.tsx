import { useEffect, useRef, useState } from 'react'
import { Printer, X } from 'lucide-react'
import { Button, Icon } from '@/design-system/atoms'
import { useReciboPago } from '@/modules/cobranza/api'
import { ReciboPagoDocument, reciboPagoCss } from '@/modules/cobranza/lib/recibo-pago-document'
import { downloadReciboPagoPdf } from '@/modules/cobranza/lib/recibo-pago-pdf'
import { imprimirReciboPago } from '@/modules/cobranza/lib/recibo-pago-print'

export function ReciboPagoDialog({ id, onClose }: { id: string; onClose: () => void }) {
  const recibo = useReciboPago(id)
  const sheet = useRef<HTMLDivElement>(null)
  const [exporting, setExporting] = useState(false)

  useEffect(() => {
    function onKey(event: KeyboardEvent) {
      if (event.key === 'Escape') onClose()
    }
    window.addEventListener('keydown', onKey)
    return () => window.removeEventListener('keydown', onKey)
  }, [onClose])

  function imprimir() {
    const article = sheet.current?.querySelector('.pago')
    if (!article || !recibo.data) return
    imprimirReciboPago(recibo.data.numero, article.outerHTML)
  }

  async function exportar() {
    if (!recibo.data) return
    setExporting(true)
    try {
      await downloadReciboPagoPdf(recibo.data)
    } finally {
      setExporting(false)
    }
  }

  return (
    <div className="fixed inset-0 z-50 flex items-start justify-center overflow-y-auto bg-foreground/40 p-4" role="presentation">
      <div
        role="dialog"
        aria-modal="true"
        aria-labelledby="recibo-pago-titulo"
        className="my-4 w-full max-w-4xl rounded-2xl border border-border bg-card p-4 shadow-[var(--shadow-sm)]"
      >
        <div className="mb-3 flex flex-wrap items-center justify-between gap-2">
          <h3 id="recibo-pago-titulo" className="text-base font-semibold">
            Recibo de pago
          </h3>
          <div className="flex flex-wrap gap-2">
            <Button type="button" size="sm" disabled={!recibo.data} onClick={imprimir}>
              <Icon icon={Printer} size={14} />
              Imprimir
            </Button>
            <Button type="button" size="sm" variant="secondary" disabled={!recibo.data || exporting} onClick={() => void exportar()}>
              {exporting ? 'Exportando…' : 'Exportar PDF'}
            </Button>
            <Button type="button" size="sm" variant="ghost" onClick={onClose}>
              <Icon icon={X} size={14} />
              Cerrar
            </Button>
          </div>
        </div>

        {recibo.isLoading ? <p className="text-sm text-muted-foreground">Cargando el recibo…</p> : null}
        {recibo.isError ? (
          <p role="alert" className="text-sm text-destructive">
            {(recibo.error as Error).message}
          </p>
        ) : null}
        {recibo.data ? (
          <div ref={sheet} className="overflow-x-auto rounded-lg border border-border bg-white p-4">
            <style>{reciboPagoCss}</style>
            <ReciboPagoDocument recibo={recibo.data} />
          </div>
        ) : null}
      </div>
    </div>
  )
}
