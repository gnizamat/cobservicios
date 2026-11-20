import { Button } from '@/design-system/atoms'

export function EditRowButton({
  editing,
  onEdit,
}: {
  editing: boolean
  onEdit: () => void
}) {
  return (
    <Button
      type="button"
      variant={editing ? 'default' : 'outline'}
      size="sm"
      className="h-7 px-2"
      onClick={(event) => {
        event.stopPropagation()
        onEdit()
      }}
    >
      {editing ? 'Editando' : 'Editar'}
    </Button>
  )
}

export function DeleteRowButton({
  deleting,
  onDelete,
}: {
  deleting: boolean
  onDelete: () => void
}) {
  return (
    <Button
      type="button"
      variant="outline"
      size="sm"
      className="h-7 px-2 text-destructive hover:text-destructive"
      disabled={deleting}
      onClick={(event) => {
        event.stopPropagation()
        onDelete()
      }}
    >
      {deleting ? 'Eliminando' : 'Eliminar'}
    </Button>
  )
}

export function SaveNotice({
  error,
  saved,
}: {
  error: string | null
  saved: string | null
}) {
  return (
    <>
      {error ? (
        <p role="alert" className="mb-3 text-sm text-destructive">
          {error}
        </p>
      ) : null}
      {saved ? (
        <p className="mb-3 text-sm text-foreground" role="status">
          Se guardó «{saved}».
        </p>
      ) : null}
    </>
  )
}
