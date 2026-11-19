import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
import {
  calleFormSchema,
  toCallePayload,
  type CalleFormValues,
  type CallePayload,
} from '@/modules/catalogo/schemas'
import type { CalleListItem } from '@/modules/catalogo/api'
import type { CatSector } from '@/shared/types/database'

const empty: CalleFormValues = { sector_id: '', nombre: '', referencia: '' }

export interface CalleFormProps {
  initial?: CalleListItem | null
  sectores: CatSector[]
  submitting?: boolean
  onSubmit: (payload: CallePayload) => void
}

export function CalleForm({ initial, sectores, submitting, onSubmit }: CalleFormProps) {
  const form = useForm<CalleFormValues>({
    resolver: zodResolver(calleFormSchema),
    defaultValues: initial
      ? {
          sector_id: initial.sector_id ?? '',
          nombre: initial.nombre,
          referencia: initial.referencia ?? '',
        }
      : empty,
  })

  return (
    <form
      onSubmit={form.handleSubmit((values) => onSubmit(toCallePayload(values)))}
      noValidate
    >
      <FormLayout
        columns={1}
        footer={
          <Button type="submit" disabled={submitting}>
            {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
            {initial ? 'Guardar cambios' : 'Registrar calle'}
          </Button>
        }
      >
        <FormField
          label="Sector"
          htmlFor="sector_id"
          error={form.formState.errors.sector_id?.message}
        >
          <Select id="sector_id" {...form.register('sector_id')}>
            <option value="">Seleccionar sector</option>
            {sectores.map((sector) => (
              <option key={sector.id} value={sector.id}>
                {sector.codigo} · {sector.nombre}
              </option>
            ))}
          </Select>
        </FormField>
        <FormField label="Nombre" htmlFor="nombre" error={form.formState.errors.nombre?.message}>
          <Input id="nombre" {...form.register('nombre')} />
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
