import type { TipoPersona } from '@/shared/types/database'

export interface UsuarioResumen {
  id: string
  tipo_persona: TipoPersona
  nombres: string
  apellido_paterno: string
  apellido_materno: string
  dni: string | null
  ruc: string | null
}

export interface PredioDeUsuario {
  id: string
  nombre: string
  numero: string
  manzana: string
  lote: string
  calle_nombre: string
}

export interface PredioHistorialItem {
  id: string
  predio_id: string
  usuario_id: string
  transferencia_id: string | null
  referencia: string
  vigente: boolean
  desde: string
  hasta: string | null
  nombre_predio: string
  numero: string
  manzana: string
  lote: string
  calle_nombre: string
  usuario: UsuarioResumen | null
}

export interface TransferenciaPredioLinea {
  id: string
  predio_id: string
  nombre_predio: string
  numero: string
  manzana: string
  lote: string
  calle_nombre: string
}

export interface TransferenciaListItem {
  id: string
  referencia: string
  created_at: string
  origen: UsuarioResumen | null
  destino: UsuarioResumen | null
  predios: TransferenciaPredioLinea[]
}
