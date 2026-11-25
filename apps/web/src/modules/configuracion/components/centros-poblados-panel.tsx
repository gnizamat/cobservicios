import { zodResolver } from '@hookform/resolvers/zod'
import { useQueryClient } from '@tanstack/react-query'
import { LoaderCircle } from 'lucide-react'
import { useState } from 'react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input } from '@/design-system/atoms'
import { cn } from '@/shared/lib/utils'
import { FormField } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import { FormLayout } from '@/design-system/templates'
import {
  sectorFormSchema,
  toSectorPayload,
  useSaveSector,
  useSectores,
  useSetSectorActivo,
  type SectorFormValues,
} from '@/modules/catalogo'

const columns = [
  { key: 'codigo', header: 'Código', className: 'w-28' },
  { key: 'nombre', header: 'Centro poblado' },
  { key: 'activo', header: 'Estado', className: 'w-28' },
]

export function CentrosPobladosPanel() {
  const query = useSectores()
  const save = useSaveSector()
  const alternar = useSetSectorActivo()
  const queryClient = useQueryClient()
  const [selectedId, setSelectedId] = useState<string | null>(null)
  const [creating, setCreating] = useState(false)
  const records = query.data ?? []
  const selected = creating ? null : (records.find((row) => row.id === selectedId) ?? records[0] ?? null)

  return (
    <div className="grid items-start gap-4 lg:grid-cols-[minmax(0,1.1fr)_minmax(16rem,0.9fr)]">
      <div className="space-y-3">
        <div className="flex items-center justify-between gap-3">
          <h3 className="text-sm font-medium text-foreground">Centros poblados</h3>
          <Button
            type="button"
            size="sm"
            variant="outline"
            onClick={() => {
              setCreating(true)
              setSelectedId(null)
            }}
          >
            Nuevo
          </Button>
        </div>
        {query.isLoading ? (
          <p className="text-sm text-muted-foreground">Cargando centros poblados…</p>
        ) : query.isError ? (
          <p role="alert" className="text-sm text-destructive">
            {(query.error as Error).message}
          </p>
        ) : (
          <DataTable
            columns={columns}
            rows={records}
            rowKey={(row) => row.id}
            selectedKey={selected?.id}
            onRowSelect={(row) => {
              setCreating(false)
              setSelectedId(row.id)
            }}
            emptyMessage="Todavía no hay centros poblados."
            renderCell={(row, key) => {
              if (key === 'codigo') return row.codigo
              if (key === 'activo') {
                return (
                  <SectorActivoSwitch
                    activo={row.activo}
                    disabled={alternar.isPending}
                    onToggle={() => alternar.mutate({ id: row.id, activo: !row.activo })}
                  />
                )
              }
              return row.nombre
            }}
          />
        )}
      </div>
      {query.isLoading ? null : (
        <CentroForm
          key={creating ? 'nuevo' : (selected?.id ?? 'nuevo')}
          initial={creating ? null : selected}
          submitting={save.isPending}
          error={save.isError ? (save.error as Error).message : null}
          onSubmit={(values) => {
            save.mutate(
              { id: creating ? null : (selected?.id ?? null), payload: toSectorPayload(values) },
              {
                onSuccess: async (row) => {
                  setCreating(false)
                  setSelectedId(row.id)
                  await queryClient.invalidateQueries({ queryKey: ['lecturas', 'territorio'] })
                  await queryClient.invalidateQueries({ queryKey: ['deudas', 'territorio'] })
                  await queryClient.invalidateQueries({ queryKey: ['facturacion'] })
                },
              },
            )
          }}
        />
      )}
    </div>
  )
}

function SectorActivoSwitch({
  activo,
  disabled,
  onToggle,
}: {
  activo: boolean
  disabled: boolean
  onToggle: () => void
}) {
  return (
    <button
      type="button"
      role="switch"
      aria-checked={activo}
      aria-label={activo ? 'Desactivar centro poblado' : 'Activar centro poblado'}
      disabled={disabled}
      onClick={(event) => {
        event.stopPropagation()
        onToggle()
      }}
      onKeyDown={(event) => event.stopPropagation()}
      className="inline-flex items-center gap-2 text-xs text-foreground"
    >
      <span
        className={cn(
          'relative inline-flex h-5 w-9 shrink-0 items-center rounded-full transition-colors',
          activo ? 'bg-primary' : 'bg-muted-foreground/35',
        )}
      >
        <span
          className={cn(
            'inline-block h-4 w-4 rounded-full bg-white shadow transition-transform',
            activo ? 'translate-x-4' : 'translate-x-0.5',
          )}
        />
      </span>
      {activo ? 'Activo' : 'Inactivo'}
    </button>
  )
}

function CentroForm({
  initial,
  submitting,
  error,
  onSubmit,
}: {
  initial: { codigo: string; nombre: string } | null
  submitting: boolean
  error: string | null
  onSubmit: (values: SectorFormValues) => void
}) {
  const form = useForm<SectorFormValues>({
    resolver: zodResolver(sectorFormSchema),
    defaultValues: initial
      ? { codigo: initial.codigo, nombre: initial.nombre }
      : { codigo: '', nombre: '' },
  })

  return (
    <form onSubmit={form.handleSubmit(onSubmit)} noValidate>
      {error ? (
        <p role="alert" className="mb-3 text-sm text-destructive">
          {error}
        </p>
      ) : null}
      <FormLayout
        columns={1}
        footer={
          <Button type="submit" disabled={submitting}>
            {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
            {initial ? 'Guardar cambios' : 'Registrar centro poblado'}
          </Button>
        }
      >
        <FormField label="Código" htmlFor="codigo" error={form.formState.errors.codigo?.message}>
          <Input id="codigo" autoComplete="off" {...form.register('codigo')} />
        </FormField>
        <FormField label="Nombre" htmlFor="nombre" error={form.formState.errors.nombre?.message}>
          <Input id="nombre" {...form.register('nombre')} />
        </FormField>
      </FormLayout>
    </form>
  )
}
