import { LoaderCircle } from 'lucide-react'
import { useEffect, useMemo, useState } from 'react'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField, PageHeader, StatusBadge } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import { AppShell, FormLayout } from '@/design-system/templates'
import type { AsambleaListItem } from '@/modules/asambleas/api/asambleas-api'
import {
  useAsambleas,
  useDeleteAsamblea,
  useEstadoAsamblea,
  useSaveAsamblea,
  useSectoresAsamblea,
} from '@/modules/asambleas/api/use-asambleas'
import { useOrganizacion } from '@/modules/configuracion/api'
import type { EstadoRegistro } from '@/shared/types/database'

const tipoLabel = {
  ordinaria: 'Ordinaria',
  extraordinaria: 'Extraordinaria',
} as const

const ambitoLabel = {
  principal: 'Principal',
  anexo: 'Anexo',
} as const

function hoyLima() {
  return new Intl.DateTimeFormat('en-CA', { timeZone: 'America/Lima' }).format(new Date())
}

function fechaCorta(iso: string) {
  const [anio, mes, dia] = iso.slice(0, 10).split('-')
  return `${dia}/${mes}/${anio}`
}

export function AsambleasPage({ embedded = false }: { embedded?: boolean }) {
  const asambleas = useAsambleas()
  const sectores = useSectoresAsamblea()
  const organizacion = useOrganizacion()
  const save = useSaveAsamblea()
  const estado = useEstadoAsamblea()
  const remove = useDeleteAsamblea()
  const [sectorFiltro, setSectorFiltro] = useState('all')
  const [anioFiltro, setAnioFiltro] = useState('all')
  const [modo, setModo] = useState<'editar' | 'crear'>('editar')
  const [selectedId, setSelectedId] = useState<string | null>(null)

  const filas = useMemo(() => {
    return (asambleas.data ?? []).filter((row) => {
      if (sectorFiltro !== 'all' && row.sector_id !== sectorFiltro) return false
      if (anioFiltro !== 'all' && String(row.anio) !== anioFiltro) return false
      return true
    })
  }, [anioFiltro, asambleas.data, sectorFiltro])

  const anios = useMemo(() => {
    return [...new Set((asambleas.data ?? []).map((row) => row.anio))].sort((a, b) => b - a)
  }, [asambleas.data])

  const selected = modo === 'crear' ? null : (filas.find((row) => row.id === selectedId) ?? filas[0] ?? null)

  const contenido = (
    <>
      {embedded ? null : (
        <PageHeader
          title="Registro de asambleas"
          description="Registrá la asamblea del centro poblado: descripción, ámbito, tipo y fecha."
        />
      )}

      <div className="mb-4 flex flex-wrap gap-3">
        <label className="flex min-w-[14rem] flex-1 flex-col gap-1 text-xs text-muted-foreground">
          Centro poblado
          <Select
            aria-label="Centro poblado"
            value={sectorFiltro}
            onChange={(event) => setSectorFiltro(event.target.value)}
            className="h-8 text-sm text-foreground"
          >
            <option value="all">Todos</option>
            {(sectores.data ?? []).map((sector) => (
              <option key={sector.id} value={sector.id}>
                {sector.nombre}
              </option>
            ))}
          </Select>
        </label>
        <label className="flex w-36 flex-col gap-1 text-xs text-muted-foreground">
          Año
          <Select
            aria-label="Año"
            value={anioFiltro}
            onChange={(event) => setAnioFiltro(event.target.value)}
            className="h-8 text-sm text-foreground"
          >
            <option value="all">Todos</option>
            {anios.map((anio) => (
              <option key={anio} value={anio}>
                {anio}
              </option>
            ))}
          </Select>
        </label>
      </div>

      <div className="grid items-start gap-4 lg:grid-cols-[minmax(0,1.35fr)_minmax(18rem,0.8fr)]">
        <div className="min-w-0 space-y-3">
          <div className="flex justify-end">
            <Button
              type="button"
              size="sm"
              onClick={() => {
                setModo('crear')
                setSelectedId(null)
              }}
            >
              Nueva asamblea
            </Button>
          </div>
          {asambleas.isLoading ? (
            <p className="text-sm text-muted-foreground">Cargando asambleas…</p>
          ) : asambleas.isError ? (
            <p role="alert" className="text-sm text-destructive">
              {(asambleas.error as Error).message}
            </p>
          ) : (
            <DataTable
              columns={[
                { key: 'descripcion', header: 'Descripción' },
                { key: 'anio', header: 'Año', className: 'w-16' },
                { key: 'sector', header: 'Centro poblado' },
                { key: 'ambito', header: 'Ámbito', className: 'w-24' },
                { key: 'tipo', header: 'Tipo', className: 'w-32' },
                { key: 'fecha', header: 'Fecha', className: 'w-24' },
                { key: 'estado', header: 'Estado', className: 'w-24' },
              ]}
              rows={filas}
              rowKey={(row) => row.id}
              selectedKey={selected?.id}
              onRowSelect={(row) => {
                setModo('editar')
                setSelectedId(row.id)
              }}
              emptyMessage="Todavía no hay asambleas para ese centro poblado y ese año."
              renderCell={(row, key) => {
                if (key === 'anio') return row.anio
                if (key === 'sector') return row.sector?.nombre ?? '—'
                if (key === 'ambito') return ambitoLabel[row.ambito]
                if (key === 'tipo') return tipoLabel[row.tipo]
                if (key === 'fecha') return fechaCorta(row.fecha)
                if (key === 'estado') return <StatusBadge status={row.estado} />
                return row.descripcion
              }}
            />
          )}
        </div>

        <AsambleaForm
          key={selected?.id ?? 'nueva'}
          jass={organizacion.data?.nombre ?? 'JASS'}
          sectores={sectores.data ?? []}
          actual={selected}
          guardando={save.isPending}
          error={save.isError ? (save.error as Error).message : null}
          cambiandoEstado={estado.isPending}
          eliminando={remove.isPending}
          onEstado={
            selected
              ? () =>
                  estado.mutate({
                    id: selected.id,
                    estado: selected.estado === 'activo' ? 'inactivo' : 'activo',
                  })
              : undefined
          }
          onDelete={
            selected
              ? () =>
                  remove.mutate(selected.id, {
                    onSuccess: () => setSelectedId(null),
                  })
              : undefined
          }
          onSave={(input) =>
            save.mutate(
              { id: selected?.id ?? null, input },
              {
                onSuccess: (id) => {
                  setModo('editar')
                  setSelectedId(id)
                },
              },
            )
          }
        />
      </div>
    </>
  )

  if (embedded) return contenido
  return <AppShell className="max-w-7xl">{contenido}</AppShell>
}

