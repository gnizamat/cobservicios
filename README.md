# COBSERVICIOS — orquestador

La raíz **solo orquesta**. El producto nuevo vive en [`apps/web`](apps/web).

## Dos Docker independientes

| Dueño | Stack | Comando |
|--------|--------|---------|
| **`apps/web`** | Supabase (Postgres, Auth, Studio…) | `npm run supabase:start` |
| **Raíz** | SQL Server (backup legado `.BAK`) | `npm run db:legacy:up` |

No mezclar: el compose de la raíz **no** incluye el backend de la app.

## Requisitos

- Node.js ≥ 20
- Docker Desktop con engine saludable (`docker version` debe mostrar **Server**)
- RAM suficiente si levantás SQL Server legado + Supabase a la vez

## Arranque rápido (app)

```bash
cd apps/web && npm install
cd ../..
npm run supabase:start   # Docker propio de apps/web
npm run web:dev          # Vite en http://localhost:5173
```

O todo junto (Supabase + web):

```bash
npm run dev
```

## Legado SQL Server (solo referencia)

```bash
npm run db:legacy:up
npm run db:legacy:restore
```

- Host: `localhost,1433`
- User: `sa`
- Password: `Cobser_Legacy_2022!`
- Backup montado: `DB_JASS_NVOTALLAN.BAK` (base `DB_JASS_NVOTALLAN`)

Código VB.NET de referencia: `COBSER_JASS_PEDREGAL/` (no se importa al bundle).

## Scripts del orquestador

| Script | Acción |
|--------|--------|
| `web:dev` / `web:build` / `web:lint` | Delega a `apps/web` |
| `web:doctor` / `web:doctor:changed` / `web:verify` | React Doctor (+ gate lint/build) |
| `supabase:start` / `stop` / `status` | Delega a `apps/web` (Docker Supabase) |
| `db:legacy:up` / `down` / `restore` | SQL Server + restore del BAK |
| `dev` | `supabase:start` + `web:dev` |

Guía para agentes: [`apps/web/AGENTS.md`](apps/web/AGENTS.md).
