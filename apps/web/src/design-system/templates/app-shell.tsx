import { useMemo, useState, type ReactNode } from 'react'
import { useLocation } from 'react-router-dom'
import { AppHeader } from '@/design-system/organisms'
import { AppSidebar } from '@/modules/navegacion/components/app-sidebar'
import { findNavItemByPath } from '@/modules/navegacion/menu'
import { cn } from '@/shared/lib/utils'

export interface AppShellProps {
  children: ReactNode
  className?: string
}

export function AppShell({ children, className }: AppShellProps) {
  const location = useLocation()
  const [mobileOpen, setMobileOpen] = useState(false)
  const [collapsed, setCollapsed] = useState(false)

  const current = useMemo(
    () => findNavItemByPath(location.pathname),
    [location.pathname],
  )

  return (
    <div className="flex min-h-screen bg-background md:gap-3 md:p-3">
      <div
        className={cn(
          'fixed inset-y-3 left-3 z-30 h-[calc(100vh-1.5rem)] transition-transform duration-200 md:sticky md:top-3 md:inset-auto md:z-auto md:h-[calc(100vh-1.5rem)] md:translate-x-0 md:self-start',
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

      <div className="flex min-h-screen min-w-0 flex-1 flex-col md:min-h-[calc(100vh-1.5rem)] md:rounded-3xl md:border md:border-border md:bg-card md:shadow-[var(--shadow-sm)]">
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
        <main className={cn('mx-auto w-full max-w-6xl flex-1 px-4 py-6 sm:px-6', className)}>
          {children}
        </main>
      </div>
    </div>
  )
}