function AsambleaForm({
  jass,
  sectores,
  actual,
  guardando,
  error,
  cambiandoEstado,
  eliminando,
  onEstado,
  onDelete,
  onSave,
}: {
  jass: string
  sectores: Array<{ id: string; nombre: string }>
  actual: AsambleaListItem | null
  guardando: boolean
  error: string | null
  cambiandoEstado: boolean
  eliminando: boolean
  onEstado?: () => void
  onDelete?: () => void
  onSave: (input: {
    sectorId: string
    descripcion: string
    anio: number
    tipo: 'ordinaria' | 'extraordinaria'
    ambito: 'principal' | 'anexo'
    fecha: string
    estado: EstadoRegistro
  }) => void
}) {
  const [sectorId, setSectorId] = useState(actual?.sector_id ?? '')

  useEffect(() => {
    if (sectorId || sectores.length === 0) return
    setSectorId(sectores[0].id)
  }, [sectorId, sectores])
  const [descripcion, setDescripcion] = useState(actual?.descripcion ?? '')
  const [anio, setAnio] = useState(String(actual?.anio ?? new Date().getFullYear()))
  const [tipo, setTipo] = useState<'ordinaria' | 'extraordinaria'>(actual?.tipo ?? 'extraordinaria')
  const [ambito, setAmbito] = useState<'principal' | 'anexo'>(actual?.ambito ?? 'anexo')
  const [fecha, setFecha] = useState(actual?.fecha.slice(0, 10) ?? hoyLima())
  const [local, setLocal] = useState<string | null>(null)
  const [confirmar, setConfirmar] = useState(false)

  return (
    <FormLayout
      columns={1}
      footer={
        <>
          {actual && onEstado ? (
            <Button type="button" size="sm" variant="secondary" disabled={cambiandoEstado} onClick={onEstado}>
              {actual.estado === 'activo' ? 'Desactivar' : 'Activar'}
            </Button>
          ) : null}
          {actual && onDelete ? (
            <Button
              type="button"
              size="sm"
              variant="outline"
              disabled={eliminando}
              onClick={() => {
                if (!confirmar) {
                  setConfirmar(true)
                  return
                }
                onDelete()
              }}
            >
              {confirmar ? 'Confirmar eliminación' : 'Eliminar'}
            </Button>
          ) : null}
          <Button
          type="button"
          disabled={guardando}
          onClick={() => {
            const anioNumero = Number(anio)
            if (!sectorId) {
              setLocal('Elegí el centro poblado.')
              return
            }
            if (!descripcion.trim()) {
              setLocal('Indicá la descripción de la asamblea.')
              return
            }
            if (!Number.isInteger(anioNumero) || anioNumero < 2000) {
              setLocal('El año no es válido.')
              return
            }
            if (!fecha) {
              setLocal('Indicá la fecha de la asamblea.')
              return
            }
            setLocal(null)
            onSave({
              sectorId,
              descripcion: descripcion.trim(),
              anio: anioNumero,
              tipo,
              ambito,
              fecha,
              estado: actual?.estado ?? 'inactivo',
            })
          }}
        >
          {guardando ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
          {actual ? 'Guardar cambios' : 'Registrar asamblea'}
        </Button>
        </>
      }
    >
      <p className="text-sm text-muted-foreground">{jass}</p>
      {local || error ? (
        <p role="alert" className="text-sm text-destructive">
          {local || error}
        </p>
      ) : null}
      <FormField label="Centro poblado" htmlFor="asm-sector">
        <Select id="asm-sector" value={sectorId} onChange={(event) => setSectorId(event.target.value)}>
          {sectores.map((sector) => (
            <option key={sector.id} value={sector.id}>
              {sector.nombre}
            </option>
          ))}
        </Select>
      </FormField>
      <FormField label="Descripción" htmlFor="asm-descripcion">
        <Input
          id="asm-descripcion"
          value={descripcion}
          onChange={(event) => setDescripcion(event.target.value)}
        />
      </FormField>
      <FormField label="Año" htmlFor="asm-anio">
        <Input
          id="asm-anio"
          inputMode="numeric"
          maxLength={4}
          value={anio}
          onChange={(event) => setAnio(event.target.value)}
        />
      </FormField>
      <FormField label="Ámbito" htmlFor="asm-ambito">
        <Select
          id="asm-ambito"
          value={ambito}
          onChange={(event) => setAmbito(event.target.value as 'principal' | 'anexo')}
        >
          <option value="principal">Principal</option>
          <option value="anexo">Anexo</option>
        </Select>
      </FormField>
      <FormField label="Tipo de asamblea" htmlFor="asm-tipo">
        <Select
          id="asm-tipo"
          value={tipo}
          onChange={(event) => setTipo(event.target.value as 'ordinaria' | 'extraordinaria')}
        >
          <option value="ordinaria">Ordinaria</option>
          <option value="extraordinaria">Extraordinaria</option>
        </Select>
      </FormField>
      <FormField label="Fecha de asamblea" htmlFor="asm-fecha">
        <Input id="asm-fecha" type="date" value={fecha} onChange={(event) => setFecha(event.target.value)} />
      </FormField>
    </FormLayout>
  )
}
