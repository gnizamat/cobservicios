import { zodResolver } from '@hookform/resolvers/zod'
import { ArrowRight, Eye, EyeOff, LoaderCircle } from 'lucide-react'
import { useState } from 'react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Input } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { useSignIn } from '@/modules/auth/api'
import { loginSchema, type LoginInput } from '@/modules/auth/schemas'

function authErrorMessage(error: unknown): string {
  if (!error || typeof error !== 'object') {
    return 'No se pudo iniciar sesión. Intentá de nuevo.'
  }

  const message = 'message' in error ? String(error.message) : ''
  if (/invalid login credentials/i.test(message)) {
    return 'Usuario o contraseña incorrectos.'
  }
  if (/email not confirmed/i.test(message)) {
    return 'Confirmá tu correo antes de ingresar.'
  }
  return message || 'No se pudo iniciar sesión. Intentá de nuevo.'
}

export function LoginForm() {
  const signIn = useSignIn()
  const [showPassword, setShowPassword] = useState(false)

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<LoginInput>({
    resolver: zodResolver(loginSchema),
    defaultValues: {
      email: '',
      password: '',
    },
  })

  const onSubmit = handleSubmit((values) => {
    signIn.mutate(values)
  })

  return (
    <form
      onSubmit={onSubmit}
      className="login-card"
      noValidate
    >
      <div className="space-y-1">
        <h2 className="font-[family-name:var(--font-display)] text-xl font-semibold">
          Iniciar sesión
        </h2>
        <p className="text-sm text-[var(--login-muted)]">
          Ingresá tus credenciales para acceder.
        </p>
      </div>

      <FormField
        label="Correo electrónico"
        htmlFor="email"
        error={errors.email?.message}
      >
        <Input
          id="email"
          type="email"
          autoComplete="username"
          placeholder="usuario@jass.pe"
          className="login-field"
          aria-invalid={Boolean(errors.email)}
          {...register('email')}
        />
      </FormField>

      <FormField
        label="Contraseña"
        htmlFor="password"
        error={errors.password?.message}
      >
        <div className="relative">
          <Input
            id="password"
            type={showPassword ? 'text' : 'password'}
            autoComplete="current-password"
            placeholder="••••••••"
            className="login-field pr-10"
            aria-invalid={Boolean(errors.password)}
            {...register('password')}
          />
          <button
            type="button"
            className="absolute top-1/2 right-2 flex h-7 w-7 -translate-y-1/2 items-center justify-center rounded-full text-[var(--login-muted)] hover:text-[var(--login-ink)]"
            aria-label={showPassword ? 'Ocultar contraseña' : 'Mostrar contraseña'}
            aria-pressed={showPassword}
            onClick={() => setShowPassword((current) => !current)}
          >
            <Icon icon={showPassword ? EyeOff : Eye} size={16} />
          </button>
        </div>
      </FormField>

      {signIn.isError ? (
        <p
          role="alert"
          className="rounded-md border border-red-300/40 bg-red-950/50 px-3 py-2 text-sm text-red-100"
        >
          {authErrorMessage(signIn.error)}
        </p>
      ) : null}

      <Button type="submit" className="login-submit" disabled={signIn.isPending}>
        {signIn.isPending ? (
          <>
            <Icon icon={LoaderCircle} className="animate-spin" />
            Ingresando…
          </>
        ) : (
          <>
            Iniciar sesión
            <Icon icon={ArrowRight} size={16} />
          </>
        )}
      </Button>
    </form>
  )
}
