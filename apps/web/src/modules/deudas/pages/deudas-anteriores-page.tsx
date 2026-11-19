import { useMemo, useState } from 'react'
import { FilterSelect, PaginationBar } from '@/design-system/molecules'
import {
  useCatalogoTarifas,
  useDeudasAnteriores,
  useDeleteDeudaAnterior,
  usePagedPredios,
  useSaveDeudasAnteriores,
  useTerritorioDeuda,
} from '@/modules/deudas/api'
import { DeudaAnteriorForm } from '@/modules/deudas/components/deuda-anterior-form'
import { DeudaWorkspace } from '@/modules/deudas/components/deuda-workspace'
import { DeudasAnterioresTable } from '@/modules/deudas/components/deudas-anteriores-table'
import { PredioUsuarioTable } from '@/modules/deudas/components/predio-usuario-table'
import { mesLabel, predioLabel, titularLabel } from '@/modules/deudas/labels'
import type { DeudaAnteriorPayload } from '@/modules/deudas/schemas'
import type {
  CostoTarifaOption,
  DeudaAnteriorListItem,
  PredioDeudaOption,
  TarifaAnio,
} from '@/modules/deudas/types'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'

function UsuarioPredioPanel({
  loading,
  error,
  rows,
  selectedId,
  titular,
  records,
  debtsLoading,
  debtsError,
  pendingDeleteId,
  deleting,
  deleteError,
  page,
  pageSize,
  total,
  onPageChange,
  onPageSizeChange,
  onSelect,
  onAskDelete,
  onCancelDelete,
  onConfirmDelete,
}: {
  loading: boolean
  error: string | null
  rows: PredioDeudaOption[]
  selectedId?: string
  titular: string
  records: DeudaAnteriorListItem[]
  debtsLoading: boolean
  debtsError: string | null
  pendingDeleteId: string | null
  deleting: boolean
  deleteError: string | null
  page: number
  pageSize: number
  total: number
  onPageChange: (page: number) => void
  onPageSizeChange: (size: number) => void
  onSelect: (id: string) => void
  onAskDelete: (id: string) => void
  onCancelDelete: () => void
  onConfirmDelete: (id: string) => void
}) {
  return (
    <div className="space-y-4">
      <div>
        <PredioUsuarioTable
          loading={loading}
          error={error}
          rows={rows}
          selectedId={selectedId}
          onSelect={onSelect}
        />
        <PaginationBar
          page={page}
          pageSize={pageSize}
          total={total}
          onPageChange={onPageChange}
          onPageSizeChange={onPageSizeChange}
        />
      </div>
      {selectedId ? (
        <section className="space-y-2">
          <h3 className="text-sm font-medium text-foreground">Deudas de {titular}</h3>
          <DeudasAnterioresTable
            loading={debtsLoading}
            error={debtsError}
            rows={records}
            pendingDeleteId={pendingDeleteId}
            deleting={deleting}
            onAskDelete={onAskDelete}
            onCancelDelete={onCancelDelete}
            onConfirmDelete={onConfirmDelete}
          />
          {deleteError ? (
            <p role="alert" className="text-sm text-destructive">
              {deleteError}
            </p>
          ) : null}
        </section>
      ) : null}
    </div>
  )
}

function Notice({ error, saved }: { error: string | null; saved: string | null }) {
  if (error) {
    return (
      <p role="alert" className="mb-3 text-sm text-destructive">
        {error}
      </p>
    )
  }
  if (!saved) return null
  return (
    <p className="mb-3 text-sm text-foreground" role="status">
      Se grabaron las deudas de {saved}.
    </p>
  )
}

function DeudaFormPanel({
  loading,
  error,
  predio,
  tarifas,
  costos,
  registradas,
  formNonce,
  submitting,
  saveError,
  savedLabel,
  onSubmit,
}: {
  loading: boolean
  error: string | null
  predio: PredioDeudaOption | null
  tarifas: TarifaAnio[]
  costos: CostoTarifaOption[]
  registradas: Array<{ anio: number; mes: number; tipo_servicio_id: string }>
  formNonce: number
  submitting: boolean
  saveError: string | null
  savedLabel: string | null
  onSubmit: (payloads: DeudaAnteriorPayload[]) => void
}) {
  if (loading) return <p className="text-sm text-muted-foreground">Cargando datos del formulario…</p>
  if (error) {
    return (
      <p role="alert" className="text-sm text-destructive">
        {error}
      </p>
    )
  }
  if (!predio) {
    return <p className="text-sm text-muted-foreground">No hay predios activos para registrar deudas.</p>
  }
  return (
    <>
      <Notice error={saveError} saved={savedLabel} />
      <DeudaAnteriorForm
        key={`${predio.id}-${formNonce}`}
        predio={predio}
        tarifas={tarifas}
        costos={costos}
        registradas={registradas}
        submitting={submitting}
        onSubmit={onSubmit}
      />
    </>
  )
}

