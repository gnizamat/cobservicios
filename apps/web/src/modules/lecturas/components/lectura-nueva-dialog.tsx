import { useEffect, useRef } from 'react'
import { Button } from '@/design-system/atoms'
import type { LecturaListItem, PredioOption, ServicioOption, ValorM3Activo } from '@/modules/lecturas/api'
import { LecturaForm } from '@/modules/lecturas/components/lectura-form'
import { SaveNotice } from '@/modules/lecturas/components/record-actions'
import { predioLabel, titularLabel } from '@/modules/lecturas/labels'
import type { LecturaPayload } from '@/modules/lecturas/schemas'

export function LecturaNuevaDialog({
  predio,
  predios,
  servicios,
  lecturas,
  valoresM3,
  historialListo,
  loading,
  submitting,
  error,
  onClose,
  onRegisterMeter,
  onSubmit,
}: {
  predio: PredioOption
  predios: PredioOption[]
  servicios: ServicioOption[]
  lecturas: LecturaListItem[]
  valoresM3: ValorM3Activo[]
  historialListo: boolean
  loading: boolean
  submitting: boolean
  error: string | null
  onClose: () => void
  onRegisterMeter: (predioId: string) => void
  onSubmit: (payload: LecturaPayload) => void
}) {
  const dialogRef = useRef<HTMLDialogElement>(null)
  useEffect(() => {
    const dialog = dialogRef.current
    if (!dialog || dialog.open) return
    dialog.showModal()
  }, [])

  return (
    <dialog
      ref={dialogRef}
      aria-labelledby="lectura-nueva-titulo"
      className="m-auto w-[min(52rem,calc(100vw-2rem))] max-w-none rounded-2xl border border-border bg-card p-4 shadow-[var(--shadow-sm)] backdrop:bg-foreground/40"
      onClose={onClose}
    >
      <div className="mb-3 flex items-start justify-between gap-3">
        <div className="min-w-0">
          <h3 id="lectura-nueva-titulo" className="text-base font-semibold text-foreground">
            Lectura de {titularLabel(predio.usuario)}
          </h3>
          <p className="text-sm text-muted-foreground">{predioLabel(predio)}</p>
        </div>
        <Button type="button" variant="outline" size="sm" onClick={() => dialogRef.current?.close()}>
          Cerrar
        </Button>
      </div>
      {loading ? (
        <p className="text-sm text-muted-foreground">Cargando datos del formulario…</p>
      ) : (
        <>
          <SaveNotice error={error} saved={null} />
          <LecturaForm
            key={`${predio.id}-${predio.medidor?.id ?? 'sin'}`}
            predioId={predio.id}
            predioFijo
            predios={predios}
            servicios={servicios}
            lecturas={lecturas}
            valoresM3={valoresM3}
            historialListo={historialListo}
            submitting={submitting}
            onRegisterMeter={onRegisterMeter}
            onSubmit={onSubmit}
          />
        </>
      )}
    </dialog>
  )
}
