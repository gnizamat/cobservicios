import { useMemo, useState } from 'react'
import { FilterSelect, PaginationBar } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import {
  useDeleteLectura,
  useLecturas,
  useMarcasMedidor,
  usePagedPredios,
  useSaveLectura,
  useSaveMedidor,
  useServicioOptions,
  useTerritorioLectura,
  useValoresVolumen,
  type LecturaListItem,
  type ValorM3Activo,
} from '@/modules/lecturas/api'
import { HidroWorkspace } from '@/modules/lecturas/components/hidro-workspace'
import { LecturaForm } from '@/modules/lecturas/components/lectura-form'
import { MedidorForm } from '@/modules/lecturas/components/medidor-form'
import { PredioUsuarioTable } from '@/modules/lecturas/components/predio-usuario-table'
import { DeleteRowButton, EditRowButton, SaveNotice } from '@/modules/lecturas/components/record-actions'
import { formatMoney, formatVolume, periodoLabel, roundMoney, titularLabel } from '@/modules/lecturas/labels'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'

const lecturaColumns = [
  { key: 'servicio', header: 'Servicio' },
  { key: 'periodo', header: 'Periodo' },
  { key: 'lectura', header: 'Lectura m³', className: 'text-right' },
  { key: 'volumen', header: 'Volumen m³', className: 'text-right' },
  { key: 'tarifa', header: 'Tarifa m³', className: 'text-right' },
  { key: 'monto', header: 'A pagar', className: 'text-right' },
  { key: 'editar', header: '', className: 'w-40 text-right' },
]

