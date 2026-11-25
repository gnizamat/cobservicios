import { useEffect, useMemo, useRef, useState } from 'react'
import { Button, Input, Select } from '@/design-system/atoms'
import { PageHeader, PaginationBar } from '@/design-system/molecules'
import { AppShell } from '@/design-system/templates'
import {
  useGenerarConvenioMedidor,
  usePrediosConvenioMedidor,
  useTerritorioDeuda,
} from '@/modules/deudas/api'
import { formatMoney, mesLabel } from '@/modules/deudas/labels'
import type { PredioDeudaFija } from '@/modules/deudas/types'

function hoyIso() {
  const hoy = new Date()
  const mes = String(hoy.getMonth() + 1).padStart(2, '0')
  const dia = String(hoy.getDate()).padStart(2, '0')
  return `${hoy.getFullYear()}-${mes}-${dia}`
}

function partesFecha(fecha: string) {
  const [anio, mes] = fecha.split('-')
  const year = Number(anio)
  const month = Number(mes)
  if (!Number.isInteger(year) || !Number.isInteger(month) || month < 1 || month > 12) {
    return null
  }
  return { anio: year, mes: month }
}

function repartirCuotas(monto: number, cuotas: number) {
  const cents = Math.round(monto * 100)
  if (cuotas < 1 || cents <= 0) return null
  const base = Math.floor(cents / cuotas)
  if (base <= 0) return null
  const resto = cents - base * cuotas
  return { cuota: base / 100, ultima: (base + resto) / 100 }
}

function predioTexto(row: PredioDeudaFija) {
  return row.numero.trim() ? `${row.predio} · ${row.numero}` : row.predio
}

function documentoTexto(dni: string, ruc: string) {
  if (dni && ruc) return `DNI ${dni} · RUC ${ruc}`
  return dni || ruc || '—'
}

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

