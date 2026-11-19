import { useEffect, useState } from 'react'
import { Building2, LayoutDashboard, Palette, Shield, Users } from 'lucide-react'
import { useSearchParams } from 'react-router-dom'
import { Button, Icon, Input } from '@/design-system/atoms'
import { AppShell } from '@/design-system/templates'
import {
  logoPublicUrl,
  useGuardarMarca,
  useMarca,
  useOrganizacion,
  useRolesSistema,
} from '@/modules/configuracion/api'
import { SistemaUsuariosPanel } from '@/modules/configuracion/components/sistema-usuarios-panel'
import { cn } from '@/shared/lib/utils'

const secciones = [
  { id: 'jass', label: 'JASS', icon: Building2 },
  { id: 'usuarios', label: 'Usuarios del sistema', icon: Users },
  { id: 'roles', label: 'Roles y permisos', icon: Shield },
  { id: 'tablero', label: 'Tablero por rol', icon: LayoutDashboard },
  { id: 'marca', label: 'Marca de la plataforma', icon: Palette },
] as const

type SeccionId = (typeof secciones)[number]['id']

function seccionActual(value: string | null): SeccionId {
  return secciones.some((item) => item.id === value) ? (value as SeccionId) : 'jass'
}

export function SistemaPage() {
  const [params, setParams] = useSearchParams()
  const seccion = seccionActual(params.get('seccion'))

  useEffect(() => {
    if (params.get('seccion') === seccion) return
    const next = new URLSearchParams(params)
    next.set('seccion', seccion)
    setParams(next, { replace: true })
  }, [params, seccion, setParams])

  return (
    <AppShell>
      <header className="mb-6 space-y-1">
        <h1 className="font-[family-name:var(--font-display)] text-2xl font-semibold text-foreground">
          Configuración del sistema
        </h1>
        <p className="max-w-3xl text-sm text-muted-foreground">
          JASS, usuarios del sistema, roles y permisos, tablero de inicio por rol y marca de la
          plataforma.
        </p>
      </header>
      <div className="grid items-start gap-4 lg:grid-cols-[16rem_minmax(0,1fr)]">
        <nav aria-label="Secciones del sistema" className="flex flex-col gap-1">
          {secciones.map((item) => {
            const active = seccion === item.id
            return (
              <button
                key={item.id}
                type="button"
                aria-current={active ? 'page' : undefined}
                onClick={() => {
                  const next = new URLSearchParams(params)
                  next.set('seccion', item.id)
                  setParams(next)
                }}
                className={cn(
                  'flex items-center gap-2 rounded-xl px-3 py-2 text-left text-sm text-muted-foreground hover:bg-secondary hover:text-foreground',
                  active && 'bg-secondary font-medium text-foreground',
                )}
              >
                <Icon icon={item.icon} size={16} />
                {item.label}
              </button>
            )
          })}
        </nav>
        <div className="min-w-0 rounded-2xl border border-border bg-card p-4 shadow-[var(--shadow-sm)]">
          {seccion === 'jass' ? <JassPanel /> : null}
          {seccion === 'usuarios' ? <SistemaUsuariosPanel /> : null}
          {seccion === 'roles' ? <RolesPanel /> : null}
          {seccion === 'tablero' ? <TableroPanel /> : null}
          {seccion === 'marca' ? <MarcaPanel /> : null}
        </div>
      </div>
    </AppShell>
  )
}

function JassPanel() {
  const organizacion = useOrganizacion()
  const jass = organizacion.data

  return (
    <section>
      <h2 className="text-lg font-semibold text-foreground">JASS</h2>
      <p className="mt-1 text-sm text-muted-foreground">
        La junta que opera esta instalación de la plataforma.
      </p>
      {organizacion.isLoading ? <p className="mt-4 text-sm text-muted-foreground">Cargando la JASS…</p> : null}
      {organizacion.isError ? (
        <p role="alert" className="mt-4 text-sm text-destructive">
          {(organizacion.error as Error).message}
        </p>
      ) : null}
      {jass ? (
        <dl className="mt-4 grid gap-3 sm:grid-cols-2">
          <Dato etiqueta="Nombre" valor={jass.nombre} />
          <Dato etiqueta="Abreviatura" valor={jass.abreviatura || '—'} />
          <Dato etiqueta="Correo" valor={jass.email || '—'} />
          <Dato etiqueta="Celular" valor={jass.celular || '—'} />
          <Dato etiqueta="Dirección" valor={jass.direccion || '—'} />
        </dl>
      ) : null}
    </section>
  )
}

