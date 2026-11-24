import { useEffect, useMemo, useRef, useState } from 'react'
import L from 'leaflet'
import 'leaflet/dist/leaflet.css'
import { MapPin, Search } from 'lucide-react'
import { Icon, Input, Select } from '@/design-system/atoms'
import { AppShell } from '@/design-system/templates'
import { useSectores } from '@/modules/catalogo'
import { usePrediosMapa, useUbicarPredio, type PredioMapa } from '@/modules/predios/api/mapa-api'
import { useOrganizacion } from '@/modules/configuracion/api'
import { cn } from '@/shared/lib/utils'

const SEDE = { lat: -5.1947, lng: -80.6165 }
const IMAGEN =
  'https://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}'

function normalizar(valor: string) {
  return valor
    .trim()
    .toLocaleLowerCase('es')
    .normalize('NFD')
    .replace(/\p{M}/gu, '')
}

function etiquetaPredio(predio: PredioMapa) {
  return [predio.nombre, predio.numero && `N° ${predio.numero}`, predio.manzana && `Mz ${predio.manzana}`, predio.lote && `Lt ${predio.lote}`]
    .filter(Boolean)
    .join(' · ')
}

function colorCalle(nombre: string) {
  let hash = 0
  for (const char of nombre) hash = (hash * 31 + char.charCodeAt(0)) >>> 0
  return `hsl(${hash % 360} 62% 42%)`
}

