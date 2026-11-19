import { Search } from 'lucide-react'
import { Icon, Input } from '@/design-system/atoms'

export interface NavSearchProps {
  value: string
  onChange: (value: string) => void
}

export function NavSearch({ value, onChange }: NavSearchProps) {
  return (
    <div className="relative px-3 pb-3">
      <Icon
        icon={Search}
        size={15}
        className="pointer-events-none absolute top-1/2 left-6 -translate-y-1/2 text-muted-foreground"
      />
      <Input
        value={value}
        onChange={(event) => onChange(event.target.value)}
        placeholder="Buscar opción…"
        className="h-9 bg-background pl-9"
        aria-label="Buscar en el menú"
      />
    </div>
  )
}
