import type { Session, User } from '@supabase/supabase-js'

export type AuthUser = User
export type AuthSession = Session

export interface AuthState {
  session: AuthSession | null
  user: AuthUser | null
  isLoading: boolean
  isAuthenticated: boolean
}
