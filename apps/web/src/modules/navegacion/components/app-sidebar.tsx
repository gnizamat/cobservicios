import { Menu } from 'lucide-react'
import { useEffect, useMemo, useState } from 'react'
import { NavLink, useLocation } from 'react-router-dom'
import { Icon } from '@/design-system/atoms'
import { NavSearch } from '@/modules/navegacion/components/nav-search'
import { NavSectionBlock } from '@/modules/navegacion/components/nav-section'
import { SidebarUser } from '@/modules/navegacion/components/sidebar-user'
import { logoPublicUrl, useMarca, useMisPermisos, useOrganizacion } from '@/modules/configuracion'
import { brandNav, mainNav, pathIsCurrent } from '@/modules/navegacion/menu'
import { filtrarNav } from '@/modules/navegacion/permisos'
import type { NavSection } from '@/modules/navegacion/types'
import { cn } from '@/shared/lib/utils'

export interface AppSidebarProps {
  className?: string
  collapsed?: boolean
  onToggleCollapsed?: () => void
  onNavigate?: () => void
}

function sectionIsCurrent(section: NavSection, pathname: string) {
  return section.items.some((item) => item.path && pathIsCurrent(pathname, item.path))
}

function openForPath(pathname: string, sections: NavSection[]) {
  return Object.fromEntries(
    sections
      .filter((section) => section.id !== 'inicio')
      .map((section) => [section.id, sectionIsCurrent(section, pathname)]),
  )
}

function RailButton({
  label,
  icon,
  active,
  onClick,
}: {
  label: string
  icon: NavSection['icon']
  active?: boolean
  onClick?: () => void
}) {
  const className = cn(
    'mx-auto flex h-10 w-10 items-center justify-center rounded-xl text-muted-foreground transition-colors hover:bg-secondary hover:text-foreground',
    active && 'bg-secondary text-foreground',
  )
  if (onClick) {
    return (
      <button type="button" title={label} onClick={onClick} className={className}>
        <Icon icon={icon} size={18} />
      </button>
    )
  }
  return (
    <span title={label} className={className}>
      <Icon icon={icon} size={18} />
    </span>
  )
}

function SidebarBrand({
  collapsed,
  onToggleCollapsed,
}: {
  collapsed: boolean
  onToggleCollapsed?: () => void
}) {
  const organizacion = useOrganizacion()
  const marca = useMarca()
  const logo = logoPublicUrl(organizacion.data?.logo_path)
  const subtitle = organizacion.data?.abreviatura || brandNav.subtitle
  const nombre = marca.data?.trim() || brandNav.name

  return (
    <div className={cn('flex items-center gap-2.5 px-3 py-3', collapsed && 'flex-col px-2')}>
      <div className="flex h-9 w-9 shrink-0 items-center justify-center overflow-hidden rounded-full bg-primary text-primary-foreground">
        {logo ? (
          <img src={logo} alt="" className="h-full w-full object-cover" />
        ) : (
          <Icon icon={brandNav.icon} size={18} />
        )}
      </div>
      {collapsed ? null : (
        <div className="min-w-0 flex-1 leading-tight">
          <p className="truncate font-[family-name:var(--font-display)] text-sm font-semibold text-foreground">
            {nombre}
          </p>
          <p className="truncate text-[10px] font-medium tracking-[0.12em] text-muted-foreground uppercase">
            {subtitle}
          </p>
        </div>
      )}
      <button
        type="button"
        onClick={onToggleCollapsed}
        className="flex h-9 w-9 shrink-0 items-center justify-center rounded-xl text-muted-foreground transition-colors hover:bg-secondary hover:text-foreground"
        aria-label={collapsed ? 'Expandir menú' : 'Contraer menú'}
      >
        <Icon icon={Menu} size={18} />
      </button>
    </div>
  )
}

