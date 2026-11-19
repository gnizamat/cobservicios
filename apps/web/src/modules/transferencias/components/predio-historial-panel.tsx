import { X } from 'lucide-react'
import { Link } from 'react-router-dom'
import { Button, Icon } from '@/design-system/atoms'
import { useHistorialPredio } from '@/modules/transferencias/api'
import { formatFechaHora, formatUsuarioNombre } from '@/modules/transferencias/lib/format'

export interface PredioHistorialPanelProps {
  predioId: string
  nombre: string
  onClose: () => void
}

export function PredioHistorialPanel({ predioId, nombre, onClose }: PredioHistorialPanelProps) {
  const { data, isLoading, isError, error } = useHistorialPredio(predioId)
  const filas = data ?? []

  return (
    <section
      aria-labelledby="historial-predio-titulo"
      className="rounded-2xl border border-border bg-card p-4 shadow-[var(--shadow-sm)]"
    >
      <div className="mb-3 flex items-start justify-between gap-3">
        <div>
          <h3
            id="historial-predio-titulo"
            className="font-[family-name:var(--font-display)] text-base font-semibold"
          >
            Historial del predio
          </h3>
          <p className="text-sm text-muted-foreground">{nombre}</p>
        </div>
        <div className="flex items-center gap-1">
          <Button asChild variant="outline" size="sm">
            <Link to={`/padron/predios/${predioId}/editar`}>Abrir predio</Link>
          </Button>
          <Button type="button" variant="ghost" size="icon" aria-label="Cerrar historial" onClick={onClose}>
            <Icon icon={X} size={16} />
          </Button>
        </div>
      </div>

      {isLoading ? (
        <p className="text-sm text-muted-foreground">Cargando historial…</p>
      ) : isError ? (
        <p role="alert" className="text-sm text-destructive">
          {(error as Error).message}
        </p>
      ) : filas.length === 0 ? (
        <p className="text-sm text-muted-foreground">Este predio todavía no tiene movimientos.</p>
      ) : (
        <ol className="space-y-2">
          {filas.map((fila) => (
            <li
              key={fila.id}
              className="rounded-lg border border-border/80 px-3 py-2 text-sm"
            >
              <div className="flex flex-wrap items-center justify-between gap-2">
                <p className="font-medium text-foreground">{formatUsuarioNombre(fila.usuario)}</p>
                <span
                  className={
                    fila.vigente
                      ? 'rounded-md bg-accent/25 px-1.5 py-0.5 text-[11px] font-medium text-accent-foreground'
                      : 'rounded-md bg-muted px-1.5 py-0.5 text-[11px] font-medium text-muted-foreground'
                  }
                >
                  {fila.vigente ? 'Vigente' : 'Cerrado'}
                </span>
              </div>
              <p className="mt-1 text-xs text-muted-foreground">
                {formatFechaHora(fila.desde)}
                {fila.hasta ? ` — ${formatFechaHora(fila.hasta)}` : ' — vigente'}
              </p>
              <p className="mt-1 text-xs text-muted-foreground">
                {fila.transferencia_id ? 'Transferencia' : 'Movimiento de padrón'}
                {fila.referencia ? ` · ${fila.referencia}` : ''}
              </p>
            </li>
          ))}
        </ol>
      )}
    </section>
  )
}
