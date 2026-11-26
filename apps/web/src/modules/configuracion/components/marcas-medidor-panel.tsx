import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useState } from 'react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import { FormLayout } from '@/design-system/templates'
import {
  useMarcasMedidorConfig,
  useSaveMarcaMedidor,
} from '@/modules/configuracion/api/use-marcas-medidor'
import {
  marcaMedidorSchema,
  type MarcaMedidorValues,
} from '@/modules/configuracion/schemas/marca-medidor'
import type { HidMarcaMedidor } from '@/shared/types/database'

const columns = [
  { key: 'nombre', header: 'Marca' },
  { key: 'procedencia', header: 'Procedencia' },
]

function celda(row: HidMarcaMedidor, key: string) {
  if (key === 'procedencia') return row.procedencia.trim() || '—'
  return row.nombre
}

export function MarcasMedidorPanel() {
  const query = useMarcasMedidorConfig()
  const save = useSaveMarcaMedidor()
  const [selectedId, setSelectedId] = useState<string | null>(null)
  const [creating, setCreating] = useState(false)
  const records = query.data ?? []
  const selected = creating ? null : (records.find((row) => row.id === selectedId) ?? records[0] ?? null)

  return (
    <div className="grid items-start gap-4 lg:grid-cols-[minmax(0,1.1fr)_minmax(16rem,0.9fr)]">
      <div className="space-y-3">
        <div className="flex items-center justify-between gap-3">
          <h3 className="text-sm font-medium text-foreground">Marcas de medidor</h3>
          <Button
            type="button"
            size="sm"
            variant="outline"
            onClick={() => {
              setCreating(true)
              setSelectedId(null)
            }}
          >
            Nueva
          </Button>
        </div>
        {query.isLoading ? (
          <p className="text-sm text-muted-foreground">Cargando marcas…</p>
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
            emptyMessage="Todavía no hay marcas de medidor."
            renderCell={celda}
          />
        )}
      </div>
      {query.isLoading ? null : (
        <MarcaForm
          key={creating ? 'nueva' : (selected?.id ?? 'nueva')}
          initial={selected}
          submitting={save.isPending}
          error={save.isError ? (save.error as Error).message : null}
          onSubmit={(values) => {
            save.mutate(
              { id: creating ? null : (selected?.id ?? null), input: values },
              {
                onSuccess: (id) => {
                  setCreating(false)
                  setSelectedId(id)
                },
              },
            )
          }}
        />
      )}
    </div>
  )
}

function MarcaForm({
  initial,
  submitting,
  error,
  onSubmit,
}: {
  initial: HidMarcaMedidor | null
  submitting: boolean
  error: string | null
  onSubmit: (values: MarcaMedidorValues) => void
}) {
  const form = useForm<MarcaMedidorValues>({
    resolver: zodResolver(marcaMedidorSchema),
    defaultValues: {
      nombre: initial?.nombre ?? '',
      procedencia: initial?.procedencia ?? '',
    },
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
            {initial ? 'Guardar cambios' : 'Registrar marca'}
          </Button>
        }
      >
        <FormField label="Marca" htmlFor="marca-nombre" error={form.formState.errors.nombre?.message}>
          <Input id="marca-nombre" autoComplete="off" {...form.register('nombre')} />
        </FormField>
        <FormField
          label="Procedencia"
          htmlFor="marca-procedencia"
          error={form.formState.errors.procedencia?.message}
        >
          <Input id="marca-procedencia" autoComplete="off" {...form.register('procedencia')} />
        </FormField>
      </FormLayout>
    </form>
  )
}
