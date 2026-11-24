import { Navigate, Route, Routes } from 'react-router-dom'
import { HomePage } from '@/app/pages/home-page'
import { GuestOnly, LoginPage, RequireAuth } from '@/modules/auth'
import {
  CallesPage,
  CostosTarifasPage,
  SectoresPage,
  ServiciosPage,
  TarifasPage,
} from '@/modules/catalogo'
import { AsambleasSectionPage } from '@/modules/asambleas'
import { CobranzaFacturacionesPage, PagosListadoPage } from '@/modules/cobranza'
import { CobranzaConfigPage, OrganizacionPage, SistemaPage } from '@/modules/configuracion'
import { DeudasAnterioresPage, DeudasMensualesPage } from '@/modules/deudas'
import { FacturacionPage } from '@/modules/facturacion'
import {
  ControlHidrometricoPage,
  LecturasPage,
  VolumenSinLecturaPage,
} from '@/modules/lecturas'
import { ModulePlaceholderPage, flattenNavItems, mainNav } from '@/modules/navegacion'
import {
  MapaPrediosPage,
  PredioCreatePage,
  PredioEditPage,
  PrediosListPage,
} from '@/modules/predios'
import { TransferenciaPrediosPage } from '@/modules/transferencias'
import {
  UsuarioCreatePage,
  UsuarioEditPage,
  UsuarioFichaPage,
  UsuariosListPage,
} from '@/modules/usuarios'

const implementedExact = new Set([
  '/',
  '/padron/usuarios',
  '/padron/usuarios/nuevo',
  '/padron/predios',
  '/padron/predios/nuevo',
  '/padron/mapa',
  '/padron/transferencias',
  '/catalogo/sectores',
  '/catalogo/calles',
  '/catalogo/servicios',
  '/catalogo/tarifas',
  '/catalogo/costos-tarifas',
  '/hidrometria/lecturas',
  '/hidrometria/volumen-sin-lectura',
  '/hidrometria/control',
  '/facturacion/deudas-anteriores',
  '/facturacion/deudas-mensuales',
  '/facturacion',
  '/configuracion/organizacion',
  '/configuracion/sistema',
  '/configuracion/cobranza',
  '/cobranza/facturaciones',
  '/cobranza/pagos',
  '/padron/asambleas',
  '/padron/asambleas/asistencia',
])

const modulePaths = flattenNavItems(mainNav)
  .flatMap((item) => (item.path ? [item.path] : []))
  .filter((path) => !implementedExact.has(path))

export function AppRouter() {
  return (
    <Routes>
      <Route element={<GuestOnly />}>
        <Route path="/acceso" element={<LoginPage />} />
      </Route>

      <Route element={<RequireAuth />}>
        <Route path="/" element={<HomePage />} />

        <Route path="/padron/usuarios" element={<UsuariosListPage />} />
        <Route path="/padron/usuarios/nuevo" element={<UsuarioCreatePage />} />
        <Route path="/padron/usuarios/:id" element={<UsuarioFichaPage />} />
        <Route path="/padron/usuarios/:id/editar" element={<UsuarioEditPage />} />

        <Route path="/padron/mapa" element={<MapaPrediosPage />} />
        <Route path="/padron/predios" element={<PrediosListPage />} />
        <Route path="/padron/predios/nuevo" element={<PredioCreatePage />} />
        <Route path="/padron/predios/:id/editar" element={<PredioEditPage />} />

        <Route path="/padron/transferencias" element={<TransferenciaPrediosPage />} />

        <Route path="/catalogo/sectores" element={<SectoresPage />} />
        <Route path="/catalogo/calles" element={<CallesPage />} />
        <Route path="/catalogo/servicios" element={<ServiciosPage />} />
        <Route path="/catalogo/tarifas" element={<TarifasPage />} />
        <Route path="/catalogo/costos-tarifas" element={<CostosTarifasPage />} />

        <Route path="/hidrometria/lecturas" element={<LecturasPage />} />
        <Route path="/hidrometria/volumen-sin-lectura" element={<VolumenSinLecturaPage />} />
        <Route path="/hidrometria/control" element={<ControlHidrometricoPage />} />

        <Route path="/facturacion/deudas-anteriores" element={<DeudasAnterioresPage />} />
        <Route path="/facturacion/deudas-mensuales" element={<DeudasMensualesPage />} />
        <Route path="/facturacion" element={<FacturacionPage />} />

        <Route path="/configuracion/organizacion" element={<OrganizacionPage />} />
        <Route path="/configuracion/sistema" element={<SistemaPage />} />
        <Route path="/configuracion/cobranza" element={<CobranzaConfigPage />} />

        <Route path="/cobranza/facturaciones" element={<CobranzaFacturacionesPage />} />
        <Route path="/cobranza/pagos" element={<PagosListadoPage />} />

        <Route path="/padron/asambleas" element={<AsambleasSectionPage />} />
        <Route path="/padron/asambleas/asistencia" element={<AsambleasSectionPage />} />
        <Route path="/asambleas" element={<Navigate to="/padron/asambleas" replace />} />
        <Route path="/asambleas/asistencia" element={<Navigate to="/padron/asambleas/asistencia" replace />} />

        {modulePaths.map((path) => (
          <Route key={path} path={path} element={<ModulePlaceholderPage />} />
        ))}
      </Route>

      <Route path="*" element={<Navigate to="/" replace />} />
    </Routes>
  )
}
