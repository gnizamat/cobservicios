import { createClient, type PostgrestError } from '@supabase/supabase-js'
import { supabase } from '@/shared/lib/supabase'
import type { Json } from '@/shared/types/database'

export interface RolSistema {
  id: string
  codigo: string
  nombre: string
  descripcion: string
  permisos: string[]
  tablero: string[]
}

export interface UsuarioSistema {
  id: string
  email: string
  nombre: string
  activo: boolean
  rol: string
  rolId: string
  rolCodigo: string
}

export interface NuevoUsuarioSistema {
  nombre: string
  email: string
  password: string
  rolCodigo: string
}

function asSistemaError(error: PostgrestError) {
  const message = error.message.replace(/^.*ERROR:\s*/i, '').trim()
  return new Error(message || 'No se pudo completar la operación.')
}

function asRows(value: Json | null): Array<Record<string, Json | undefined>> {
  if (!Array.isArray(value)) return []
  return value.filter(
    (row): row is Record<string, Json | undefined> =>
      row != null && typeof row === 'object' && !Array.isArray(row),
  )
}

function text(value: Json | undefined) {
  return value == null ? '' : String(value)
}

export async function listRoles(): Promise<RolSistema[]> {
  const { data, error } = await supabase
    .from('sys_roles')
    .select('id, codigo, nombre, descripcion, permisos, tablero')
    .order('nombre')
  if (error) throw asSistemaError(error)
  return (data ?? []).map((rol) => ({
    id: rol.id,
    codigo: rol.codigo,
    nombre: rol.nombre,
    descripcion: rol.descripcion,
    permisos: rol.permisos ?? [],
    tablero: rol.tablero ?? [],
  }))
}

export async function listUsuariosSistema(): Promise<UsuarioSistema[]> {
  const { data, error } = await supabase.rpc('listar_usuarios_sistema')
  if (error) throw asSistemaError(error)
  return asRows(data).map((row) => ({
    id: text(row.id),
    email: text(row.email),
    nombre: text(row.nombre),
    activo: row.activo !== false,
    rol: text(row.rol),
    rolId: text(row.rol_id),
    rolCodigo: text(row.rol_codigo),
  }))
}

export async function actualizarUsuarioSistema(input: {
  id: string
  nombre: string
  rolId: string
  activo: boolean
}) {
  const { error } = await supabase.rpc('actualizar_usuario_sistema', {
    p_user_id: input.id,
    p_nombre: input.nombre.trim(),
    p_rol_id: input.rolId,
    p_activo: input.activo,
  })
  if (error) throw asSistemaError(error)
}

export async function crearUsuarioSistema(input: NuevoUsuarioSistema) {
  const url = import.meta.env.VITE_SUPABASE_URL
  const anonKey = import.meta.env.VITE_SUPABASE_ANON_KEY
  if (!url || !anonKey) {
    throw new Error('Falta la configuración local de Supabase.')
  }

  const registro = createClient(url, anonKey, {
    auth: { persistSession: false, autoRefreshToken: false, detectSessionInUrl: false },
  })
  const { data, error } = await registro.auth.signUp({
    email: input.email.trim(),
    password: input.password,
    options: {
      data: {
        nombre: input.nombre.trim(),
        rol: input.rolCodigo,
      },
    },
  })
  if (error) {
    if (/already registered/i.test(error.message)) {
      throw new Error('Ese correo ya tiene una cuenta.')
    }
    throw new Error(error.message)
  }
  if (!data.user) {
    throw new Error('No se pudo crear el usuario.')
  }
}

export async function getMarcaNombre(): Promise<string> {
  const { data, error } = await supabase
    .from('app_meta')
    .select('value')
    .eq('key', 'marca_nombre')
    .maybeSingle()
  if (error) throw asSistemaError(error)
  return data?.value?.trim() ?? ''
}

export async function guardarMarcaNombre(nombre: string) {
  const { data, error } = await supabase.rpc('guardar_marca_plataforma', {
    p_nombre: nombre.trim(),
  })
  if (error) throw asSistemaError(error)
  return data ?? nombre.trim()
}
