import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useEffect, useMemo } from 'react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
import { usePredioCatalogs } from '@/modules/predios/api'
import { UsuarioTitularField } from '@/modules/predios/components/usuario-titular-field'
import {
  predioFormSchema,
  toPredioPayload,
  type PredioFormValues,
  type PredioPayload,
} from '@/modules/predios/schemas'
import type { PadPredio } from '@/shared/types/database'

export interface PredioFormProps {
  initial?: PadPredio
  submitting?: boolean
  submitLabel?: string
  onSubmit: (payload: PredioPayload) => void
  onCancel?: () => void
}

const defaults: PredioFormValues = {
  usuario_id: '',
  tipo_predio_id: '',
  sector_id: '',
  calle_id: '',
  nombre: '',
  numero: '',
  manzana: '',
  lote: '',
  partida_registral: '',
  unidad_catastral: '',
  titulo: '',
  fecha_documento: '',
  coord_este: '',
  coord_norte: '',
  estado: 'activo',
}

export function PredioForm({
  initial,
  submitting,
  submitLabel = 'Guardar',
  onSubmit,
  onCancel,
}: PredioFormProps) {
  const catalogs = usePredioCatalogs()
  const form = useForm<PredioFormValues>({
    resolver: zodResolver(predioFormSchema),
    defaultValues: defaults,
  })

  const sectorId = form.watch('sector_id')

  const callesFiltradas = useMemo(() => {
    const calles = catalogs.data?.calles ?? []
    if (!sectorId) return calles
    return calles.filter((calle) => !calle.sector_id || calle.sector_id === sectorId)
  }, [catalogs.data?.calles, sectorId])

  useEffect(() => {
    if (!initial) return
    form.reset({
      usuario_id: initial.usuario_id,
      tipo_predio_id: initial.tipo_predio_id ?? '',
      sector_id: initial.sector_id ?? '',
      calle_id: initial.calle_id ?? '',
      nombre: initial.nombre,
      numero: initial.numero,
      manzana: initial.manzana,
      lote: initial.lote,
      partida_registral: initial.partida_registral,
      unidad_catastral: initial.unidad_catastral,
      titulo: initial.titulo,
      fecha_documento: initial.fecha_documento ?? '',
      coord_este: initial.coord_este,
      coord_norte: initial.coord_norte,
      estado: initial.estado,
    })
  }, [initial, form])

  return (
    <form
      onSubmit={form.handleSubmit((values) => {
        onSubmit(toPredioPayload(values))
      })}
      noValidate
    >
      <FormLayout
        footer={
          <>
            {onCancel ? (
              <Button type="button" variant="outline" onClick={onCancel}>
                Cancelar
              </Button>
            ) : null}
            <Button type="submit" disabled={submitting || catalogs.isLoading}>
              {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
              {submitLabel}
            </Button>
          </>
        }
      >
        <div className="sm:col-span-2">
          <UsuarioTitularField
            id="usuario_id"
            value={form.watch('usuario_id')}
            error={form.formState.errors.usuario_id?.message}
            onChange={(usuarioId) => {
              form.setValue('usuario_id', usuarioId, {
                shouldDirty: true,
                shouldValidate: Boolean(usuarioId),
              })
              if (!usuarioId) form.clearErrors('usuario_id')
            }}
          />
        </div>

        <FormField
          label="Nombre / referencia del predio"
          htmlFor="nombre"
          error={form.formState.errors.nombre?.message}
          className="sm:col-span-2"
        >
          <Input id="nombre" {...form.register('nombre')} />
        </FormField>

        <FormField
          label="Tipo de predio"
          htmlFor="tipo_predio_id"
          error={form.formState.errors.tipo_predio_id?.message}
        >
          <Select id="tipo_predio_id" {...form.register('tipo_predio_id')}>
            <option value="">Seleccionar…</option>
            {(catalogs.data?.tipos ?? []).map((tipo) => (
              <option key={tipo.id} value={tipo.id}>
                {tipo.nombre}
              </option>
            ))}
          </Select>
        </FormField>

        <FormField
          label="Estado"
          htmlFor="estado"
          error={form.formState.errors.estado?.message}
        >
          <Select id="estado" {...form.register('estado')}>
            <option value="activo">Activo</option>
            <option value="inactivo">Inactivo</option>
          </Select>
        </FormField>

        <FormField
          label="Sector"
          htmlFor="sector_id"
          error={form.formState.errors.sector_id?.message}
        >
          <Select
            id="sector_id"
            {...form.register('sector_id', {
              onChange: () => form.setValue('calle_id', ''),
            })}
          >
            <option value="">Seleccionar…</option>
            {(catalogs.data?.sectores ?? []).map((sector) => (
              <option key={sector.id} value={sector.id}>
                {sector.nombre}
              </option>
            ))}
          </Select>
        </FormField>

        <FormField
          label="Calle"
          htmlFor="calle_id"
          error={form.formState.errors.calle_id?.message}
        >
          <Select id="calle_id" {...form.register('calle_id')}>
            <option value="">Seleccionar…</option>
            {callesFiltradas.map((calle) => (
              <option key={calle.id} value={calle.id}>
                {calle.nombre}
              </option>
            ))}
          </Select>
        </FormField>

        <FormField label="Número" htmlFor="numero" error={form.formState.errors.numero?.message}>
          <Input id="numero" {...form.register('numero')} />
        </FormField>
        <FormField label="Manzana" htmlFor="manzana" error={form.formState.errors.manzana?.message}>
          <Input id="manzana" {...form.register('manzana')} />
        </FormField>
        <FormField label="Lote" htmlFor="lote" error={form.formState.errors.lote?.message}>
          <Input id="lote" {...form.register('lote')} />
        </FormField>
        <FormField
          label="Fecha documento"
          htmlFor="fecha_documento"
          error={form.formState.errors.fecha_documento?.message}
        >
          <Input id="fecha_documento" type="date" {...form.register('fecha_documento')} />
        </FormField>

        <FormField
          label="Partida registral"
          htmlFor="partida_registral"
          error={form.formState.errors.partida_registral?.message}
        >
          <Input id="partida_registral" {...form.register('partida_registral')} />
        </FormField>
        <FormField
          label="Unidad catastral"
          htmlFor="unidad_catastral"
          error={form.formState.errors.unidad_catastral?.message}
        >
          <Input id="unidad_catastral" {...form.register('unidad_catastral')} />
        </FormField>
        <FormField
          label="Título"
          htmlFor="titulo"
          error={form.formState.errors.titulo?.message}
          className="sm:col-span-2"
        >
          <Input id="titulo" {...form.register('titulo')} />
        </FormField>
        <FormField
          label="Coord. Este"
          htmlFor="coord_este"
          error={form.formState.errors.coord_este?.message}
        >
          <Input id="coord_este" {...form.register('coord_este')} />
        </FormField>
        <FormField
          label="Coord. Norte"
          htmlFor="coord_norte"
          error={form.formState.errors.coord_norte?.message}
        >
          <Input id="coord_norte" {...form.register('coord_norte')} />
        </FormField>
      </FormLayout>
    </form>
  )
}