export function DeudasAnterioresPage() {
  const [searchInput, setSearchInput] = useState('')
  const [sectorId, setSectorId] = useState('all')
  const [calleId, setCalleId] = useState('all')
  const [formNonce, setFormNonce] = useState(0)
  const [savedLabel, setSavedLabel] = useState<string | null>(null)
  const [pendingDeleteId, setPendingDeleteId] = useState<string | null>(null)
  const search = useDebouncedValue(searchInput.trim(), 200)
  const territorio = useTerritorioDeuda()
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
  const tarifas = useCatalogoTarifas()
  const selected = catalogo.selected
  const deudas = useDeudasAnteriores(selected?.id ?? null)
  const save = useSaveDeudasAnteriores(selected?.id ?? null)
  const remove = useDeleteDeudaAnterior(selected?.id ?? null)
  const titular = titularLabel(selected?.usuario)
  const records = deudas.data ?? []

  return (
    <DeudaWorkspace
      title="Deudas anteriores"
      description="Elegí el usuario y su predio. Agregá deudas de distinto año, mes y tipo de servicio, y grabalas todas juntas."
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
        setPendingDeleteId(null)
        setFormNonce((value) => value + 1)
      }}
      formTitle="Registrar deuda anterior"
      formDescription={
        selected
          ? `${titular} · ${predioLabel(selected)}. Agregá cada deuda y después grabá el lote.`
          : 'Elegí un usuario de la lista para registrar la deuda de su predio.'
      }
      list={
        <UsuarioPredioPanel
          loading={catalogo.query.isLoading}
          error={catalogo.query.isError ? (catalogo.query.error as Error).message : null}
          rows={catalogo.rows}
          selectedId={selected?.id}
          titular={titular}
          records={records}
          debtsLoading={deudas.isLoading}
          debtsError={deudas.isError ? (deudas.error as Error).message : null}
          pendingDeleteId={pendingDeleteId}
          deleting={remove.isPending}
          deleteError={remove.isError ? (remove.error as Error).message : null}
          page={catalogo.page}
          pageSize={catalogo.pageSize}
          total={catalogo.total}
          onPageChange={catalogo.setPage}
          onPageSizeChange={catalogo.changePageSize}
          onSelect={(id) => {
            setSavedLabel(null)
            setPendingDeleteId(null)
            setFormNonce((value) => value + 1)
            catalogo.select(id)
          }}
          onAskDelete={setPendingDeleteId}
          onCancelDelete={() => setPendingDeleteId(null)}
          onConfirmDelete={(id) => {
            remove.mutate(id, {
              onSuccess: () => {
                setPendingDeleteId(null)
                setSavedLabel(null)
              },
            })
          }}
        />
      }
      form={
        <DeudaFormPanel
          loading={catalogo.query.isLoading || tarifas.isLoading}
          error={tarifas.isError ? (tarifas.error as Error).message : null}
          predio={selected}
          tarifas={tarifas.data?.tarifas ?? []}
          costos={tarifas.data?.costos ?? []}
          registradas={records}
          formNonce={formNonce}
          submitting={save.isPending}
          saveError={save.isError ? (save.error as Error).message : null}
          savedLabel={savedLabel}
          onSubmit={(payloads) => {
            save.mutate(payloads, {
              onSuccess: () => {
                const periodos = new Set(payloads.map((payload) => `${mesLabel(payload.mes)} ${payload.anio}`))
                setSavedLabel(
                  payloads.length === 1
                    ? [...periodos][0]
                    : `${payloads.length} registros (${[...periodos].join(', ')})`,
                )
                setFormNonce((value) => value + 1)
              },
            })
          }}
        />
      }
    />
  )
}
