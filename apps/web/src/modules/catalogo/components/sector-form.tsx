import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
import {
  sectorFormSchema,
  toSectorPayload,
  type SectorFormValues,
  type SectorPayload,
} from '@/modules/catalogo/schemas'
import type { CatSector } from '@/shared/types/database'

const empty: SectorFormValues = { codigo: '', nombre: '' }

export interface SectorFormProps {
  initial?: CatSector | null
  submitting?: boolean
  onSubmit: (payload: SectorPayload) => void
}

export function SectorForm({ initial, submitting, onSubmit }: SectorFormProps) {
  const form = useForm<SectorFormValues>({
    resolver: zodResolver(sectorFormSchema),
    defaultValues: initial
      ? { codigo: initial.codigo, nombre: initial.nombre }
      : empty,
  })

  return (
    <form
      onSubmit={form.handleSubmit((values) => onSubmit(toSectorPayload(values)))}
      noValidate
    >
      <FormLayout
        columns={1}
        footer={
          <Button type="submit" disabled={submitting}>
            {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
            {initial ? 'Guardar cambios' : 'Registrar sector'}
          </Button>
        }
      >
        <FormField label="Código" htmlFor="codigo" error={form.formState.errors.codigo?.message}>
          <Input id="codigo" autoComplete="off" {...form.register('codigo')} />
        </FormField>
        <FormField label="Nombre" htmlFor="nombre" error={form.formState.errors.nombre?.message}>
          <Input id="nombre" {...form.register('nombre')} />
        </FormField>
      </FormLayout>
    </form>
  )
}
