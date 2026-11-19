import { zodResolver } from '@hookform/resolvers/zod'
import { ChevronLeft, ChevronRight, LoaderCircle, Save } from 'lucide-react'
import { useState } from 'react'
import { useForm } from 'react-hook-form'
import { Button, Icon, Textarea } from '@/design-system/atoms'
import { FormField } from '@/design-system/molecules'
import { usePrediosDeUsuario, useRegistrarTransferencia } from '@/modules/transferencias/api'
import { PredioTransferTable } from '@/modules/transferencias/components/predio-transfer-table'
import { UsuarioPicker } from '@/modules/transferencias/components/usuario-picker'
import {
  transferenciaFormSchema,
  type TransferenciaFormValues,
} from '@/modules/transferencias/schemas'
import type { PredioDeUsuario, UsuarioResumen } from '@/modules/transferencias/types'

const defaults: TransferenciaFormValues = {
  usuario_origen_id: '',
  usuario_destino_id: '',
  referencia: '',
  predio_ids: [],
}

function toggleId(ids: string[], id: string) {
  return ids.includes(id) ? ids.filter((item) => item !== id) : [...ids, id]
}

function origenEmptyMessage(hasUsuario: boolean) {
  return hasUsuario
    ? 'Este usuario no tiene predios activos por transferir.'
    : 'Buscá un usuario para ver sus predios.'
}

function destinoEmptyMessage(hasUsuario: boolean) {
  return hasUsuario
    ? 'Este usuario no tiene predios activos.'
    : 'Elegí el destino para ver los predios que ya tiene.'
}

export interface TransferenciaFormProps {
  onInspectPredio: (predio: PredioDeUsuario) => void
}

export function TransferenciaForm({ onInspectPredio }: TransferenciaFormProps) {
  const form = useForm<TransferenciaFormValues>({
    resolver: zodResolver(transferenciaFormSchema),
    defaultValues: defaults,
  })
  const registrar = useRegistrarTransferencia()
  const [origen, setOrigen] = useState<UsuarioResumen | null>(null)
  const [destino, setDestino] = useState<UsuarioResumen | null>(null)
  const [leftChecked, setLeftChecked] = useState<string[]>([])
  const [rightChecked, setRightChecked] = useState<string[]>([])
  const [success, setSuccess] = useState('')

  const stagedIds = form.watch('predio_ids')
  const origenPredios = usePrediosDeUsuario(origen?.id)
  const destinoPredios = usePrediosDeUsuario(destino?.id)
  const origenItems = origenPredios.data ?? []
  const staged = new Set(stagedIds)
  const leftPredios = origenItems.filter((predio) => !staged.has(predio.id))
  const stagedPredios = origenItems.filter((predio) => staged.has(predio.id))
  const destinoItems = destinoPredios.data ?? []
  const validate = form.formState.isSubmitted

  const clearMovimiento = () => {
    form.setValue('predio_ids', [])
    setLeftChecked([])
    setRightChecked([])
  }

  const moveToDestino = () => {
    form.setValue('predio_ids', [...new Set([...stagedIds, ...leftChecked])], {
      shouldValidate: validate,
    })
    setLeftChecked([])
    setSuccess('')
  }

  const moveToOrigen = () => {
    const remove = new Set(rightChecked)
    form.setValue(
      'predio_ids',
      stagedIds.filter((id) => !remove.has(id)),
      { shouldValidate: validate },
    )
    setRightChecked([])
    setSuccess('')
  }

  const resetForm = () => {
    form.reset({
      usuario_origen_id: '',
      usuario_destino_id: '',
      referencia: '',
      predio_ids: [],
    })
    setOrigen(null)
    setDestino(null)
    setLeftChecked([])
    setRightChecked([])
    setSuccess('')
    registrar.reset()
  }

  const selectOrigen = (usuario: UsuarioResumen | null) => {
    setOrigen(usuario)
    form.setValue('usuario_origen_id', usuario?.id ?? '', { shouldValidate: validate })
    clearMovimiento()
    setSuccess('')
  }

  const selectDestino = (usuario: UsuarioResumen | null) => {
    setDestino(usuario)
    form.setValue('usuario_destino_id', usuario?.id ?? '', { shouldValidate: validate })
    setSuccess('')
  }

  return (
    <form
      noValidate
      onSubmit={form.handleSubmit(async (values) => {
        setSuccess('')
        try {
          await registrar.mutateAsync(values)
        } catch {
          return
        }
        form.setValue('predio_ids', [])
        form.setValue('referencia', '')
        setLeftChecked([])
        setRightChecked([])
        setSuccess('Transferencia registrada. El historial de cada predio quedó actualizado.')
      })}
    >
      <div className="rounded-2xl border border-border bg-card p-4 shadow-[var(--shadow-sm)] sm:p-5">
        <h3 className="mb-4 font-[family-name:var(--font-display)] text-base font-semibold">
          Transferencia de predios
        </h3>

        <div className="grid items-start gap-3 lg:grid-cols-[minmax(0,1fr)_auto_minmax(0,1fr)]">
          <OrigenColumn
            usuario={origen}
            excludeId={destino?.id}
            error={form.formState.errors.usuario_origen_id?.message}
            predios={leftPredios}
            checkedIds={leftChecked}
            loading={origenPredios.isLoading}
            onSelect={selectOrigen}
            onCheckedChange={setLeftChecked}
            onInspect={onInspectPredio}
          />
          <TransferActions
            selectedCount={leftChecked.length}
            returnCount={rightChecked.length}
            hasDestino={Boolean(destino)}
            onMoveRight={moveToDestino}
            onMoveLeft={moveToOrigen}
          />
          <DestinoColumn
            usuario={destino}
            excludeId={origen?.id}
            error={form.formState.errors.usuario_destino_id?.message}
            stagedPredios={stagedPredios}
            ownedPredios={destinoItems}
            checkedIds={rightChecked}
            loading={destinoPredios.isLoading}
            onSelect={selectDestino}
            onCheckedChange={setRightChecked}
            onInspect={onInspectPredio}
          />
        </div>

        <FormField
          className="mt-4"
          label="Referencia"
          htmlFor="referencia"
          error={form.formState.errors.referencia?.message}
          hint="Queda guardada en la transferencia y en el historial de cada predio."
        >
          <Textarea
            id="referencia"
            rows={2}
            placeholder="Acta, documento o motivo de la transferencia"
            {...form.register('referencia')}
          />
        </FormField>

        <FormNotices
          predioError={form.formState.errors.predio_ids?.message}
          origenLoadError={origenPredios.isError}
          destinoLoadError={destinoPredios.isError}
          saveError={registrar.error}
          success={success}
        />

        <div className="mt-5 flex flex-wrap items-center justify-end gap-2 border-t border-border pt-4">
          <Button type="button" variant="outline" onClick={resetForm} disabled={registrar.isPending}>
            Cancelar
          </Button>
          <Button type="submit" disabled={registrar.isPending}>
            <SaveIcon pending={registrar.isPending} />
            Grabar
          </Button>
        </div>
      </div>
    </form>
  )
}

