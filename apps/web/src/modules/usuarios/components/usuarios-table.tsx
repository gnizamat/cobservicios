import { Pencil } from 'lucide-react'
import { Link } from 'react-router-dom'
import { Button, Icon } from '@/design-system/atoms'
import { StatusBadge } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import type { PadUsuario } from '@/shared/types/database'

function displayName(user: PadUsuario) {
  if (user.tipo_persona === 'natural') {
    return [user.nombres, user.apellido_paterno, user.apellido_materno]
      .filter(Boolean)
      .join(' ')
  }
  return user.nombres
}

const columns = [
  { key: 'usuario', header: 'Usuario' },
  { key: 'documento', header: 'Documento' },
  { key: 'contacto', header: 'Contacto' },
  { key: 'estado', header: 'Estado', className: 'w-[6.5rem]' },
  { key: 'acciones', header: '', className: 'w-10 text-right' },
]

export function UsuariosTable({
  rows,
  onOpen,
}: {
  rows: PadUsuario[]
  onOpen?: (usuario: PadUsuario) => void
}) {
  return (
    <DataTable
      columns={columns}
      rows={rows}
      rowKey={(row) => row.id}
      emptyMessage="No hay usuarios con esos filtros."
      onRowSelect={onOpen}
      renderCell={(row, key) => {
        switch (key) {
          case 'usuario':
            return (
              <div className="min-w-0">
                <p className="truncate font-medium text-foreground">{displayName(row)}</p>
                <p className="text-[11px] text-muted-foreground capitalize">{row.tipo_persona}</p>
              </div>
            )
          case 'documento':
            return (
              <span className="tabular-nums text-muted-foreground">
                {row.dni ? `DNI ${row.dni}` : row.ruc ? `RUC ${row.ruc}` : '—'}
              </span>
            )
          case 'contacto':
            return (
              <div className="min-w-0 text-muted-foreground">
                <div className="truncate tabular-nums">{row.celular || '—'}</div>
                {row.email ? (
                  <div className="truncate text-[11px]">{row.email}</div>
                ) : null}
              </div>
            )
          case 'estado':
            return <StatusBadge status={row.estado} />
          case 'acciones':
            return (
              <Button asChild variant="ghost" size="sm" className="h-7 px-2">
                <Link
                  to={`/padron/usuarios/${row.id}/editar`}
                  aria-label="Editar usuario"
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
