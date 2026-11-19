import { Check, Palette } from 'lucide-react'
import { useEffect, useId, useRef, useState } from 'react'
import { Icon } from '@/design-system/atoms'
import { applyTheme, readTheme, themes, type ThemeId } from '@/modules/navegacion/appearance'
import { cn } from '@/shared/lib/utils'

export function AppearanceMenu({ collapsed = false }: { collapsed?: boolean }) {
  const [open, setOpen] = useState(false)
  const [theme, setTheme] = useState<ThemeId>(() => readTheme())
  const panelId = useId()
  const rootRef = useRef<HTMLDivElement>(null)

  useEffect(() => {
    if (!open) return
    function closeOnOutside(event: MouseEvent) {
      if (!rootRef.current?.contains(event.target as Node)) setOpen(false)
    }
    function closeOnEscape(event: KeyboardEvent) {
      if (event.key === 'Escape') setOpen(false)
    }
    document.addEventListener('mousedown', closeOnOutside)
    document.addEventListener('keydown', closeOnEscape)
    return () => {
      document.removeEventListener('mousedown', closeOnOutside)
      document.removeEventListener('keydown', closeOnEscape)
    }
  }, [open])

  function choose(id: ThemeId) {
    setTheme(id)
    applyTheme(id)
  }

  return (
    <div ref={rootRef} className="relative">
      <button
        type="button"
        className="flex h-9 w-9 items-center justify-center rounded-full text-muted-foreground transition-colors hover:bg-secondary hover:text-foreground"
        aria-label="Apariencia"
        aria-expanded={open}
        aria-controls={panelId}
        onClick={() => setOpen((value) => !value)}
      >
        <Icon icon={Palette} size={16} />
      </button>
      {open ? (
        <div
          id={panelId}
          role="menu"
          aria-label="Apariencia"
          className={cn(
            'absolute z-40 w-64 rounded-2xl border border-border bg-popover p-2 text-popover-foreground shadow-[var(--shadow-lg)]',
            collapsed ? 'bottom-0 left-full ml-2' : 'right-0 bottom-12',
          )}
        >
          <p className="px-2 py-1.5 text-sm font-semibold text-foreground">Apariencia</p>
          <ul className="space-y-0.5">
            {themes.map((item) => {
              const selected = item.id === theme
              return (
                <li key={item.id}>
                  <button
                    type="button"
                    role="menuitemradio"
                    aria-checked={selected}
                    onClick={() => choose(item.id)}
                    className={cn(
                      'flex w-full items-center gap-2.5 rounded-xl px-2 py-2 text-left transition-colors hover:bg-secondary',
                      selected && 'bg-secondary',
                    )}
                  >
                    <span className={cn('theme-swatch', `theme-swatch-${item.id}`)} />
                    <span className="min-w-0 flex-1">
                      <span className="block text-sm font-medium text-foreground">{item.name}</span>
                      <span className="block truncate text-xs text-muted-foreground">{item.description}</span>
                    </span>
                    {selected ? <Icon icon={Check} size={16} className="text-primary" /> : null}
                  </button>
                </li>
              )
            })}
          </ul>
        </div>
      ) : null}
    </div>
  )
}
