import { useMemo, useState } from 'react'
import { FilterSelect } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import { useCalles, useSaveCalle, useSectores } from '@/modules/catalogo/api'
import { CalleForm } from '@/modules/catalogo/components/calle-form'
import { CatalogWorkspace } from '@/modules/catalogo/components/catalog-workspace'
import { useRecordSelection } from '@/modules/catalogo/components/use-record-selection'
import { includesSearch } from '@/modules/catalogo/labels'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'

const columns = [
  { key: 'nombre', header: 'Calle' },
  { key: 'sector', header: 'Sector' },
  { key: 'referencia', header: 'Referencia' },
]

export function CallesPage() {
  const [searchInput, setSearchInput] = useState('')
  const [sectorId, setSectorId] = useState('all')
  const search = useDebouncedValue(searchInput.trim(), 200)
  const calles = useCalles()
  const sectores = useSectores()
  const save = useSaveCalle()
  const sectorOptions = useMemo(
    () => [
      { value: 'all', label: 'Todos los centros poblados' },
      ...[...(sectores.data ?? [])]
        .filter((sector) => sector.activo)
        .sort((a, b) => a.nombre.localeCompare(b.nombre, 'es'))
        .map((sector) => ({ value: sector.id, label: sector.nombre })),
    ],
    [sectores.data],
  )
  const records = useMemo(
    () =>
      (calles.data ?? []).filter(
        (row) =>
          (sectorId === 'all' || row.sector_id === sectorId) &&
          includesSearch(search, [
            row.nombre,
            row.referencia,
            row.sector?.nombre,
            row.sector?.codigo,
          ]),
      ),
    [calles.data, search, sectorId],
  )
  const selection = useRecordSelection(records)

  return (
    <CatalogWorkspace
      title="Calles"
      description="Calles del territorio. Filtrá por centro poblado o mirá las de todos."
      search={searchInput}
      onSearchChange={setSearchInput}
      searchPlaceholder="Calle, sector o referencia…"
      filters={
        <FilterSelect
          label="Centro poblado"
          value={sectorOptions.some((option) => option.value === sectorId) ? sectorId : 'all'}
          options={sectorOptions}
          onChange={setSectorId}
        />
      }
      hasActiveFilters={Boolean(searchInput.trim()) || sectorId !== 'all'}
      onResetFilters={() => {
        setSearchInput('')
        setSectorId('all')
      }}
      onNew={selection.startCreate}
      formTitle={selection.selected ? 'Calle cargada' : 'Nueva calle'}
      formDescription={
        selection.selected
          ? `${selection.selected.nombre}. Elegí otra fila para reemplazar los datos del formulario.`
          : 'Indicá el sector, el nombre y una referencia.'
      }
      list={
        calles.isLoading ? (
          <p className="text-sm text-muted-foreground">Cargando calles…</p>
        ) : calles.isError ? (
          <p role="alert" className="text-sm text-destructive">
            {(calles.error as Error).message}
          </p>
        ) : (
          <DataTable
            columns={columns}
            rows={records}
            rowKey={(row) => row.id}
            selectedKey={selection.selected?.id}
            onRowSelect={(row) => selection.select(row.id)}
            emptyMessage="No hay calles con ese filtro."
            renderCell={(row, key) => {
              if (key === 'nombre') return <span className="font-medium">{row.nombre}</span>
              if (key === 'sector') {
                return (
                  <span className="text-muted-foreground">
                    {row.sector ? `${row.sector.codigo} · ${row.sector.nombre}` : '—'}
                  </span>
                )
              }
              return <span className="text-muted-foreground">{row.referencia || '—'}</span>
            }}
          />
        )
      }
      form={
        calles.isLoading ? (
          <p className="text-sm text-muted-foreground">Cargando datos del formulario…</p>
        ) : (
        <>
          {save.isError ? (
            <p role="alert" className="mb-3 text-sm text-destructive">
              {(save.error as Error).message}
            </p>
          ) : null}
          <CalleForm
            key={selection.selected?.id ?? 'new'}
            initial={selection.selected}
            sectores={(sectores.data ?? []).filter((sector) => sector.activo)}
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
