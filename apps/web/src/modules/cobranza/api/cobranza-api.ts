import { asCobranzaError } from '@/modules/cobranza/api/errors'
import { logoPublicUrl } from '@/modules/configuracion'
import { supabase } from '@/shared/lib/supabase'
import type { Json } from '@/shared/types/database'

export interface TerritorioCobranza {
  sectores: Array<{ id: string; nombre: string }>
  calles: Array<{ id: string; nombre: string; sector_id: string }>
}

export interface PredioCobranza {
  predioId: string
  predio: string
  numero: string
  usuario: string
  documento: string
  sector: string
  calle: string
  facturas: number
  monto: number
}

export interface FacturaCobro {
  id: string
  numero: string
  anio: number
  mes: number
  monto: number
  interes: number
  volumen: number
  servicios: string
  fecha: string
  estado: string
}

export interface CobranzaPredio {
  id: string
  nombre: string
  numero: string
  sector: string
  calle: string
  usuario: string
  documento: string
  facturas: FacturaCobro[]
}

export interface CobroRegistrado {
  id: string
  numero: string
  monto: number
  interes: number
  facturas: number
}

export interface FiltroCobranza {
  sectorId: string
  calleId: string
  search: string
}

type Rel<T> = T | T[] | null

function one<T>(value: Rel<T> | undefined): T | null {
  if (value == null) return null
  return Array.isArray(value) ? (value[0] ?? null) : value
}

function asRows(value: Json | null): Array<Record<string, Json | undefined>> {
  if (!Array.isArray(value)) return []
  return value.filter(
    (row): row is Record<string, Json | undefined> =>
      row != null && typeof row === 'object' && !Array.isArray(row),
  )
}

function num(value: Json | number | string | null | undefined) {
  const parsed = Number(value ?? 0)
  return Number.isFinite(parsed) ? parsed : 0
}

function text(value: Json | string | null | undefined) {
  return value == null ? '' : String(value)
}

function nullableId(value: string) {
  return value && value !== 'all' ? value : null
}

export async function listTerritorioCobranza(): Promise<TerritorioCobranza> {
  const [sectores, calles] = await Promise.all([
    supabase.from('cat_sectores').select('id, nombre').order('nombre'),
    supabase.from('cat_calles').select('id, nombre, sector_id').order('nombre'),
  ])
  if (sectores.error) throw asCobranzaError(sectores.error)
  if (calles.error) throw asCobranzaError(calles.error)
  return {
    sectores: sectores.data ?? [],
    calles: (calles.data ?? []).filter((calle) => calle.sector_id),
  } as TerritorioCobranza
}

export async function listPrediosACobrar(filtros: FiltroCobranza): Promise<PredioCobranza[]> {
  const { data, error } = await supabase.rpc('listar_predios_a_cobrar', {
    p_sector_id: nullableId(filtros.sectorId),
    p_calle_id: nullableId(filtros.calleId),
    p_search: filtros.search.trim() || null,
  })
  if (error) throw asCobranzaError(error)
  return asRows(data).map((row) => ({
    predioId: text(row.predio_id),
    predio: text(row.predio),
    numero: text(row.numero),
    usuario: text(row.usuario),
    documento: text(row.documento),
    sector: text(row.sector),
    calle: text(row.calle),
    facturas: num(row.facturas),
    monto: num(row.monto),
  }))
}

type DetalleRow = {
  servicio: Rel<{ nombre: string }>
  deuda: Rel<{ volumen: number | string | null; interes: number | string | null }>
}

export async function getCobranzaPredio(predioId: string): Promise<CobranzaPredio> {
  const predioQuery = supabase
    .from('pad_predios')
    .select(
      'id, nombre, numero, sector:cat_sectores(nombre), calle:cat_calles(nombre), usuario:pad_usuarios(nombres, apellido_paterno, apellido_materno, dni, ruc)',
    )
    .eq('id', predioId)
    .maybeSingle()
  const facturasQuery = supabase
    .from('fac_facturaciones')
    .select(
      'id, numero, anio, mes, monto_total, fecha, estado, detalle:fac_facturacion_detalle(servicio:cat_tipos_servicio(nombre), deuda:fac_deudas_anteriores(volumen, interes))',
    )
    .eq('predio_id', predioId)
    .order('anio', { ascending: false })
    .order('mes', { ascending: false })

  const [predioResult, facturasResult] = await Promise.all([predioQuery, facturasQuery])
  if (predioResult.error) throw asCobranzaError(predioResult.error)
  if (facturasResult.error) throw asCobranzaError(facturasResult.error)
  const predio = predioResult.data
  if (!predio) throw new Error('No se encontró el predio.')

  const usuario = one(predio.usuario)
  const documento = usuario?.dni
    ? `DNI ${usuario.dni}`
    : usuario?.ruc
      ? `RUC ${usuario.ruc}`
      : ''
  const nombre = [usuario?.apellido_paterno, usuario?.apellido_materno, usuario?.nombres]
    .filter(Boolean)
    .join(' ')

  return {
    id: predio.id,
    nombre: predio.nombre,
    numero: predio.numero ?? '',
    sector: one(predio.sector)?.nombre ?? '',
    calle: one(predio.calle)?.nombre ?? '',
    usuario: nombre,
    documento,
    facturas: (facturasResult.data ?? []).map((factura) => {
      const detalles = (factura.detalle ?? []) as DetalleRow[]
      const servicios = detalles
        .map((detalle) => one(detalle.servicio)?.nombre ?? '')
        .filter(Boolean)
      const volumen = detalles.reduce((total, detalle) => total + num(one(detalle.deuda)?.volumen), 0)
      const interes = detalles.reduce((total, detalle) => total + num(one(detalle.deuda)?.interes), 0)
      return {
        id: factura.id,
        numero: factura.numero,
        anio: factura.anio,
        mes: factura.mes,
        monto: num(factura.monto_total),
        interes,
        volumen,
        servicios: servicios.join(' · '),
        fecha: factura.fecha,
        estado: factura.estado,
      }
    }),
  }
}

