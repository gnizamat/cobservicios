export type Json =
  | string
  | number
  | boolean
  | null
  | { [key: string]: Json | undefined }
  | Json[]

export type TipoPersona = 'natural' | 'juridica' | 'institucional'
export type Sexo = 'M' | 'F'
export type EstadoRegistro = 'activo' | 'inactivo'
export type CategoriaServicio =
  | 'fijo'
  | 'unico'
  | 'volumen'
  | 'alcantarillado'
  | 'medidor'

export type Database = {
  public: {
    Tables: {
      cat_sectores: {
        Row: {
          id: string
          codigo: string
          nombre: string
          activo: boolean
          created_at: string
        }
        Insert: {
          id?: string
          codigo: string
          nombre: string
          activo?: boolean
          created_at?: string
        }
        Update: Partial<Database['public']['Tables']['cat_sectores']['Insert']>
        Relationships: []
      }
      cat_calles: {
        Row: {
          id: string
          sector_id: string | null
          nombre: string
          referencia: string
          created_at: string
        }
        Insert: {
          id?: string
          sector_id?: string | null
          nombre: string
          referencia?: string
          created_at?: string
        }
        Update: Partial<Database['public']['Tables']['cat_calles']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'cat_calles_sector_id_fkey'
            columns: ['sector_id']
            isOneToOne: false
            referencedRelation: 'cat_sectores'
            referencedColumns: ['id']
          },
        ]
      }
      cat_tipos_predio: {
        Row: {
          id: string
          codigo: string
          nombre: string
        }
        Insert: {
          id?: string
          codigo: string
          nombre: string
        }
        Update: Partial<Database['public']['Tables']['cat_tipos_predio']['Insert']>
        Relationships: []
      }
      pad_usuarios: {
        Row: {
          id: string
          tipo_persona: TipoPersona
          nombres: string
          apellido_paterno: string
          apellido_materno: string
          dni: string | null
          ruc: string | null
          sexo: Sexo | null
          direccion: string
          email: string | null
          celular: string | null
          estado: EstadoRegistro
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          tipo_persona?: TipoPersona
          nombres: string
          apellido_paterno?: string
          apellido_materno?: string
          dni?: string | null
          ruc?: string | null
          sexo?: Sexo | null
          direccion?: string
          email?: string | null
          celular?: string | null
          estado?: EstadoRegistro
          created_at?: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['pad_usuarios']['Insert']>
        Relationships: []
      }
      pad_predios: {
        Row: {
          id: string
          usuario_id: string
          tipo_predio_id: string | null
          sector_id: string | null
          calle_id: string | null
          nombre: string
          numero: string
          manzana: string
          lote: string
          partida_registral: string
          unidad_catastral: string
          titulo: string
          fecha_documento: string | null
          coord_este: string
          coord_norte: string
          latitud: number | null
          longitud: number | null
          estado: EstadoRegistro
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          usuario_id: string
          tipo_predio_id?: string | null
          sector_id?: string | null
          calle_id?: string | null
          nombre: string
          numero?: string
          manzana?: string
          lote?: string
          partida_registral?: string
          unidad_catastral?: string
          titulo?: string
          fecha_documento?: string | null
          coord_este?: string
          coord_norte?: string
          latitud?: number | null
          longitud?: number | null
          estado?: EstadoRegistro
          created_at?: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['pad_predios']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'pad_predios_usuario_id_fkey'
            columns: ['usuario_id']
            isOneToOne: false
            referencedRelation: 'pad_usuarios'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'pad_predios_tipo_predio_id_fkey'
            columns: ['tipo_predio_id']
            isOneToOne: false
            referencedRelation: 'cat_tipos_predio'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'pad_predios_sector_id_fkey'
            columns: ['sector_id']
            isOneToOne: false
            referencedRelation: 'cat_sectores'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'pad_predios_calle_id_fkey'
            columns: ['calle_id']
            isOneToOne: false
            referencedRelation: 'cat_calles'
            referencedColumns: ['id']
          },
        ]
      }
      pad_transferencias: {
        Row: {
          id: string
          usuario_origen_id: string
          usuario_destino_id: string
          referencia: string
          created_at: string
          created_by: string | null
        }
        Insert: {
          id?: string
          usuario_origen_id: string
          usuario_destino_id: string
          referencia?: string
          created_at?: string
          created_by?: string | null
        }
        Update: Partial<Database['public']['Tables']['pad_transferencias']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'pad_transferencias_usuario_origen_id_fkey'
            columns: ['usuario_origen_id']
            isOneToOne: false
            referencedRelation: 'pad_usuarios'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'pad_transferencias_usuario_destino_id_fkey'
            columns: ['usuario_destino_id']
            isOneToOne: false
            referencedRelation: 'pad_usuarios'
            referencedColumns: ['id']
          },
        ]
      }
      pad_predio_historial: {
        Row: {
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
          created_at: string
        }
        Insert: {
          id?: string
          predio_id: string
          usuario_id: string
          transferencia_id?: string | null
          referencia?: string
          vigente?: boolean
          desde?: string
          hasta?: string | null
          nombre_predio?: string
          numero?: string
          manzana?: string
          lote?: string
          calle_nombre?: string
          created_at?: string
        }
        Update: Partial<Database['public']['Tables']['pad_predio_historial']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'pad_predio_historial_predio_id_fkey'
            columns: ['predio_id']
            isOneToOne: false
            referencedRelation: 'pad_predios'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'pad_predio_historial_usuario_id_fkey'
            columns: ['usuario_id']
            isOneToOne: false
            referencedRelation: 'pad_usuarios'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'pad_predio_historial_transferencia_id_fkey'
            columns: ['transferencia_id']
            isOneToOne: false
            referencedRelation: 'pad_transferencias'
            referencedColumns: ['id']
          },
        ]
      }
      cat_tipos_servicio: {
        Row: {
          id: string
          codigo: string
          nombre: string
          categoria: CategoriaServicio
          estado: EstadoRegistro
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          codigo: string
          nombre: string
          categoria?: CategoriaServicio
          estado?: EstadoRegistro
          created_at?: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['cat_tipos_servicio']['Insert']>
        Relationships: []
      }
      cat_tarifas: {
        Row: {
          id: string
          anio: number
          nombre: string
          modalidad: string
          unidad_recaudacion: string
          activa: boolean
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          anio: number
          nombre: string
          modalidad?: string
          unidad_recaudacion?: string
          activa?: boolean
          created_at?: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['cat_tarifas']['Insert']>
        Relationships: []
      }
      cat_costos_tarifa: {
        Row: {
          id: string
          tarifa_id: string
          tipo_servicio_id: string
          valor: number
          monto: number
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          tarifa_id: string
          tipo_servicio_id: string
          valor?: number
          monto?: number
          created_at?: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['cat_costos_tarifa']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'cat_costos_tarifa_tarifa_id_fkey'
            columns: ['tarifa_id']
            isOneToOne: false
            referencedRelation: 'cat_tarifas'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'cat_costos_tarifa_tipo_servicio_id_fkey'
            columns: ['tipo_servicio_id']
            isOneToOne: false
            referencedRelation: 'cat_tipos_servicio'
            referencedColumns: ['id']
          },
        ]
      }
      cat_costos_tarifa_historial: {
        Row: {
          id: string
          costo_id: string
          tarifa_id: string
          tipo_servicio_id: string
          monto_anterior: number
          monto_nuevo: number
          valor_anterior: number
          valor_nuevo: number
          created_at: string
          created_by: string | null
        }
        Insert: {
          id?: string
          costo_id: string
          tarifa_id: string
          tipo_servicio_id: string
          monto_anterior: number
          monto_nuevo: number
          valor_anterior: number
          valor_nuevo: number
          created_at?: string
          created_by?: string | null
        }
        Update: Partial<Database['public']['Tables']['cat_costos_tarifa_historial']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'cat_costos_tarifa_historial_costo_id_fkey'
            columns: ['costo_id']
            isOneToOne: false
            referencedRelation: 'cat_costos_tarifa'
            referencedColumns: ['id']
          },
        ]
      }
      hid_estructuras: {
        Row: {
          id: string
          codigo: string
          nombre: string
          created_at: string
        }
        Insert: {
          id?: string
          codigo: string
          nombre: string
          created_at?: string
        }
        Update: Partial<Database['public']['Tables']['hid_estructuras']['Insert']>
        Relationships: []
      }
      hid_marcas_medidor: {
        Row: {
          id: string
          nombre: string
          created_at: string
        }
        Insert: {
          id?: string
          nombre: string
          created_at?: string
        }
        Update: Partial<Database['public']['Tables']['hid_marcas_medidor']['Insert']>
        Relationships: []
      }
      hid_medidores: {
        Row: {
          id: string
          predio_id: string
          codigo: string
          marca_id: string | null
          marca: string
          fecha_instalacion: string
          estado: EstadoRegistro
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          predio_id: string
          codigo: string
          marca_id: string
          marca?: string
          fecha_instalacion: string
          estado?: EstadoRegistro
          created_at?: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['hid_medidores']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'hid_medidores_predio_id_fkey'
            columns: ['predio_id']
            isOneToOne: false
            referencedRelation: 'pad_predios'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'hid_medidores_marca_id_fkey'
            columns: ['marca_id']
            isOneToOne: false
            referencedRelation: 'hid_marcas_medidor'
            referencedColumns: ['id']
          },
        ]
      }
      hid_lecturas: {
        Row: {
          id: string
          predio_id: string
          tipo_servicio_id: string
          anio: number
          mes: number
          fecha_lectura: string
          lectura_m3: number
          lectura_lt: number
          volumen_m3: number
          referencia: string
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          predio_id: string
          tipo_servicio_id: string
          anio: number
          mes: number
          fecha_lectura: string
          lectura_m3?: number
          lectura_lt?: number
          volumen_m3?: number
          referencia?: string
          created_at?: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['hid_lecturas']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'hid_lecturas_predio_id_fkey'
            columns: ['predio_id']
            isOneToOne: false
            referencedRelation: 'pad_predios'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'hid_lecturas_tipo_servicio_id_fkey'
            columns: ['tipo_servicio_id']
            isOneToOne: false
            referencedRelation: 'cat_tipos_servicio'
            referencedColumns: ['id']
          },
        ]
      }
      hid_volumenes_sin_lectura: {
        Row: {
          id: string
          predio_id: string
          tipo_servicio_id: string
          anio: number
          mes: number
          volumen_m3: number
          referencia: string
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          predio_id: string
          tipo_servicio_id: string
          anio: number
          mes: number
          volumen_m3?: number
          referencia?: string
          created_at?: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['hid_volumenes_sin_lectura']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'hid_volumenes_sin_lectura_predio_id_fkey'
            columns: ['predio_id']
            isOneToOne: false
            referencedRelation: 'pad_predios'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'hid_volumenes_sin_lectura_tipo_servicio_id_fkey'
            columns: ['tipo_servicio_id']
            isOneToOne: false
            referencedRelation: 'cat_tipos_servicio'
            referencedColumns: ['id']
          },
        ]
      }
      hid_control: {
        Row: {
          id: string
          estructura_id: string
          anio: number
          mes: number
          fecha_lectura: string
          hora_inicio: string
          hora_fin: string
          lectura_inicial: number
          lectura_final: number
          volumen_m3: number
          cloro_inicial: number
          cloro_final: number
          referencia: string
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          estructura_id: string
          anio: number
          mes: number
          fecha_lectura: string
          hora_inicio: string
          hora_fin: string
          lectura_inicial?: number
          lectura_final?: number
          volumen_m3?: number
          cloro_inicial?: number
          cloro_final?: number
          referencia?: string
          created_at?: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['hid_control']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'hid_control_estructura_id_fkey'
            columns: ['estructura_id']
            isOneToOne: false
            referencedRelation: 'hid_estructuras'
            referencedColumns: ['id']
          },
        ]
      }
      fac_deudas_anteriores: {
        Row: {
          id: string
          predio_id: string
          tarifa_id: string
          tipo_servicio_id: string
          anio: number
          mes: number
          monto: number
          interes: number
          saldo: number
          volumen: number
          fecha_registro: string
          concepto: string
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          predio_id: string
          tarifa_id: string
          tipo_servicio_id: string
          anio: number
          mes: number
          monto: number
          interes?: number
          saldo: number
          volumen?: number
          fecha_registro: string
          concepto?: string
          created_at?: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['fac_deudas_anteriores']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'fac_deudas_anteriores_predio_id_fkey'
            columns: ['predio_id']
            isOneToOne: false
            referencedRelation: 'pad_predios'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'fac_deudas_anteriores_tarifa_id_fkey'
            columns: ['tarifa_id']
            isOneToOne: false
            referencedRelation: 'cat_tarifas'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'fac_deudas_anteriores_tipo_servicio_id_fkey'
            columns: ['tipo_servicio_id']
            isOneToOne: false
            referencedRelation: 'cat_tipos_servicio'
            referencedColumns: ['id']
          },
        ]
      }
      fac_facturaciones: {
        Row: {
          id: string
          predio_id: string
          anio: number
          mes: number
          numero: string
          monto_total: number
          fecha: string
          estado: string
          caja_id: string
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          predio_id: string
          anio: number
          mes: number
          numero: string
          monto_total: number
          fecha?: string
          estado?: string
          caja_id: string
          created_at?: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['fac_facturaciones']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'fac_facturaciones_predio_id_fkey'
            columns: ['predio_id']
            isOneToOne: false
            referencedRelation: 'pad_predios'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'fac_facturaciones_caja_id_fkey'
            columns: ['caja_id']
            isOneToOne: false
            referencedRelation: 'cob_cajas'
            referencedColumns: ['id']
          },
        ]
      }
      fac_facturacion_detalle: {
        Row: {
          id: string
          facturacion_id: string
          deuda_anterior_id: string
          tipo_servicio_id: string
          monto: number
        }
        Insert: {
          id?: string
          facturacion_id: string
          deuda_anterior_id: string
          tipo_servicio_id: string
          monto: number
        }
        Update: Partial<Database['public']['Tables']['fac_facturacion_detalle']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'fac_facturacion_detalle_facturacion_id_fkey'
            columns: ['facturacion_id']
            isOneToOne: false
            referencedRelation: 'fac_facturaciones'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'fac_facturacion_detalle_deuda_anterior_id_fkey'
            columns: ['deuda_anterior_id']
            isOneToOne: true
            referencedRelation: 'fac_deudas_anteriores'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'fac_facturacion_detalle_tipo_servicio_id_fkey'
            columns: ['tipo_servicio_id']
            isOneToOne: false
            referencedRelation: 'cat_tipos_servicio'
            referencedColumns: ['id']
          },
        ]
      }
      cob_cajas: {
        Row: {
          id: string
          nombre: string
          sector_id: string | null
          usuario_id: string | null
          activa: boolean
          created_at: string
        }
        Insert: {
          id?: string
          nombre: string
          sector_id?: string | null
          usuario_id?: string | null
          activa?: boolean
          created_at?: string
        }
        Update: Partial<Database['public']['Tables']['cob_cajas']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'cob_cajas_sector_id_fkey'
            columns: ['sector_id']
            isOneToOne: false
            referencedRelation: 'cat_sectores'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'cob_cajas_usuario_id_fkey'
            columns: ['usuario_id']
            isOneToOne: false
            referencedRelation: 'sys_usuario_perfil'
            referencedColumns: ['user_id']
          },
        ]
      }
      cob_pagos: {
        Row: {
          id: string
          predio_id: string
          caja_id: string
          numero: string
          fecha: string
          tipo_pago: string
          referencia: string
          monto: number
          interes: number
          anulado: boolean
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          predio_id: string
          caja_id: string
          numero: string
          fecha?: string
          tipo_pago: string
          referencia?: string
          monto: number
          interes?: number
          anulado?: boolean
          created_at?: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['cob_pagos']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'cob_pagos_predio_id_fkey'
            columns: ['predio_id']
            isOneToOne: false
            referencedRelation: 'pad_predios'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'cob_pagos_caja_id_fkey'
            columns: ['caja_id']
            isOneToOne: false
            referencedRelation: 'cob_cajas'
            referencedColumns: ['id']
          },
        ]
      }
      cob_pago_facturaciones: {
        Row: {
          id: string
          pago_id: string
          facturacion_id: string
          monto: number
          vigente: boolean
        }
        Insert: {
          id?: string
          pago_id: string
          facturacion_id: string
          monto: number
          vigente?: boolean
        }
        Update: Partial<Database['public']['Tables']['cob_pago_facturaciones']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'cob_pago_facturaciones_pago_id_fkey'
            columns: ['pago_id']
            isOneToOne: false
            referencedRelation: 'cob_pagos'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'cob_pago_facturaciones_facturacion_id_fkey'
            columns: ['facturacion_id']
            isOneToOne: true
            referencedRelation: 'fac_facturaciones'
            referencedColumns: ['id']
          },
        ]
      }
      cob_pago_deudas: {
        Row: {
          pago_id: string
          deuda_anterior_id: string
          saldo: number
          interes: number
        }
        Insert: {
          pago_id: string
          deuda_anterior_id: string
          saldo: number
          interes: number
        }
        Update: Partial<Database['public']['Tables']['cob_pago_deudas']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'cob_pago_deudas_pago_id_fkey'
            columns: ['pago_id']
            isOneToOne: false
            referencedRelation: 'cob_pagos'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'cob_pago_deudas_deuda_anterior_id_fkey'
            columns: ['deuda_anterior_id']
            isOneToOne: false
            referencedRelation: 'fac_deudas_anteriores'
            referencedColumns: ['id']
          },
        ]
      }
      cob_pago_eventos: {
        Row: {
          id: string
          pago_id: string
          accion: string
          actor_id: string | null
          actor_email: string
          motivo: string
          detalle: Json
          created_at: string
        }
        Insert: {
          id?: string
          pago_id: string
          accion: string
          actor_id?: string | null
          actor_email?: string
          motivo?: string
          detalle?: Json
          created_at?: string
        }
        Update: Partial<Database['public']['Tables']['cob_pago_eventos']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'cob_pago_eventos_pago_id_fkey'
            columns: ['pago_id']
            isOneToOne: false
            referencedRelation: 'cob_pagos'
            referencedColumns: ['id']
          },
        ]
      }
      asm_asambleas: {
        Row: {
          id: string
          sector_id: string
          descripcion: string
          anio: number
          tipo: 'ordinaria' | 'extraordinaria'
          ambito: 'principal' | 'anexo'
          fecha: string
          estado: Database['public']['Enums']['estado_registro']
          padron_generado_en: string | null
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          sector_id: string
          descripcion: string
          anio: number
          tipo: 'ordinaria' | 'extraordinaria'
          ambito: 'principal' | 'anexo'
          fecha: string
          estado?: Database['public']['Enums']['estado_registro']
          padron_generado_en?: string | null
          created_at?: string
          updated_at?: string
        }
        Update: {
          sector_id?: string
          descripcion?: string
          anio?: number
          tipo?: 'ordinaria' | 'extraordinaria'
          ambito?: 'principal' | 'anexo'
          fecha?: string
          estado?: Database['public']['Enums']['estado_registro']
          padron_generado_en?: string | null
          updated_at?: string
        }
        Relationships: [
          {
            foreignKeyName: 'asm_asambleas_sector_id_fkey'
            columns: ['sector_id']
            isOneToOne: false
            referencedRelation: 'cat_sectores'
            referencedColumns: ['id']
          },
        ]
      }
      asm_padron: {
        Row: {
          id: string
          asamblea_id: string
          usuario_id: string
          predio_id: string | null
          correlativo: number
          nombre: string
          documento: string
          deuda: number
          habil: boolean
          asistencia: boolean
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          asamblea_id: string
          usuario_id: string
          predio_id?: string | null
          correlativo: number
          nombre: string
          documento?: string
          deuda?: number
          habil?: boolean
          asistencia?: boolean
          created_at?: string
          updated_at?: string
        }
        Update: {
          predio_id?: string | null
          correlativo?: number
          nombre?: string
          documento?: string
          deuda?: number
          habil?: boolean
          asistencia?: boolean
          updated_at?: string
        }
        Relationships: [
          {
            foreignKeyName: 'asm_padron_asamblea_id_fkey'
            columns: ['asamblea_id']
            isOneToOne: false
            referencedRelation: 'asm_asambleas'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'asm_padron_usuario_id_fkey'
            columns: ['usuario_id']
            isOneToOne: false
            referencedRelation: 'pad_usuarios'
            referencedColumns: ['id']
          },
          {
            foreignKeyName: 'asm_padron_predio_id_fkey'
            columns: ['predio_id']
            isOneToOne: false
            referencedRelation: 'pad_predios'
            referencedColumns: ['id']
          },
        ]
      }
      org_jass: {
        Row: {
          id: boolean
          nombre: string
          abreviatura: string
          celular: string
          direccion: string
          email: string
          logo_path: string
          latitud: number | null
          longitud: number | null
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: boolean
          nombre: string
          abreviatura?: string
          celular?: string
          direccion?: string
          email?: string
          logo_path?: string
          latitud?: number | null
          longitud?: number | null
          created_at?: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['org_jass']['Insert']>
        Relationships: []
      }
      sys_roles: {
        Row: {
          id: string
          codigo: string
          nombre: string
          descripcion: string
          permisos: string[]
          tablero: string[]
          created_at: string
        }
        Insert: {
          id?: string
          codigo: string
          nombre: string
          descripcion?: string
          permisos?: string[]
          tablero?: string[]
          created_at?: string
        }
        Update: Partial<Database['public']['Tables']['sys_roles']['Insert']>
        Relationships: []
      }
      sys_usuario_perfil: {
        Row: {
          user_id: string
          nombre: string
          rol_id: string
          sector_id: string | null
          activo: boolean
          created_at: string
          updated_at: string
        }
        Insert: {
          user_id: string
          nombre?: string
          rol_id: string
          sector_id?: string | null
          activo?: boolean
          created_at?: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['sys_usuario_perfil']['Insert']>
        Relationships: [
          {
            foreignKeyName: 'sys_usuario_perfil_rol_id_fkey'
            columns: ['rol_id']
            isOneToOne: false
            referencedRelation: 'sys_roles'
            referencedColumns: ['id']
          },
        ]
      }
      cat_conceptos_multa: {
        Row: {
          id: string
          nombre: string
          monto: number
          estado: Database['public']['Enums']['estado_registro']
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          nombre: string
          monto?: number
          estado?: Database['public']['Enums']['estado_registro']
          created_at?: string
          updated_at?: string
        }
        Update: {
          id?: string
          nombre?: string
          monto?: number
          estado?: Database['public']['Enums']['estado_registro']
          updated_at?: string
        }
        Relationships: []
      }
      cat_intereses: {
        Row: {
          id: string
          nombre: string
          porcentaje: number
          monto: number
          estado: Database['public']['Enums']['estado_registro']
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          nombre: string
          porcentaje?: number
          monto?: number
          estado?: Database['public']['Enums']['estado_registro']
          created_at?: string
          updated_at?: string
        }
        Update: {
          id?: string
          nombre?: string
          porcentaje?: number
          monto?: number
          estado?: Database['public']['Enums']['estado_registro']
          updated_at?: string
        }
        Relationships: []
      }
      cat_bancos: {
        Row: {
          id: string
          nombre: string
          cuenta: string
          estado: Database['public']['Enums']['estado_registro']
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          nombre: string
          cuenta?: string
          estado?: Database['public']['Enums']['estado_registro']
          created_at?: string
          updated_at?: string
        }
        Update: {
          id?: string
          nombre?: string
          cuenta?: string
          estado?: Database['public']['Enums']['estado_registro']
          updated_at?: string
        }
        Relationships: []
      }
      cat_documentos: {
        Row: {
          id: string
          codigo: string
          nombre: string
          estado: Database['public']['Enums']['estado_registro']
          created_at: string
          updated_at: string
        }
        Insert: {
          id?: string
          codigo: string
          nombre: string
          estado?: Database['public']['Enums']['estado_registro']
          created_at?: string
          updated_at?: string
        }
        Update: {
          id?: string
          codigo?: string
          nombre?: string
          estado?: Database['public']['Enums']['estado_registro']
          updated_at?: string
        }
        Relationships: []
      }
      app_meta: {
        Row: {
          key: string
          value: string
          updated_at: string
        }
        Insert: {
          key: string
          value: string
          updated_at?: string
        }
        Update: Partial<Database['public']['Tables']['app_meta']['Insert']>
        Relationships: []
      }
    }
    Views: {
      pad_usuarios_centro_activo: {
        Row: Database['public']['Tables']['pad_usuarios']['Row']
        Relationships: []
      }
    }
    Functions: {
      registrar_transferencia_predios: {
        Args: {
          p_usuario_origen_id: string
          p_usuario_destino_id: string
          p_referencia: string
          p_predio_ids: string[]
        }
        Returns: string
      }
      listar_predios_deuda_fija: {
        Args: {
          p_anio: number
          p_mes: number
          p_tipo_servicio_id: string
          p_sector_id?: string | null
          p_calle_id?: string | null
        }
        Returns: Json
      }
      generar_deudas_fijas: {
        Args: {
          p_anio: number
          p_mes: number
          p_tipo_servicio_id: string
          p_predio_ids: string[]
        }
        Returns: Json
      }
      listar_predios_convenio_medidor: {
        Args: {
          p_anio: number
          p_sector_id?: string | null
          p_calle_id?: string | null
          p_busqueda?: string | null
        }
        Returns: Json
      }
      generar_convenio_medidor: {
        Args: {
          p_fecha: string
          p_cuotas: number
          p_predio_ids: string[]
        }
        Returns: Json
      }
      listar_deudas_a_facturar: {
        Args: {
          p_anio: number
          p_mes: number
          p_sector_id?: string | null
          p_calle_id?: string | null
        }
        Returns: Json
      }
      listar_facturaciones: {
        Args: {
          p_anio: number
          p_mes: number
          p_sector_id?: string | null
          p_calle_id?: string | null
        }
        Returns: Json
      }
      generar_facturacion: {
        Args: {
          p_anio: number
          p_mes: number
          p_predio_ids: string[]
          p_caja_id: string
        }
        Returns: Json
      }
      listar_predios_a_cobrar: {
        Args: {
          p_sector_id?: string | null
          p_calle_id?: string | null
          p_search?: string | null
        }
        Returns: Json
      }
      cobrar_facturaciones: {
        Args: {
          p_predio_id: string
          p_facturacion_ids: string[]
          p_tipo_pago: string
          p_referencia: string
          p_fecha: string
          p_caja_id?: string | null
        }
        Returns: Json
      }
      listar_pagos: {
        Args: {
          p_sector_id?: string | null
          p_caja_id?: string | null
          p_desde?: string | null
          p_hasta?: string | null
          p_search?: string | null
        }
        Returns: Json
      }
      anular_pago: {
        Args: {
          p_pago_id: string
          p_clave: string
          p_motivo: string
        }
        Returns: Json
      }
      eliminar_facturacion: {
        Args: {
          p_facturacion_id: string
          p_clave: string
          p_motivo: string
        }
        Returns: Json
      }
      listar_usuarios_sistema: {
        Args: Record<string, never>
        Returns: Json
      }
      actualizar_usuario_sistema: {
        Args: {
          p_user_id: string
          p_nombre: string
          p_rol_id: string
          p_activo: boolean
          p_sector_id: string | null
        }
        Returns: Json
      }
      guardar_marca_plataforma: {
        Args: {
          p_nombre: string
        }
        Returns: string
      }
      mis_permisos: {
        Args: Record<string, never>
        Returns: Json
      }
      guardar_permisos_rol: {
        Args: {
          p_rol_id: string
          p_permisos: string[]
        }
        Returns: undefined
      }
      generar_padron_asamblea: {
        Args: {
          p_asamblea_id: string
        }
        Returns: number
      }
      registrar_lectura: {
        Args: {
          p_id: string | null
          p_predio_id: string
          p_tipo_servicio_id: string
          p_anio: number
          p_mes: number
          p_fecha_lectura: string
          p_lectura_m3: number
          p_lectura_lt: number
          p_volumen_m3: number
          p_referencia: string
        }
        Returns: Json
      }
      eliminar_lectura: {
        Args: {
          p_id: string
        }
        Returns: undefined
      }
      consulta_dni_activa: {
        Args: Record<string, never>
        Returns: boolean
      }
      consultar_dni: {
        Args: {
          p_dni: string
        }
        Returns: Json
      }
      leer_integracion_dni: {
        Args: Record<string, never>
        Returns: Json
      }
      guardar_integracion_dni: {
        Args: {
          p_proveedor: string
          p_token: string
          p_activa: boolean
        }
        Returns: Json
      }
      eliminar_credencial_dni: {
        Args: Record<string, never>
        Returns: Json
      }
      leer_integracion_ruc: {
        Args: Record<string, never>
        Returns: Json
      }
      guardar_integracion_ruc: {
        Args: {
          p_proveedor: string
          p_token: string
          p_activa: boolean
        }
        Returns: Json
      }
      eliminar_credencial_ruc: {
        Args: Record<string, never>
        Returns: Json
      }
      consulta_ruc_activa: {
        Args: Record<string, never>
        Returns: boolean
      }
      consultar_ruc: {
        Args: {
          p_ruc: string
        }
        Returns: Json
      }
      leer_integracion_ia: {
        Args: Record<string, never>
        Returns: Json
      }
      guardar_integracion_ia: {
        Args: {
          p_proveedor: string
          p_token: string
          p_modelo: string
        }
        Returns: Json
      }
      eliminar_credencial_ia: {
        Args: Record<string, never>
        Returns: Json
      }
      buscar_predio_ids: {
        Args: {
          p_search: string
          p_estado: string | null
          p_tipo_predio_id: string | null
          p_limit: number
          p_offset: number
          p_sector_id?: string | null
          p_calle_id?: string | null
        }
        Returns: {
          total: number
          ids: string[]
        }
      }
    }
    Enums: {
      tipo_persona: TipoPersona
      sexo: Sexo
      estado_registro: EstadoRegistro
      categoria_servicio: CategoriaServicio
    }
    CompositeTypes: Record<string, never>
  }
}

