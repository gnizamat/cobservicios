import { Search, X } from 'lucide-react'
import { useEffect, useState } from 'react'
import { Button, Icon, Input } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { useUsuarioTitular, useUsuariosTitular } from '@/modules/predios/api'
import type { UsuarioTitular } from '@/modules/predios/api/predios-api'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'
import { cn } from '@/shared/lib/utils'

function nombreUsuario(user: Pick<UsuarioTitular, 'tipo_persona' | 'nombres' | 'apellido_paterno' | 'apellido_materno'>) {
  if (user.tipo_persona === 'natural') {
    return [user.nombres, user.apellido_paterno, user.apellido_materno].filter(Boolean).join(' ')
  }
  return user.nombres
}

function documentoUsuario(user: Pick<UsuarioTitular, 'dni' | 'ruc'>) {
  if (user.dni) return `DNI ${user.dni}`
  if (user.ruc) return `RUC ${user.ruc}`
  return ''
}

export function UsuarioTitularField({
  id,
  value,
  error,
  onChange,
}: {
  id: string
  value: string
  error?: string
  onChange: (usuarioId: string) => void
}) {
  const [open, setOpen] = useState(false)
  const [term, setTerm] = useState('')
  const [activeIndex, setActiveIndex] = useState(0)
  const debounced = useDebouncedValue(term.trim(), 250)
  const buscar = debounced.length > 0
  const resultados = useUsuariosTitular(debounced, open && buscar)
  const seleccionado = useUsuarioTitular(value)
  const opciones = resultados.data ?? []

  useEffect(() => {
    setActiveIndex(0)
  }, [debounced, opciones.length])

  const texto = value && !term ? (seleccionado.data ? nombreUsuario(seleccionado.data) : '') : term

  function elegir(usuario: UsuarioTitular) {
    onChange(usuario.id)
    setTerm('')
    setOpen(false)
  }

  return (
    <FormField label="Usuario titular" htmlFor={id} error={error}>
      <div className="relative">
        <Icon
          icon={Search}
          size={14}
          className="pointer-events-none absolute top-1/2 left-2.5 -translate-y-1/2 text-muted-foreground"
        />
        <Input
          id={id}
          value={texto}
          placeholder="DNI, nombres, apellidos"
          autoComplete="off"
          role="combobox"
          aria-expanded={open}
          aria-controls={`${id}-opciones`}
          aria-autocomplete="list"
          aria-activedescendant={open && opciones[activeIndex] ? `${id}-opcion-${opciones[activeIndex].id}` : undefined}
          className="pr-9 pl-8"
          onFocus={() => setOpen(true)}
          onBlur={() => setOpen(false)}
          onChange={(event) => {
            if (value) onChange('')
            setTerm(event.target.value)
            setOpen(true)
          }}
          onKeyDown={(event) => {
            if (event.key === 'ArrowDown') {
              event.preventDefault()
              setOpen(true)
              setActiveIndex((index) => Math.min(index + 1, Math.max(opciones.length - 1, 0)))
            } else if (event.key === 'ArrowUp') {
              event.preventDefault()
              setActiveIndex((index) => Math.max(index - 1, 0))
            } else if (event.key === 'Escape') {
              setOpen(false)
            } else if (event.key === 'Enter') {
              event.preventDefault()
              const elegido = opciones[activeIndex]
              if (open && elegido) elegir(elegido)
            }
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
              onChange('')
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
            {!buscar ? (
              <li className="px-3 py-2 text-xs text-muted-foreground">
                Escribe DNI, nombres o apellidos.
              </li>
            ) : resultados.isError ? (
              <li className="px-3 py-2 text-xs text-destructive">No se pudo buscar usuarios.</li>
            ) : opciones.length === 0 ? (
              <li className="px-3 py-2 text-xs text-muted-foreground">
                {resultados.isFetching ? 'Buscando…' : 'Ningún usuario coincide con esa búsqueda.'}
              </li>
            ) : (
              opciones.map((usuario, index) => {
                const documento = documentoUsuario(usuario)
                return (
                  <li key={usuario.id}>
                    <button
                      id={`${id}-opcion-${usuario.id}`}
                      type="button"
                      role="option"
                      aria-selected={value === usuario.id || index === activeIndex}
                      className={cn(
                        'flex w-full flex-col items-start px-3 py-1.5 text-left text-sm hover:bg-secondary/70',
                        index === activeIndex && 'bg-secondary/70',
                      )}
                      onMouseDown={(event) => event.preventDefault()}
                      onMouseEnter={() => setActiveIndex(index)}
                      onClick={() => elegir(usuario)}
                    >
                      <span className="font-medium text-foreground">{nombreUsuario(usuario)}</span>
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
