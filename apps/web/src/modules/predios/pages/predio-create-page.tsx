import { useNavigate } from 'react-router-dom'
import { PageHeader } from '@/design-system/molecules'
import { AppShell } from '@/design-system/templates'
import { useCreatePredio } from '@/modules/predios/api'
import { PredioForm } from '@/modules/predios/components/predio-form'

export function PredioCreatePage() {
  const navigate = useNavigate()
  const create = useCreatePredio()

  return (
    <AppShell>
      <PageHeader
        className="mb-3"
        title="Registrar predio"
        description="Alta de predio asociado a un usuario del padrón."
      />
      {create.isError ? (
        <p role="alert" className="mb-4 text-sm text-destructive">
          {(create.error as Error).message}
        </p>
      ) : null}
      <PredioForm
        submitting={create.isPending}
        submitLabel="Registrar"
        onCancel={() => navigate('/padron/predios')}
        onSubmit={(payload) => {
          create.mutate(payload, {
            onSuccess: () => navigate('/padron/predios'),
          })
        }}
      />
    </AppShell>
  )
}
