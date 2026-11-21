import { useNavigate } from 'react-router-dom'
import { PageHeader } from '@/design-system/molecules'
import { AppShell } from '@/design-system/templates'
import { useCreateUsuario } from '@/modules/usuarios/api'
import { UsuarioForm } from '@/modules/usuarios/components/usuario-form'

export function UsuarioCreatePage() {
  const navigate = useNavigate()
  const create = useCreateUsuario()

  return (
    <AppShell>
      <PageHeader
        className="mb-3"
        title="Registrar usuario"
        description="Alta de usuario de servicio en el padrón."
      />
      {create.isError ? (
        <p role="alert" className="mb-4 text-sm text-destructive">
          {(create.error as Error).message}
        </p>
      ) : null}
      <UsuarioForm
        submitting={create.isPending}
        submitLabel="Registrar"
        onCancel={() => navigate('/padron/usuarios')}
        onSubmit={(payload) => {
          create.mutate(payload, {
            onSuccess: () => navigate('/padron/usuarios'),
          })
        }}
      />
    </AppShell>
  )
}
