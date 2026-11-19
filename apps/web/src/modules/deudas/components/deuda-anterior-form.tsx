import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useState } from 'react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { DataTable } from '@/design-system/organisms'
import { FormLayout } from '@/design-system/templates'
import {
  MESES,
  categoriaLabel,
  formatMoney,
  formatVolume,
  mesLabel,
  moneyInput,
  montoSugerido,
  predioLabel,
  titularLabel,
  todayIso,
} from '@/modules/deudas/labels'
import {
  deudaAnteriorFormSchema,
  prepareDeudaAnterior,
  type DeudaAnteriorFormValues,
  type DeudaAnteriorPayload,
} from '@/modules/deudas/schemas'
import type { CostoTarifaOption, PredioDeudaOption, TarifaAnio } from '@/modules/deudas/types'

function tarifaHint(costo: CostoTarifaOption | null, yearWithoutCosts: boolean) {
  if (costo) {
    return `Valor de tarifa ${formatMoney(costo.valor)} · monto de catálogo ${formatMoney(costo.monto)}`
  }
  if (yearWithoutCosts) return 'Este año no tiene tipos de tarifa con costo.'
  return undefined
}

function volumenMontoHint(costo: CostoTarifaOption | null) {
  if (costo?.categoria === 'volumen' && Number(costo.monto) === 0) {
    return 'El monto se calcula como valor de tarifa por el volumen.'
  }
  return undefined
}

type DeudaPendiente = DeudaAnteriorPayload & {
  localId: string
  servicioNombre: string
}

const pendientesColumns = [
  { key: 'periodo', header: 'Periodo' },
  { key: 'servicio', header: 'Tipo de servicio' },
  { key: 'monto', header: 'Monto', className: 'text-right' },
  { key: 'volumen', header: 'Volumen', className: 'text-right' },
  { key: 'mora', header: 'Mora', className: 'text-right' },
  { key: 'quitar', header: '', className: 'w-20 text-right' },
]

export interface DeudaAnteriorFormProps {
  predio: PredioDeudaOption
  tarifas: TarifaAnio[]
  costos: CostoTarifaOption[]
  registradas: Array<{ anio: number; mes: number; tipo_servicio_id: string }>
  submitting?: boolean
  onSubmit: (payloads: DeudaAnteriorPayload[]) => void
}

