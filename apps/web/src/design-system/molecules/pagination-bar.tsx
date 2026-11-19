import { ChevronLeft, ChevronRight } from 'lucide-react'
import { Button, Icon, Select } from '@/design-system/atoms'
import { cn } from '@/shared/lib/utils'

export interface PaginationBarProps {
  page: number
  pageSize: number
  total: number
  onPageChange: (page: number) => void
  onPageSizeChange?: (pageSize: number) => void
  pageSizeOptions?: number[]
  className?: string
}

export function PaginationBar({
  page,
  pageSize,
  total,
  onPageChange,
  onPageSizeChange,
  pageSizeOptions = [10, 20, 50],
  className,
}: PaginationBarProps) {
  const totalPages = Math.max(1, Math.ceil(total / pageSize))
  const safePage = Math.min(page, totalPages)
  const from = total === 0 ? 0 : (safePage - 1) * pageSize + 1
  const to = Math.min(safePage * pageSize, total)

  return (
    <div
      className={cn(
        'mt-3 flex flex-col gap-2 border-t border-border/70 pt-2.5 text-xs text-muted-foreground sm:flex-row sm:items-center sm:justify-between',
        className,
      )}
    >
      <p>
        {total === 0 ? 'Sin resultados' : `${from}–${to} de ${total}`}
      </p>

      <div className="flex flex-wrap items-center gap-2">
        {onPageSizeChange ? (
          <label className="flex items-center gap-1.5">
            <span>Por página</span>
            <Select
              aria-label="Registros por página"
              value={String(pageSize)}
              onChange={(event) => onPageSizeChange(Number(event.target.value))}
              className="h-7 w-[4.5rem] text-xs"
            >
              {pageSizeOptions.map((size) => (
                <option key={size} value={size}>
                  {size}
                </option>
              ))}
            </Select>
          </label>
        ) : null}

        <div className="flex items-center gap-1">
          <Button
            type="button"
            variant="outline"
            size="sm"
            className="h-7 px-2"
            disabled={safePage <= 1}
            onClick={() => onPageChange(safePage - 1)}
            aria-label="Página anterior"
          >
            <Icon icon={ChevronLeft} size={14} />
          </Button>
          <span className="min-w-[4.5rem] text-center tabular-nums">
            {safePage} / {totalPages}
          </span>
          <Button
            type="button"
            variant="outline"
            size="sm"
            className="h-7 px-2"
            disabled={safePage >= totalPages}
            onClick={() => onPageChange(safePage + 1)}
            aria-label="Página siguiente"
          >
            <Icon icon={ChevronRight} size={14} />
          </Button>
        </div>
      </div>
    </div>
  )
}
