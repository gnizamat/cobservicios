import {
  ArrowLeftRight,
  FileText,
  House,
  Receipt,
  UserRound,
  Wallet,
} from 'lucide-react'
import type { ReactNode } from 'react'
import { useState } from 'react'
import { Link, useParams } from 'react-router-dom'
import { Button, Icon } from '@/design-system/atoms'
import { StatusBadge } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import { AppShell } from '@/design-system/templates'
import { useFichaUsuario } from '@/modules/usuarios/api'
import type { UsuarioFicha } from '@/modules/usuarios/api/ficha-api'
import {
  buildMovimientos,
  documentoFicha,
  formatFecha,
  formatMoney,
  formatVolume,
  medidoresLabel,
  nombreFicha,
  periodoLabel,
  sexoLabel,
  sumSaldo,
  texto,
  tipoPagoFicha,
  tipoPersonaLabel,
  ubicacionPredio,
} from '@/modules/usuarios/lib/ficha-view'
import { cn } from '@/shared/lib/utils'

const secciones = [
  { id: 'ficha', label: 'Ficha', icon: UserRound },
  { id: 'predios', label: 'Predios', icon: House },
  { id: 'deudas', label: 'Deudas', icon: Receipt },
  { id: 'pagos', label: 'Pagos', icon: Wallet },
  { id: 'facturacion', label: 'Facturación', icon: FileText },
  { id: 'movimientos', label: 'Movimientos', icon: ArrowLeftRight },
] as const

type SeccionId = (typeof secciones)[number]['id']

export function UsuarioFichaPage() {
  const { id = '' } = useParams()
  const [seccion, setSeccion] = useState<SeccionId>('ficha')
  const ficha = useFichaUsuario(id)

  return (
    <AppShell>
      {ficha.isLoading ? (
        <p className="text-sm text-muted-foreground">Cargando la ficha…</p>
      ) : ficha.isError ? (
        <p role="alert" className="text-sm text-destructive">
          {(ficha.error as Error).message}
        </p>
      ) : ficha.data ? (
        <FichaContenido
          ficha={ficha.data}
          seccion={seccion}
          onSeccion={setSeccion}
        />
      ) : null}
    </AppShell>
  )
}