export interface CajaCobranza {
  id: string
  nombre: string
}

export interface PagoListado {
  id: string
  numero: string
  fecha: string
  tipoPago: string
  referencia: string
  monto: number
  interes: number
  anulado: boolean
  cajaId: string
  caja: string
  predio: string
  numeroPredio: string
  usuario: string
  documento: string
  sector: string
  calle: string
  facturas: string
  anuladoPor: string
  motivoAnulacion: string
  anuladoEn: string
}

export interface FiltroPagos {
  sectorId: string
  cajaId: string
  desde: string
  hasta: string
  search: string
}

export async function listCajas(): Promise<CajaCobranza[]> {
  const { data, error } = await supabase
    .from('cob_cajas')
    .select('id, nombre')
    .eq('activa', true)
    .order('nombre')
  if (error) throw asCobranzaError(error)
  return data ?? []
}

export async function listPagos(filtros: FiltroPagos): Promise<PagoListado[]> {
  const { data, error } = await supabase.rpc('listar_pagos', {
    p_sector_id: nullableId(filtros.sectorId),
    p_caja_id: nullableId(filtros.cajaId),
    p_desde: filtros.desde || null,
    p_hasta: filtros.hasta || null,
    p_search: filtros.search.trim() || null,
  })
  if (error) throw asCobranzaError(error)
  return asRows(data).map((row) => ({
    id: text(row.id),
    numero: text(row.numero),
    fecha: text(row.fecha),
    tipoPago: text(row.tipo_pago),
    referencia: text(row.referencia),
    monto: num(row.monto),
    interes: num(row.interes),
    anulado: row.anulado === true,
    cajaId: text(row.caja_id),
    caja: text(row.caja),
    predio: text(row.predio),
    numeroPredio: text(row.numero_predio),
    usuario: text(row.usuario),
    documento: text(row.documento),
    sector: text(row.sector),
    calle: text(row.calle),
    facturas: text(row.facturas),
    anuladoPor: text(row.anulado_por),
    motivoAnulacion: text(row.motivo_anulacion),
    anuladoEn: text(row.anulado_en),
  }))
}

export async function anularPago(input: {
  pagoId: string
  clave: string
  motivo: string
}): Promise<{ id: string; numero: string; facturas: number }> {
  const { data, error } = await supabase.rpc('anular_pago', {
    p_pago_id: input.pagoId,
    p_clave: input.clave,
    p_motivo: input.motivo,
  })
  if (error) throw asCobranzaError(error)
  const payload = data && typeof data === 'object' && !Array.isArray(data) ? data : {}
  return {
    id: text(payload.id),
    numero: text(payload.numero),
    facturas: num(payload.facturas),
  }
}

export async function cobrarFacturaciones(input: {
  predioId: string
  facturacionIds: string[]
  tipoPago: string
  referencia: string
  fecha: string
  cajaId?: string
}): Promise<CobroRegistrado> {
  const { data, error } = await supabase.rpc('cobrar_facturaciones', {
    p_predio_id: input.predioId,
    p_facturacion_ids: input.facturacionIds,
    p_tipo_pago: input.tipoPago,
    p_referencia: input.referencia,
    p_fecha: input.fecha,
    p_caja_id: input.cajaId || null,
  })
  if (error) throw asCobranzaError(error)
  const payload = data && typeof data === 'object' && !Array.isArray(data) ? data : {}
  return {
    id: text(payload.id),
    numero: text(payload.numero),
    monto: num(payload.monto),
    interes: num(payload.interes),
    facturas: num(payload.facturas),
  }
}

export interface ReciboPagoLinea {
  factura: string
  anio: number
  mes: number
  servicio: string
  volumen: number
  monto: number
}

