import { useMemo, useState } from 'react'
import { Printer, Trash2 } from 'lucide-react'
import { Button, Icon, Input } from '@/design-system/atoms'
import { FilterSelect, ListFilters, PageHeader } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import { AppShell } from '@/design-system/templates'
import { useCajas, usePagos, useTerritorioCobranza } from '@/modules/cobranza/api'
import type { PagoListado } from '@/modules/cobranza/api'
import { AnularPagoDialog } from '@/modules/cobranza/components/anular-pago-dialog'
import { ReciboPagoDialog } from '@/modules/cobranza/components/recibo-pago-dialog'
import {
  etiquetaCaja,
  fechaHoy,
  formatFecha,
  formatMoney,
  predioLabel,
  tipoPagoLabel,
} from '@/modules/cobranza/labels'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'
import { cn } from '@/shared/lib/utils'

function inicioDeMes() {
  return `${fechaHoy().slice(0, 8)}01`
}

export function PagosListadoPage() {
  return (
    <AppShell>
      <PageHeader
        title="Listado de pagos"
        description="Pagos del periodo. Filtrá por centro poblado, caja y fechas. Imprimí el recibo o eliminá el pago con tu contraseña."
      />
      <PagosListado />
    </AppShell>
  )
}

export function PagosListado() {
  const [searchInput, setSearchInput] = useState('')
  const search = useDebouncedValue(searchInput.trim(), 300)
  const [sectorId, setSectorId] = useState('all')
  const [cajaId, setCajaId] = useState('all')
  const [desde, setDesde] = useState(inicioDeMes)
  const [hasta, setHasta] = useState(fechaHoy)
  const [aviso, setAviso] = useState<string | null>(null)
  const [reciboId, setReciboId] = useState<string | null>(null)
  const [anular, setAnular] = useState<PagoListado | null>(null)
  const territorio = useTerritorioCobranza()
  const cajas = useCajas()
  const pagos = usePagos({ sectorId, cajaId, desde, hasta, search })
  const rows = pagos.data ?? []
  const vigentes = rows.filter((row) => !row.anulado)
  const total = vigentes.reduce((sum, row) => sum + row.monto, 0)

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
  const cajaOptions = useMemo(
    () => [
      { value: 'all', label: 'Todas las cajas' },
      ...(cajas.data ?? []).map((caja) => ({
        value: caja.id,
        label: etiquetaCaja(caja.nombre, caja.sector, caja.usuario),
      })),
    ],
    [cajas.data],
  )

  const filtrosActivos =
    Boolean(searchInput.trim()) ||
    sectorId !== 'all' ||
    cajaId !== 'all' ||
    desde !== inicioDeMes() ||
    hasta !== fechaHoy()

  return (
    <>
      <ListFilters
        liveSearch
        search={searchInput}
        onSearchChange={setSearchInput}
        searchPlaceholder="Recibo, nombre, DNI, RUC o predio…"
        hasActiveFilters={filtrosActivos}
        onReset={() => {
          setSearchInput('')
          setSectorId('all')
          setCajaId('all')
          setDesde(inicioDeMes())
          setHasta(fechaHoy())
          setAviso(null)
        }}
        filters={
          <>
            <FilterSelect
              label="Centro poblado"
              value={sectorId}
              options={sectorOptions}
              onChange={setSectorId}
            />
            <FilterSelect
              label="Caja"
              value={cajaOptions.some((option) => option.value === cajaId) ? cajaId : 'all'}
              options={cajaOptions}
              onChange={setCajaId}
            />
            <label className="flex items-center gap-1.5 text-xs text-muted-foreground">
              Desde
              <Input
                type="date"
                value={desde}
                max={hasta || undefined}
                onChange={(event) => setDesde(event.target.value)}
                aria-label="Fecha desde"
                className="h-8 w-[9.5rem] text-sm text-foreground"
              />
            </label>
            <label className="flex items-center gap-1.5 text-xs text-muted-foreground">
              Hasta
              <Input
                type="date"
                value={hasta}
                min={desde || undefined}
                onChange={(event) => setHasta(event.target.value)}
                aria-label="Fecha hasta"
                className="h-8 w-[9.5rem] text-sm text-foreground"
              />
            </label>
          </>
        }
      />

      {aviso ? (
        <p className="mb-3 text-sm text-foreground" role="status">
          {aviso}
        </p>
      ) : null}

      {pagos.isLoading ? (
        <p className="text-sm text-muted-foreground">Cargando pagos…</p>
      ) : pagos.isError ? (
        <p role="alert" className="text-sm text-destructive">
          {(pagos.error as Error).message}
        </p>
      ) : (
        <>
          <p className="mb-2 text-sm text-muted-foreground">
            {rows.length === 1 ? '1 pago' : `${rows.length} pagos`}
            {' · '}
            {formatMoney(total)} vigentes
          </p>
          <DataTable
            columns={[
              { key: 'numero', header: 'Recibo' },
              { key: 'fecha', header: 'Fecha' },
              { key: 'usuario', header: 'Usuario' },
              { key: 'documento', header: 'Documento' },
              { key: 'predio', header: 'Predio' },
              { key: 'sector', header: 'Centro poblado' },
              { key: 'caja', header: 'Caja' },
              { key: 'tipo', header: 'Tipo' },
              { key: 'monto', header: 'Monto', className: 'text-right' },
              { key: 'estado', header: 'Estado' },
              { key: 'acciones', header: 'Acciones', className: 'text-right' },
            ]}
            rows={rows}
            rowKey={(row) => row.id}
            emptyMessage="No hay pagos para ese centro poblado, esa caja y ese rango de fechas."
            renderCell={(row, key) => renderPago(row, key, setReciboId, setAnular)}
          />
        </>
      )}

      {reciboId ? <ReciboPagoDialog id={reciboId} onClose={() => setReciboId(null)} /> : null}
      {anular ? (
        <AnularPagoDialog
          pago={anular}
          onClose={() => setAnular(null)}
          onAnulado={(mensaje) => {
            setAviso(mensaje)
            setAnular(null)
          }}
        />
      ) : null}
    </>
  )
}