export function LecturasPage() {
  const [searchInput, setSearchInput] = useState('')
  const [sectorId, setSectorId] = useState('all')
  const [calleId, setCalleId] = useState('all')
  const search = useDebouncedValue(searchInput.trim(), 200)
  const [savedLabel, setSavedLabel] = useState<string | null>(null)
  const [removedLabel, setRemovedLabel] = useState<string | null>(null)
  const [lecturaId, setLecturaId] = useState<string | null>(null)
  const [panel, setPanel] = useState<'lectura' | 'medidor'>('lectura')
  const territorio = useTerritorioLectura()
  const catalogo = usePagedPredios(search, sectorId, calleId)
  const sectorOptions = useMemo(
    () => [
      { value: 'all', label: 'Todos los centros poblados' },
      ...(territorio.data?.sectores ?? []).map((sector) => ({
        value: sector.id,
        label: sector.nombre,
      })),
    ],
    [territorio.data?.sectores],
  )
  const calleOptions = useMemo(() => {
    const calles = (territorio.data?.calles ?? []).filter(
      (calle) => sectorId === 'all' || calle.sector_id === sectorId,
    )
    return [
      { value: 'all', label: 'Todas las calles' },
      ...calles.map((calle) => ({ value: calle.id, label: calle.nombre })),
    ]
  }, [territorio.data?.calles, sectorId])
  const marcas = useMarcasMedidor()
  const servicios = useServicioOptions()
  const valoresM3 = useValoresVolumen()
  const query = useLecturas()
  const save = useSaveLectura()
  const remove = useDeleteLectura()
  const saveMedidor = useSaveMedidor()
  const selectedPredio = catalogo.selected
  const predioOptions =
    selectedPredio && !catalogo.rows.some((row) => row.id === selectedPredio.id)
      ? [selectedPredio, ...catalogo.rows]
      : catalogo.rows
  const lecturasPredio = (query.data ?? []).filter((row) => row.predio_id === selectedPredio?.id)
  const lectura = lecturasPredio.find((row) => row.id === lecturaId) ?? null
  const titular = titularLabel(selectedPredio?.usuario)

  return (
    <HidroWorkspace
      title="Registrar lecturas"
      description="La lista carga usuarios con su predio. Buscá por DNI, apellido o nombres. La lectura exige un medidor asignado."
      search={searchInput}
      onSearchChange={(value) => {
        setSearchInput(value)
        catalogo.resetPage()
      }}
      searchPlaceholder="DNI, apellido, nombres o predio…"
      filters={
        <>
          <FilterSelect
            label="Centro poblado"
            value={sectorId}
            options={sectorOptions}
            onChange={(value) => {
              setSectorId(value)
              setCalleId((current) => {
                if (current === 'all' || value === 'all') return current
                const calle = territorio.data?.calles.find((item) => item.id === current)
                return calle?.sector_id === value ? current : 'all'
              })
              catalogo.resetPage()
            }}
          />
          <FilterSelect
            label="Calle"
            value={calleOptions.some((option) => option.value === calleId) ? calleId : 'all'}
            options={calleOptions}
            onChange={(value) => {
              setCalleId(value)
              catalogo.resetPage()
            }}
          />
        </>
      }
      hasActiveFilters={Boolean(searchInput.trim()) || sectorId !== 'all' || calleId !== 'all'}
      onResetFilters={() => {
        setSearchInput('')
        setSectorId('all')
        setCalleId('all')
        catalogo.resetPage()
      }}
      onNew={() => {
        setSavedLabel(null)
        setLecturaId(null)
        setPanel('lectura')
      }}
      formTitle={
        panel === 'medidor' ? 'Registrar medidor' : lectura ? 'Editar lectura' : 'Nueva lectura'
      }
      formDescription={
        panel === 'medidor'
          ? `Asigná el medidor de ${titular}.`
          : lectura
            ? `Editando ${titular} · ${periodoLabel(lectura.anio, lectura.mes)}.`
            : selectedPredio?.medidor
              ? `Medidor ${selectedPredio.medidor.codigo}. Al guardar se graba la deuda por el volumen.`
              : 'Elegí un usuario. Si el predio no tiene medidor, registralo antes de la lectura.'
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
                setRemovedLabel(null)
                setLecturaId(null)
                setPanel('lectura')
                catalogo.select(id)
              }}
              onRegisterMeter={(id) => {
                setSavedLabel(null)
                setLecturaId(null)
                setPanel('medidor')
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
              <h3 className="text-sm font-medium text-foreground">Lecturas de {titular}</h3>
              {removedLabel ? (
                <p className="text-sm text-foreground" role="status">
                  Se eliminó la lectura de {removedLabel}.
                </p>
              ) : null}
              <LecturasDelPredio
                loading={query.isLoading}
                error={
                  remove.isError
                    ? (remove.error as Error).message
                    : query.isError
                      ? (query.error as Error).message
                      : null
                }
                records={lecturasPredio}
                valoresM3={valoresM3.data ?? []}
                selectedId={lectura?.id}
                deletingId={remove.isPending ? remove.variables : undefined}
                onSelect={(id) => {
                  setSavedLabel(null)
                  setPanel('lectura')
                  setLecturaId(id)
                }}
                onDelete={(row) => {
                  const periodo = periodoLabel(row.anio, row.mes)
                  if (!window.confirm(`¿Eliminar la lectura de ${periodo}?`)) return
                  setSavedLabel(null)
                  remove.mutate(row.id, {
                    onSuccess: () => {
                      if (lecturaId === row.id) setLecturaId(null)
                      setRemovedLabel(periodo)
                    },
                  })
                }}
              />
            </section>
          ) : null}
        </div>
      }
      form={
        catalogo.query.isLoading || servicios.isLoading || marcas.isLoading || query.isLoading || valoresM3.isLoading ? (
          <p className="text-sm text-muted-foreground">Cargando datos del formulario…</p>
        ) : panel === 'medidor' && selectedPredio ? (
          <>
            <SaveNotice
              error={saveMedidor.isError ? (saveMedidor.error as Error).message : null}
              saved={savedLabel}
            />
            <MedidorForm
              key={`${selectedPredio.id}-${selectedPredio.medidor?.id ?? 'nuevo'}`}
              predioId={selectedPredio.id}
              titular={titular}
              marcas={marcas.data ?? []}
              initial={selectedPredio.medidor}
              submitting={saveMedidor.isPending}
              onCancel={() => {
                setSavedLabel(null)
                setPanel('lectura')
              }}
              onSubmit={(payload) => {
                saveMedidor.mutate(
                  { id: selectedPredio.medidor?.id ?? null, payload },
                  {
                    onSuccess: () => {
                      setSavedLabel(payload.codigo)
                      setPanel('lectura')
                    },
                  },
                )
              }}
            />
          </>
        ) : (
          <>
            <SaveNotice
              error={save.isError ? (save.error as Error).message : null}
              saved={savedLabel}
            />
            <LecturaForm
              key={`${lectura?.id ?? 'new'}-${selectedPredio?.id ?? 'none'}-${selectedPredio?.medidor?.id ?? 'sin'}`}
              initial={lectura}
              predioId={selectedPredio?.id}
              predios={predioOptions}
              servicios={servicios.data ?? []}
              lecturas={query.data ?? []}
              valoresM3={valoresM3.data ?? []}
              historialListo={!query.isError}
              submitting={save.isPending}
              onRegisterMeter={(id) => {
                setSavedLabel(null)
                catalogo.select(id)
                setPanel('medidor')
              }}
              onSubmit={(payload) => {
                save.mutate(
                  { id: lectura?.id ?? null, payload },
                  {
                    onSuccess: (row) => {
                      catalogo.select(row.predio_id)
                      setLecturaId(row.id)
                      setSavedLabel(
                        row.deuda_generada
                          ? `${periodoLabel(row.anio, row.mes)} · deuda ${formatMoney(row.deuda_monto)} por ${formatVolume(row.deuda_volumen)} m³`
                          : periodoLabel(row.anio, row.mes),
                      )
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

function importeLectura(row: LecturaListItem, valoresM3: ValorM3Activo[]) {
  const tarifa = valoresM3.find((item) => item.anio === row.anio) ?? null
  if (!tarifa || tarifa.valor <= 0) return { tarifa: null, monto: null }
  return { tarifa, monto: roundMoney(Number(row.volumen_m3) * tarifa.valor) }
}

function LecturasDelPredio({
  loading,
  error,
  records,
  valoresM3,
  selectedId,
  deletingId,
  onSelect,
  onDelete,
}: {
  loading: boolean
  error: string | null
  records: LecturaListItem[]
  valoresM3: ValorM3Activo[]
  selectedId?: string
  deletingId?: string
  onSelect: (id: string) => void
  onDelete: (row: LecturaListItem) => void
}) {
  if (loading) return <p className="text-sm text-muted-foreground">Cargando lecturas…</p>
  if (error) {
    return (
      <p role="alert" className="text-sm text-destructive">
        {error}
      </p>
    )
  }
  return (
    <DataTable
      columns={lecturaColumns}
      rows={records}
      rowKey={(row) => row.id}
      selectedKey={selectedId}
      onRowSelect={(row) => onSelect(row.id)}
      emptyMessage="Este predio no tiene lecturas registradas."
      renderCell={(row, key) => {
        if (key === 'servicio') return row.servicio?.nombre ?? '—'
        if (key === 'periodo') return periodoLabel(row.anio, row.mes)
        if (key === 'lectura') {
          return <span className="tabular-nums">{formatVolume(row.lectura_m3)}</span>
        }
        if (key === 'volumen') {
          return <span className="tabular-nums">{formatVolume(row.volumen_m3)}</span>
        }
        if (key === 'tarifa' || key === 'monto') {
          const importe = importeLectura(row, valoresM3)
          const texto =
            key === 'tarifa'
              ? importe.tarifa
                ? `${formatMoney(importe.tarifa.valor)} · ${importe.tarifa.nombre}`
                : 'Sin tarifa'
              : importe.monto == null
                ? '—'
                : formatMoney(importe.monto)
          return <span className="tabular-nums">{texto}</span>
        }
        return (
          <span className="inline-flex justify-end gap-1">
            <EditRowButton editing={selectedId === row.id} onEdit={() => onSelect(row.id)} />
            <DeleteRowButton
              deleting={deletingId === row.id}
              onDelete={() => onDelete(row)}
            />
          </span>
        )
      }}
    />
  )
}
