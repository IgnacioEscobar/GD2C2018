CREATE SCHEMA PEAKY_BLINDERS;
GO

USE GD2C2018

-- Creacion inicial de tablas
CREATE TABLE PEAKY_BLINDERS.Empresa (
	ID				int				NOT NULL IDENTITY(1,1) PRIMARY KEY,
	usuario			int				,
	razon_social	nvarchar (255)	,
	cuit			nvarchar (255)	,
	email			nvarchar (50)	,
	telefono		int				,
	fecha_creacion	datetime		,
	ciudad			nvarchar (50)	,
	codigo_postal	nvarchar (50)	,
	calle			nvarchar (50)	,
	numero_calle	numeric (18,0)	,
	piso			numeric (18,0)	,
	departamento	nvarchar (50)
)
