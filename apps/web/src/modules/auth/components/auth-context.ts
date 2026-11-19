import { createContext } from 'react'
import type { AuthState } from '@/modules/auth/types'

export const AuthContext = createContext<AuthState | null>(null)
