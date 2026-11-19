import { Search, X } from 'lucide-react'
import { useState } from 'react'
import { Button, Icon, Input } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { useUsuariosActivos } from '@/modules/transferencias/api'
import { formatDocumento, formatUsuarioNombre } from '@/modules/transferencias/lib/format'
import type { UsuarioResumen } from '@/modules/transferencias/types'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'

export interface UsuarioPickerProps {
  id: string
  label: string
  value: UsuarioResumen | null
  excludeId?: string
  error?: string
  onChange: (usuario: UsuarioResumen | null) => void
}

export function UsuarioPicker({
  id,
  label,
  value,
  excludeId,
  error,
  onChange,
}: UsuarioPickerProps) {
  const [open, setOpen] = useState(false)
  const [term, setTerm] = useState('')
  const debounced = useDebouncedValue(term.trim(), 250)
  const { data, isFetching, isError } = useUsuariosActivos(debounced, open)
  const options = (data ?? []).filter((usuario) => usuario.id !== excludeId)

  return (
    <FormField label={label} htmlFor={id} error={error}>
      <div className="relative">
        <Icon
          icon={Search}
          size={14}
          className="pointer-events-none absolute top-1/2 left-2.5 -translate-y-1/2 text-muted-foreground"
        />
        <Input
          id={id}
          value={value ? formatUsuarioNombre(value) : term}
          placeholder="Nombre, DNI o RUC"
          autoComplete="off"
          role="combobox"
          aria-expanded={open}
          aria-controls={`${id}-opciones`}
          aria-autocomplete="list"
          className="pr-9 pl-8"
          onFocus={() => setOpen(true)}
          onBlur={() => setOpen(false)}
          onChange={(event) => {
            if (value) onChange(null)
            setTerm(event.target.value)
            setOpen(true)
          }}
        />
        {value ? (
          <Button
            type="button"
            variant="ghost"
            size="icon"
            className="absolute top-0 right-0 h-9 w-9"
            aria-label="Quitar usuario"
            onMouseDown={(event) => event.preventDefault()}
            onClick={() => {
              onChange(null)
              setTerm('')
              setOpen(true)
            }}
          >
            <Icon icon={X} size={14} />
          </Button>
        ) : null}

        {open ? (
          <ul
            id={`${id}-opciones`}
            role="listbox"
            className="absolute z-20 mt-1 max-h-56 w-full overflow-auto rounded-md border border-border bg-card py-1 shadow-[var(--shadow-sm)]"
          >
            {isError ? (
              <li className="px-3 py-2 text-xs text-destructive">
                No se pudo buscar usuarios.
              </li>
            ) : options.length === 0 ? (
              <li className="px-3 py-2 text-xs text-muted-foreground">
                {isFetching ? 'Buscando…' : 'Sin usuarios activos.'}
              </li>
            ) : (
              options.map((usuario) => {
                const documento = formatDocumento(usuario)
                return (
                  <li key={usuario.id}>
                    <button
                      type="button"
                      role="option"
                      aria-selected={value?.id === usuario.id}
                      className="flex w-full flex-col items-start px-3 py-1.5 text-left text-sm hover:bg-secondary/70"
                      onMouseDown={(event) => event.preventDefault()}
                      onClick={() => {
                        onChange(usuario)
                        setTerm('')
                        setOpen(false)
                      }}
                    >
                      <span className="font-medium text-foreground">
                        {formatUsuarioNombre(usuario)}
                      </span>
                      {documento ? (
                        <span className="text-[11px] text-muted-foreground">{documento}</span>
                      ) : null}
                    </button>
                  </li>
                )
              })
            )}
          </ul>
        ) : null}
      </div>
    </FormField>
  )
}
