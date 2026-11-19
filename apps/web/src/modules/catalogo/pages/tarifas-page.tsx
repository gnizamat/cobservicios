import { useMemo, useState } from 'react'
import { StatusBadge } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import { useSaveTarifa, useTarifas } from '@/modules/catalogo/api'
import { CatalogWorkspace } from '@/modules/catalogo/components/catalog-workspace'
import { TarifaForm } from '@/modules/catalogo/components/tarifa-form'
import { useRecordSelection } from '@/modules/catalogo/components/use-record-selection'
import { includesSearch } from '@/modules/catalogo/labels'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'

const columns = [
  { key: 'anio', header: 'Año', className: 'w-20' },
  { key: 'nombre', header: 'Tarifa' },
  { key: 'modalidad', header: 'Modalidad' },
  { key: 'estado', header: 'Estado', className: 'w-24' },
]

export function TarifasPage({ embedded = false }: { embedded?: boolean }) {
  const [searchInput, setSearchInput] = useState('')
  const search = useDebouncedValue(searchInput.trim(), 200)
  const query = useTarifas()
  const save = useSaveTarifa()
  const records = useMemo(() => {
    const filtered = (query.data ?? []).filter((row) =>
      includesSearch(search, [row.anio, row.nombre, row.modalidad, row.unidad_recaudacion]),
    )
    return [...filtered].sort(
      (a, b) => Number(b.activa) - Number(a.activa) || b.anio - a.anio,
    )
  }, [query.data, search])
  const selection = useRecordSelection(records)

  return (
    <CatalogWorkspace
      embedded={embedded}
      title={embedded ? 'Años de tarifa' : 'Tarifas por año'}
      description="Años de tarifa. El formulario carga el año vigente o el primero de la lista."
      search={searchInput}
      onSearchChange={setSearchInput}
      searchPlaceholder="Año, nombre o modalidad…"
      hasActiveFilters={Boolean(searchInput.trim())}
      onResetFilters={() => setSearchInput('')}
      onNew={selection.startCreate}
      formTitle={selection.selected ? 'Tarifa cargada' : 'Nueva tarifa'}
      formDescription={
        selection.selected
          ? `${selection.selected.anio} · ${selection.selected.nombre}. Activar un año deja inactivos a los demás.`
          : 'Registrá el año, la modalidad y la unidad de recaudación.'
      }
      list={
        query.isLoading ? (
          <p className="text-sm text-muted-foreground">Cargando tarifas…</p>
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
            onRowSelect={(row) => selection.select(row.id)}
            emptyMessage="No hay tarifas con ese filtro."
            renderCell={(row, key) => {
              if (key === 'anio') {
                return <span className="font-medium tabular-nums">{row.anio}</span>
              }
              if (key === 'nombre') return row.nombre
              if (key === 'modalidad') {
                return <span className="text-muted-foreground">{row.modalidad}</span>
              }
              return <StatusBadge status={row.activa ? 'activo' : 'inactivo'} />
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
          <TarifaForm
            key={selection.selected?.id ?? 'new'}
            initial={selection.selected}
            submitting={save.isPending}
            onSubmit={(payload) => {
              save.mutate(
                { id: selection.selected?.id ?? null, payload },
                { onSuccess: (row) => selection.select(row.id) },
              )
            }}
          />
        </>
        )
      }
    />
  )
}
