import type { PostgrestError } from '@supabase/supabase-js'

export function asCobranzaError(error: PostgrestError): Error {
  if (error.code === 'P0001') {
    const message = error.message.replace(/^.*ERROR:\s*/i, '').trim()
    return new Error(message || 'No se pudo registrar el cobro.')
  }
  if (error.code === '23505') {
    return new Error('Esa facturación ya tiene un pago registrado.')
  }
  return new Error(error.message)
}
