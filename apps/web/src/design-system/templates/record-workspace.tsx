import type { ReactNode } from 'react'
import { Plus } from 'lucide-react'
import { Button, Icon } from '@/design-system/atoms'
import { ListFilters, PageHeader } from '@/design-system/molecules'
import { AppShell } from '@/design-system/templates/app-shell'

export interface RecordWorkspaceProps {
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
  /** Sin el marco de la aplicación, para incrustar el catálogo en otra pantalla. */
  embedded?: boolean
}

export function RecordWorkspace({
  title,
  description,
  search,
  onSearchChange,
  searchPlaceholder,
  filters,
  hasActiveFilters,
  onResetFilters,
  onNew,
  list,
  formTitle,
  formDescription,
  form,
  embedded = false,
}: RecordWorkspaceProps) {
  const body = (
    <>
      <PageHeader
        title={title}
        description={description}
        actions={
          <Button type="button" size="sm" onClick={onNew}>
            <Icon icon={Plus} size={16} />
            Nuevo
          </Button>
        }
      />

      <ListFilters
        liveSearch
        search={search}
        onSearchChange={onSearchChange}
        onReset={onResetFilters}
        hasActiveFilters={hasActiveFilters}
        searchPlaceholder={searchPlaceholder}
        filters={filters}
      />

      <div className="grid items-start gap-4 lg:grid-cols-[minmax(0,1.35fr)_minmax(18rem,0.85fr)]">
        <div className="order-2 min-w-0 lg:order-1">{list}</div>
        <section className="order-1 min-w-0 lg:sticky lg:top-4 lg:order-2">
          <div className="mb-3 space-y-1">
            <h3 className="font-[family-name:var(--font-display)] text-lg font-semibold text-foreground">
              {formTitle}
            </h3>
            <p className="text-sm text-muted-foreground">{formDescription}</p>
          </div>
          {form}
        </section>
      </div>
    </>
  )

  if (embedded) return body
  return <AppShell>{body}</AppShell>
}
