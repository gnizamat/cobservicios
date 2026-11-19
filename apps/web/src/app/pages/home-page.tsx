import { AppShell } from '@/design-system/templates'
import { useAuth } from '@/modules/auth'
import { QuickLinks } from '@/modules/navegacion/components/quick-links'
import { mainNav } from '@/modules/navegacion/menu'

export function HomePage() {
  const { user } = useAuth()
  const optionCount = mainNav.reduce((acc, section) => acc + section.items.length, 0)

  return (
    <AppShell>
      <section className="mb-8 flex max-w-3xl flex-col gap-3">
        <h2 className="font-[family-name:var(--font-display)] text-3xl font-semibold tracking-tight text-foreground">
          Bienvenido
        </h2>
        <p className="text-muted-foreground">
          Sesión
          {user?.email ? (
            <>
              {' '}
              de <span className="font-medium text-foreground">{user.email}</span>
            </>
          ) : null}
          . Menú principal migrado del sistema COBSER, reorganizado en{' '}
          {mainNav.length} áreas y {optionCount} opciones con búsqueda rápida.
        </p>
      </section>

      <section className="space-y-3">
        <h3 className="text-sm font-semibold tracking-wide text-muted-foreground uppercase">
          Accesos frecuentes
        </h3>
        <QuickLinks />
      </section>
    </AppShell>
  )
}
