-- Las políticas RLS ya dejaban pasar a authenticated, pero en el proyecto
-- alojado faltaba el GRANT de tabla. Postgres responde "permission denied"
-- antes de evaluar las políticas.

do $$
declare
  tabla text;
begin
  for tabla in
    select distinct tablename
    from pg_policies
    where schemaname = 'public'
      and 'authenticated' = any (roles)
      and cmd in ('SELECT', 'ALL')
  loop
    execute format('grant select on public.%I to authenticated', tabla);
  end loop;

  for tabla in
    select distinct tablename
    from pg_policies
    where schemaname = 'public'
      and 'anon' = any (roles)
      and cmd in ('SELECT', 'ALL')
  loop
    execute format('grant select on public.%I to anon', tabla);
  end loop;

  for tabla in
    select distinct tablename
    from pg_policies
    where schemaname = 'public'
      and 'authenticated' = any (roles)
      and cmd in ('INSERT', 'ALL')
  loop
    execute format('grant insert on public.%I to authenticated', tabla);
  end loop;

  for tabla in
    select distinct tablename
    from pg_policies
    where schemaname = 'public'
      and 'authenticated' = any (roles)
      and cmd in ('UPDATE', 'ALL')
  loop
    execute format('grant update on public.%I to authenticated', tabla);
  end loop;

  for tabla in
    select distinct tablename
    from pg_policies
    where schemaname = 'public'
      and 'authenticated' = any (roles)
      and cmd in ('DELETE', 'ALL')
  loop
    execute format('grant delete on public.%I to authenticated', tabla);
  end loop;
end $$;

grant select, insert, update, delete on all tables in schema public to service_role;
grant usage, select on all sequences in schema public to authenticated, service_role;

alter default privileges in schema public
  grant select, insert, update, delete on tables to authenticated, service_role;

notify pgrst, 'reload schema';
