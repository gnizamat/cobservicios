import { zodResolver } from '@hookform/resolvers/zod'
import { ImagePlus, LoaderCircle, Trash2 } from 'lucide-react'
import { useRef } from 'react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
import { logoPublicUrl, type Organizacion } from '@/modules/configuracion/api'
import { datosJassSchema, type DatosJassValues } from '@/modules/configuracion/schemas'

export interface DatosJassFormProps {
  organizacion: Organizacion
  submitting?: boolean
  uploading?: boolean
  removing?: boolean
  onSubmit: (values: DatosJassValues) => void
  onUploadLogo: (file: File) => void
  onRemoveLogo: () => void
}

export function DatosJassForm({
  organizacion,
  submitting,
  uploading,
  removing,
  onSubmit,
  onUploadLogo,
  onRemoveLogo,
}: DatosJassFormProps) {
  const fileRef = useRef<HTMLInputElement>(null)
  const logo = logoPublicUrl(organizacion.logo_path)
  const form = useForm<DatosJassValues>({
    resolver: zodResolver(datosJassSchema),
    defaultValues: {
      nombre: organizacion.nombre,
      abreviatura: organizacion.abreviatura,
      celular: organizacion.celular,
      direccion: organizacion.direccion,
      email: organizacion.email,
    },
  })

  return (
    <form onSubmit={form.handleSubmit(onSubmit)} noValidate className="space-y-6">
      <section className="space-y-3">
        <h3 className="text-xs font-semibold tracking-[0.14em] text-muted-foreground uppercase">Identidad</h3>
        <FormLayout
          columns={1}
          footer={
            <Button type="submit" disabled={submitting}>
              {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
              Guardar datos
            </Button>
          }
        >
          <FormField label="Nombre de la JASS" htmlFor="nombre" error={form.formState.errors.nombre?.message}>
            <Input id="nombre" {...form.register('nombre')} />
          </FormField>
          <FormField
            label="Abreviatura"
            htmlFor="abreviatura"
            error={form.formState.errors.abreviatura?.message}
          >
            <Input id="abreviatura" {...form.register('abreviatura')} />
          </FormField>
          <FormField label="Logo de la JASS" htmlFor="logo" hint="PNG, JPG o WebP. Hasta 2 MB.">
            <div className="flex flex-wrap items-center gap-3">
              <div className="flex h-14 w-14 items-center justify-center overflow-hidden rounded-full border border-border bg-muted">
                {logo ? (
                  <img src={logo} alt="" className="h-full w-full object-cover" />
                ) : (
                  <Icon icon={ImagePlus} className="text-muted-foreground" />
                )}
              </div>
              <input
                ref={fileRef}
                id="logo"
                type="file"
                accept="image/png,image/jpeg,image/webp"
                className="sr-only"
                onChange={(event) => {
                  const file = event.target.files?.[0]
                  event.target.value = ''
                  if (file) onUploadLogo(file)
                }}
              />
              <Button
                type="button"
                variant="outline"
                size="sm"
                disabled={uploading}
                onClick={() => fileRef.current?.click()}
              >
                {uploading ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
                Cambiar logo
              </Button>
              {logo ? (
                <Button
                  type="button"
                  variant="ghost"
                  size="sm"
                  className="text-destructive"
                  disabled={removing}
                  onClick={onRemoveLogo}
                >
                  <Icon icon={Trash2} size={14} />
                  Eliminar
                </Button>
              ) : null}
            </div>
          </FormField>
        </FormLayout>
      </section>
      <section className="space-y-3">
        <h3 className="text-xs font-semibold tracking-[0.14em] text-muted-foreground uppercase">Comunicación</h3>
        <FormLayout columns={1}>
          <FormField label="Celular" htmlFor="celular" error={form.formState.errors.celular?.message}>
            <Input id="celular" inputMode="tel" {...form.register('celular')} />
          </FormField>
          <FormField label="Dirección" htmlFor="direccion" error={form.formState.errors.direccion?.message}>
            <Input id="direccion" {...form.register('direccion')} />
          </FormField>
          <FormField label="Email" htmlFor="email" error={form.formState.errors.email?.message}>
            <Input id="email" type="email" autoComplete="off" {...form.register('email')} />
          </FormField>
        </FormLayout>
      </section>
    </form>
  )
}
