import { useEffect, useMemo, useState } from 'react'
import { Button, Input, Select } from '@/design-system/atoms'
import { FilterSelect, ListFilters, PageHeader } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import { AppShell } from '@/design-system/templates'
import {
  useCajas,
  useCobranzaPredio,
  useCobrarFacturaciones,
  usePrediosACobrar,
  useTerritorioCobranza,
} from '@/modules/cobranza/api'
import type { FacturaCobro, PredioCobranza } from '@/modules/cobranza/api'
import { ReciboPagoDialog } from '@/modules/cobranza/components/recibo-pago-dialog'
import { PagosListado } from '@/modules/cobranza/pages/pagos-listado-page'
import {
  etiquetaCaja,
  fechaHoy,
  formatFecha,
  formatMoney,
  formatVolume,
  mesLabel,
  predioLabel,
  TIPOS_PAGO,
  type TipoPago,
} from '@/modules/cobranza/labels'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'
import { cn } from '@/shared/lib/utils'

export function CobranzaFacturacionesPage() {
  const [vista, setVista] = useState<'cobrar' | 'pagos'>('cobrar')
  const [searchInput, setSearchInput] = useState('')
  const search = useDebouncedValue(searchInput.trim(), 300)
  const [sectorId, setSectorId] = useState('all')
  const [calleId, setCalleId] = useState('all')
  const [predioId, setPredioId] = useState<string | null>(null)
  const [aviso, setAviso] = useState<string | null>(null)
  const [reciboId, setReciboId] = useState<string | null>(null)
  const territorio = useTerritorioCobranza()
  const predios = usePrediosACobrar({ sectorId, calleId, search })
  const rows = predios.data ?? []

  useEffect(() => {
    if (predioId && predios.data && !predios.data.some((row) => row.predioId === predioId)) {
      setPredioId(null)
    }
  }, [predioId, predios.data])

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

  function cambiarSector(value: string) {
    setSectorId(value)
    setCalleId((current) => {
      if (current === 'all' || value === 'all') return current
      const calle = territorio.data?.calles.find((item) => item.id === current)
      return calle?.sector_id === value ? current : 'all'
    })
    setPredioId(null)
    setAviso(null)
  }

  const esPagos = vista === 'pagos'

  return (
    <AppShell className="max-w-none">
      <PageHeader
        title={esPagos ? 'Listado de pagos' : 'Cobranza de facturaciones'}
        description={
          esPagos
            ? 'Pagos del periodo. Filtrá por centro poblado, caja y fechas. Imprimí el recibo o eliminá el pago con tu contraseña.'
            : 'Predios con facturas pendientes. Filtrá por centro poblado y calle, elegí el predio y marcá las facturas a cobrar.'
        }
        actions={
          <div className="flex rounded-lg border border-border p-0.5">
            <Button
              type="button"
              size="sm"
              variant={esPagos ? 'ghost' : 'default'}
              onClick={() => setVista('cobrar')}
            >
              Por cobrar
            </Button>
            <Button
              type="button"
              size="sm"
              variant={esPagos ? 'default' : 'ghost'}
              onClick={() => setVista('pagos')}
            >
              Pagos
            </Button>
          </div>
        }
      />
      {esPagos ? (
        <PagosListado />
      ) : (
      <>
      <ListFilters
        liveSearch
        search={searchInput}
        onSearchChange={setSearchInput}
        searchPlaceholder="Nombre, DNI, RUC o predio…"
        hasActiveFilters={Boolean(searchInput.trim()) || sectorId !== 'all' || calleId !== 'all'}
        onReset={() => {
          setSearchInput('')
          setSectorId('all')
          setCalleId('all')
          setPredioId(null)
          setAviso(null)
        }}
        filters={
          <>
            <FilterSelect
              label="Centro poblado"
              value={sectorId}
              options={sectorOptions}
              onChange={cambiarSector}
            />
            <FilterSelect
              label="Calle"
              value={calleOptions.some((option) => option.value === calleId) ? calleId : 'all'}
              options={calleOptions}
              onChange={(value) => {
                setCalleId(value)
                setPredioId(null)
                setAviso(null)
              }}
            />
          </>
        }
      />

      {aviso ? (
        <p className="mb-3 text-sm text-foreground" role="status">
          {aviso}
        </p>
      ) : null}

      <div className="grid items-start gap-4 xl:grid-cols-[minmax(0,1fr)_34rem]">
        <section className="min-w-0">
          {predios.isLoading ? (
            <p className="text-sm text-muted-foreground">Cargando predios con facturas…</p>
          ) : predios.isError ? (
            <p role="alert" className="text-sm text-destructive">
              {(predios.error as Error).message}
            </p>
          ) : (
            <DataTable
              columns={[
                { key: 'usuario', header: 'Usuario', className: 'whitespace-nowrap px-1.5' },
                { key: 'documento', header: 'Documento', className: 'whitespace-nowrap px-1.5' },
                { key: 'predio', header: 'Predio', className: 'whitespace-nowrap px-1.5' },
                { key: 'sector', header: 'Centro poblado', className: 'whitespace-nowrap px-1.5' },
                { key: 'calle', header: 'Calle', className: 'whitespace-nowrap px-1.5' },
                { key: 'facturas', header: 'Facturas', className: 'whitespace-nowrap px-1.5 text-right' },
                { key: 'monto', header: 'Pendiente', className: 'whitespace-nowrap px-1.5 text-right' },
              ]}
              rows={rows}
              rowKey={(row) => row.predioId}
              selectedKey={predioId ?? undefined}
              onRowSelect={(row) => {
                setAviso(null)
                setPredioId(row.predioId)
              }}
              emptyMessage="No hay predios con facturas pendientes para ese centro y esa calle."
              renderCell={(row, key) => renderPredio(row, key)}
            />
          )}
        </section>
        <CobroPanel
          predioId={predioId}
          onCobrado={(mensaje, pagoId) => {
            setAviso(mensaje)
            setReciboId(pagoId)
          }}
        />
      </div>
      {reciboId ? <ReciboPagoDialog id={reciboId} onClose={() => setReciboId(null)} /> : null}
      </>
      )}
    </AppShell>
  )
}

