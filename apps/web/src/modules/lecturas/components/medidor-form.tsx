import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
import type { MarcaMedidor, MedidorAsignado } from '@/modules/lecturas/api'
import { currentPeriod } from '@/modules/lecturas/labels'
import {
  medidorFormSchema,
  toMedidorPayload,
  type MedidorFormValues,
  type MedidorPayload,
} from '@/modules/lecturas/schemas'

export interface MedidorFormProps {
  predioId: string
  titular: string
  marcas: MarcaMedidor[]
  initial?: MedidorAsignado | null
  submitting?: boolean
  onCancel: () => void
  onSubmit: (payload: MedidorPayload) => void
}

export function MedidorForm({
  predioId,
  titular,
  marcas,
  initial,
  submitting,
  onCancel,
  onSubmit,
}: MedidorFormProps) {
  const period = currentPeriod()
  const marcasForm =
    initial?.marca_id && !marcas.some((marca) => marca.id === initial.marca_id)
      ? [{ id: initial.marca_id, nombre: initial.marca || 'Marca asignada', procedencia: '' }, ...marcas]
      : marcas
  const form = useForm<MedidorFormValues>({
    resolver: zodResolver(medidorFormSchema),
    defaultValues: initial
      ? {
          codigo: initial.codigo,
          marca_id: initial.marca_id ?? '',
          fecha_instalacion: initial.fecha_instalacion,
        }
      : {
          codigo: '',
          marca_id: '',
          fecha_instalacion: period.fecha,
        },
  })

  return (
    <form
      onSubmit={form.handleSubmit((values) => onSubmit(toMedidorPayload(predioId, values)))}
      noValidate
    >
      <FormLayout
        columns={1}
        footer={
          <div className="flex gap-2">
            <Button type="submit" disabled={submitting || marcasForm.length === 0}>
              {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
              {initial ? 'Guardar medidor' : 'Registrar medidor'}
            </Button>
            <Button type="button" variant="outline" onClick={onCancel}>
              Volver
            </Button>
          </div>
        }
      >
        <p className="text-sm text-muted-foreground">
          Medidor de {titular}. Queda activo en el predio y habilita la lectura.
        </p>
        <FormField label="Código" htmlFor="codigo" error={form.formState.errors.codigo?.message}>
          <Input id="codigo" autoComplete="off" {...form.register('codigo')} />
        </FormField>
        <FormField label="Marca" htmlFor="marca_id" error={form.formState.errors.marca_id?.message}>
          <Select id="marca_id" {...form.register('marca_id')}>
            <option value="">Seleccioná la marca</option>
            {marcasForm.map((marca) => (
              <option key={marca.id} value={marca.id}>
                {marca.procedencia.trim() ? `${marca.nombre} · ${marca.procedencia}` : marca.nombre}
              </option>
            ))}
          </Select>
        </FormField>
        <FormField
          label="Fecha de instalación"
          htmlFor="fecha_instalacion"
          error={form.formState.errors.fecha_instalacion?.message}
        >
          <Input id="fecha_instalacion" type="date" {...form.register('fecha_instalacion')} />
        </FormField>
      </FormLayout>
    </form>
  )
}
