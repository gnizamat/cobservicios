import { Menu, PanelLeftClose, PanelLeftOpen } from 'lucide-react'
import { Button, Icon } from '@/design-system/atoms'
import { UserMenu } from '@/modules/navegacion/components/user-menu'

export interface AppHeaderProps {
  title?: string
  subtitle?: string
  sidebarOpen?: boolean
  onToggleSidebar?: () => void
}

export function AppHeader({
  title = 'Panel principal',
  subtitle,
  sidebarOpen = true,
  onToggleSidebar,
}: AppHeaderProps) {
  return (
    <header className="flex h-14 items-center gap-3 border-b border-border bg-card/95 px-4 shadow-[var(--shadow-sm)] backdrop-blur-sm">
      {onToggleSidebar ? (
        <Button
          type="button"
          variant="ghost"
          size="icon"
          onClick={onToggleSidebar}
          aria-label={sidebarOpen ? 'Ocultar menú' : 'Mostrar menú'}
        >
          <Icon
            icon={sidebarOpen ? PanelLeftClose : PanelLeftOpen}
            className="hidden sm:block"
          />
          <Icon icon={Menu} className="sm:hidden" />
        </Button>
      ) : null}

      <div className="min-w-0 flex-1 leading-tight">
        <h1 className="truncate font-[family-name:var(--font-display)] text-sm font-semibold text-foreground">
          {title}
        </h1>
        {subtitle ? (
          <p className="truncate text-xs text-muted-foreground">{subtitle}</p>
        ) : null}
      </div>

      <UserMenu />
    </header>
  )
}
