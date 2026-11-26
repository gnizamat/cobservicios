import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useEffect, useState, type ChangeEvent } from 'react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import { FormLayout } from '@/design-system/templates'
import { useSectores } from '@/modules/catalogo'
import {
  useConsultaDniActiva,
  usePersonaDni,
  type ColaboradorHidrometria,
} from '@/modules/configuracion/api/colaboradores-api'
import { useColaboradores, useSaveColaborador } from '@/modules/configuracion/api/use-colaboradores'
import {
  colaboradorFormSchema,
  textoColaborador,
  toColaboradorPayload,
  type ColaboradorFormValues,
} from '@/modules/configuracion/schemas/colaborador'
import { cn } from '@/shared/lib/utils'

const columns = [
  { key: 'dni', header: 'DNI', className: 'w-28' },
  { key: 'nombre', header: 'Colaborador' },
  { key: 'centros', header: 'Centros poblados' },
]

function nombreColaborador(row: Pick<ColaboradorHidrometria, 'apellido_paterno' | 'apellido_materno' | 'nombres'>) {
  const apellidos = [row.apellido_paterno, row.apellido_materno].filter(Boolean).join(' ')
  return apellidos ? `${apellidos}, ${row.nombres}` : row.nombres
}

function mensajeConsulta(error: unknown) {
  if (!error) return undefined
  const texto = error instanceof Error ? error.message : 'No se pudo consultar el DNI'
  return texto.replace(/^[A-Z0-9]{5}:\s*/, '')
}

function celdaColaborador(row: ColaboradorHidrometria, key: string) {
  if (key === 'dni') return row.dni
  if (key === 'centros') return row.sectores.map((sector) => sector.nombre).join(' · ') || '—'
  return nombreColaborador(row)
}

function ListaColaboradores({
  records,
  selectedId,
  loading,
  error,
  onCreate,
  onSelect,
}: {
  records: ColaboradorHidrometria[]
  selectedId?: string
  loading: boolean
  error: string | null
  onCreate: () => void
  onSelect: (id: string) => void
}) {
  return (
    <div className="space-y-3">
      <div className="flex items-center justify-between gap-3">
        <h3 className="text-sm font-medium text-foreground">Colaboradores</h3>
        <Button type="button" size="sm" variant="outline" onClick={onCreate}>
          Nuevo
        </Button>
      </div>
      {loading ? (
        <p className="text-sm text-muted-foreground">Cargando colaboradores…</p>
      ) : error ? (
        <p role="alert" className="text-sm text-destructive">
          {error}
        </p>
      ) : (
        <DataTable
          columns={columns}
          rows={records}
          rowKey={(row) => row.id}
          selectedKey={selectedId}
          onRowSelect={(row) => onSelect(row.id)}
          emptyMessage="Todavía no hay colaboradores."
          renderCell={celdaColaborador}
        />
      )}
    </div>
  )
}

export function ColaboradoresPanel() {
  const query = useColaboradores()
  const sectores = useSectores()
  const save = useSaveColaborador()
  const [selectedId, setSelectedId] = useState<string | null>(null)
  const [creating, setCreating] = useState(false)
  const records = query.data ?? []
  const selected = creating ? null : (records.find((row) => row.id === selectedId) ?? records[0] ?? null)
  const formKey = creating ? 'nuevo' : (selected?.id ?? 'nuevo')

  return (
    <div className="grid items-start gap-4 xl:grid-cols-[minmax(0,1.15fr)_minmax(18rem,0.85fr)]">
      <ListaColaboradores
        records={records}
        selectedId={selected?.id}
        loading={query.isLoading}
        error={query.isError ? (query.error as Error).message : null}
        onCreate={() => {
          setCreating(true)
          setSelectedId(null)
        }}
        onSelect={(id) => {
          setCreating(false)
          setSelectedId(id)
        }}
      />
      {query.isLoading || sectores.isLoading ? null : (
        <ColaboradorForm
          key={formKey}
          initial={selected}
          sectores={sectores.data ?? []}
          submitting={save.isPending}
          error={save.isError ? (save.error as Error).message : null}
          onSubmit={(values) => {
            save.mutate(
              { id: creating ? null : (selected?.id ?? null), input: toColaboradorPayload(values) },
              {
                onSuccess: (id) => {
                  setCreating(false)
                  setSelectedId(id)
                },
              },
            )
          }}
        />
      )}
    </div>
  )
}

