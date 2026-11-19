import { LoaderCircle } from 'lucide-react'
import { useState, type ReactNode } from 'react'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField, StatusBadge } from '@/design-system/molecules'
import { DataTable, type DataTableColumn } from '@/design-system/organisms'
import { FormLayout } from '@/design-system/templates'
import {
  useBancos,
  useCajasConfig,
  useConceptosMulta,
  useDocumentos,
  useInteresesConfig,
  useSaveBanco,
  useSaveCajaConfig,
  useSaveConceptoMulta,
  useSaveDocumento,
  useSaveInteresConfig,
} from '@/modules/configuracion/api/use-cobranza-config'
import type { EstadoRegistro } from '@/shared/types/database'

const moneda = new Intl.NumberFormat('es-PE', { style: 'currency', currency: 'PEN' })
const tasa = new Intl.NumberFormat('es-PE', { maximumFractionDigits: 4 })

interface Fila {
  id: string
  nombre: string
  estado: EstadoRegistro
  detalle: string
}

function useSeleccion<T extends { id: string }>(rows: T[]) {
  const [modo, setModo] = useState<'editar' | 'crear'>('editar')
  const [id, setId] = useState<string | null>(null)
  const selected = modo === 'crear' ? null : (rows.find((row) => row.id === id) ?? rows[0] ?? null)
  return {
    selected,
    crear: () => {
      setModo('crear')
      setId(null)
    },
    elegir: (next: string) => {
      setModo('editar')
      setId(next)
    },
  }
}

function ListaCatalogo({
  filas,
  cargando,
  error,
  columns,
  renderCell,
  vacio,
  selectedId,
  onSelect,
  onNew,
  formulario,
}: {
  filas: Fila[]
  cargando: boolean
  error: string | null
  columns: DataTableColumn[]
  renderCell: (row: Fila, key: string) => ReactNode
  vacio: string
  selectedId?: string
  onSelect: (row: Fila) => void
  onNew: () => void
  formulario: ReactNode
}) {
  return (
    <div className="grid items-start gap-4 lg:grid-cols-[minmax(0,1.2fr)_minmax(16rem,0.8fr)]">
      <div className="min-w-0 space-y-3">
        <div className="flex justify-end">
          <Button type="button" size="sm" onClick={onNew}>
            Nuevo
          </Button>
        </div>
        {cargando ? (
          <p className="text-sm text-muted-foreground">Cargando…</p>
        ) : error ? (
          <p role="alert" className="text-sm text-destructive">
            {error}
          </p>
        ) : (
          <DataTable
            columns={columns}
            rows={filas}
            rowKey={(row) => row.id}
            emptyMessage={vacio}
            selectedKey={selectedId}
            onRowSelect={onSelect}
            renderCell={renderCell}
          />
        )}
      </div>
      {formulario}
    </div>
  )
}

