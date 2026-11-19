import { useEffect, useRef } from 'react'
import { Printer, X } from 'lucide-react'
import { Button, Icon } from '@/design-system/atoms'
import { useRecibo } from '@/modules/facturacion/api'
import { ReciboDocument, reciboCss } from '@/modules/facturacion/lib/recibo-document'
import { downloadReciboPdf } from '@/modules/facturacion/lib/recibo-pdf'
import { imprimirRecibo } from '@/modules/facturacion/lib/recibo-print'

export function ReciboDialog({ id, onClose }: { id: string; onClose: () => void }) {
  const recibo = useRecibo(id)
  const sheet = useRef<HTMLDivElement>(null)

  useEffect(() => {
    function onKey(event: KeyboardEvent) {
      if (event.key === 'Escape') onClose()
    }
    window.addEventListener('keydown', onKey)
    return () => window.removeEventListener('keydown', onKey)
  }, [onClose])

  function imprimir() {
    const article = sheet.current?.querySelector('.recibo')
    if (!article || !recibo.data) return
    imprimirRecibo(recibo.data.numero, article.outerHTML)
  }

  return (
    <div className="fixed inset-0 z-50 flex items-start justify-center overflow-y-auto bg-foreground/40 p-4" role="presentation">
      <div
        role="dialog"
        aria-modal="true"
        aria-labelledby="recibo-titulo"
        className="my-4 w-full max-w-4xl rounded-2xl border border-border bg-card p-4 shadow-[var(--shadow-sm)]"
      >
        <div className="mb-3 flex flex-wrap items-center justify-between gap-2">
          <h3 id="recibo-titulo" className="text-base font-semibold">
            Recibo de facturación
          </h3>
          <div className="flex flex-wrap gap-2">
            <Button type="button" size="sm" disabled={!recibo.data} onClick={imprimir}>
              <Icon icon={Printer} size={14} />
              Imprimir
            </Button>
            <Button
              type="button"
              size="sm"
              variant="secondary"
              disabled={!recibo.data}
              onClick={() => {
                if (recibo.data) downloadReciboPdf(recibo.data)
              }}
            >
              Exportar PDF
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
            <style>{reciboCss}</style>
            <ReciboDocument recibo={recibo.data} />
          </div>
        ) : null}
      </div>
    </div>
  )
}
