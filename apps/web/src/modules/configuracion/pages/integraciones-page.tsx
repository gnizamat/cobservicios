import { useEffect, useState } from 'react'
import { Building2, IdCard, KeyRound, Plug, Sparkles } from 'lucide-react'
import type { UseMutationResult, UseQueryResult } from '@tanstack/react-query'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { AppShell } from '@/design-system/templates'
import {
  useEliminarCredencialDni,
  useEliminarCredencialIa,
  useEliminarCredencialRuc,
  useGuardarIntegracionDni,
  useGuardarIntegracionIa,
  useGuardarIntegracionRuc,
  useIntegracionDni,
  useIntegracionIa,
  useIntegracionRuc,
  type IntegracionDni,
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

type Seccion = 'ia' | 'dni' | 'ruc'

const secciones = [
  { id: 'ia', label: 'Inteligencia artificial', icon: Sparkles },
  { id: 'dni', label: 'Consulta de DNI', icon: IdCard },
  { id: 'ruc', label: 'Consulta de RUC', icon: Building2 },
] as const

const textos: Record<
  'dni' | 'ruc',
  { habilitada: string; apagada: string; usoActivo: string }
> = {
  dni: {
    habilitada: 'La consulta de DNI queda habilitada al guardar.',
    apagada: 'La consulta de DNI queda apagada al guardar.',
    usoActivo: 'Quienes registran usuarios pueden consultar el DNI.',
  },
  ruc: {
    habilitada: 'La consulta de RUC queda habilitada al guardar.',
    apagada: 'La consulta de RUC queda apagada al guardar.',
    usoActivo: 'Quienes registran usuarios pueden consultar el RUC.',
  },
}

export function IntegracionesPage() {
  const [seccion, setSeccion] = useState<Seccion>('ia')

  return (
    <AppShell>
      <header className="mb-6 space-y-1">
        <h1 className="font-[family-name:var(--font-display)] text-2xl font-semibold text-foreground">
          Integraciones
        </h1>
        <p className="max-w-3xl text-sm text-muted-foreground">
          Conecta la JASS con servicios externos. Las claves quedan en el servidor y no vuelven a
          mostrarse.
        </p>
      </header>

      <div className="grid items-start gap-4 lg:grid-cols-[15rem_minmax(0,1fr)]">
        <nav aria-label="Integraciones" className="flex flex-col gap-1">
          {secciones.map((item) => {
            const activa = seccion === item.id
            return (
              <button
                key={item.id}
                type="button"
                aria-current={activa ? 'page' : undefined}
                onClick={() => setSeccion(item.id)}
                className={cn(
                  'flex items-center gap-2 rounded-xl px-3 py-2 text-left text-sm text-muted-foreground hover:bg-secondary hover:text-foreground',
                  activa && 'bg-secondary font-medium text-foreground',
                )}
              >
                <Icon icon={item.icon} size={16} />
                {item.label}
              </button>
            )
          })}
        </nav>

        {seccion === 'ia' ? <PanelIa key="ia" /> : null}
        {seccion === 'dni' ? <PanelDni key="dni" /> : null}
        {seccion === 'ruc' ? <PanelRuc key="ruc" /> : null}
      </div>
    </AppShell>
  )
}

function PanelIa() {
  const integracion = useIntegracionIa()
  const guardar = useGuardarIntegracionIa()
  const eliminar = useEliminarCredencialIa()
  const [token, setToken] = useState('')
  const [modelo, setModelo] = useState('gpt-4.1-mini')
  const [aviso, setAviso] = useState<string | null>(null)

  useEffect(() => {
    if (!integracion.data) return
    setModelo(integracion.data.modelo)
    setToken('')
  }, [integracion.data])

  const error =
    (integracion.error as Error | null)?.message ??
    (guardar.error as Error | null)?.message ??
    (eliminar.error as Error | null)?.message ??
    null
  const tieneToken = integracion.data?.tieneToken === true
  const sufijo = integracion.data?.sufijo ?? ''
  const ocupado = guardar.isPending || eliminar.isPending

  return (
    <section className="min-w-0 max-w-3xl space-y-6">
      <div className="space-y-1">
        <h2 className="text-base font-semibold text-foreground">Conversaciones</h2>
        <p className="max-w-2xl text-sm text-muted-foreground">
          Modelo de lenguaje de la JASS. Funciona con la clave guardada en el servidor.
        </p>
      </div>

      {integracion.isLoading ? (
        <p className="text-sm text-muted-foreground">Cargando la integración…</p>
      ) : (
        <form
          className="space-y-6 rounded-2xl border border-border bg-card p-4 sm:p-5"
          onSubmit={(event) => {
            event.preventDefault()
            setAviso(null)
            guardar.mutate(
              { proveedor: 'openai', token, modelo },
              {
                onSuccess: () => {
                  setToken('')
                  setAviso('Cambios guardados.')
                },
              },
            )
          }}
        >
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

          <label className="flex flex-col gap-1.5 text-sm text-foreground">
            <span className="inline-flex items-center gap-2">
              <Icon icon={Plug} size={14} className="text-muted-foreground" />
              Proveedor
            </span>
            <Select
              aria-label="Proveedor"
              value="openai"
              className="h-9 text-sm"
              onChange={() => undefined}
            >
              <option value="openai">OpenAI</option>
            </Select>
          </label>

          <label className="flex flex-col gap-1.5 text-sm text-foreground">
            <span className="inline-flex items-center gap-2">
              <Icon icon={KeyRound} size={14} className="text-muted-foreground" />
              API key de OpenAI
            </span>
            <Input
              type="password"
              autoComplete="off"
              value={token}
              onChange={(event) => setToken(event.target.value)}
              placeholder={
                tieneToken && sufijo
                  ? `Guardada: **** ${sufijo}`
                  : tieneToken
                    ? 'Ya hay una clave guardada'
                    : 'Pega aquí la clave de OpenAI'
              }
              aria-label="API key de OpenAI"
            />
            <span className="text-xs text-muted-foreground">
              {tieneToken
                ? 'Dejala en blanco para conservar la clave guardada.'
                : 'La clave queda guardada en el servidor y no vuelve a mostrarse.'}
            </span>
          </label>

          <label className="flex flex-col gap-1.5 text-sm text-foreground">
            <span>Modelo</span>
            <Input
              value={modelo}
              onChange={(event) => setModelo(event.target.value)}
              aria-label="Modelo"
              spellCheck={false}
              autoCapitalize="off"
            />
          </label>

          <div className="flex flex-wrap items-center justify-end gap-2">
            <Button
              type="button"
              variant="outline"
              disabled={!tieneToken || ocupado}
              onClick={() => {
                setAviso(null)
                eliminar.mutate(undefined, {
                  onSuccess: () => {
                    setToken('')
                    setAviso('Clave eliminada.')
                  },
                })
              }}
            >
              {eliminar.isPending ? 'Quitando…' : 'Quitar clave de OpenAI'}
            </Button>
            <Button type="submit" disabled={ocupado || integracion.isLoading}>
              {guardar.isPending ? 'Guardando…' : 'Guardar'}
            </Button>
          </div>
        </form>
      )}
    </section>
  )
}

function PanelDni() {
  return (
    <PanelConsulta
      seccion="dni"
      integracion={useIntegracionDni()}
      guardar={useGuardarIntegracionDni()}
      eliminar={useEliminarCredencialDni()}
    />
  )
}

function PanelRuc() {
  return (
    <PanelConsulta
      seccion="ruc"
      integracion={useIntegracionRuc()}
      guardar={useGuardarIntegracionRuc()}
      eliminar={useEliminarCredencialRuc()}
    />
  )
}

function PanelConsulta({
  seccion,
  integracion,
  guardar,
  eliminar,
}: {
  seccion: 'dni' | 'ruc'
  integracion: UseQueryResult<IntegracionDni>
  guardar: UseMutationResult<
    IntegracionDni,
    Error,
    { proveedor: 'decolecta'; token: string; activa: boolean }
  >
  eliminar: UseMutationResult<IntegracionDni, Error, void>
}) {
  const [activa, setActiva] = useState(false)
  const [token, setToken] = useState('')
  const [aviso, setAviso] = useState<string | null>(null)
  const copia = textos[seccion]

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
    <section className="min-w-0 max-w-3xl space-y-6">
      {integracion.isLoading ? (
        <p className="text-sm text-muted-foreground">Cargando la integración…</p>
      ) : (
        <>
          <EstadoBanner
            activa={activa}
            updatedAt={integracion.data?.updatedAt ?? null}
            usoActivo={copia.usoActivo}
          />

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
                    {activa ? copia.habilitada : copia.apagada}
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
  )
}

function EstadoBanner({
  activa,
  updatedAt,
  usoActivo,
}: {
  activa: boolean
  updatedAt: string | null
  usoActivo: string
}) {
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
        {activa ? usoActivo : 'Nadie puede usarla hasta que la actives.'}
      </p>
      {cuando ? (
        <p className="mt-2 text-xs text-muted-foreground">Actualizado el {cuando}</p>
      ) : null}
    </div>
  )
}