function TopLinks({
  sections,
  onNavigate,
}: {
  sections: NavSection[]
  onNavigate?: () => void
}) {
  return sections.flatMap((section) =>
    section.items
      .filter((item) => item.path)
      .map((item) => (
        <NavLink
          key={item.id}
          to={item.path ?? '/'}
          end
          onClick={onNavigate}
          className={({ isActive }) =>
            cn(
              'mx-2 flex items-center gap-2.5 rounded-xl px-2.5 py-2 text-sm transition-colors',
              isActive
                ? 'bg-secondary font-medium text-foreground'
                : 'text-foreground/80 hover:bg-secondary/70 hover:text-foreground',
            )
          }
        >
          <Icon icon={item.icon ?? section.icon} size={16} className="text-muted-foreground" />
          Inicio
        </NavLink>
      )),
  )
}

export function AppSidebar({
  className,
  collapsed = false,
  onToggleCollapsed,
  onNavigate,
}: AppSidebarProps) {
  const { pathname } = useLocation()
  const acceso = useMisPermisos()
  const nav = useMemo(() => filtrarNav(mainNav, acceso.data), [acceso.data])
  const topSections = nav.filter((section) => section.id === 'inicio')
  const groups = nav.filter((section) => section.id !== 'inicio')
  const [query, setQuery] = useState('')
  const [openMap, setOpenMap] = useState<Record<string, boolean>>(() => openForPath(pathname, mainNav))

  useEffect(() => {
    setOpenMap((prev) => {
      const next = { ...prev }
      for (const section of groups) {
        if (sectionIsCurrent(section, pathname)) next[section.id] = true
      }
      return next
    })
  }, [pathname])

  const matchCount = useMemo(() => {
    if (!query.trim()) return null
    const q = query.trim().toLowerCase()
    return nav.reduce((total, section) => {
      const hits = section.items.filter(
        (item) =>
          item.label.toLowerCase().includes(q) ||
          item.description?.toLowerCase().includes(q) ||
          section.label.toLowerCase().includes(q),
      ).length
      return total + hits
    }, 0)
  }, [nav, query])

  function revealGroup(id: string) {
    setOpenMap((prev) => ({ ...prev, [id]: true }))
    if (collapsed) onToggleCollapsed?.()
  }

  return (
    <aside
      className={cn(
        'flex h-full flex-col overflow-hidden rounded-3xl border border-border bg-card text-card-foreground shadow-[var(--shadow-lg)]',
        collapsed ? 'w-[4.5rem]' : 'w-60',
        className,
      )}
    >
      <SidebarBrand collapsed={collapsed} onToggleCollapsed={onToggleCollapsed} />
      {collapsed ? null : <NavSearch value={query} onChange={setQuery} />}
      {matchCount !== null && !collapsed ? (
        <p className="px-4 pb-2 text-xs text-muted-foreground">
          {matchCount === 0 ? 'Sin coincidencias' : `${matchCount} opción${matchCount === 1 ? '' : 'es'}`}
        </p>
      ) : null}

      <nav className="flex-1 space-y-0.5 overflow-y-auto px-1 pb-2" aria-label="Menú principal">
        {collapsed ? (
          <>
            <NavLink
              to="/"
              end
              title="Inicio"
              onClick={onNavigate}
              className="mx-auto flex h-10 w-10 items-center justify-center rounded-xl text-muted-foreground transition-colors hover:bg-secondary hover:text-foreground aria-[current=page]:bg-secondary aria-[current=page]:text-foreground"
            >
              <Icon icon={topSections[0]?.icon ?? brandNav.icon} size={18} />
            </NavLink>
            {groups.map((section) => (
              <RailButton
                key={section.id}
                label={section.label}
                icon={section.icon}
                active={sectionIsCurrent(section, pathname)}
                onClick={() => revealGroup(section.id)}
              />
            ))}
          </>
        ) : (
          <>
            <TopLinks sections={topSections} onNavigate={onNavigate} />
            {groups.map((section) => (
              <NavSectionBlock
                key={section.id}
                section={section}
                query={query}
                open={openMap[section.id] ?? false}
                onToggle={() =>
                  setOpenMap((prev) => ({ ...prev, [section.id]: !prev[section.id] }))
                }
                onNavigate={onNavigate}
              />
            ))}
          </>
        )}
      </nav>

      <SidebarUser collapsed={collapsed} />
    </aside>
  )
}
