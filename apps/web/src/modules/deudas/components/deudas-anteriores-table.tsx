import { Button } from '@/design-system/atoms'
import { DataTable } from '@/design-system/organisms'
import { formatMoney, formatVolume, mesLabel } from '@/modules/deudas/labels'
import type { DeudaAnteriorListItem } from '@/modules/deudas/types'

const columns = [
  { key: 'periodo', header: 'Periodo' },
  { key: 'tarifa', header: 'Tipo de tarifa' },
  { key: 'monto', header: 'Monto', className: 'text-right' },
  { key: 'volumen', header: 'Volumen', className: 'text-right' },
  { key: 'mora', header: 'Mora', className: 'text-right' },
  { key: 'total', header: 'Total', className: 'text-right' },
  { key: 'eliminar', header: '', className: 'w-28 text-right' },
]

export function DeudasAnterioresTable({
  loading,
  error,
  rows,
  pendingDeleteId,
  deleting,
  onAskDelete,
  onConfirmDelete,
  onCancelDelete,
}: {
  loading: boolean
  error: string | null
  rows: DeudaAnteriorListItem[]
  pendingDeleteId: string | null
  deleting: boolean
  onAskDelete: (id: string) => void
  onConfirmDelete: (id: string) => void
  onCancelDelete: () => void
}) {
  if (loading) return <p className="text-sm text-muted-foreground">Cargando deudas del predio…</p>
  if (error) {
    return (
      <p role="alert" className="text-sm text-destructive">
        {error}
      </p>
    )
  }

  const monto = rows.reduce((sum, row) => sum + Number(row.monto), 0)
  const mora = rows.reduce((sum, row) => sum + Number(row.interes), 0)

  return (
    <div className="space-y-2">
      <DataTable
        columns={columns}
        rows={rows}
        rowKey={(row) => row.id}
        emptyMessage="Este predio todavía no tiene deudas anteriores."
        renderCell={(row, key) => {
          if (key === 'periodo') return `${mesLabel(row.mes)} ${row.anio}`
          if (key === 'tarifa') return row.servicio?.nombre ?? (row.concepto || '—')
          if (key === 'monto') return formatMoney(row.monto)
          if (key === 'volumen') return formatVolume(row.volumen)
          if (key === 'mora') return formatMoney(row.interes)
          if (key === 'total') return formatMoney(Number(row.saldo) + Number(row.interes))
          if (key === 'eliminar') {
            if (pendingDeleteId === row.id) {
              return (
                <span className="inline-flex gap-1">
                  <Button
                    type="button"
                    variant="destructive"
                    size="sm"
                    className="h-7 px-2"
                    disabled={deleting}
                    onClick={() => onConfirmDelete(row.id)}
                  >
                    Confirmar
                  </Button>
                  <Button
                    type="button"
                    variant="outline"
                    size="sm"
                    className="h-7 px-2"
                    disabled={deleting}
                    onClick={onCancelDelete}
                  >
                    No
                  </Button>
                </span>
              )
            }
            return (
              <Button
                type="button"
                variant="outline"
                size="sm"
                className="h-7 px-2"
                onClick={() => onAskDelete(row.id)}
              >
                Eliminar
              </Button>
            )
          }
          return null
        }}
      />
      {rows.length > 0 ? (
        <p className="text-sm text-muted-foreground">
          {rows.length} {rows.length === 1 ? 'deuda' : 'deudas'} · Monto {formatMoney(monto)} · Mora{' '}
          {formatMoney(mora)} · Total {formatMoney(monto + mora)}
        </p>
      ) : null}
    </div>
  )
}
