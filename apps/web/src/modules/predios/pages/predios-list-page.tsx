import { Plus } from 'lucide-react'
import { useEffect, useMemo, useState } from 'react'
import { Link } from 'react-router-dom'
import { Button, Icon } from '@/design-system/atoms'
import {
  FilterSelect,
  ListFilters,
  PageHeader,
  PaginationBar,
} from '@/design-system/molecules'
import { AppShell } from '@/design-system/templates'
import { usePredioCatalogs, usePredios } from '@/modules/predios/api'
import { PrediosTable } from '@/modules/predios/components/predios-table'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'
import type { ListEstadoFilter } from '@/shared/types/list'

const ESTADO_OPTIONS = [
  { value: 'all', label: 'Todos los estados' },
  { value: 'activo', label: 'Activos' },
  { value: 'inactivo', label: 'Inactivos' },
]

export function PrediosListPage() {
  const [searchInput, setSearchInput] = useState('')
  const search = useDebouncedValue(searchInput.trim(), 300)
  const [estado, setEstado] = useState<ListEstadoFilter>('all')
  const [tipoPredioId, setTipoPredioId] = useState<string>('all')
  const [sectorId, setSectorId] = useState<string>('all')
  const [calleId, setCalleId] = useState<string>('all')
  const [page, setPage] = useState(1)
  const [pageSize, setPageSize] = useState(20)

  const { data: catalogs } = usePredioCatalogs()

  const tipoOptions = useMemo(
    () => [
      { value: 'all', label: 'Todos los tipos' },
      ...(catalogs?.tipos ?? []).map((tipo) => ({
        value: tipo.id,
        label: tipo.nombre,
      })),
    ],
    [catalogs?.tipos],
  )

  const sectorOptions = useMemo(
    () => [
      { value: 'all', label: 'Todos los centros poblados' },
      ...(catalogs?.sectores ?? []).map((sector) => ({
        value: sector.id,
        label: sector.nombre,
      })),
    ],
    [catalogs?.sectores],
  )

  const calleOptions = useMemo(() => {
    const calles = (catalogs?.calles ?? []).filter(
      (calle) => sectorId === 'all' || calle.sector_id === sectorId,
    )
    return [
      { value: 'all', label: 'Todas las calles' },
      ...calles.map((calle) => ({
        value: calle.id,
        label: calle.nombre,
      })),
    ]
  }, [catalogs?.calles, sectorId])

  useEffect(() => {
    setPage(1)
  }, [search])

  const query = useMemo(
    () => ({ search, estado, tipoPredioId, sectorId, calleId, page, pageSize }),
    [search, estado, tipoPredioId, sectorId, calleId, page, pageSize],
  )

  const { data, isLoading, isError, error, isFetching } = usePredios(query)
  const items = data?.items ?? []
  const total = data?.total ?? 0

  const hasActiveFilters =
    Boolean(searchInput.trim()) ||
    estado !== 'all' ||
    tipoPredioId !== 'all' ||
    sectorId !== 'all' ||
    calleId !== 'all'

  const resetFilters = () => {
    setSearchInput('')
    setEstado('all')
    setTipoPredioId('all')
    setSectorId('all')
    setCalleId('all')
    setPage(1)
  }

  return (
    <AppShell>
      <PageHeader
        className="mb-3"
        title="Predios"
        description="Padrón de predios con búsqueda, filtros y paginación."
        actions={
          <Button asChild size="sm">
            <Link to="/padron/predios/nuevo">
              <Icon icon={Plus} size={16} />
              Nuevo predio
            </Link>
          </Button>
        }
      />

      <ListFilters
        liveSearch
        search={searchInput}
        onSearchChange={setSearchInput}
        onReset={resetFilters}
        hasActiveFilters={hasActiveFilters}
        searchPlaceholder="DNI, nombres, apellidos, predio, número, manzana o lote…"
        filters={
          <>
            <FilterSelect
              label="Estado"
              value={estado}
              options={ESTADO_OPTIONS}
              onChange={(value) => {
                setEstado(value as ListEstadoFilter)
                setPage(1)
              }}
            />
            <FilterSelect
              label="Tipo de predio"
              value={tipoPredioId}
              options={tipoOptions}
              onChange={(value) => {
                setTipoPredioId(value)
                setPage(1)
              }}
            />
            <FilterSelect
              label="Centro poblado"
              value={sectorId}
              options={sectorOptions}
              onChange={(value) => {
                setSectorId(value)
                setCalleId((current) => {
                  if (current === 'all' || value === 'all') return current
                  const calle = catalogs?.calles.find((item) => item.id === current)
                  return calle?.sector_id === value ? current : 'all'
                })
                setPage(1)
              }}
            />
            <FilterSelect
              label="Calle"
              value={calleOptions.some((option) => option.value === calleId) ? calleId : 'all'}
              options={calleOptions}
              onChange={(value) => {
                setCalleId(value)
                setPage(1)
              }}
            />
          </>
        }
      />

      {isLoading && !data ? (
        <p className="text-sm text-muted-foreground">Cargando predios…</p>
      ) : isError ? (
        <p role="alert" className="text-sm text-destructive">
          {(error as Error).message}
        </p>
      ) : (
        <div className={isFetching ? 'opacity-70 transition-opacity' : undefined}>
          <PrediosTable rows={items} />
          <PaginationBar
            page={page}
            pageSize={pageSize}
            total={total}
            onPageChange={setPage}
            onPageSizeChange={(size) => {
              setPageSize(size)
              setPage(1)
            }}
          />
        </div>
      )}
    </AppShell>
  )
}
