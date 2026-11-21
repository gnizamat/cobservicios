import { useMemo, useState, type ReactNode } from 'react'
import { useLocation } from 'react-router-dom'
import { AppHeader } from '@/design-system/organisms'
import { useMisPermisos } from '@/modules/configuracion'
import { AppSidebar } from '@/modules/navegacion/components/app-sidebar'
import { findNavItemByPath, flattenNavItems, pathIsCurrent } from '@/modules/navegacion/menu'
import { opcionPermitida } from '@/modules/navegacion/permisos'
import { cn } from '@/shared/lib/utils'

export interface AppShellProps {
  children: ReactNode
  className?: string
}

export function AppShell({ children, className }: AppShellProps) {
  const location = useLocation()
  const [mobileOpen, setMobileOpen] = useState(false)
  const [collapsed, setCollapsed] = useState(false)

  const acceso = useMisPermisos()
  const current = useMemo(
    () => findNavItemByPath(location.pathname),
    [location.pathname],
  )
  const protegida = useMemo(
    () =>
      flattenNavItems().find(
        (item) => item.path && pathIsCurrent(location.pathname, item.path),
      ),
    [location.pathname],
  )
  const bloqueada = Boolean(
    protegida &&
      protegida.id !== 'dashboard' &&
      acceso.data?.conocido &&
      !opcionPermitida(acceso.data, protegida.id),
  )

  return (
    <div className="flex h-dvh overflow-hidden bg-background md:gap-2 md:p-2">
      <div
        className={cn(
          'fixed inset-y-2 left-2 z-30 h-[calc(100dvh-1rem)] shrink-0 transition-transform duration-200 md:static md:z-auto md:h-full',
          mobileOpen ? 'translate-x-0' : '-translate-x-[120%] md:translate-x-0',
        )}
      >
        <AppSidebar
          collapsed={collapsed}
          onToggleCollapsed={() => {
            if (window.matchMedia('(max-width: 767px)').matches) {
              setMobileOpen(false)
              return
            }
            setCollapsed((value) => !value)
          }}
          onNavigate={() => setMobileOpen(false)}
        />
      </div>

      {mobileOpen ? (
        <button
          type="button"
          className="fixed inset-0 z-20 bg-foreground/20 md:hidden"
          aria-label="Cerrar menú"
          onClick={() => setMobileOpen(false)}
        />
      ) : null}

      <div className="flex h-full min-w-0 flex-1 flex-col overflow-hidden md:rounded-3xl md:border md:border-border md:bg-card md:shadow-[var(--shadow-sm)]">
        <AppHeader
          title={current?.label ?? 'COBSERVICIOS'}
          subtitle={current?.description}
          sidebarOpen={mobileOpen || !collapsed}
          onToggleSidebar={() => {
            if (window.matchMedia('(min-width: 768px)').matches) {
              setCollapsed((value) => !value)
              return
            }
            setCollapsed(false)
            setMobileOpen((value) => !value)
          }}
        />
        <div className="min-h-0 flex-1 overflow-y-auto">
          <main className={cn('mx-auto w-full max-w-6xl px-4 py-6 sm:px-6', className)}>
            {bloqueada ? (
              <p role="alert" className="text-sm text-muted-foreground">
                Tu rol no tiene permiso para abrir esta opción.
              </p>
            ) : (
              children
            )}
          </main>
        </div>
      </div>
    </div>
  )
}
