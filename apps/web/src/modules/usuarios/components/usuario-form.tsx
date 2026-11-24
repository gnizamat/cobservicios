import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useEffect, useRef, type ChangeEvent, type KeyboardEvent } from 'react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
import { useConsultaDniActiva, useConsultarDni } from '@/modules/usuarios/api/consulta-dni-api'
import { useConsultaRucActiva, useConsultarRuc } from '@/modules/usuarios/api/consulta-ruc-api'
import {
  textoMayusculas,
  toUsuarioPayload,
  usuarioFormSchema,
  type UsuarioFormValues,
  type UsuarioPayload,
} from '@/modules/usuarios/schemas'
import type { PadUsuario } from '@/shared/types/database'

export interface UsuarioFormProps {
  initial?: PadUsuario
  submitting?: boolean
  submitLabel?: string
  onSubmit: (payload: UsuarioPayload) => void
  onCancel?: () => void
}

function mensajeConsulta(error: unknown) {
  if (!error) return undefined
  const texto = error instanceof Error ? error.message : 'No se pudo consultar el DNI'
  return texto.replace(/^[A-Z0-9]{5}:\s*/, '')
}

function avanzarConEnter(event: KeyboardEvent<HTMLFormElement>) {
  if (event.key !== 'Enter' || event.nativeEvent.isComposing) return
  if (event.shiftKey || event.altKey || event.ctrlKey || event.metaKey) return
  const actual = event.target
  if (!(actual instanceof HTMLElement)) return
  if (actual instanceof HTMLButtonElement || actual instanceof HTMLTextAreaElement) return

  const formulario = event.currentTarget
  const controles = [...formulario.querySelectorAll<HTMLElement>('input, select, button')].filter(
    (control) =>
      !control.hasAttribute('disabled') &&
      control.tabIndex !== -1 &&
      (control instanceof HTMLInputElement ? control.type !== 'hidden' : true),
  )
  const indice = controles.indexOf(actual)
  if (indice === -1) return

  event.preventDefault()
  const siguiente = controles[indice + 1]
  if (siguiente) {
    siguiente.focus()
    return
  }
  formulario.requestSubmit()
}

const defaults: UsuarioFormValues = {
  tipo_persona: 'natural',
  nombres: '',
  apellido_paterno: '',
  apellido_materno: '',
  dni: '',
  ruc: '',
  sexo: '',
  direccion: '',
  email: '',
  celular: '',
  estado: 'activo',
}

