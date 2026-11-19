import { LoaderCircle } from 'lucide-react'
import { useEffect, useMemo, useState } from 'react'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { PageHeader, PaginationBar } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import { AppShell } from '@/design-system/templates'
import type { PadronItem } from '@/modules/asambleas/api/asambleas-api'
import {
  useAsambleas,
  useGenerarPadron,
  useMarcarAsistencia,
  usePadron,
  useSectoresAsamblea,
} from '@/modules/asambleas/api/use-asambleas'
import { useOrganizacion } from '@/modules/configuracion/api'
import {
  descargarExcel,
  descargarPdf,
  imprimirReporte,
  type ReporteTabla,
} from '@/modules/asambleas/lib/asistencia-reportes'
import { cn } from '@/shared/lib/utils'

type Vista = 'control' | 'padron' | 'asistentes' | 'resumen'

const vistas: Array<{ id: Vista; label: string }> = [
  { id: 'control', label: 'Control' },
  { id: 'padron', label: 'Padrón de hábiles' },
  { id: 'asistentes', label: 'Asistentes' },
  { id: 'resumen', label: 'Resumen por calle' },
]

function fechaCorta(iso: string) {
  const [anio, mes, dia] = iso.slice(0, 10).split('-')
  return `${dia}/${mes}/${anio}`
}

function porcentaje(parte: number, total: number) {
  if (total === 0) return '0,00'
  return ((parte / total) * 100).toLocaleString('es-PE', {
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
  })
}

function normalizar(valor: string) {
  return valor
    .trim()
    .toLocaleLowerCase('es')
    .normalize('NFD')
    .replace(/\p{M}/gu, '')
}

function incluye(valor: string, busqueda: string) {
  if (!busqueda) return true
  return normalizar(valor).includes(normalizar(busqueda))
}

function predioTexto(predio: PadronItem['predio']) {
  if (!predio) return '—'
  return [predio.nombre, predio.numero, predio.manzana && `Mz ${predio.manzana}`, predio.lote && `Lt ${predio.lote}`]
    .filter(Boolean)
    .join(' ')
}

