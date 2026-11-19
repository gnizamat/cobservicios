import { useState } from 'react'

export function useRecordSelection<T extends { id: string }>(records: T[]) {
  const [mode, setMode] = useState<'edit' | 'create'>('edit')
  const [selectedId, setSelectedId] = useState<string | null>(null)

  const selected =
    mode === 'create'
      ? null
      : (records.find((row) => row.id === selectedId) ?? records[0] ?? null)

  return {
    selected,
    startCreate: () => {
      setMode('create')
      setSelectedId(null)
    },
    select: (id: string) => {
      setMode('edit')
      setSelectedId(id)
    },
  }
}
