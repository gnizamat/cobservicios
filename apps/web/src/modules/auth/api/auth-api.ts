import { supabase } from '@/shared/lib/supabase'
import type { LoginInput } from '@/modules/auth/schemas'

export async function signInWithPassword({ email, password }: LoginInput) {
  const { data, error } = await supabase.auth.signInWithPassword({
    email,
    password,
  })

  if (error) {
    throw error
  }

  return data
}

export async function signOut() {
  const { error } = await supabase.auth.signOut()
  if (error) {
    throw error
  }
}

export async function getSession() {
  const { data, error } = await supabase.auth.getSession()
  if (error) {
    throw error
  }
  return data.session
}