function renderPago(
  row: PagoListado,
  key: string,
  onImprimir: (id: string) => void,
  onEliminar: (pago: PagoListado) => void,
) {
  if (key === 'numero') return <span className="font-medium">{row.numero}</span>
  if (key === 'fecha') return formatFecha(row.fecha)
  if (key === 'usuario') return row.usuario || '—'
  if (key === 'documento') return row.documento || '—'
  if (key === 'predio') return predioLabel(row.predio, row.numeroPredio)
  if (key === 'sector') return row.sector || '—'
  if (key === 'caja') return row.caja || '—'
  if (key === 'tipo') return tipoPagoLabel(row.tipoPago)
  if (key === 'monto') {
    return <span className="block text-right tabular-nums">{formatMoney(row.monto)}</span>
  }
  if (key === 'estado') {
    return (
      <span className="block">
        <span
          className={cn(
            'inline-flex rounded-md px-1.5 py-0.5 text-[11px] font-medium',
            row.anulado ? 'bg-muted text-muted-foreground' : 'bg-accent/25 text-accent-foreground',
          )}
        >
          {row.anulado ? 'Anulado' : 'Vigente'}
        </span>
        {row.anulado && row.anuladoPor ? (
          <span className="mt-1 block text-[11px] text-muted-foreground">
            {row.anuladoPor}
            {row.motivoAnulacion ? ` · ${row.motivoAnulacion}` : ''}
          </span>
        ) : null}
      </span>
    )
  }
  if (key === 'acciones') {
    return (
      <span className="flex justify-end gap-1">
        <Button
          type="button"
          size="sm"
          variant="ghost"
          className="h-7 px-2"
          disabled={row.anulado}
          aria-label={`Imprimir recibo ${row.numero}`}
          title={row.anulado ? 'El recibo anulado no se imprime' : 'Imprimir recibo'}
          onClick={() => onImprimir(row.id)}
        >
          <Icon icon={Printer} size={14} />
        </Button>
        <Button
          type="button"
          size="sm"
          variant="ghost"
          className="h-7 px-2 text-destructive"
          disabled={row.anulado}
          aria-label={`Eliminar pago ${row.numero}`}
          title={row.anulado ? 'Este pago ya fue eliminado' : 'Eliminar pago'}
          onClick={() => onEliminar(row)}
        >
          <Icon icon={Trash2} size={14} />
        </Button>
      </span>
    )
  }
  return null
}
