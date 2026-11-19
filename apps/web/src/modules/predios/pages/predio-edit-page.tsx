import { useNavigate, useParams } from 'react-router-dom'
import { PageHeader } from '@/design-system/molecules'
import { AppShell } from '@/design-system/templates'
import { usePredio, useUpdatePredio } from '@/modules/predios/api'
import { PredioForm } from '@/modules/predios/components/predio-form'

export function PredioEditPage() {
  const { id = '' } = useParams()
  const navigate = useNavigate()
  const { data, isLoading, isError, error } = usePredio(id)
  const update = useUpdatePredio(id)

  return (
    <AppShell>
      <PageHeader
        title="Modificar predio"
        description="Actualización de datos del predio de servicio."
      />
      {isLoading ? (
        <p className="text-sm text-muted-foreground">Cargando…</p>
      ) : isError ? (
        <p role="alert" className="text-sm text-destructive">
          {(error as Error).message}
        </p>
      ) : data ? (
        <>
          {update.isError ? (
            <p role="alert" className="mb-4 text-sm text-destructive">
              {(update.error as Error).message}
            </p>
          ) : null}
          <PredioForm
            initial={data}
            submitting={update.isPending}
            submitLabel="Guardar cambios"
            onCancel={() => navigate('/padron/predios')}
            onSubmit={(payload) => {
              update.mutate(payload, {
                onSuccess: () => navigate('/padron/predios'),
              })
            }}
          />
        </>
      ) : null}
    </AppShell>
  )
}
