import type { ReactNode } from 'react'
import { RecordWorkspace } from '@/design-system/templates'

export interface HidroWorkspaceProps {
  title: string
  description: string
  search: string
  onSearchChange: (value: string) => void
  searchPlaceholder: string
  filters?: ReactNode
  hasActiveFilters?: boolean
  onResetFilters?: () => void
  onNew: () => void
  list: ReactNode
  formTitle: string
  formDescription: string
  form: ReactNode
}

export function HidroWorkspace(props: HidroWorkspaceProps) {
  return <RecordWorkspace wide {...props} />
}
