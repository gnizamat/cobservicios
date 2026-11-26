import { useQuery } from '@tanstack/react-query'
import { supabase } from '@/shared/lib/supabase'

export interface PersonaDni {
  nombres: string
  apellidoPaterno: string
  apellidoMaterno: string
}

export interface ColaboradorSector {
  id: string
  nombre: string
  codigo: string
  activo: boolean
}

export interface ColaboradorHidrometria {
  id: string
  dni: string
  apellido_paterno: string
  apellido_materno: string
  nombres: string
  sectores: ColaboradorSector[]
}

export interface ColaboradorInput {
  dni: string
  apellido_paterno: string
  apellido_materno: string
  nombres: string
  sector_ids: string[]
}

interface AsignacionRow {
  sector_id: string
  sector: ColaboradorSector | ColaboradorSector[] | null
}

interface ColaboradorRow {
  id: string
  dni: string
  apellido_paterno: string
  apellido_materno: string
  nombres: string
  asignaciones: AsignacionRow[] | null
}

function sectorDe(asignacion: AsignacionRow): ColaboradorSector | null {
  const sector = asignacion.sector
  if (!sector) return null
  return Array.isArray(sector) ? (sector[0] ?? null) : sector
}

function mensaje(error: { message: string }) {
  return new Error(error.message.replace(/^.*?:\s*/, ''))
}

export async function listColaboradores(): Promise<ColaboradorHidrometria[]> {
  const { data, error } = await supabase
    .from('hid_colaboradores')
    .select(
      'id, dni, apellido_paterno, apellido_materno, nombres, asignaciones:hid_colaborador_sectores(sector_id, sector:cat_sectores(id, nombre, codigo, activo))',
    )
    .order('apellido_paterno', { ascending: true })
    .order('apellido_materno', { ascending: true })
    .order('nombres', { ascending: true })

  if (error) throw mensaje(error)

  return ((data ?? []) as ColaboradorRow[]).map((row) => ({
    id: row.id,
    dni: row.dni,
    apellido_paterno: row.apellido_paterno,
    apellido_materno: row.apellido_materno,
    nombres: row.nombres,
    sectores: (row.asignaciones ?? [])
      .map(sectorDe)
      .filter((sector): sector is ColaboradorSector => sector !== null)
      .sort((a, b) => a.nombre.localeCompare(b.nombre, 'es')),
  }))
}

export async function saveColaborador(id: string | null, input: ColaboradorInput): Promise<string> {
  const { data, error } = await supabase.rpc('guardar_colaborador_hidrometria', {
    p_id: id,
    p_dni: input.dni,
    p_apellido_paterno: input.apellido_paterno,
    p_apellido_materno: input.apellido_materno,
    p_nombres: input.nombres,
    p_sector_ids: input.sector_ids,
  })
  if (error) throw mensaje(error)
  if (!data) throw new Error('No se pudo guardar el colaborador')
  return data
}

export function useConsultaDniActiva() {
  return useQuery({
    queryKey: ['configuracion', 'consulta-dni-activa'],
    queryFn: async () => {
      const { data, error } = await supabase.rpc('consulta_dni_activa')
      if (error) throw error
      return data === true
    },
    staleTime: 30_000,
  })
}

export async function consultarPersonaDni(dni: string): Promise<PersonaDni> {
  const { data, error } = await supabase.rpc('consultar_dni', { p_dni: dni })
  if (error) throw mensaje(error)
  const persona = (data ?? {}) as {
    nombres?: string
    apellido_paterno?: string
    apellido_materno?: string
  }
  return {
    nombres: persona.nombres?.trim() ?? '',
    apellidoPaterno: persona.apellido_paterno?.trim() ?? '',
    apellidoMaterno: persona.apellido_materno?.trim() ?? '',
  }
}

export function usePersonaDni(dni: string, enabled: boolean) {
  return useQuery({
    queryKey: ['configuracion', 'consulta-dni', dni],
    queryFn: () => consultarPersonaDni(dni),
    enabled,
    retry: false,
    staleTime: Number.POSITIVE_INFINITY,
  })
}
