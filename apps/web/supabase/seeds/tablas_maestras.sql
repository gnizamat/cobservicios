-- Tablas maestras de JASS Nuevo Tallan.
-- Reemplaza el catalogo de ejemplo. Se detiene si ya hay padron, facturas, pagos, medidores o asambleas.

begin;

do $$
begin
  if exists (select 1 from public.pad_predios)
     or exists (select 1 from public.pad_usuarios)
     or exists (select 1 from public.fac_facturaciones)
     or exists (select 1 from public.fac_deudas_anteriores)
     or exists (select 1 from public.cob_pagos)
     or exists (select 1 from public.hid_medidores)
     or exists (select 1 from public.hid_lecturas)
     or exists (select 1 from public.asm_asambleas)
  then
    raise exception 'Hay datos operativos que dependen del catalogo. No se reemplazan las tablas maestras.';
  end if;
end $$;

delete from public.cat_costos_tarifa_historial;
delete from public.cat_costos_tarifa;
delete from public.cat_tarifas;
delete from public.cat_calles;
delete from public.cat_sectores;
delete from public.cat_tipos_servicio;
delete from public.cat_tipos_predio;
delete from public.cat_documentos;
delete from public.hid_marcas_medidor;
delete from public.cob_cajas;
delete from public.cat_bancos;
delete from public.cat_conceptos_multa;
delete from public.cat_intereses;

-- cat_sectores
insert into public.cat_sectores (id, codigo, nombre, created_at) values ('151b38f3-aae9-42f9-bc88-aee023b092bb', 'CP-1', 'NUEVO TALLAN', '2026-11-17 21:09:59.659481+00');
insert into public.cat_sectores (id, codigo, nombre, created_at) values ('34e4bbb1-cc6b-482a-9971-448714f6a1f1', 'CP-2', 'EL TABANCO', '2026-11-17 21:09:59.676687+00');
insert into public.cat_sectores (id, codigo, nombre, created_at) values ('4f503737-efc7-4936-9aa2-05ce355459f3', 'CP-3', 'NUEVO SINCHAO CHICO', '2026-11-17 21:09:59.69368+00');
insert into public.cat_sectores (id, codigo, nombre, created_at) values ('b464b5ba-c42e-4b4c-9473-cae2ed791181', 'CP-4', 'NUEVO PIEDRAL', '2026-11-17 21:09:59.711178+00');
insert into public.cat_sectores (id, codigo, nombre, created_at) values ('07baa447-a59c-4d35-b9b3-f4103dbaf64f', 'CP-5', 'ZONA VENTURA', '2026-11-17 21:09:59.725703+00');

