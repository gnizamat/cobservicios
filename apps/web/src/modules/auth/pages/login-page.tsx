import { AuthLayout } from '@/design-system/templates'
import { LoginForm } from '@/modules/auth/components/login-form'

export function LoginPage() {
  return (
    <AuthLayout
      slogan={
        <>
          <p className="login-scene__status">
            <span className="login-scene__pulse" aria-hidden />
            Sistema en operación
          </p>
          <h1 className="login-scene__title">
            <span className="login-scene__line">Agua Limpia, segura y salud</span>
            <span className="login-scene__line">para todas nuestras familias</span>
          </h1>
          <p className="login-scene__lead">JUNTA ADMINISTRADORA DE SERVICIOS JASS</p>
        </>
      }
    >
      <LoginForm />
    </AuthLayout>
  )
}
