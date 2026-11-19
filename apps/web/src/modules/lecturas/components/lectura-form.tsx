import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
import type { LecturaListItem, PredioOption, ServicioOption, ValorM3Activo } from '@/modules/lecturas/api'
import {
  MESES,
  currentPeriod,
  formatMoney,
  formatVolume,
  periodoLabel,
  predioOptionLabel,
  roundMoney,
  ultimaLecturaAntes,
  volumeInput,
  volumenPorDiferencia,
} from '@/modules/lecturas/labels'
import {
  lecturaFormSchema,
  toLecturaPayload,
  type LecturaFormValues,
  type LecturaPayload,
} from '@/modules/lecturas/schemas'

export interface LecturaFormProps {
  initial?: LecturaListItem | null
  predios: PredioOption[]
  servicios: ServicioOption[]
  lecturas: LecturaListItem[]
  valoresM3?: ValorM3Activo[]
  historialListo?: boolean
  predioId?: string | null
  submitting?: boolean
  onRegisterMeter?: (predioId: string) => void
  onSubmit: (payload: LecturaPayload) => void
}

function withOption<T extends { id: string }>(options: T[], current: T | null | undefined) {
  if (!current || options.some((item) => item.id === current.id)) return options
  return [current, ...options]
}

export function LecturaForm({
  initial,
  predios,
  servicios,
  lecturas,
  valoresM3 = [],
  historialListo = true,
  predioId,
  submitting,
  onRegisterMeter,
  onSubmit,
}: LecturaFormProps) {
  const period = currentPeriod()
  const predioOptions = withOption(predios, initial?.predio)
  const servicioOptions = withOption(servicios, initial?.servicio)
  const blocked = predioOptions.length === 0 || servicioOptions.length === 0
  const form = useForm<LecturaFormValues>({
    resolver: zodResolver(lecturaFormSchema),
    defaultValues: initial
      ? {
          predio_id: initial.predio_id,
          tipo_servicio_id: initial.tipo_servicio_id,
          anio: String(initial.anio),
          mes: String(initial.mes),
          fecha_lectura: initial.fecha_lectura,
          lectura_m3: volumeInput(initial.lectura_m3),
          lectura_lt: volumeInput(initial.lectura_lt),
          referencia: initial.referencia,
        }
      : {
          predio_id: predioId ?? predioOptions[0]?.id ?? '',
          tipo_servicio_id:
            servicioOptions.find((servicio) => servicio.codigo === 'VOL')?.id ??
            servicioOptions[0]?.id ??
            '',
          anio: period.anio,
          mes: period.mes,
          fecha_lectura: period.fecha,
          lectura_m3: '',
          lectura_lt: '0',
          referencia: '',
        },
  })
  const chosenId = form.watch('predio_id')
  const servicioId = form.watch('tipo_servicio_id')
  const anio = Number(form.watch('anio'))
  const mes = Number(form.watch('mes'))
  const lecturaM3Raw = form.watch('lectura_m3')
  const lecturaLtRaw = form.watch('lectura_lt')
  const sinMedidor = !predioOptions.find((predio) => predio.id === chosenId)?.medidor
  const periodoValido = Number.isInteger(anio) && anio >= 1000 && mes >= 1 && mes <= 12
  const ultima =
    historialListo && periodoValido
      ? ultimaLecturaAntes(lecturas, {
          predioId: chosenId,
          servicioId,
          anio,
          mes,
          excludeId: initial?.id,
        })
      : null
  const lecturaM3 = Number(lecturaM3Raw)
  const lecturaLt = lecturaLtRaw.trim() === '' ? 0 : Number(lecturaLtRaw)
  const lecturaLista =
    lecturaM3Raw.trim() !== '' && Number.isFinite(lecturaM3) && Number.isFinite(lecturaLt)
  const volumen =
    historialListo && lecturaLista
      ? volumenPorDiferencia(
          lecturaM3,
          lecturaLt,
          Number(ultima?.lectura_m3 ?? 0),
          Number(ultima?.lectura_lt ?? 0),
        )
      : null
  const volumenValido = volumen != null && volumen >= 0
  const tarifaAnio = Number.isInteger(anio) ? valoresM3.find((item) => item.anio === anio) ?? null : null
  const importe =
    volumenValido && tarifaAnio && tarifaAnio.valor > 0 ? roundMoney(volumen * tarifaAnio.valor) : null
  const sinTarifa = Boolean(volumenValido && volumen > 0 && importe == null)
  const lecturaMenor = volumen != null && volumen < 0
  const lecturaError = lecturaMenor
    ? `La lectura es menor que la última registrada (${formatVolume(ultima?.lectura_m3 ?? 0)} m³).`
    : form.formState.errors.lectura_m3?.message

  return (
    <form
      onSubmit={form.handleSubmit((values) => {
        if (!predioOptions.find((predio) => predio.id === values.predio_id)?.medidor) return
        if (!volumenValido || volumen == null) return
        onSubmit(toLecturaPayload(values, volumen))
      })}
      noValidate
    >
      <FormLayout
        columns={1}
        footer={
          <Button
            type="submit"
            disabled={submitting || blocked || sinMedidor || !historialListo || lecturaMenor || sinTarifa}
          >
            {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
            {initial ? 'Guardar cambios' : 'Registrar lectura'}
          </Button>
        }
      >
        {blocked ? (
          <p className="text-sm text-muted-foreground">
            Hace falta al menos un predio activo y un tipo de servicio para registrar la lectura.
          </p>
        ) : null}
        {sinMedidor && !blocked ? (
          <div className="space-y-2 rounded-md border border-border bg-muted/40 p-3">
            <p className="text-sm text-foreground">
              Este predio no tiene un medidor asignado. Registralo para poder guardar la lectura.
            </p>
            {onRegisterMeter ? (
              <Button type="button" size="sm" variant="outline" onClick={() => onRegisterMeter(chosenId)}>
                Registrar medidor
              </Button>
            ) : null}
          </div>
        ) : null}
        <FormField label="Predio" htmlFor="predio_id" error={form.formState.errors.predio_id?.message}>
          <Select id="predio_id" {...form.register('predio_id')}>
            {predioOptions.map((predio) => (
              <option key={predio.id} value={predio.id}>
                {predioOptionLabel(predio)}
              </option>
            ))}
          </Select>
        </FormField>
        <FormField
          label="Servicio"
          htmlFor="tipo_servicio_id"
          error={form.formState.errors.tipo_servicio_id?.message}
        >
          <Select id="tipo_servicio_id" {...form.register('tipo_servicio_id')}>
            {servicioOptions.map((servicio) => (
              <option key={servicio.id} value={servicio.id}>
                {servicio.codigo} · {servicio.nombre}
              </option>
            ))}
          </Select>
        </FormField>
        <FormField label="Año" htmlFor="anio" error={form.formState.errors.anio?.message}>
          <Input id="anio" inputMode="numeric" {...form.register('anio')} />
        </FormField>
        <FormField label="Mes" htmlFor="mes" error={form.formState.errors.mes?.message}>
          <Select id="mes" {...form.register('mes')}>
            {MESES.map((item) => (
              <option key={item.value} value={item.value}>
                {item.label}
              </option>
            ))}
          </Select>
        </FormField>
        <FormField
          label="Fecha de lectura"
          htmlFor="fecha_lectura"
          error={form.formState.errors.fecha_lectura?.message}
        >
          <Input id="fecha_lectura" type="date" {...form.register('fecha_lectura')} />
        </FormField>
        <FormField
          label="Última lectura m³"
          htmlFor="ultima_lectura"
          hint={
            !historialListo
              ? 'No se pudo consultar la última lectura.'
              : ultima
                ? `${periodoLabel(ultima.anio, ultima.mes)}${Number(ultima.lectura_lt) > 0 ? ` · ${formatVolume(ultima.lectura_lt)} L` : ''}.`
                : 'No hay una lectura anterior para este predio y servicio. Se toma 0.'
          }
        >
          <Input
            id="ultima_lectura"
            value={ultima ? formatVolume(ultima.lectura_m3) : '0.00'}
            readOnly
            tabIndex={-1}
            className="bg-muted tabular-nums"
          />
        </FormField>
        <FormField
          label="Lectura m³"
          htmlFor="lectura_m3"
          hint="Índice actual del medidor."
          error={lecturaError}
        >
          <Input id="lectura_m3" inputMode="decimal" {...form.register('lectura_m3')} />
        </FormField>
        <FormField
          label="Lectura litros"
          htmlFor="lectura_lt"
          error={form.formState.errors.lectura_lt?.message}
        >
          <Input id="lectura_lt" inputMode="decimal" {...form.register('lectura_lt')} />
        </FormField>
        <FormField
          label="Volumen m³"
          htmlFor="volumen_m3"
          hint={
            lecturaMenor
              ? 'La diferencia no puede ser negativa.'
              : ultima
                ? 'Lectura nueva menos la última lectura registrada.'
                : 'Sin lectura anterior, el volumen es la lectura ingresada.'
          }
        >
          <Input
            id="volumen_m3"
            value={volumenValido ? formatVolume(volumen) : ''}
            readOnly
            tabIndex={-1}
            className="bg-muted tabular-nums"
          />
        </FormField>
        <FormField
          label="Referencia S/."
          htmlFor="referencia_soles"
          hint={
            sinTarifa
              ? `No hay tarifa de volumen para ${anio}.`
              : tarifaAnio
                ? volumenValido
                  ? volumen > 0
                    ? `${formatVolume(volumen)} m³ × ${formatMoney(tarifaAnio.valor)} · ${tarifaAnio.nombre}. Este importe se graba como deuda.`
                    : 'Sin consumo no se genera deuda.'
                  : `${tarifaAnio.nombre}: ${formatMoney(tarifaAnio.valor)} por m³.`
                : 'No hay tarifa de volumen para el año de la lectura.'
          }
        >
          <Input
            id="referencia_soles"
            value={importe != null ? formatMoney(importe) : ''}
            readOnly
            tabIndex={-1}
            className="bg-muted tabular-nums"
          />
        </FormField>
        <FormField
          label="Referencia"
          htmlFor="referencia"
          hint="Nota opcional."
          error={form.formState.errors.referencia?.message}
        >
          <Input id="referencia" {...form.register('referencia')} />
        </FormField>
      </FormLayout>
    </form>
  )
}
