import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
import type { PredioOption, ServicioOption, VolumenListItem } from '@/modules/lecturas/api'
import { MESES, currentPeriod, predioOptionLabel, volumeInput } from '@/modules/lecturas/labels'
import {
  toVolumenPayload,
  volumenFormSchema,
  type VolumenFormValues,
  type VolumenPayload,
} from '@/modules/lecturas/schemas'

export interface VolumenFormProps {
  initial?: VolumenListItem | null
  predios: PredioOption[]
  servicios: ServicioOption[]
  predioId?: string | null
  submitting?: boolean
  onSubmit: (payload: VolumenPayload) => void
}

function withOption<T extends { id: string }>(options: T[], current: T | null | undefined) {
  if (!current || options.some((item) => item.id === current.id)) return options
  return [current, ...options]
}

export function VolumenForm({
  initial,
  predios,
  servicios,
  predioId,
  submitting,
  onSubmit,
}: VolumenFormProps) {
  const period = currentPeriod()
  const predioOptions = withOption(predios, initial?.predio)
  const servicioOptions = withOption(servicios, initial?.servicio)
  const blocked = predioOptions.length === 0 || servicioOptions.length === 0
  const form = useForm<VolumenFormValues>({
    resolver: zodResolver(volumenFormSchema),
    defaultValues: initial
      ? {
          predio_id: initial.predio_id,
          tipo_servicio_id: initial.tipo_servicio_id,
          anio: String(initial.anio),
          mes: String(initial.mes),
          volumen_m3: volumeInput(initial.volumen_m3),
          referencia: initial.referencia,
        }
      : {
          predio_id: predioId ?? predioOptions[0]?.id ?? '',
          tipo_servicio_id: servicioOptions[0]?.id ?? '',
          anio: period.anio,
          mes: period.mes,
          volumen_m3: '',
          referencia: '',
        },
  })

  return (
    <form onSubmit={form.handleSubmit((values) => onSubmit(toVolumenPayload(values)))} noValidate>
      <FormLayout
        columns={1}
        footer={
          <Button type="submit" disabled={submitting || blocked}>
            {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
            {initial ? 'Guardar cambios' : 'Registrar volumen'}
          </Button>
        }
      >
        {blocked ? (
          <p className="text-sm text-muted-foreground">
            Hace falta al menos un predio activo y un tipo de servicio para asignar el volumen.
          </p>
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
          label="Volumen m³"
          htmlFor="volumen_m3"
          hint="Volumen asignado cuando el predio no tiene lectura de medidor."
          error={form.formState.errors.volumen_m3?.message}
        >
          <Input id="volumen_m3" inputMode="decimal" {...form.register('volumen_m3')} />
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
