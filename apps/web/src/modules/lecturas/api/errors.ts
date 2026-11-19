import type { PostgrestError } from '@supabase/supabase-js'

export function asHidrometriaError(error: PostgrestError): Error {
  if (error.code === '23505') {
    return new Error('Ya existe un registro para ese predio, servicio y periodo.')
  }
  if (error.code === '23503') {
    return new Error('No se puede guardar porque hay datos relacionados.')
  }
  if (error.code === 'P0001') {
    const message = error.message.toLowerCase()
    if (message.includes('marca')) return new Error('Seleccioná una marca de medidor.')
    if (message.includes('medidor')) {
      return new Error('No se puede registrar la lectura porque el predio no tiene un medidor asignado.')
    }
    return new Error(error.message)
  }
  return new Error(error.message)
}

export function embedOne<T>(value: T | T[] | null | undefined): T | null {
  if (value == null) return null
  if (Array.isArray(value)) return value[0] ?? null
  return value
}
