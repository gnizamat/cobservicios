import { useMemo, useState } from 'react'
import { FilterSelect, PaginationBar } from '@/design-system/molecules'
import { Button } from '@/design-system/atoms'
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
  type LecturaGuardada,
  type LecturaListItem,
  type MarcaMedidor,
  type PredioOption,
  type ServicioOption,
  type ValorM3Activo,
} from '@/modules/lecturas/api'
import { HidroWorkspace } from '@/modules/lecturas/components/hidro-workspace'
import { LecturaForm } from '@/modules/lecturas/components/lectura-form'
import { LecturaNuevaDialog } from '@/modules/lecturas/components/lectura-nueva-dialog'
import { MedidorForm } from '@/modules/lecturas/components/medidor-form'
import { PredioUsuarioTable } from '@/modules/lecturas/components/predio-usuario-table'
import { DeleteRowButton, EditRowButton, SaveNotice } from '@/modules/lecturas/components/record-actions'
import { formatMoney, formatVolume, periodoLabel, roundMoney, titularLabel } from '@/modules/lecturas/labels'
import type { LecturaPayload, MedidorPayload } from '@/modules/lecturas/schemas'
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
  const [lecturaNueva, setLecturaNueva] = useState(false)
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
    <>
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
        setLecturaNueva(Boolean(selectedPredio))
      }}
      formTitle={
        panel === 'medidor' ? 'Registrar medidor' : lectura ? 'Editar lectura' : 'Lectura del predio'
      }
      formDescription={
        panel === 'medidor'
          ? `Asigná el medidor de ${titular}.`
          : lectura
            ? `Editando ${titular} · ${periodoLabel(lectura.anio, lectura.mes)}.`
            : selectedPredio
              ? `${titular}. Nuevo abre el formulario para registrar la lectura.`
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
                setLecturaNueva(false)
                setPanel('lectura')
                catalogo.select(id)
              }}
              onRegisterMeter={(id) => {
                setSavedLabel(null)
                setLecturaId(null)
                setLecturaNueva(false)
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
                  setLecturaNueva(false)
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
        <LecturasAside
          loading={
            catalogo.query.isLoading ||
            servicios.isLoading ||
            marcas.isLoading ||
            query.isLoading ||
            valoresM3.isLoading
          }
          panel={panel}
          predio={selectedPredio}
          titular={titular}
          lectura={lectura}
          lecturaNueva={lecturaNueva}
          savedLabel={savedLabel}
          saveError={save.isError ? (save.error as Error).message : null}
          medidorError={saveMedidor.isError ? (saveMedidor.error as Error).message : null}
          marcas={marcas.data ?? []}
          predios={predioOptions}
          servicios={servicios.data ?? []}
          lecturas={query.data ?? []}
          valoresM3={valoresM3.data ?? []}
          historialListo={!query.isError}
          savingLectura={save.isPending}
          savingMedidor={saveMedidor.isPending}
          onOpenNueva={() => setLecturaNueva(true)}
          onCancelMedidor={() => {
            setSavedLabel(null)
            setPanel('lectura')
          }}
          onSaveMedidor={(id, payload) => {
            saveMedidor.mutate(
              { id, payload },
              {
                onSuccess: () => {
                  setSavedLabel(payload.codigo)
                  setPanel('lectura')
                },
              },
            )
          }}
          onRegisterMeter={(id) => {
            setSavedLabel(null)
            catalogo.select(id)
            setPanel('medidor')
          }}
          onSaveLectura={(id, payload) => {
            save.mutate(
              { id, payload },
              {
                onSuccess: (row) => {
                  catalogo.select(row.predio_id)
                  setLecturaId(row.id)
                  setSavedLabel(etiquetaGuardada(row))
                },
              },
            )
          }}
        />
      }
    />
    {lecturaNueva && selectedPredio ? (
      <LecturaNuevaDialog
        predio={selectedPredio}
        predios={predioOptions}
        servicios={servicios.data ?? []}
        lecturas={query.data ?? []}
        valoresM3={valoresM3.data ?? []}
        historialListo={!query.isError}
        loading={servicios.isLoading || query.isLoading || valoresM3.isLoading}
        submitting={save.isPending}
        error={save.isError ? (save.error as Error).message : null}
        onClose={() => setLecturaNueva(false)}
        onRegisterMeter={(id) => {
          setSavedLabel(null)
          setLecturaNueva(false)
          catalogo.select(id)
          setPanel('medidor')
        }}
        onSubmit={(payload) => {
          save.mutate(
            { id: null, payload },
            {
              onSuccess: (row) => {
                catalogo.select(row.predio_id)
                setLecturaId(null)
                setLecturaNueva(false)
                setPanel('lectura')
                setSavedLabel(etiquetaGuardada(row))
              },
            },
          )
        }}
      />
    ) : null}
    </>
  )
}