function ColaboradorForm({
  initial,
  sectores,
  submitting,
  error,
  onSubmit,
}: {
  initial: ColaboradorHidrometria | null
  sectores: { id: string; codigo: string; nombre: string; activo: boolean }[]
  submitting: boolean
  error: string | null
  onSubmit: (values: ColaboradorFormValues) => void
}) {
  const form = useForm<ColaboradorFormValues>({
    resolver: zodResolver(colaboradorFormSchema),
    defaultValues: initial
      ? {
          dni: initial.dni,
          apellido_paterno: initial.apellido_paterno,
          apellido_materno: initial.apellido_materno,
          nombres: initial.nombres,
          sector_ids: initial.sectores.map((sector) => sector.id),
        }
      : {
          dni: '',
          apellido_paterno: '',
          apellido_materno: '',
          nombres: '',
          sector_ids: [],
        },
  })
  const consultaActiva = useConsultaDniActiva()
  const dni = form.watch('dni')
  const sectorIds = form.watch('sector_ids')
  const seleccionados = new Set(sectorIds)
  const buscarDni = consultaActiva.data === true && /^\d{8}$/.test(dni) && dni !== (initial?.dni ?? '')
  const personaDni = usePersonaDni(dni, buscarDni)
  const centros = [...sectores].sort((a, b) => {
    if (a.activo !== b.activo) return a.activo ? -1 : 1
    return a.nombre.localeCompare(b.nombre, 'es')
  })
  const errorCentros =
    form.formState.errors.sector_ids?.message ??
    form.formState.errors.sector_ids?.root?.message

  useEffect(() => {
    const persona = personaDni.data
    if (!persona || form.getValues('dni') !== dni) return
    form.setValue('nombres', textoColaborador(persona.nombres).trim(), { shouldValidate: true })
    form.setValue('apellido_paterno', textoColaborador(persona.apellidoPaterno).trim(), {
      shouldValidate: true,
    })
    form.setValue('apellido_materno', textoColaborador(persona.apellidoMaterno).trim(), {
      shouldValidate: true,
    })
  }, [dni, form, personaDni.data])

  function registrarDni() {
    const registro = form.register('dni')
    return {
      ...registro,
      inputMode: 'numeric' as const,
      maxLength: 8,
      onChange: (event: ChangeEvent<HTMLInputElement>) => {
        event.target.value = event.target.value.replace(/\D/g, '').slice(0, 8)
        void registro.onChange(event)
      },
    }
  }

  function registrarTexto(nombre: 'apellido_paterno' | 'apellido_materno' | 'nombres') {
    const registro = form.register(nombre)
    return {
      ...registro,
      autoCapitalize: 'characters' as const,
      spellCheck: false,
      onChange: (event: ChangeEvent<HTMLInputElement>) => {
        event.target.value = textoColaborador(event.target.value)
        void registro.onChange(event)
      },
    }
  }

  return (
    <form onSubmit={form.handleSubmit(onSubmit)} noValidate>
      {error ? (
        <p role="alert" className="mb-3 text-sm text-destructive">
          {error}
        </p>
      ) : null}
      <FormLayout
        columns={1}
        footer={
          <Button type="submit" disabled={submitting || centros.length === 0}>
            {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
            {initial ? 'Guardar cambios' : 'Registrar colaborador'}
          </Button>
        }
      >
        <FormField
          label="DNI"
          htmlFor="colaborador-dni"
          error={form.formState.errors.dni?.message ?? mensajeConsulta(personaDni.error)}
          hint={
            consultaActiva.data === true
              ? personaDni.isFetching
                ? 'Buscando el DNI…'
                : 'Al completar el DNI se completan los apellidos y nombres.'
              : undefined
          }
        >
          <Input id="colaborador-dni" autoComplete="off" {...registrarDni()} />
        </FormField>
        <FormField
          label="Apellido paterno"
          htmlFor="colaborador-paterno"
          error={form.formState.errors.apellido_paterno?.message}
        >
          <Input id="colaborador-paterno" {...registrarTexto('apellido_paterno')} />
        </FormField>
        <FormField
          label="Apellido materno"
          htmlFor="colaborador-materno"
          error={form.formState.errors.apellido_materno?.message}
        >
          <Input id="colaborador-materno" {...registrarTexto('apellido_materno')} />
        </FormField>
        <FormField
          label="Nombres"
          htmlFor="colaborador-nombres"
          error={form.formState.errors.nombres?.message}
        >
          <Input id="colaborador-nombres" {...registrarTexto('nombres')} />
        </FormField>
        <fieldset className="space-y-2">
          <legend className="text-sm font-medium text-foreground">Centros poblados</legend>
          <p className="text-xs text-muted-foreground">
            Un colaborador puede estar asignado a uno o varios centros poblados.
          </p>
          {centros.length === 0 ? (
            <p className="text-sm text-muted-foreground">
              Todavía no hay centros poblados. Registralos en Organización.
            </p>
          ) : (
            <div className="max-h-56 space-y-1 overflow-y-auto rounded-xl border border-border p-2">
              {centros.map((sector) => {
                const marcado = seleccionados.has(sector.id)
                return (
                  <label
                    key={sector.id}
                    className={cn(
                      'flex cursor-pointer items-center gap-2 rounded-lg px-2 py-1.5 text-sm text-foreground hover:bg-secondary',
                      !sector.activo && 'text-muted-foreground',
                    )}
                  >
                    <input
                      type="checkbox"
                      className="size-4 accent-primary"
                      checked={marcado}
                      onChange={(event) => {
                        const siguiente = event.target.checked
                          ? [...sectorIds, sector.id]
                          : sectorIds.filter((id) => id !== sector.id)
                        form.setValue('sector_ids', siguiente, { shouldValidate: true, shouldDirty: true })
                      }}
                    />
                    <span>
                      {sector.nombre}
                      {sector.activo ? '' : ' · inactivo'}
                    </span>
                  </label>
                )
              })}
            </div>
          )}
          {errorCentros ? <p className="text-xs text-destructive">{errorCentros}</p> : null}
        </fieldset>
      </FormLayout>
    </form>
  )
}
