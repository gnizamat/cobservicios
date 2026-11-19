import { useEffect, useMemo, useRef, useState } from 'react'
import { Button, Select } from '@/design-system/atoms'
import { PageHeader, PaginationBar } from '@/design-system/molecules'
import { AppShell } from '@/design-system/templates'
import {
  useCatalogoTarifas,
  useGenerarDeudasFijas,
  usePrediosDeudaFija,
  useTerritorioDeuda,
} from '@/modules/deudas/api'
import { formatMoney, MESES, mesLabel } from '@/modules/deudas/labels'
import type { PredioDeudaFija } from '@/modules/deudas/types'

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

function predioTexto(row: PredioDeudaFija) {
  return row.numero.trim() ? `${row.predio} · ${row.numero}` : row.predio
}

export function DeudasMensualesPage() {
  const hoy = new Date()
  const [sectorId, setSectorId] = useState('all')
  const [calleId, setCalleId] = useState('all')
  const [anioElegido, setAnioElegido] = useState<number | null>(null)
  const [mes, setMes] = useState(String(hoy.getMonth() + 1))
  const [servicioElegido, setServicioElegido] = useState<string | null>(null)
  const [picked, setPicked] = useState<string[]>([])
  const [aviso, setAviso] = useState<string | null>(null)
  const [page, setPage] = useState(1)
  const [pageSize, setPageSize] = useState(20)
  const territorio = useTerritorioDeuda()
  const catalogo = useCatalogoTarifas()
  const generar = useGenerarDeudasFijas()
  const anio =
    anioElegido ??
    catalogo.data?.tarifas.find((tarifa) => tarifa.activa)?.anio ??
    catalogo.data?.tarifas[0]?.anio ??
    hoy.getFullYear()
  const servicios = useMemo(() => {
    const seen = new Set<string>()
    return (catalogo.data?.costos ?? []).filter((costo) => {
      if (costo.categoria !== 'fijo' || costo.anio !== anio || seen.has(costo.tipo_servicio_id)) return false
      seen.add(costo.tipo_servicio_id)
      return true
    })
  }, [catalogo.data?.costos, anio])
  const servicioId = servicios.some((servicio) => servicio.tipo_servicio_id === servicioElegido)
    ? (servicioElegido ?? '')
    : (servicios[0]?.tipo_servicio_id ?? '')
  const servicio = servicios.find((item) => item.tipo_servicio_id === servicioId) ?? null
  const valor = Number(servicio?.monto ?? 0)
  const lista = usePrediosDeudaFija({
    anio,
    mes: Number(mes),
    tipoServicioId: valor > 0 ? servicioId : '',
    sectorId,
    calleId,
  })
  const rows = lista.data ?? []
  const totalPages = Math.max(1, Math.ceil(rows.length / pageSize))
  const safePage = Math.min(page, totalPages)
  const pageRows = rows.slice((safePage - 1) * pageSize, safePage * pageSize)
  const selected = new Set(picked.filter((id) => rows.some((row) => row.predio_id === id)))
  const pageSelected = pageRows.length > 0 && pageRows.every((row) => selected.has(row.predio_id))
  const allRef = useRef<HTMLInputElement>(null)

  useEffect(() => {
    if (allRef.current) {
      const someOnPage = pageRows.some((row) => selected.has(row.predio_id))
      allRef.current.indeterminate = someOnPage && !pageSelected
    }
  }, [pageRows, pageSelected, selected])

  useEffect(() => {
    if (page > totalPages) setPage(totalPages)
  }, [page, totalPages])

  const sectorOptions = useMemo(
    () => [
      { value: 'all', label: 'Todos los centros poblados' },
      ...(territorio.data?.sectores ?? []).map((sector) => ({ value: sector.id, label: sector.nombre })),
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
    const years = new Set((catalogo.data?.tarifas ?? []).map((tarifa) => tarifa.anio))
    years.add(anio)
    return [...years]
      .sort((left, right) => right - left)
      .map((year) => ({ value: String(year), label: String(year) }))
  }, [catalogo.data?.tarifas, anio])
  const servicioOptions = servicios.map((item) => ({
    value: item.tipo_servicio_id,
    label: item.servicio_nombre,
  }))
  const periodo = `${mesLabel(mes)} ${anio}`

  function limpiarSeleccion() {
    setPicked([])
    setAviso(null)
    setPage(1)
  }

  function togglePagina() {
    const ids = pageRows.map((row) => row.predio_id)
    setPicked((current) => {
      const next = new Set(current.filter((id) => rows.some((row) => row.predio_id === id)))
      if (pageSelected) {
        for (const id of ids) next.delete(id)
      } else {
        for (const id of ids) next.add(id)
      }
      return [...next]
    })
  }

  function generarSeleccion() {
    if (!servicioId || selected.size === 0) return
    setAviso(null)
    generar.mutate(
      {
        anio,
        mes: Number(mes),
        tipoServicioId: servicioId,
        predioIds: [...selected],
      },
      {
        onSuccess: (resultado) => {
          setPicked([])
          if (resultado.generadas === 0) {
            setAviso('Esos predios ya tienen esta deuda en el mes elegido.')
            return
          }
          setAviso(
            resultado.generadas === 1
              ? `Se generó 1 deuda de ${servicio?.servicio_nombre} por ${formatMoney(resultado.total)}.`
              : `Se generaron ${resultado.generadas} deudas de ${servicio?.servicio_nombre} por ${formatMoney(resultado.total)}.`,
          )
        },
      },
    )
  }

  return (
    <AppShell>
      <PageHeader
        title="Deudas mensuales"
        description="Elegí el centro poblado, la calle, el año, el mes y el servicio fijo. Los predios que ya tienen esa deuda en el periodo no aparecen, para no duplicarla."
        actions={
          <Button
            type="button"
            size="sm"
            disabled={selected.size === 0 || valor <= 0 || generar.isPending}
            onClick={generarSeleccion}
          >
            {generar.isPending ? 'Generando…' : `Generar deuda${selected.size > 0 ? ` (${selected.size})` : ''}`}
          </Button>
        }
      />

      <div className="mb-4 flex flex-col gap-3 rounded-lg border border-border/80 bg-card/60 p-3 sm:flex-row sm:flex-wrap sm:items-end">
        <ParamSelect
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
            limpiarSeleccion()
          }}
        />
        <ParamSelect
          label="Calle"
          value={calleOptions.some((option) => option.value === calleId) ? calleId : 'all'}
          options={calleOptions}
          onChange={(value) => {
            setCalleId(value)
            limpiarSeleccion()
          }}
        />
        <ParamSelect
          label="Año"
          value={String(anio)}
          options={anioOptions}
          onChange={(value) => {
            setAnioElegido(Number(value))
            limpiarSeleccion()
          }}
        />
        <ParamSelect
          label="Mes"
          value={mes}
          options={MESES.map((item) => ({ value: item.value, label: item.label }))}
          onChange={(value) => {
            setMes(value)
            limpiarSeleccion()
          }}
        />
        <ParamSelect
          label="Tipo de servicio"
          value={servicioId}
          options={
            catalogo.isLoading
              ? [{ value: '', label: 'Cargando servicios…' }]
              : servicioOptions.length
                ? servicioOptions
                : [{ value: '', label: 'Sin servicios fijos' }]
          }
          onChange={(value) => {
            setServicioElegido(value)
            limpiarSeleccion()
          }}
        />
        <div className="flex min-w-[8rem] flex-col gap-1 text-xs text-muted-foreground">
          Valor S/
          <div className="flex h-8 items-center rounded-md border border-border bg-background px-3 text-sm font-medium text-foreground">
            {servicio ? formatMoney(valor) : '—'}
          </div>
        </div>
      </div>

      <div className="mb-3 flex flex-wrap items-center justify-between gap-2">
        <p className="text-sm text-muted-foreground">
          {servicio
            ? `${rows.length} ${rows.length === 1 ? 'predio' : 'predios'} sin ${servicio.servicio_nombre} en ${periodo}`
            : 'Elegí un servicio fijo'}
          {selected.size > 0 ? ` · ${formatMoney(selected.size * valor)} seleccionados` : ''}
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
      {valor <= 0 && servicio ? (
        <p className="mb-3 text-sm text-muted-foreground">
          {servicio.servicio_nombre} no tiene un valor fijo en {anio}.
        </p>
      ) : null}

      {lista.isLoading ? <p className="text-sm text-muted-foreground">Cargando predios de {periodo}…</p> : null}
      {lista.isError ? (
        <p role="alert" className="text-sm text-destructive">
          {(lista.error as Error).message}
        </p>
      ) : null}
      {!lista.isLoading && !lista.isError && rows.length === 0 && valor > 0 ? (
        <div className="rounded-lg border border-dashed border-border px-4 py-8 text-center text-sm text-muted-foreground">
          No hay predios pendientes. Los que ya tienen {servicio?.servicio_nombre} en {periodo} no se muestran.
        </div>
      ) : null}
      {rows.length > 0 ? (
        <div>
          <div className="overflow-x-auto rounded-lg border border-border bg-card shadow-[var(--shadow-sm)]">
          <table className="min-w-full text-[13px]">
            <thead className="bg-secondary/80 text-left text-[11px] tracking-wide text-muted-foreground uppercase">
              <tr>
                <th className="w-10 px-2.5 py-2">
                  <input
                    ref={allRef}
                    type="checkbox"
                    aria-label="Seleccionar esta página"
                    checked={pageSelected}
                    onChange={togglePagina}
                  />
                </th>
                <th className="px-2.5 py-2 font-semibold whitespace-nowrap">Predio</th>
                <th className="px-2.5 py-2 font-semibold whitespace-nowrap">Usuario</th>
                <th className="px-2.5 py-2 font-semibold whitespace-nowrap">Centro poblado</th>
                <th className="px-2.5 py-2 font-semibold whitespace-nowrap">Calle</th>
              </tr>
            </thead>
            <tbody>
              {pageRows.map((row) => (
                <tr key={row.predio_id} className="border-t border-border">
                  <td className="px-2.5 py-1.5">
                    <input
                      type="checkbox"
                      aria-label={`Seleccionar ${row.predio}`}
                      checked={selected.has(row.predio_id)}
                      onChange={() => {
                        setPicked((current) => {
                          const next = new Set(current.filter((id) => rows.some((item) => item.predio_id === id)))
                          if (next.has(row.predio_id)) next.delete(row.predio_id)
                          else next.add(row.predio_id)
                          return [...next]
                        })
                      }}
                    />
                  </td>
                  <td className="px-2.5 py-1.5 whitespace-nowrap">{predioTexto(row)}</td>
                  <td className="px-2.5 py-1.5 whitespace-nowrap">{row.usuario}</td>
                  <td className="px-2.5 py-1.5 whitespace-nowrap text-muted-foreground">{row.sector || '—'}</td>
                  <td className="px-2.5 py-1.5 whitespace-nowrap text-muted-foreground">{row.calle || '—'}</td>
                </tr>
              ))}
            </tbody>
          </table>
          </div>
          <PaginationBar
            page={safePage}
            pageSize={pageSize}
            total={rows.length}
            onPageChange={setPage}
            onPageSizeChange={(size) => {
              setPageSize(size)
              setPage(1)
            }}
          />
        </div>
      ) : null}
    </AppShell>
  )
}
