import { useEffect, useState, type FormEvent } from 'react'
import { Button, Input } from '@/design-system/atoms'
import { useEliminarFacturacion } from '@/modules/facturacion/api'
import { formatMoney } from '@/modules/facturacion/labels'
import type { FacturacionGenerada } from '@/modules/facturacion/types'
import { useAuth } from '@/modules/auth'

export function EliminarFacturacionDialog({
  factura,
  onClose,
  onEliminada,
}: {
  factura: FacturacionGenerada
  onClose: () => void
  onEliminada: (mensaje: string) => void
}) {
  const { user } = useAuth()
  const eliminar = useEliminarFacturacion()
  const [clave, setClave] = useState('')
  const [motivo, setMotivo] = useState('')
  const correo = user?.email ?? ''
  const puedeEnviar = clave.trim().length > 0 && motivo.trim().length >= 5 && Boolean(correo)

  useEffect(() => {
    function onKey(event: KeyboardEvent) {
      if (event.key === 'Escape' && !eliminar.isPending) onClose()
    }
    window.addEventListener('keydown', onKey)
    return () => window.removeEventListener('keydown', onKey)
  }, [eliminar.isPending, onClose])

  function enviar(event: FormEvent) {
    event.preventDefault()
    if (!puedeEnviar || factura.tienePagos) return
    eliminar.mutate(
      { facturacionId: factura.id, clave, motivo: motivo.trim() },
      {
        onSuccess: (resultado) => {
          setClave('')
          onEliminada(
            `Se eliminó ${resultado.numero}. Las deudas volvieron a quedar pendientes de facturar.`,
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
        aria-labelledby="eliminar-facturacion-titulo"
        onSubmit={enviar}
        className="my-8 w-full max-w-md rounded-2xl border border-border bg-card p-4 shadow-[var(--shadow-sm)]"
      >
        <h3 id="eliminar-facturacion-titulo" className="text-base font-semibold">
          Eliminar facturación
        </h3>
        <p className="mt-2 text-sm text-muted-foreground">
          {factura.numero} · {factura.usuario || 'Sin usuario'} · {formatMoney(factura.monto)}. Se
          borra el recibo y las deudas vuelven a quedar pendientes. La operación queda registrada con
          tu usuario, la fecha y el motivo.
        </p>
        {factura.tienePagos ? (
          <p role="alert" className="mt-3 text-sm text-destructive">
            No se puede eliminar: las deudas de esta facturación están vinculadas a pagos.
          </p>
        ) : (
          <p className="mt-3 text-sm text-foreground">
            Confirmá la contraseña de <span className="font-medium">{correo || 'tu sesión'}</span>.
          </p>
        )}

        <label className="mt-3 flex flex-col gap-1 text-xs text-muted-foreground">
          Contraseña
          <Input
            type="password"
            autoComplete="current-password"
            value={clave}
            onChange={(event) => setClave(event.target.value)}
            aria-label="Contraseña para eliminar la facturación"
            disabled={factura.tienePagos}
            className="h-8 text-sm"
          />
        </label>
        <label className="mt-3 flex flex-col gap-1 text-xs text-muted-foreground">
          Motivo
          <Input
            value={motivo}
            onChange={(event) => setMotivo(event.target.value)}
            aria-label="Motivo de la eliminación"
            placeholder="Por qué se elimina esta facturación"
            disabled={factura.tienePagos}
            className="h-8 text-sm"
          />
        </label>

        {eliminar.isError ? (
          <p role="alert" className="mt-3 text-sm text-destructive">
            {(eliminar.error as Error).message}
          </p>
        ) : null}

        <div className="mt-4 flex justify-end gap-2">
          <Button type="button" variant="ghost" size="sm" disabled={eliminar.isPending} onClick={onClose}>
            Cancelar
          </Button>
          <Button
            type="submit"
            variant="destructive"
            size="sm"
            disabled={!puedeEnviar || factura.tienePagos || eliminar.isPending}
          >
            {eliminar.isPending ? 'Eliminando…' : 'Eliminar facturación'}
          </Button>
        </div>
      </form>
    </div>
  )
}