export function DeudasConveniosPage() {
  const [sectorId, setSectorId] = useState('all')
  const [calleId, setCalleId] = useState('all')
  const [busqueda, setBusqueda] = useState('')
  const [consulta, setConsulta] = useState('')
  const [fecha, setFecha] = useState(hoyIso)
  const [cuotas, setCuotas] = useState('12')
  const [picked, setPicked] = useState<string[]>([])
  const [aviso, setAviso] = useState<string | null>(null)
  const [page, setPage] = useState(1)
  const [pageSize, setPageSize] = useState(20)
  const territorio = useTerritorioDeuda()
  const generar = useGenerarConvenioMedidor()
  const periodo = partesFecha(fecha)
  const nroCuotas = Math.min(36, Math.max(0, Number(cuotas) || 0))
  const lista = usePrediosConvenioMedidor({
    anio: periodo?.anio ?? 0,
    sectorId,
    calleId,
    busqueda: consulta,
  })
  const rows = lista.data?.predios ?? []
  const monto = lista.data?.monto ?? 0
  const reparto = repartirCuotas(monto, nroCuotas)
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

  useEffect(() => {
    const texto = busqueda.trim()
    const timer = window.setTimeout(() => setConsulta(texto), 250)
    return () => window.clearTimeout(timer)
  }, [busqueda])

  useEffect(() => {
    setPicked([])
    setAviso(null)
    setPage(1)
  }, [consulta])

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
    if (!periodo || !reparto || selected.size === 0) return
    setAviso(null)
    generar.mutate(
      { fecha, cuotas: nroCuotas, predioIds: [...selected] },
      {
        onSuccess: (resultado) => {
          setPicked([])
          if (resultado.generadas === 0) {
            setAviso('Esos predios ya tienen un convenio de este costo.')
            return
          }
          const cuotasTexto =
            resultado.cuota === resultado.ultima
              ? `${resultado.cuotas} cuotas de ${formatMoney(resultado.cuota)}`
              : `${resultado.cuotas - 1} cuotas de ${formatMoney(resultado.cuota)} y una última de ${formatMoney(resultado.ultima)}`
          setAviso(
            resultado.predios === 1
              ? `Se generó el convenio de ${resultado.servicio} en ${cuotasTexto}.`
              : `Se generaron ${resultado.predios} convenios de ${resultado.servicio} en ${cuotasTexto}.`,
          )
        },
      },
    )
  }

  const inicio = periodo ? `${mesLabel(periodo.mes)} ${periodo.anio}` : '—'
  const cuotaTexto = !reparto
    ? '—'
    : reparto.cuota === reparto.ultima
      ? formatMoney(reparto.cuota)
      : `${formatMoney(reparto.cuota)} · última ${formatMoney(reparto.ultima)}`

  return (
    <AppShell>
      <PageHeader
        title="Deudas convenios"
        description="El costo del medidor se parte en cuotas fijas desde la fecha del convenio. Cada cuota queda como deuda del mes correspondiente."
        actions={
          <Button
            type="button"
            size="sm"
            disabled={selected.size === 0 || !reparto || generar.isPending}
            onClick={generarSeleccion}
          >
            {generar.isPending
              ? 'Generando…'
              : `Generar convenio${selected.size > 0 ? ` (${selected.size})` : ''}`}
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
        <label className="flex min-w-[14rem] flex-1 flex-col gap-1 text-xs text-muted-foreground">
          Buscar
          <Input
            aria-label="Buscar por DNI, apellidos o nombres"
            value={busqueda}
            placeholder="DNI, apellidos o nombres"
            className="h-8 text-sm"
            onChange={(event) => setBusqueda(event.target.value)}
            onKeyDown={(event) => {
              if (event.key !== 'Enter') return
              event.preventDefault()
              setConsulta(busqueda.trim())
              limpiarSeleccion()
            }}
          />
        </label>
        <label className="flex min-w-[10rem] flex-col gap-1 text-xs text-muted-foreground">
          Fecha del convenio
          <Input
            aria-label="Fecha del convenio"
            type="date"
            value={fecha}
            className="h-8 text-sm"
            onChange={(event) => {
              setFecha(event.target.value)
              limpiarSeleccion()
            }}
          />
        </label>
        <label className="flex w-28 flex-col gap-1 text-xs text-muted-foreground">
          N° de cuotas
          <Input
            aria-label="Número de cuotas"
            inputMode="numeric"
            value={cuotas}
            className="h-8 text-sm"
            onChange={(event) => {
              const digitos = event.target.value.replace(/\D/g, '').slice(0, 2)
              setCuotas(digitos)
            }}
          />
        </label>
        <div className="flex min-w-[8rem] flex-col gap-1 text-xs text-muted-foreground">
          Costo S/
          <div className="flex h-8 items-center rounded-md border border-border bg-background px-3 text-sm font-medium text-foreground">
            {lista.data ? formatMoney(monto) : '—'}
          </div>
        </div>
        <div className="flex min-w-[8rem] flex-col gap-1 text-xs text-muted-foreground">
          Valor de cuota
          <div className="flex h-8 items-center rounded-md border border-border bg-background px-3 text-sm font-medium text-foreground">
            {cuotaTexto}
          </div>
        </div>
      </div>

      <div className="mb-3 flex flex-wrap items-center justify-between gap-2">
        <p className="text-sm text-muted-foreground">
          {lista.data
            ? `${rows.length} ${rows.length === 1 ? 'predio' : 'predios'} sin convenio de ${lista.data.servicio}`
            : 'Cargando el costo del medidor…'}
          {periodo ? ` · inicio ${inicio}` : ''}
          {selected.size > 0 && monto > 0 ? ` · ${formatMoney(selected.size * monto)} seleccionados` : ''}
        </p>
        <Button
          type="button"
          size="sm"
          variant="outline"
          onClick={() => {
            setConsulta(busqueda.trim())
            limpiarSeleccion()
          }}
        >
          Buscar
        </Button>
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
      {nroCuotas < 1 || nroCuotas > 36 ? (
        <p className="mb-3 text-sm text-muted-foreground">Las cuotas van de 1 a 36 meses.</p>
      ) : null}

      {lista.isLoading ? <p className="text-sm text-muted-foreground">Cargando predios…</p> : null}
      {lista.isError ? (
        <p role="alert" className="text-sm text-destructive">
          {(lista.error as Error).message}
        </p>
      ) : null}
      {!lista.isLoading && !lista.isError && rows.length === 0 && lista.data ? (
        <div className="rounded-lg border border-dashed border-border px-4 py-8 text-center text-sm text-muted-foreground">
          {consulta
            ? 'Ningún predio coincide con el DNI, los apellidos o los nombres buscados.'
            : `No hay predios pendientes. Los que ya tienen un convenio de ${lista.data.servicio} no se muestran.`}
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
                  <th className="px-2.5 py-2 font-semibold whitespace-nowrap">DNI / RUC</th>
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
                            const next = new Set(
                              current.filter((id) => rows.some((item) => item.predio_id === id)),
                            )
                            if (next.has(row.predio_id)) next.delete(row.predio_id)
                            else next.add(row.predio_id)
                            return [...next]
                          })
                        }}
                      />
                    </td>
                    <td className="px-2.5 py-1.5 whitespace-nowrap">{predioTexto(row)}</td>
                    <td className="px-2.5 py-1.5 whitespace-nowrap tabular-nums">{documentoTexto(row.dni, row.ruc)}</td>
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
