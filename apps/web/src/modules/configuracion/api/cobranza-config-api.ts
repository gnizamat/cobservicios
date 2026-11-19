import type { PostgrestError } from '@supabase/supabase-js'
import { supabase } from '@/shared/lib/supabase'
import type {
  CatBanco,
  CatConceptoMulta,
  CatDocumento,
  CatInteres,
  CobCaja,
  EstadoRegistro,
} from '@/shared/types/database'

function fail(error: PostgrestError): never {
  if (error.code === '23505') throw new Error('Ya existe un registro con esos datos.')
  throw new Error(error.message)
}

export interface ConceptoMultaInput {
  nombre: string
  monto: number
  estado: EstadoRegistro
}

export interface InteresInput {
  nombre: string
  porcentaje: number
  estado: EstadoRegistro
}

export interface BancoInput {
  nombre: string
  cuenta: string
  estado: EstadoRegistro
}

export interface CajaInput {
  nombre: string
  activa: boolean
}

export interface DocumentoInput {
  codigo: string
  nombre: string
  estado: EstadoRegistro
}

export async function listConceptosMulta(): Promise<CatConceptoMulta[]> {
  const { data, error } = await supabase
    .from('cat_conceptos_multa')
    .select('*')
    .order('nombre', { ascending: true })
  if (error) fail(error)
  return data ?? []
}

export async function saveConceptoMulta(
  id: string | null,
  input: ConceptoMultaInput,
): Promise<string> {
  const query = id
    ? supabase.from('cat_conceptos_multa').update(input).eq('id', id)
    : supabase.from('cat_conceptos_multa').insert(input)
  const { data, error } = await query.select('id').single()
  if (error) fail(error)
  return data.id
}

export async function listIntereses(): Promise<CatInteres[]> {
  const { data, error } = await supabase
    .from('cat_intereses')
    .select('*')
    .order('nombre', { ascending: true })
  if (error) fail(error)
  return data ?? []
}

export async function saveInteres(id: string | null, input: InteresInput): Promise<string> {
  const query = id
    ? supabase.from('cat_intereses').update(input).eq('id', id)
    : supabase.from('cat_intereses').insert(input)
  const { data, error } = await query.select('id').single()
  if (error) fail(error)
  return data.id
}

export async function listBancos(): Promise<CatBanco[]> {
  const { data, error } = await supabase
    .from('cat_bancos')
    .select('*')
    .order('nombre', { ascending: true })
  if (error) fail(error)
  return data ?? []
}

export async function saveBanco(id: string | null, input: BancoInput): Promise<string> {
  const query = id
    ? supabase.from('cat_bancos').update(input).eq('id', id)
    : supabase.from('cat_bancos').insert(input)
  const { data, error } = await query.select('id').single()
  if (error) fail(error)
  return data.id
}

export async function listCajasConfig(): Promise<CobCaja[]> {
  const { data, error } = await supabase
    .from('cob_cajas')
    .select('*')
    .order('nombre', { ascending: true })
  if (error) fail(error)
  return data ?? []
}

export async function saveCaja(id: string | null, input: CajaInput): Promise<string> {
  const query = id
    ? supabase.from('cob_cajas').update(input).eq('id', id)
    : supabase.from('cob_cajas').insert(input)
  const { data, error } = await query.select('id').single()
  if (error) fail(error)
  return data.id
}

export async function listDocumentos(): Promise<CatDocumento[]> {
  const { data, error } = await supabase
    .from('cat_documentos')
    .select('*')
    .order('codigo', { ascending: true })
  if (error) fail(error)
  return data ?? []
}

export async function saveDocumento(id: string | null, input: DocumentoInput): Promise<string> {
  const query = id
    ? supabase.from('cat_documentos').update(input).eq('id', id)
    : supabase.from('cat_documentos').insert(input)
  const { data, error } = await query.select('id').single()
  if (error) fail(error)
  return data.id
}