export type PadUsuario = Database['public']['Tables']['pad_usuarios']['Row']
export type PadPredio = Database['public']['Tables']['pad_predios']['Row']
export type CatSector = Database['public']['Tables']['cat_sectores']['Row']
export type CatCalle = Database['public']['Tables']['cat_calles']['Row']
export type CatTipoPredio = Database['public']['Tables']['cat_tipos_predio']['Row']
export type CatTipoServicio = Database['public']['Tables']['cat_tipos_servicio']['Row']
export type CatTarifa = Database['public']['Tables']['cat_tarifas']['Row']
export type CatCostoTarifa = Database['public']['Tables']['cat_costos_tarifa']['Row']
export type CatCostoTarifaHistorial =
  Database['public']['Tables']['cat_costos_tarifa_historial']['Row']
export type CatConceptoMulta = Database['public']['Tables']['cat_conceptos_multa']['Row']
export type CatInteres = Database['public']['Tables']['cat_intereses']['Row']
export type CatBanco = Database['public']['Tables']['cat_bancos']['Row']
export type CatDocumento = Database['public']['Tables']['cat_documentos']['Row']
export type CobCaja = Database['public']['Tables']['cob_cajas']['Row']
export type AsmAsamblea = Database['public']['Tables']['asm_asambleas']['Row']
export type AsmPadron = Database['public']['Tables']['asm_padron']['Row']
export type HidEstructura = Database['public']['Tables']['hid_estructuras']['Row']
export type HidMarcaMedidor = Database['public']['Tables']['hid_marcas_medidor']['Row']
export type HidMedidor = Database['public']['Tables']['hid_medidores']['Row']
export type HidLectura = Database['public']['Tables']['hid_lecturas']['Row']
export type HidVolumenSinLectura =
  Database['public']['Tables']['hid_volumenes_sin_lectura']['Row']
export type HidControl = Database['public']['Tables']['hid_control']['Row']
export type FacDeudaAnterior = Database['public']['Tables']['fac_deudas_anteriores']['Row']
export type FacFacturacion = Database['public']['Tables']['fac_facturaciones']['Row']
export type FacFacturacionDetalle = Database['public']['Tables']['fac_facturacion_detalle']['Row']