function SaveIcon({ pending }: { pending: boolean }) {
  if (pending) return <Icon icon={LoaderCircle} className="animate-spin" />
  return <Icon icon={Save} size={16} />
}

function OrigenColumn({
  usuario,
  excludeId,
  error,
  predios,
  checkedIds,
  loading,
  onSelect,
  onCheckedChange,
  onInspect,
}: {
  usuario: UsuarioResumen | null
  excludeId?: string
  error?: string
  predios: PredioDeUsuario[]
  checkedIds: string[]
  loading: boolean
  onSelect: (usuario: UsuarioResumen | null) => void
  onCheckedChange: (ids: string[]) => void
  onInspect: (predio: PredioDeUsuario) => void
}) {
  return (
    <section className="min-w-0 space-y-3">
      <UsuarioPicker
        id="usuario-origen"
        label="Seleccione usuario"
        value={usuario}
        excludeId={excludeId}
        error={error}
        onChange={onSelect}
      />
      <PredioPanel
        title="Predios del origen"
        count={predios.length}
        predios={predios}
        checkedIds={checkedIds}
        loading={Boolean(usuario) && loading}
        emptyMessage={origenEmptyMessage(Boolean(usuario))}
        onToggle={(id) => onCheckedChange(toggleId(checkedIds, id))}
        onToggleAll={(checked) =>
          onCheckedChange(checked ? predios.map((predio) => predio.id) : [])
        }
        onInspect={onInspect}
      />
    </section>
  )
}