function renderPredio(row: PredioCobranza, key: string) {
  if (key === 'usuario') return <span className="font-medium">{row.usuario || '—'}</span>
  if (key === 'documento') return row.documento || '—'
  if (key === 'predio') return predioLabel(row.predio, row.numero)
  if (key === 'sector') return row.sector || '—'
  if (key === 'calle') return row.calle || '—'
  if (key === 'facturas') return <span className="block text-right tabular-nums">{row.facturas}</span>
  if (key === 'monto') {
    return <span className="block text-right tabular-nums">{formatMoney(row.monto)}</span>
  }
  return null
}

function CobroPanel({
  predioId,
  onCobrado,
}: {
  predioId: string | null
  onCobrado: (mensaje: string, pagoId: string) => void
}) {
  const detalle = useCobranzaPredio(predioId)
  const cajas = useCajas()
  const cobrar = useCobrarFacturaciones()
  const [anio, setAnio] = useState('all')
  const [picked, setPicked] = useState<string[]>([])
  const [tipoPago, setTipoPago] = useState<TipoPago>('efectivo')
  const [referencia, setReferencia] = useState('')
  const [cajaId, setCajaId] = useState('')

  useEffect(() => {
    setAnio('all')
    setPicked([])
    setTipoPago('efectivo')
    setReferencia('')
  }, [predioId])

  useEffect(() => {
    const primera = cajas.data?.[0]?.id
    if (primera && !cajas.data?.some((caja) => caja.id === cajaId)) {
      setCajaId(primera)
    }
  }, [cajaId, cajas.data])

  const facturas = detalle.data?.facturas ?? []
  const anios = useMemo(
    () => [...new Set(facturas.map((factura) => factura.anio))].sort((a, b) => b - a),
    [facturas],
  )
  const visibles = facturas.filter((factura) => anio === 'all' || String(factura.anio) === anio)
  const pendientes = visibles.filter((factura) => factura.estado === 'generada')
  const selected = new Set(picked.filter((id) => pendientes.some((factura) => factura.id === id)))
  const elegidas = pendientes.filter((factura) => selected.has(factura.id))
  const allSelected = pendientes.length > 0 && pendientes.every((factura) => selected.has(factura.id))
  const total = elegidas.reduce((sum, factura) => sum + factura.monto, 0)
  const interes = elegidas.reduce((sum, factura) => sum + factura.interes, 0)
  const referenciaObligatoria = tipoPago !== 'efectivo'
  const puedeCobrar = elegidas.length > 0 && (!referenciaObligatoria || referencia.trim().length > 0)

  function toggle(id: string) {
    setPicked((current) =>
      current.includes(id) ? current.filter((item) => item !== id) : [...current, id],
    )
  }

  function cobrarSeleccion() {
    if (!predioId || !puedeCobrar) return
    cobrar.mutate(
      {
        predioId,
        facturacionIds: elegidas.map((factura) => factura.id),
        tipoPago,
        referencia: tipoPago === 'efectivo' ? '' : referencia.trim(),
        fecha: fechaHoy(),
        cajaId,
      },
      {
        onSuccess: (pago) => {
          setPicked([])
          setReferencia('')
          onCobrado(
            pago.facturas === 1
              ? `Se cobró ${pago.numero} por ${formatMoney(pago.monto)}.`
              : `Se cobraron ${pago.facturas} facturas en ${pago.numero} por ${formatMoney(pago.monto)}.`,
            pago.id,
          )
        },
      },
    )
  }

  if (!predioId) {
    return (
      <aside className="rounded-2xl border border-dashed border-border px-4 py-8 text-sm text-muted-foreground">
        Elegí un predio para ver sus facturaciones y cobrarlas.
      </aside>
    )
  }

  if (detalle.isLoading) {
    return <p className="text-sm text-muted-foreground">Cargando facturaciones…</p>
  }

  if (detalle.isError) {
    return (
      <p role="alert" className="text-sm text-destructive">
        {(detalle.error as Error).message}
      </p>
    )
  }

  const predio = detalle.data
  if (!predio) return null

  return (
    <aside className="space-y-3 rounded-2xl border border-border bg-card p-4">
      <header className="flex items-start justify-between gap-3">
        <div className="min-w-0">
          <p className="text-[11px] font-medium tracking-wide text-muted-foreground uppercase">
            Datos del predio
          </p>
          <h2 className="mt-1 text-base font-semibold text-foreground">{predio.usuario || '—'}</h2>
          <p className="text-sm text-muted-foreground">
            {predioLabel(predio.nombre, predio.numero)}
            {predio.documento ? ` · ${predio.documento}` : ''}
          </p>
          <p className="text-sm text-muted-foreground">
            {[predio.sector, predio.calle].filter(Boolean).join(' · ') || 'Sin ubicación'}
          </p>
        </div>
        <p className="shrink-0 text-right text-sm text-muted-foreground">
          F. cobranza
          <span className="mt-0.5 block font-medium text-foreground">{formatFecha(fechaHoy())}</span>
        </p>
      </header>

      <label className="flex max-w-[12rem] flex-col gap-1 text-xs text-muted-foreground">
        Filtrar por año
        <Select
          aria-label="Filtrar por año"
          value={anios.some((year) => String(year) === anio) || anio === 'all' ? anio : 'all'}
          onChange={(event) => {
            setAnio(event.target.value)
            setPicked([])
          }}
          className="h-8 text-sm text-foreground"
        >
          <option value="all">Todos</option>
          {anios.map((year) => (
            <option key={year} value={String(year)}>
              {year}
            </option>
          ))}
        </Select>
      </label>

      <FacturasTable
        facturas={visibles}
        selected={selected}
        allSelected={allSelected}
        onToggleAll={() => setPicked(allSelected ? [] : pendientes.map((factura) => factura.id))}
        onToggle={toggle}
      />

      <p className="rounded-lg bg-secondary/50 px-3 py-2 text-xs text-muted-foreground">
        {elegidas.length === 0
          ? 'Ninguna factura seleccionada.'
          : elegidas.map((factura) => factura.numero).join(', ')}
      </p>

      <div className="grid gap-3 sm:grid-cols-2">
        <label className="flex flex-col gap-1 text-xs text-muted-foreground sm:col-span-2">
          Caja
          <Select
            aria-label="Caja"
            value={cajaId}
            onChange={(event) => setCajaId(event.target.value)}
            className="h-8 text-sm text-foreground"
          >
            {(cajas.data ?? []).map((caja) => (
              <option key={caja.id} value={caja.id}>
                {etiquetaCaja(caja.nombre, caja.sector, caja.usuario)}
              </option>
            ))}
          </Select>
        </label>
        <label className="flex flex-col gap-1 text-xs text-muted-foreground">
          Tipo de pago
          <Select
            aria-label="Tipo de pago"
            value={tipoPago}
            onChange={(event) => {
              const next = event.target.value as TipoPago
              setTipoPago(next)
              if (next === 'efectivo') setReferencia('')
            }}
            className="h-8 text-sm text-foreground"
          >
            {TIPOS_PAGO.map((tipo) => (
              <option key={tipo.value} value={tipo.value}>
                {tipo.label}
              </option>
            ))}
          </Select>
        </label>
        <label className="flex flex-col gap-1 text-xs text-muted-foreground">
          Referencia
          <Input
            value={referencia}
            disabled={!referenciaObligatoria}
            onChange={(event) => setReferencia(event.target.value)}
            aria-label="Referencia del pago"
            className="h-8 text-sm"
          />
        </label>
      </div>

      <dl className="grid grid-cols-2 gap-2 text-sm">
        <div>
          <dt className="text-xs text-muted-foreground">Total a pagar deuda</dt>
          <dd className="font-medium tabular-nums">{formatMoney(total)}</dd>
        </div>
        <div>
          <dt className="text-xs text-muted-foreground">Total a pagar interés</dt>
          <dd className="font-medium tabular-nums">{formatMoney(interes)}</dd>
        </div>
        <div className="col-span-2">
          <dt className="text-xs text-muted-foreground">Total a pagar</dt>
          <dd className="text-base font-semibold tabular-nums text-foreground">{formatMoney(total)}</dd>
        </div>
      </dl>

      {cobrar.isError ? (
        <p role="alert" className="text-sm text-destructive">
          {(cobrar.error as Error).message}
        </p>
      ) : null}

      <Button type="button" disabled={!puedeCobrar || cobrar.isPending} onClick={cobrarSeleccion}>
        {cobrar.isPending ? 'Cobrando…' : 'Cobrar'}
      </Button>
    </aside>
  )
}