function FichaContenido({
  ficha,
  seccion,
  onSeccion,
}: {
  ficha: UsuarioFicha
  seccion: SeccionId
  onSeccion: (seccion: SeccionId) => void
}) {
  const usuario = ficha.usuario
  const movimientos = buildMovimientos(ficha)
  const saldo = sumSaldo(ficha)
  const counts: Partial<Record<SeccionId, number>> = {
    predios: ficha.predios.length,
    deudas: ficha.deudas.length,
    pagos: ficha.pagos.length,
    facturacion: ficha.facturas.length,
    movimientos: movimientos.length,
  }

  return (
    <>
      <header className="mb-6 flex flex-col gap-3 sm:flex-row sm:items-start sm:justify-between">
        <div className="min-w-0">
          <div className="flex flex-wrap items-center gap-2">
            <h1 className="font-[family-name:var(--font-display)] text-2xl font-semibold tracking-tight text-foreground">
              {nombreFicha(usuario)}
            </h1>
            <StatusBadge status={usuario.estado} />
          </div>
          <p className="mt-1 text-sm text-muted-foreground">
            {tipoPersonaLabel(usuario.tipo_persona)} · {documentoFicha(usuario)}
          </p>
          <p className="mt-1 text-sm text-muted-foreground">
            {ficha.predios.length === 1 ? '1 predio' : `${ficha.predios.length} predios`}
            {' · '}
            Deuda pendiente {formatMoney(saldo)}
            {' · '}
            {ficha.facturas.length === 1 ? '1 factura' : `${ficha.facturas.length} facturas`}
          </p>
        </div>
        <div className="flex flex-wrap items-center gap-2">
          <Button asChild variant="outline" size="sm">
            <Link to="/padron/usuarios">Volver</Link>
          </Button>
          <Button asChild size="sm">
            <Link to={`/padron/usuarios/${usuario.id}/editar`}>Editar</Link>
          </Button>
        </div>
      </header>

      <div className="grid items-start gap-4 lg:grid-cols-[14rem_minmax(0,1fr)]">
        <nav aria-label="Secciones de la ficha" className="flex flex-col gap-1">
          {secciones.map((item) => {
            const active = seccion === item.id
            const count = counts[item.id]
            return (
              <button
                key={item.id}
                type="button"
                aria-current={active ? 'page' : undefined}
                onClick={() => onSeccion(item.id)}
                className={cn(
                  'flex items-center gap-2 rounded-xl px-3 py-2 text-left text-sm text-muted-foreground hover:bg-secondary hover:text-foreground',
                  active && 'bg-secondary font-medium text-foreground',
                )}
              >
                <Icon icon={item.icon} size={16} />
                <span className="min-w-0 flex-1">{item.label}</span>
                {count !== undefined ? (
                  <span className="tabular-nums text-xs text-muted-foreground">{count}</span>
                ) : null}
              </button>
            )
          })}
        </nav>

        <div className="min-w-0">
          {seccion === 'ficha' ? <SeccionFicha ficha={ficha} /> : null}
          {seccion === 'predios' ? <SeccionPredios ficha={ficha} /> : null}
          {seccion === 'deudas' ? <SeccionDeudas ficha={ficha} saldo={saldo} /> : null}
          {seccion === 'pagos' ? <SeccionPagos ficha={ficha} /> : null}
          {seccion === 'facturacion' ? <SeccionFacturas ficha={ficha} /> : null}
          {seccion === 'movimientos' ? (
            <SeccionMovimientos movimientos={movimientos} />
          ) : null}
        </div>
      </div>
    </>
  )
}

function Campo({ label, value }: { label: string; value: string }) {
  return (
    <div className="min-w-0">
      <dt className="text-[11px] font-medium tracking-wide text-muted-foreground uppercase">
        {label}
      </dt>
      <dd className="mt-0.5 text-sm text-foreground">{value}</dd>
    </div>
  )
}

function Bloque({ titulo, children }: { titulo: string; children: ReactNode }) {
  return (
    <article className="rounded-2xl border border-border bg-card p-4">
      <h2 className="mb-4 text-sm font-semibold text-foreground">{titulo}</h2>
      {children}
    </article>
  )
}

function SeccionFicha({ ficha }: { ficha: UsuarioFicha }) {
  const usuario = ficha.usuario
  return (
    <div className="grid items-start gap-4 xl:grid-cols-[minmax(0,1fr)_18rem]">
      <div className="space-y-4">
        <Bloque titulo="Datos personales">
          <dl className="grid gap-x-6 gap-y-4 sm:grid-cols-2">
            <Campo label="Tipo de persona" value={tipoPersonaLabel(usuario.tipo_persona)} />
            <Campo label="Nombres" value={texto(usuario.nombres)} />
            <Campo label="Apellido paterno" value={texto(usuario.apellido_paterno)} />
            <Campo label="Apellido materno" value={texto(usuario.apellido_materno)} />
            <Campo label="Sexo" value={sexoLabel(usuario.sexo)} />
            <Campo label="DNI" value={texto(usuario.dni)} />
            <Campo label="RUC" value={texto(usuario.ruc)} />
          </dl>
        </Bloque>
        <Bloque titulo="Contacto">
          <dl className="grid gap-x-6 gap-y-4 sm:grid-cols-2">
            <Campo label="Dirección" value={texto(usuario.direccion)} />
            <Campo label="Celular" value={texto(usuario.celular)} />
            <Campo label="Correo" value={texto(usuario.email)} />
          </dl>
        </Bloque>
      </div>
      <PrediosResumen ficha={ficha} />
    </div>
  )
}

