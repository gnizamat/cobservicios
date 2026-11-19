# AGENTS.md — COBSERVICIOS `apps/web`

Guía para agentes que construyen sobre este proyecto.

## Mapa

| Ruta | Rol |
|------|-----|
| `src/app/` | Shell, providers, router, páginas de arranque |
| `src/modules/<name>/` | Dominio (api, schemas, pages, components, types) |
| `src/design-system/` | Atomic Design: tokens → atoms → molecules → organisms → templates |
| `src/components/ui/` | Primitivos shadcn (sin lógica de dominio) |
| `src/shared/` | Cliente Supabase, query client, utils, hooks compartidos |
| `supabase/` | Migrations + config; **Docker propio** vía CLI |
| `.cursor/rules/` | Reglas de arquitectura obligatorias |

La raíz `COBSERVICIOS/` solo orquesta. El Docker de SQL Server legado **no** es el backend de esta app.

## Comandos

Desde `apps/web` o vía orquestador (`npm run …` en la raíz):

```bash
npm run supabase:start   # Docker Supabase de ESTE proyecto
npm run supabase:status
npm run supabase:stop
npm run supabase:types   # regenera src/shared/types/database.ts
npm run dev
npm run build
npm run doctor:changed   # React Doctor — obligatorio tras generar/editar React
npm run doctor           # escaneo completo
npm run verify           # lint + build + doctor (gate)
```

Tras `supabase:start`, copiá keys a `.env.local` (ver `.env.example` / `supabase status -o env`).

## React Doctor (obligatorio)

Todo código React generado o editado debe pasar por React Doctor antes de cerrar la tarea:

1. `npm run doctor:changed` (o `npm run web:doctor:changed` desde la raíz).
2. Corregir errors / regresiones.
3. Skill: `.cursor/skills/react-doctor/SKILL.md` (también en `.agents/skills/`). Hook stop: `.cursor/hooks.json`.
4. Config: `doctor.config.ts`.

## Cómo agregar un módulo

1. Crear `src/modules/<name>/{api,schemas,pages,components,types}`.
2. Exportar solo la API pública desde `src/modules/<name>/index.ts`.
3. Forms → Zod en `schemas/` + RHF.
4. Data → funciones Supabase + hooks TanStack Query en `api/`.
5. UI del dominio → `components/` del módulo (compuesta con design-system).
6. Registrar rutas en `src/app/router.tsx` si aplica.

## Cómo agregar UI

1. **Token** primero si es color/spacing/type nuevo (`design-system/tokens/`).
2. Primitivo shadcn → `components/ui/` (CLI shadcn / patrón existente).
3. Exponer como **atom** en `design-system/atoms/` si es reutilizable.
4. Componer **molecules / organisms / templates** hacia arriba.
5. Los módulos **no** importan `@/components/ui` directo; usan `@/design-system`.

## Legado

Referencia de dominio: `../../COBSER_JASS_PEDREGAL/LOGICA` y SQL Server (`npm run db:legacy:*` en la raíz).  
No copiar patrones WinForms ni importar código VB.NET.
