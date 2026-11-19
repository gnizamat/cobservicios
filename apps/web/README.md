# apps/web — COBSERVICIOS

React + Vite + Tailwind + shadcn + Supabase local.

## Docker propio

```bash
npm run supabase:start   # levanta el stack Docker de ESTE proyecto
npm run supabase:status
npm run supabase:stop
```

Requiere Docker Desktop con el **engine respondiendo** (`docker version` debe mostrar Server).

## Dev

```bash
npm install
npm run dev
```

## React Doctor (obligatorio)

Tras generar o editar código React, verificar siempre:

```bash
npm run doctor:changed   # cambios vs base + untracked
npm run doctor           # escaneo completo
npm run verify           # lint + build + doctor
```

- Config: [`doctor.config.ts`](./doctor.config.ts)
- Skill: [`.cursor/skills/react-doctor/`](./.cursor/skills/react-doctor/)
- Hook stop: [`.cursor/hooks.json`](./.cursor/hooks.json) (rescanea al cerrar el turno del agente)

Ver [AGENTS.md](./AGENTS.md) y `.cursor/rules/` para el harness de IA.
