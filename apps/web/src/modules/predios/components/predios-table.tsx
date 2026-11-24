import { Pencil } from 'lucide-react'
import { Link } from 'react-router-dom'
import { Button, Icon } from '@/design-system/atoms'
import { StatusBadge } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import type { PredioListItem } from '@/modules/predios/api'

function usuarioLabel(item: PredioListItem) {
  const user = item.usuario
  if (!user) return '—'
  if (user.tipo_persona === 'natural') {
    return [user.nombres, user.apellido_paterno, user.apellido_materno]
      .filter(Boolean)
      .join(' ')
  }
  return user.nombres
}

const columns = [
  { key: 'predio', header: 'Predio' },
  { key: 'titular', header: 'Titular' },
  { key: 'ubicacion', header: 'Ubicación' },
  { key: 'estado', header: 'Estado', className: 'w-[6.5rem]' },
  { key: 'acciones', header: '', className: 'w-10 text-right' },
]

export function PrediosTable({
  rows,
  onOpen,
}: {
  rows: PredioListItem[]
  onOpen?: (predio: PredioListItem) => void
}) {
  return (
    <DataTable
      columns={columns}
      rows={rows}
      rowKey={(row) => row.id}
      onRowSelect={onOpen}
      emptyMessage="No hay predios con esos filtros."
      renderCell={(row, key) => {
        switch (key) {
          case 'predio':
            return (
              <div className="min-w-0">
                <p className="truncate font-medium text-foreground">{row.nombre}</p>
                <p className="text-[11px] text-muted-foreground">
                  {[
                    row.manzana && `Mz ${row.manzana}`,
                    row.lote && `Lt ${row.lote}`,
                    row.numero && `N° ${row.numero}`,
                  ]
                    .filter(Boolean)
                    .join(' · ') || row.tipo_predio?.nombre || '—'}
                </p>
              </div>
            )
          case 'titular':
            return <span className="line-clamp-2 text-foreground">{usuarioLabel(row)}</span>
          case 'ubicacion':
            return (
              <span className="line-clamp-2 text-muted-foreground">
                {[row.sector?.nombre, row.calle?.nombre].filter(Boolean).join(' · ') || '—'}
              </span>
            )
          case 'estado':
            return <StatusBadge status={row.estado} />
          case 'acciones':
            return (
              <Button asChild variant="ghost" size="sm" className="h-7 px-2">
                <Link
                  to={`/padron/predios/${row.id}/editar`}
                  aria-label="Editar predio"
                  onClick={(event) => event.stopPropagation()}
                >
                  <Icon icon={Pencil} size={14} />
                </Link>
              </Button>
            )
          default:
            return null
        }
      }}
    />
  )
}
