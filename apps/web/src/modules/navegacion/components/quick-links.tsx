import { ArrowRight } from 'lucide-react'
import { Link } from 'react-router-dom'
import { Icon } from '@/design-system/atoms'
import { flattenNavItems, mainNav } from '@/modules/navegacion/menu'

const featuredIds = [
  'usuarios-servicio',
  'predios',
  'lecturas',
  'facturacion',
  'cobranza-deudas',
]

export function QuickLinks() {
  const items = flattenNavItems(mainNav).filter((item) =>
    featuredIds.includes(item.id),
  )

  return (
    <div className="grid gap-3 sm:grid-cols-2 lg:grid-cols-3">
      {items.map((item) => (
        <Link
          key={item.id}
          to={item.path ?? '/'}
          className="group flex flex-col gap-2 rounded-xl border border-border bg-card p-4 shadow-[var(--shadow-sm)] transition-transform hover:-translate-y-0.5 hover:border-primary/40 hover:shadow-[var(--shadow-md)]"
        >
          <div className="flex items-start justify-between gap-2">
            <p className="font-medium text-foreground">{item.label}</p>
            <Icon
              icon={ArrowRight}
              size={16}
              className="text-muted-foreground transition-transform group-hover:translate-x-0.5 group-hover:text-primary"
            />
          </div>
          <p className="text-xs text-muted-foreground">
            {item.status === 'soon' ? 'En migración · acceso preparado' : 'Disponible'}
          </p>
        </Link>
      ))}
    </div>
  )
}
