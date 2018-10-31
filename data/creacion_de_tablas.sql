CREATE SCHEMA PEAKY_BLINDERS;
GO

USE GD2C2018

-- Creacion inicial de tablas
create table PEAKY_BLINDERS.Empresa (
	ID						int				NOT NULL IDENTITY(1,1) PRIMARY KEY,
	usuario					int				,
	razon_social			varchar (255)	,
	cuit					bigint			,
	email					varchar (50)	,
	telefono				int				,
	fecha_creacion			date			,
	ciudad					varchar (50)	,
	codigo_postal			varchar (50)	,
	calle					varchar (50)	,
	numero_calle			smallint		,
	piso					tinyint			,
	departamento			varchar (50)
)

create table PEAKY_BLINDERS.Cliente (
	ID						int				NOT NULL IDENTITY(1,1) PRIMARY KEY,
	usuario					int				,
	nombre					varchar (30)	,
	apellido				varchar (30)	,
	tipo_documento			varchar (4)		,
	documento				int				,
	cuil					bigint			,
	email					varchar (50)	,
	telefono				int				,
	fecha_creacion			date			,
	fecha_nacimiento		date			,
	ciudad					varchar (50)	,
	codigo_postal			varchar (50)	,
	calle					varchar (50)	,
	numero_calle			smallint		,
	piso					tinyint			,
	departamento			varchar (50)
)

create table PEAKY_BLINDERS.Usuario (
	ID						int				PRIMARY KEY NOT NULL IDENTITY(1,1),
	usuario					varchar (30)	,  --FK
	contrasenna				binary  (20) 	,  -- Nota: Usar SHA1 o SHA (o cambiar el tipo de dato)
	cant_fallos				int				,
	habilitado				bit
)

create table PEAKY_BLINDERS.Publicacion (
	ID						int				PRIMARY KEY NOT NULL IDENTITY(1,1),
	estado					varchar (10)	,
	grado					int				,
	descripcion				varchar (255)	,
	fecha_creacion			date			, 	
	fechahora_espectaculo	datetime		,
	calle					varchar (50)	,
	numero_calle			smallint		,		
	responsable				int				, -- FK
	rubro					int				, -- FK
)

create table PEAKY_BLINDERS.Fecha (
	ID						int				PRIMARY KEY NOT NULL IDENTITY(1,1),
	pubicacion				int				, -- FK
	fechahora_espectaculo	datetime		,
)

create table PEAKY_BLINDERS.Platea (
	ID						int				PRIMARY KEY NOT NULL IDENTITY(1,1),
	publicacion				int				, -- FK
	stock_sin_numerar		int				,
	cantidad_asientos		int				,
	asientos_por_fila		int				,
	costo					money
)

create table PEAKY_BLINDERS.Rubro (
  ID						int				PRIMARY KEY NOT NULL IDENTITY(1,1),
  descripcion				varchar(255)
)

create table PEAKY_BLINDERS.Punto (
  ID						int				PRIMARY KEY NOT NULL IDENTITY(1,1),
  cliente					int				, -- FK
  cantidad					int				,
  fecha_adquisicion			datetime
)

create table PEAKY_BLINDERS.Factura (
  ID						int				PRIMARY KEY NOT NULL IDENTITY(1,1),
  cliente					int				, -- FK
  monto						money			,
  fecha						datetime
)

create table PEAKY_BLINDERS.Item (
  ID						int				PRIMARY KEY NOT NULL IDENTITY(1,1),
  factura					int				, -- FK
  descripcion				varchar (50)	,
  cantidad					int				,
  monto						money			,
  fecha						datetime
)

create table PEAKY_BLINDERS.Compra (
  ID						int				PRIMARY KEY NOT NULL IDENTITY(1,1),
  cliente					int				, -- FK
  fecha						int				, -- FK
  medio_de_pago				varchar(15)
)

create table PEAKY_BLINDERS.Ubicacion (
  ID						int				PRIMARY KEY NOT NULL IDENTITY(1,1),
  platea					int				, -- FK
  compra					int				, -- FK
  fila						varchar (2)		,
  asiento					int				,
  sin_numerar				bit				,
  monto						money			
) 