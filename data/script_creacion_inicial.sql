GO -- Schema
create schema PEAKY_BLINDERS;

GO -- Creación tablas y migracion
-- Usuarios --
create table PEAKY_BLINDERS.usuarios (
  id_usuario int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  nombre_de_usuario varchar(40),
  password_hash binary(32),
  habilitado bit default 1,
  intentos_fallidos tinyint default 0,
  nuevo bit default 0,
);

-- Empresas --
create table PEAKY_BLINDERS.empresas (
  id_empresa int PRIMARY KEY NOT NULL IDENTITY(1,1),
  id_usuario int REFERENCES PEAKY_BLINDERS.usuarios (id_usuario),
  razon_social varchar(60),
  mail varchar(60),
  telefono varchar(10),
  calle varchar(60),
  numero smallint,
  piso tinyint,
  depto char,
  localidad varchar(60), -- estos datos no estan en la tabla maestra
  codigo_postal varchar(4),
  ciudad varchar(60), -- estos datos no estan en la tabla maestra
  cuit varchar(14)
);

insert into PEAKY_BLINDERS.empresas (
  razon_social,
  mail,
  calle,
  numero,
  piso,
  depto,
  codigo_postal,
  cuit
)
select distinct
  Espec_Empresa_Razon_Social,
  Espec_Empresa_Mail,
  Espec_Empresa_Dom_Calle,
  Espec_Empresa_Nro_Calle,
  Espec_Empresa_Piso,
  Espec_Empresa_Depto,
  Espec_Empresa_Cod_Postal,
  Espec_Empresa_Cuit
from gd_esquema.Maestra;

-- Estados --
create table PEAKY_BLINDERS.estados (
  id_estado int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(25)
);

insert into PEAKY_BLINDERS.estados values ('Borrador'), ('Publicada'), ('Finalizada');

-- Rubros --
create table PEAKY_BLINDERS.rubros (
  id_rubro tinyint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(15)
);

insert into PEAKY_BLINDERS.rubros values ('Vacio');

-- Grados --
create table PEAKY_BLINDERS.grados (
  id_grado tinyint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  muliplicador decimal(2, 2)
)

set IDENTITY_INSERT PEAKY_BLINDERS.grados ON;
insert into PEAKY_BLINDERS.grados (id_grado, muliplicador) values (1, 0.10);
set IDENTITY_INSERT PEAKY_BLINDERS.grados OFF;

-- Publicaciones --
create table PEAKY_BLINDERS.publicaciones (
  id_publicacion int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(200),
  stock smallint,
  fecha_publicacion datetime,
  id_rubro tinyint REFERENCES PEAKY_BLINDERS.rubros (id_rubro),
  calle varchar(50),
  numero smallint,
  codigo_postal varchar(4),
  localidad varchar(60),
  id_grado tinyint REFERENCES PEAKY_BLINDERS.grados (id_grado),
  id_empresa int REFERENCES PEAKY_BLINDERS.empresas (id_empresa),
  id_estado int REFERENCES PEAKY_BLINDERS.estados (id_estado)
);

set IDENTITY_INSERT PEAKY_BLINDERS.publicaciones ON;

insert into PEAKY_BLINDERS.publicaciones (
  id_publicacion,
  descripcion,
  fecha_publicacion,
  id_estado,
  id_grado,
  id_empresa,
  id_rubro
)
select distinct
  Espectaculo_Cod,
  Espectaculo_Descripcion,
  Espectaculo_Fecha,
  2, -- estado "Publicada"
  1, -- grado de 0.1
  EM.id_empresa,
  1 -- rubro vacio
from gd_esquema.Maestra M
join PEAKY_BLINDERS.empresas EM on EM.razon_social = M.Espec_Empresa_Razon_Social;

SET IDENTITY_INSERT PEAKY_BLINDERS.publicaciones OFF;

-- Presentaciones --
create table PEAKY_BLINDERS.presentaciones (
  id_presentacion int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_publicacion int REFERENCES PEAKY_BLINDERS.publicaciones (id_publicacion),
  fecha_presentacion datetime,
)

insert into PEAKY_BLINDERS.presentaciones (
  id_publicacion,
  fecha_presentacion
)
select distinct
  Espectaculo_Cod,
  Espectaculo_Fecha_Venc
from gd_esquema.Maestra

-- Tipos de documentos
create table PEAKY_BLINDERS.tipos_de_documento (
  id_tipo_de_documento tinyint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(10)
)

SET IDENTITY_INSERT PEAKY_BLINDERS.tipos_de_documento ON;
insert into PEAKY_BLINDERS.tipos_de_documento (id_tipo_de_documento, descripcion) values (1, 'DNI'), (2, 'LC'), (3, 'LE'), (4, 'Pasaporte');
SET IDENTITY_INSERT PEAKY_BLINDERS.tipos_de_documento OFF;

