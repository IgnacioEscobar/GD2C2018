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

insert into estados values ('Publicada');
-- es el único estado que aparece en la db, hay que agregar más

-- Publicaciones --
create table publicaiones (
  id_publicacion int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_estado int REFERENCES estados (id_estado),
  -- id_grado ???
  -- stock ???
  fecha date,
  fecha_vencimiento date,
  -- direccion varchar(60) ???
  id_empresa int REFERENCES empresas (id_empresa),
  -- id_rubro int REFERENCES rubros (id_rubro) ???
);

set IDENTITY_INSERT publicaiones ON;

insert into publicaiones (
  id_publicacion,
  id_estado,
  fecha,
  fecha_vencimiento,
  id_empresa
)
select distinct
  Espectaculo_Cod,
  E.id_estado,
  Espectaculo_Fecha,
  Espectaculo_Fecha_Venc,
  EM.id_empresa
from gd_esquema.Maestra M
join estados E on M.Espectaculo_Estado = E.descripcion
join empresas EM on EM.razon_social = M.Espec_Empresa_Razon_Social;

SET IDENTITY_INSERT publicaiones OFF;

-- Tipos de documentos
create table tipos_de_documentos (
  id_tipo_de_documento smallint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(10)
)

SET IDENTITY_INSERT tipos_de_documentos ON;
insert into tipos_de_documentos values (1, 'DNI')
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
  fecha_nacimiento date,
  fecha_creacion date,
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

insert into medios_de_pago values ('Efectivo');

-- Factura --
-- create table facturas (
--   id_factura int PRIMARY KEY NOT NULL IDENTITY(1, 1),
--   nro_factura int unique,
--   fecha date,
--   total int,
--   id_medio_de_pago int REFERENCES medios_de_pago (id_medio_de_pago),
-- );

-- insert into facturas (
--   nro_factura,
--   fecha,
--   total,
--   id_medio_de_pago
-- )
-- select distinct
--   Factura_Nro,
--   Factura_Fecha,
--   Factura_Total,
--   id_medio_de_pago
-- from gd_esquema.Maestra M
-- join medios_de_pago MP on M.Forma_Pago_Desc = MP.descripcion 
-- where Factura_Nro is not null;

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