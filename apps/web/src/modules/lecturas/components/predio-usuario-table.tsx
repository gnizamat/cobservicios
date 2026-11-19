import { Button } from '@/design-system/atoms'
import { DataTable } from '@/design-system/organisms'
import type { PredioOption } from '@/modules/lecturas/api'
import { predioLabel, titularLabel } from '@/modules/lecturas/labels'

const columns = [
  { key: 'usuario', header: 'Usuario' },
  { key: 'dni', header: 'DNI', className: 'w-28' },
  { key: 'predio', header: 'Predio' },
  { key: 'medidor', header: 'Medidor', className: 'w-28' },
  { key: 'registrar', header: '', className: 'w-36 text-right' },
]

export function PredioUsuarioTable({
  loading,
  error,
  rows,
  selectedId,
  onSelect,
  onRegisterMeter,
}: {
  loading: boolean
  error: string | null
  rows: PredioOption[]
  selectedId?: string
  onSelect: (id: string) => void
  onRegisterMeter?: (id: string) => void
}) {
  if (loading) return <p className="text-sm text-muted-foreground">Cargando usuarios y predios…</p>
  if (error) {
    return (
      <p role="alert" className="text-sm text-destructive">
        {error}
      </p>
    )
  }
  const visibleColumns = onRegisterMeter ? columns : columns.filter((column) => column.key !== 'registrar')
  return (
    <DataTable
      columns={visibleColumns}
      rows={rows}
      rowKey={(row) => row.id}
      selectedKey={selectedId}
      onRowSelect={(row) => onSelect(row.id)}
      emptyMessage="No hay usuarios con predio para esa búsqueda."
      renderCell={(row, key) => {
        if (key === 'usuario') return titularLabel(row.usuario)
        if (key === 'dni') return row.usuario?.dni?.trim() || '—'
        if (key === 'medidor') {
          return row.medidor?.codigo ?? <span className="text-muted-foreground">Sin medidor</span>
        }
        if (key === 'registrar' && onRegisterMeter) {
          return (
            <Button
              type="button"
              variant={row.medidor ? 'outline' : 'default'}
              size="sm"
              className="h-7 px-2"
              onClick={(event) => {
                event.stopPropagation()
                onRegisterMeter(row.id)
              }}
            >
              {row.medidor ? 'Cambiar medidor' : 'Registrar medidor'}
            </Button>
          )
        }
        return predioLabel(row)
      }}
    />
  )
}
