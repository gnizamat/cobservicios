import { useMemo, useState } from 'react'
import { FilterSelect } from '@/design-system/molecules'
import { categoriaServicioLabel, useCostos, useSaveCosto, useServicios, useTarifas } from '@/modules/catalogo/api'
import { CatalogWorkspace } from '@/modules/catalogo/components/catalog-workspace'
import { CostoForm } from '@/modules/catalogo/components/costo-form'
import { CostoHistorial } from '@/modules/catalogo/components/costo-historial'
import { CostosTable } from '@/modules/catalogo/components/costos-table'
import { useRecordSelection } from '@/modules/catalogo/components/use-record-selection'
import { formatAmount, includesSearch, montoCambio } from '@/modules/catalogo/labels'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'

export function CostosTarifasPage({ embedded = false }: { embedded?: boolean }) {
  const [searchInput, setSearchInput] = useState('')
  const [anio, setAnio] = useState('all')
  const search = useDebouncedValue(searchInput.trim(), 200)
  const costos = useCostos()
  const tarifas = useTarifas()
  const servicios = useServicios()
  const save = useSaveCosto()
  const [savedLabel, setSavedLabel] = useState<string | null>(null)

  const anioOptions = useMemo(
    () => [
      { value: 'all', label: 'Todos los años' },
      ...(tarifas.data ?? []).map((tarifa) => ({
        value: String(tarifa.anio),
        label: String(tarifa.anio),
      })),
    ],
    [tarifas.data],
  )

  const records = useMemo(() => {
    const rows = [...(costos.data ?? [])].sort((a, b) => {
      const year = (b.tarifa?.anio ?? 0) - (a.tarifa?.anio ?? 0)
      if (year !== 0) return year
      return (a.servicio?.nombre ?? '').localeCompare(b.servicio?.nombre ?? '', 'es')
    })
    return rows.filter((row) => {
      if (anio !== 'all' && String(row.tarifa?.anio ?? '') !== anio) return false
      return includesSearch(search, [
        row.tarifa?.anio,
        row.tarifa?.nombre,
        row.servicio?.codigo,
        row.servicio?.nombre,
        row.servicio ? categoriaServicioLabel(row.servicio.categoria) : '',
      ])
    })
  }, [anio, costos.data, search])

  const selection = useRecordSelection(records)
  const hasActiveFilters = Boolean(searchInput.trim()) || anio !== 'all'

  return (
    <CatalogWorkspace
      embedded={embedded}
      title="Costos de tarifas"
      description="Elegí Editar en un costo. Si cambiás el monto, el valor anterior queda en el historial."
      search={searchInput}
      onSearchChange={setSearchInput}
      searchPlaceholder="Año o servicio…"
      hasActiveFilters={hasActiveFilters}
      onResetFilters={() => {
        setSearchInput('')
        setAnio('all')
      }}
      filters={
        <FilterSelect
          label="Año"
          value={anio}
          options={anioOptions}
          onChange={setAnio}
        />
      }
      onNew={() => {
        setSavedLabel(null)
        selection.startCreate()
      }}
      formTitle={selection.selected ? 'Editar costo' : 'Nuevo costo'}
      formDescription={
        selection.selected
          ? `${selection.selected.tarifa?.anio ?? '—'} · ${selection.selected.servicio?.nombre ?? 'servicio'}. Monto actual S/ ${formatAmount(selection.selected.monto)}.`
          : 'Elegí el año, el servicio, el valor unitario y el monto.'
      }
      list={
        costos.isLoading ? (
          <p className="text-sm text-muted-foreground">Cargando costos…</p>
        ) : costos.isError ? (
          <p role="alert" className="text-sm text-destructive">
            {(costos.error as Error).message}
          </p>
        ) : (
          <CostosTable
            rows={records}
            selectedId={selection.selected?.id}
            onEdit={(id) => {
              setSavedLabel(null)
              selection.select(id)
            }}
          />
        )
      }
      form={
        costos.isLoading ? (
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
              {savedLabel}
            </p>
          ) : null}
          <CostoForm
            key={selection.selected?.id ?? 'new'}
            initial={selection.selected}
            tarifas={tarifas.data ?? []}
            servicios={servicios.data ?? []}
            submitting={save.isPending}
            onSubmit={(payload) => {
              const current = selection.selected
              const changedMonto = current
                ? montoCambio(current.monto, payload.monto)
                : false
              save.mutate(
                { id: current?.id ?? null, payload },
                {
                  onSuccess: (row) => {
                    selection.select(row.id)
                    setSavedLabel(
                      changedMonto
                        ? 'Se guardó el monto y quedó registrado en el historial.'
                        : 'Se guardó el costo.',
                    )
                  },
                },
              )
            }}
          />
          <CostoHistorial costoId={selection.selected?.id} />
        </>
        )
      }
    />
  )
}
