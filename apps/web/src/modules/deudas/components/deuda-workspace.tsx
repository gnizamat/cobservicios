import type { ReactNode } from 'react'
import { RecordWorkspace } from '@/design-system/templates'

export interface DeudaWorkspaceProps {
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

export function DeudaWorkspace(props: DeudaWorkspaceProps) {
  return <RecordWorkspace {...props} />
}
