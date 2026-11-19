import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
import { CATEGORIAS_SERVICIO } from '@/modules/catalogo/labels'
import {
  servicioFormSchema,
  toServicioPayload,
  type ServicioFormValues,
  type ServicioPayload,
} from '@/modules/catalogo/schemas'
import type { CatTipoServicio } from '@/shared/types/database'

const empty: ServicioFormValues = {
  codigo: '',
  nombre: '',
  categoria: 'fijo',
  estado: 'activo',
}

export interface ServicioFormProps {
  initial?: CatTipoServicio | null
  submitting?: boolean
  onSubmit: (payload: ServicioPayload) => void
}

export function ServicioForm({ initial, submitting, onSubmit }: ServicioFormProps) {
  const form = useForm<ServicioFormValues>({
    resolver: zodResolver(servicioFormSchema),
    defaultValues: initial
      ? {
          codigo: initial.codigo,
          nombre: initial.nombre,
          categoria: initial.categoria,
          estado: initial.estado,
        }
      : empty,
  })

  return (
    <form
      onSubmit={form.handleSubmit((values) => onSubmit(toServicioPayload(values)))}
      noValidate
    >
      <FormLayout
        columns={1}
        footer={
          <Button type="submit" disabled={submitting}>
            {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
            {initial ? 'Guardar cambios' : 'Registrar servicio'}
          </Button>
        }
      >
        <FormField label="Código" htmlFor="codigo" error={form.formState.errors.codigo?.message}>
          <Input id="codigo" autoComplete="off" {...form.register('codigo')} />
        </FormField>
        <FormField label="Nombre" htmlFor="nombre" error={form.formState.errors.nombre?.message}>
          <Input id="nombre" {...form.register('nombre')} />
        </FormField>
        <FormField
          label="Categoría"
          htmlFor="categoria"
          error={form.formState.errors.categoria?.message}
        >
          <Select id="categoria" {...form.register('categoria')}>
            {CATEGORIAS_SERVICIO.map((item) => (
              <option key={item.value} value={item.value}>
                {item.label}
              </option>
            ))}
          </Select>
        </FormField>
        <FormField label="Estado" htmlFor="estado" error={form.formState.errors.estado?.message}>
          <Select id="estado" {...form.register('estado')}>
            <option value="activo">Activo</option>
            <option value="inactivo">Inactivo</option>
          </Select>
        </FormField>
      </FormLayout>
    </form>
  )
}