export function UsuarioForm({
  initial,
  submitting,
  submitLabel = 'Guardar',
  onSubmit,
  onCancel,
}: UsuarioFormProps) {
  const form = useForm<UsuarioFormValues>({
    resolver: zodResolver(usuarioFormSchema),
    defaultValues: defaults,
  })
  const consultaActiva = useConsultaDniActiva()
  const consultaRucActiva = useConsultaRucActiva()
  const consultarDni = useConsultarDni()
  const consultarRuc = useConsultarRuc()
  const consultar = useRef(consultarDni.mutate)
  consultar.current = consultarDni.mutate
  const consultarEmpresa = useRef(consultarRuc.mutate)
  consultarEmpresa.current = consultarRuc.mutate
  const dniInicial = useRef(initial?.dni ?? '')
  const dniConsultado = useRef('')
  const rucInicial = useRef(initial?.ruc ?? '')
  const rucConsultado = useRef('')
  const tipoAnterior = useRef(initial?.tipo_persona ?? defaults.tipo_persona)
  const reiniciarDni = useRef(consultarDni.reset)
  const reiniciarRuc = useRef(consultarRuc.reset)
  reiniciarDni.current = consultarDni.reset
  reiniciarRuc.current = consultarRuc.reset

  const tipo = form.watch('tipo_persona')
  const dni = form.watch('dni')
  const ruc = form.watch('ruc')
  const soloLetras = tipo === 'natural'
  const buscarDni = tipo === 'natural' && consultaActiva.data === true
  const buscarRuc = tipo !== 'natural' && consultaRucActiva.data === true

  useEffect(() => {
    if (!buscarDni || !/^\d{8}$/.test(dni) || dni === dniInicial.current || dniConsultado.current === dni) {
      return
    }
    dniConsultado.current = dni
    consultar.current(dni, {
      onSuccess: (persona) => {
        if (form.getValues('dni') !== dni) return
        form.setValue('nombres', textoMayusculas(persona.nombres, true), { shouldValidate: true })
        form.setValue('apellido_paterno', textoMayusculas(persona.apellidoPaterno, true), {
          shouldValidate: true,
        })
        form.setValue('apellido_materno', textoMayusculas(persona.apellidoMaterno, true), {
          shouldValidate: true,
        })
      },
    })
  }, [buscarDni, dni, form])

  useEffect(() => {
    if (!buscarRuc || !/^\d{11}$/.test(ruc) || ruc === rucInicial.current || rucConsultado.current === ruc) {
      return
    }
    rucConsultado.current = ruc
    consultarEmpresa.current(ruc, {
      onSuccess: (empresa) => {
        if (form.getValues('ruc') !== ruc) return
        form.setValue('nombres', textoMayusculas(empresa.razonSocial, false), { shouldValidate: true })
        if (empresa.direccion) {
          form.setValue('direccion', textoMayusculas(empresa.direccion, false), { shouldValidate: true })
        }
      },
    })
  }, [buscarRuc, form, ruc])

  useEffect(() => {
    if (tipo === tipoAnterior.current) return
    tipoAnterior.current = tipo
    dniConsultado.current = ''
    rucConsultado.current = ''
    dniInicial.current = ''
    rucInicial.current = ''
    form.setValue('dni', '')
    form.setValue('ruc', '')
    form.setValue('nombres', '')
    form.setValue('apellido_paterno', '')
    form.setValue('apellido_materno', '')
    form.setValue('direccion', '')
    form.setValue('celular', '')
    form.setValue('email', '')
    form.setValue('sexo', '')
    form.clearErrors()
    reiniciarDni.current()
    reiniciarRuc.current()
  }, [form, tipo])

  function registrarTexto(
    nombre: 'nombres' | 'apellido_paterno' | 'apellido_materno' | 'direccion' | 'email',
    letras: boolean,
  ) {
    const registro = form.register(nombre)
    return {
      ...registro,
      autoCapitalize: 'characters' as const,
      spellCheck: false,
      onChange: (event: ChangeEvent<HTMLInputElement>) => {
        event.target.value = textoMayusculas(event.target.value, letras)
        void registro.onChange(event)
      },
    }
  }

  function registrarDigitos(nombre: 'dni' | 'ruc' | 'celular', maxLength: number) {
    const registro = form.register(nombre)
    return {
      ...registro,
      inputMode: 'numeric' as const,
      maxLength,
      onChange: (event: ChangeEvent<HTMLInputElement>) => {
        event.target.value = event.target.value.replace(/\D/g, '').slice(0, maxLength)
        void registro.onChange(event)
      },
    }
  }

  useEffect(() => {
    tipoAnterior.current = initial?.tipo_persona ?? defaults.tipo_persona
    dniInicial.current = initial?.dni ?? ''
    rucInicial.current = initial?.ruc ?? ''
    if (!initial) return
    const letras = initial.tipo_persona === 'natural'
    form.reset({
      tipo_persona: initial.tipo_persona,
      nombres: textoMayusculas(initial.nombres, letras),
      apellido_paterno: textoMayusculas(initial.apellido_paterno, true),
      apellido_materno: textoMayusculas(initial.apellido_materno, true),
      dni: initial.dni ?? '',
      ruc: initial.ruc ?? '',
      sexo: initial.sexo ?? '',
      direccion: textoMayusculas(initial.direccion),
      email: textoMayusculas(initial.email ?? ''),
      celular: initial.celular ?? '',
      estado: initial.estado,
    })
  }, [initial, form])

  return (
    <form
      onSubmit={form.handleSubmit((values) => {
        onSubmit(toUsuarioPayload(values))
      })}
      onKeyDown={avanzarConEnter}
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
            <Button type="submit" disabled={submitting}>
              {submitting ? <Icon icon={LoaderCircle} className="animate-spin" /> : null}
              {submitLabel}
            </Button>
          </>
        }
      >
        <FormField
          label="Tipo de persona"
          htmlFor="tipo_persona"
          error={form.formState.errors.tipo_persona?.message}
        >
          <Select id="tipo_persona" {...form.register('tipo_persona')}>
            <option value="natural">Natural</option>
            <option value="juridica">Jurídica</option>
            <option value="institucional">Institucional</option>
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

        {tipo === 'natural' ? (
          <FormField
            label="DNI"
            htmlFor="dni"
            error={form.formState.errors.dni?.message ?? mensajeConsulta(consultarDni.error)}
            hint={
              buscarDni
                ? consultarDni.isPending
                  ? 'Buscando el DNI…'
                  : 'Al completar el DNI se completan los nombres y apellidos.'
                : undefined
            }
          >
            <Input id="dni" {...registrarDigitos('dni', 8)} />
          </FormField>
        ) : (
          <FormField
            label="RUC"
            htmlFor="ruc"
            error={form.formState.errors.ruc?.message ?? mensajeConsulta(consultarRuc.error)}
            hint={
              buscarRuc
                ? consultarRuc.isPending
                  ? 'Buscando el RUC…'
                  : 'Al completar el RUC se completa la razón social.'
                : undefined
            }
            className={tipo === 'institucional' ? undefined : 'sm:col-span-2'}
          >
            <Input id="ruc" {...registrarDigitos('ruc', 11)} />
          </FormField>
        )}

        <FormField
          label={tipo === 'juridica' || tipo === 'institucional' ? 'Razón social / nombre' : 'Nombres'}
          htmlFor="nombres"
          error={form.formState.errors.nombres?.message}
          className={tipo === 'natural' ? undefined : 'sm:col-span-2'}
        >
          <Input id="nombres" {...registrarTexto('nombres', soloLetras)} />
        </FormField>

        {tipo === 'natural' ? (
          <>
            <FormField
              label="Apellido paterno"
              htmlFor="apellido_paterno"
              error={form.formState.errors.apellido_paterno?.message}
            >
              <Input id="apellido_paterno" {...registrarTexto('apellido_paterno', true)} />
            </FormField>
            <FormField
              label="Apellido materno"
              htmlFor="apellido_materno"
              error={form.formState.errors.apellido_materno?.message}
            >
              <Input id="apellido_materno" {...registrarTexto('apellido_materno', true)} />
            </FormField>
            <FormField
              label="Sexo"
              htmlFor="sexo"
              error={form.formState.errors.sexo?.message}
            >
              <Select id="sexo" {...form.register('sexo')}>
                <option value="">Seleccionar</option>
                <option value="M">Masculino</option>
                <option value="F">Femenino</option>
              </Select>
            </FormField>
          </>
        ) : null}

        <FormField
          label="Dirección"
          htmlFor="direccion"
          error={form.formState.errors.direccion?.message}
          className="sm:col-span-2"
        >
          <Input id="direccion" {...registrarTexto('direccion', false)} />
        </FormField>

        <FormField
          label="Celular"
          htmlFor="celular"
          error={form.formState.errors.celular?.message}
        >
          <Input id="celular" {...registrarDigitos('celular', 9)} />
        </FormField>

        <FormField
          label="Correo"
          htmlFor="email"
          error={form.formState.errors.email?.message}
        >
          <Input id="email" type="email" {...registrarTexto('email', false)} />
        </FormField>
      </FormLayout>
    </form>
  )
}
