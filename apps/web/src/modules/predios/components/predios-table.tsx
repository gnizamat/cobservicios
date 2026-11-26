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

function documentoLabel(item: PredioListItem) {
  const user = item.usuario
  if (user?.dni?.trim()) return `DNI ${user.dni.trim()}`
  if (user?.ruc?.trim()) return `RUC ${user.ruc.trim()}`
  return '—'
}

const columns = [
  { key: 'documento', header: 'Documento', className: 'w-[14%] whitespace-nowrap px-4' },
  { key: 'titular', header: 'Titular', className: 'w-[22%] px-4' },
  { key: 'predio', header: 'Predio', className: 'w-[20%] px-4' },
  { key: 'ubicacion', header: 'Ubicación', className: 'w-[28%] px-4' },
  { key: 'estado', header: 'Estado', className: 'w-[12%] px-4' },
  { key: 'acciones', header: '', className: 'w-12 px-3 text-right' },
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
      layout="fixed"
      columns={columns}
      rows={rows}
      rowKey={(row) => row.id}
      onRowSelect={onOpen}
      emptyMessage="No hay predios con esos filtros."
      renderCell={(row, key) => {
        switch (key) {
          case 'documento':
            return <span className="tabular-nums text-foreground">{documentoLabel(row)}</span>
          case 'predio': {
            const detalle =
              [
                row.manzana && `Mz ${row.manzana}`,
                row.lote && `Lt ${row.lote}`,
                row.numero && `N° ${row.numero}`,
              ]
                .filter(Boolean)
                .join(' · ') || row.tipo_predio?.nombre
            return (
              <p className="truncate">
                <span className="font-medium text-foreground">{row.nombre}</span>
                {detalle ? <span className="text-muted-foreground"> · {detalle}</span> : null}
              </p>
            )
          }
          case 'titular':
            return <span className="block truncate text-foreground">{usuarioLabel(row)}</span>
          case 'ubicacion':
            return (
              <span className="block truncate text-muted-foreground">
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
