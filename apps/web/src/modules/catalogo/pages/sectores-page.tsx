import { useMemo, useState } from 'react'
import { useSaveSector, useSectores } from '@/modules/catalogo/api'
import { CatalogWorkspace } from '@/modules/catalogo/components/catalog-workspace'
import { SectorForm } from '@/modules/catalogo/components/sector-form'
import { useRecordSelection } from '@/modules/catalogo/components/use-record-selection'
import { includesSearch } from '@/modules/catalogo/labels'
import { DataTable } from '@/design-system/organisms'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'

const columns = [
  { key: 'codigo', header: 'Código', className: 'w-24' },
  { key: 'nombre', header: 'Sector' },
]

export function SectoresPage() {
  const [searchInput, setSearchInput] = useState('')
  const search = useDebouncedValue(searchInput.trim(), 200)
  const query = useSectores()
  const save = useSaveSector()
  const records = useMemo(
    () => (query.data ?? []).filter((row) => includesSearch(search, [row.codigo, row.nombre])),
    [query.data, search],
  )
  const selection = useRecordSelection(records)

  return (
    <CatalogWorkspace
      title="Sectores"
      description="Territorio de cobranza. Al abrir la pantalla, el formulario carga el primer sector."
      search={searchInput}
      onSearchChange={setSearchInput}
      searchPlaceholder="Código o nombre del sector…"
      hasActiveFilters={Boolean(searchInput.trim())}
      onResetFilters={() => setSearchInput('')}
      onNew={selection.startCreate}
      formTitle={selection.selected ? 'Sector cargado' : 'Nuevo sector'}
      formDescription={
        selection.selected
          ? `${selection.selected.codigo} · ${selection.selected.nombre}. Elegí otra fila para cargar sus datos.`
          : 'Completá el código y el nombre para registrar un sector.'
      }
      list={
        query.isLoading ? (
          <p className="text-sm text-muted-foreground">Cargando sectores…</p>
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
            emptyMessage="No hay sectores con ese filtro."
            renderCell={(row, key) => {
              if (key === 'codigo') {
                return <span className="font-medium tabular-nums">{row.codigo}</span>
              }
              return row.nombre
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
          <SectorForm
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