function etiquetaGuardada(row: LecturaGuardada) {
  return row.deuda_generada
    ? `${periodoLabel(row.anio, row.mes)} · deuda ${formatMoney(row.deuda_monto)} por ${formatVolume(row.deuda_volumen)} m³`
    : periodoLabel(row.anio, row.mes)
}

function LecturasAside({
  loading,
  panel,
  predio,
  titular,
  lectura,
  lecturaNueva,
  savedLabel,
  saveError,
  medidorError,
  marcas,
  predios,
  servicios,
  lecturas,
  valoresM3,
  historialListo,
  savingLectura,
  savingMedidor,
  onOpenNueva,
  onCancelMedidor,
  onSaveMedidor,
  onRegisterMeter,
  onSaveLectura,
}: {
  loading: boolean
  panel: 'lectura' | 'medidor'
  predio: PredioOption | null
  titular: string
  lectura: LecturaListItem | null
  lecturaNueva: boolean
  savedLabel: string | null
  saveError: string | null
  medidorError: string | null
  marcas: MarcaMedidor[]
  predios: PredioOption[]
  servicios: ServicioOption[]
  lecturas: LecturaListItem[]
  valoresM3: ValorM3Activo[]
  historialListo: boolean
  savingLectura: boolean
  savingMedidor: boolean
  onOpenNueva: () => void
  onCancelMedidor: () => void
  onSaveMedidor: (id: string | null, payload: MedidorPayload) => void
  onRegisterMeter: (id: string) => void
  onSaveLectura: (id: string, payload: LecturaPayload) => void
}) {
  if (loading) return <p className="text-sm text-muted-foreground">Cargando datos del formulario…</p>
  if (panel === 'medidor' && predio) {
    return (
      <>
        <SaveNotice error={medidorError} saved={savedLabel} />
        <MedidorForm
          key={`${predio.id}-${predio.medidor?.id ?? 'nuevo'}`}
          predioId={predio.id}
          titular={titular}
          marcas={marcas}
          initial={predio.medidor}
          submitting={savingMedidor}
          onCancel={onCancelMedidor}
          onSubmit={(payload) => onSaveMedidor(predio.medidor?.id ?? null, payload)}
        />
      </>
    )
  }
  if (lectura) {
    return (
      <>
        <SaveNotice error={saveError} saved={savedLabel} />
        <LecturaForm
          key={`${lectura.id}-${predio?.id ?? 'none'}-${predio?.medidor?.id ?? 'sin'}`}
          initial={lectura}
          predioId={predio?.id}
          predios={predios}
          servicios={servicios}
          lecturas={lecturas}
          valoresM3={valoresM3}
          historialListo={historialListo}
          submitting={savingLectura}
          onRegisterMeter={onRegisterMeter}
          onSubmit={(payload) => onSaveLectura(lectura.id, payload)}
        />
      </>
    )
  }
  return (
    <>
      {lecturaNueva ? null : <SaveNotice error={saveError} saved={savedLabel} />}
      <div className="space-y-3 rounded-2xl border border-border bg-card p-4">
        <p className="text-sm text-muted-foreground">
          {predio
            ? `La lectura de ${titular} se registra en un formulario aparte.`
            : 'Elegí un predio de la lista.'}
        </p>
        <Button type="button" size="sm" disabled={!predio} onClick={onOpenNueva}>
          Registrar lectura
        </Button>
      </div>
    </>
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
