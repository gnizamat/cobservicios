import { Building2, MapPinned, MapPin } from 'lucide-react'
import { useState } from 'react'
import { Icon } from '@/design-system/atoms'
import { AppShell } from '@/design-system/templates'
import {
  useOrganizacion,
  useRemoveLogo,
  useSaveDatosJass,
  useSaveUbicacion,
  useUploadLogo,
} from '@/modules/configuracion/api'
import { CentrosPobladosPanel } from '@/modules/configuracion/components/centros-poblados-panel'
import { DatosJassForm } from '@/modules/configuracion/components/datos-jass-form'
import { UbicacionForm } from '@/modules/configuracion/components/ubicacion-form'
import { cn } from '@/shared/lib/utils'

const secciones = [
  { id: 'datos', label: 'Datos de la JASS', icon: Building2 },
  { id: 'ubicacion', label: 'Ubicación', icon: MapPin },
  { id: 'centros', label: 'Centros poblados', icon: MapPinned },
] as const

type SeccionId = (typeof secciones)[number]['id']

export function OrganizacionPage() {
  const [seccion, setSeccion] = useState<SeccionId>('datos')
  const [notice, setNotice] = useState<string | null>(null)
  const organizacion = useOrganizacion()
  const saveDatos = useSaveDatosJass()
  const saveUbicacion = useSaveUbicacion()
  const uploadLogo = useUploadLogo()
  const removeLogo = useRemoveLogo()
  const error =
    (organizacion.error as Error | null)?.message ??
    (saveDatos.error as Error | null)?.message ??
    (saveUbicacion.error as Error | null)?.message ??
    (uploadLogo.error as Error | null)?.message ??
    (removeLogo.error as Error | null)?.message ??
    null

  return (
    <AppShell>
      <header className="mb-6 space-y-1">
        <h1 className="font-[family-name:var(--font-display)] text-2xl font-semibold text-foreground">
          Configuración de la JASS
        </h1>
        <p className="max-w-2xl text-sm text-muted-foreground">
          Nombre, logo y contacto de la junta, la sede en el mapa y los centros poblados.
        </p>
      </header>
      <div className="grid items-start gap-4 lg:grid-cols-[15rem_minmax(0,1fr)]">
        <nav aria-label="Secciones de configuración" className="flex flex-col gap-1">
          {secciones.map((item) => {
            const active = seccion === item.id
            return (
              <button
                key={item.id}
                type="button"
                aria-current={active ? 'page' : undefined}
                onClick={() => {
                  setNotice(null)
                  setSeccion(item.id)
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
        <section className="min-w-0">
          {notice ? (
            <p role="status" className="mb-3 text-sm text-foreground">
              {notice}
            </p>
          ) : null}
          {error && seccion !== 'centros' ? (
            <p role="alert" className="mb-3 text-sm text-destructive">
              {error}
            </p>
          ) : null}
          {seccion === 'centros' ? (
            <CentrosPobladosPanel />
          ) : organizacion.isLoading ? (
            <p className="text-sm text-muted-foreground">Cargando la configuración…</p>
          ) : organizacion.data && seccion === 'datos' ? (
            <DatosJassForm
              key={`${organizacion.data.updated_at}-${organizacion.data.logo_path}`}
              organizacion={organizacion.data}
              submitting={saveDatos.isPending}
              uploading={uploadLogo.isPending}
              removing={removeLogo.isPending}
              onSubmit={(values) => {
                saveDatos.mutate(values, { onSuccess: () => setNotice('Se guardaron los datos de la JASS.') })
              }}
              onUploadLogo={(file) => {
                uploadLogo.mutate(file, { onSuccess: () => setNotice('Se actualizó el logo.') })
              }}
              onRemoveLogo={() => {
                removeLogo.mutate(undefined, { onSuccess: () => setNotice('Se quitó el logo.') })
              }}
            />
          ) : organizacion.data ? (
            <UbicacionForm
              key={`${organizacion.data.latitud}-${organizacion.data.longitud}`}
              organizacion={organizacion.data}
              submitting={saveUbicacion.isPending}
              onSubmit={(values) => {
                saveUbicacion.mutate(values, { onSuccess: () => setNotice('Se guardó la ubicación.') })
              }}
            />
          ) : null}
        </section>
      </div>
    </AppShell>
  )
}
