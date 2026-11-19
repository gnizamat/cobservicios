import { asFacturacionError } from '@/modules/facturacion/api/errors'
import { addDaysIso } from '@/modules/facturacion/labels'
import type {
  DeudaAFacturar,
  FacturacionGenerada,
  GenerarFacturacionResultado,
  ReciboFactura,
  ReciboLinea,
  TarifaFacturacion,
  TerritorioFacturacion,
} from '@/modules/facturacion/types'
import { supabase } from '@/shared/lib/supabase'
import type { Json } from '@/shared/types/database'

export interface FiltroFacturacion {
  anio: number
  mes: number
  sectorId?: string
  calleId?: string
}

function filtroIds(filtros: FiltroFacturacion) {
  return {
    p_anio: filtros.anio,
    p_mes: filtros.mes,
    p_sector_id: filtros.sectorId && filtros.sectorId !== 'all' ? filtros.sectorId : null,
    p_calle_id: filtros.calleId && filtros.calleId !== 'all' ? filtros.calleId : null,
  }
}

function asRows(value: Json | null): Array<Record<string, Json | undefined>> {
  if (!Array.isArray(value)) return []
  return value.filter(
    (row): row is Record<string, Json | undefined> =>
      row != null && typeof row === 'object' && !Array.isArray(row),
  )
}

function num(value: Json | undefined) {
  const parsed = Number(value)
  return Number.isFinite(parsed) ? parsed : 0
}

function text(value: Json | undefined) {
  return value == null ? '' : String(value)
}

function mapPendiente(row: Record<string, Json | undefined>): DeudaAFacturar {
  return {
    predio_id: text(row.predio_id),
    predio: text(row.predio),
    numero: text(row.numero),
    usuario: text(row.usuario),
    sector: text(row.sector),
    calle: text(row.calle),
    deudas: num(row.deudas),
    monto: num(row.monto),
    anio: num(row.anio),
    mes: num(row.mes),
  }
}

function mapGenerada(row: Record<string, Json | undefined>): FacturacionGenerada {
  return {
    id: text(row.id),
    numero: text(row.numero_factura) || text(row.numero),
    predio_id: text(row.predio_id),
    predio: text(row.predio),
    numero_predio: text(row.numero_predio),
    usuario: text(row.usuario),
    sector: text(row.sector),
    calle: text(row.calle),
    anio: num(row.anio),
    mes: num(row.mes),
    monto: num(row.monto),
    fecha: text(row.fecha),
    deudas: num(row.deudas),
  }
}

export async function listTerritorioFacturacion(): Promise<TerritorioFacturacion> {
  const [sectores, calles] = await Promise.all([
    supabase.from('cat_sectores').select('id, nombre').order('nombre'),
    supabase.from('cat_calles').select('id, nombre, sector_id').order('nombre'),
  ])
  if (sectores.error) throw asFacturacionError(sectores.error)
  if (calles.error) throw asFacturacionError(calles.error)
  return { sectores: sectores.data ?? [], calles: calles.data ?? [] }
}

export async function listTarifasFacturacion(): Promise<TarifaFacturacion[]> {
  const { data, error } = await supabase
    .from('cat_tarifas')
    .select('id, anio, nombre, activa')
    .order('anio', { ascending: false })
  if (error) throw asFacturacionError(error)
  return data ?? []
}

export async function listDeudasAFacturar(filtros: FiltroFacturacion): Promise<DeudaAFacturar[]> {
  const { data, error } = await supabase.rpc('listar_deudas_a_facturar', filtroIds(filtros))
  if (error) throw asFacturacionError(error)
  return asRows(data).map(mapPendiente)
}

export async function listFacturacionesGeneradas(
  filtros: FiltroFacturacion,
): Promise<FacturacionGenerada[]> {
  const { data, error } = await supabase.rpc('listar_facturaciones', filtroIds(filtros))
  if (error) throw asFacturacionError(error)
  return asRows(data).map(mapGenerada)
}

export async function generarFacturacion(
  anio: number,
  mes: number,
  predioIds: string[],
): Promise<GenerarFacturacionResultado> {
  const { data, error } = await supabase.rpc('generar_facturacion', {
    p_anio: anio,
    p_mes: mes,
    p_predio_ids: predioIds,
  })
  if (error) throw asFacturacionError(error)
  const payload = data && typeof data === 'object' && !Array.isArray(data) ? data : {}
  return {
    generadas: num(payload.generadas),
    monto: num(payload.monto),
  }
}

type Rel<T> = T | T[] | null

function one<T>(value: Rel<T> | undefined): T | null {
  if (value == null) return null
  return Array.isArray(value) ? (value[0] ?? null) : value
}

function periodBefore(anio: number, mes: number, otherAnio: number, otherMes: number) {
  return otherAnio < anio || (otherAnio === anio && otherMes < mes)
}