function PrediosResumen({ ficha }: { ficha: UsuarioFicha }) {
  return (
    <article className="rounded-2xl border border-border bg-card p-4">
      <div className="mb-3 flex items-center justify-between gap-2">
        <h2 className="text-sm font-semibold text-foreground">Predios</h2>
        <span className="text-xs text-muted-foreground tabular-nums">{ficha.predios.length}</span>
      </div>
      {ficha.predios.length === 0 ? (
        <p className="text-sm text-muted-foreground">Este usuario no tiene predios.</p>
      ) : (
        <ul className="space-y-2">
          {ficha.predios.map((predio) => {
            const medidor = medidoresLabel(predio)
            return (
              <li key={predio.id}>
                <Link
                  to={`/padron/predios/${predio.id}/editar`}
                  className="block rounded-xl border border-border/80 px-3 py-2 hover:bg-secondary/40"
                >
                  <p className="truncate text-sm font-medium text-foreground">{predio.nombre}</p>
                  <p className="mt-0.5 text-xs text-muted-foreground">{ubicacionPredio(predio) || '—'}</p>
                  {medidor ? (
                    <p className="mt-1 text-xs text-muted-foreground">Medidor {medidor}</p>
                  ) : null}
                </Link>
              </li>
            )
          })}
        </ul>
      )}
    </article>
  )
}

function predioNombre(ficha: UsuarioFicha, predioId: string) {
  return ficha.predios.find((predio) => predio.id === predioId)?.nombre ?? '—'
}

function SeccionPredios({ ficha }: { ficha: UsuarioFicha }) {
  return (
    <DataTable
      columns={[
        { key: 'predio', header: 'Predio' },
        { key: 'ubicacion', header: 'Ubicación' },
        { key: 'tipo', header: 'Tipo' },
        { key: 'medidor', header: 'Medidor' },
        { key: 'estado', header: 'Estado', className: 'w-[6.5rem]' },
      ]}
      rows={ficha.predios}
      rowKey={(row) => row.id}
      emptyMessage="Este usuario no tiene predios."
      renderCell={(row, key) => {
        if (key === 'predio') {
          return (
            <Link to={`/padron/predios/${row.id}/editar`} className="font-medium hover:underline">
              {row.nombre}
            </Link>
          )
        }
        if (key === 'ubicacion') return ubicacionPredio(row) || '—'
        if (key === 'tipo') return row.tipo || '—'
        if (key === 'medidor') return medidoresLabel(row) || '—'
        if (key === 'estado') return <StatusBadge status={row.estado} />
        return null
      }}
    />
  )
}

function SeccionDeudas({ ficha, saldo }: { ficha: UsuarioFicha; saldo: number }) {
  const monto = ficha.deudas.reduce((total, deuda) => total + deuda.monto, 0)
  return (
    <div className="space-y-3">
      {ficha.deudas.length > 0 ? (
        <p className="text-sm text-muted-foreground">
          Monto {formatMoney(monto)} · Saldo pendiente {formatMoney(saldo)}
        </p>
      ) : null}
      <DataTable
        columns={[
          { key: 'periodo', header: 'Periodo' },
          { key: 'predio', header: 'Predio' },
          { key: 'concepto', header: 'Concepto' },
          { key: 'volumen', header: 'Volumen', className: 'text-right' },
          { key: 'monto', header: 'Monto', className: 'text-right' },
          { key: 'saldo', header: 'Saldo', className: 'text-right' },
        ]}
        rows={ficha.deudas}
        rowKey={(row) => row.id}
        emptyMessage="Este usuario no tiene deudas."
        renderCell={(row, key) => {
          if (key === 'periodo') return periodoLabel(row.anio, row.mes)
          if (key === 'predio') return predioNombre(ficha, row.predioId)
          if (key === 'concepto') return row.concepto || '—'
          if (key === 'volumen') {
            return (
              <span className="block text-right tabular-nums">
                {row.volumen > 0 ? formatVolume(row.volumen) : '—'}
              </span>
            )
          }
          if (key === 'monto' || key === 'saldo') {
            return (
              <span className="block text-right tabular-nums">
                {formatMoney(key === 'monto' ? row.monto : row.saldo)}
              </span>
            )
          }
          return null
        }}
      />
    </div>
  )
}

