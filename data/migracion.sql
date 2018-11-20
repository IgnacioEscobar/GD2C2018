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
  localidad,
  codigo_postal,
  ciudad,
  cuit
)
select distinct
  Espec_Empresa_Razon_Social as razon_social,
  Espec_Empresa_Mail as mail,
  Espec_Empresa_Dom_Calle as calle,
  Espec_Empresa_Nro_Calle as numero,
  Espec_Empresa_Piso as piso,
  Espec_Empresa_Depto as departamento,
  Espec_Empresa_Cod_Postal as codigo_postal,
  Espec_Empresa_Cuit as cuit
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

-- Publicaciones --
create table publicaiones (
  id_publicacion int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_estado int REFERENCES estados (id_estado),
  -- id_grado int REFERENCES grados (id_grado),
  -- stock smallint,
  -- direccion varchar(60),
  id_empresa int REFERENCES empresas (id_empresa),
  id_rubro int REFERENCES rubros (id_rubro)
);

set IDENTITY_INSERT publicaiones ON;

-- podríamos remplazar el join con estados
-- dado que los que vienen estan todos en el estado 2

insert into publicaiones (
  id_publicacion,
  id_estado,
  id_empresa,
  id_rubro
)
select distinct
  Espectaculo_Cod,
  E.id_estado,
  EM.id_empresa,
  1 -- rubro vacio
from gd_esquema.Maestra M
join estados E on M.Espectaculo_Estado = E.descripcion
join empresas EM on EM.razon_social = M.Espec_Empresa_Razon_Social;

SET IDENTITY_INSERT publicaiones OFF;

-- Presentaciones --
create table presentaciones (
  id_presentacion int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_publicacion int REFERENCES publicaiones (id_publicacion),
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
insert into tipos_de_documentos values (1, 'DNI'), (2, 'LC'), (3, 'LE');
SET IDENTITY_INSERT tipos_de_documentos OFF;

-- Clientes --
create table clientes (
  id_cliente int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  -- id_usuario int REFERENCES usuarios
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

-- -- Items --
-- create table items (
--   id_item int PRIMARY KEY NOT NULL IDENTITY(1, 1),
--   id_factura int REFERENCES facturas (id_factura),
--   descripcion varchar(100),
-- )

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

-- Compras --
create table compras (
  id_compra int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_cliente REFERENCES clientes (id_cliente),
  id_medio_de_pago REFERENCES medios_de_pago (id_medio_de_pago),
  fecha datetime,
  cantidad smallint,
  id_presentacion int REFERENCES presentaciones (id_presentacion),
  -- id_ubicacion int REFERENCES ubicaciones (id_ubicacion)
);

insert into compras (
  id_cliente,
  id_medio_de_pago,
  fecha
)
select C.id_cliente, MP.id_medio_de_pago, Compra_Fecha
from gd_esquema.Maestra M
join clientes C on C.numero_de_documento = M.Cli_Dni
join medios_de_pago MP on MP.descripcion = M.Forma_Pago_Desc
where Compra_Fecha is not null;
