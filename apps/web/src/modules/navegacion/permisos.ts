import { mainNav } from '@/modules/navegacion/menu'
import type { NavSection } from '@/modules/navegacion/types'

const seccionPorEtiquetaAntigua: Record<string, string> = {
  Administración: 'configuracion',
}

export interface AccesoRol {
  codigo: string
  permisos: string[]
  conocido: boolean
}

export interface PermisoOpcion {
  id: string
  label: string
}

export interface PermisoGrupo {
  id: string
  label: string
  items: PermisoOpcion[]
}

export function catalogoPermisos(): PermisoGrupo[] {
  return mainNav
    .filter((section) => section.id !== 'inicio')
    .map((section) => ({
      id: section.id,
      label: section.label,
      items: section.items
        .filter((item) => item.path)
        .map((item) => ({ id: item.id, label: item.label })),
    }))
}

export function expandirPermisos(permisos: string[] | undefined) {
  const concedidos = new Set(permisos ?? [])
  const ids = new Set<string>()

  for (const grupo of catalogoPermisos()) {
    const grupoCompleto =
      concedidos.has(grupo.id) ||
      concedidos.has(grupo.label) ||
      [...concedidos].some((valor) => seccionPorEtiquetaAntigua[valor] === grupo.id)

    for (const item of grupo.items) {
      if (grupoCompleto || concedidos.has(item.id) || concedidos.has(item.label)) {
        ids.add(item.id)
      }
    }
  }

  return ids
}

export function opcionPermitida(acceso: AccesoRol | undefined, itemId: string) {
  if (itemId === 'dashboard') return true
  if (!acceso?.conocido) return true
  return expandirPermisos(acceso.permisos).has(itemId)
}

export function filtrarNav(sections: NavSection[], acceso: AccesoRol | undefined) {
  return sections
    .map((section) => ({
      ...section,
      items: section.items.filter((item) => opcionPermitida(acceso, item.id)),
    }))
    .filter((section) => section.id === 'inicio' || section.items.length > 0)
}
