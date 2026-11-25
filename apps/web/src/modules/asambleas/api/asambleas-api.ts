import type { PostgrestError } from '@supabase/supabase-js'
import { supabase } from '@/shared/lib/supabase'
import type { AsmAsamblea, AsmPadron, CatSector, EstadoRegistro } from '@/shared/types/database'

function fail(error: PostgrestError): never {
  if (error.code === '23503') {
    throw new Error('No se puede eliminar porque hay datos relacionados.')
  }
  throw new Error(error.message)
}

export type AmbitoAsamblea = 'principal' | 'anexo'
export type TipoAsamblea = 'ordinaria' | 'extraordinaria'

export interface AsambleaInput {
  sectorId: string
  descripcion: string
  anio: number
  tipo: TipoAsamblea
  ambito: AmbitoAsamblea
  fecha: string
  estado: EstadoRegistro
}

export interface AsambleaListItem extends AsmAsamblea {
  sector: Pick<CatSector, 'id' | 'nombre'> | null
}

export interface PadronItem extends AsmPadron {
  predio: { nombre: string; numero: string; manzana: string; lote: string } | null
  calle: string
  sectorNombre: string
  dni: string
  nombres: string
  apellidos: string
}

function uno<T>(value: T | T[] | null | undefined): T | null {
  if (value == null) return null
  return Array.isArray(value) ? (value[0] ?? null) : value
}

export async function listSectoresAsamblea(): Promise<Pick<CatSector, 'id' | 'nombre'>[]> {
  const { data, error } = await supabase.from('cat_sectores').select('id, nombre').eq('activo', true).order('nombre')
  if (error) fail(error)
  return data ?? []
}

export async function listAsambleas(): Promise<AsambleaListItem[]> {
  const { data, error } = await supabase
    .from('asm_asambleas')
    .select('*, sector:cat_sectores(id, nombre)')
    .order('anio', { ascending: false })
    .order('fecha', { ascending: false })
  if (error) fail(error)
  return (data ?? []) as AsambleaListItem[]
}

export async function saveAsamblea(id: string | null, input: AsambleaInput): Promise<string> {
  const payload = {
    sector_id: input.sectorId,
    descripcion: input.descripcion,
    anio: input.anio,
    tipo: input.tipo,
    ambito: input.ambito,
    fecha: input.fecha,
    estado: input.estado,
  }
  const query = id
    ? supabase.from('asm_asambleas').update(payload).eq('id', id)
    : supabase.from('asm_asambleas').insert(payload)
  const { data, error } = await query.select('id').single()
  if (error) fail(error)
  return data.id
}

export async function setEstadoAsamblea(id: string, estado: EstadoRegistro): Promise<void> {
  const { error } = await supabase.from('asm_asambleas').update({ estado }).eq('id', id)
  if (error) fail(error)
}

export async function deleteAsamblea(id: string): Promise<void> {
  const { error } = await supabase.from('asm_asambleas').delete().eq('id', id)
  if (error) fail(error)
}

export async function listPadron(asambleaId: string): Promise<PadronItem[]> {
  const { data, error } = await supabase
    .from('asm_padron')
    .select(
      '*, predio:pad_predios(nombre, numero, manzana, lote, calle:cat_calles(nombre), sector:cat_sectores(nombre)), usuario:pad_usuarios(dni, nombres, apellido_paterno, apellido_materno)',
    )
    .eq('asamblea_id', asambleaId)
    .order('correlativo', { ascending: true })
  if (error) fail(error)
  return (data ?? []).map((row) => {
    const predio = uno(row.predio)
    const calle = uno(predio?.calle)
    const sector = uno(predio?.sector)
    const usuario = uno(row.usuario)
    const apellidos = [usuario?.apellido_paterno, usuario?.apellido_materno]
      .map((parte) => parte?.trim())
      .filter(Boolean)
      .join(' ')
    return {
      ...row,
      predio: predio
        ? {
            nombre: predio.nombre,
            numero: predio.numero,
            manzana: predio.manzana,
            lote: predio.lote,
          }
        : null,
      calle: calle?.nombre?.trim() || 'Sin calle',
      sectorNombre: sector?.nombre?.trim() || '',
      dni: usuario?.dni?.trim() || row.documento,
      nombres: usuario?.nombres?.trim() || '',
      apellidos,
    }
  })
}

export async function marcarAsistencia(id: string, asistencia: boolean): Promise<void> {
  const { data: actual, error: readError } = await supabase
    .from('asm_padron')
    .select('habil')
    .eq('id', id)
    .single()
  if (readError) fail(readError)
  if (!actual.habil) {
    throw new Error('Solo se marca la asistencia de un usuario hábil, sin deuda de tarifa ni aporte.')
  }
  const { error } = await supabase.from('asm_padron').update({ asistencia }).eq('id', id)
  if (error) fail(error)
}

export async function generarPadron(asambleaId: string): Promise<number> {
  const { data, error } = await supabase.rpc('generar_padron_asamblea', {
    p_asamblea_id: asambleaId,
  })
  if (error) fail(error)
  return data ?? 0
}
