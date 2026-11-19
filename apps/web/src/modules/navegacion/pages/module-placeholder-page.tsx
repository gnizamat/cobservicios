import { Construction } from 'lucide-react'
import { useLocation } from 'react-router-dom'
import { Icon } from '@/design-system/atoms'
import { AppShell } from '@/design-system/templates'
import { findNavItemByPath } from '@/modules/navegacion/menu'

export function ModulePlaceholderPage() {
  const location = useLocation()
  const item = findNavItemByPath(location.pathname)

  return (
    <AppShell>
      <section className="flex max-w-2xl flex-col gap-4 rounded-2xl border border-dashed border-border bg-card/60 p-8">
        <div className="flex h-12 w-12 items-center justify-center rounded-xl bg-secondary text-primary">
          <Icon icon={Construction} size={22} />
        </div>
        <div className="space-y-2">
          <h2 className="font-[family-name:var(--font-display)] text-2xl font-semibold text-foreground">
            {item?.label ?? 'Módulo'}
          </h2>
          <p className="text-muted-foreground">
            Opción migrada del menú legado
            {item?.legacyId ? ` (idMenu ${item.legacyId})` : ''}. La interfaz de
            negocio se implementará en el módulo correspondiente; por ahora el
            acceso y la navegación ya están disponibles.
          </p>
        </div>
      </section>
    </AppShell>
  )
}
