export interface TerritorioFacturacion {
  sectores: Array<{ id: string; nombre: string }>
  calles: Array<{ id: string; nombre: string; sector_id: string | null }>
}

export interface TarifaFacturacion {
  id: string
  anio: number
  nombre: string
  activa: boolean
}

export interface DeudaAFacturar {
  predio_id: string
  predio: string
  numero: string
  usuario: string
  sector: string
  calle: string
  deudas: number
  monto: number
  anio: number
  mes: number
}

export interface FacturacionGenerada {
  id: string
  numero: string
  predio_id: string
  predio: string
  numero_predio: string
  usuario: string
  sector: string
  calle: string
  anio: number
  mes: number
  monto: number
  fecha: string
  deudas: number
}

export interface GenerarFacturacionResultado {
  generadas: number
  monto: number
}

export interface ReciboLinea {
  servicio: string
  costo: number
  monto: number
  volumen: number
}

export interface ReciboFactura {
  id: string
  numero: string
  anio: number
  mes: number
  fecha: string
  vencimiento: string
  monto: number
  saldoAnterior: number
  totalPagar: number
  usuario: string
  documento: string
  predio: string
  numeroPredio: string
  manzana: string
  lote: string
  calle: string
  sector: string
  codigo: string
  volumen: number
  lecturaAnterior: number | null
  lecturaActual: number | null
  diferencia: number | null
  lineas: ReciboLinea[]
}
