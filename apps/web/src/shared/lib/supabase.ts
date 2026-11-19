import { createClient } from '@supabase/supabase-js'
import type { Database } from '@/shared/types/database'

const url = import.meta.env.VITE_SUPABASE_URL
const anonKey = import.meta.env.VITE_SUPABASE_ANON_KEY

if (!url || !anonKey) {
  console.warn(
    '[supabase] Missing VITE_SUPABASE_URL or VITE_SUPABASE_ANON_KEY. Copy .env.example to .env.local after `supabase start`.',
  )
}

export const supabase = createClient<Database>(
  url ?? 'http://127.0.0.1:54421',
  anonKey ?? 'public-anon-key',
)
