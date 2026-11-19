import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
import { UbicacionMapa } from '@/modules/configuracion/components/ubicacion-mapa'
import type { Organizacion } from '@/modules/configuracion/api'
import { ubicacionSchema, type UbicacionValues } from '@/modules/configuracion/schemas'

export interface UbicacionFormProps {
  organizacion: Organizacion
  submitting?: boolean
  onSubmit: (values: UbicacionValues) => void
}

function coordinateInput(value: number | null) {
  return value == null ? '' : String(value)
}

export function UbicacionForm({ organizacion, submitting, onSubmit }: UbicacionFormProps) {
  const form = useForm<UbicacionValues>({
    resolver: zodResolver(ubicacionSchema),
    defaultValues: {
      latitud: coordinateInput(organizacion.latitud),
      longitud: coordinateInput(organizacion.longitud),
    },
  })
  const latitud = form.watch('latitud')
  const longitud = form.watch('longitud')
  const latitudNumero = Number(latitud)
  const longitudNumero = Number(longitud)
  const punto =
    latitud.trim() !== '' &&
    longitud.trim() !== '' &&
    Number.isFinite(latitudNumero) &&
    Number.isFinite(longitudNumero)
      ? { latitud: latitudNumero, longitud: longitudNumero }
      : null

  return (
    <form onSubmit={form.handleSubmit(onSubmit)} noValidate className="space-y-4">
      <UbicacionMapa
        latitud={punto?.latitud ?? null}
        longitud={punto?.longitud ?? null}
        onPick={(nextLatitud, nextLongitud) => {
          form.setValue('latitud', String(nextLatitud), { shouldValidate: true })
          form.setValue('longitud', String(nextLongitud), { shouldValidate: true })
        }}
      />
      <p className="text-sm text-muted-foreground">Hacé clic en el mapa para marcar la sede de la JASS.</p>
      <FormLayout
        columns={2}
        footer={
          <Button type="submit" disabled={submitting}>
            {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
            Guardar ubicación
          </Button>
        }
      >
        <FormField label="Latitud" htmlFor="latitud" error={form.formState.errors.latitud?.message}>
          <Input id="latitud" inputMode="decimal" {...form.register('latitud')} />
        </FormField>
        <FormField label="Longitud" htmlFor="longitud" error={form.formState.errors.longitud?.message}>
          <Input id="longitud" inputMode="decimal" {...form.register('longitud')} />
        </FormField>
      </FormLayout>
    </form>
  )
}
