import { useEffect } from 'react'
import { Gauge, Users } from 'lucide-react'
import { useSearchParams } from 'react-router-dom'
import { Icon } from '@/design-system/atoms'
import { AppShell } from '@/design-system/templates'
import { ColaboradoresPanel } from '@/modules/configuracion/components/colaboradores-panel'
import { MarcasMedidorPanel } from '@/modules/configuracion/components/marcas-medidor-panel'
import { cn } from '@/shared/lib/utils'

const secciones = [
  { id: 'colaboradores', label: 'Colaboradores', icon: Users },
  { id: 'medidores', label: 'Medidores', icon: Gauge },
] as const

type SeccionId = (typeof secciones)[number]['id']

function seccionActual(value: string | null): SeccionId {
  return secciones.some((item) => item.id === value) ? (value as SeccionId) : 'colaboradores'
}

export function HidrometriaConfigPage() {
  const [params, setParams] = useSearchParams()
  const seccion = seccionActual(params.get('seccion'))

  useEffect(() => {
    if (params.get('seccion') === seccion) return
    const next = new URLSearchParams(params)
    next.set('seccion', seccion)
    setParams(next, { replace: true })
  }, [params, seccion, setParams])

  return (
    <AppShell className="max-w-7xl">
      <header className="mb-4 space-y-1">
        <h1 className="inline-flex items-center gap-2 font-[family-name:var(--font-display)] text-2xl font-semibold text-foreground">
          <Icon icon={Gauge} size={22} />
          Hidrometría
        </h1>
        <p className="max-w-3xl text-sm text-muted-foreground">
          Colaboradores de las lecturas y las marcas de medidor con su procedencia.
        </p>
      </header>
      <div className="grid items-start gap-6 lg:grid-cols-[13.5rem_minmax(0,1fr)]">
        <nav aria-label="Secciones de hidrometría" className="flex flex-col gap-0.5 lg:sticky lg:top-0">
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
        <section className="min-w-0 rounded-2xl border border-border bg-card p-4 shadow-[var(--shadow-sm)]">
          {seccion === 'colaboradores' ? <ColaboradoresPanel /> : null}
          {seccion === 'medidores' ? <MarcasMedidorPanel /> : null}
        </section>
      </div>
    </AppShell>
  )
}
