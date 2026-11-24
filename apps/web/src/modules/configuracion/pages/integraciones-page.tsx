import { useEffect, useState } from 'react'
import { IdCard, Plug } from 'lucide-react'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { AppShell } from '@/design-system/templates'
import {
  useEliminarCredencialDni,
  useGuardarIntegracionDni,
  useIntegracionDni,
} from '@/modules/configuracion/api/integraciones-api'
import { cn } from '@/shared/lib/utils'

const fecha = new Intl.DateTimeFormat('es-PE', {
  day: '2-digit',
  month: '2-digit',
  year: 'numeric',
  hour: '2-digit',
  minute: '2-digit',
  hour12: false,
})

export function IntegracionesPage() {
  const integracion = useIntegracionDni()
  const guardar = useGuardarIntegracionDni()
  const eliminar = useEliminarCredencialDni()
  const [activa, setActiva] = useState(false)
  const [token, setToken] = useState('')
  const [aviso, setAviso] = useState<string | null>(null)

  useEffect(() => {
    if (!integracion.data) return
    setActiva(integracion.data.activa)
    setToken('')
  }, [integracion.data])

  const error =
    (integracion.error as Error | null)?.message ??
    (guardar.error as Error | null)?.message ??
    (eliminar.error as Error | null)?.message ??
    null
  const tieneToken = integracion.data?.tieneToken === true
  const ocupado = guardar.isPending || eliminar.isPending

  return (
    <AppShell>
      <header className="mb-6 space-y-1">
        <h1 className="font-[family-name:var(--font-display)] text-2xl font-semibold text-foreground">
          Integraciones
        </h1>
        <p className="max-w-3xl text-sm text-muted-foreground">
          Autocompleta nombres y apellidos al registrar usuarios a partir del DNI. No verifica
          identidad.
        </p>
      </header>

      <div className="grid items-start gap-4 lg:grid-cols-[15rem_minmax(0,1fr)]">
        <nav aria-label="Integraciones" className="flex flex-col gap-1">
          <p className="px-3 py-1 text-[11px] font-semibold tracking-[0.14em] text-muted-foreground uppercase">
            Inteligencia artificial
          </p>
          <button
            type="button"
            aria-current="page"
            className="flex items-center gap-2 rounded-xl bg-secondary px-3 py-2 text-left text-sm font-medium text-foreground"
          >
            <Icon icon={IdCard} size={16} />
            Consulta de DNI
          </button>
        </nav>

        <section className="min-w-0 max-w-3xl space-y-6">
          {integracion.isLoading ? (
            <p className="text-sm text-muted-foreground">Cargando la integración…</p>
          ) : (
            <>
              <EstadoBanner activa={activa} updatedAt={integracion.data?.updatedAt ?? null} />

              {error ? (
                <p role="alert" className="text-sm text-destructive">
                  {error.replace(/^.*?:\s*/, '')}
                </p>
              ) : null}
              {aviso ? (
                <p role="status" className="text-sm text-foreground">
                  {aviso}
                </p>
              ) : null}

              <form
                className="space-y-6"
                onSubmit={(event) => {
                  event.preventDefault()
                  setAviso(null)
                  guardar.mutate(
                    { proveedor: 'decolecta', token, activa },
                    {
                      onSuccess: () => {
                        setToken('')
                        setAviso('Cambios guardados.')
                      },
                    },
                  )
                }}
              >
                <fieldset className="space-y-4">
                  <legend className="text-[11px] font-semibold tracking-[0.14em] text-muted-foreground uppercase">
                    Proveedor
                  </legend>
                  <label className="flex flex-col gap-1.5 text-sm text-foreground">
                    <span className="inline-flex items-center gap-2">
                      <Icon icon={Plug} size={14} className="text-muted-foreground" />
                      Servicio
                    </span>
                    <Select
                      aria-label="Servicio"
                      value="decolecta"
                      className="h-9 text-sm"
                      onChange={() => undefined}
                    >
                      <option value="decolecta">Decolecta</option>
                    </Select>
                  </label>
                  <label className="flex flex-col gap-1.5 text-sm text-foreground">
                    <span>Token de API</span>
                    <Input
                      type="password"
                      autoComplete="off"
                      value={token}
                      onChange={(event) => setToken(event.target.value)}
                      placeholder="Pega aquí la clave del proveedor"
                      aria-label="Token de API"
                    />
                    <span className="text-xs text-muted-foreground">
                      {tieneToken
                        ? 'Ya hay una clave guardada. Dejala en blanco para conservarla.'
                        : 'La clave queda guardada en el servidor y no vuelve a mostrarse.'}
                    </span>
                  </label>
                </fieldset>

                <fieldset className="space-y-3">
                  <legend className="text-[11px] font-semibold tracking-[0.14em] text-muted-foreground uppercase">
                    Uso en la JASS
                  </legend>
                  <button
                    type="button"
                    role="switch"
                    aria-checked={activa}
                    onClick={() => setActiva((value) => !value)}
                    className="flex w-full items-center justify-between gap-4 rounded-xl border border-border bg-card px-3 py-2.5 text-left transition-colors hover:bg-secondary/60 focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-ring"
                  >
                    <span className="min-w-0">
                      <span className="block text-sm font-medium text-foreground">
                        Integración activa
                      </span>
                      <span className="block text-xs text-muted-foreground">
                        {activa
                          ? 'La consulta de DNI queda habilitada al guardar.'
                          : 'La consulta de DNI queda apagada al guardar.'}
                      </span>
                    </span>
                    <span className="inline-flex shrink-0 items-center gap-2">
                      <span
                        className={cn(
                          'text-xs font-medium',
                          activa ? 'text-primary' : 'text-muted-foreground',
                        )}
                      >
                        {activa ? 'Activada' : 'Desactivada'}
                      </span>
                      <span
                        aria-hidden
                        className={cn(
                          'relative h-7 w-12 rounded-full transition-colors',
                          activa ? 'bg-primary' : 'bg-foreground/15',
                        )}
                      >
                        <span
                          className={cn(
                            'absolute top-0.5 size-6 rounded-full bg-white shadow-md ring-1 ring-black/10 transition-transform',
                            activa ? 'translate-x-5' : 'translate-x-0.5',
                          )}
                        />
                      </span>
                    </span>
                  </button>
                </fieldset>

                <div className="flex flex-wrap items-center justify-end gap-2">
                  <Button type="submit" disabled={ocupado || integracion.isLoading}>
                    {guardar.isPending ? 'Guardando…' : 'Guardar cambios'}
                  </Button>
                </div>
              </form>

              <div className="flex justify-end border-t border-border pt-4">
                <Button
                  type="button"
                  variant="outline"
                  disabled={!tieneToken || ocupado}
                  onClick={() => {
                    setAviso(null)
                    eliminar.mutate(undefined, {
                      onSuccess: () => {
                        setToken('')
                        setActiva(false)
                        setAviso('Credencial eliminada.')
                      },
                    })
                  }}
                >
                  {eliminar.isPending ? 'Eliminando…' : 'Eliminar credencial'}
                </Button>
              </div>
            </>
          )}
        </section>
      </div>
    </AppShell>
  )
}

function EstadoBanner({ activa, updatedAt }: { activa: boolean; updatedAt: string | null }) {
  const cuando = updatedAt ? fecha.format(new Date(updatedAt)) : null
  return (
    <div
      className={cn(
        'rounded-xl border px-4 py-3',
        activa ? 'border-primary/30 bg-primary/10' : 'border-border bg-secondary/70',
      )}
    >
      <p className="text-sm font-medium text-foreground">
        {activa ? 'Activa para esta JASS' : 'Desactivada para esta JASS'}
      </p>
      <p className="mt-1 text-sm text-muted-foreground">
        {activa
          ? 'Quienes registran usuarios pueden consultar el DNI.'
          : 'Nadie puede usarla hasta que la actives.'}
      </p>
      {cuando ? (
        <p className="mt-2 text-xs text-muted-foreground">Actualizado el {cuando}</p>
      ) : null}
    </div>
  )
}
