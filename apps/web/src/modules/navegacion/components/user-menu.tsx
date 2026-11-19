import { LogOut, UserRound } from 'lucide-react'
import { Button, Icon } from '@/design-system/atoms'
import { useAuth, useSignOut } from '@/modules/auth'

export function UserMenu() {
  const { user } = useAuth()
  const signOut = useSignOut()

  return (
    <div className="flex items-center gap-2">
      <div className="hidden items-center gap-2 rounded-full border border-border bg-background px-3 py-1.5 sm:flex">
        <Icon icon={UserRound} size={14} className="text-muted-foreground" />
        <span className="max-w-48 truncate text-xs text-foreground">
          {user?.email ?? 'Sesión'}
        </span>
      </div>
      <Button
        type="button"
        variant="outline"
        size="sm"
        disabled={signOut.isPending}
        onClick={() => signOut.mutate()}
      >
        <Icon icon={LogOut} size={14} />
        Salir
      </Button>
    </div>
  )
}
