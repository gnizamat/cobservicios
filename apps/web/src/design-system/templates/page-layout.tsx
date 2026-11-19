import type { ReactNode } from 'react'
import { AppHeader } from '@/design-system/organisms'
import { cn } from '@/shared/lib/utils'

export interface PageLayoutProps {
  children: ReactNode
  className?: string
}

export function PageLayout({ children, className }: PageLayoutProps) {
  return (
    <div className="flex min-h-screen flex-col bg-background">
      <AppHeader />
      <main className={cn('mx-auto w-full max-w-6xl flex-1 px-6 py-8', className)}>
        {children}
      </main>
    </div>
  )
}
