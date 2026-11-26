import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useEffect, useRef } from 'react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
import { cn } from '@/shared/lib/utils'
import type { LecturaListItem, PredioOption, ServicioOption, ValorM3Activo } from '@/modules/lecturas/api'
import { useLecturadores } from '@/modules/lecturas/api'
import {
  MESES,
  formatMoney,
  formatVolume,
  periodoLabel,
  periodoSiguiente,
  predioOptionLabel,
  roundMoney,
  ultimaLecturaAntes,
  ultimaLecturaDe,
  volumeInput,
  volumenPorDiferencia,
} from '@/modules/lecturas/labels'
import {
  lecturaFormSchema,
  toLecturaPayload,
  type LecturaFormValues,
  type LecturaPayload,
} from '@/modules/lecturas/schemas'

export interface LecturaFormProps {
  initial?: LecturaListItem | null
  predios: PredioOption[]
  servicios: ServicioOption[]
  lecturas: LecturaListItem[]
  valoresM3?: ValorM3Activo[]
  historialListo?: boolean
  predioId?: string | null
  predioFijo?: boolean
  submitting?: boolean
  onRegisterMeter?: (predioId: string) => void
  onSubmit: (payload: LecturaPayload) => void
}

function nombreLecturador(item: {
  apellido_paterno: string
  apellido_materno: string
  nombres: string
}) {
  const apellidos = [item.apellido_paterno, item.apellido_materno].filter(Boolean).join(' ')
  return apellidos ? `${apellidos}, ${item.nombres}` : item.nombres
}

function withOption<T extends { id: string }>(options: T[], current: T | null | undefined) {
  if (!current || options.some((item) => item.id === current.id)) return options
  return [current, ...options]
}

