import { useHistorialCostos } from '@/modules/catalogo/api'
import { formatAmount, formatDateTime } from '@/modules/catalogo/labels'

export function CostoHistorial({ costoId }: { costoId?: string | null }) {
  const query = useHistorialCostos(costoId)

  if (!costoId) return null

  return (
    <section className="mt-4 rounded-2xl border border-border bg-card p-4">
      <h4 className="text-sm font-semibold text-foreground">Historial de montos</h4>
      <p className="mt-1 text-xs text-muted-foreground">
        Cada cambio del monto queda registrado. Si solo cambia el valor unitario, no se agrega una fila.
      </p>
      {query.isLoading ? (
        <p className="mt-3 text-sm text-muted-foreground">Cargando historial…</p>
      ) : query.isError ? (
        <p role="alert" className="mt-3 text-sm text-destructive">
          {(query.error as Error).message}
        </p>
      ) : (query.data ?? []).length === 0 ? (
        <p className="mt-3 text-sm text-muted-foreground">Todavía no hay cambios de monto.</p>
      ) : (
        <ol className="mt-3 space-y-2">
          {(query.data ?? []).map((item) => (
            <li key={item.id} className="rounded-lg bg-secondary/40 px-3 py-2 text-sm">
              <p className="font-medium tabular-nums text-foreground">
                S/ {formatAmount(item.monto_anterior)} → S/ {formatAmount(item.monto_nuevo)}
              </p>
              <p className="text-xs text-muted-foreground">{formatDateTime(item.created_at)}</p>
            </li>
          ))}
        </ol>
      )}
    </section>
  )
}
