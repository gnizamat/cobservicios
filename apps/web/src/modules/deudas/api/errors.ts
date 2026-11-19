import type { PostgrestError } from '@supabase/supabase-js'

export function asDeudaError(error: PostgrestError): Error {
  if (error.code === '23505') {
    return new Error('Ya existe una deuda de ese tipo de tarifa para el mismo año y mes.')
  }
  if (error.code === '23514') {
    return new Error('Revisá el monto, la mora y el volumen. El monto debe ser mayor a cero.')
  }
  if (error.code === '23503') {
    return new Error('No se puede guardar porque el predio o la tarifa ya no existen.')
  }
  if (error.code === 'P0001') {
    const message = error.message.replace(/^.*ERROR:\s*/i, '').trim()
    return new Error(message || 'No se pudo registrar la deuda.')
  }
  return new Error(error.message)
}

export function embedOne<T>(value: T | T[] | null | undefined): T | null {
  if (value == null) return null
  if (Array.isArray(value)) return value[0] ?? null
  return value
}
