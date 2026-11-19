import { DataTable } from '@/design-system/organisms'
import { predioLabel, titularLabel } from '@/modules/deudas/labels'
import type { PredioDeudaOption } from '@/modules/deudas/types'

const columns = [
  { key: 'usuario', header: 'Usuario' },
  { key: 'dni', header: 'DNI', className: 'w-28' },
  { key: 'predio', header: 'Predio' },
]

export function PredioUsuarioTable({
  loading,
  error,
  rows,
  selectedId,
  onSelect,
}: {
  loading: boolean
  error: string | null
  rows: PredioDeudaOption[]
  selectedId?: string
  onSelect: (id: string) => void
}) {
  if (loading) return <p className="text-sm text-muted-foreground">Cargando usuarios y predios…</p>
  if (error) {
    return (
      <p role="alert" className="text-sm text-destructive">
        {error}
      </p>
    )
  }

  return (
    <DataTable
      columns={columns}
      rows={rows}
      rowKey={(row) => row.id}
      selectedKey={selectedId}
      onRowSelect={(row) => onSelect(row.id)}
      emptyMessage="No hay usuarios con predio para esa búsqueda."
      renderCell={(row, key) => {
        if (key === 'usuario') return titularLabel(row.usuario)
        if (key === 'dni') return row.usuario?.dni?.trim() || '—'
        return predioLabel(row)
      }}
    />
  )
}
