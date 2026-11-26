import {
  Banknote,
  BookOpen,
  Building2,
  ClipboardList,
  Droplets,
  FileBarChart2,
  Gauge,
  HelpCircle,
  Home,
  Cog,
  Landmark,
  Plug,
  LayoutDashboard,
  Map,
  MapPinned,
  Receipt,
  Users,
  UsersRound,
  Wallet,
} from 'lucide-react'
import type { NavItem, NavSection } from '@/modules/navegacion/types'

/**
 * Menú principal migrado desde Menu.vb / sysMenu, reorganizado por dominio
 * operativo (mejor que el ribbon plano del legado).
 */
export const mainNav: NavSection[] = [
  {
    id: 'inicio',
    label: 'Inicio',
    icon: Home,
    items: [
      {
        id: 'dashboard',
        label: 'Panel principal',
        path: '/',
        icon: LayoutDashboard,
        status: 'ready',
        description: 'Resumen y accesos rápidos',
      },
    ],
  },
  {
    id: 'padron',
    label: 'Organización',
    description: 'Usuarios, predios y asambleas',
    icon: Users,
    items: [
      {
        id: 'mapa-predios',
        label: 'Mapa',
        path: '/padron/mapa',
        icon: Map,
        status: 'ready',
        description: 'Ubicación de los predios urbanos por calle',
      },
      {
        id: 'usuarios-servicio',
        label: 'Usuarios',
        path: '/padron/usuarios',
        icon: Users,
        legacyId: 50,
        status: 'ready',
        description: 'Registrar y modificar usuarios del padrón',
      },
      {
        id: 'predios',
        label: 'Predios',
        path: '/padron/predios',
        icon: Building2,
        legacyId: 51,
        status: 'ready',
        description: 'Registrar y modificar predios de servicio',
      },
      {
        id: 'transferencia-predios',
        label: 'Transferencia de predios',
        path: '/padron/transferencias',
        legacyId: 81,
        status: 'ready',
        description: 'Transferir predios entre usuarios y consultar la trazabilidad',
      },
      {
        id: 'asambleas',
        label: 'Asambleas',
        path: '/padron/asambleas',
        icon: UsersRound,
        status: 'ready',
        description: 'Registro de asambleas y asistencia de usuarios hábiles',
      },
    ],
  },
  {
    id: 'territorio',
    label: 'Territorio y catálogo',
    description: 'Sectores, calles, tarifas y servicios',
    icon: MapPinned,
    items: [
      {
        id: 'sectores',
        label: 'Sectores',
        path: '/catalogo/sectores',
        legacyId: 66,
        status: 'ready',
        description: 'Registrar sectores y cargar sus datos',
      },
      {
        id: 'calles',
        label: 'Calles',
        path: '/catalogo/calles',
        legacyId: 65,
        status: 'ready',
        description: 'Calles por sector, con referencia',
      },
      {
        id: 'servicios',
        label: 'Tipos de servicio',
        path: '/catalogo/servicios',
        legacyId: 62,
        status: 'ready',
        description: 'Servicios fijos, únicos, volumen y medidor',
      },
      {
        id: 'tarifas',
        label: 'Tarifas por año',
        path: '/catalogo/tarifas',
        legacyId: 61,
        status: 'ready',
        description: 'Año, modalidad y tarifa vigente',
      },
      {
        id: 'costos-tarifas',
        label: 'Costos de tarifas',
        path: '/catalogo/costos-tarifas',
        legacyId: 63,
        status: 'ready',
        description: 'Valor y monto por servicio y año',
      },
    ],
  },
  {
    id: 'hidrometria',
    label: 'Hidrometría',
    description: 'Lecturas y control de consumo',
    icon: Gauge,
    items: [
      {
        id: 'lecturas',
        label: 'Registrar lecturas',
        path: '/hidrometria/lecturas',
        icon: ClipboardList,
        legacyId: 73,
        status: 'ready',
        description: 'Lectura de medidor y consumo del mes',
      },
      {
        id: 'volumen-sin-lectura',
        label: 'Volumen sin lectura',
        path: '/hidrometria/volumen-sin-lectura',
        legacyId: 55,
        status: 'ready',
        description: 'Volumen asignado sin medidor',
      },
      {
        id: 'control-hidrometrico',
        label: 'Control hidrométrico',
        path: '/hidrometria/control',
        legacyId: 77,
        status: 'ready',
        description: 'Lectura de estructura, volumen y cloro',
      },
    ],
  },
  {
    id: 'facturacion',
    label: 'Facturación y deudas',
    description: 'Generación de deudas y facturas',
    icon: Receipt,
    items: [
      {
        id: 'deudas-mensuales',
        label: 'Deudas mensuales',
        path: '/facturacion/deudas-mensuales',
        legacyId: 67,
        status: 'ready',
        description: 'Generar la deuda fija del mes por predio',
      },
      {
        id: 'deudas-unicas',
        label: 'Deudas convenios',
        path: '/facturacion/deudas-unicas',
        legacyId: 68,
        status: 'ready',
        description: 'Costo del medidor en cuotas fijas desde la fecha del convenio',
      },
      {
        id: 'deudas-volumen',
        label: 'Deudas por volumen',
        path: '/facturacion/deudas-volumen',
        legacyId: 69,
        status: 'soon',
      },
      {
        id: 'deudas-alcantarillado',
        label: 'Deudas alcantarillado',
        path: '/facturacion/deudas-alcantarillado',
        legacyId: 83,
        status: 'soon',
      },
      {
        id: 'deudas-anteriores',
        label: 'Deudas anteriores',
        path: '/facturacion/deudas-anteriores',
        legacyId: 54,
        status: 'ready',
        description: 'Deudas previas por predio y tipo de tarifa',
      },
      {
        id: 'intereses',
        label: 'Generar intereses',
        path: '/facturacion/intereses',
        legacyId: 82,
        status: 'soon',
      },
      {
        id: 'facturacion',
        label: 'Facturación',
        path: '/facturacion',
        legacyId: 74,
        status: 'ready',
        description: 'Facturar las deudas de un mes por predio',
      },
    ],
  },
  {
    id: 'cobranza',
    label: 'Cobranza',
    description: 'Pagos e ingresos',
    icon: Wallet,
    items: [
      {
        id: 'cobranza-facturaciones',
        label: 'Cobranza de facturaciones',
        path: '/cobranza/facturaciones',
        legacyId: 70,
        status: 'ready',
        description: 'Cobrar las facturas pendientes de un predio',
      },
      {
        id: 'cobranza-pagos',
        label: 'Listado de pagos',
        path: '/cobranza/pagos',
        icon: Receipt,
        status: 'ready',
        description: 'Pagos por centro poblado, caja y fecha, con impresión y eliminación',
      },
      {
        id: 'otros-ingresos',
        label: 'Otros ingresos',
        path: '/cobranza/otros-ingresos',
        legacyId: 71,
        status: 'soon',
      },
    ],
  },
  {
    id: 'reportes',
    label: 'Reportes',
    icon: FileBarChart2,
    items: [
      {
        id: 'rpt-deudas',
        label: 'Deudas',
        path: '/reportes/deudas',
        legacyId: 59,
        status: 'soon',
      },
      {
        id: 'rpt-facturaciones',
        label: 'Facturaciones',
        path: '/reportes/facturaciones',
        legacyId: 75,
        status: 'soon',
      },
      {
        id: 'rpt-cobranzas',
        label: 'Cobranzas',
        path: '/reportes/cobranzas',
        legacyId: 76,
        status: 'soon',
      },
      {
        id: 'rpt-lecturas',
        label: 'Lecturas',
        path: '/reportes/lecturas',
        legacyId: 79,
        status: 'soon',
      },
    ],
  },
  {
    id: 'configuracion',
    label: 'Configuración',
    description: 'Organización de la JASS, sistema, cobranza, hidrometría e integraciones',
    icon: Landmark,
    items: [
      {
        id: 'organizacion',
        label: 'Organización',
        path: '/configuracion/organizacion',
        icon: Landmark,
        status: 'ready',
        description: 'Nombre, logo, contacto, ubicación y centros poblados',
      },
      {
        id: 'sistema',
        label: 'Configuración del sistema',
        path: '/configuracion/sistema',
        icon: Cog,
        status: 'ready',
        description: 'JASS, usuarios, roles, permisos, tablero y marca de la plataforma',
      },
      {
        id: 'config-cobranza',
        label: 'Cobranza',
        path: '/configuracion/cobranza',
        icon: Banknote,
        status: 'ready',
        description: 'Tarifas, multas, intereses, bancos, cajas y documentos',
      },
      {
        id: 'config-hidrometria',
        label: 'Hidrometría',
        path: '/configuracion/hidrometria',
        icon: Gauge,
        status: 'ready',
        description: 'Colaboradores de lecturas y marcas de medidor',
      },
      {
        id: 'integraciones',
        label: 'Integraciones',
        path: '/configuracion/integraciones',
        icon: Plug,
        status: 'ready',
        description: 'Consulta de DNI para completar nombres al registrar usuarios',
      },
    ],
  },
  {
    id: 'ayuda',
    label: 'Ayuda',
    icon: HelpCircle,
    items: [
      {
        id: 'manual',
        label: 'Manual de usuario',
        path: '/ayuda/manual',
        icon: BookOpen,
        legacyId: 42,
        status: 'soon',
      },
      {
        id: 'glosario',
        label: 'Glosario',
        path: '/ayuda/glosario',
        legacyId: 41,
        status: 'soon',
      },
    ],
  },
]

export const brandNav = {
  name: 'COBSERVICIOS',
  subtitle: 'JASS Pedregal',
  icon: Droplets,
} as const

export function flattenNavItems(sections: NavSection[] = mainNav): NavItem[] {
  return sections.flatMap((section) => section.items)
}

function menuPaths() {
  return flattenNavItems().flatMap((item) => (item.path ? [item.path] : []))
}

/** El enlace cierra en esa ruta cuando otro ítem del menú vive debajo de ella. */
export function navLinkEnds(path: string) {
  return menuPaths().some((other) => other.startsWith(`${path}/`))
}

export function pathIsCurrent(pathname: string, path: string) {
  if (path === '/') return pathname === '/'
  if (pathname === path) return true
  if (!pathname.startsWith(`${path}/`)) return false
  const coveredByChild = menuPaths().some(
    (other) =>
      other.length > path.length &&
      other.startsWith(`${path}/`) &&
      (pathname === other || pathname.startsWith(`${other}/`)),
  )
  return !coveredByChild
}

export function findNavItemByPath(
  path: string,
  sections: NavSection[] = mainNav,
): NavItem | undefined {
  return flattenNavItems(sections).find((item) => item.path === path)
}
