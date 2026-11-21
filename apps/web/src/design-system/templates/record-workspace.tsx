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
    <div className="min-w-0">
      <PageHeader
        title={title}
        description={description}
        className={embedded ? 'mb-3' : undefined}
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

      <div className="grid items-start gap-4 lg:grid-cols-[minmax(0,1.4fr)_minmax(17rem,0.75fr)]">
        <div className="order-2 min-w-0 lg:order-1">{list}</div>
        <section className="order-1 min-w-0 lg:sticky lg:top-0 lg:order-2">
          <div className="mb-2 space-y-0.5">
            <h3 className="font-[family-name:var(--font-display)] text-base font-semibold text-foreground">
              {formTitle}
            </h3>
            <p className="text-sm text-muted-foreground">{formDescription}</p>
          </div>
          {form}
        </section>
      </div>
    </div>
  )

  if (embedded) return body
  return <AppShell>{body}</AppShell>
}
