import { zodResolver } from '@hookform/resolvers/zod'
import { LoaderCircle } from 'lucide-react'
import { useEffect, type ChangeEvent, type KeyboardEvent } from 'react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input, Select } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { FormLayout } from '@/design-system/templates'
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

  const tipo = form.watch('tipo_persona')
  const soloLetras = tipo === 'natural'

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

        <FormField
          label={tipo === 'juridica' || tipo === 'institucional' ? 'Razón social / nombre' : 'Nombres'}
          htmlFor="nombres"
          error={form.formState.errors.nombres?.message}
          className="sm:col-span-2"
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
              label="DNI"
              htmlFor="dni"
              error={form.formState.errors.dni?.message}
            >
              <Input id="dni" {...registrarDigitos('dni', 8)} />
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
        ) : (
          <FormField
            label="RUC"
            htmlFor="ruc"
            error={form.formState.errors.ruc?.message}
            className={tipo === 'institucional' ? undefined : 'sm:col-span-2'}
          >
            <Input id="ruc" {...registrarDigitos('ruc', 11)} />
          </FormField>
        )}

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
