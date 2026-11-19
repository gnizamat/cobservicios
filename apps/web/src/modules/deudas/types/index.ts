import type { CategoriaServicio, FacDeudaAnterior, TipoPersona } from '@/shared/types/database'

export type UsuarioPredio = {
  id: string
  nombres: string
  apellido_paterno: string
  apellido_materno: string
  dni: string | null
  tipo_persona: TipoPersona
}

export type PredioDeudaOption = {
  id: string
  nombre: string
  numero: string
  manzana: string
  lote: string
  calle: { nombre: string } | null
  usuario: UsuarioPredio | null
}

export type PredioBusqueda = {
  items: PredioDeudaOption[]
  total: number
}

export type TarifaAnio = {
  id: string
  anio: number
  nombre: string
  activa: boolean
}

export type CostoTarifaOption = {
  id: string
  tarifa_id: string
  tipo_servicio_id: string
  anio: number
  valor: number
  monto: number
  servicio_nombre: string
  servicio_codigo: string
  categoria: CategoriaServicio
}

export type PredioDeudaFija = {
  predio_id: string
  predio: string
  numero: string
  usuario: string
  sector: string
  calle: string
}

export type GenerarDeudasFijasResultado = {
  generadas: number
  monto: number
  total: number
}

export type DeudaAnteriorListItem = FacDeudaAnterior & {
  servicio: {
    id: string
    codigo: string
    nombre: string
    categoria: CategoriaServicio
  } | null
  tarifa: {
    id: string
    anio: number
    nombre: string
  } | null
}