function escapeHtml(valor: string) {
  return valor.replace(/[&<>"']/g, (char) =>
    ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#39;' })[char] ?? char,
  )
}

export function MapaPrediosPage() {
  const organizacion = useOrganizacion()
  const sectores = useSectores()
  const predios = usePrediosMapa()
  const ubicar = useUbicarPredio()
  const [sectorId, setSectorId] = useState('all')
  const [calleId, setCalleId] = useState('all')
  const [busqueda, setBusqueda] = useState('')
  const [elegidoId, setElegidoId] = useState<string | null>(null)
  const [modoUbicar, setModoUbicar] = useState(false)

  const filas = predios.data ?? []
  const visibles = useMemo(() => {
    const texto = normalizar(busqueda)
    return filas.filter((predio) => {
      if (sectorId !== 'all' && predio.sectorId !== sectorId) return false
      if (calleId !== 'all' && predio.calleId !== calleId) return false
      if (!texto) return true
      return [predio.nombre, predio.numero, predio.calle, predio.sector, predio.usuario, predio.documento]
        .some((parte) => normalizar(parte).includes(texto))
    })
  }, [busqueda, calleId, filas, sectorId])

  const calles = useMemo(() => {
    const base = sectorId === 'all' ? filas : filas.filter((predio) => predio.sectorId === sectorId)
    const grupos = new Map<string, { id: string; nombre: string; total: number }>()
    for (const predio of base) {
      if (!predio.calleId) continue
      const actual = grupos.get(predio.calleId) ?? { id: predio.calleId, nombre: predio.calle, total: 0 }
      actual.total += 1
      grupos.set(predio.calleId, actual)
    }
    return [...grupos.values()].sort((a, b) => a.nombre.localeCompare(b.nombre, 'es'))
  }, [filas, sectorId])

  const porCalle = useMemo(() => {
    const grupos = new Map<string, PredioMapa[]>()
    for (const predio of visibles) {
      const lista = grupos.get(predio.calle) ?? []
      lista.push(predio)
      grupos.set(predio.calle, lista)
    }
    return [...grupos.entries()].sort(([a], [b]) => a.localeCompare(b, 'es'))
  }, [visibles])

  const ubicados = useMemo(
    () => visibles.filter((predio) => predio.latitud != null && predio.longitud != null),
    [visibles],
  )
  const elegido = visibles.find((predio) => predio.id === elegidoId) ?? null
  const centro = {
    lat: organizacion.data?.latitud ?? SEDE.lat,
    lng: organizacion.data?.longitud ?? SEDE.lng,
  }

  function cambiarSector(value: string) {
    setSectorId(value)
    setCalleId('all')
    setElegidoId(null)
    setModoUbicar(false)
  }

  return (
    <AppShell className="flex h-full max-w-none flex-col overflow-hidden px-3 py-3">
      <div className="mb-3 flex flex-col gap-2 lg:flex-row lg:items-end">
        <p className="text-sm text-muted-foreground lg:max-w-[12rem]">
          {ubicados.length} de {visibles.length} con punto
        </p>
        <div className="grid flex-1 gap-2 sm:grid-cols-[minmax(0,0.8fr)_minmax(0,1fr)_minmax(0,1.2fr)]">
          <label className="flex min-w-0 flex-col gap-1 text-xs text-muted-foreground">
            Centro poblado
            <Select
              aria-label="Centro poblado"
              value={sectorId}
              onChange={(event) => cambiarSector(event.target.value)}
              className="h-8 text-sm text-foreground"
            >
              <option value="all">Todos los centros poblados</option>
              {(sectores.data ?? []).map((sector) => (
                <option key={sector.id} value={sector.id}>
                  {sector.nombre}
                </option>
              ))}
            </Select>
          </label>
          <label className="flex min-w-0 flex-col gap-1 text-xs text-muted-foreground">
            Calle
            <Select
              aria-label="Calle"
              value={calles.some((calle) => calle.id === calleId) ? calleId : 'all'}
              onChange={(event) => {
                setCalleId(event.target.value)
                setElegidoId(null)
              }}
              className="h-8 text-sm text-foreground"
            >
              <option value="all">Todas las calles</option>
              {calles.map((calle) => (
                <option key={calle.id} value={calle.id}>
                  {calle.nombre}
                </option>
              ))}
            </Select>
          </label>
          <label className="flex min-w-0 flex-col gap-1 text-xs text-muted-foreground">
            Buscar
            <span className="relative">
              <Icon
                icon={Search}
                size={14}
                className="pointer-events-none absolute top-1/2 left-2.5 -translate-y-1/2"
              />
              <Input
                value={busqueda}
                onChange={(event) => setBusqueda(event.target.value)}
                placeholder="Predio, usuario o documento"
                aria-label="Buscar predio, usuario o documento"
                className="h-8 pl-8 text-sm"
              />
            </span>
          </label>
        </div>
      </div>

      {predios.isError ? (
        <p role="alert" className="mb-3 text-sm text-destructive">
          {(predios.error as Error).message}
        </p>
      ) : null}
      {ubicar.isError ? (
        <p role="alert" className="mb-3 text-sm text-destructive">
          {(ubicar.error as Error).message}
        </p>
      ) : null}

      <div className="grid min-h-0 flex-1 gap-3 lg:grid-cols-[18rem_minmax(0,1fr)]">
        <aside className="min-h-0 overflow-y-auto rounded-xl border border-border bg-card">
          {predios.isLoading ? (
            <p className="p-3 text-sm text-muted-foreground">Cargando predios…</p>
          ) : porCalle.length === 0 ? (
            <p className="p-3 text-sm text-muted-foreground">No hay predios con ese filtro.</p>
          ) : (
            porCalle.map(([calle, lista]) => (
              <section key={calle} className="border-b border-border last:border-b-0">
                <h2 className="sticky top-0 bg-card px-3 py-2 text-xs font-semibold tracking-wide text-muted-foreground uppercase">
                  {calle}
                  <span className="ml-2 font-normal">
                    {lista.filter((predio) => predio.latitud != null).length}/{lista.length}
                  </span>
                </h2>
                <ul>
                  {lista.map((predio) => {
                    const activo = predio.id === elegidoId
                    const ubicado = predio.latitud != null && predio.longitud != null
                    return (
                      <li key={predio.id}>
                        <button
                          type="button"
                          onClick={() => {
                            setElegidoId(predio.id)
                            setModoUbicar(!ubicado)
                          }}
                          className={cn(
                            'flex w-full items-start gap-2 px-3 py-2 text-left text-sm hover:bg-secondary/70',
                            activo && 'bg-secondary',
                          )}
                        >
                          <Icon
                            icon={MapPin}
                            size={14}
                            className={ubicado ? 'mt-0.5 text-primary' : 'mt-0.5 text-muted-foreground'}
                          />
                          <span className="min-w-0">
                            <span className="block truncate font-medium">{etiquetaPredio(predio)}</span>
                            <span className="block truncate text-xs text-muted-foreground">
                              {predio.usuario}
                              {ubicado ? '' : ' · Sin punto'}
                            </span>
                          </span>
                        </button>
                      </li>
                    )
                  })}
                </ul>
              </section>
            ))
          )}
        </aside>

        <div className="flex min-h-[28rem] min-w-0 flex-col gap-2 lg:min-h-0">
          {modoUbicar && elegido ? (
            <p className="rounded-lg border border-border bg-secondary/50 px-3 py-2 text-sm text-foreground">
              Hacé clic en el mapa para ubicar <span className="font-medium">{etiquetaPredio(elegido)}</span>{' '}
              sobre {elegido.calle}.
            </p>
          ) : (
            <p className="text-sm text-muted-foreground">
              Elegí un predio sin punto y hacé clic en el mapa para dejarlo en su calle.
            </p>
          )}
          <MapaVista
            centro={centro}
            puntos={ubicados}
            elegidoId={elegidoId}
            ubicar={modoUbicar}
            onElegir={(id) => {
              setElegidoId(id)
              setModoUbicar(false)
            }}
            onMapaClick={(latitud, longitud) => {
              if (!modoUbicar || !elegido) return
              ubicar.mutate(
                { id: elegido.id, latitud, longitud },
                { onSuccess: () => setModoUbicar(false) },
              )
            }}
          />
        </div>
      </div>
    </AppShell>
  )
}

function MapaVista({
  centro,
  puntos,
  elegidoId,
  ubicar,
  onElegir,
  onMapaClick,
}: {
  centro: { lat: number; lng: number }
  puntos: PredioMapa[]
  elegidoId: string | null
  ubicar: boolean
  onElegir: (id: string) => void
  onMapaClick: (latitud: number, longitud: number) => void
}) {
  const host = useRef<HTMLDivElement>(null)
  const mapRef = useRef<L.Map | null>(null)
  const capaRef = useRef<L.LayerGroup | null>(null)
  const clickRef = useRef(onMapaClick)
  const elegirRef = useRef(onElegir)
  clickRef.current = onMapaClick
  elegirRef.current = onElegir

  useEffect(() => {
    const element = host.current
    if (!element || mapRef.current) return
    const map = L.map(element, { center: [centro.lat, centro.lng], zoom: 16 })
    L.tileLayer(IMAGEN, {
      attribution: 'Imágenes &copy; Esri, Maxar, Earthstar Geographics',
      maxZoom: 19,
    }).addTo(map)
    capaRef.current = L.layerGroup().addTo(map)
    map.on('click', (event) => {
      clickRef.current(
        Math.round(event.latlng.lat * 1_000_000) / 1_000_000,
        Math.round(event.latlng.lng * 1_000_000) / 1_000_000,
      )
    })
    mapRef.current = map
    return () => {
      map.remove()
      mapRef.current = null
      capaRef.current = null
    }
  }, [centro.lat, centro.lng])

  useEffect(() => {
    const map = mapRef.current
    const capa = capaRef.current
    if (!map || !capa) return
    capa.clearLayers()
    const bounds: L.LatLngExpression[] = []
    for (const predio of puntos) {
      if (predio.latitud == null || predio.longitud == null) continue
      const punto: L.LatLngExpression = [predio.latitud, predio.longitud]
      bounds.push(punto)
      const marker = L.circleMarker(punto, {
        radius: predio.id === elegidoId ? 9 : 6,
        color: '#ffffff',
        weight: 2,
        fillColor: colorCalle(predio.calle),
        fillOpacity: 0.95,
      })
      marker.bindPopup(
        `<strong>${escapeHtml(etiquetaPredio(predio))}</strong><br>${escapeHtml(predio.calle)}<br>${escapeHtml(predio.usuario)}`,
      )
      marker.on('click', (event) => {
        L.DomEvent.stopPropagation(event.originalEvent)
        elegirRef.current(predio.id)
      })
      marker.addTo(capa)
    }
    if (bounds.length > 1 && !elegidoId) map.fitBounds(L.latLngBounds(bounds), { padding: [24, 24], maxZoom: 17 })
  }, [elegidoId, puntos])

  useEffect(() => {
    const map = mapRef.current
    const predio = puntos.find((item) => item.id === elegidoId)
    if (!map || !predio || predio.latitud == null || predio.longitud == null) return
    map.setView([predio.latitud, predio.longitud], Math.max(map.getZoom(), 17))
  }, [elegidoId, puntos])

  return (
    <div
      ref={host}
      className={cn(
        'min-h-0 flex-1 overflow-hidden rounded-xl border border-border [&_.leaflet-container]:z-0 [&_.leaflet-container]:h-full [&_.leaflet-container]:w-full [&_img]:max-w-none',
        ubicar && 'cursor-crosshair',
      )}
    />
  )
}
