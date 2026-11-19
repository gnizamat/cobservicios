import type { UsuarioResumen } from '@/modules/transferencias/types'

export function formatUsuarioNombre(
  usuario: Pick<
    UsuarioResumen,
    'tipo_persona' | 'nombres' | 'apellido_paterno' | 'apellido_materno'
  > | null,
) {
  if (!usuario) return '—'
  if (usuario.tipo_persona !== 'natural') return usuario.nombres
  const apellidos = [usuario.apellido_paterno, usuario.apellido_materno]
    .filter(Boolean)
    .join(' ')
  if (!apellidos) return usuario.nombres
  return `${apellidos}, ${usuario.nombres}`
}

export function formatDocumento(usuario: Pick<UsuarioResumen, 'dni' | 'ruc'>) {
  if (usuario.dni) return `DNI ${usuario.dni}`
  if (usuario.ruc) return `RUC ${usuario.ruc}`
  return ''
}

const fechaHora = new Intl.DateTimeFormat('es-PE', {
  dateStyle: 'short',
  timeStyle: 'short',
  timeZone: 'America/Lima',
})

export function formatFechaHora(iso: string) {
  return fechaHora.format(new Date(iso))
}

export function formatUbicacionPredio(predio: {
  calle_nombre?: string
  numero?: string
  manzana?: string
  lote?: string
}) {
  return [
    predio.calle_nombre,
    predio.numero && `N° ${predio.numero}`,
    predio.manzana && `Mz ${predio.manzana}`,
    predio.lote && `Lt ${predio.lote}`,
  ]
    .filter(Boolean)
    .join(' · ')
}