export async function getRecibo(id: string): Promise<ReciboFactura> {
  const facturaQuery = supabase
    .from('fac_facturaciones')
    .select(
      'id, numero, anio, mes, monto_total, fecha, predio_id, predio:pad_predios(nombre, numero, manzana, lote, unidad_catastral, sector:cat_sectores(nombre), calle:cat_calles(nombre), usuario:pad_usuarios(nombres, apellido_paterno, apellido_materno, dni, ruc))',
    )
    .eq('id', id)
    .maybeSingle()
  const detalleQuery = supabase
    .from('fac_facturacion_detalle')
    .select(
      'monto, tipo_servicio_id, deuda:fac_deudas_anteriores(volumen, tarifa_id), servicio:cat_tipos_servicio(nombre)',
    )
    .eq('facturacion_id', id)

  const [facturaResult, detalleResult] = await Promise.all([facturaQuery, detalleQuery])
  if (facturaResult.error) throw asFacturacionError(facturaResult.error)
  if (detalleResult.error) throw asFacturacionError(detalleResult.error)
  const factura = facturaResult.data
  if (!factura) throw new Error('No se encontró la facturación.')

  const predio = one(factura.predio)
  const usuario = one(predio?.usuario)
  const detalles = detalleResult.data ?? []
  const tarifaIds = [
    ...new Set(
      detalles
        .map((row) => one(row.deuda)?.tarifa_id)
        .filter((value): value is string => Boolean(value)),
    ),
  ]

  const [costosResult, lecturasResult, deudasResult, medidorResult] = await Promise.all([
    tarifaIds.length
      ? supabase
          .from('cat_costos_tarifa')
          .select('tarifa_id, tipo_servicio_id, monto, valor')
          .in('tarifa_id', tarifaIds)
      : Promise.resolve({ data: [], error: null }),
    supabase
      .from('hid_lecturas')
      .select('anio, mes, lectura_m3, volumen_m3, fecha_lectura')
      .eq('predio_id', factura.predio_id)
      .order('anio', { ascending: true })
      .order('mes', { ascending: true })
      .order('fecha_lectura', { ascending: true }),
    supabase.from('fac_deudas_anteriores').select('anio, mes, saldo').eq('predio_id', factura.predio_id),
    supabase
      .from('hid_medidores')
      .select('codigo')
      .eq('predio_id', factura.predio_id)
      .eq('estado', 'activo')
      .limit(1),
  ])
  if (costosResult.error) throw asFacturacionError(costosResult.error)
  if (lecturasResult.error) throw asFacturacionError(lecturasResult.error)
  if (deudasResult.error) throw asFacturacionError(deudasResult.error)
  if (medidorResult.error) throw asFacturacionError(medidorResult.error)

  const costos = new Map(
    (costosResult.data ?? []).map((costo) => [
      `${costo.tarifa_id}:${costo.tipo_servicio_id}`,
      Number(costo.monto) > 0 ? Number(costo.monto) : Number(costo.valor),
    ]),
  )
  const lineas: ReciboLinea[] = detalles.map((row) => {
    const deuda = one(row.deuda)
    const servicio = one(row.servicio)
    const costo = deuda ? (costos.get(`${deuda.tarifa_id}:${row.tipo_servicio_id}`) ?? 0) : 0
    return {
      servicio: servicio?.nombre ?? 'Servicio',
      costo,
      monto: Number(row.monto),
      volumen: Number(deuda?.volumen ?? 0),
    }
  })

  const lecturas = lecturasResult.data ?? []
  const actual =
    [...lecturas].reverse().find((lectura) => lectura.anio === factura.anio && lectura.mes === factura.mes) ??
    null
  const anterior = actual
    ? [...lecturas]
        .reverse()
        .find((lectura) => periodBefore(actual.anio, actual.mes, lectura.anio, lectura.mes))
    : null
  const saldoAnterior = (deudasResult.data ?? [])
    .filter((deuda) => periodBefore(factura.anio, factura.mes, deuda.anio, deuda.mes))
    .reduce((sum, deuda) => sum + Number(deuda.saldo), 0)
  const monto = Number(factura.monto_total)
  const nombre = [usuario?.apellido_paterno, usuario?.apellido_materno, usuario?.nombres]
    .map((part) => part?.trim())
    .filter(Boolean)
    .join(' ')

  return {
    id: factura.id,
    numero: factura.numero,
    anio: factura.anio,
    mes: factura.mes,
    fecha: factura.fecha,
    vencimiento: addDaysIso(factura.fecha, 15),
    monto,
    saldoAnterior,
    totalPagar: Math.round((monto + saldoAnterior) * 100) / 100,
    usuario: nombre.toUpperCase(),
    documento: usuario?.dni || usuario?.ruc || '',
    predio: predio?.nombre ?? '',
    numeroPredio: predio?.numero ?? '',
    manzana: predio?.manzana ?? '',
    lote: predio?.lote ?? '',
    calle: one(predio?.calle)?.nombre ?? '',
    sector: one(predio?.sector)?.nombre ?? '',
    codigo: medidorResult.data?.[0]?.codigo || predio?.unidad_catastral || '',
    volumen: lineas.reduce((sum, linea) => sum + linea.volumen, 0),
    lecturaAnterior: anterior ? Number(anterior.lectura_m3) : null,
    lecturaActual: actual ? Number(actual.lectura_m3) : null,
    diferencia: actual ? Number(actual.volumen_m3) : null,
    lineas,
  }
}
