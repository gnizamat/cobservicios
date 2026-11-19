import { useMemo, useState } from 'react'
import { Button } from '@/design-system/atoms'
import { StatusBadge } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import { categoriaServicioLabel, useSaveServicio, useServicios } from '@/modules/catalogo/api'
import { CatalogWorkspace } from '@/modules/catalogo/components/catalog-workspace'
import { ServicioForm } from '@/modules/catalogo/components/servicio-form'
import { useRecordSelection } from '@/modules/catalogo/components/use-record-selection'
import { includesSearch } from '@/modules/catalogo/labels'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'

const columns = [
  { key: 'codigo', header: 'Código', className: 'w-24' },
  { key: 'nombre', header: 'Servicio' },
  { key: 'categoria', header: 'Categoría' },
  { key: 'estado', header: 'Estado', className: 'w-24' },
  { key: 'editar', header: '', className: 'w-24 text-right' },
]

export function ServiciosPage({
  embedded = false,
  title = 'Tipos de servicio',
  description = 'Elegí Editar en cualquier servicio. El formulario carga ese registro para modificarlo.',
}: {
  embedded?: boolean
  title?: string
  description?: string
}) {
  const [searchInput, setSearchInput] = useState('')
  const search = useDebouncedValue(searchInput.trim(), 200)
  const query = useServicios()
  const save = useSaveServicio()
  const [savedLabel, setSavedLabel] = useState<string | null>(null)
  const records = useMemo(
    () =>
      (query.data ?? []).filter((row) =>
        includesSearch(search, [row.codigo, row.nombre, categoriaServicioLabel(row.categoria)]),
      ),
    [query.data, search],
  )
  const selection = useRecordSelection(records)

  return (
    <CatalogWorkspace
      embedded={embedded}
      title={title}
      description={description}
      search={searchInput}
      onSearchChange={setSearchInput}
      searchPlaceholder="Código, nombre o categoría…"
      hasActiveFilters={Boolean(searchInput.trim())}
      onResetFilters={() => setSearchInput('')}
      onNew={() => {
        setSavedLabel(null)
        selection.startCreate()
      }}
      formTitle={selection.selected ? 'Editar servicio' : 'Nuevo tipo de servicio'}
      formDescription={
        selection.selected
          ? `Editando ${selection.selected.codigo} · ${selection.selected.nombre}. Cambiá los datos y guardá.`
          : 'Definí código, nombre, categoría y estado.'
      }
      list={
        query.isLoading ? (
          <p className="text-sm text-muted-foreground">Cargando tipos de servicio…</p>
        ) : query.isError ? (
          <p role="alert" className="text-sm text-destructive">
            {(query.error as Error).message}
          </p>
        ) : (
          <DataTable
            columns={columns}
            rows={records}
            rowKey={(row) => row.id}
            selectedKey={selection.selected?.id}
            onRowSelect={(row) => {
              setSavedLabel(null)
              selection.select(row.id)
            }}
            emptyMessage="No hay servicios con ese filtro."
            renderCell={(row, key) => {
              if (key === 'codigo') {
                return <span className="font-medium tabular-nums">{row.codigo}</span>
              }
              if (key === 'nombre') return row.nombre
              if (key === 'categoria') {
                return (
                  <span className="text-muted-foreground">
                    {categoriaServicioLabel(row.categoria)}
                  </span>
                )
              }
              if (key === 'estado') return <StatusBadge status={row.estado} />
              const editing = selection.selected?.id === row.id
              return (
                <Button
                  type="button"
                  variant={editing ? 'default' : 'outline'}
                  size="sm"
                  className="h-7 px-2"
                  onClick={(event) => {
                    event.stopPropagation()
                    setSavedLabel(null)
                    selection.select(row.id)
                  }}
                >
                  {editing ? 'Editando' : 'Editar'}
                </Button>
              )
            }}
          />
        )
      }
      form={
        query.isLoading ? (
          <p className="text-sm text-muted-foreground">Cargando datos del formulario…</p>
        ) : (
        <>
          {save.isError ? (
            <p role="alert" className="mb-3 text-sm text-destructive">
              {(save.error as Error).message}
            </p>
          ) : null}
          {savedLabel ? (
            <p className="mb-3 text-sm text-foreground" role="status">
              Se guardó «{savedLabel}».
            </p>
          ) : null}
          <ServicioForm
            key={selection.selected?.id ?? 'new'}
            initial={selection.selected}
            submitting={save.isPending}
            onSubmit={(payload) => {
              const id = selection.selected?.id ?? null
              save.mutate(
                { id, payload },
                {
                  onSuccess: (row) => {
                    selection.select(row.id)
                    setSavedLabel(row.nombre)
                  },
                },
              )
            }}
          />
        </>
        )
      }
    />
  )
}
