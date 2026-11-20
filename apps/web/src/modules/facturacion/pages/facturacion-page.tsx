import { useMemo, useState } from 'react'
import { Printer, Trash2 } from 'lucide-react'
import { Button, Icon, Select } from '@/design-system/atoms'
import { PageHeader } from '@/design-system/molecules'
import { AppShell } from '@/design-system/templates'
import {
  useDeudasAFacturar,
  useFacturacionesGeneradas,
  useGenerarFacturacion,
  useTarifasFacturacion,
  useTerritorioFacturacion,
} from '@/modules/facturacion/api'
import { EliminarFacturacionDialog } from '@/modules/facturacion/components/eliminar-facturacion-dialog'
import { ReciboDialog } from '@/modules/facturacion/components/recibo-dialog'
import { formatMoney, MESES, mesLabel, predioFacturaLabel } from '@/modules/facturacion/labels'
import type { DeudaAFacturar, FacturacionGenerada } from '@/modules/facturacion/types'
import { cn } from '@/shared/lib/utils'

function ParamSelect({
  label,
  value,
  onChange,
  options,
}: {
  label: string
  value: string
  onChange: (value: string) => void
  options: Array<{ value: string; label: string }>
}) {
  return (
    <label className="flex min-w-[11rem] flex-1 flex-col gap-1 text-xs text-muted-foreground">
      {label}
      <Select
        aria-label={label}
        value={value}
        onChange={(event) => onChange(event.target.value)}
        className="h-8 text-sm text-foreground"
      >
        {options.map((option) => (
          <option key={option.value} value={option.value}>
            {option.label}
          </option>
        ))}
      </Select>
    </label>
  )
}

function VistaButton({
  active,
  children,
  onClick,
}: {
  active: boolean
  children: string
  onClick: () => void
}) {
  return (
    <button
      type="button"
      aria-pressed={active}
      onClick={onClick}
      className={cn(
        'h-8 rounded-md px-3 text-sm',
        active ? 'bg-primary text-primary-foreground' : 'text-muted-foreground hover:bg-secondary',
      )}
    >
      {children}
    </button>
  )
}

