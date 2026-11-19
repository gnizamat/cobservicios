import { zodResolver } from '@hookform/resolvers/zod'
import { useQueryClient } from '@tanstack/react-query'
import { LoaderCircle } from 'lucide-react'
import { useState } from 'react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import { FormLayout } from '@/design-system/templates'
import {
  sectorFormSchema,
  toSectorPayload,
  useSaveSector,
  useSectores,
  type SectorFormValues,
} from '@/modules/catalogo'

const columns = [
  { key: 'codigo', header: 'Código', className: 'w-28' },
  { key: 'nombre', header: 'Centro poblado' },
]

export function CentrosPobladosPanel() {
  const query = useSectores()
  const save = useSaveSector()
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
            renderCell={(row, key) => (key === 'codigo' ? row.codigo : row.nombre)}
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
