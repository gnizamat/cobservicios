import type { ReactDoctorConfig } from 'react-doctor'

/**
 * React Doctor — verificación determinística del código React generado.
 * Docs: https://www.react.doctor/docs
 */
const config: ReactDoctorConfig = {
  $schema: 'https://www.react.doctor/schema.json',
  lint: true,
  verbose: false,
  blocking: 'error',
  warnings: true,
  supplyChain: {
    enabled: true,
    severity: 'warning',
    minScore: 40,
  },
  ignore: {
    files: ['dist/**', 'node_modules/**', 'supabase/**', 'src/shared/types/database.ts'],
    // shadcn re-exports variants alongside components (cva helpers)
    overrides: [
      {
        files: ['src/components/ui/**', 'src/design-system/atoms/**'],
        rules: [
          'react/only-export-components',
          'react-doctor/only-export-components',
        ],
      },
    ],
  },
}

export default config