function RolesPanel() {
  const roles = useRolesSistema()

  return (
    <section>
      <h2 className="text-lg font-semibold text-foreground">Roles y permisos</h2>
      <p className="mt-1 text-sm text-muted-foreground">
        Cada rol define qué módulos de la plataforma puede usar una cuenta.
      </p>
      {roles.isLoading ? <p className="mt-4 text-sm text-muted-foreground">Cargando roles…</p> : null}
      {roles.isError ? (
        <p role="alert" className="mt-4 text-sm text-destructive">
          {(roles.error as Error).message}
        </p>
      ) : null}
      <div className="mt-4 space-y-3">
        {(roles.data ?? []).map((rol) => (
          <article key={rol.id} className="rounded-xl border border-border p-3">
            <h3 className="font-medium text-foreground">{rol.nombre}</h3>
            <p className="mt-1 text-sm text-muted-foreground">{rol.descripcion}</p>
            <ul className="mt-3 flex flex-wrap gap-1.5">
              {rol.permisos.map((permiso) => (
                <li
                  key={permiso}
                  className="rounded-full bg-secondary px-2 py-0.5 text-[11px] font-medium text-foreground"
                >
                  {permiso}
                </li>
              ))}
            </ul>
          </article>
        ))}
      </div>
    </section>
  )
}

function TableroPanel() {
  const roles = useRolesSistema()

  return (
    <section>
      <h2 className="text-lg font-semibold text-foreground">Tablero por rol</h2>
      <p className="mt-1 text-sm text-muted-foreground">
        Accesos de inicio que ve cada rol al entrar a la plataforma.
      </p>
      <div className="mt-4 space-y-3">
        {(roles.data ?? []).map((rol) => (
          <article key={rol.id} className="rounded-xl border border-border p-3">
            <h3 className="font-medium text-foreground">{rol.nombre}</h3>
            <ul className="mt-3 flex flex-wrap gap-1.5">
              {rol.tablero.map((acceso) => (
                <li
                  key={acceso}
                  className="rounded-lg border border-border bg-secondary/40 px-2.5 py-1 text-sm text-foreground"
                >
                  {acceso}
                </li>
              ))}
            </ul>
          </article>
        ))}
      </div>
    </section>
  )
}

function MarcaPanel() {
  const marca = useMarca()
  const guardar = useGuardarMarca()
  const organizacion = useOrganizacion()
  const [nombre, setNombre] = useState('')
  const [listo, setListo] = useState(false)
  const logo = logoPublicUrl(organizacion.data?.logo_path)
  const visible = (listo ? nombre : marca.data) || 'COBSERVICIOS'

  useEffect(() => {
    if (marca.data != null && !listo) {
      setNombre(marca.data)
      setListo(true)
    }
  }, [listo, marca.data])

  return (
    <section>
      <h2 className="text-lg font-semibold text-foreground">Marca de la plataforma</h2>
      <p className="mt-1 text-sm text-muted-foreground">
        Nombre que aparece en el menú, junto al logo de la JASS.
      </p>
      <div className="mt-4 flex items-center gap-3 rounded-xl border border-border bg-secondary/30 p-3">
        <div className="flex h-10 w-10 items-center justify-center overflow-hidden rounded-full bg-primary text-primary-foreground">
          {logo ? <img src={logo} alt="" className="h-full w-full object-cover" /> : null}
        </div>
        <div className="min-w-0">
          <p className="truncate font-[family-name:var(--font-display)] text-sm font-semibold">{visible}</p>
          <p className="truncate text-[10px] font-medium tracking-[0.12em] text-muted-foreground uppercase">
            {organizacion.data?.abreviatura || organizacion.data?.nombre || 'JASS'}
          </p>
        </div>
      </div>
      <form
        className="mt-4 flex flex-col gap-3 sm:flex-row sm:items-end"
        onSubmit={(event) => {
          event.preventDefault()
          guardar.mutate(nombre, {
            onSuccess: (value) => setNombre(value),
          })
        }}
      >
        <label className="flex min-w-0 flex-1 flex-col gap-1 text-xs text-muted-foreground">
          Nombre de la plataforma
          <Input
            value={nombre}
            onChange={(event) => setNombre(event.target.value)}
            className="h-8 text-sm text-foreground"
          />
        </label>
        <Button type="submit" disabled={guardar.isPending || nombre.trim().length < 2}>
          {guardar.isPending ? 'Guardando…' : 'Guardar'}
        </Button>
      </form>
      {guardar.isError ? (
        <p role="alert" className="mt-3 text-sm text-destructive">
          {(guardar.error as Error).message}
        </p>
      ) : null}
    </section>
  )
}

function Dato({ etiqueta, valor }: { etiqueta: string; valor: string }) {
  return (
    <div className="rounded-xl border border-border px-3 py-2">
      <dt className="text-[11px] font-medium tracking-wide text-muted-foreground uppercase">{etiqueta}</dt>
      <dd className="mt-1 text-sm text-foreground">{valor}</dd>
    </div>
  )
}
