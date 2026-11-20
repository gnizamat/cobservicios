import { useEffect, useMemo, useRef, useState } from 'react'
import { Button } from '@/design-system/atoms'
import { useGuardarPermisosRol, useRolesSistema } from '@/modules/configuracion/api'
import type { RolSistema } from '@/modules/configuracion/api'
import { catalogoPermisos, expandirPermisos } from '@/modules/navegacion/permisos'
import { cn } from '@/shared/lib/utils'

const catalogo = catalogoPermisos()

function mismos(a: Set<string>, b: Set<string>) {
  if (a.size !== b.size) return false
  for (const id of a) {
    if (!b.has(id)) return false
  }
  return true
}

export function RolesPermisosPanel() {
  const roles = useRolesSistema()
  const guardar = useGuardarPermisosRol()
  const [rolId, setRolId] = useState<string | null>(null)
  const [seleccion, setSeleccion] = useState<Set<string>>(new Set())
  const [aviso, setAviso] = useState('')
  const rol = (roles.data ?? []).find((item) => item.id === rolId) ?? roles.data?.[0]

  useEffect(() => {
    const lista = roles.data ?? []
    if (!lista.length) return
    const actual = lista.find((item) => item.id === rolId) ?? lista[0]
    setRolId(actual.id)
    setSeleccion(expandirPermisos(actual.permisos))
  }, [roles.data, rolId])

  const guardado = useMemo(() => expandirPermisos(rol?.permisos), [rol])
  const cambio = rol ? !mismos(seleccion, guardado) : false

  function elegir(siguiente: RolSistema) {
    setRolId(siguiente.id)
    setSeleccion(expandirPermisos(siguiente.permisos))
    setAviso('')
    guardar.reset()
  }

  function fijar(id: string, activo: boolean) {
    setSeleccion((actual) => {
      const next = new Set(actual)
      if (activo) next.add(id)
      else if (!(rol?.codigo === 'administrador' && id === 'sistema')) next.delete(id)
      return next
    })
    setAviso('')
  }

  function fijarGrupo(ids: string[], activo: boolean) {
    setSeleccion((actual) => {
      const next = new Set(actual)
      for (const id of ids) {
        if (activo) next.add(id)
        else if (!(rol?.codigo === 'administrador' && id === 'sistema')) next.delete(id)
      }
      return next
    })
    setAviso('')
  }

  return (
    <section>
      <h2 className="text-lg font-semibold text-foreground">Roles y permisos</h2>
      <p className="mt-1 text-sm text-muted-foreground">
        Cada rol define qué opciones del menú puede abrir una cuenta. Inicio queda siempre visible.
      </p>

      {roles.isLoading ? <p className="mt-4 text-sm text-muted-foreground">Cargando roles…</p> : null}
      {roles.isError ? (
        <p role="alert" className="mt-4 text-sm text-destructive">
          {(roles.error as Error).message}
        </p>
      ) : null}

      {rol ? (
        <div className="mt-4 grid items-start gap-4 lg:grid-cols-[16rem_minmax(0,1fr)]">
          <div className="flex flex-col gap-1" role="listbox" aria-label="Roles">
            {(roles.data ?? []).map((item) => {
              const activo = item.id === rol.id
              return (
                <button
                  key={item.id}
                  type="button"
                  role="option"
                  aria-selected={activo}
                  onClick={() => elegir(item)}
                  className={cn(
                    'rounded-xl px-3 py-2 text-left hover:bg-secondary',
                    activo && 'bg-secondary',
                  )}
                >
                  <span className="block text-sm font-medium text-foreground">{item.nombre}</span>
                  <span className="mt-0.5 block text-xs text-muted-foreground">{item.descripcion}</span>
                </button>
              )
            })}
          </div>

          <form
            className="min-w-0"
            onSubmit={(event) => {
              event.preventDefault()
              if (!rol) return
              guardar.mutate(
                { rolId: rol.id, permisos: [...seleccion] },
                { onSuccess: () => setAviso('Permisos guardados.') },
              )
            }}
          >
            <div className="space-y-3">
              {catalogo.map((grupo) => (
                <GrupoPermisos
                  key={grupo.id}
                  grupo={grupo}
                  seleccion={seleccion}
                  administrador={rol.codigo === 'administrador'}
                  onToggleItem={fijar}
                  onToggleGrupo={fijarGrupo}
                />
              ))}
            </div>
            <div className="mt-4 flex flex-wrap items-center gap-3">
              <Button type="submit" disabled={!cambio || guardar.isPending}>
                {guardar.isPending ? 'Guardando…' : 'Guardar permisos'}
              </Button>
              {aviso ? <p className="text-sm text-foreground">{aviso}</p> : null}
              {guardar.isError ? (
                <p role="alert" className="text-sm text-destructive">
                  {(guardar.error as Error).message}
                </p>
              ) : null}
            </div>
          </form>
        </div>
      ) : null}
    </section>
  )
}

function GrupoPermisos({
  grupo,
  seleccion,
  administrador,
  onToggleItem,
  onToggleGrupo,
}: {
  grupo: (typeof catalogo)[number]
  seleccion: Set<string>
  administrador: boolean
  onToggleItem: (id: string, activo: boolean) => void
  onToggleGrupo: (ids: string[], activo: boolean) => void
}) {
  const ids = grupo.items.map((item) => item.id)
  const marcados = ids.filter((id) => seleccion.has(id)).length
  const ref = useRef<HTMLInputElement>(null)

  useEffect(() => {
    if (ref.current) ref.current.indeterminate = marcados > 0 && marcados < ids.length
  }, [ids.length, marcados])

  return (
    <fieldset className="rounded-xl border border-border p-3">
      <legend className="sr-only">{grupo.label}</legend>
      <label className="flex items-center gap-2 text-sm font-medium text-foreground">
        <input
          ref={ref}
          type="checkbox"
          className="size-4 accent-primary"
          checked={marcados === ids.length}
          onChange={(event) => onToggleGrupo(ids, event.target.checked)}
        />
        {grupo.label}
      </label>
      <ul className="mt-2 space-y-1 pl-6">
        {grupo.items.map((item) => {
          const fijo = administrador && item.id === 'sistema'
          return (
            <li key={item.id}>
              <label className="flex items-center gap-2 text-sm text-foreground">
                <input
                  type="checkbox"
                  className="size-4 accent-primary"
                  checked={seleccion.has(item.id)}
                  disabled={fijo}
                  onChange={(event) => onToggleItem(item.id, event.target.checked)}
                />
                {item.label}
              </label>
            </li>
          )
        })}
      </ul>
    </fieldset>
  )
}
