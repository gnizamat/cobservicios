/** Public API for the auth module. Import from '@/modules/auth' only. */
export { loginSchema, type LoginInput } from './schemas'
export { useSignIn, useSignOut, signInWithPassword, signOut, getSession } from './api'
export { AuthProvider } from './components/auth-provider'
export { useAuth } from './components/use-auth'
export { RequireAuth } from './components/require-auth'
export { GuestOnly } from './components/guest-only'
export { LoginPage } from './pages/login-page'
export type { AuthState, AuthUser, AuthSession } from './types'
