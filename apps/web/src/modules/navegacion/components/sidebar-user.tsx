import { AppearanceMenu } from '@/modules/navegacion/components/appearance-menu'
import { useAuth } from '@/modules/auth'
import { cn } from '@/shared/lib/utils'

function sessionLabel(email: string | undefined) {
  const local = email?.split('@')[0]?.trim()
  if (!local) return { initials: 'CS', name: 'Sesión', detail: 'Usuario del sistema' }
  const initials = local.slice(0, 2).toUpperCase()
  return { initials, name: local, detail: email ?? 'Sesión activa' }
}

export function SidebarUser({ collapsed = false }: { collapsed?: boolean }) {
  const { user } = useAuth()
  const session = sessionLabel(user?.email)

  return (
    <div
      className={cn(
        'mt-auto flex items-center gap-2 border-t border-border/80 px-3 py-3',
        collapsed && 'flex-col px-2',
      )}
    >
      <span className="flex h-9 w-9 shrink-0 items-center justify-center rounded-full bg-primary text-xs font-semibold text-primary-foreground">
        {session.initials}
      </span>
      {collapsed ? null : (
        <span className="min-w-0 flex-1 leading-tight">
          <span className="block truncate text-xs font-semibold tracking-wide text-foreground uppercase">
            {session.name}
          </span>
          <span className="block truncate text-[11px] text-muted-foreground">{session.detail}</span>
        </span>
      )}
      <AppearanceMenu collapsed={collapsed} />
    </div>
  )
}
