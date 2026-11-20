-- La caja queda a cargo de un usuario de acceso al sistema.

alter table public.cob_cajas
  add column if not exists usuario_id uuid references public.sys_usuario_perfil (user_id) on delete set null;

comment on column public.cob_cajas.usuario_id is
  'Usuario del sistema responsable de la caja.';

create index if not exists cob_cajas_usuario_id_idx
  on public.cob_cajas (usuario_id);

notify pgrst, 'reload schema';
