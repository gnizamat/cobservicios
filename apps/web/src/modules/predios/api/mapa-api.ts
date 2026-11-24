import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { supabase } from '@/shared/lib/supabase'

export interface PredioMapa {
  id: string
  nombre: string
  numero: string
  manzana: string
  lote: string
  latitud: number | null
  longitud: number | null
  sectorId: string | null
  sector: string
  calleId: string | null
  calle: string
  usuario: string
  documento: string
}

interface Relacion {
  id?: string
  nombre?: string
  nombres?: string
  apellido_paterno?: string
  apellido_materno?: string
  dni?: string | null
}

function uno<T>(value: T | T[] | null): T | null {
  if (Array.isArray(value)) return value[0] ?? null
  return value
}

function nombreUsuario(usuario: Relacion | null) {
  if (!usuario) return 'Sin usuario'
  return [usuario.apellido_paterno, usuario.apellido_materno, usuario.nombres]
    .map((parte) => parte?.trim())
    .filter(Boolean)
    .join(' ')
}

export async function listPrediosMapa(): Promise<PredioMapa[]> {
  const { data, error } = await supabase
    .from('pad_predios')
    .select(
      'id, nombre, numero, manzana, lote, latitud, longitud, sector_id, calle_id, sector:cat_sectores(id, nombre), calle:cat_calles(id, nombre), usuario:pad_usuarios(nombres, apellido_paterno, apellido_materno, dni)',
    )
    .eq('estado', 'activo')
    .order('nombre', { ascending: true })
    .range(0, 1999)
  if (error) throw error

  return (data ?? []).map((row) => {
    const sector = uno(row.sector as Relacion | Relacion[] | null)
    const calle = uno(row.calle as Relacion | Relacion[] | null)
    const usuario = uno(row.usuario as Relacion | Relacion[] | null)
    return {
      id: row.id,
      nombre: row.nombre,
      numero: row.numero,
      manzana: row.manzana,
      lote: row.lote,
      latitud: row.latitud,
      longitud: row.longitud,
      sectorId: row.sector_id,
      sector: sector?.nombre?.trim() || 'Sin centro poblado',
      calleId: row.calle_id,
      calle: calle?.nombre?.trim() || 'Sin calle',
      usuario: nombreUsuario(usuario),
      documento: usuario?.dni?.trim() || '',
    }
  })
}

export function usePrediosMapa() {
  return useQuery({
    queryKey: ['predios', 'mapa'],
    queryFn: listPrediosMapa,
  })
}

export function useUbicarPredio() {
  const client = useQueryClient()
  return useMutation({
    mutationFn: async (input: { id: string; latitud: number; longitud: number }) => {
      const { error } = await supabase
        .from('pad_predios')
        .update({ latitud: input.latitud, longitud: input.longitud })
        .eq('id', input.id)
      if (error) throw error
    },
    onSuccess: () => {
      void client.invalidateQueries({ queryKey: ['predios', 'mapa'] })
    },
  })
}
