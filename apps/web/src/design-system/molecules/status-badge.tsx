import { cn } from '@/shared/lib/utils'

export interface StatusBadgeProps {
  status: 'activo' | 'inactivo' | string
  className?: string
}

export function StatusBadge({ status, className }: StatusBadgeProps) {
  const active = status === 'activo'
  return (
    <span
      className={cn(
        'inline-flex rounded-md px-1.5 py-0.5 text-[11px] font-medium leading-none',
        active
          ? 'bg-accent/25 text-accent-foreground'
          : 'bg-muted text-muted-foreground',
        className,
      )}
    >
      {active ? 'Activo' : 'Inactivo'}
    </span>
  )
}
