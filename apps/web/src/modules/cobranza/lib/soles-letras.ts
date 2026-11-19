const UNIDADES = ['', 'UN', 'DOS', 'TRES', 'CUATRO', 'CINCO', 'SEIS', 'SIETE', 'OCHO', 'NUEVE']
const DIEZ = [
  'DIEZ',
  'ONCE',
  'DOCE',
  'TRECE',
  'CATORCE',
  'QUINCE',
  'DIECISEIS',
  'DIECISIETE',
  'DIECIOCHO',
  'DIECINUEVE',
]
const VEINTE = [
  'VEINTE',
  'VEINTIUN',
  'VEINTIDOS',
  'VEINTITRES',
  'VEINTICUATRO',
  'VEINTICINCO',
  'VEINTISEIS',
  'VEINTISIETE',
  'VEINTIOCHO',
  'VEINTINUEVE',
]
const DECENAS = ['', '', 'VEINTE', 'TREINTA', 'CUARENTA', 'CINCUENTA', 'SESENTA', 'SETENTA', 'OCHENTA', 'NOVENTA']
const CENTENAS = [
  '',
  'CIENTO',
  'DOSCIENTOS',
  'TRESCIENTOS',
  'CUATROCIENTOS',
  'QUINIENTOS',
  'SEISCIENTOS',
  'SETECIENTOS',
  'OCHOCIENTOS',
  'NOVECIENTOS',
]

function centenas(value: number) {
  if (value === 0) return ''
  if (value === 100) return 'CIEN'
  const hundreds = Math.floor(value / 100)
  const rest = value % 100
  let tens = ''
  if (rest < 10) tens = UNIDADES[rest]
  else if (rest < 20) tens = DIEZ[rest - 10]
  else if (rest < 30) tens = VEINTE[rest - 20]
  else {
    const ten = Math.floor(rest / 10)
    const unit = rest % 10
    tens = unit ? `${DECENAS[ten]} Y ${UNIDADES[unit]}` : DECENAS[ten]
  }
  return [hundreds ? CENTENAS[hundreds] : '', tens].filter(Boolean).join(' ')
}

function cerrarUnidad(text: string) {
  if (text === 'UN') return 'UNO'
  if (text.endsWith('VEINTIUN')) return `${text}O`
  if (text.endsWith(' Y UN')) return `${text}O`
  return text
}

function entero(value: number) {
  if (value === 0) return 'CERO'
  const millions = Math.floor(value / 1_000_000)
  const thousands = Math.floor((value % 1_000_000) / 1000)
  const rest = value % 1000
  const parts = [
    millions ? `${millions === 1 ? 'UN' : centenas(millions)} MILLON${millions === 1 ? '' : 'ES'}` : '',
    thousands ? `${thousands === 1 ? '' : `${centenas(thousands)} `}MIL` : '',
    rest ? centenas(rest) : '',
  ].filter(Boolean)
  return cerrarUnidad(parts.join(' ').replace(/\s+/g, ' ').trim())
}

export function solesEnLetras(monto: number) {
  const total = Math.round(monto * 100)
  const soles = Math.floor(total / 100)
  const centavos = String(total % 100).padStart(2, '0')
  return `SON ${entero(soles)} Y ${centavos}/100 SOLES`
}
