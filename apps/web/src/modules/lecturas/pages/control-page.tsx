import { useMemo, useState } from 'react'
import { DataTable } from '@/design-system/organisms'
import {
  useControles,
  useEstructuras,
  useSaveControl,
  type ControlListItem,
} from '@/modules/lecturas/api'
import { ControlForm } from '@/modules/lecturas/components/control-form'
import { HidroWorkspace } from '@/modules/lecturas/components/hidro-workspace'
import { EditRowButton, SaveNotice } from '@/modules/lecturas/components/record-actions'
import { useRecordSelection } from '@/modules/lecturas/components/use-record-selection'
import { formatVolume, includesSearch, periodoLabel, timeInput } from '@/modules/lecturas/labels'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'

const columns = [
  { key: 'estructura', header: 'Estructura' },
  { key: 'periodo', header: 'Periodo' },
  { key: 'horario', header: 'Horario' },
  { key: 'volumen', header: 'Volumen m³', className: 'text-right' },
  { key: 'cloro', header: 'Cloro' },
  { key: 'editar', header: '', className: 'w-24 text-right' },
]

export function ControlHidrometricoPage() {
  const [searchInput, setSearchInput] = useState('')
  const search = useDebouncedValue(searchInput.trim(), 200)
  const [savedLabel, setSavedLabel] = useState<string | null>(null)
  const estructuras = useEstructuras()
  const query = useControles()
  const save = useSaveControl()
  const records = useMemo(
    () =>
      (query.data ?? []).filter((row) =>
        includesSearch(search, [
          row.estructura?.nombre,
          row.estructura?.codigo,
          periodoLabel(row.anio, row.mes),
          row.fecha_lectura,
          row.referencia,
        ]),
      ),
    [query.data, search],
  )
  const selection = useRecordSelection(records)

  return (
    <HidroWorkspace
      title="Control hidrométrico"
      description="Registrá la lectura de la estructura, el volumen producido y el cloro."
      search={searchInput}
      onSearchChange={setSearchInput}
      searchPlaceholder="Estructura, periodo o referencia…"
      hasActiveFilters={Boolean(searchInput.trim())}
      onResetFilters={() => setSearchInput('')}
      onNew={() => {
        setSavedLabel(null)
        selection.startCreate()
      }}
      formTitle={selection.selected ? 'Editar control' : 'Nuevo control'}
      formDescription={
        selection.selected
          ? `Editando ${selection.selected.estructura?.nombre ?? 'estructura'} · ${periodoLabel(selection.selected.anio, selection.selected.mes)}.`
          : 'El volumen se calcula como la lectura final menos la inicial.'
      }
      list={
        <ControlList
          loading={query.isLoading}
          error={query.isError ? (query.error as Error).message : null}
          records={records}
          selectedId={selection.selected?.id}
          onSelect={(id) => {
            setSavedLabel(null)
            selection.select(id)
          }}
        />
      }
      form={
        estructuras.isLoading ? (
          <p className="text-sm text-muted-foreground">Cargando datos del formulario…</p>
        ) : (
          <>
            <SaveNotice
              error={save.isError ? (save.error as Error).message : null}
              saved={savedLabel}
            />
            <ControlForm
              key={selection.selected?.id ?? 'new'}
              initial={selection.selected}
              estructuras={estructuras.data ?? []}
              submitting={save.isPending}
              onSubmit={(payload) => {
                const label = `${formatVolume(payload.volumen_m3)} m³`
                save.mutate(
                  { id: selection.selected?.id ?? null, payload },
                  {
                    onSuccess: (row) => {
                      selection.select(row.id)
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

function ControlList({
  loading,
  error,
  records,
  selectedId,
  onSelect,
}: {
  loading: boolean
  error: string | null
  records: ControlListItem[]
  selectedId?: string
  onSelect: (id: string) => void
}) {
  if (loading) return <p className="text-sm text-muted-foreground">Cargando controles…</p>
  if (error) {
    return (
      <p role="alert" className="text-sm text-destructive">
        {error}
      </p>
    )
  }
  return (
    <DataTable
      columns={columns}
      rows={records}
      rowKey={(row) => row.id}
      selectedKey={selectedId}
      onRowSelect={(row) => onSelect(row.id)}
      emptyMessage="No hay controles con ese filtro."
      renderCell={(row, key) => {
        if (key === 'estructura') return row.estructura?.nombre ?? '—'
        if (key === 'periodo') return periodoLabel(row.anio, row.mes)
        if (key === 'horario') return `${timeInput(row.hora_inicio)} – ${timeInput(row.hora_fin)}`
        if (key === 'volumen') {
          return <span className="tabular-nums">{formatVolume(row.volumen_m3)}</span>
        }
        if (key === 'cloro') {
          return (
            <span className="tabular-nums">
              {formatVolume(row.cloro_inicial)} → {formatVolume(row.cloro_final)}
            </span>
          )
        }
        return <EditRowButton editing={selectedId === row.id} onEdit={() => onSelect(row.id)} />
      }}
    />
  )
}
