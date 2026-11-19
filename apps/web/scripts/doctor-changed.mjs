import { spawnSync } from 'node:child_process'
import { existsSync } from 'node:fs'
import { dirname, join } from 'node:path'
import { fileURLToPath } from 'node:url'

const root = join(dirname(fileURLToPath(import.meta.url)), '..')
process.chdir(root)

const gitOk =
  spawnSync('git', ['rev-parse', '--is-inside-work-tree'], {
    encoding: 'utf8',
    stdio: 'pipe',
  }).status === 0

const headOk =
  gitOk &&
  spawnSync('git', ['rev-parse', 'HEAD'], { encoding: 'utf8', stdio: 'pipe' })
    .status === 0

const args = headOk
  ? ['--verbose', '--scope', 'changed', '--include-untracked', '--no-telemetry']
  : ['--verbose', '--no-telemetry']

if (!headOk) {
  console.warn(
    '[doctor:changed] Sin git/HEAD — usando escaneo completo. Inicializá el repo para diff scope.',
  )
}

const bin =
  process.platform === 'win32'
    ? join(root, 'node_modules', '.bin', 'react-doctor.cmd')
    : join(root, 'node_modules', '.bin', 'react-doctor')

const command = existsSync(bin) ? bin : 'npx'
const commandArgs = existsSync(bin) ? args : ['react-doctor', ...args]

const result = spawnSync(command, commandArgs, {
  encoding: 'utf8',
  stdio: 'inherit',
  shell: true,
})

process.exit(result.status ?? 1)
