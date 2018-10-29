create table empresas (
  id_empresa int PRIMARY KEY NOT NULL IDENTITY(1,1),
  -- usuario int NOT NULL,
  razon_social nvarchar(60),
  mail nvarchar(60),
  calle nvarchar(60),
  numero int,
  piso int,
  departamento char,
  localidad nvarchar(60), -- estos datos no estan en la tabla maestra
  codigo_postal nvarchar(4),
  ciudad nvarchar(60), -- estos datos no estan en la tabla maestra
  cuit nvarchar(14)
)

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
from gd_esquema.Maestra