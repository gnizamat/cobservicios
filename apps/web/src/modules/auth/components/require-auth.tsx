import { Navigate, Outlet, useLocation } from 'react-router-dom'
import { useAuth } from '@/modules/auth/components/use-auth'

export function RequireAuth() {
  const { isAuthenticated, isLoading } = useAuth()
  const location = useLocation()

  if (isLoading) {
    return (
      <div className="flex min-h-screen items-center justify-center bg-background text-sm text-muted-foreground">
        Verificando sesión…
      </div>
    )
  }

  if (!isAuthenticated) {
    return <Navigate to="/acceso" replace state={{ from: location.pathname }} />
  }

  return <Outlet />
}
