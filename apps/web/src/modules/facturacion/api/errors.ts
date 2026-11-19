import type { PostgrestError } from '@supabase/supabase-js'

export function asFacturacionError(error: PostgrestError): Error {
  if (error.code === '23505') {
    return new Error('Ese predio ya tiene facturación para el año y mes elegidos.')
  }
  if (error.code === 'P0001') {
    const message = error.message.replace(/^.*ERROR:\s*/i, '').trim()
    return new Error(message || 'No se pudo generar la facturación.')
  }
  return new Error(error.message)
}
