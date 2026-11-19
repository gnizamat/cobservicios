import type { PostgrestError } from '@supabase/supabase-js'

export function asOrganizacionError(error: PostgrestError): Error {
  return new Error(error.message)
}
