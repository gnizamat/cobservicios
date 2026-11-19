import { useEffect, useMemo, useState } from 'react'
import { useTransferencias } from '@/modules/transferencias/api'
import {
  formatFechaHora,
  formatUbicacionPredio,
  formatUsuarioNombre,
} from '@/modules/transferencias/lib/format'
import type { PredioDeUsuario, TransferenciaPredioLinea } from '@/modules/transferencias/types'
import { ListFilters, PaginationBar } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import { useDebouncedValue } from '@/shared/hooks/use-debounced-value'

export interface TransferenciasHistorialProps {
  onInspectPredio: (predio: PredioDeUsuario) => void
}

const columns = [
  { key: 'fecha', header: 'Fecha', className: 'w-36' },
  { key: 'origen', header: 'Origen' },
  { key: 'destino', header: 'Destino' },
  { key: 'referencia', header: 'Referencia' },
  { key: 'predios', header: 'Predios' },
]

function lineaComoPredio(linea: TransferenciaPredioLinea): PredioDeUsuario {
  return {
    id: linea.predio_id,
    nombre: linea.nombre_predio,
    numero: linea.numero,
    manzana: linea.manzana,
    lote: linea.lote,
    calle_nombre: linea.calle_nombre,
  }
}

export function TransferenciasHistorial({ onInspectPredio }: TransferenciasHistorialProps) {
  const [searchInput, setSearchInput] = useState('')
  const search = useDebouncedValue(searchInput.trim(), 300)
  const [page, setPage] = useState(1)
  const [pageSize, setPageSize] = useState(10)

  useEffect(() => {
    setPage(1)
  }, [search])

  const query = useMemo(
    () => ({ search, page, pageSize }),
    [search, page, pageSize],
  )
  const { data, isLoading, isError, error, isFetching } = useTransferencias(query)
  const items = data?.items ?? []

  return (
    <section className="mt-8">
      <div className="mb-4 space-y-1">
        <h3 className="font-[family-name:var(--font-display)] text-lg font-semibold tracking-tight">
          Trazabilidad
        </h3>
        <p className="max-w-2xl text-sm text-muted-foreground">
          Cada transferencia conserva origen, destino, referencia y los predios movidos.
        </p>
      </div>

      <ListFilters
        liveSearch
        search={searchInput}
        onSearchChange={setSearchInput}
        onReset={() => {
          setSearchInput('')
          setPage(1)
        }}
        hasActiveFilters={Boolean(searchInput.trim())}
        searchPlaceholder="Referencia, usuario o predio…"
      />

      {isLoading && !data ? (
        <p className="text-sm text-muted-foreground">Cargando transferencias…</p>
      ) : isError ? (
        <p role="alert" className="text-sm text-destructive">
          {(error as Error).message}
        </p>
      ) : (
        <div className={isFetching ? 'opacity-70 transition-opacity' : undefined}>
          <DataTable
            columns={columns}
            rows={items}
            rowKey={(row) => row.id}
            emptyMessage="Todavía no hay transferencias registradas."
            renderCell={(row, key) => {
              switch (key) {
                case 'fecha':
                  return formatFechaHora(row.created_at)
                case 'origen':
                  return formatUsuarioNombre(row.origen)
                case 'destino':
                  return formatUsuarioNombre(row.destino)
                case 'referencia':
                  return row.referencia || '—'
                case 'predios':
                  return (
                    <ul className="space-y-1">
                      {row.predios.map((linea) => (
                        <li key={linea.id}>
                          <button
                            type="button"
                            className="text-left text-foreground underline-offset-2 hover:underline"
                            onClick={() => onInspectPredio(lineaComoPredio(linea))}
                          >
                            {linea.nombre_predio}
                            <span className="block text-[11px] text-muted-foreground no-underline">
                              {formatUbicacionPredio(linea) || 'Sin ubicación'}
                            </span>
                          </button>
                        </li>
                      ))}
                    </ul>
                  )
                default:
                  return null
              }
            }}
          />
          <PaginationBar
            page={page}
            pageSize={pageSize}
            total={data?.total ?? 0}
            pageSizeOptions={[10, 20, 50]}
            onPageChange={setPage}
            onPageSizeChange={(size) => {
              setPageSize(size)
              setPage(1)
            }}
          />
        </div>
      )}
    </section>
  )
}