function FacturasTable({
  facturas,
  selected,
  allSelected,
  onToggleAll,
  onToggle,
}: {
  facturas: FacturaCobro[]
  selected: Set<string>
  allSelected: boolean
  onToggleAll: () => void
  onToggle: (id: string) => void
}) {
  if (facturas.length === 0) {
    return (
      <p className="rounded-lg border border-dashed border-border px-3 py-6 text-center text-sm text-muted-foreground">
        Este predio no tiene facturaciones en ese año.
      </p>
    )
  }

  return (
    <div className="overflow-hidden rounded-lg border border-border">
      <div className="overflow-x-auto">
        <table className="min-w-full text-[13px]">
          <thead className="bg-secondary/50 text-left text-[11px] tracking-wide text-muted-foreground uppercase">
            <tr>
              <th className="w-10 px-2.5 py-2">
                <input
                  type="checkbox"
                  aria-label="Seleccionar todas las facturas pendientes"
                  checked={allSelected}
                  onChange={onToggleAll}
                />
              </th>
              <th className="px-2.5 py-2 font-semibold">Periodo</th>
              <th className="px-2.5 py-2 font-semibold">Factura</th>
              <th className="px-2.5 py-2 text-right font-semibold">Monto</th>
              <th className="px-2.5 py-2 text-right font-semibold">Volumen</th>
              <th className="px-2.5 py-2 font-semibold">Servicio</th>
              <th className="px-2.5 py-2 font-semibold">Estado</th>
            </tr>
          </thead>
          <tbody>
            {facturas.map((factura) => {
              const pendiente = factura.estado === 'generada'
              return (
                <tr
                  key={factura.id}
                  className={cn('border-t border-border/70', selected.has(factura.id) && 'bg-primary/10')}
                >
                  <td className="px-2.5 py-1.5">
                    <input
                      type="checkbox"
                      aria-label={`Seleccionar ${factura.numero}`}
                      checked={selected.has(factura.id)}
                      disabled={!pendiente}
                      onChange={() => onToggle(factura.id)}
                    />
                  </td>
                  <td className="px-2.5 py-1.5">
                    {mesLabel(factura.mes)} {factura.anio}
                  </td>
                  <td className="px-2.5 py-1.5 font-medium">{factura.numero}</td>
                  <td className="px-2.5 py-1.5 text-right tabular-nums">{formatMoney(factura.monto)}</td>
                  <td className="px-2.5 py-1.5 text-right tabular-nums">
                    {formatVolume(factura.volumen)}
                  </td>
                  <td className="px-2.5 py-1.5 text-muted-foreground">{factura.servicios || '—'}</td>
                  <td className="px-2.5 py-1.5">
                    <span
                      className={cn(
                        'inline-flex rounded-md px-1.5 py-0.5 text-[11px] font-medium',
                        pendiente
                          ? 'bg-accent/25 text-accent-foreground'
                          : 'bg-muted text-muted-foreground',
                      )}
                    >
                      {pendiente ? 'Pendiente' : factura.estado === 'cobrada' ? 'Cobrada' : factura.estado}
                    </span>
                  </td>
                </tr>
              )
            })}
          </tbody>
        </table>
      </div>
    </div>
  )
}
