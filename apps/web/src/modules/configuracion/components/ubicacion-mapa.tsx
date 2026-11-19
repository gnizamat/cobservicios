import { useEffect, useRef } from 'react'
import L from 'leaflet'
import 'leaflet/dist/leaflet.css'

const SEDE = { lat: -5.1947, lng: -80.6165 }

export interface UbicacionMapaProps {
  latitud: number | null
  longitud: number | null
  onPick: (latitud: number, longitud: number) => void
}

function roundCoordinate(value: number) {
  return Math.round(value * 1_000_000) / 1_000_000
}

export function UbicacionMapa({ latitud, longitud, onPick }: UbicacionMapaProps) {
  const host = useRef<HTMLDivElement>(null)
  const mapRef = useRef<L.Map | null>(null)
  const markerRef = useRef<L.CircleMarker | null>(null)
  const onPickRef = useRef(onPick)
  onPickRef.current = onPick

  useEffect(() => {
    const element = host.current
    if (!element || mapRef.current) return
    const map = L.map(element, {
      center: [SEDE.lat, SEDE.lng],
      zoom: 15,
    })
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; OpenStreetMap',
    }).addTo(map)
    map.on('click', (event) => {
      onPickRef.current(roundCoordinate(event.latlng.lat), roundCoordinate(event.latlng.lng))
    })
    mapRef.current = map
    return () => {
      map.remove()
      mapRef.current = null
      markerRef.current = null
    }
  }, [])

  useEffect(() => {
    const map = mapRef.current
    if (!map || latitud == null || longitud == null) return
    const point = L.latLng(latitud, longitud)
    if (!markerRef.current) {
      markerRef.current = L.circleMarker(point, {
        radius: 9,
        color: '#0f766e',
        fillColor: '#14b8a6',
        fillOpacity: 0.95,
        weight: 2,
      }).addTo(map)
      map.setView(point, map.getZoom())
      return
    }
    markerRef.current.setLatLng(point)
  }, [latitud, longitud])

  return (
    <div
      ref={host}
      className="h-80 w-full overflow-hidden rounded-xl border border-border [&_.leaflet-container]:z-0 [&_.leaflet-container]:h-full [&_.leaflet-container]:w-full [&_img]:max-w-none"
    />
  )
}