function Acciones({
  guardando,
  nuevo,
  onSubmit,
}: {
  guardando: boolean
  nuevo: boolean
  onSubmit: () => void
}) {
  return (
    <Button type="button" disabled={guardando} onClick={onSubmit}>
      {guardando ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
      {nuevo ? 'Registrar' : 'Guardar cambios'}
    </Button>
  )
}

export function ConceptosMultaPanel() {
  const query = useConceptosMulta()
  const save = useSaveConceptoMulta()
  const filas: Fila[] = (query.data ?? []).map((row) => ({
    id: row.id,
    nombre: row.nombre,
    estado: row.estado,
    detalle: moneda.format(row.monto),
  }))
  const seleccion = useSeleccion(query.data ?? [])
  const actual = seleccion.selected

  return (
    <ListaCatalogo
      filas={filas}
      cargando={query.isLoading}
      error={query.isError ? (query.error as Error).message : null}
      columns={[
        { key: 'nombre', header: 'Concepto' },
        { key: 'detalle', header: 'Monto', className: 'w-28' },
        { key: 'estado', header: 'Estado', className: 'w-24' },
      ]}
      vacio="Todavía no hay conceptos de multa."
      selectedId={actual?.id}
      onSelect={(row) => seleccion.elegir(row.id)}
      onNew={seleccion.crear}
      renderCell={(row, key) =>
        key === 'estado' ? <StatusBadge status={row.estado} /> : row[key as 'nombre' | 'detalle']
      }
      formulario={
        <MultaForm
          key={actual?.id ?? 'nuevo'}
          nombreInicial={actual?.nombre ?? ''}
          montoInicial={actual ? String(actual.monto) : ''}
          estadoInicial={actual?.estado ?? 'activo'}
          nuevo={!actual}
          guardando={save.isPending}
          error={save.isError ? (save.error as Error).message : null}
          onSave={(input) =>
            save.mutate(
              { id: actual?.id ?? null, input },
              { onSuccess: (id) => seleccion.elegir(id) },
            )
          }
        />
      }
    />
  )
}

function MultaForm({
  nombreInicial,
  montoInicial,
  estadoInicial,
  nuevo,
  guardando,
  error,
  onSave,
}: {
  nombreInicial: string
  montoInicial: string
  estadoInicial: EstadoRegistro
  nuevo: boolean
  guardando: boolean
  error: string | null
  onSave: (input: { nombre: string; monto: number; estado: EstadoRegistro }) => void
}) {
  const [nombre, setNombre] = useState(nombreInicial)
  const [monto, setMonto] = useState(montoInicial)
  const [estado, setEstado] = useState(estadoInicial)
  const [local, setLocal] = useState<string | null>(null)

  return (
    <FormLayout
      columns={1}
      footer={
        <Acciones
          guardando={guardando}
          nuevo={nuevo}
          onSubmit={() => {
            const valor = Number(monto)
            if (!nombre.trim()) {
              setLocal('Indicá el nombre del concepto.')
              return
            }
            if (!Number.isFinite(valor) || valor < 0) {
              setLocal('El monto tiene que ser cero o mayor.')
              return
            }
            setLocal(null)
            onSave({ nombre: nombre.trim(), monto: valor, estado })
          }}
        />
      }
    >
      {local || error ? (
        <p role="alert" className="text-sm text-destructive">
          {local || error}
        </p>
      ) : null}
      <FormField label="Concepto" htmlFor="multa-nombre">
        <Input id="multa-nombre" value={nombre} onChange={(event) => setNombre(event.target.value)} />
      </FormField>
      <FormField label="Monto" htmlFor="multa-monto">
        <Input
          id="multa-monto"
          inputMode="decimal"
          value={monto}
          onChange={(event) => setMonto(event.target.value)}
        />
      </FormField>
      <EstadoField id="multa-estado" value={estado} onChange={setEstado} />
    </FormLayout>
  )
}

export function InteresesPanel() {
  const query = useInteresesConfig()
  const save = useSaveInteresConfig()
  const filas: Fila[] = (query.data ?? []).map((row) => ({
    id: row.id,
    nombre: row.nombre,
    estado: row.estado,
    detalle: `${tasa.format(row.porcentaje)} %`,
  }))
  const seleccion = useSeleccion(query.data ?? [])
  const actual = seleccion.selected

  return (
    <ListaCatalogo
      filas={filas}
      cargando={query.isLoading}
      error={query.isError ? (query.error as Error).message : null}
      columns={[
        { key: 'nombre', header: 'Interés' },
        { key: 'detalle', header: 'Porcentaje', className: 'w-28' },
        { key: 'estado', header: 'Estado', className: 'w-24' },
      ]}
      vacio="Todavía no hay tasas de interés."
      selectedId={actual?.id}
      onSelect={(row) => seleccion.elegir(row.id)}
      onNew={seleccion.crear}
      renderCell={(row, key) =>
        key === 'estado' ? <StatusBadge status={row.estado} /> : row[key as 'nombre' | 'detalle']
      }
      formulario={
        <InteresForm
          key={actual?.id ?? 'nuevo'}
          nombreInicial={actual?.nombre ?? ''}
          porcentajeInicial={actual ? String(actual.porcentaje) : ''}
          estadoInicial={actual?.estado ?? 'activo'}
          nuevo={!actual}
          guardando={save.isPending}
          error={save.isError ? (save.error as Error).message : null}
          onSave={(input) =>
            save.mutate(
              { id: actual?.id ?? null, input },
              { onSuccess: (id) => seleccion.elegir(id) },
            )
          }
        />
      }
    />
  )
}

function InteresForm({
  nombreInicial,
  porcentajeInicial,
  estadoInicial,
  nuevo,
  guardando,
  error,
  onSave,
}: {
  nombreInicial: string
  porcentajeInicial: string
  estadoInicial: EstadoRegistro
  nuevo: boolean
  guardando: boolean
  error: string | null
  onSave: (input: { nombre: string; porcentaje: number; estado: EstadoRegistro }) => void
}) {
  const [nombre, setNombre] = useState(nombreInicial)
  const [porcentaje, setPorcentaje] = useState(porcentajeInicial)
  const [estado, setEstado] = useState(estadoInicial)
  const [local, setLocal] = useState<string | null>(null)

  return (
    <FormLayout
      columns={1}
      footer={
        <Acciones
          guardando={guardando}
          nuevo={nuevo}
          onSubmit={() => {
            const valor = Number(porcentaje)
            if (!nombre.trim()) {
              setLocal('Indicá el nombre del interés.')
              return
            }
            if (!Number.isFinite(valor) || valor < 0) {
              setLocal('El porcentaje tiene que ser cero o mayor.')
              return
            }
            setLocal(null)
            onSave({ nombre: nombre.trim(), porcentaje: valor, estado })
          }}
        />
      }
    >
      {local || error ? (
        <p role="alert" className="text-sm text-destructive">
          {local || error}
        </p>
      ) : null}
      <FormField label="Nombre" htmlFor="interes-nombre">
        <Input
          id="interes-nombre"
          value={nombre}
          onChange={(event) => setNombre(event.target.value)}
        />
      </FormField>
      <FormField label="Porcentaje" htmlFor="interes-porcentaje">
        <Input
          id="interes-porcentaje"
          inputMode="decimal"
          value={porcentaje}
          onChange={(event) => setPorcentaje(event.target.value)}
        />
      </FormField>
      <EstadoField id="interes-estado" value={estado} onChange={setEstado} />
    </FormLayout>
  )
}

export function BancosPanel() {
  const query = useBancos()
  const save = useSaveBanco()
  const filas: Fila[] = (query.data ?? []).map((row) => ({
    id: row.id,
    nombre: row.nombre,
    estado: row.estado,
    detalle: row.cuenta,
  }))
  const seleccion = useSeleccion(query.data ?? [])
  const actual = seleccion.selected

  return (
    <ListaCatalogo
      filas={filas}
      cargando={query.isLoading}
      error={query.isError ? (query.error as Error).message : null}
      columns={[
        { key: 'nombre', header: 'Banco' },
        { key: 'detalle', header: 'Cuenta' },
        { key: 'estado', header: 'Estado', className: 'w-24' },
      ]}
      vacio="Todavía no hay bancos."
      selectedId={actual?.id}
      onSelect={(row) => seleccion.elegir(row.id)}
      onNew={seleccion.crear}
      renderCell={(row, key) =>
        key === 'estado' ? <StatusBadge status={row.estado} /> : row[key as 'nombre' | 'detalle']
      }
      formulario={
        <BancoForm
          key={actual?.id ?? 'nuevo'}
          nombreInicial={actual?.nombre ?? ''}
          cuentaInicial={actual?.cuenta ?? ''}
          estadoInicial={actual?.estado ?? 'activo'}
          nuevo={!actual}
          guardando={save.isPending}
          error={save.isError ? (save.error as Error).message : null}
          onSave={(input) =>
            save.mutate(
              { id: actual?.id ?? null, input },
              { onSuccess: (id) => seleccion.elegir(id) },
            )
          }
        />
      }
    />
  )
}

function BancoForm({
  nombreInicial,
  cuentaInicial,
  estadoInicial,
  nuevo,
  guardando,
  error,
  onSave,
}: {
  nombreInicial: string
  cuentaInicial: string
  estadoInicial: EstadoRegistro
  nuevo: boolean
  guardando: boolean
  error: string | null
  onSave: (input: { nombre: string; cuenta: string; estado: EstadoRegistro }) => void
}) {
  const [nombre, setNombre] = useState(nombreInicial)
  const [cuenta, setCuenta] = useState(cuentaInicial)
  const [estado, setEstado] = useState(estadoInicial)
  const [local, setLocal] = useState<string | null>(null)

  return (
    <FormLayout
      columns={1}
      footer={
        <Acciones
          guardando={guardando}
          nuevo={nuevo}
          onSubmit={() => {
            if (!nombre.trim()) {
              setLocal('Indicá el nombre del banco.')
              return
            }
            setLocal(null)
            onSave({ nombre: nombre.trim(), cuenta: cuenta.trim(), estado })
          }}
        />
      }
    >
      {local || error ? (
        <p role="alert" className="text-sm text-destructive">
          {local || error}
        </p>
      ) : null}
      <FormField label="Banco" htmlFor="banco-nombre">
        <Input id="banco-nombre" value={nombre} onChange={(event) => setNombre(event.target.value)} />
      </FormField>
      <FormField label="Cuenta" htmlFor="banco-cuenta">
        <Input id="banco-cuenta" value={cuenta} onChange={(event) => setCuenta(event.target.value)} />
      </FormField>
      <EstadoField id="banco-estado" value={estado} onChange={setEstado} />
    </FormLayout>
  )
}

export function CajasPanel() {
  const query = useCajasConfig()
  const save = useSaveCajaConfig()
  const filas: Fila[] = (query.data ?? []).map((row) => ({
    id: row.id,
    nombre: row.nombre,
    estado: row.activa ? 'activo' : 'inactivo',
    detalle: '',
  }))
  const seleccion = useSeleccion(query.data ?? [])
  const actual = seleccion.selected

  return (
    <ListaCatalogo
      filas={filas}
      cargando={query.isLoading}
      error={query.isError ? (query.error as Error).message : null}
      columns={[
        { key: 'nombre', header: 'Caja' },
        { key: 'estado', header: 'Estado', className: 'w-24' },
      ]}
      vacio="Todavía no hay cajas."
      selectedId={actual?.id}
      onSelect={(row) => seleccion.elegir(row.id)}
      onNew={seleccion.crear}
      renderCell={(row, key) =>
        key === 'estado' ? <StatusBadge status={row.estado} /> : row.nombre
      }
      formulario={
        <CajaForm
          key={actual?.id ?? 'nuevo'}
          nombreInicial={actual?.nombre ?? ''}
          activaInicial={actual?.activa ?? true}
          nuevo={!actual}
          guardando={save.isPending}
          error={save.isError ? (save.error as Error).message : null}
          onSave={(input) =>
            save.mutate(
              { id: actual?.id ?? null, input },
              { onSuccess: (id) => seleccion.elegir(id) },
            )
          }
        />
      }
    />
  )
}

function CajaForm({
  nombreInicial,
  activaInicial,
  nuevo,
  guardando,
  error,
  onSave,
}: {
  nombreInicial: string
  activaInicial: boolean
  nuevo: boolean
  guardando: boolean
  error: string | null
  onSave: (input: { nombre: string; activa: boolean }) => void
}) {
  const [nombre, setNombre] = useState(nombreInicial)
  const [activa, setActiva] = useState<EstadoRegistro>(activaInicial ? 'activo' : 'inactivo')
  const [local, setLocal] = useState<string | null>(null)

  return (
    <FormLayout
      columns={1}
      footer={
        <Acciones
          guardando={guardando}
          nuevo={nuevo}
          onSubmit={() => {
            if (!nombre.trim()) {
              setLocal('Indicá el nombre de la caja.')
              return
            }
            setLocal(null)
            onSave({ nombre: nombre.trim(), activa: activa === 'activo' })
          }}
        />
      }
    >
      {local || error ? (
        <p role="alert" className="text-sm text-destructive">
          {local || error}
        </p>
      ) : null}
      <FormField label="Caja" htmlFor="caja-nombre">
        <Input id="caja-nombre" value={nombre} onChange={(event) => setNombre(event.target.value)} />
      </FormField>
      <EstadoField
        id="caja-estado"
        value={activa}
        onChange={(value) => setActiva(value)}
      />
    </FormLayout>
  )
}

export function DocumentosPanel() {
  const query = useDocumentos()
  const save = useSaveDocumento()
  const filas: Fila[] = (query.data ?? []).map((row) => ({
    id: row.id,
    nombre: row.nombre,
    estado: row.estado,
    detalle: row.codigo,
  }))
  const seleccion = useSeleccion(query.data ?? [])
  const actual = seleccion.selected

  return (
    <ListaCatalogo
      filas={filas}
      cargando={query.isLoading}
      error={query.isError ? (query.error as Error).message : null}
      columns={[
        { key: 'detalle', header: 'Código', className: 'w-24' },
        { key: 'nombre', header: 'Documento' },
        { key: 'estado', header: 'Estado', className: 'w-24' },
      ]}
      vacio="Todavía no hay documentos."
      selectedId={actual?.id}
      onSelect={(row) => seleccion.elegir(row.id)}
      onNew={seleccion.crear}
      renderCell={(row, key) =>
        key === 'estado' ? <StatusBadge status={row.estado} /> : row[key as 'nombre' | 'detalle']
      }
      formulario={
        <DocumentoForm
          key={actual?.id ?? 'nuevo'}
          codigoInicial={actual?.codigo ?? ''}
          nombreInicial={actual?.nombre ?? ''}
          estadoInicial={actual?.estado ?? 'activo'}
          nuevo={!actual}
          guardando={save.isPending}
          error={save.isError ? (save.error as Error).message : null}
          onSave={(input) =>
            save.mutate(
              { id: actual?.id ?? null, input },
              { onSuccess: (id) => seleccion.elegir(id) },
            )
          }
        />
      }
    />
  )
}

function DocumentoForm({
  codigoInicial,
  nombreInicial,
  estadoInicial,
  nuevo,
  guardando,
  error,
  onSave,
}: {
  codigoInicial: string
  nombreInicial: string
  estadoInicial: EstadoRegistro
  nuevo: boolean
  guardando: boolean
  error: string | null
  onSave: (input: { codigo: string; nombre: string; estado: EstadoRegistro }) => void
}) {
  const [codigo, setCodigo] = useState(codigoInicial)
  const [nombre, setNombre] = useState(nombreInicial)
  const [estado, setEstado] = useState(estadoInicial)
  const [local, setLocal] = useState<string | null>(null)

  return (
    <FormLayout
      columns={1}
      footer={
        <Acciones
          guardando={guardando}
          nuevo={nuevo}
          onSubmit={() => {
            if (!codigo.trim() || !nombre.trim()) {
              setLocal('Indicá el código y el nombre del documento.')
              return
            }
            setLocal(null)
            onSave({
              codigo: codigo.trim().toUpperCase(),
              nombre: nombre.trim(),
              estado,
            })
          }}
        />
      }
    >
      {local || error ? (
        <p role="alert" className="text-sm text-destructive">
          {local || error}
        </p>
      ) : null}
      <FormField label="Código" htmlFor="doc-codigo">
        <Input id="doc-codigo" value={codigo} onChange={(event) => setCodigo(event.target.value)} />
      </FormField>
      <FormField label="Documento" htmlFor="doc-nombre">
        <Input id="doc-nombre" value={nombre} onChange={(event) => setNombre(event.target.value)} />
      </FormField>
      <EstadoField id="doc-estado" value={estado} onChange={setEstado} />
    </FormLayout>
  )
}

function EstadoField({
  id,
  value,
  onChange,
}: {
  id: string
  value: EstadoRegistro
  onChange: (value: EstadoRegistro) => void
}) {
  return (
    <FormField label="Estado" htmlFor={id}>
      <Select
        id={id}
        value={value}
        onChange={(event) => onChange(event.target.value as EstadoRegistro)}
      >
        <option value="activo">Activo</option>
        <option value="inactivo">Inactivo</option>
      </Select>
    </FormField>
  )
}
