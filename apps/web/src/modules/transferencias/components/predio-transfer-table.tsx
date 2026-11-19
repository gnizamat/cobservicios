import { History } from 'lucide-react'
import { Button, Icon } from '@/design-system/atoms'
import type { PredioDeUsuario } from '@/modules/transferencias/types'

export interface PredioTransferTableProps {
  predios: PredioDeUsuario[]
  checkedIds: string[]
  selectable?: boolean
  emptyMessage: string
  loading?: boolean
  onToggle?: (id: string) => void
  onToggleAll?: (checked: boolean) => void
  onInspect: (predio: PredioDeUsuario) => void
}

export function PredioTransferTable({
  predios,
  checkedIds,
  selectable = true,
  emptyMessage,
  loading,
  onToggle,
  onToggleAll,
  onInspect,
}: PredioTransferTableProps) {
  if (loading) {
    return <p className="px-2 py-6 text-center text-xs text-muted-foreground">Cargando predios…</p>
  }

  if (predios.length === 0) {
    return (
      <p className="px-2 py-6 text-center text-xs text-muted-foreground">{emptyMessage}</p>
    )
  }

  const checked = new Set(checkedIds)
  const allChecked = selectable && predios.every((predio) => checked.has(predio.id))

  return (
    <div className="overflow-x-auto">
      <table className="min-w-full text-[13px]">
        <thead className="bg-secondary/60 text-left text-[11px] tracking-wide text-muted-foreground uppercase">
          <tr>
            {selectable ? (
              <th className="w-8 px-2 py-1.5">
                <input
                  type="checkbox"
                  className="size-3.5 accent-primary"
                  checked={allChecked}
                  aria-label="Seleccionar todos los predios"
                  onChange={(event) => onToggleAll?.(event.target.checked)}
                />
              </th>
            ) : null}
            <th className="px-2 py-1.5 font-semibold">Predio</th>
            <th className="px-2 py-1.5 font-semibold">Calle</th>
            <th className="px-2 py-1.5 font-semibold">N° casa</th>
            <th className="px-2 py-1.5 font-semibold">Mz</th>
            <th className="px-2 py-1.5 font-semibold">Lt</th>
            <th className="w-8 px-1 py-1.5" />
          </tr>
        </thead>
        <tbody>
          {predios.map((predio) => {
            const isChecked = checked.has(predio.id)
            return (
              <tr key={predio.id} className="border-t border-border/70">
                {selectable ? (
                  <td className="px-2 py-1.5">
                    <input
                      type="checkbox"
                      className="size-3.5 accent-primary"
                      checked={isChecked}
                      aria-label={`Seleccionar ${predio.nombre}`}
                      onChange={() => onToggle?.(predio.id)}
                    />
                  </td>
                ) : null}
                <td className="max-w-40 truncate px-2 py-1.5 font-medium text-foreground">
                  {predio.nombre}
                </td>
                <td className="max-w-36 truncate px-2 py-1.5 text-muted-foreground">
                  {predio.calle_nombre || '—'}
                </td>
                <td className="px-2 py-1.5 text-muted-foreground">{predio.numero || '—'}</td>
                <td className="px-2 py-1.5 text-muted-foreground">{predio.manzana || '—'}</td>
                <td className="px-2 py-1.5 text-muted-foreground">{predio.lote || '—'}</td>
                <td className="px-1 py-1">
                  <Button
                    type="button"
                    variant="ghost"
                    size="icon"
                    className="h-7 w-7"
                    aria-label={`Ver historial de ${predio.nombre}`}
                    onClick={() => onInspect(predio)}
                  >
                    <Icon icon={History} size={14} />
                  </Button>
                </td>
              </tr>
            )
          })}
        </tbody>
      </table>
    </div>
  )
}
