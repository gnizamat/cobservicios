import { useEffect } from 'react'
import {
  Banknote,
  CalendarRange,
  FileText,
  Landmark,
  Percent,
  Receipt,
  Tags,
  Wallet,
} from 'lucide-react'
import { useSearchParams } from 'react-router-dom'
import { Icon } from '@/design-system/atoms'
import { AppShell } from '@/design-system/templates'
import { CostosTarifasPage, ServiciosPage, TarifasPage } from '@/modules/catalogo'
import {
  BancosPanel,
  CajasPanel,
  ConceptosMultaPanel,
  DocumentosPanel,
  InteresesPanel,
} from '@/modules/configuracion/components/cobranza-catalogos'
import { cn } from '@/shared/lib/utils'

const secciones = [
  { id: 'anios', label: 'Años de tarifa', icon: CalendarRange },
  { id: 'tipos', label: 'Tipos de tarifa', icon: Tags },
  { id: 'costos', label: 'Costos de tarifas', icon: Receipt },
  { id: 'multas', label: 'Conceptos de multa', icon: Banknote },
  { id: 'intereses', label: 'Intereses', icon: Percent },
  { id: 'bancos', label: 'Bancos', icon: Landmark },
  { id: 'cajas', label: 'Cajas', icon: Wallet },
  { id: 'documentos', label: 'Documentos', icon: FileText },
] as const

type SeccionId = (typeof secciones)[number]['id']

function seccionActual(value: string | null): SeccionId {
  return secciones.some((item) => item.id === value) ? (value as SeccionId) : 'anios'
}

export function CobranzaConfigPage() {
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
        <h1 className="font-[family-name:var(--font-display)] text-2xl font-semibold text-foreground">
          Configuración de cobranza
        </h1>
        <p className="max-w-3xl text-sm text-muted-foreground">
          Años y tipos de tarifa, costos, conceptos de multa, intereses, bancos, cajas y documentos.
        </p>
      </header>
      <div className="grid items-start gap-6 lg:grid-cols-[13.5rem_minmax(0,1fr)]">
        <nav
          aria-label="Secciones de cobranza"
          className="flex flex-col gap-0.5 lg:sticky lg:top-0"
        >
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
        <Seccion seccion={seccion} />
      </div>
    </AppShell>
  )
}

function Seccion({ seccion }: { seccion: SeccionId }) {
  if (seccion === 'anios') return <TarifasPage embedded />
  if (seccion === 'tipos') {
    return (
      <ServiciosPage
        embedded
        title="Tipos de tarifa"
        description="Tipos de tarifa que se usan para armar los costos de cada año."
      />
    )
  }
  if (seccion === 'costos') return <CostosTarifasPage embedded />

  return (
    <section className="min-w-0 rounded-2xl border border-border bg-card p-4 shadow-[var(--shadow-sm)]">
      {seccion === 'multas' ? <ConceptosMultaPanel /> : null}
      {seccion === 'intereses' ? <InteresesPanel /> : null}
      {seccion === 'bancos' ? <BancosPanel /> : null}
      {seccion === 'cajas' ? <CajasPanel /> : null}
      {seccion === 'documentos' ? <DocumentosPanel /> : null}
    </section>
  )
}
