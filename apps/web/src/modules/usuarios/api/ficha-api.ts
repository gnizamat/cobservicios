import { getUsuario } from '@/modules/usuarios/api/usuarios-api'
import { supabase } from '@/shared/lib/supabase'
import type { EstadoRegistro, PadUsuario } from '@/shared/types/database'

export interface FichaPredio {
  id: string
  nombre: string
  numero: string
  manzana: string
  lote: string
  unidadCatastral: string
  estado: EstadoRegistro
  sector: string
  calle: string
  tipo: string
  medidores: FichaMedidor[]
}

export interface FichaMedidor {
  id: string
  codigo: string
  marca: string
  estado: string
  fechaInstalacion: string
}

export interface FichaDeuda {
  id: string
  predioId: string
  anio: number
  mes: number
  monto: number
  saldo: number
  volumen: number
  fecha: string
  concepto: string
}

export interface FichaFactura {
  id: string
  predioId: string
  anio: number
  mes: number
  numero: string
  monto: number
  fecha: string
  estado: string
  conceptos: string
}

export interface FichaLectura {
  id: string
  predioId: string
  anio: number
  mes: number
  fecha: string
  lecturaM3: number
  volumenM3: number
  referencia: string
  servicio: string
}

export interface FichaVolumen {
  id: string
  predioId: string
  anio: number
  mes: number
  volumenM3: number
  fecha: string
  referencia: string
  servicio: string
}

export interface FichaHistorial {
  id: string
  predioId: string
  transferenciaId: string | null
  referencia: string
  vigente: boolean
  desde: string
  hasta: string | null
  nombrePredio: string
}

export interface FichaPago {
  id: string
  predioId: string
  numero: string
  fecha: string
  tipoPago: string
  referencia: string
  monto: number
  interes: number
}

export interface UsuarioFicha {
  usuario: PadUsuario
  predios: FichaPredio[]
  deudas: FichaDeuda[]
  facturas: FichaFactura[]
  pagos: FichaPago[]
  lecturas: FichaLectura[]
  volumenes: FichaVolumen[]
  historial: FichaHistorial[]
}

type NombreRelacion = { nombre: string } | { nombre: string }[] | null

function relacionNombre(value: NombreRelacion) {
  if (!value) return ''
  const row = Array.isArray(value) ? value[0] : value
  return row?.nombre ?? ''
}

function asNumber(value: number | string | null | undefined) {
  const parsed = Number(value ?? 0)
  return Number.isFinite(parsed) ? parsed : 0
}

function asText(value: string | null | undefined) {
  return value?.trim() ?? ''
}

