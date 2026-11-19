---
name: Harness apps web
overview: Scaffold del proyecto React/Vite en `apps/web` (con su propio Docker Supabase y harness de IA) y un orquestador en la raíz `COBSERVICIOS` que solo coordina scripts y el Docker legado SQL Server.
todos:
  - id: orchestrator-root
    content: Crear package.json raíz, docker-compose SQL Server (solo legado), scripts restore BAK y README orquestador
    status: pending
  - id: scaffold-web
    content: "Scaffold apps/web: Vite React TS, Tailwind, shadcn, lucide, RHF, Zod, TanStack Query, Supabase client"
    status: pending
  - id: architecture-skeleton
    content: Crear árbol modules/ + design-system/tokens→templates + shared/ + shell app mínimo
    status: pending
  - id: supabase-local
    content: Docker propio de apps/web via supabase init/start; .env.example; scripts raíz solo delegan a apps/web
    status: pending
  - id: ai-harness
    content: Escribir AGENTS.md y .cursor/rules/*.mdc (architecture, design-system, modules, forms-data, supabase, legacy)
    status: pending
isProject: false
---

# Plan: Orquestador + apps/web + harness IA

## Contexto

- Legado intacto: `COBSER_JASS_PEDREGAL/` (VB.NET) y `DB_JASS_PEDREGAL.BAK` (SQL Server).
- El producto nuevo vive en **`apps/web`**.
- La raíz `COBSERVICIOS` solo orquesta. No es el app React.
- **Dos Docker independientes (regla dura):**
  - **`apps/web` → Docker propio (Supabase):** `supabase start` anclado a `apps/web/supabase/` (Postgres, Auth, Storage, Studio). Backend real de la app.
  - **Raíz → Docker solo legado:** SQL Server para el `.BAK`. No es el backend de `apps/web`.
- El orquestador no mezcla stacks: `supabase:*` delega a `apps/web`; `db:legacy:*` usa el compose raíz.

## Estructura objetivo

```text
COBSERVICIOS/                          # orquestador (NO dueño del Docker de la app)
  package.json                         # scripts que delegan
  docker-compose.yml                   # SOLO SQL Server (legado / BAK)
  docker/sqlserver/restore/
  apps/
    web/                               # React + dueño de su Docker
      package.json
      vite.config.ts
      src/...
      supabase/                        # `supabase start` = Docker de la app
      .cursor/rules/
      AGENTS.md
      .env.example
  COBSER_JASS_PEDREGAL/
  DB_JASS_PEDREGAL.BAK
  README.md
```

```mermaid
flowchart TB
  orchestrator["COBSERVICIOS orquestador"]
  web["apps/web React Vite"]
  supabaseDocker["Docker de apps/web Supabase"]
  sqlserver["Docker raíz SQL Server BAK"]
  legacy["COBSER_JASS_PEDREGAL referencia"]

  orchestrator -->|"npm run web:dev"| web
  orchestrator -->|"npm run supabase:start delega"| web
  web -->|"supabase start"| supabaseDocker
  web -->|"@supabase/supabase-js"| supabaseDocker
  orchestrator -->|"npm run db:legacy:up"| sqlserver
  sqlserver -.->|"inspección esquema/datos"| web
  legacy -.->|"dominio módulos"| web
```

## Stack en apps/web

- React + TypeScript + Vite, Tailwind, shadcn/ui, Lucide, RHF, Zod, TanStack Query, `@supabase/supabase-js`

### Arquitectura modular + Atomic Design

```text
apps/web/src/
  app/
  modules/<name>/{api,schemas,pages,components,types,index.ts}
  design-system/{tokens,atoms,molecules,organisms,templates}
  shared/lib/
  components/ui/   # solo shadcn generado
```

## Orquestador

- `web:*` → `apps/web`
- `supabase:*` → `cd apps/web && npx supabase …` (Docker de la app)
- `db:legacy:*` → compose raíz SQL Server
- Compose raíz **no** incluye Postgres/Auth/Studio

## Harness IA en apps/web

AGENTS.md + `.cursor/rules/` (architecture, design-system, modules, forms-data, supabase, legacy-reference).

## Alcance de esta fase

Scaffold + design-system mínimo + Docker propio Supabase en apps/web + SQL Server legado en raíz + harness. Sin migración BAK→Postgres ni pantallas de negocio.
