-- Empresas --
create table empresas (
  id_empresa int PRIMARY KEY NOT NULL IDENTITY(1,1),
  -- usuario int NOT NULL,
  razon_social varchar(60),
  mail varchar(60),
  calle varchar(60),
  numero smallint,
  piso tinyint,
  departamento char,
  localidad varchar(60), -- estos datos no estan en la tabla maestra
  codigo_postal varchar(4),
  ciudad varchar(60), -- estos datos no estan en la tabla maestra
  cuit varchar(14)
);

insert into empresas (
  razon_social,
  mail,
  calle,
  numero,
  piso,
  departamento,
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
create table estados (
  id_estado int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(25)
);

insert into estados values ('Borrador'), ('Publicada'), ('Finalizada');
-- es el único estado que aparece en la db, hay que agregar más

-- Rubros --
create table rubros (
  id_rubro tinyint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(15)
);

insert into rubros values ('Vacio');

-- Grados --
create table grados (
  id_grado tinyint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  muliplicador decimal(2, 2)
)

set IDENTITY_INSERT grados ON;
insert into grados (id_grado, muliplicador) values (1, 0.10);
set IDENTITY_INSERT grados OFF;

-- Publicaciones --
create table publicaciones (
  id_publicacion int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_estado int REFERENCES estados (id_estado),
  id_grado tinyint REFERENCES grados (id_grado),
  stock smallint,
  direccion varchar(60),
  id_empresa int REFERENCES empresas (id_empresa),
  id_rubro tinyint REFERENCES rubros (id_rubro)
);

set IDENTITY_INSERT publicaciones ON;

-- podríamos remplazar el join con estados
-- dado que los que vienen estan todos en el estado 2

insert into publicaciones (
  id_publicacion,
  id_estado,
  id_grado,
  id_empresa,
  id_rubro
)
select distinct
  Espectaculo_Cod,
  E.id_estado,
  1, -- grado de 0.1
  EM.id_empresa,
  1 -- rubro vacio
from gd_esquema.Maestra M
join estados E on M.Espectaculo_Estado = E.descripcion
join empresas EM on EM.razon_social = M.Espec_Empresa_Razon_Social;

SET IDENTITY_INSERT publicaciones OFF;

-- Presentaciones --
create table presentaciones (
  id_presentacion int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_publicacion int REFERENCES publicaciones (id_publicacion),
  fecha_hora datetime,
  fecha_venc datetime
)

insert into presentaciones (
  id_publicacion,
  fecha_hora,
  fecha_venc
)
select distinct
  Espectaculo_Cod,
  Espectaculo_Fecha,
  Espectaculo_Fecha_Venc
from gd_esquema.Maestra

-- Tipos de documentos
create table tipos_de_documentos (
  id_tipo_de_documento smallint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(10)
)

SET IDENTITY_INSERT tipos_de_documentos ON;
insert into tipos_de_documentos (id_tipo_de_documento, descripcion) values (1, 'DNI'), (2, 'LC'), (3, 'LE');
SET IDENTITY_INSERT tipos_de_documentos OFF;

-- Clientes --
create table clientes (
  id_cliente int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_usuario int REFERENCES usuarios (id_usuario),
  nombre varchar(60),
  apellido varchar(60),
  id_tipo_de_documento smallint REFERENCES tipos_de_documentos,
  numero_de_documento int,
  -- cuil
  mail varchar(60),
  -- telefono ???
  calle varchar(60),
  numero smallint,
  piso tinyint,
  depto char,
  localidad varchar(60),
  codigo_postal varchar(4),
  fecha_nacimiento datetime,
  fecha_creacion datetime,
  -- tarjeta_de_credito_asociada
);

insert into clientes (
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

-- Usuarios --
create table usuarios (
  id_usuario int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  nombre_de_usuario varchar(40),
  password_hash binary(32),
  habilitado bit default 1,
  intentos_fallidos tinyint default 0
);

-- Roles --
create table roles (
  id_rol tinyint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(30)
);

set IDENTITY_INSERT roles on;
insert into roles (id_rol, descripcion) values
  (1, 'Empresa'),
  (2, 'Administrativo'),
  (3, 'Cliente');
set IDENTITY_INSERT roles off;

-- Roles x Usuario --
create table roles_por_usuario (
  id_rol_por_usuario int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_usuario int REFERENCES usuarios (id_usuario),
  id_rol tinyint REFERENCES roles (id_rol)
);

-- Medio de Pago --
create table medios_de_pago (
  id_medio_de_pago int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(20)
);

insert into medios_de_pago values ('Efectivo'), ('Tarjeta de Crédito');

-- Factura --
create table facturas (
  id_factura int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  nro_factura int unique,
  fecha datetime,
  total int,
  id_medio_de_pago int REFERENCES medios_de_pago (id_medio_de_pago),
);

insert into facturas (
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
join medios_de_pago MP on M.Forma_Pago_Desc = MP.descripcion 
where Factura_Nro is not null;

-- Tipos de ubicacion --
create table tipos_de_ubicacion (
  id_tipo_de_ubicacion smallint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(15)
);

SET IDENTITY_INSERT tipos_de_ubicacion ON;

insert into tipos_de_ubicacion (
  id_tipo_de_ubicacion,
  descripcion
)
select distinct
  Ubicacion_Tipo_Codigo,
  Ubicacion_Tipo_Descripcion
from gd_esquema.Maestra;

SET IDENTITY_INSERT tipos_de_ubicacion OFF;

-- Ubicaciones --
create table ubicaciones (
  id_ubicacion int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_publicacion int REFERENCES publicaciones (id_publicacion),
  id_tipo_de_ubicacion smallint REFERENCES tipos_de_ubicacion (id_tipo_de_ubicacion),
  fila char,
  asiento tinyint,
  precio int
)

insert into ubicaciones (
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
join tipos_de_ubicacion TU on M.Ubicacion_Tipo_Descripcion = TU.descripcion

-- Compras --
create table compras (
  id_compra int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_cliente int REFERENCES clientes (id_cliente),
  id_medio_de_pago int REFERENCES medios_de_pago (id_medio_de_pago),
  fecha datetime,
  cantidad smallint,
  id_presentacion int REFERENCES presentaciones (id_presentacion),
  id_publicacion int REFERENCES publicaciones (id_publicacion),
  -- ^^ desnormalizacion para hacer mas simple la migración y cualquier consulta futura
  id_ubicacion int REFERENCES ubicaciones (id_ubicacion),
  monto int
);

insert into compras (
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
join clientes C on C.numero_de_documento = M.Cli_Dni
join presentaciones PRS on M.Espectaculo_Cod = PRS.id_publicacion
-- ^^ nos tomamos la libertad de ver solo id de publicacion
-- porque la db hay solo una presentacion por cada publicacion
join ubicaciones U on
  M.Espectaculo_Cod = U.id_publicacion and
  M.Ubicacion_Fila = U.fila and
  M.Ubicacion_Asiento = U.asiento and
  M.Ubicacion_Precio = U.precio
where Compra_Fecha is not null and Item_Factura_Monto is null

-- -- Items --
create table items (
  id_item int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_factura int REFERENCES facturas (id_factura),
  descripcion varchar(100),
  id_compra int REFERENCES compras (id_compra),
  cantidad tinyint,
  comision decimal(6,2)
)

insert into items (
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
join facturas F on F.nro_factura = M.Factura_Nro
join compras C on
  C.id_publicacion = M.Espectaculo_Cod and
  C.monto = M.Ubicacion_Precio and
  C.fecha = Compra_Fecha and
  C.cantidad = Compra_Cantidad
join ubicaciones U on
  C.id_ubicacion = U.id_ubicacion and
  U.fila = M.Ubicacion_Fila and
  U.asiento = M.Ubicacion_Asiento
