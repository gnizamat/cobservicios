import type { LucideIcon, LucideProps } from 'lucide-react'
import { cn } from '@/shared/lib/utils'

export interface IconProps extends LucideProps {
  icon: LucideIcon
}

/** Atom for Lucide icons with consistent sizing. */
export function Icon({ icon: Lucide, className, size = 16, ...props }: IconProps) {
  return <Lucide className={cn('shrink-0', className)} size={size} {...props} />
}