function SeccionPagos({ ficha }: { ficha: UsuarioFicha }) {
  return (
    <DataTable
      columns={[
        { key: 'fecha', header: 'Fecha' },
        { key: 'numero', header: 'Recibo' },
        { key: 'predio', header: 'Predio' },
        { key: 'tipo', header: 'Tipo' },
        { key: 'referencia', header: 'Referencia' },
        { key: 'monto', header: 'Monto', className: 'text-right' },
      ]}
      rows={ficha.pagos}
      rowKey={(row) => row.id}
      emptyMessage="Este usuario no tiene pagos registrados."
      renderCell={(row, key) => {
        if (key === 'fecha') return formatFecha(row.fecha)
        if (key === 'numero') return <span className="font-medium">{row.numero}</span>
        if (key === 'predio') return predioNombre(ficha, row.predioId)
        if (key === 'tipo') return tipoPagoFicha(row.tipoPago)
        if (key === 'referencia') return row.referencia || '—'
        if (key === 'monto') {
          return <span className="block text-right tabular-nums">{formatMoney(row.monto)}</span>
        }
        return null
      }}
    />
  )
}

function SeccionFacturas({ ficha }: { ficha: UsuarioFicha }) {
  return (
    <DataTable
      columns={[
        { key: 'numero', header: 'Número' },
        { key: 'periodo', header: 'Periodo' },
        { key: 'predio', header: 'Predio' },
        { key: 'fecha', header: 'Fecha' },
        { key: 'conceptos', header: 'Conceptos' },
        { key: 'monto', header: 'Monto', className: 'text-right' },
        { key: 'estado', header: 'Estado' },
      ]}
      rows={ficha.facturas}
      rowKey={(row) => row.id}
      emptyMessage="Este usuario no tiene facturas."
      renderCell={(row, key) => {
        if (key === 'numero') return <span className="font-medium">{row.numero}</span>
        if (key === 'periodo') return periodoLabel(row.anio, row.mes)
        if (key === 'predio') return predioNombre(ficha, row.predioId)
        if (key === 'fecha') return formatFecha(row.fecha)
        if (key === 'conceptos') return row.conceptos || '—'
        if (key === 'monto') {
          return <span className="block text-right tabular-nums">{formatMoney(row.monto)}</span>
        }
        if (key === 'estado') {
          return (
            <span className="inline-flex rounded-md bg-secondary px-1.5 py-0.5 text-[11px] font-medium text-foreground">
              {row.estado === 'generada'
                ? 'Generada'
                : row.estado === 'cobrada'
                  ? 'Cobrada'
                  : row.estado === 'anulada'
                    ? 'Anulada'
                    : row.estado}
            </span>
          )
        }
        return null
      }}
    />
  )
}

function SeccionMovimientos({
  movimientos,
}: {
  movimientos: ReturnType<typeof buildMovimientos>
}) {
  return (
    <DataTable
      columns={[
        { key: 'fecha', header: 'Fecha', className: 'w-[6.5rem]' },
        { key: 'tipo', header: 'Movimiento', className: 'w-[8rem]' },
        { key: 'predio', header: 'Predio' },
        { key: 'detalle', header: 'Detalle' },
      ]}
      rows={movimientos}
      rowKey={(row) => row.id}
      emptyMessage="Estos predios todavía no tienen movimientos."
      renderCell={(row, key) => {
        if (key === 'fecha') return formatFecha(row.fecha)
        if (key === 'tipo') return row.tipo
        if (key === 'predio') return row.predio
        if (key === 'detalle') return row.detalle
        return null
      }}
    />
  )
}