function DestinoColumn({
  usuario,
  excludeId,
  error,
  stagedPredios,
  ownedPredios,
  checkedIds,
  loading,
  onSelect,
  onCheckedChange,
  onInspect,
}: {
  usuario: UsuarioResumen | null
  excludeId?: string
  error?: string
  stagedPredios: PredioDeUsuario[]
  ownedPredios: PredioDeUsuario[]
  checkedIds: string[]
  loading: boolean
  onSelect: (usuario: UsuarioResumen | null) => void
  onCheckedChange: (ids: string[]) => void
  onInspect: (predio: PredioDeUsuario) => void
}) {
  return (
    <section className="min-w-0 space-y-3">
      <UsuarioPicker
        id="usuario-destino"
        label="Seleccione usuario destino"
        value={usuario}
        excludeId={excludeId}
        error={error}
        onChange={onSelect}
      />
      <PredioPanel
        title="Por transferir"
        count={stagedPredios.length}
        predios={stagedPredios}
        checkedIds={checkedIds}
        highlighted
        emptyMessage="Pasá predios con la flecha. Todavía no se graban."
        onToggle={(id) => onCheckedChange(toggleId(checkedIds, id))}
        onToggleAll={(checked) =>
          onCheckedChange(checked ? stagedPredios.map((predio) => predio.id) : [])
        }
        onInspect={onInspect}
      />
      <PredioPanel
        title="Predios actuales del destino"
        count={ownedPredios.length}
        predios={ownedPredios}
        checkedIds={[]}
        selectable={false}
        loading={Boolean(usuario) && loading}
        emptyMessage={destinoEmptyMessage(Boolean(usuario))}
        onInspect={onInspect}
      />
    </section>
  )
}

function TransferActions({
  selectedCount,
  returnCount,
  hasDestino,
  onMoveRight,
  onMoveLeft,
}: {
  selectedCount: number
  returnCount: number
  hasDestino: boolean
  onMoveRight: () => void
  onMoveLeft: () => void
}) {
  const needsDestino = selectedCount > 0 && !hasDestino
  return (
    <div className="flex items-center justify-center gap-2 lg:flex-col lg:pt-24">
      <Button
        type="button"
        variant="outline"
        size="icon"
        aria-label="Pasar predios seleccionados al destino"
        disabled={selectedCount === 0 || !hasDestino}
        onClick={onMoveRight}
      >
        <Icon icon={ChevronRight} />
      </Button>
      <Button
        type="button"
        variant="outline"
        size="icon"
        aria-label="Devolver predios seleccionados al origen"
        disabled={returnCount === 0}
        onClick={onMoveLeft}
      >
        <Icon icon={ChevronLeft} />
      </Button>
      {needsDestino ? (
        <p className="max-w-28 text-center text-[11px] text-muted-foreground">
          Elegí el usuario destino
        </p>
      ) : null}
    </div>
  )
}

function FormNotices({
  predioError,
  origenLoadError,
  destinoLoadError,
  saveError,
  success,
}: {
  predioError?: string
  origenLoadError: boolean
  destinoLoadError: boolean
  saveError: unknown
  success: string
}) {
  const loadError = origenLoadError || destinoLoadError
  const saveMessage = saveError instanceof Error ? saveError.message : ''
  return (
    <>
      {predioError ? (
        <p role="alert" className="mt-3 text-sm text-destructive">
          {predioError}
        </p>
      ) : null}
      {loadError ? (
        <p role="alert" className="mt-3 text-sm text-destructive">
          No se pudieron cargar los predios.
        </p>
      ) : null}
      {saveMessage ? (
        <p role="alert" className="mt-3 text-sm text-destructive">
          {saveMessage}
        </p>
      ) : null}
      {success ? (
        <p role="status" className="mt-3 text-sm text-foreground">
          {success}
        </p>
      ) : null}
    </>
  )
}

function PredioPanel({
  title,
  count,
  predios,
  checkedIds,
  emptyMessage,
  loading,
  selectable = true,
  highlighted = false,
  onToggle,
  onToggleAll,
  onInspect,
}: {
  title: string
  count: number
  predios: PredioDeUsuario[]
  checkedIds: string[]
  emptyMessage: string
  loading?: boolean
  selectable?: boolean
  highlighted?: boolean
  onToggle?: (id: string) => void
  onToggleAll?: (checked: boolean) => void
  onInspect: (predio: PredioDeUsuario) => void
}) {
  const frame = highlighted
    ? 'overflow-hidden rounded-xl border border-primary/40 bg-primary/5'
    : 'overflow-hidden rounded-xl border border-border'

  return (
    <div className={frame}>
      <div className="flex items-center justify-between border-b border-border/80 px-3 py-2">
        <h4 className="text-xs font-semibold tracking-wide text-muted-foreground uppercase">
          {title}
        </h4>
        <span className="text-[11px] text-muted-foreground">{count}</span>
      </div>
      <div className="max-h-64 overflow-auto">
        <PredioTransferTable
          predios={predios}
          checkedIds={checkedIds}
          selectable={selectable}
          loading={loading}
          emptyMessage={emptyMessage}
          onToggle={onToggle}
          onToggleAll={onToggleAll}
          onInspect={onInspect}
        />
      </div>
    </div>
  )
}
