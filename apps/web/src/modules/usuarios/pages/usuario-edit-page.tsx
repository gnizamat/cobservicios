import { useNavigate, useParams } from 'react-router-dom'
import { PageHeader } from '@/design-system/molecules'
import { AppShell } from '@/design-system/templates'
import { useUpdateUsuario, useUsuario } from '@/modules/usuarios/api'
import { UsuarioForm } from '@/modules/usuarios/components/usuario-form'

export function UsuarioEditPage() {
  const { id = '' } = useParams()
  const navigate = useNavigate()
  const { data, isLoading, isError, error } = useUsuario(id)
  const update = useUpdateUsuario(id)

  return (
    <AppShell>
      <PageHeader
        title="Modificar usuario"
        description="Actualización de datos del padrón de usuarios."
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
          <UsuarioForm
            initial={data}
            submitting={update.isPending}
            submitLabel="Guardar cambios"
            onCancel={() => navigate(`/padron/usuarios/${id}`)}
            onSubmit={(payload) => {
              update.mutate(payload, {
                onSuccess: () => navigate(`/padron/usuarios/${id}`),
              })
            }}
          />
        </>
      ) : null}
    </AppShell>
  )
}
