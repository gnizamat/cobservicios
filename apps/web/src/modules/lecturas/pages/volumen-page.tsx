import { useState } from 'react'
import { PaginationBar } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import {
  usePagedPredios,
  useSaveVolumen,
  useServicioOptions,
  useVolumenes,
  type VolumenListItem,
} from '@/modules/lecturas/api'
import { HidroWorkspace } from '@/modules/lecturas/components/hidro-workspace'
import { PredioUsuarioTable } from '@/modules/lecturas/components/predio-usuario-table'
import { EditRowButton, SaveNotice } from '@/modules/lecturas/components/record-actions'
import { VolumenForm } from '@/modules/lecturas/components/volumen-form'
import { formatVolume, periodoLabel, titularLabel } from '@/modules/lecturas/labels'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'

const volumenColumns = [
  { key: 'servicio', header: 'Servicio' },
  { key: 'periodo', header: 'Periodo' },
  { key: 'volumen', header: 'Volumen m³', className: 'text-right' },
  { key: 'editar', header: '', className: 'w-24 text-right' },
]

export function VolumenSinLecturaPage() {
  const [searchInput, setSearchInput] = useState('')
  const search = useDebouncedValue(searchInput.trim(), 200)
  const [savedLabel, setSavedLabel] = useState<string | null>(null)
  const [volumenId, setVolumenId] = useState<string | null>(null)
  const catalogo = usePagedPredios(search)
  const servicios = useServicioOptions()
  const query = useVolumenes()
  const save = useSaveVolumen()
  const selectedPredio = catalogo.selected
  const volumenesPredio = (query.data ?? []).filter((row) => row.predio_id === selectedPredio?.id)
  const volumen = volumenesPredio.find((row) => row.id === volumenId) ?? null

  return (
    <HidroWorkspace
      title="Volumen sin lectura"
      description="La lista carga usuarios con su predio. Buscá por DNI, apellido o nombres."
      search={searchInput}
      onSearchChange={(value) => {
        setSearchInput(value)
        catalogo.resetPage()
      }}
      searchPlaceholder="DNI, apellido, nombres o predio…"
      hasActiveFilters={Boolean(searchInput.trim())}
      onResetFilters={() => {
        setSearchInput('')
        catalogo.resetPage()
      }}
      onNew={() => {
        setSavedLabel(null)
        setVolumenId(null)
      }}
      formTitle={volumen ? 'Editar volumen' : 'Nuevo volumen'}
      formDescription={
        volumen
          ? `Editando ${titularLabel(selectedPredio?.usuario)} · ${periodoLabel(volumen.anio, volumen.mes)}.`
          : 'Elegí un usuario en la lista. El formulario toma ese predio para asignar el volumen del mes.'
      }
      list={
        <div className="space-y-4">
          <div>
            <PredioUsuarioTable
              loading={catalogo.query.isLoading}
              error={catalogo.query.isError ? (catalogo.query.error as Error).message : null}
              rows={catalogo.rows}
              selectedId={selectedPredio?.id}
              onSelect={(id) => {
                setSavedLabel(null)
                setVolumenId(null)
                catalogo.select(id)
              }}
            />
            <PaginationBar
              page={catalogo.page}
              pageSize={catalogo.pageSize}
              total={catalogo.total}
              onPageChange={catalogo.setPage}
              onPageSizeChange={catalogo.changePageSize}
            />
          </div>
          {selectedPredio ? (
            <section className="space-y-2">
              <h3 className="text-sm font-medium text-foreground">
                Volúmenes de {titularLabel(selectedPredio.usuario)}
              </h3>
              <VolumenesDelPredio
                loading={query.isLoading}
                error={query.isError ? (query.error as Error).message : null}
                records={volumenesPredio}
                selectedId={volumen?.id}
                onSelect={(id) => {
                  setSavedLabel(null)
                  setVolumenId(id)
                }}
              />
            </section>
          ) : null}
        </div>
      }
      form={
        catalogo.query.isLoading || servicios.isLoading ? (
          <p className="text-sm text-muted-foreground">Cargando datos del formulario…</p>
        ) : (
          <>
            <SaveNotice
              error={save.isError ? (save.error as Error).message : null}
              saved={savedLabel}
            />
            <VolumenForm
              key={`${volumen?.id ?? 'new'}-${selectedPredio?.id ?? 'none'}`}
              initial={volumen}
              predioId={selectedPredio?.id}
              predios={
                selectedPredio && !catalogo.rows.some((row) => row.id === selectedPredio.id)
                  ? [selectedPredio, ...catalogo.rows]
                  : catalogo.rows
              }
              servicios={servicios.data ?? []}
              submitting={save.isPending}
              onSubmit={(payload) => {
                const label = `${formatVolume(payload.volumen_m3)} m³`
                save.mutate(
                  { id: volumen?.id ?? null, payload },
                  {
                    onSuccess: (row) => {
                      catalogo.select(row.predio_id)
                      setVolumenId(row.id)
                      setSavedLabel(label)
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

function VolumenesDelPredio({
  loading,
  error,
  records,
  selectedId,
  onSelect,
}: {
  loading: boolean
  error: string | null
  records: VolumenListItem[]
  selectedId?: string
  onSelect: (id: string) => void
}) {
  if (loading) return <p className="text-sm text-muted-foreground">Cargando volúmenes…</p>
  if (error) {
    return (
      <p role="alert" className="text-sm text-destructive">
        {error}
      </p>
    )
  }
  return (
    <DataTable
      columns={volumenColumns}
      rows={records}
      rowKey={(row) => row.id}
      selectedKey={selectedId}
      onRowSelect={(row) => onSelect(row.id)}
      emptyMessage="Este predio no tiene volúmenes asignados."
      renderCell={(row, key) => {
        if (key === 'servicio') return row.servicio?.nombre ?? '—'
        if (key === 'periodo') return periodoLabel(row.anio, row.mes)
        if (key === 'volumen') {
          return <span className="tabular-nums">{formatVolume(row.volumen_m3)}</span>
        }
        return <EditRowButton editing={selectedId === row.id} onEdit={() => onSelect(row.id)} />
      }}
    />
  )
}