export function FacturacionPage() {
  const hoy = new Date()
  const [sectorId, setSectorId] = useState('all')
  const [calleId, setCalleId] = useState('all')
  const [anioElegido, setAnioElegido] = useState<number | null>(null)
  const [mes, setMes] = useState(String(hoy.getMonth() + 1))
  const [vista, setVista] = useState<'pendientes' | 'generadas'>('pendientes')
  const [picked, setPicked] = useState<string[] | null>(null)
  const [aviso, setAviso] = useState<string | null>(null)
  const [reciboId, setReciboId] = useState<string | null>(null)
  const [eliminar, setEliminar] = useState<FacturacionGenerada | null>(null)
  const territorio = useTerritorioFacturacion()
  const tarifas = useTarifasFacturacion()
  const anio =
    anioElegido ??
    tarifas.data?.find((tarifa) => tarifa.activa)?.anio ??
    tarifas.data?.[0]?.anio ??
    hoy.getFullYear()
  const filtros = { anio, mes: Number(mes), sectorId, calleId }
  const pendientes = useDeudasAFacturar(filtros)
  const generadas = useFacturacionesGeneradas(filtros)
  const generar = useGenerarFacturacion()
  const rows = pendientes.data ?? []
  const selectedIds = picked ?? rows.map((row) => row.predio_id)
  const selected = new Set(selectedIds)
  const allSelected = rows.length > 0 && rows.every((row) => selected.has(row.predio_id))

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
  const anioOptions = useMemo(() => {
    const years = new Set((tarifas.data ?? []).map((tarifa) => tarifa.anio))
    years.add(anio)
    return [...years]
      .sort((left, right) => right - left)
      .map((year) => ({ value: String(year), label: String(year) }))
  }, [tarifas.data, anio])

  const periodo = `${mesLabel(mes)} ${anio}`
  const montoSeleccionado = rows
    .filter((row) => selected.has(row.predio_id))
    .reduce((sum, row) => sum + row.monto, 0)

  function cambiarSector(value: string) {
    setSectorId(value)
    setCalleId((current) => {
      if (current === 'all' || value === 'all') return current
      const calle = territorio.data?.calles.find((item) => item.id === current)
      return calle?.sector_id === value ? current : 'all'
    })
    setPicked(null)
    setAviso(null)
  }

  function generarSeleccion() {
    setAviso(null)
    generar.mutate(
      { anio, mes: Number(mes), predioIds: [...selected] },
      {
        onSuccess: (resultado) => {
          setPicked(null)
          if (resultado.generadas === 0) {
            setAviso('Esos predios no tienen deudas pendientes de facturar en ese mes.')
            return
          }
          setVista('generadas')
          setAviso(
            resultado.generadas === 1
              ? `Se generó 1 facturación por ${formatMoney(resultado.monto)}.`
              : `Se generaron ${resultado.generadas} facturaciones por ${formatMoney(resultado.monto)}.`,
          )
        },
      },
    )
  }

  return (
    <AppShell>
      <PageHeader
        title="Facturación"
        description="Elegí el centro poblado, la calle, el año y el mes. Cada facturación junta todas las deudas registradas de ese mes en el predio."
        actions={
          <Button
            type="button"
            size="sm"
            disabled={vista !== 'pendientes' || selected.size === 0 || generar.isPending}
            onClick={generarSeleccion}
          >
            {generar.isPending
              ? 'Generando…'
              : `Generar facturación${selected.size > 0 && vista === 'pendientes' ? ` (${selected.size})` : ''}`}
          </Button>
        }
      />

      <div className="mb-4 flex flex-col gap-3 rounded-lg border border-border/80 bg-card/60 p-3 sm:flex-row sm:flex-wrap sm:items-end">
        <ParamSelect label="Centro poblado" value={sectorId} options={sectorOptions} onChange={cambiarSector} />
        <ParamSelect
          label="Calle"
          value={calleOptions.some((option) => option.value === calleId) ? calleId : 'all'}
          options={calleOptions}
          onChange={(value) => {
            setCalleId(value)
            setPicked(null)
            setAviso(null)
          }}
        />
        <ParamSelect
          label="Año"
          value={String(anio)}
          options={anioOptions}
          onChange={(value) => {
            setAnioElegido(Number(value))
            setPicked(null)
            setAviso(null)
          }}
        />
        <ParamSelect
          label="Mes"
          value={mes}
          options={MESES.map((item) => ({ value: item.value, label: item.label }))}
          onChange={(value) => {
            setMes(value)
            setPicked(null)
            setAviso(null)
          }}
        />
      </div>

      <div className="mb-3 flex flex-wrap items-center justify-between gap-2">
        <div className="flex rounded-lg bg-secondary/60 p-1">
          <VistaButton active={vista === 'pendientes'} onClick={() => setVista('pendientes')}>
            Por facturar
          </VistaButton>
          <VistaButton active={vista === 'generadas'} onClick={() => setVista('generadas')}>
            Facturaciones generadas
          </VistaButton>
        </div>
        <p className="text-sm text-muted-foreground">
          {vista === 'pendientes'
            ? `${rows.length} ${rows.length === 1 ? 'predio' : 'predios'} · ${formatMoney(montoSeleccionado)} seleccionados`
            : `${generadas.data?.length ?? 0} ${generadas.data?.length === 1 ? 'facturación' : 'facturaciones'} de ${periodo}`}
        </p>
      </div>

      {aviso ? (
        <p className="mb-3 text-sm text-foreground" role="status">
          {aviso}
        </p>
      ) : null}
      {generar.isError ? (
        <p className="mb-3 text-sm text-destructive" role="alert">
          {(generar.error as Error).message}
        </p>
      ) : null}

      {vista === 'pendientes' ? (
        <PendientesTable
          loading={pendientes.isLoading}
          error={pendientes.isError ? (pendientes.error as Error).message : null}
          rows={rows}
          periodo={periodo}
          selected={selected}
          allSelected={allSelected}
          onToggleAll={() => setPicked(allSelected ? [] : rows.map((row) => row.predio_id))}
          onToggle={(id) => {
            const next = new Set(selected)
            if (next.has(id)) next.delete(id)
            else next.add(id)
            setPicked([...next])
          }}
        />
      ) : (
        <GeneradasTable
          loading={generadas.isLoading}
          error={generadas.isError ? (generadas.error as Error).message : null}
          rows={generadas.data ?? []}
          periodo={periodo}
          onImprimir={setReciboId}
          onEliminar={setEliminar}
        />
      )}
      {reciboId ? <ReciboDialog id={reciboId} onClose={() => setReciboId(null)} /> : null}
      {eliminar ? (
        <EliminarFacturacionDialog
          factura={eliminar}
          onClose={() => setEliminar(null)}
          onEliminada={(mensaje) => {
            setAviso(mensaje)
            setEliminar(null)
          }}
        />
      ) : null}
    </AppShell>
  )
}

