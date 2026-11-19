import type { PostgrestError } from '@supabase/supabase-js'

export function asCatalogError(error: PostgrestError): Error {
  if (error.code === '23505') {
    return new Error('Ya existe un registro con esos datos.')
  }
  if (error.code === '23503') {
    return new Error('No se puede guardar porque hay datos relacionados.')
  }
  return new Error(error.message)
}

export function embedOne<T>(value: T | T[] | null | undefined): T | null {
  if (value == null) return null
  if (Array.isArray(value)) return value[0] ?? null
  return value
}