export function LecturaForm({
  initial,
  predios,
  servicios,
  lecturas,
  valoresM3 = [],
  historialListo = true,
  predioId,
  predioFijo = false,
  submitting,
  onRegisterMeter,
  onSubmit,
}: LecturaFormProps) {
  const predioOptions = withOption(predios, initial?.predio)
  const servicioOptions = withOption(servicios, initial?.servicio)
  const blocked = predioOptions.length === 0 || servicioOptions.length === 0
  const predioInicial = initial?.predio_id ?? predioId ?? predioOptions[0]?.id ?? ''
  const servicioInicial =
    initial?.tipo_servicio_id ??
    servicioOptions.find((servicio) => servicio.codigo === 'VOL')?.id ??
    servicioOptions[0]?.id ??
    ''
  const period = initial
    ? {
        anio: String(initial.anio),
        mes: String(initial.mes),
        fecha: initial.fecha_lectura,
      }
    : periodoSiguiente(
        ultimaLecturaDe(lecturas, {
          predioId: predioInicial,
          servicioId: servicioInicial,
        }),
      )
  const form = useForm<LecturaFormValues>({
    resolver: zodResolver(lecturaFormSchema),
    defaultValues: initial
      ? {
          predio_id: initial.predio_id,
          tipo_servicio_id: initial.tipo_servicio_id,
          anio: period.anio,
          mes: period.mes,
          fecha_lectura: period.fecha,
          lectura_m3: volumeInput(initial.lectura_m3),
          lectura_lt: volumeInput(initial.lectura_lt),
          referencia: initial.referencia,
          colaborador_id: initial.colaborador_id ?? '',
        }
      : {
          predio_id: predioInicial,
          tipo_servicio_id: servicioInicial,
          anio: period.anio,
          mes: period.mes,
          fecha_lectura: period.fecha,
          lectura_m3: '',
          lectura_lt: '0',
          referencia: '',
          colaborador_id: '',
        },
  })
  const chosenId = form.watch('predio_id')
  const servicioId = form.watch('tipo_servicio_id')
  const anio = Number(form.watch('anio'))
  const mes = Number(form.watch('mes'))
  const lecturaM3Raw = form.watch('lectura_m3')
  const lecturaLtRaw = form.watch('lectura_lt')
  const predioElegido = predioOptions.find((predio) => predio.id === chosenId)
  const sinMedidor = !predioElegido?.medidor
  const lecturadores = useLecturadores()
  const centroId = predioElegido?.sector_id ?? predioElegido?.calle?.sector_id ?? null
  const catalogoLecturador = lecturadores.data ?? []
  const asignados = catalogoLecturador.filter(
    (item) => centroId != null && item.sector_ids.includes(centroId),
  )
  const baseLecturador = asignados.length > 0 ? asignados : catalogoLecturador
  const colaboradorId = form.watch('colaborador_id')
  const lecturadorActual = catalogoLecturador.find((item) => item.id === colaboradorId)
  const opcionesLecturador =
    lecturadorActual && !baseLecturador.some((item) => item.id === lecturadorActual.id)
      ? [lecturadorActual, ...baseLecturador]
      : baseLecturador
  useEffect(() => {
    if (lecturadores.isLoading) return
    const vigente = baseLecturador.some((item) => item.id === colaboradorId)
    if (colaboradorId && vigente) return
    if (!colaboradorId && asignados.length === 1) {
      form.setValue('colaborador_id', asignados[0]?.id ?? '')
      return
    }
    if (colaboradorId && !vigente) form.setValue('colaborador_id', '')
  }, [asignados, baseLecturador, colaboradorId, form, lecturadores.isLoading])
  const periodoAplicado = useRef(`${predioInicial}|${servicioInicial}`)
  const ultimaRegistrada = ultimaLecturaDe(lecturas, {
    predioId: chosenId,
    servicioId,
    excludeId: initial?.id,
  })
  const siguiente = periodoSiguiente(ultimaRegistrada)
  useEffect(() => {
    if (initial) return
    const clave = `${chosenId}|${servicioId}`
    if (periodoAplicado.current === clave) return
    periodoAplicado.current = clave
    form.setValue('anio', siguiente.anio)
    form.setValue('mes', siguiente.mes)
    form.setValue('fecha_lectura', siguiente.fecha)
  }, [chosenId, form, initial, servicioId, siguiente.anio, siguiente.fecha, siguiente.mes])
  const periodoValido = Number.isInteger(anio) && anio >= 1000 && mes >= 1 && mes <= 12
  const ultima =
    historialListo && periodoValido
      ? ultimaLecturaAntes(lecturas, {
          predioId: chosenId,
          servicioId,
          anio,
          mes,
          excludeId: initial?.id,
        })
      : null
  const primera = Boolean(historialListo && periodoValido && !ultima)
  const lecturaM3 = Number(lecturaM3Raw)
  const lecturaLt = lecturaLtRaw.trim() === '' ? 0 : Number(lecturaLtRaw)
  const lecturaLista =
    lecturaM3Raw.trim() !== '' && Number.isFinite(lecturaM3) && Number.isFinite(lecturaLt)
  const volumen =
    historialListo && lecturaLista
      ? primera
        ? 0
        : volumenPorDiferencia(
            lecturaM3,
            lecturaLt,
            Number(ultima?.lectura_m3 ?? 0),
            Number(ultima?.lectura_lt ?? 0),
          )
      : null
  const volumenValido = volumen != null && volumen >= 0
  const tarifaAnio = Number.isInteger(anio) ? valoresM3.find((item) => item.anio === anio) ?? null : null
  const importe =
    primera || !volumenValido
      ? null
      : tarifaAnio && tarifaAnio.valor > 0
        ? roundMoney(volumen * tarifaAnio.valor)
        : null
  const sinTarifa = Boolean(!primera && volumenValido && volumen > 0 && importe == null)
  const lecturaMenor = volumen != null && volumen < 0
  const lecturaError = lecturaMenor
    ? `La lectura es menor que la última registrada (${formatVolume(ultima?.lectura_m3 ?? 0)} m³).`
    : form.formState.errors.lectura_m3?.message

  return (
    <form
      onSubmit={form.handleSubmit((values) => {
        if (!predioOptions.find((predio) => predio.id === values.predio_id)?.medidor) return
        if (!volumenValido || volumen == null) return
        onSubmit(toLecturaPayload(values, volumen))
      })}
      noValidate
    >
      <FormLayout
        columns={predioFijo ? 4 : 1}
        dense={predioFijo}
        footer={
          <Button
            type="submit"
            disabled={submitting || blocked || sinMedidor || !historialListo || lecturaMenor || sinTarifa}
          >
            {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
            {initial ? 'Guardar cambios' : 'Registrar lectura'}
          </Button>
        }
      >
        {blocked ? (
          <p className={cn('text-sm text-muted-foreground', predioFijo && 'sm:col-span-4')}>
            Hace falta al menos un predio activo y un tipo de servicio para registrar la lectura.
          </p>
        ) : null}
        {sinMedidor && !blocked ? (
          <div className={cn('space-y-2 rounded-md border border-border bg-muted/40 p-3', predioFijo && 'sm:col-span-4')}>
            <p className="text-sm text-foreground">
              Este predio no tiene un medidor asignado. Registralo para poder guardar la lectura.
            </p>
            {onRegisterMeter ? (
              <Button type="button" size="sm" variant="outline" onClick={() => onRegisterMeter(chosenId)}>
                Registrar medidor
              </Button>
            ) : null}
          </div>
        ) : null}
        <div className={cn('flex h-10 items-center gap-2', predioFijo && 'sm:col-span-4')}>
          <label htmlFor="colaborador_id" className="shrink-0 text-sm font-medium text-foreground">
            Lecturador:
          </label>
          <Select
            id="colaborador_id"
            className="h-8 min-w-0 flex-1"
            disabled={lecturadores.isLoading}
            {...form.register('colaborador_id')}
          >
            <option value="">
              {lecturadores.isLoading
                ? 'Cargando lecturadores…'
                : opcionesLecturador.length === 0
                  ? 'No hay lecturadores'
                  : 'Seleccioná el lecturador'}
            </option>
            {opcionesLecturador.map((item) => (
              <option key={item.id} value={item.id}>
                {nombreLecturador(item)}
              </option>
            ))}
          </Select>
        </div>
        {predioFijo ? (
          <input type="hidden" {...form.register('predio_id')} />
        ) : (
          <FormField label="Predio" htmlFor="predio_id" error={form.formState.errors.predio_id?.message}>
            <Select id="predio_id" {...form.register('predio_id')}>
              {predioOptions.map((predio) => (
                <option key={predio.id} value={predio.id}>
                  {predioOptionLabel(predio)}
                </option>
              ))}
            </Select>
          </FormField>
        )}
        <FormField
          label="Servicio"
          htmlFor="tipo_servicio_id"
          className={predioFijo ? 'sm:col-span-2' : undefined}
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
        <FormField
          label="Mes"
          htmlFor="mes"
          hint={
            initial
              ? undefined
              : ultimaRegistrada
                ? `Última lectura: ${periodoLabel(ultimaRegistrada.anio, ultimaRegistrada.mes)}. Se carga el mes siguiente.`
                : 'Este medidor todavía no tiene lecturas.'
          }
          error={form.formState.errors.mes?.message}
        >
          <Select id="mes" {...form.register('mes')}>
            {MESES.map((item) => (
              <option key={item.value} value={item.value}>
                {item.label}
              </option>
            ))}
          </Select>
        </FormField>
        <FormField
          label="Fecha de lectura"
          htmlFor="fecha_lectura"
          error={form.formState.errors.fecha_lectura?.message}
        >
          <Input id="fecha_lectura" type="date" {...form.register('fecha_lectura')} />
        </FormField>
        <FormField
          label="Última lectura m³"
          htmlFor="ultima_lectura"
          hint={
            !historialListo
              ? 'No se pudo consultar la última lectura.'
              : ultima
                ? `${periodoLabel(ultima.anio, ultima.mes)}${Number(ultima.lectura_lt) > 0 ? ` · ${formatVolume(ultima.lectura_lt)} L` : ''}.`
                : 'Primera lectura de este medidor. Solo deja el índice; no calcula monto.'
          }
        >
          <Input
            id="ultima_lectura"
            value={ultima ? formatVolume(ultima.lectura_m3) : ''}
            readOnly
            tabIndex={-1}
            className="bg-muted tabular-nums"
          />
        </FormField>
        <FormField
          label="Lectura m³"
          htmlFor="lectura_m3"
          hint="Índice actual del medidor."
          error={lecturaError}
        >
          <Input id="lectura_m3" inputMode="decimal" {...form.register('lectura_m3')} />
        </FormField>
        <FormField
          label="Lectura litros"
          htmlFor="lectura_lt"
          error={form.formState.errors.lectura_lt?.message}
        >
          <Input id="lectura_lt" inputMode="decimal" {...form.register('lectura_lt')} />
        </FormField>
        <FormField
          label="Volumen m³"
          htmlFor="volumen_m3"
          hint={
            lecturaMenor
              ? 'La diferencia no puede ser negativa.'
              : primera
                ? 'La primera lectura no genera volumen. Se halla desde la siguiente, por la diferencia.'
                : 'Lectura nueva menos la última lectura registrada.'
          }
        >
          <Input
            id="volumen_m3"
            value={volumenValido ? formatVolume(volumen) : ''}
            readOnly
            tabIndex={-1}
            className="bg-muted tabular-nums"
          />
        </FormField>
        <FormField
          label="Referencia S/."
          htmlFor="referencia_soles"
          className={predioFijo ? 'sm:col-span-2' : undefined}
          hint={
            primera
              ? 'La primera lectura no calcula monto. El importe en soles empieza en la siguiente lectura.'
              : sinTarifa
              ? `No hay tarifa de volumen para ${anio}.`
              : tarifaAnio
                ? volumenValido
                  ? volumen > 0
                    ? `${formatVolume(volumen)} m³ × ${formatMoney(tarifaAnio.valor)} · ${tarifaAnio.nombre}. Este importe se graba como deuda.`
                    : 'Sin consumo no se genera deuda.'
                  : `${tarifaAnio.nombre}: ${formatMoney(tarifaAnio.valor)} por m³.`
                : 'No hay tarifa de volumen para el año de la lectura.'
          }
        >
          <Input
            id="referencia_soles"
            value={importe != null ? formatMoney(importe) : ''}
            readOnly
            tabIndex={-1}
            className="bg-muted tabular-nums"
          />
        </FormField>
        <FormField
          label="Referencia"
          htmlFor="referencia"
          hint="Nota opcional."
          error={form.formState.errors.referencia?.message}
        >
          <Input id="referencia" {...form.register('referencia')} />
        </FormField>
      </FormLayout>
    </form>
  )
}
