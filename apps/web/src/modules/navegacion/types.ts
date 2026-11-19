import type { LucideIcon } from 'lucide-react'

export type NavItemStatus = 'ready' | 'soon'

export interface NavItem {
  id: string
  label: string
  description?: string
  path?: string
  icon?: LucideIcon
  /** idMenu del legado VB.NET (referencia) */
  legacyId?: number
  status?: NavItemStatus
  children?: NavItem[]
}

export interface NavSection {
  id: string
  label: string
  description?: string
  icon: LucideIcon
  items: NavItem[]
}
