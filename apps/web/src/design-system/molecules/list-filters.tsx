import type { FormEvent, ReactNode } from 'react'
import { Search, X } from 'lucide-react'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { cn } from '@/shared/lib/utils'

export interface ListFilterOption {
  value: string
  label: string
}

export interface ListFiltersProps {
  search: string
  onSearchChange: (value: string) => void
  /** Si se omite, Enter no fuerza una acción extra (búsqueda en vivo). */
  onSubmit?: () => void
  onReset?: () => void
  searchPlaceholder?: string
  filters?: ReactNode
  className?: string
  hasActiveFilters?: boolean
  /** Oculta el botón Buscar; la consulta corre mientras se escribe. */
  liveSearch?: boolean
}

export function ListFilters({
  search,
  onSearchChange,
  onSubmit,
  onReset,
  searchPlaceholder = 'Buscar…',
  filters,
  className,
  hasActiveFilters = false,
  liveSearch = false,
}: ListFiltersProps) {
  const handleSubmit = (event: FormEvent) => {
    event.preventDefault()
    onSubmit?.()
  }

  return (
    <form
      onSubmit={handleSubmit}
      className={cn(
        'mb-3 flex flex-col gap-2 rounded-lg border border-border/80 bg-card/60 p-2 sm:flex-row sm:flex-wrap sm:items-center',
        className,
      )}
    >
      <div className="relative min-w-[12rem] flex-1">
        <Icon
          icon={Search}
          size={14}
          className="pointer-events-none absolute top-1/2 left-2.5 -translate-y-1/2 text-muted-foreground"
        />
        <Input
          value={search}
          onChange={(event) => onSearchChange(event.target.value)}
          placeholder={searchPlaceholder}
          className="h-8 pl-8 text-sm"
          aria-label="Buscar registros"
          autoComplete="off"
        />
      </div>

      {filters}

      {onReset && hasActiveFilters ? (
        <Button type="button" variant="ghost" size="sm" className="h-8 px-2" onClick={onReset}>
          <Icon icon={X} size={14} />
          Limpiar
        </Button>
      ) : null}

      {!liveSearch && onSubmit ? (
        <Button type="submit" variant="secondary" size="sm" className="h-8">
          Buscar
        </Button>
      ) : null}
    </form>
  )
}

export function FilterSelect({
  label,
  value,
  onChange,
  options,
  className,
}: {
  label: string
  value: string
  onChange: (value: string) => void
  options: ListFilterOption[]
  className?: string
}) {
  return (
    <label className={cn('flex min-w-[9.5rem] items-center gap-1.5', className)}>
      <span className="sr-only">{label}</span>
      <Select
        aria-label={label}
        value={value}
        onChange={(event) => onChange(event.target.value)}
        className="h-8 text-sm"
      >
        {options.map((option) => (
          <option key={option.value} value={option.value}>
            {option.label}
          </option>
        ))}
      </Select>
    </label>
  )
}
