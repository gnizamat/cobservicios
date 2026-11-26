import type { PostgrestError } from '@supabase/supabase-js'
import { supabase } from '@/shared/lib/supabase'
import type { HidMarcaMedidor } from '@/shared/types/database'

export interface MarcaMedidorInput {
  nombre: string
  procedencia: string
}

function fail(error: PostgrestError): never {
  if (error.code === '23505') throw new Error('Ya existe una marca con ese nombre.')
  throw new Error(error.message.replace(/^.*?:\s*/, ''))
}

export async function listMarcasMedidorConfig(): Promise<HidMarcaMedidor[]> {
  const { data, error } = await supabase
    .from('hid_marcas_medidor')
    .select('*')
    .order('nombre', { ascending: true })
  if (error) fail(error)
  return data ?? []
}

export async function saveMarcaMedidor(
  id: string | null,
  input: MarcaMedidorInput,
): Promise<string> {
  const payload = {
    nombre: input.nombre.trim(),
    procedencia: input.procedencia.trim(),
  }
  const query = id
    ? supabase.from('hid_marcas_medidor').update(payload).eq('id', id)
    : supabase.from('hid_marcas_medidor').insert(payload)
  const { data, error } = await query.select('id').single()
  if (error) fail(error)
  return data.id
}
