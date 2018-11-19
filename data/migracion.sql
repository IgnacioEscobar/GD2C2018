-- Empresas --
create table empresas (
  id_empresa int PRIMARY KEY NOT NULL IDENTITY(1,1),
  -- usuario int NOT NULL,
  razon_social varchar(60),
  mail varchar(60),
  calle varchar(60),
  numero int,
  piso int,
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
select
  distinct
  Espec_Empresa_Razon_Social as razon_social,
  Espec_Empresa_Mail as mail,
  Espec_Empresa_Dom_Calle as calle,
  Espec_Empresa_Nro_Calle as numero,
  Espec_Empresa_Piso as piso,
  Espec_Empresa_Depto as departamento,
  null as localidad,
  Espec_Empresa_Cod_Postal as codigo_postal,
  null as ciudad,
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