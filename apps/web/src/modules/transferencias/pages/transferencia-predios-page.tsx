import { useState } from 'react'
import { PageHeader } from '@/design-system/molecules'
import { AppShell } from '@/design-system/templates'
import { PredioHistorialPanel } from '@/modules/transferencias/components/predio-historial-panel'
import { TransferenciaForm } from '@/modules/transferencias/components/transferencia-form'
import { TransferenciasHistorial } from '@/modules/transferencias/components/transferencias-historial'
import type { PredioDeUsuario } from '@/modules/transferencias/types'

export function TransferenciaPrediosPage() {
  const [predio, setPredio] = useState<PredioDeUsuario | null>(null)

  return (
    <AppShell>
      <PageHeader
        title="Transferencia de predios"
        description="Buscá el usuario de origen y el destino, pasá los predios y registrá una referencia. La titularidad y cada transferencia quedan en el historial."
      />
      <TransferenciaForm onInspectPredio={setPredio} />
      {predio ? (
        <div className="mt-4">
          <PredioHistorialPanel
            predioId={predio.id}
            nombre={predio.nombre}
            onClose={() => setPredio(null)}
          />
        </div>
      ) : null}
      <TransferenciasHistorial onInspectPredio={setPredio} />
    </AppShell>
  )
}