export function DeudaAnteriorForm({
  predio,
  tarifas,
  costos,
  registradas,
  submitting,
  onSubmit,
}: DeudaAnteriorFormProps) {
  const tarifaInicial = tarifas.find((tarifa) => tarifa.activa) ?? tarifas[0]
  const anioInicial = tarifaInicial ? String(tarifaInicial.anio) : ''
  const costoInicial = costos.find((costo) => String(costo.anio) === anioInicial)
  const form = useForm<DeudaAnteriorFormValues>({
    resolver: zodResolver(deudaAnteriorFormSchema),
    defaultValues: {
      predio_id: predio.id,
      anio: anioInicial,
      mes: String(new Date().getMonth() + 1),
      tipo_servicio_id: costoInicial?.tipo_servicio_id ?? '',
      monto: costoInicial ? montoSugerido(costoInicial, '0') : '',
      interes: '0.00',
      volumen: '0',
      fecha_registro: todayIso(),
      concepto: '',
    },
  })
  const [pendientes, setPendientes] = useState<DeudaPendiente[]>([])

  const anio = form.watch('anio')
  const tipoId = form.watch('tipo_servicio_id')
  const monto = form.watch('monto')
  const interes = form.watch('interes')
  const costosAnio = costos.filter((costo) => String(costo.anio) === anio)
  const costo = costosAnio.find((item) => item.tipo_servicio_id === tipoId) ?? null
  const total = (Number(monto) || 0) + (Number(interes) || 0)
  const blocked = !predio.id || tarifas.length === 0 || costosAnio.length === 0
  const tipoHint = tarifaHint(costo, costosAnio.length === 0)
  const volumenHint = volumenMontoHint(costo)
  const montoPendiente = pendientes.reduce((sum, row) => sum + row.monto, 0)
  const moraPendiente = pendientes.reduce((sum, row) => sum + row.interes, 0)

  function aplicarCosto(next: CostoTarifaOption | undefined, volumen: string) {
    if (!next) {
      form.setValue('tipo_servicio_id', '')
      form.setValue('monto', '')
      return
    }
    form.setValue('tipo_servicio_id', next.tipo_servicio_id)
    form.setValue('monto', montoSugerido(next, volumen))
  }

  return (
    <form
      onSubmit={form.handleSubmit((values) => {
        const result = prepareDeudaAnterior(values, tarifas, costos, [...registradas, ...pendientes])
        if ('message' in result) {
          form.setError(result.field, { message: result.message })
          return
        }
        const servicioNombre =
          costos.find(
            (item) =>
              item.tipo_servicio_id === result.payload.tipo_servicio_id && item.anio === result.payload.anio,
          )?.servicio_nombre ?? 'Servicio'
        setPendientes((rows) => [
          ...rows,
          { ...result.payload, localId: crypto.randomUUID(), servicioNombre },
        ])
        form.clearErrors()
      })}
      noValidate
    >
      <FormLayout
        columns={1}
        footer={
          <>
            <Button type="submit" variant="outline" disabled={submitting || blocked}>
              Agregar deuda
            </Button>
            <Button
              type="button"
              disabled={submitting || pendientes.length === 0}
              onClick={() =>
                onSubmit(
                  pendientes.map((row) => ({
                    predio_id: row.predio_id,
                    tarifa_id: row.tarifa_id,
                    tipo_servicio_id: row.tipo_servicio_id,
                    anio: row.anio,
                    mes: row.mes,
                    monto: row.monto,
                    interes: row.interes,
                    saldo: row.saldo,
                    volumen: row.volumen,
                    fecha_registro: row.fecha_registro,
                    concepto: row.concepto,
                  })),
                )
              }
            >
              {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
              Grabar {pendientes.length === 1 ? '1 deuda' : `${pendientes.length} deudas`}
            </Button>
          </>
        }
      >
        <input type="hidden" {...form.register('predio_id')} />
        <div className="rounded-md border border-border bg-muted/40 p-3 text-sm">
          <p className="font-medium text-foreground">{titularLabel(predio.usuario)}</p>
          <p className="text-muted-foreground">{predioLabel(predio)}</p>
          {predio.usuario?.dni ? <p className="text-muted-foreground">DNI {predio.usuario.dni}</p> : null}
        </div>
        {tarifas.length === 0 ? (
          <p className="text-sm text-muted-foreground">
            Cargá al menos una tarifa anual para registrar deudas anteriores.
          </p>
        ) : null}
        <FormField label="Año de tarifa" htmlFor="anio" error={form.formState.errors.anio?.message}>
          <Select
            id="anio"
            {...form.register('anio', {
              onChange: (event) => {
                const year = String(event.target.value)
                const delAnio = costos.filter((item) => String(item.anio) === year)
                const current = form.getValues('tipo_servicio_id')
                const next = delAnio.find((item) => item.tipo_servicio_id === current) ?? delAnio[0]
                aplicarCosto(next, form.getValues('volumen'))
              },
            })}
          >
            {tarifas.map((tarifa) => (
              <option key={tarifa.id} value={String(tarifa.anio)}>
                {tarifa.anio} · {tarifa.nombre}
              </option>
            ))}
          </Select>
        </FormField>
        <FormField label="Mes" htmlFor="mes" error={form.formState.errors.mes?.message}>
          <Select id="mes" {...form.register('mes')}>
            {MESES.map((mes) => (
              <option key={mes.value} value={mes.value}>
                {mes.label}
              </option>
            ))}
          </Select>
        </FormField>
        <FormField
          label="Tipo de servicio"
          htmlFor="tipo_servicio_id"
          error={form.formState.errors.tipo_servicio_id?.message}
          hint={tipoHint}
        >
          <Select
            id="tipo_servicio_id"
            {...form.register('tipo_servicio_id', {
              onChange: (event) => {
                const next = costosAnio.find((item) => item.tipo_servicio_id === event.target.value)
                if (!next) return
                form.setValue('monto', montoSugerido(next, form.getValues('volumen')))
              },
            })}
          >
            {costosAnio.length === 0 ? <option value="">Sin tipos de tarifa</option> : null}
            {costosAnio.map((item) => (
              <option key={item.id} value={item.tipo_servicio_id}>
                {item.servicio_nombre} · {categoriaLabel(item.categoria)}
              </option>
            ))}
          </Select>
        </FormField>
        <FormField
          label="Volumen m³"
          htmlFor="volumen"
          error={form.formState.errors.volumen?.message}
          hint={volumenHint}
        >
          <Input
            id="volumen"
            inputMode="decimal"
            {...form.register('volumen', {
              onChange: (event) => {
                if (!costo || costo.categoria !== 'volumen' || Number(costo.monto) !== 0) return
                form.setValue('monto', moneyInput(Number(costo.valor) * (Number(event.target.value) || 0)))
              },
            })}
          />
        </FormField>
        <FormField label="Monto S/." htmlFor="monto" error={form.formState.errors.monto?.message}>
          <Input id="monto" inputMode="decimal" {...form.register('monto')} />
        </FormField>
        <FormField label="Mora S/." htmlFor="interes" error={form.formState.errors.interes?.message}>
          <Input id="interes" inputMode="decimal" {...form.register('interes')} />
        </FormField>
        <p className="text-sm text-foreground">Total {formatMoney(total)}</p>
        <FormField
          label="Fecha de registro"
          htmlFor="fecha_registro"
          error={form.formState.errors.fecha_registro?.message}
        >
          <Input id="fecha_registro" type="date" {...form.register('fecha_registro')} />
        </FormField>
        <FormField
          label="Descripción"
          htmlFor="concepto"
          error={form.formState.errors.concepto?.message}
          hint="Opcional. Si la dejás vacía, el listado muestra el tipo de tarifa."
        >
          <Input id="concepto" {...form.register('concepto')} />
        </FormField>
        <div className="space-y-2">
          <div className="flex items-baseline justify-between gap-3">
            <h3 className="text-sm font-medium text-foreground">Deudas por grabar</h3>
            {pendientes.length > 0 ? (
              <p className="text-xs text-muted-foreground">
                {pendientes.length} {pendientes.length === 1 ? 'línea' : 'líneas'} · Total{' '}
                {formatMoney(montoPendiente + moraPendiente)}
              </p>
            ) : null}
          </div>
          {pendientes.length > 0 ? (
            <p className="text-xs text-muted-foreground">
              Todavía no están en el predio. Grabá para registrarlas todas, o quitá una línea si no corresponde.
            </p>
          ) : (
            <p className="text-xs text-muted-foreground">
              Agregá deudas de distinto año, mes y tipo de servicio. Al final se graban juntas en el predio.
            </p>
          )}
          <DataTable
            columns={pendientesColumns}
            rows={pendientes}
            rowKey={(row) => row.localId}
            emptyMessage="Todavía no agregaste deudas."
            renderCell={(row, key) => {
              if (key === 'periodo') return `${mesLabel(row.mes)} ${row.anio}`
              if (key === 'servicio') return row.servicioNombre
              if (key === 'monto') return <span className="tabular-nums">{formatMoney(row.monto)}</span>
              if (key === 'volumen') return <span className="tabular-nums">{formatVolume(row.volumen)}</span>
              if (key === 'mora') return <span className="tabular-nums">{formatMoney(row.interes)}</span>
              return (
                <Button
                  type="button"
                  variant="outline"
                  size="sm"
                  className="h-7 px-2"
                  disabled={submitting}
                  onClick={() => setPendientes((rows) => rows.filter((item) => item.localId !== row.localId))}
                >
                  Quitar
                </Button>
              )
            }}
          />
          {pendientes.length > 0 ? (
            <p className="text-sm text-foreground">
              Monto {formatMoney(montoPendiente)} · Mora {formatMoney(moraPendiente)} · Total{' '}
              {formatMoney(montoPendiente + moraPendiente)}
            </p>
          ) : null}
        </div>
      </FormLayout>
    </form>
  )
}
