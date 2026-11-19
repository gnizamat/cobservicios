import { useEffect, useState, type FormEvent } from 'react'
import { Button, Input } from '@/design-system/atoms'
import { useAnularPago } from '@/modules/cobranza/api'
import type { PagoListado } from '@/modules/cobranza/api'
import { formatMoney } from '@/modules/cobranza/labels'
import { useAuth } from '@/modules/auth'

export function AnularPagoDialog({
  pago,
  onClose,
  onAnulado,
}: {
  pago: PagoListado
  onClose: () => void
  onAnulado: (mensaje: string) => void
}) {
  const { user } = useAuth()
  const anular = useAnularPago()
  const [clave, setClave] = useState('')
  const [motivo, setMotivo] = useState('')
  const correo = user?.email ?? ''
  const puedeEnviar = clave.trim().length > 0 && motivo.trim().length >= 5 && Boolean(correo)

  useEffect(() => {
    function onKey(event: KeyboardEvent) {
      if (event.key === 'Escape' && !anular.isPending) onClose()
    }
    window.addEventListener('keydown', onKey)
    return () => window.removeEventListener('keydown', onKey)
  }, [anular.isPending, onClose])

  function enviar(event: FormEvent) {
    event.preventDefault()
    if (!puedeEnviar) return
    anular.mutate(
      { pagoId: pago.id, clave, motivo: motivo.trim() },
      {
        onSuccess: (resultado) => {
          setClave('')
          onAnulado(
            resultado.facturas > 0
              ? `Se eliminó ${resultado.numero}. Las facturas volvieron a quedar pendientes.`
              : `Se eliminó ${resultado.numero}.`,
          )
          onClose()
        },
      },
    )
  }

  return (
    <div
      className="fixed inset-0 z-50 flex items-start justify-center overflow-y-auto bg-foreground/40 p-4"
      role="presentation"
    >
      <form
        role="dialog"
        aria-modal="true"
        aria-labelledby="anular-pago-titulo"
        onSubmit={enviar}
        className="my-8 w-full max-w-md rounded-2xl border border-border bg-card p-4 shadow-[var(--shadow-sm)]"
      >
        <h3 id="anular-pago-titulo" className="text-base font-semibold">
          Eliminar pago
        </h3>
        <p className="mt-2 text-sm text-muted-foreground">
          {pago.numero} · {pago.usuario || 'Sin usuario'} · {formatMoney(pago.monto)}. El recibo queda
          anulado y las facturas vuelven a estar pendientes. La operación se registra con tu usuario,
          la fecha y el motivo.
        </p>
        <p className="mt-3 text-sm text-foreground">
          Confirmá la contraseña de <span className="font-medium">{correo || 'tu sesión'}</span>.
        </p>

        <label className="mt-3 flex flex-col gap-1 text-xs text-muted-foreground">
          Contraseña
          <Input
            type="password"
            autoComplete="current-password"
            value={clave}
            onChange={(event) => setClave(event.target.value)}
            aria-label="Contraseña para eliminar el pago"
            className="h-8 text-sm"
          />
        </label>
        <label className="mt-3 flex flex-col gap-1 text-xs text-muted-foreground">
          Motivo
          <Input
            value={motivo}
            onChange={(event) => setMotivo(event.target.value)}
            aria-label="Motivo de la eliminación"
            placeholder="Por qué se elimina este pago"
            className="h-8 text-sm"
          />
        </label>

        {anular.isError ? (
          <p role="alert" className="mt-3 text-sm text-destructive">
            {(anular.error as Error).message}
          </p>
        ) : null}

        <div className="mt-4 flex justify-end gap-2">
          <Button type="button" variant="ghost" size="sm" disabled={anular.isPending} onClick={onClose}>
            Cancelar
          </Button>
          <Button type="submit" variant="destructive" size="sm" disabled={!puedeEnviar || anular.isPending}>
            {anular.isPending ? 'Eliminando…' : 'Eliminar pago'}
          </Button>
        </div>
      </form>
    </div>
  )
}
