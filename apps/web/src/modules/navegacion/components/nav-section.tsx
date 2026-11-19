import { ChevronRight } from 'lucide-react'
import { NavLink, useLocation } from 'react-router-dom'
import { Icon } from '@/design-system/atoms'
import { navLinkEnds, pathIsCurrent } from '@/modules/navegacion/menu'
import type { NavItem, NavSection as NavSectionType } from '@/modules/navegacion/types'
import { cn } from '@/shared/lib/utils'

export interface NavSectionProps {
  section: NavSectionType
  open: boolean
  onToggle: () => void
  query: string
  onNavigate?: () => void
}

function itemIcon(item: NavItem, section: NavSectionType) {
  return item.icon ?? section.icon
}

export function NavSectionBlock({ section, open, onToggle, query, onNavigate }: NavSectionProps) {
  const { pathname } = useLocation()
  const filtered = section.items.filter((item) => {
    if (!query.trim()) return true
    const q = query.trim().toLowerCase()
    return (
      item.label.toLowerCase().includes(q) ||
      item.description?.toLowerCase().includes(q) ||
      section.label.toLowerCase().includes(q)
    )
  })

  if (filtered.length === 0) return null

  const forceOpen = Boolean(query.trim())
  const isOpen = forceOpen || open
  const active = section.items.some((item) => item.path && pathIsCurrent(pathname, item.path))

  return (
    <div className="px-2">
      <button
        type="button"
        onClick={onToggle}
        className="flex w-full items-center gap-2 rounded-xl px-2.5 py-2 text-left text-[11px] font-semibold tracking-[0.14em] text-muted-foreground uppercase transition-colors hover:bg-secondary/80 hover:text-foreground"
        aria-expanded={isOpen}
      >
        <span className="min-w-0 flex-1 truncate">{section.label}</span>
        {active ? <span className="size-1.5 shrink-0 rounded-full bg-primary" aria-hidden /> : null}
        <Icon
          icon={ChevronRight}
          size={14}
          className={cn('transition-transform', isOpen && 'rotate-90')}
        />
      </button>

      {isOpen ? (
        <ul className="mb-1 space-y-0.5">
          {filtered.map((item) => {
            if (!item.path) return null
            const ItemIcon = itemIcon(item, section)
            return (
              <li key={item.id}>
                <NavLink
                  to={item.path}
                  end={item.path === '/' || navLinkEnds(item.path)}
                  onClick={onNavigate}
                  className={({ isActive }) =>
                    cn(
                      'flex items-center gap-2.5 rounded-xl px-2.5 py-2 text-sm transition-colors',
                      isActive
                        ? 'bg-secondary font-medium text-foreground'
                        : 'text-foreground/80 hover:bg-secondary/70 hover:text-foreground',
                    )
                  }
                >
                  <Icon icon={ItemIcon} size={16} className="text-muted-foreground" />
                  <span className="min-w-0 flex-1 truncate">{item.label}</span>
                  {item.status === 'soon' ? (
                    <span className="text-[10px] font-medium text-muted-foreground">Pronto</span>
                  ) : null}
                </NavLink>
              </li>
            )
          })}
        </ul>
      ) : null}
    </div>
  )
}
