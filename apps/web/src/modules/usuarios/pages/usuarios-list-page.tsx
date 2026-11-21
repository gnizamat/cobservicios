import { Plus } from 'lucide-react'
import { useEffect, useMemo, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import { Button, Icon } from '@/design-system/atoms'
import {
  FilterSelect,
  ListFilters,
  PageHeader,
  PaginationBar,
} from '@/design-system/molecules'
import { AppShell } from '@/design-system/templates'
import { useUsuarios } from '@/modules/usuarios/api'
import type { UsuarioTipoFilter } from '@/modules/usuarios/api'
import { UsuariosTable } from '@/modules/usuarios/components/usuarios-table'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'
import type { ListEstadoFilter } from '@/shared/types/list'

const ESTADO_OPTIONS = [
  { value: 'all', label: 'Todos los estados' },
  { value: 'activo', label: 'Activos' },
  { value: 'inactivo', label: 'Inactivos' },
]

const TIPO_OPTIONS = [
  { value: 'all', label: 'Todos los tipos' },
  { value: 'natural', label: 'Natural' },
  { value: 'juridica', label: 'Jurídica' },
  { value: 'institucional', label: 'Institucional' },
]

export function UsuariosListPage() {
  const navigate = useNavigate()
  const [searchInput, setSearchInput] = useState('')
  const search = useDebouncedValue(searchInput.trim(), 300)
  const [estado, setEstado] = useState<ListEstadoFilter>('all')
  const [tipoPersona, setTipoPersona] = useState<UsuarioTipoFilter>('all')
  const [page, setPage] = useState(1)
  const [pageSize, setPageSize] = useState(20)

  useEffect(() => {
    setPage(1)
  }, [search])

  const query = useMemo(
    () => ({ search, estado, tipoPersona, page, pageSize }),
    [search, estado, tipoPersona, page, pageSize],
  )

  const { data, isLoading, isError, error, isFetching } = useUsuarios(query)
  const items = data?.items ?? []
  const total = data?.total ?? 0

  const hasActiveFilters =
    Boolean(searchInput.trim()) || estado !== 'all' || tipoPersona !== 'all'

  const resetFilters = () => {
    setSearchInput('')
    setEstado('all')
    setTipoPersona('all')
    setPage(1)
  }

  return (
    <AppShell>
      <PageHeader
        className="mb-3"
        title="Usuarios de servicio"
        description="Padrón de usuarios con búsqueda, filtros y paginación."
        actions={
          <Button asChild size="sm">
            <Link to="/padron/usuarios/nuevo">
              <Icon icon={Plus} size={16} />
              Nuevo usuario
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
        searchPlaceholder="Nombre, DNI, RUC, celular o correo…"
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
              label="Tipo de persona"
              value={tipoPersona}
              options={TIPO_OPTIONS}
              onChange={(value) => {
                setTipoPersona(value as UsuarioTipoFilter)
                setPage(1)
              }}
            />
          </>
        }
      />

      {isLoading && !data ? (
        <p className="text-sm text-muted-foreground">Cargando usuarios…</p>
      ) : isError ? (
        <p role="alert" className="text-sm text-destructive">
          {(error as Error).message}
        </p>
      ) : (
        <div className={isFetching ? 'opacity-70 transition-opacity' : undefined}>
          <UsuariosTable
            rows={items}
            onOpen={(usuario) => navigate(`/padron/usuarios/${usuario.id}`)}
          />
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
