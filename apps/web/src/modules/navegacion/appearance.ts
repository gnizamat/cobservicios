export const themes = [
  { id: 'yaqu', name: 'Yaqu', description: 'Tema original con degradados suaves' },
  { id: 'yaqu-dark', name: 'Yaqu Dark', description: 'Modo oscuro con acentos azules' },
  { id: 'claro', name: 'Claro', description: 'Interfaz limpia y minimalista' },
  { id: 'black', name: 'Black', description: 'Alto contraste estilo OLED' },
  { id: 'claude', name: 'Claude', description: 'Tonos cálidos y acentos terracota' },
  { id: 'eco-lima', name: 'Eco Lima', description: 'Verde lima sobre fondo blanco' },
] as const

export type ThemeId = (typeof themes)[number]['id']

const STORAGE_KEY = 'cobservicios-theme'

export function isThemeId(value: string | null): value is ThemeId {
  return themes.some((theme) => theme.id === value)
}

export function readTheme(): ThemeId {
  try {
    const stored = localStorage.getItem(STORAGE_KEY)
    if (isThemeId(stored)) return stored
  } catch {
    /* El navegador puede bloquear el almacenamiento. */
  }
  return 'yaqu'
}

export function applyTheme(id: ThemeId) {
  document.documentElement.dataset.theme = id
  try {
    localStorage.setItem(STORAGE_KEY, id)
  } catch {
    /* Si no se puede guardar, el tema igual queda aplicado en esta visita. */
  }
}

export function applyStoredTheme() {
  applyTheme(readTheme())
}
