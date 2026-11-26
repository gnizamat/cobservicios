import type { ReactNode } from 'react'
import { cn } from '@/shared/lib/utils'

export interface FormLayoutProps {
  children: ReactNode
  footer?: ReactNode
  className?: string
  /** 1 columna para paneles laterales; 2 o 4 cuando el formulario tiene ancho. */
  columns?: 1 | 2 | 4
  /** Menos padding y separación, para que el formulario quepa sin scroll. */
  dense?: boolean
}

export function FormLayout({ children, footer, className, columns = 2, dense = false }: FormLayoutProps) {
  return (
    <div
      className={cn(
        'rounded-2xl border border-border bg-card p-5 shadow-[var(--shadow-sm)] sm:p-6',
        dense && 'p-3 sm:p-4',
        className,
      )}
    >
      <div
        className={cn(
          'grid gap-4',
          dense && 'gap-x-3 gap-y-2',
          columns === 1 && 'grid-cols-1',
          columns === 2 && 'sm:grid-cols-2',
          columns === 4 && 'grid-cols-2 sm:grid-cols-4',
        )}
      >
        {children}
      </div>
      {footer ? (
        <div
          className={cn(
            'mt-6 flex flex-wrap items-center justify-end gap-2 border-t border-border pt-4',
            dense && 'mt-3 pt-3',
          )}
        >
          {footer}
        </div>
      ) : null}
    </div>
  )
}