-- Roles --
create table PEAKY_BLINDERS.roles (
  id_rol tinyint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(30),
  habilitado bit default 1
);

set IDENTITY_INSERT PEAKY_BLINDERS.roles on;
insert into PEAKY_BLINDERS.roles (id_rol, descripcion, habilitado) values
  (1, 'Administrador', 1),
  (2, 'Cliente', 1),
  (3, 'Empresa', 1);
set IDENTITY_INSERT PEAKY_BLINDERS.roles off;

-- Roles x Usuario --
create table PEAKY_BLINDERS.roles_por_usuario (
  id_rol_por_usuario int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_usuario int REFERENCES PEAKY_BLINDERS.usuarios (id_usuario),
  id_rol tinyint REFERENCES PEAKY_BLINDERS.roles (id_rol)
);

-- Funcionalidades --
create table PEAKY_BLINDERS.funcionalidades (
  id_funcionalidad tinyint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(50)
)

set IDENTITY_INSERT PEAKY_BLINDERS.funcionalidades on;
insert into PEAKY_BLINDERS.funcionalidades (id_funcionalidad, descripcion) values
  (1, 'ABM de Rol'),
  (2, 'ABM de Cliente'),
  (3, 'ABM de Empresa de espectáculos'),
  (4, 'ABM de Categoría'),
  (5, 'ABM grado de publicación'),
  (6, 'Generar Publicación'),
  (7, 'Editar Publicacion'),
  (8, 'Comprar'),
  (9, 'Historial del cliente'),
  (10, 'Canje y administración de puntos'),
  (11, 'Generar Pago de comisiones'),
  (12, 'Listado Estadístico');
set IDENTITY_INSERT PEAKY_BLINDERS.funcionalidades off;

-- Funcionalidades x Rol
create table PEAKY_BLINDERS.funcionalidades_por_rol (
  id_funcionalidad_por_rol smallint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_rol tinyint REFERENCES PEAKY_BLINDERS.roles (id_rol),
  id_funcionalidad tinyint REFERENCES PEAKY_BLINDERS.funcionalidades (id_funcionalidad)
)

insert into PEAKY_BLINDERS.funcionalidades_por_rol (id_rol, id_funcionalidad) values
  (1, 1), (1, 2), (1, 3), (1, 4), (1, 5), (1, 11), (1, 12),
  (2, 8), (2, 9), (2, 10),
  (3, 6), (3, 7);

-- Clientes --
create table PEAKY_BLINDERS.clientes (
  id_cliente int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_usuario int REFERENCES PEAKY_BLINDERS.usuarios (id_usuario),
  nombre varchar(60),
  apellido varchar(60),
  id_tipo_de_documento tinyint REFERENCES PEAKY_BLINDERS.tipos_de_documento,
  numero_de_documento int,
  cuil varchar(14),
  mail varchar(60),
  telefono varchar(10),
  calle varchar(60),
  numero smallint,
  piso tinyint,
  depto char,
  localidad varchar(60),
  codigo_postal varchar(4),
  fecha_nacimiento datetime,
  fecha_creacion datetime,
  tarjeta_de_credito_asociada varchar(16)
);

insert into PEAKY_BLINDERS.clientes (
  nombre,
  apellido,
  numero_de_documento,
  id_tipo_de_documento,
  mail,
  calle,
  numero,
  piso,
  depto,
  codigo_postal,
  fecha_nacimiento
)
select distinct
  Cli_Nombre,
  Cli_Apeliido,
  Cli_Dni,
  1,
  Cli_Mail,
  Cli_Dom_Calle,
  Cli_Nro_Calle,
  Cli_Piso,
  Cli_Depto,
  Cli_Cod_Postal,
  Cli_Fecha_Nac
from gd_esquema.Maestra
where Cli_Dni is not null;

-- Movimientos de puntos
create table PEAKY_BLINDERS.movimientos_de_puntos (
  id_movimiento int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_cliente int REFERENCES PEAKY_BLINDERS.clientes (id_cliente),
  variacion int,
  fecha datetime
)

-- Medio de Pago --
create table PEAKY_BLINDERS.medios_de_pago (
  id_medio_de_pago tinyint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(20)
);

insert into PEAKY_BLINDERS.medios_de_pago values ('Efectivo'), ('Tarjeta de Crédito');

-- Factura --
create table PEAKY_BLINDERS.facturas (
  id_factura int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  nro_factura int unique,
  fecha datetime,
  total int,
  id_medio_de_pago tinyint REFERENCES PEAKY_BLINDERS.medios_de_pago (id_medio_de_pago),
);

insert into PEAKY_BLINDERS.facturas (
  nro_factura,
  fecha,
  total,
  id_medio_de_pago
)
select distinct
  Factura_Nro,
  Factura_Fecha,
  Factura_Total,
  id_medio_de_pago
from gd_esquema.Maestra M
join PEAKY_BLINDERS.medios_de_pago MP on M.Forma_Pago_Desc = MP.descripcion 
where Factura_Nro is not null;

