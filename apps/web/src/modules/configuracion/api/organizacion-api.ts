import { asOrganizacionError } from '@/modules/configuracion/api/errors'
import type { DatosJassValues, UbicacionValues } from '@/modules/configuracion/schemas'
import { supabase } from '@/shared/lib/supabase'
import type { Database } from '@/shared/types/database'

const BUCKET = 'organizacion'

export type Organizacion = Database['public']['Tables']['org_jass']['Row']

export function logoPublicUrl(path: string | null | undefined) {
  if (!path) return null
  const { data } = supabase.storage.from(BUCKET).getPublicUrl(path)
  return data.publicUrl
}

export async function getOrganizacion(): Promise<Organizacion> {
  const { data, error } = await supabase.from('org_jass').select('*').eq('id', true).maybeSingle()
  if (error) throw asOrganizacionError(error)
  if (!data) throw new Error('No hay datos de la JASS.')
  return data
}

export async function saveDatosJass(values: DatosJassValues): Promise<Organizacion> {
  const { data, error } = await supabase
    .from('org_jass')
    .update({
      nombre: values.nombre.trim(),
      abreviatura: values.abreviatura.trim(),
      celular: values.celular.trim(),
      direccion: values.direccion.trim(),
      email: values.email.trim(),
    })
    .eq('id', true)
    .select('*')
    .single()
  if (error) throw asOrganizacionError(error)
  return data
}

export async function saveUbicacion(values: UbicacionValues): Promise<Organizacion> {
  const latitud = values.latitud === '' ? null : Number(values.latitud)
  const longitud = values.longitud === '' ? null : Number(values.longitud)
  const { data, error } = await supabase
    .from('org_jass')
    .update({ latitud, longitud })
    .eq('id', true)
    .select('*')
    .single()
  if (error) throw asOrganizacionError(error)
  return data
}

export async function uploadLogo(file: File): Promise<Organizacion> {
  const extension = file.type === 'image/png' ? 'png' : file.type === 'image/webp' ? 'webp' : 'jpg'
  const path = `logo/${crypto.randomUUID()}.${extension}`
  const { error: uploadError } = await supabase.storage.from(BUCKET).upload(path, file, {
    contentType: file.type,
    upsert: false,
  })
  if (uploadError) throw new Error(uploadError.message)

  const current = await getOrganizacion()
  const { data, error } = await supabase
    .from('org_jass')
    .update({ logo_path: path })
    .eq('id', true)
    .select('*')
    .single()
  if (error) throw asOrganizacionError(error)

  if (current.logo_path && current.logo_path !== path) {
    await supabase.storage.from(BUCKET).remove([current.logo_path])
  }
  return data
}

export async function removeLogo(): Promise<Organizacion> {
  const current = await getOrganizacion()
  const { data, error } = await supabase
    .from('org_jass')
    .update({ logo_path: '' })
    .eq('id', true)
    .select('*')
    .single()
  if (error) throw asOrganizacionError(error)
  if (current.logo_path) {
    await supabase.storage.from(BUCKET).remove([current.logo_path])
  }
  return data
}