export function AsistenciaPage({ embedded = false }: { embedded?: boolean }) {
  const asambleas = useAsambleas()
  const sectores = useSectoresAsamblea()
  const organizacion = useOrganizacion()
  const [sectorId, setSectorId] = useState('all')
  const [asambleaId, setAsambleaId] = useState('')
  const [calle, setCalle] = useState('all')
  const [dni, setDni] = useState('')
  const [nombres, setNombres] = useState('')
  const [apellidos, setApellidos] = useState('')
  const [correlativo, setCorrelativo] = useState('')
  const [vista, setVista] = useState<Vista>('control')
  const [page, setPage] = useState(1)
  const pageSize = 20

  const asambleasVisibles = useMemo(() => {
    const lista = asambleas.data ?? []
    if (sectorId === 'all') return lista
    return lista.filter((item) => item.sector?.id === sectorId)
  }, [asambleas.data, sectorId])

  const asamblea =
    asambleasVisibles.find((item) => item.id === asambleaId) ?? asambleasVisibles[0] ?? null

  useEffect(() => {
    const siguiente = asamblea?.id ?? ''
    if (asambleaId !== siguiente) setAsambleaId(siguiente)
  }, [asamblea, asambleaId])
  const padron = usePadron(asamblea?.id ?? null)
  const marcar = useMarcarAsistencia(asamblea?.id ?? null)
  const generar = useGenerarPadron()

  const habiles = useMemo(
    () => (padron.data ?? []).filter((row) => row.habil),
    [padron.data],
  )
  const calles = useMemo(
    () => [...new Set(habiles.map((row) => row.calle))].sort((a, b) => a.localeCompare(b, 'es')),
    [habiles],
  )

  const filtrados = useMemo(() => {
    const dniBusqueda = dni.trim()
    const nombresBusqueda = nombres.trim()
    const apellidosBusqueda = apellidos.trim()
    const correlativoBusqueda = correlativo.trim()
    return habiles.filter((row) => {
      if (calle !== 'all' && row.calle !== calle) return false
      if (
        dniBusqueda &&
        !incluye(row.dni, dniBusqueda) &&
        !incluye(row.documento, dniBusqueda)
      ) {
        return false
      }
      if (nombresBusqueda && !incluye(row.nombres, nombresBusqueda)) return false
      if (apellidosBusqueda && !incluye(row.apellidos, apellidosBusqueda)) return false
      if (correlativoBusqueda && String(row.correlativo) !== correlativoBusqueda) return false
      return true
    })
  }, [apellidos, calle, correlativo, dni, habiles, nombres])

  const asistentesFiltrados = filtrados.filter((row) => row.asistencia)
  const lista = vista === 'asistentes' ? asistentesFiltrados : filtrados
  const totalHabiles = habiles.length
  const totalAsistentes = habiles.filter((row) => row.asistencia).length
  const centro = asamblea?.sector?.nombre ?? habiles[0]?.sectorNombre ?? 'Centro poblado'

  const resumen = useMemo(() => {
    const grupos = new Map<string, { habiles: number; asistentes: number }>()
    for (const row of calle === 'all' ? habiles : habiles.filter((item) => item.calle === calle)) {
      const actual = grupos.get(row.calle) ?? { habiles: 0, asistentes: 0 }
      actual.habiles += 1
      if (row.asistencia) actual.asistentes += 1
      grupos.set(row.calle, actual)
    }
    return [...grupos.entries()]
      .sort(([a], [b]) => a.localeCompare(b, 'es'))
      .map(([nombreCalle, totales]) => ({
        centro,
        calle: nombreCalle,
        ...totales,
      }))
  }, [calle, centro, habiles])

  const pagina = lista.slice((page - 1) * pageSize, page * pageSize)

  useEffect(() => {
    if (calle !== 'all' && !calles.includes(calle)) setCalle('all')
  }, [calle, calles])

  useEffect(() => {
    setPage(1)
  }, [asambleaId, sectorId, calle, dni, nombres, apellidos, correlativo, vista])

  function limpiar() {
    setCalle('all')
    setDni('')
    setNombres('')
    setApellidos('')
    setCorrelativo('')
  }

  function reporteActual(): ReporteTabla {
    const encabezado = [
      organizacion.data?.nombre ?? 'JASS',
      asamblea
        ? `${asamblea.descripcion} · ${asamblea.anio} · ${fechaCorta(asamblea.fecha)} · ${centro}`
        : centro,
      `Hábiles: ${totalHabiles} · Asistentes: ${totalAsistentes} · Asistencia: ${porcentaje(totalAsistentes, totalHabiles)} %`,
    ]
    if (vista === 'resumen') {
      return {
        titulo: 'Resumen de asistencia por centro poblado y calle',
        lineas: encabezado,
        columnas: ['Centro poblado', 'Calle', 'Hábiles', 'Asistentes', '% asistencia'],
        filas: resumen.map((fila) => [
          fila.centro,
          fila.calle,
          String(fila.habiles),
          String(fila.asistentes),
          `${porcentaje(fila.asistentes, fila.habiles)} %`,
        ]),
        nombreArchivo: 'resumen-asistencia',
      }
    }
    const titulo =
      vista === 'asistentes' ? 'Usuarios asistentes a la asamblea' : 'Padrón de usuarios hábiles'
    return {
      titulo,
      lineas: encabezado,
      columnas: ['N°', 'Documento', 'Usuario', 'Calle', 'Predio', 'Asistencia'],
      filas: lista.map((row) => [
        String(row.correlativo),
        row.documento || '—',
        row.nombre,
        row.calle,
        predioTexto(row.predio),
        row.asistencia ? 'Asistió' : 'No asistió',
      ]),
      nombreArchivo: vista === 'asistentes' ? 'usuarios-asistentes' : 'padron-habiles',
    }
  }

  const contenido = (
    <>
      {embedded ? null : (
        <PageHeader
          title="Asistencia de usuarios"
          description="Usuarios hábiles, sin deuda de tarifa ni aporte económico. Marcá quién asistió y sacá el padrón, la lista de asistentes y el resumen por calle."
        />
      )}

      <div className="mb-4 grid gap-3 sm:grid-cols-2 lg:grid-cols-3">
        <Dato etiqueta="N° hábiles" valor={String(totalHabiles)} />
        <Dato etiqueta="N° asistentes" valor={String(totalAsistentes)} />
        <Dato etiqueta="% asistencia" valor={`${porcentaje(totalAsistentes, totalHabiles)} %`} />
      </div>

      <div className="mb-4 grid gap-3 md:grid-cols-2 xl:grid-cols-6">
        <label className="flex flex-col gap-1 text-xs text-muted-foreground xl:col-span-2">
          Centro poblado
          <Select
            aria-label="Centro poblado"
            value={sectorId}
            onChange={(event) => {
              setSectorId(event.target.value)
              setCalle('all')
            }}
            className="h-8 text-sm text-foreground"
          >
            <option value="all">Todos los centros poblados</option>
            {(sectores.data ?? []).map((sector) => (
              <option key={sector.id} value={sector.id}>
                {sector.nombre}
              </option>
            ))}
          </Select>
        </label>
        <label className="flex flex-col gap-1 text-xs text-muted-foreground xl:col-span-2">
          Asamblea
          <Select
            aria-label="Asamblea"
            value={asamblea?.id ?? ''}
            onChange={(event) => setAsambleaId(event.target.value)}
            className="h-8 text-sm text-foreground"
          >
            {asambleasVisibles.length === 0 ? (
              <option value="">Sin asambleas</option>
            ) : null}
            {asambleasVisibles.map((item) => (
              <option key={item.id} value={item.id}>
                {item.anio} · {item.sector?.nombre ?? 'Centro poblado'} · {item.descripcion}
              </option>
            ))}
          </Select>
        </label>
        <label className="flex flex-col gap-1 text-xs text-muted-foreground xl:col-span-2">
          Calle
          <Select
            aria-label="Calle"
            value={calle}
            onChange={(event) => setCalle(event.target.value)}
            className="h-8 text-sm text-foreground"
          >
            <option value="all">Todas las calles</option>
            {calles.map((item) => (
              <option key={item} value={item}>
                {item}
              </option>
            ))}
          </Select>
        </label>
        <Campo label="DNI" value={dni} onChange={setDni} />
        <Campo label="Nombres" value={nombres} onChange={setNombres} className="xl:col-span-2" />
        <Campo label="Apellidos" value={apellidos} onChange={setApellidos} className="xl:col-span-2" />
        <Campo label="N° correlativo" value={correlativo} onChange={setCorrelativo} />
      </div>

      <div className="mb-4 flex flex-wrap items-center justify-between gap-2">
        <div className="flex flex-wrap gap-1">
          {vistas.map((item) => (
            <button
              key={item.id}
              type="button"
              aria-pressed={vista === item.id}
              onClick={() => setVista(item.id)}
              className={cn(
                'h-8 rounded-md px-3 text-sm',
                vista === item.id
                  ? 'bg-primary text-primary-foreground'
                  : 'text-muted-foreground hover:bg-secondary',
              )}
            >
              {item.label}
            </button>
          ))}
        </div>
        <div className="flex flex-wrap gap-2">
          <Button
            type="button"
            size="sm"
            disabled={!asamblea || generar.isPending}
            onClick={() => {
              if (asamblea) generar.mutate(asamblea.id)
            }}
          >
            {generar.isPending ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
            Generar padrón
          </Button>
          <Button type="button" size="sm" variant="outline" onClick={limpiar}>
            Nueva búsqueda
          </Button>
          <Button type="button" size="sm" variant="secondary" onClick={() => imprimirReporte(reporteActual())}>
            Imprimir
          </Button>
          <Button type="button" size="sm" variant="secondary" onClick={() => descargarExcel(reporteActual())}>
            Excel
          </Button>
          <Button type="button" size="sm" variant="secondary" onClick={() => descargarPdf(reporteActual())}>
            PDF
          </Button>
        </div>
      </div>

      {marcar.isError || generar.isError ? (
        <p role="alert" className="mb-3 text-sm text-destructive">
          {((marcar.error ?? generar.error) as Error).message}
        </p>
      ) : null}

      {asambleas.isLoading || padron.isLoading ? (
        <p className="text-sm text-muted-foreground">Cargando padrón…</p>
      ) : padron.isError ? (
        <p role="alert" className="text-sm text-destructive">
          {(padron.error as Error).message}
        </p>
      ) : !asamblea ? (
        <p className="text-sm text-muted-foreground">
          {sectorId === 'all'
            ? 'Todavía no hay asambleas. Registrá una en Registro de asambleas.'
            : 'Ese centro poblado todavía no tiene asambleas.'}
        </p>
      ) : totalHabiles === 0 ? (
        <p className="text-sm text-muted-foreground">
          Esta asamblea todavía no tiene padrón de hábiles. Usá Generar padrón.
        </p>
      ) : vista === 'resumen' ? (
        <DataTable
          columns={[
            { key: 'centro', header: 'Centro poblado' },
            { key: 'calle', header: 'Calle' },
            { key: 'habiles', header: 'Hábiles', className: 'w-24' },
            { key: 'asistentes', header: 'Asistentes', className: 'w-28' },
            { key: 'porcentaje', header: '% asistencia', className: 'w-28' },
          ]}
          rows={resumen}
          rowKey={(row) => row.calle}
          emptyMessage="No hay calles para ese filtro."
          renderCell={(row, key) => {
            if (key === 'habiles') return row.habiles
            if (key === 'asistentes') return row.asistentes
            if (key === 'porcentaje') return `${porcentaje(row.asistentes, row.habiles)} %`
            if (key === 'centro') return row.centro
            return row.calle
          }}
        />
      ) : (
        <>
          <DataTable
            columns={[
              { key: 'correlativo', header: 'N°', className: 'w-14' },
              { key: 'documento', header: 'Documento', className: 'w-28' },
              { key: 'nombre', header: 'Usuario' },
              { key: 'calle', header: 'Calle' },
              { key: 'predio', header: 'Predio' },
              { key: 'asistencia', header: 'Asistencia', className: 'w-28' },
            ]}
            rows={pagina}
            rowKey={(row) => row.id}
            emptyMessage={
              vista === 'asistentes'
                ? 'Todavía no hay asistentes con esos filtros.'
                : 'No hay usuarios hábiles con esos filtros.'
            }
            renderCell={(row, key) => {
              if (key === 'correlativo') return row.correlativo
              if (key === 'documento') return row.documento || '—'
              if (key === 'calle') return row.calle
              if (key === 'predio') return predioTexto(row.predio)
              if (key === 'asistencia') {
                if (vista !== 'control') return row.asistencia ? 'Asistió' : 'No asistió'
                return (
                  <input
                    type="checkbox"
                    aria-label={`Asistencia de ${row.nombre}`}
                    checked={row.asistencia}
                    onClick={(event) => event.stopPropagation()}
                    onChange={(event) =>
                      marcar.mutate({ id: row.id, asistencia: event.target.checked })
                    }
                  />
                )
              }
              return row.nombre
            }}
          />
          <PaginationBar page={page} pageSize={pageSize} total={lista.length} onPageChange={setPage} />
        </>
      )}
    </>
  )

  if (embedded) return contenido
  return <AppShell className="max-w-7xl">{contenido}</AppShell>
}

function Campo({
  label,
  value,
  onChange,
  className,
}: {
  label: string
  value: string
  onChange: (value: string) => void
  className?: string
}) {
  return (
    <label className={cn('flex flex-col gap-1 text-xs text-muted-foreground', className)}>
      {label}
      <Input
        aria-label={label}
        value={value}
        onChange={(event) => onChange(event.target.value)}
        className="h-8"
      />
    </label>
  )
}

function Dato({ etiqueta, valor }: { etiqueta: string; valor: string }) {
  return (
    <div className="rounded-xl border border-border bg-card px-4 py-3">
      <p className="text-xs text-muted-foreground">{etiqueta}</p>
      <p className="font-[family-name:var(--font-display)] text-2xl font-semibold text-foreground">
        {valor}
      </p>
    </div>
  )
}
