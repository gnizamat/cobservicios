import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
import {
  tarifaFormSchema,
  toTarifaPayload,
  type TarifaFormValues,
  type TarifaPayload,
} from '@/modules/catalogo/schemas'
import type { CatTarifa } from '@/shared/types/database'

const empty: TarifaFormValues = {
  anio: '',
  nombre: '',
  modalidad: 'Contraentrega',
  unidad_recaudacion: 'Soles por metro cúbico (S/. * m3)',
  activa: 'inactiva',
}

export interface TarifaFormProps {
  initial?: CatTarifa | null
  submitting?: boolean
  onSubmit: (payload: TarifaPayload) => void
}

export function TarifaForm({ initial, submitting, onSubmit }: TarifaFormProps) {
  const form = useForm<TarifaFormValues>({
    resolver: zodResolver(tarifaFormSchema),
    defaultValues: initial
      ? {
          anio: String(initial.anio),
          nombre: initial.nombre,
          modalidad: initial.modalidad,
          unidad_recaudacion: initial.unidad_recaudacion,
          activa: initial.activa ? 'activa' : 'inactiva',
        }
      : empty,
  })

  return (
    <form
      onSubmit={form.handleSubmit((values) => onSubmit(toTarifaPayload(values)))}
      noValidate
    >
      <FormLayout
        columns={1}
        footer={
          <Button type="submit" disabled={submitting}>
            {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
            {initial ? 'Guardar cambios' : 'Registrar tarifa'}
          </Button>
        }
      >
        <FormField label="Año" htmlFor="anio" error={form.formState.errors.anio?.message}>
          <Input id="anio" inputMode="numeric" maxLength={4} {...form.register('anio')} />
        </FormField>
        <FormField label="Nombre" htmlFor="nombre" error={form.formState.errors.nombre?.message}>
          <Input id="nombre" {...form.register('nombre')} />
        </FormField>
        <FormField
          label="Modalidad"
          htmlFor="modalidad"
          error={form.formState.errors.modalidad?.message}
        >
          <Input id="modalidad" {...form.register('modalidad')} />
        </FormField>
        <FormField
          label="Unidad de recaudación"
          htmlFor="unidad_recaudacion"
          error={form.formState.errors.unidad_recaudacion?.message}
        >
          <Input id="unidad_recaudacion" {...form.register('unidad_recaudacion')} />
        </FormField>
        <FormField label="Estado" htmlFor="activa" error={form.formState.errors.activa?.message}>
          <Select id="activa" {...form.register('activa')}>
            <option value="activa">Activa</option>
            <option value="inactiva">Inactiva</option>
          </Select>
        </FormField>
      </FormLayout>
    </form>
  )
}