-- cat_calles
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('2e9d8503-4af7-42fe-bf70-183cdd2f9add', '07baa447-a59c-4d35-b9b3-f4103dbaf64f', 'Av Progreso', '', '2026-11-17 21:09:59.965115+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('e80f67e0-a397-4a66-86df-ae9fe1bd2798', '4f503737-efc7-4936-9aa2-05ce355459f3', 'Calle 17 de Abril S/N', '', '2026-11-17 21:09:59.848561+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('d8b5308e-0c40-408f-80d0-8b7f38735025', '151b38f3-aae9-42f9-bc88-aee023b092bb', 'Calle 18 de Octubre', '', '2026-11-17 21:09:59.741723+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('473da4fe-8115-4130-8706-3dbedf8a76ee', '4f503737-efc7-4936-9aa2-05ce355459f3', 'Calle 27 de Marzo S/N', '', '2026-11-17 21:09:59.865991+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('034369b2-7f28-4675-8726-e1c787217f9f', '07baa447-a59c-4d35-b9b3-f4103dbaf64f', 'Calle Comercio', '', '2026-11-17 21:09:59.981292+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('7095747a-9f8f-43c6-9671-bd542c3f8941', '4f503737-efc7-4936-9aa2-05ce355459f3', 'Calle Dos de Mayo S/N', '', '2026-11-17 21:09:59.880545+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('06289c05-125a-44f9-8ac7-6a2d0fa82549', '4f503737-efc7-4936-9aa2-05ce355459f3', 'Calle el Porvenir S/N', '', '2026-11-17 21:09:59.895107+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('6344f9a1-f5df-4512-9806-3a65888f6490', '151b38f3-aae9-42f9-bc88-aee023b092bb', 'Calle Francisco Bolognesi', '', '2026-11-17 21:09:59.753858+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('aa21fc73-bd06-4376-a2f4-32a6f8f55cf6', '34e4bbb1-cc6b-482a-9971-448714f6a1f1', 'Calle Juan Velasco - Piedral', '', '2026-11-17 21:09:59.806174+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('5783560d-d896-4680-9120-b07ecb965f88', '151b38f3-aae9-42f9-bc88-aee023b092bb', 'Calle Juan Velasco - Tabanco', '', '2026-11-17 21:09:59.764994+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('b6c1d947-186e-468f-ab6c-d4ae27469c5a', '151b38f3-aae9-42f9-bc88-aee023b092bb', 'Calle la Libertad', '', '2026-11-17 21:09:59.773711+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('0bc7c067-5737-46f1-9960-4137b566a9e4', '151b38f3-aae9-42f9-bc88-aee023b092bb', 'Calle La Victoria', '', '2026-11-17 21:09:59.78181+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('86f6bb2e-9f58-4d4d-8816-a51ad3fd39d0', '151b38f3-aae9-42f9-bc88-aee023b092bb', 'Calle Las Dunas - Tabanco', '', '2026-11-17 21:09:59.791155+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('b30982bd-94ae-40a2-8a72-6e9badd203d8', '07baa447-a59c-4d35-b9b3-f4103dbaf64f', 'Calle Las Dunas - Zona Ventura', '', '2026-11-17 21:09:59.972689+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('43a8b202-2bb6-4eb6-ab8f-3416af2fe1c2', '4f503737-efc7-4936-9aa2-05ce355459f3', 'Calle Las Margaritas S/N', '', '2026-11-17 21:09:59.909527+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('6afed4c6-ca0b-4559-a627-889cbe0fff11', '4f503737-efc7-4936-9aa2-05ce355459f3', 'Calle las Mercedes S/N', '', '2026-11-17 21:09:59.925322+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('13ba072b-b543-4d67-a7a9-ebe226e7e216', '4f503737-efc7-4936-9aa2-05ce355459f3', 'Calle Los Claveles S/N', '', '2026-11-17 21:09:59.938431+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('77ed4bb9-5025-4efc-b773-73f3ca5e9632', '151b38f3-aae9-42f9-bc88-aee023b092bb', 'Calle Panamericana', '', '2026-11-17 21:09:59.798534+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('c0ca809f-18be-461f-a093-6fb7c4984283', '34e4bbb1-cc6b-482a-9971-448714f6a1f1', 'Calle primero de Mayo S/N', '', '2026-11-17 21:09:59.816836+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('9cf45c50-e2b5-416e-a26b-bb4c8ca33458', '07baa447-a59c-4d35-b9b3-f4103dbaf64f', 'Calle San Jose', '', '2026-11-17 21:09:59.94862+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('034f7998-e4dd-4edd-a1c6-2d8297f1ae92', '07baa447-a59c-4d35-b9b3-f4103dbaf64f', 'Calle Santa Isabel', '', '2026-11-17 21:09:59.956851+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('84a3526d-41a5-4128-87e7-359289c5f3f8', '07baa447-a59c-4d35-b9b3-f4103dbaf64f', 'Calle Trasversal San Pablo', '', '2026-11-17 21:09:59.988785+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('42b4a522-fb2f-4202-a910-3b57873d9139', '34e4bbb1-cc6b-482a-9971-448714f6a1f1', 'Calle Virgen de las Mercedes S/N', '', '2026-11-17 21:09:59.831168+00');
insert into public.cat_calles (id, sector_id, nombre, referencia, created_at) values ('433f2842-cb0e-4413-8580-0ccf6472ce91', '07baa447-a59c-4d35-b9b3-f4103dbaf64f', 'Usuarios al lado de Panamericana', '', '2026-11-17 21:09:59.99691+00');

-- cat_tipos_predio
insert into public.cat_tipos_predio (id, codigo, nombre) values ('13693896-84da-4770-a92c-16bf97d9cdd1', 'COM', 'Comercial');
insert into public.cat_tipos_predio (id, codigo, nombre) values ('f912f706-2671-4a1c-87d8-ce73992b1415', 'DOM', 'Doméstico');
insert into public.cat_tipos_predio (id, codigo, nombre) values ('16910ec4-c558-4caa-8a10-edae63a8ad66', 'EST', 'Estatal');
insert into public.cat_tipos_predio (id, codigo, nombre) values ('d3fcb798-7c5b-4a4f-9c32-f524b7b833b8', 'IND', 'Industrial');

-- cat_tipos_servicio
insert into public.cat_tipos_servicio (id, codigo, nombre, categoria, estado, created_at, updated_at) values ('46e5536a-44aa-4cad-8eec-bfb2c9169bc0', 'AGUA', 'Agua potable', 'fijo'::public.categoria_servicio, 'activo'::public.estado_registro, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_tipos_servicio (id, codigo, nombre, categoria, estado, created_at, updated_at) values ('d8bad556-bb94-460a-83cc-7dfabc7bb540', 'ALC', 'Alcantarillado', 'alcantarillado'::public.categoria_servicio, 'activo'::public.estado_registro, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:49:53.387166+00');
insert into public.cat_tipos_servicio (id, codigo, nombre, categoria, estado, created_at, updated_at) values ('ddb220a2-5234-4c06-822d-9becc8fdb8b2', 'CONEX', 'Conexión domiciliaria', 'unico'::public.categoria_servicio, 'activo'::public.estado_registro, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_tipos_servicio (id, codigo, nombre, categoria, estado, created_at, updated_at) values ('382df9c4-5526-437f-9da5-d847d2fc5c13', 'CUOTA', 'Cuota familiar', 'fijo'::public.categoria_servicio, 'activo'::public.estado_registro, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_tipos_servicio (id, codigo, nombre, categoria, estado, created_at, updated_at) values ('781080ff-dab6-45b4-a63a-2c2c3a32c8d5', 'MED', 'Mantenimiento de medidor', 'medidor'::public.categoria_servicio, 'activo'::public.estado_registro, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_tipos_servicio (id, codigo, nombre, categoria, estado, created_at, updated_at) values ('c359d6cd-04a4-4bcf-8882-a61c1621edb4', 'VOL', 'Agua por volumen', 'volumen'::public.categoria_servicio, 'activo'::public.estado_registro, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');

-- cat_tarifas
insert into public.cat_tarifas (id, anio, nombre, modalidad, unidad_recaudacion, activa, created_at, updated_at) values ('4116f657-be80-4190-b420-a37183fc814c', 2024, 'Tarifa 2024', 'Contraentrega', 'Soles por metro cúbico (S/. * m3)', 'f', '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_tarifas (id, anio, nombre, modalidad, unidad_recaudacion, activa, created_at, updated_at) values ('0bdf164a-f1e7-4565-b7a5-23c806c795f9', 2025, 'Tarifa 2025', 'Contraentrega', 'Soles por metro cúbico (S/. * m3)', 'f', '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_tarifas (id, anio, nombre, modalidad, unidad_recaudacion, activa, created_at, updated_at) values ('35264729-d1ef-479b-b7ff-dd206e34190b', 2026, 'Tarifa 2026', 'Contraentrega', 'Soles por metro cúbico (S/. * m3)', 't', '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');

-- cat_costos_tarifa
insert into public.cat_costos_tarifa (id, tarifa_id, tipo_servicio_id, valor, monto, created_at, updated_at) values ('2b2508f3-ef80-437e-9f5d-fff6f965e33a', '35264729-d1ef-479b-b7ff-dd206e34190b', '46e5536a-44aa-4cad-8eec-bfb2c9169bc0', 0.0000, 15.00, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_costos_tarifa (id, tarifa_id, tipo_servicio_id, valor, monto, created_at, updated_at) values ('5ded6c85-d9df-4a0d-bbd6-5ae428ae41b7', '0bdf164a-f1e7-4565-b7a5-23c806c795f9', '46e5536a-44aa-4cad-8eec-bfb2c9169bc0', 0.0000, 12.00, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_costos_tarifa (id, tarifa_id, tipo_servicio_id, valor, monto, created_at, updated_at) values ('cfb12f6a-5119-4c51-965c-8ad172cf146a', '35264729-d1ef-479b-b7ff-dd206e34190b', '382df9c4-5526-437f-9da5-d847d2fc5c13', 0.0000, 5.00, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_costos_tarifa (id, tarifa_id, tipo_servicio_id, valor, monto, created_at, updated_at) values ('17828b0d-a364-4138-9534-69fee77c58a7', '0bdf164a-f1e7-4565-b7a5-23c806c795f9', '382df9c4-5526-437f-9da5-d847d2fc5c13', 0.0000, 4.00, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_costos_tarifa (id, tarifa_id, tipo_servicio_id, valor, monto, created_at, updated_at) values ('00bc213a-aeaa-45ee-8057-ad73546f0284', '35264729-d1ef-479b-b7ff-dd206e34190b', 'ddb220a2-5234-4c06-822d-9becc8fdb8b2', 0.0000, 150.00, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_costos_tarifa (id, tarifa_id, tipo_servicio_id, valor, monto, created_at, updated_at) values ('2fd5d943-1224-43c5-a257-dabd2dd6eecf', '0bdf164a-f1e7-4565-b7a5-23c806c795f9', 'ddb220a2-5234-4c06-822d-9becc8fdb8b2', 0.0000, 120.00, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_costos_tarifa (id, tarifa_id, tipo_servicio_id, valor, monto, created_at, updated_at) values ('ecde2cbb-e676-421a-8de3-4e243e8068a8', '0bdf164a-f1e7-4565-b7a5-23c806c795f9', 'c359d6cd-04a4-4bcf-8882-a61c1621edb4', 1.0000, 0.00, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_costos_tarifa (id, tarifa_id, tipo_servicio_id, valor, monto, created_at, updated_at) values ('710e33ea-8c87-4abc-9a96-cf5c42102093', '35264729-d1ef-479b-b7ff-dd206e34190b', 'd8bad556-bb94-460a-83cc-7dfabc7bb540', 0.0000, 8.00, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_costos_tarifa (id, tarifa_id, tipo_servicio_id, valor, monto, created_at, updated_at) values ('5219c436-7417-49fc-a95f-4bd283133ebc', '0bdf164a-f1e7-4565-b7a5-23c806c795f9', 'd8bad556-bb94-460a-83cc-7dfabc7bb540', 0.0000, 6.00, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_costos_tarifa (id, tarifa_id, tipo_servicio_id, valor, monto, created_at, updated_at) values ('fa279462-11c0-4a73-8aa9-f08e267119a2', '35264729-d1ef-479b-b7ff-dd206e34190b', '781080ff-dab6-45b4-a63a-2c2c3a32c8d5', 0.0000, 3.50, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_costos_tarifa (id, tarifa_id, tipo_servicio_id, valor, monto, created_at, updated_at) values ('f240c322-ef2d-403b-918a-1b0125f6aba4', '0bdf164a-f1e7-4565-b7a5-23c806c795f9', '781080ff-dab6-45b4-a63a-2c2c3a32c8d5', 0.0000, 2.50, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:29:48.150995+00');
insert into public.cat_costos_tarifa (id, tarifa_id, tipo_servicio_id, valor, monto, created_at, updated_at) values ('4613d17e-a521-448e-9686-3d45a8b291e8', '35264729-d1ef-479b-b7ff-dd206e34190b', 'c359d6cd-04a4-4bcf-8882-a61c1621edb4', 1.2000, 0.00, '2026-11-04 02:29:48.150995+00', '2026-11-04 02:54:27.459428+00');

-- cat_costos_tarifa_historial
insert into public.cat_costos_tarifa_historial (id, costo_id, tarifa_id, tipo_servicio_id, monto_anterior, monto_nuevo, valor_anterior, valor_nuevo, created_at, created_by) values ('f86e433f-b8f4-4977-9dac-3c6f4af86d07', '4613d17e-a521-448e-9686-3d45a8b291e8', '35264729-d1ef-479b-b7ff-dd206e34190b', 'c359d6cd-04a4-4bcf-8882-a61c1621edb4', 0.00, 1.00, 1.2000, 1.2000, '2026-11-04 02:53:45.865386+00', null);
insert into public.cat_costos_tarifa_historial (id, costo_id, tarifa_id, tipo_servicio_id, monto_anterior, monto_nuevo, valor_anterior, valor_nuevo, created_at, created_by) values ('9e666103-c1e3-48ad-abd2-d537766cbe02', '4613d17e-a521-448e-9686-3d45a8b291e8', '35264729-d1ef-479b-b7ff-dd206e34190b', 'c359d6cd-04a4-4bcf-8882-a61c1621edb4', 1.00, 0.00, 1.2000, 1.2000, '2026-11-04 02:54:27.459428+00', null);

-- cat_documentos
insert into public.cat_documentos (id, codigo, nombre, estado, created_at, updated_at) values ('7c9a644c-7732-4e7f-87c4-b47eca7f5850', 'FAC', 'Factura', 'activo'::public.estado_registro, '2026-11-18 15:37:17.279614+00', '2026-11-18 15:37:17.279614+00');
insert into public.cat_documentos (id, codigo, nombre, estado, created_at, updated_at) values ('58ddcfcb-68cd-40ba-85f8-55bcc0447761', 'REC', 'Recibo', 'activo'::public.estado_registro, '2026-11-18 15:37:17.279614+00', '2026-11-18 15:37:17.279614+00');

-- cat_bancos
-- sin registros

-- cat_conceptos_multa
-- sin registros

-- cat_intereses
-- sin registros

-- hid_marcas_medidor
insert into public.hid_marcas_medidor (id, nombre, created_at) values ('4976bd1b-03a4-45bf-ac64-970ac72e1cdd', 'Actaris', '2026-11-04 03:58:47.686028+00');
insert into public.hid_marcas_medidor (id, nombre, created_at) values ('90483740-d631-424e-8ea4-29eb11363767', 'Arad', '2026-11-04 03:58:47.686028+00');
insert into public.hid_marcas_medidor (id, nombre, created_at) values ('3dc535f0-3175-49f5-8db6-bbe0bc81f23c', 'Badger', '2026-11-04 03:58:47.686028+00');
insert into public.hid_marcas_medidor (id, nombre, created_at) values ('ce7cd4f3-1e18-477e-8df2-8faaa5b4db0f', 'Diehl', '2026-11-04 03:58:47.686028+00');
insert into public.hid_marcas_medidor (id, nombre, created_at) values ('5497ec91-3b08-4f48-933a-53c6596c1d4b', 'Dorot', '2026-11-04 03:58:47.686028+00');
insert into public.hid_marcas_medidor (id, nombre, created_at) values ('01f4842c-257d-4013-8296-03a675347bb1', 'Elster', '2026-11-04 03:58:47.686028+00');
insert into public.hid_marcas_medidor (id, nombre, created_at) values ('fa41cbdc-1085-4c87-8ff3-cb398f258956', 'Itron', '2026-11-04 03:58:47.686028+00');
insert into public.hid_marcas_medidor (id, nombre, created_at) values ('75b4e7fc-b605-4fea-a7aa-7044f3f52842', 'Ningbo', '2026-11-04 03:58:47.686028+00');
insert into public.hid_marcas_medidor (id, nombre, created_at) values ('b25b805b-41d8-4543-b58c-f8d74ca3a176', 'Sensus', '2026-11-04 03:58:47.686028+00');
insert into public.hid_marcas_medidor (id, nombre, created_at) values ('affba779-58ef-45dd-82e9-26d17517d16f', 'Zenner', '2026-11-04 03:58:47.686028+00');

-- cob_cajas
insert into public.cob_cajas (id, nombre, activa, created_at) values ('c54566d5-6d57-4275-be19-699330027e3b', 'Caja principal', 't', '2026-11-18 13:48:54.163254+00');

-- org_jass
insert into public.org_jass (id, nombre, abreviatura, celular, direccion, email, logo_path, latitud, longitud, created_at, updated_at) values (true, 'Junta Administradora de Servicios de Nuevo Tallan', 'JASS NUEVO TALLAN', '', 'Pedregal', '', '', -5.194700, -80.616500, '2026-11-18 01:43:02.249727+00', '2026-11-18 01:51:12.244957+00') on conflict (id) do update set nombre = excluded.nombre, abreviatura = excluded.abreviatura, celular = excluded.celular, direccion = excluded.direccion, email = excluded.email, logo_path = excluded.logo_path, latitud = excluded.latitud, longitud = excluded.longitud;

-- app_meta
insert into public.app_meta (key, value, updated_at) values ('app', 'cobservicios-web', '2026-11-02 03:02:14.839553+00') on conflict (key) do update set value = excluded.value;
insert into public.app_meta (key, value, updated_at) values ('marca_nombre', 'COBSERVICIOS', '2026-11-18 14:39:41.762312+00') on conflict (key) do update set value = excluded.value;
commit;
