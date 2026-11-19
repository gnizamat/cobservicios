import type { ReactNode } from 'react'
import { Droplets } from 'lucide-react'
import { Icon } from '@/design-system/atoms'
import { cn } from '@/shared/lib/utils'

export interface AuthLayoutProps {
  children: ReactNode
  slogan: ReactNode
  className?: string
}

/**
 * Full-viewport access scene: a slow aerial approach, then the slogan and
 * the sign-in card. The photograph is decorative.
 */
export function AuthLayout({ children, slogan, className }: AuthLayoutProps) {
  return (
    <div className={cn('login-scene', className)}>
      <div className="login-scene__sky" aria-hidden>
        <img
          className="login-scene__photo"
          src="/login/valle.jpg"
          alt=""
        />
        <div className="login-scene__shade" />
      </div>

      <header className="login-scene__bar">
        <div className="flex items-center gap-2.5">
          <span className="flex h-9 w-9 items-center justify-center rounded-full bg-[var(--login-mark)] text-[var(--login-mark-ink)]">
            <Icon icon={Droplets} size={18} />
          </span>
          <span className="text-lg font-semibold tracking-tight">cobservicios</span>
        </div>
        <p className="text-[0.68rem] font-medium tracking-[0.22em] text-[var(--login-muted)] uppercase">
          JASS · Pedregal
        </p>
      </header>

      <main className="login-scene__stage">
        <div className="login-scene__story">{slogan}</div>
        <div className="login-scene__panel">{children}</div>
      </main>
    </div>
  )
}
