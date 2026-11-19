import type { ReactNode } from 'react'
import { cn } from '@/shared/lib/utils'

export interface FormLayoutProps {
  children: ReactNode
  footer?: ReactNode
  className?: string
  /** 1 columna para paneles laterales; 2 a partir de `sm` en formularios anchos. */
  columns?: 1 | 2
}

export function FormLayout({ children, footer, className, columns = 2 }: FormLayoutProps) {
  return (
    <div
      className={cn(
        'rounded-2xl border border-border bg-card p-5 shadow-[var(--shadow-sm)] sm:p-6',
        className,
      )}
    >
      <div className={cn('grid gap-4', columns === 1 ? 'grid-cols-1' : 'sm:grid-cols-2')}>
        {children}
      </div>
      {footer ? (
        <div className="mt-6 flex flex-wrap items-center justify-end gap-2 border-t border-border pt-4">
          {footer}
        </div>
      ) : null}
    </div>
  )
}
