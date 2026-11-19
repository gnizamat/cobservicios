import { Button } from '@/design-system/atoms'
import { DataTable } from '@/design-system/organisms'
import { categoriaServicioLabel, type CostoListItem } from '@/modules/catalogo/api'
import { formatAmount } from '@/modules/catalogo/labels'

const columns = [
  { key: 'anio', header: 'Año', className: 'w-20' },
  { key: 'servicio', header: 'Servicio' },
  { key: 'valor', header: 'Valor', className: 'text-right' },
  { key: 'monto', header: 'Monto', className: 'text-right' },
  { key: 'editar', header: '', className: 'w-24 text-right' },
]

export interface CostosTableProps {
  rows: CostoListItem[]
  selectedId?: string
  onEdit: (id: string) => void
}

export function CostosTable({ rows, selectedId, onEdit }: CostosTableProps) {
  return (
    <DataTable
      columns={columns}
      rows={rows}
      rowKey={(row) => row.id}
      selectedKey={selectedId}
      onRowSelect={(row) => onEdit(row.id)}
      emptyMessage="No hay costos con ese filtro."
      renderCell={(row, key) => {
        if (key === 'anio') {
          return <span className="font-medium tabular-nums">{row.tarifa?.anio ?? '—'}</span>
        }
        if (key === 'servicio') {
          return (
            <div className="min-w-0">
              <p className="truncate">{row.servicio?.nombre ?? '—'}</p>
              <p className="text-[11px] text-muted-foreground">
                {row.servicio ? categoriaServicioLabel(row.servicio.categoria) : ''}
              </p>
            </div>
          )
        }
        if (key === 'valor') {
          return <span className="block text-right tabular-nums">{formatAmount(row.valor)}</span>
        }
        if (key === 'monto') {
          return <span className="block text-right tabular-nums">{formatAmount(row.monto)}</span>
        }
        const editing = selectedId === row.id
        return (
          <Button
            type="button"
            variant={editing ? 'default' : 'outline'}
            size="sm"
            className="h-7 px-2"
            onClick={(event) => {
              event.stopPropagation()
              onEdit(row.id)
            }}
          >
            {editing ? 'Editando' : 'Editar'}
          </Button>
        )
      }}
    />
  )
}