function PendientesTable({
  loading,
  error,
  rows,
  periodo,
  selected,
  allSelected,
  onToggleAll,
  onToggle,
}: {
  loading: boolean
  error: string | null
  rows: DeudaAFacturar[]
  periodo: string
  selected: Set<string>
  allSelected: boolean
  onToggleAll: () => void
  onToggle: (id: string) => void
}) {
  if (loading) return <p className="text-sm text-muted-foreground">Cargando deudas de {periodo}…</p>
  if (error) {
    return (
      <p role="alert" className="text-sm text-destructive">
        {error}
      </p>
    )
  }
  if (rows.length === 0) {
    return (
      <div className="rounded-lg border border-dashed border-border px-4 py-8 text-center text-sm text-muted-foreground">
        No hay deudas pendientes de facturar en {periodo} para ese centro y esa calle.
      </div>
    )
  }

  return (
    <div className="overflow-hidden rounded-lg border border-border bg-card shadow-[var(--shadow-sm)]">
      <div className="overflow-x-auto">
        <table className="min-w-full text-[13px]">
          <thead className="bg-secondary/50 text-left text-[11px] tracking-wide text-muted-foreground uppercase">
            <tr>
              <th className="w-10 px-2.5 py-2">
                <input
                  type="checkbox"
                  aria-label="Seleccionar todos"
                  checked={allSelected}
                  onChange={onToggleAll}
                />
              </th>
              <th className="px-2.5 py-2 font-semibold">Predio</th>
              <th className="px-2.5 py-2 font-semibold">Usuario</th>
              <th className="px-2.5 py-2 font-semibold">Calle</th>
              <th className="px-2.5 py-2 text-right font-semibold">Deudas</th>
              <th className="px-2.5 py-2 text-right font-semibold">Monto</th>
            </tr>
          </thead>
          <tbody>
            {rows.map((row) => (
              <tr key={row.predio_id} className="border-t border-border">
                <td className="px-2.5 py-1.5">
                  <input
                    type="checkbox"
                    aria-label={`Seleccionar ${row.predio}`}
                    checked={selected.has(row.predio_id)}
                    onChange={() => onToggle(row.predio_id)}
                  />
                </td>
                <td className="px-2.5 py-1.5">{predioFacturaLabel(row.predio, row.numero)}</td>
                <td className="px-2.5 py-1.5">{row.usuario}</td>
                <td className="px-2.5 py-1.5 text-muted-foreground">{row.calle || '—'}</td>
                <td className="px-2.5 py-1.5 text-right">{row.deudas}</td>
                <td className="px-2.5 py-1.5 text-right">{formatMoney(row.monto)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  )
}

function GeneradasTable({
  loading,
  error,
  rows,
  periodo,
  onImprimir,
  onEliminar,
}: {
  loading: boolean
  error: string | null
  rows: FacturacionGenerada[]
  periodo: string
  onImprimir: (id: string) => void
  onEliminar: (factura: FacturacionGenerada) => void
}) {
  if (loading) return <p className="text-sm text-muted-foreground">Cargando facturaciones de {periodo}…</p>
  if (error) {
    return (
      <p role="alert" className="text-sm text-destructive">
        {error}
      </p>
    )
  }
  if (rows.length === 0) {
    return (
      <div className="rounded-lg border border-dashed border-border px-4 py-8 text-center text-sm text-muted-foreground">
        Todavía no hay facturaciones generadas en {periodo} para ese centro y esa calle.
      </div>
    )
  }

  return (
    <div className="overflow-hidden rounded-lg border border-border bg-card shadow-[var(--shadow-sm)]">
      <div className="overflow-x-auto">
        <table className="min-w-full text-[13px]">
          <thead className="bg-secondary/50 text-left text-[11px] tracking-wide text-muted-foreground uppercase">
            <tr>
              <th className="px-2.5 py-2 font-semibold">Número</th>
              <th className="px-2.5 py-2 font-semibold">Predio</th>
              <th className="px-2.5 py-2 font-semibold">Usuario</th>
              <th className="px-2.5 py-2 font-semibold">Calle</th>
              <th className="px-2.5 py-2 text-right font-semibold">Deudas</th>
              <th className="px-2.5 py-2 text-right font-semibold">Monto</th>
              <th className="px-2.5 py-2 font-semibold">Fecha</th>
              <th className="px-2.5 py-2 font-semibold">Acciones</th>
            </tr>
          </thead>
          <tbody>
            {rows.map((row) => (
              <tr key={row.id} className="border-t border-border">
                <td className="px-2.5 py-1.5 font-medium">{row.numero}</td>
                <td className="px-2.5 py-1.5">{predioFacturaLabel(row.predio, row.numero_predio)}</td>
                <td className="px-2.5 py-1.5">{row.usuario}</td>
                <td className="px-2.5 py-1.5 text-muted-foreground">{row.calle || '—'}</td>
                <td className="px-2.5 py-1.5 text-right">{row.deudas}</td>
                <td className="px-2.5 py-1.5 text-right">{formatMoney(row.monto)}</td>
                <td className="px-2.5 py-1.5">{row.fecha}</td>
                <td className="px-2.5 py-1.5">
                  <span className="flex flex-wrap gap-1">
                    <Button
                      type="button"
                      size="sm"
                      variant="outline"
                      aria-label={`Imprimir recibo de ${row.numero}`}
                      onClick={() => onImprimir(row.id)}
                    >
                      <Icon icon={Printer} size={14} />
                      Imprimir
                    </Button>
                    <Button
                      type="button"
                      size="sm"
                      variant="outline"
                      className="text-destructive"
                      disabled={row.tienePagos}
                      aria-label={
                        row.tienePagos
                          ? `No se puede eliminar ${row.numero} porque tiene pagos`
                          : `Eliminar facturación ${row.numero}`
                      }
                      title={
                        row.tienePagos
                          ? 'No se puede eliminar: las deudas están vinculadas a pagos'
                          : 'Eliminar facturación'
                      }
                      onClick={() => onEliminar(row)}
                    >
                      <Icon icon={Trash2} size={14} />
                      Eliminar
                    </Button>
                  </span>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  )
}