export async function getFichaUsuario(id: string): Promise<UsuarioFicha> {
  const usuario = await getUsuario(id)

  const { data: predioRows, error: prediosError } = await supabase
    .from('pad_predios')
    .select(
      'id, nombre, numero, manzana, lote, unidad_catastral, estado, sector:cat_sectores(nombre), calle:cat_calles(nombre), tipo_predio:cat_tipos_predio(nombre)',
    )
    .eq('usuario_id', id)
    .order('nombre', { ascending: true })
  if (prediosError) throw prediosError

  const predioBase = predioRows ?? []
  const predioIds = predioBase.map((predio) => predio.id)

  if (predioIds.length === 0) {
    return {
      usuario,
      predios: [],
      deudas: [],
      facturas: [],
      pagos: [],
      lecturas: [],
      volumenes: [],
      historial: [],
    }
  }

  const [medidoresRes, deudasRes, facturasRes, pagosRes, lecturasRes, volumenesRes, historialRes] =
    await Promise.all([
      supabase
        .from('hid_medidores')
        .select('id, predio_id, codigo, marca, estado, fecha_instalacion')
        .in('predio_id', predioIds)
        .order('fecha_instalacion', { ascending: false }),
      supabase
        .from('fac_deudas_anteriores')
        .select(
          'id, predio_id, anio, mes, monto, saldo, volumen, fecha_registro, concepto, servicio:cat_tipos_servicio(nombre)',
        )
        .in('predio_id', predioIds)
        .order('anio', { ascending: false })
        .order('mes', { ascending: false }),
      supabase
        .from('fac_facturaciones')
        .select('id, predio_id, anio, mes, numero, monto_total, fecha, estado')
        .in('predio_id', predioIds)
        .order('fecha', { ascending: false }),
      supabase
        .from('cob_pagos')
        .select('id, predio_id, numero, fecha, tipo_pago, referencia, monto, interes')
        .in('predio_id', predioIds)
        .eq('anulado', false)
        .order('fecha', { ascending: false }),
      supabase
        .from('hid_lecturas')
        .select(
          'id, predio_id, anio, mes, fecha_lectura, lectura_m3, volumen_m3, referencia, servicio:cat_tipos_servicio(nombre)',
        )
        .in('predio_id', predioIds)
        .order('fecha_lectura', { ascending: false }),
      supabase
        .from('hid_volumenes_sin_lectura')
        .select(
          'id, predio_id, anio, mes, volumen_m3, referencia, created_at, servicio:cat_tipos_servicio(nombre)',
        )
        .in('predio_id', predioIds)
        .order('created_at', { ascending: false }),
      supabase
        .from('pad_predio_historial')
        .select(
          'id, predio_id, transferencia_id, referencia, vigente, desde, hasta, nombre_predio',
        )
        .in('predio_id', predioIds)
        .order('desde', { ascending: false }),
    ])

  if (medidoresRes.error) throw medidoresRes.error
  if (deudasRes.error) throw deudasRes.error
  if (facturasRes.error) throw facturasRes.error
  if (pagosRes.error) throw pagosRes.error
  if (lecturasRes.error) throw lecturasRes.error
  if (volumenesRes.error) throw volumenesRes.error
  if (historialRes.error) throw historialRes.error

  const facturaIds = (facturasRes.data ?? []).map((factura) => factura.id)
  const detallePorFactura = new Map<string, string[]>()
  if (facturaIds.length > 0) {
    const { data: detalles, error: detalleError } = await supabase
      .from('fac_facturacion_detalle')
      .select('facturacion_id, servicio:cat_tipos_servicio(nombre)')
      .in('facturacion_id', facturaIds)
    if (detalleError) throw detalleError
    for (const detalle of detalles ?? []) {
      const nombre = relacionNombre(detalle.servicio as NombreRelacion)
      if (!nombre) continue
      const actuales = detallePorFactura.get(detalle.facturacion_id) ?? []
      actuales.push(nombre)
      detallePorFactura.set(detalle.facturacion_id, actuales)
    }
  }

  const medidoresPorPredio = new Map<string, FichaMedidor[]>()
  for (const medidor of medidoresRes.data ?? []) {
    const lista = medidoresPorPredio.get(medidor.predio_id) ?? []
    lista.push({
      id: medidor.id,
      codigo: medidor.codigo,
      marca: asText(medidor.marca),
      estado: medidor.estado,
      fechaInstalacion: medidor.fecha_instalacion,
    })
    medidoresPorPredio.set(medidor.predio_id, lista)
  }

  return {
    usuario,
    predios: predioBase.map((predio) => ({
      id: predio.id,
      nombre: predio.nombre,
      numero: asText(predio.numero),
      manzana: asText(predio.manzana),
      lote: asText(predio.lote),
      unidadCatastral: asText(predio.unidad_catastral),
      estado: predio.estado,
      sector: relacionNombre(predio.sector as NombreRelacion),
      calle: relacionNombre(predio.calle as NombreRelacion),
      tipo: relacionNombre(predio.tipo_predio as NombreRelacion),
      medidores: medidoresPorPredio.get(predio.id) ?? [],
    })),
    deudas: (deudasRes.data ?? []).map((deuda) => ({
      id: deuda.id,
      predioId: deuda.predio_id,
      anio: deuda.anio,
      mes: deuda.mes,
      monto: asNumber(deuda.monto),
      saldo: asNumber(deuda.saldo),
      volumen: asNumber(deuda.volumen),
      fecha: deuda.fecha_registro,
      concepto: asText(deuda.concepto) || relacionNombre(deuda.servicio as NombreRelacion),
    })),
    pagos: (pagosRes.data ?? []).map((pago) => ({
      id: pago.id,
      predioId: pago.predio_id,
      numero: pago.numero,
      fecha: pago.fecha,
      tipoPago: pago.tipo_pago,
      referencia: asText(pago.referencia),
      monto: asNumber(pago.monto),
      interes: asNumber(pago.interes),
    })),
    facturas: (facturasRes.data ?? []).map((factura) => ({
      id: factura.id,
      predioId: factura.predio_id,
      anio: factura.anio,
      mes: factura.mes,
      numero: factura.numero,
      monto: asNumber(factura.monto_total),
      fecha: factura.fecha,
      estado: factura.estado,
      conceptos: (detallePorFactura.get(factura.id) ?? []).join(' · '),
    })),
    lecturas: (lecturasRes.data ?? []).map((lectura) => ({
      id: lectura.id,
      predioId: lectura.predio_id,
      anio: lectura.anio,
      mes: lectura.mes,
      fecha: lectura.fecha_lectura,
      lecturaM3: asNumber(lectura.lectura_m3),
      volumenM3: asNumber(lectura.volumen_m3),
      referencia: asText(lectura.referencia),
      servicio: relacionNombre(lectura.servicio as NombreRelacion),
    })),
    volumenes: (volumenesRes.data ?? []).map((volumen) => ({
      id: volumen.id,
      predioId: volumen.predio_id,
      anio: volumen.anio,
      mes: volumen.mes,
      volumenM3: asNumber(volumen.volumen_m3),
      fecha: volumen.created_at,
      referencia: asText(volumen.referencia),
      servicio: relacionNombre(volumen.servicio as NombreRelacion),
    })),
    historial: (historialRes.data ?? []).map((fila) => ({
      id: fila.id,
      predioId: fila.predio_id,
      transferenciaId: fila.transferencia_id,
      referencia: asText(fila.referencia),
      vigente: fila.vigente,
      desde: fila.desde,
      hasta: fila.hasta,
      nombrePredio: asText(fila.nombre_predio),
    })),
  }
}
