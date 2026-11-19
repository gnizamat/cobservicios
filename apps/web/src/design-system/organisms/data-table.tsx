import type { ReactNode } from 'react'
import { cn } from '@/shared/lib/utils'

export interface DataTableColumn {
  key: string
  header: string
  className?: string
}

export interface DataTableProps<T> {
  columns: DataTableColumn[]
  rows: T[]
  rowKey: (row: T) => string
  emptyMessage: string
  renderCell: (row: T, columnKey: string) => ReactNode
  /** Compacta filas y tipografía para listados densos. */
  density?: 'comfortable' | 'compact'
  className?: string
  /** Resalta la fila cuyo `rowKey` coincide. */
  selectedKey?: string
  /** Al elegir una fila (clic o teclado) para cargar su ficha. */
  onRowSelect?: (row: T) => void
}

export function DataTable<T>({
  columns,
  rows,
  rowKey,
  emptyMessage,
  renderCell,
  density = 'compact',
  className,
  selectedKey,
  onRowSelect,
}: DataTableProps<T>) {
  const cellPad = density === 'compact' ? 'px-2.5 py-1.5' : 'px-4 py-3'
  const headPad = density === 'compact' ? 'px-2.5 py-2' : 'px-4 py-3'

  if (rows.length === 0) {
    return (
      <div className="rounded-lg border border-dashed border-border px-4 py-8 text-center text-sm text-muted-foreground">
        {emptyMessage}
      </div>
    )
  }

  return (
    <div
      className={cn(
        'overflow-hidden rounded-lg border border-border bg-card shadow-[var(--shadow-sm)]',
        className,
      )}
    >
      <div className="overflow-x-auto">
        <table className={cn('min-w-full', density === 'compact' ? 'text-[13px]' : 'text-sm')}>
          <thead className="bg-secondary/50 text-left text-[11px] tracking-wide text-muted-foreground uppercase">
            <tr>
              {columns.map((column) => (
                <th
                  key={column.key}
                  className={cn(headPad, 'font-semibold', column.className)}
                >
                  {column.header}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {rows.map((row) => {
              const key = rowKey(row)
              const selected = selectedKey === key
              return (
              <tr
                key={key}
                aria-selected={onRowSelect ? selected : undefined}
                tabIndex={onRowSelect ? 0 : undefined}
                onClick={onRowSelect ? () => onRowSelect(row) : undefined}
                onKeyDown={
                  onRowSelect
                    ? (event) => {
                        if (event.key !== 'Enter' && event.key !== ' ') return
                        event.preventDefault()
                        onRowSelect(row)
                      }
                    : undefined
                }
                className={cn(
                  'border-t border-border/70 hover:bg-secondary/30',
                  onRowSelect && 'cursor-pointer focus-visible:outline-2 focus-visible:outline-offset-[-2px] focus-visible:outline-ring',
                  selected && 'bg-primary/10 shadow-[inset_3px_0_0_0_var(--color-primary)]',
                )}
              >
                {columns.map((column) => (
                  <td key={column.key} className={cn(cellPad, 'align-middle', column.className)}>
                    {renderCell(row, column.key)}
                  </td>
                ))}
              </tr>
              )
            })}
          </tbody>
        </table>
      </div>
    </div>
  )
}
