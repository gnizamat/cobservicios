import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
import type { ControlListItem } from '@/modules/lecturas/api'
import { MESES, currentPeriod, formatVolume, timeInput, volumeInput } from '@/modules/lecturas/labels'
import {
  controlFormSchema,
  toControlPayload,
  type ControlFormValues,
  type ControlPayload,
} from '@/modules/lecturas/schemas'
import type { HidEstructura } from '@/shared/types/database'

export interface ControlFormProps {
  initial?: ControlListItem | null
  estructuras: HidEstructura[]
  submitting?: boolean
  onSubmit: (payload: ControlPayload) => void
}

function withEstructura(options: HidEstructura[], current: ControlListItem['estructura']) {
  if (!current || options.some((item) => item.id === current.id)) return options
  return [{ ...current, created_at: '' }, ...options]
}

export function ControlForm({ initial, estructuras, submitting, onSubmit }: ControlFormProps) {
  const period = currentPeriod()
  const options = withEstructura(estructuras, initial?.estructura ?? null)
  const form = useForm<ControlFormValues>({
    resolver: zodResolver(controlFormSchema),
    defaultValues: initial
      ? {
          estructura_id: initial.estructura_id,
          anio: String(initial.anio),
          mes: String(initial.mes),
          fecha_lectura: initial.fecha_lectura,
          hora_inicio: timeInput(initial.hora_inicio),
          hora_fin: timeInput(initial.hora_fin),
          lectura_inicial: volumeInput(initial.lectura_inicial),
          lectura_final: volumeInput(initial.lectura_final),
          cloro_inicial: volumeInput(initial.cloro_inicial),
          cloro_final: volumeInput(initial.cloro_final),
          referencia: initial.referencia,
        }
      : {
          estructura_id: options[0]?.id ?? '',
          anio: period.anio,
          mes: period.mes,
          fecha_lectura: period.fecha,
          hora_inicio: '08:00',
          hora_fin: '10:00',
          lectura_inicial: '',
          lectura_final: '',
          cloro_inicial: '0',
          cloro_final: '0',
          referencia: '',
        },
  })
  const lecturaInicial = Number(form.watch('lectura_inicial') || 0)
  const lecturaFinal = Number(form.watch('lectura_final') || 0)
  const volumen =
    Number.isFinite(lecturaInicial) && Number.isFinite(lecturaFinal)
      ? Math.max(0, lecturaFinal - lecturaInicial)
      : 0

  return (
    <form onSubmit={form.handleSubmit((values) => onSubmit(toControlPayload(values)))} noValidate>
      <FormLayout
        columns={1}
        footer={
          <Button type="submit" disabled={submitting || options.length === 0}>
            {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
            {initial ? 'Guardar cambios' : 'Registrar control'}
          </Button>
        }
      >
        <FormField
          label="Estructura"
          htmlFor="estructura_id"
          error={form.formState.errors.estructura_id?.message}
        >
          <Select id="estructura_id" {...form.register('estructura_id')}>
            {options.map((estructura) => (
              <option key={estructura.id} value={estructura.id}>
                {estructura.codigo} · {estructura.nombre}
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
          label="Fecha"
          htmlFor="fecha_lectura"
          error={form.formState.errors.fecha_lectura?.message}
        >
          <Input id="fecha_lectura" type="date" {...form.register('fecha_lectura')} />
        </FormField>
        <FormField
          label="Hora inicio"
          htmlFor="hora_inicio"
          error={form.formState.errors.hora_inicio?.message}
        >
          <Input id="hora_inicio" type="time" {...form.register('hora_inicio')} />
        </FormField>
        <FormField label="Hora fin" htmlFor="hora_fin" error={form.formState.errors.hora_fin?.message}>
          <Input id="hora_fin" type="time" {...form.register('hora_fin')} />
        </FormField>
        <FormField
          label="Lectura inicial"
          htmlFor="lectura_inicial"
          error={form.formState.errors.lectura_inicial?.message}
        >
          <Input id="lectura_inicial" inputMode="decimal" {...form.register('lectura_inicial')} />
        </FormField>
        <FormField
          label="Lectura final"
          htmlFor="lectura_final"
          error={form.formState.errors.lectura_final?.message}
        >
          <Input id="lectura_final" inputMode="decimal" {...form.register('lectura_final')} />
        </FormField>
        <FormField label="Volumen m³" htmlFor="volumen_m3" hint="Lectura final menos lectura inicial.">
          <Input id="volumen_m3" value={formatVolume(volumen)} readOnly />
        </FormField>
        <FormField
          label="Cloro inicial"
          htmlFor="cloro_inicial"
          error={form.formState.errors.cloro_inicial?.message}
        >
          <Input id="cloro_inicial" inputMode="decimal" {...form.register('cloro_inicial')} />
        </FormField>
        <FormField
          label="Cloro final"
          htmlFor="cloro_final"
          error={form.formState.errors.cloro_final?.message}
        >
          <Input id="cloro_final" inputMode="decimal" {...form.register('cloro_final')} />
        </FormField>
        <FormField
          label="Referencia"
          htmlFor="referencia"
          error={form.formState.errors.referencia?.message}
        >
          <Input id="referencia" {...form.register('referencia')} />
        </FormField>
      </FormLayout>
    </form>
  )
}
