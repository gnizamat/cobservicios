import { NavLink, useLocation } from 'react-router-dom'
import { PageHeader } from '@/design-system/molecules'
import { AppShell } from '@/design-system/templates'
import { AsambleasPage } from '@/modules/asambleas/pages/asambleas-page'
import { AsistenciaPage } from '@/modules/asambleas/pages/asistencia-page'
import { cn } from '@/shared/lib/utils'

const tabs = [
  {
    id: 'registro',
    label: 'Registro de asambleas',
    to: '/padron/asambleas',
    end: true,
    description: 'Registrá la asamblea del centro poblado: descripción, ámbito, tipo y fecha.',
  },
  {
    id: 'asistencia',
    label: 'Asistencia de usuarios',
    to: '/padron/asambleas/asistencia',
    end: false,
    description:
      'Usuarios hábiles, sin deuda de tarifa ni aporte económico. Marcá quién asistió y sacá el padrón, la lista de asistentes y el resumen por calle.',
  },
] as const

export function AsambleasSectionPage() {
  const { pathname } = useLocation()
  const activa = tabs.find((tab) => pathname.startsWith(tab.to) && !tab.end) ?? tabs[0]

  return (
    <AppShell className="max-w-7xl">
      <PageHeader title="Asambleas" description={activa.description} />
      <div role="tablist" aria-label="Asambleas" className="mb-4 flex gap-1 border-b border-border">
        {tabs.map((tab) => (
          <NavLink
            key={tab.id}
            to={tab.to}
            end={tab.end}
            role="tab"
            aria-selected={activa.id === tab.id}
            className={({ isActive }) =>
              cn(
                '-mb-px border-b-2 px-3 py-2 text-sm',
                isActive
                  ? 'border-primary font-medium text-foreground'
                  : 'border-transparent text-muted-foreground hover:text-foreground',
              )
            }
          >
            {tab.label}
          </NavLink>
        ))}
      </div>
      {activa.id === 'asistencia' ? <AsistenciaPage embedded /> : <AsambleasPage embedded />}
    </AppShell>
  )
}
