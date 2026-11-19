import { useMemo, useState, type FormEvent, type ReactNode } from 'react'
import { Pencil, Plus, Search, UserX, UserCheck } from 'lucide-react'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { PaginationBar } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import {
  useActualizarUsuarioSistema,
  useCrearUsuarioSistema,
  useOrganizacion,
  useRolesSistema,
  useUsuariosSistema,
} from '@/modules/configuracion/api'
import type { UsuarioSistema } from '@/modules/configuracion/api'
import { useAuth } from '@/modules/auth'
import { cn } from '@/shared/lib/utils'

const PAGE_SIZE = 20

export function SistemaUsuariosPanel() {
  const { user } = useAuth()
  const organizacion = useOrganizacion()
  const roles = useRolesSistema()
  const usuarios = useUsuariosSistema()
  const [search, setSearch] = useState('')
  const [page, setPage] = useState(1)
  const [crear, setCrear] = useState(false)
  const [editar, setEditar] = useState<UsuarioSistema | null>(null)
  const jass = organizacion.data?.nombre || 'JASS'
  const filtrados = useMemo(() => {
    const term = search.trim().toLowerCase()
    const rows = usuarios.data ?? []
    if (!term) return rows
    return rows.filter(
      (row) =>
        row.email.toLowerCase().includes(term) ||
        row.nombre.toLowerCase().includes(term) ||
        row.rol.toLowerCase().includes(term),
    )
  }, [search, usuarios.data])
  const pageRows = filtrados.slice((page - 1) * PAGE_SIZE, page * PAGE_SIZE)

  return (
    <section>
      <header className="mb-4 flex flex-col gap-3 sm:flex-row sm:items-start sm:justify-between">
        <div>
          <h2 className="text-lg font-semibold text-foreground">Gestión de usuarios</h2>
          <p className="mt-1 max-w-2xl text-sm text-muted-foreground">
            Cuentas que entran a la plataforma. Cada una pertenece a esta JASS y tiene un rol.
          </p>
        </div>
        <Button type="button" onClick={() => setCrear(true)}>
          <Icon icon={Plus} size={16} />
          Agregar usuario
        </Button>
      </header>

      <div className="relative mb-3 max-w-md">
        <Icon
          icon={Search}
          size={14}
          className="pointer-events-none absolute top-1/2 left-2.5 -translate-y-1/2 text-muted-foreground"
        />
        <Input
          value={search}
          onChange={(event) => {
            setSearch(event.target.value)
            setPage(1)
          }}
          placeholder="Buscar por correo o nombre…"
          aria-label="Buscar usuarios del sistema"
          className="h-8 pl-8 text-sm"
        />
      </div>

      {usuarios.isLoading ? <p className="text-sm text-muted-foreground">Cargando usuarios…</p> : null}
      {usuarios.isError ? (
        <p role="alert" className="text-sm text-destructive">
          {(usuarios.error as Error).message}
        </p>
      ) : null}

      {usuarios.data ? (
        <>
          <DataTable
            columns={[
              { key: 'email', header: 'Email' },
              { key: 'nombre', header: 'Nombre' },
              { key: 'jass', header: 'JASS' },
              { key: 'rol', header: 'Rol' },
              { key: 'estado', header: 'Estado' },
              { key: 'acciones', header: 'Acciones', className: 'text-right' },
            ]}
            rows={pageRows}
            rowKey={(row) => row.id}
            emptyMessage="No hay usuarios del sistema para esa búsqueda."
            renderCell={(row, key) => {
              if (key === 'email') return <span className="font-medium">{row.email}</span>
              if (key === 'nombre') return row.nombre || '—'
              if (key === 'jass') return jass
              if (key === 'rol') {
                return (
                  <span className="inline-flex rounded-full bg-primary/15 px-2 py-0.5 text-[11px] font-medium text-primary">
                    {row.rol || 'Sin rol'}
                  </span>
                )
              }
              if (key === 'estado') return row.activo ? 'Activo' : 'Inactivo'
              if (key === 'acciones') {
                const propio = row.id === user?.id
                return (
                  <span className="flex justify-end gap-1">
                    <Button
                      type="button"
                      size="sm"
                      variant="ghost"
                      className="h-7 px-2"
                      aria-label={`Editar ${row.email}`}
                      onClick={() => setEditar(row)}
                    >
                      <Icon icon={Pencil} size={14} />
                    </Button>
                    <EstadoUsuarioButton usuario={row} propio={propio} />
                  </span>
                )
              }
              return null
            }}
          />
          <PaginationBar
            page={page}
            pageSize={PAGE_SIZE}
            total={filtrados.length}
            onPageChange={setPage}
          />
        </>
      ) : null}

      {crear ? <CrearUsuarioDialog onClose={() => setCrear(false)} /> : null}
      {editar ? <EditarUsuarioDialog usuario={editar} onClose={() => setEditar(null)} /> : null}
      {roles.isError ? (
        <p role="alert" className={cn('mt-3 text-sm text-destructive')}>
          {(roles.error as Error).message}
        </p>
      ) : null}
    </section>
  )
}