-- Tipos de ubicacion --
create table PEAKY_BLINDERS.tipos_de_ubicacion (
  id_tipo_de_ubicacion smallint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(15)
);

SET IDENTITY_INSERT PEAKY_BLINDERS.tipos_de_ubicacion ON;

insert into PEAKY_BLINDERS.tipos_de_ubicacion (
  id_tipo_de_ubicacion,
  descripcion
)
select distinct
  Ubicacion_Tipo_Codigo,
  Ubicacion_Tipo_Descripcion
from gd_esquema.Maestra;

SET IDENTITY_INSERT PEAKY_BLINDERS.tipos_de_ubicacion OFF;

-- Ubicaciones --
create table PEAKY_BLINDERS.ubicaciones (
  id_ubicacion int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_publicacion int REFERENCES PEAKY_BLINDERS.publicaciones (id_publicacion),
  id_tipo_de_ubicacion smallint REFERENCES PEAKY_BLINDERS.tipos_de_ubicacion (id_tipo_de_ubicacion),
  fila char,
  asiento tinyint,
  precio int
)

insert into PEAKY_BLINDERS.ubicaciones (
  id_publicacion,
  id_tipo_de_ubicacion,
  fila,
  asiento,
  precio
)
select distinct
  M.Espectaculo_Cod,
  TU.id_tipo_de_ubicacion,
  M.Ubicacion_Fila,
  M.Ubicacion_Asiento,
  M.Ubicacion_Precio
from gd_esquema.Maestra M
join PEAKY_BLINDERS.tipos_de_ubicacion TU on M.Ubicacion_Tipo_Descripcion = TU.descripcion

-- Compras --
create table PEAKY_BLINDERS.compras (
  id_compra int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_cliente int REFERENCES PEAKY_BLINDERS.clientes (id_cliente),
  id_medio_de_pago tinyint REFERENCES PEAKY_BLINDERS.medios_de_pago (id_medio_de_pago),
  fecha datetime,
  cantidad tinyint,
  id_presentacion int REFERENCES PEAKY_BLINDERS.presentaciones (id_presentacion),
  id_publicacion int REFERENCES PEAKY_BLINDERS.publicaciones (id_publicacion),
  -- ^^ desnormalizacion para hacer mas simple la migración y cualquier consulta futura
  id_ubicacion int REFERENCES PEAKY_BLINDERS.ubicaciones (id_ubicacion),
  monto int
);

insert into PEAKY_BLINDERS.compras (
  id_cliente,
  id_medio_de_pago,
  fecha,
  cantidad,
  id_presentacion,
  id_publicacion,
  id_ubicacion,
  monto
)
select distinct
  C.id_cliente,
  1, -- todo lo que venia de la base era en efectivo
  M.Compra_Fecha,
  M.Compra_Cantidad,
  PRS.id_presentacion,
  M.Espectaculo_Cod,
  U.id_ubicacion,
  M.Ubicacion_Precio
from gd_esquema.Maestra M
join PEAKY_BLINDERS.clientes C on C.numero_de_documento = M.Cli_Dni
join PEAKY_BLINDERS.presentaciones PRS on M.Espectaculo_Cod = PRS.id_publicacion
-- ^^ nos tomamos la libertad de ver solo id de publicacion
-- porque la db hay solo una presentacion por cada publicacion
join PEAKY_BLINDERS.ubicaciones U on
  M.Espectaculo_Cod = U.id_publicacion and
  M.Ubicacion_Fila = U.fila and
  M.Ubicacion_Asiento = U.asiento and
  M.Ubicacion_Precio = U.precio
where Compra_Fecha is not null and Item_Factura_Monto is null

-- -- Items --
create table PEAKY_BLINDERS.items (
  id_item int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_factura int REFERENCES PEAKY_BLINDERS.facturas (id_factura),
  descripcion varchar(100),
  id_compra int REFERENCES PEAKY_BLINDERS.compras (id_compra),
  cantidad tinyint,
  comision decimal(6,2)
)

insert into PEAKY_BLINDERS.items (
  id_factura,
  descripcion,
  id_compra,
  cantidad,
  comision
)
select
  F.id_factura,
  M.Item_Factura_Descripcion,
  C.id_compra,
  M.Item_Factura_Cantidad,
  M.Item_Factura_Monto
from gd_esquema.Maestra M
join PEAKY_BLINDERS.facturas F on F.nro_factura = M.Factura_Nro
join PEAKY_BLINDERS.compras C on
  C.id_publicacion = M.Espectaculo_Cod and
  C.monto = M.Ubicacion_Precio and
  C.fecha = Compra_Fecha and
  C.cantidad = Compra_Cantidad
join PEAKY_BLINDERS.ubicaciones U on
  C.id_ubicacion = U.id_ubicacion and
  U.fila = M.Ubicacion_Fila and
  U.asiento = M.Ubicacion_Asiento
