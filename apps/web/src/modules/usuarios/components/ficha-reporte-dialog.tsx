import { useEffect, useRef } from 'react'
import { Printer, X } from 'lucide-react'
import { Button, Icon } from '@/design-system/atoms'
import {
  FichaReporteDocument,
  fichaReporteCss,
  imprimirReporteFicha,
} from '@/modules/usuarios/lib/ficha-reporte-document'
import { downloadReporteFichaPdf } from '@/modules/usuarios/lib/ficha-reporte-pdf'
import type { ReporteFicha } from '@/modules/usuarios/lib/ficha-reporte'

export function FichaReporteDialog({
  reporte,
  onClose,
}: {
  reporte: ReporteFicha
  onClose: () => void
}) {
  const sheet = useRef<HTMLDivElement>(null)

  useEffect(() => {
    function onKey(event: KeyboardEvent) {
      if (event.key === 'Escape') onClose()
    }
    window.addEventListener('keydown', onKey)
    return () => window.removeEventListener('keydown', onKey)
  }, [onClose])

  function imprimir() {
    const article = sheet.current?.querySelector('.ficha-reporte')
    if (!article) return
    imprimirReporteFicha(reporte.titulo, article.outerHTML)
  }

  return (
    <div className="fixed inset-0 z-50 flex items-start justify-center overflow-y-auto bg-foreground/40 p-4" role="presentation">
      <div
        role="dialog"
        aria-modal="true"
        aria-labelledby="ficha-reporte-titulo"
        className="my-4 w-full max-w-4xl rounded-2xl border border-border bg-card p-4 shadow-[var(--shadow-sm)]"
      >
        <div className="mb-3 flex flex-wrap items-center justify-between gap-2">
          <h3 id="ficha-reporte-titulo" className="text-base font-semibold">
            Reporte de {reporte.titulo.toLowerCase()}
          </h3>
          <div className="flex flex-wrap gap-2">
            <Button type="button" size="sm" onClick={imprimir}>
              <Icon icon={Printer} size={14} />
              Imprimir
            </Button>
            <Button type="button" size="sm" variant="secondary" onClick={() => downloadReporteFichaPdf(reporte)}>
              Exportar PDF
            </Button>
            <Button type="button" size="sm" variant="ghost" onClick={onClose}>
              <Icon icon={X} size={14} />
              Cerrar
            </Button>
          </div>
        </div>
        <div ref={sheet} className="overflow-x-auto rounded-lg border border-border bg-white p-4">
          <style>{fichaReporteCss}</style>
          <FichaReporteDocument reporte={reporte} />
        </div>
      </div>
    </div>
  )
}
