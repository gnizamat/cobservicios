import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
import type { CostoListItem } from '@/modules/catalogo/api'
import {
  amountInput,
  costoFormSchema,
  toCostoPayload,
  type CostoFormValues,
  type CostoPayload,
} from '@/modules/catalogo/schemas'
import type { CatTarifa, CatTipoServicio } from '@/shared/types/database'

const empty: CostoFormValues = {
  tarifa_id: '',
  tipo_servicio_id: '',
  valor: '0',
  monto: '0',
}

export interface CostoFormProps {
  initial?: CostoListItem | null
  tarifas: CatTarifa[]
  servicios: CatTipoServicio[]
  submitting?: boolean
  onSubmit: (payload: CostoPayload) => void
}

export function CostoForm({
  initial,
  tarifas,
  servicios,
  submitting,
  onSubmit,
}: CostoFormProps) {
  const form = useForm<CostoFormValues>({
    resolver: zodResolver(costoFormSchema),
    defaultValues: initial
      ? {
          tarifa_id: initial.tarifa_id,
          tipo_servicio_id: initial.tipo_servicio_id,
          valor: amountInput(initial.valor),
          monto: amountInput(initial.monto),
        }
      : empty,
  })

  return (
    <form
      onSubmit={form.handleSubmit((values) => onSubmit(toCostoPayload(values)))}
      noValidate
    >
      <FormLayout
        columns={1}
        footer={
          <Button type="submit" disabled={submitting}>
            {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
            {initial ? 'Guardar cambios' : 'Registrar costo'}
          </Button>
        }
      >
        <FormField
          label="Año de tarifa"
          htmlFor="tarifa_id"
          error={form.formState.errors.tarifa_id?.message}
        >
          <Select id="tarifa_id" {...form.register('tarifa_id')}>
            <option value="">Seleccionar año</option>
            {tarifas.map((tarifa) => (
              <option key={tarifa.id} value={tarifa.id}>
                {tarifa.anio} · {tarifa.nombre}
                {tarifa.activa ? ' (activa)' : ''}
              </option>
            ))}
          </Select>
        </FormField>
        <FormField
          label="Tipo de servicio"
          htmlFor="tipo_servicio_id"
          error={form.formState.errors.tipo_servicio_id?.message}
        >
          <Select id="tipo_servicio_id" {...form.register('tipo_servicio_id')}>
            <option value="">Seleccionar servicio</option>
            {servicios.map((servicio) => (
              <option key={servicio.id} value={servicio.id}>
                {servicio.codigo} · {servicio.nombre}
              </option>
            ))}
          </Select>
        </FormField>
        <FormField
          label="Valor de tarifa"
          htmlFor="valor"
          hint="Factor o valor unitario, por ejemplo S/. por m3."
          error={form.formState.errors.valor?.message}
        >
          <Input id="valor" inputMode="decimal" {...form.register('valor')} />
        </FormField>
        <FormField
          label="Monto"
          htmlFor="monto"
          hint="Al guardar un monto distinto, el cambio queda en el historial."
          error={form.formState.errors.monto?.message}
        >
          <Input id="monto" inputMode="decimal" {...form.register('monto')} />
        </FormField>
      </FormLayout>
    </form>
  )
}