function EstadoUsuarioButton({ usuario, propio }: { usuario: UsuarioSistema; propio: boolean }) {
  const actualizar = useActualizarUsuarioSistema()
  const desactivar = usuario.activo

  return (
    <Button
      type="button"
      size="sm"
      variant="ghost"
      className="h-7 px-2"
      disabled={propio || actualizar.isPending || !usuario.rolId}
      aria-label={desactivar ? `Desactivar ${usuario.email}` : `Activar ${usuario.email}`}
      title={propio ? 'No podés desactivar tu propia cuenta' : undefined}
      onClick={() =>
        actualizar.mutate({
          id: usuario.id,
          nombre: usuario.nombre,
          rolId: usuario.rolId,
          activo: !usuario.activo,
        })
      }
    >
      <Icon icon={desactivar ? UserX : UserCheck} size={14} />
    </Button>
  )
}

function CrearUsuarioDialog({ onClose }: { onClose: () => void }) {
  const roles = useRolesSistema()
  const crear = useCrearUsuarioSistema()
  const [nombre, setNombre] = useState('')
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')
  const [rolCodigo, setRolCodigo] = useState('operador')
  const puede = nombre.trim().length >= 2 && email.includes('@') && password.length >= 6 && rolCodigo

  function enviar(event: FormEvent) {
    event.preventDefault()
    if (!puede) return
    crear.mutate(
      { nombre, email, password, rolCodigo },
      {
        onSuccess: () => {
          setPassword('')
          onClose()
        },
      },
    )
  }

  return (
    <Dialog titulo="Agregar usuario">
      <form onSubmit={enviar} className="space-y-3">
        <Campo label="Nombre">
          <Input value={nombre} onChange={(event) => setNombre(event.target.value)} className="h-8 text-sm" />
        </Campo>
        <Campo label="Email">
          <Input
            type="email"
            value={email}
            autoComplete="off"
            onChange={(event) => setEmail(event.target.value)}
            className="h-8 text-sm"
          />
        </Campo>
        <Campo label="Contraseña">
          <Input
            type="password"
            value={password}
            autoComplete="new-password"
            onChange={(event) => setPassword(event.target.value)}
            className="h-8 text-sm"
          />
        </Campo>
        <Campo label="Rol">
          <Select
            value={rolCodigo}
            onChange={(event) => setRolCodigo(event.target.value)}
            className="h-8 text-sm"
          >
            {(roles.data ?? []).map((rol) => (
              <option key={rol.id} value={rol.codigo}>
                {rol.nombre}
              </option>
            ))}
          </Select>
        </Campo>
        {crear.isError ? <Alerta mensaje={(crear.error as Error).message} /> : null}
        <Acciones pending={crear.isPending} disabled={!puede} onClose={onClose} etiqueta="Crear usuario" />
      </form>
    </Dialog>
  )
}

function EditarUsuarioDialog({ usuario, onClose }: { usuario: UsuarioSistema; onClose: () => void }) {
  const roles = useRolesSistema()
  const actualizar = useActualizarUsuarioSistema()
  const [nombre, setNombre] = useState(usuario.nombre)
  const [rolId, setRolId] = useState(usuario.rolId)

  function enviar(event: FormEvent) {
    event.preventDefault()
    actualizar.mutate(
      { id: usuario.id, nombre, rolId, activo: usuario.activo },
      { onSuccess: onClose },
    )
  }

  return (
    <Dialog titulo="Editar usuario">
      <form onSubmit={enviar} className="space-y-3">
        <p className="text-sm text-muted-foreground">{usuario.email}</p>
        <Campo label="Nombre">
          <Input value={nombre} onChange={(event) => setNombre(event.target.value)} className="h-8 text-sm" />
        </Campo>
        <Campo label="Rol">
          <Select value={rolId} onChange={(event) => setRolId(event.target.value)} className="h-8 text-sm">
            {(roles.data ?? []).map((rol) => (
              <option key={rol.id} value={rol.id}>
                {rol.nombre}
              </option>
            ))}
          </Select>
        </Campo>
        {actualizar.isError ? <Alerta mensaje={(actualizar.error as Error).message} /> : null}
        <Acciones
          pending={actualizar.isPending}
          disabled={nombre.trim().length < 2 || !rolId}
          onClose={onClose}
          etiqueta="Guardar"
        />
      </form>
    </Dialog>
  )
}

function Dialog({
  titulo,
  children,
}: {
  titulo: string
  children: ReactNode
}) {
  return (
    <div className="fixed inset-0 z-50 flex items-start justify-center bg-foreground/40 p-4" role="presentation">
      <div
        role="dialog"
        aria-modal="true"
        aria-labelledby="usuario-sistema-titulo"
        className="mt-10 w-full max-w-md rounded-2xl border border-border bg-card p-4 shadow-[var(--shadow-sm)]"
      >
        <h3 id="usuario-sistema-titulo" className="mb-3 text-base font-semibold">
          {titulo}
        </h3>
        {children}
      </div>
    </div>
  )
}

function Campo({ label, children }: { label: string; children: ReactNode }) {
  return (
    <label className="flex flex-col gap-1 text-xs text-muted-foreground">
      {label}
      {children}
    </label>
  )
}

function Alerta({ mensaje }: { mensaje: string }) {
  return (
    <p role="alert" className="text-sm text-destructive">
      {mensaje}
    </p>
  )
}

function Acciones({
  pending,
  disabled,
  onClose,
  etiqueta,
}: {
  pending: boolean
  disabled: boolean
  onClose: () => void
  etiqueta: string
}) {
  return (
    <div className="flex justify-end gap-2 pt-1">
      <Button type="button" variant="ghost" size="sm" disabled={pending} onClick={onClose}>
        Cancelar
      </Button>
      <Button type="submit" size="sm" disabled={disabled || pending}>
        {pending ? 'Guardando…' : etiqueta}
      </Button>
    </div>
  )
}