export interface ReciboPago {
  id: string
  numero: string
  fecha: string
  anio: number
  monto: number
  usuario: string
  documento: string
  codigo: string
  sector: string
  calle: string
  predio: string
  numeroCasa: string
  manzana: string
  lote: string
  lineas: ReciboPagoLinea[]
  emisor: {
    nombre: string
    abreviatura: string
    direccion: string
    celular: string
    logoUrl: string | null
  }
}

type FacturaRelacion = { numero: string; anio: number; mes: number }
type DetallePago = {
  facturacion_id: string
  monto: number | string
  servicio: Rel<{ nombre: string }>
  deuda: Rel<{ volumen: number | string | null }>
}

export async function getReciboPago(id: string): Promise<ReciboPago> {
  const [pagoResult, orgResult] = await Promise.all([
    supabase
      .from('cob_pagos')
      .select('id, predio_id, numero, fecha, monto')
      .eq('id', id)
      .maybeSingle(),
    supabase
      .from('org_jass')
      .select('nombre, abreviatura, direccion, celular, logo_path')
      .eq('id', true)
      .maybeSingle(),
  ])
  if (pagoResult.error) throw asCobranzaError(pagoResult.error)
  if (orgResult.error) throw asCobranzaError(orgResult.error)
  const pago = pagoResult.data
  if (!pago) throw new Error('No se encontró el recibo de pago.')

  const [predioResult, linksResult] = await Promise.all([
    supabase
      .from('pad_predios')
      .select(
        'nombre, numero, manzana, lote, sector:cat_sectores(nombre), calle:cat_calles(nombre), usuario:pad_usuarios(nombres, apellido_paterno, apellido_materno, dni, ruc)',
      )
      .eq('id', pago.predio_id)
      .maybeSingle(),
    supabase
      .from('cob_pago_facturaciones')
      .select('facturacion_id, monto, factura:fac_facturaciones(numero, anio, mes)')
      .eq('pago_id', id),
  ])
  if (predioResult.error) throw asCobranzaError(predioResult.error)
  if (linksResult.error) throw asCobranzaError(linksResult.error)

  const links = linksResult.data ?? []
  const facturaIds = links.map((link) => link.facturacion_id)
  const detallesResult = facturaIds.length
    ? await supabase
        .from('fac_facturacion_detalle')
        .select(
          'facturacion_id, monto, servicio:cat_tipos_servicio(nombre), deuda:fac_deudas_anteriores(volumen)',
        )
        .in('facturacion_id', facturaIds)
    : { data: [], error: null }
  if (detallesResult.error) throw asCobranzaError(detallesResult.error)

  const facturas = new Map(
    links.map((link) => {
      const factura = one(link.factura as Rel<FacturaRelacion>)
      return [
        link.facturacion_id,
        {
          numero: factura?.numero ?? '',
          anio: factura?.anio ?? 0,
          mes: factura?.mes ?? 0,
          monto: num(link.monto),
        },
      ]
    }),
  )
  const detalles = (detallesResult.data ?? []) as DetallePago[]
  const lineas: ReciboPagoLinea[] = detalles.map((detalle) => {
    const factura = facturas.get(detalle.facturacion_id)
    return {
      factura: factura?.numero ?? '',
      anio: factura?.anio ?? 0,
      mes: factura?.mes ?? 0,
      servicio: one(detalle.servicio)?.nombre ?? '',
      volumen: num(one(detalle.deuda)?.volumen),
      monto: num(detalle.monto),
    }
  })
  if (lineas.length === 0) {
    for (const factura of facturas.values()) {
      lineas.push({
        factura: factura.numero,
        anio: factura.anio,
        mes: factura.mes,
        servicio: '',
        volumen: 0,
        monto: factura.monto,
      })
    }
  }
  lineas.sort((left, right) => left.anio - right.anio || left.mes - right.mes || left.factura.localeCompare(right.factura))

  const predio = predioResult.data
  const usuario = one(predio?.usuario)
  const codigo = usuario?.dni || usuario?.ruc || ''
  const org = orgResult.data

  return {
    id: pago.id,
    numero: pago.numero,
    fecha: pago.fecha,
    anio: Number(pago.fecha.slice(0, 4)),
    monto: num(pago.monto),
    usuario: [usuario?.apellido_paterno, usuario?.apellido_materno, usuario?.nombres]
      .filter(Boolean)
      .join(' ')
      .toUpperCase(),
    documento: codigo,
    codigo,
    sector: (one(predio?.sector)?.nombre ?? '').toUpperCase(),
    calle: one(predio?.calle)?.nombre ?? '',
    predio: predio?.nombre ?? '',
    numeroCasa: predio?.numero ?? '',
    manzana: predio?.manzana ?? '',
    lote: predio?.lote ?? '',
    lineas,
    emisor: {
      nombre: (org?.nombre || 'Junta administradora de servicios de saneamiento').toUpperCase(),
      abreviatura: (org?.abreviatura ?? '').toUpperCase(),
      direccion: org?.direccion ?? '',
      celular: org?.celular ?? '',
      logoUrl: logoPublicUrl(org?.logo_path),
    },
  }
}
