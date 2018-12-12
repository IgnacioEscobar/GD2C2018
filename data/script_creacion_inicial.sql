-- Schema
create schema PEAKY_BLINDERS;
GO

-- Creación tablas y migracion
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
  numero varchar(6),
  piso tinyint,
  depto char,
  localidad varchar(60), -- estos datos no estan en la tabla maestra
  codigo_postal varchar(4),
  ciudad varchar(60), -- estos datos no estan en la tabla maestra
  cuit varchar(12)
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
  (select replace(Espec_Empresa_Cuit, '-', ''))
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
  descripcion varchar(15),
  muliplicador decimal(2, 2)
)

set IDENTITY_INSERT PEAKY_BLINDERS.grados ON;
insert into PEAKY_BLINDERS.grados (id_grado, descripcion, muliplicador) values
	(1, 'BAJO', 0.10),
	(2, 'MEDIO', 0.20),
	(3, 'ALTO', 0.30);
set IDENTITY_INSERT PEAKY_BLINDERS.grados OFF;

-- Publicaciones --
create table PEAKY_BLINDERS.publicaciones (
  id_publicacion int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(200),
  fecha_publicacion datetime,
  id_rubro tinyint REFERENCES PEAKY_BLINDERS.rubros (id_rubro),
  calle varchar(50),
  numero varchar(6),
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
  fecha_vencimiento datetime
)

insert into PEAKY_BLINDERS.presentaciones (
  id_publicacion,
  fecha_presentacion,
  fecha_vencimiento
)
select distinct
  Espectaculo_Cod,
  Espectaculo_Fecha,
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
  (7, 'Editar Publicación'),
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
  cuil varchar(12),
  mail varchar(60),
  telefono varchar(10),
  calle varchar(60),
  numero varchar(6),
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
  fila varchar(3),
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
go

-- Creacion de procedures

CREATE PROCEDURE PEAKY_BLINDERS.autenticar_usuario
@usuario     varchar(30),
@contrasenna varchar(30),
@id int output
AS
  BEGIN
    DECLARE @esperada binary(32);
	DECLARE @cant_intentos_fallidos tinyint;
	DECLARE @nuevo bit

    select top 1
      @esperada = password_hash, @id = id_usuario, @cant_intentos_fallidos = intentos_fallidos, @nuevo = nuevo
    from PEAKY_BLINDERS.usuarios
    where nombre_de_usuario = @usuario and habilitado = 1

    IF @esperada IS NOT NULL
      BEGIN
		IF @cant_intentos_fallidos >= 3
			return 5 -- USUARIO INHABILITADO
        IF HASHBYTES ('SHA2_256', @contrasenna) = @esperada
          BEGIN
            update PEAKY_BLINDERS.usuarios
            set intentos_fallidos = 0
            where nombre_de_usuario = @usuario

			IF @nuevo = 1
				return 3 -- USUARIO NUEVO (CAMBIO DE PASS)
			ELSE
				return 2 -- TODO OK
          END
        ELSE
          BEGIN
            update PEAKY_BLINDERS.usuarios
            set intentos_fallidos = @cant_intentos_fallidos + 1
            where nombre_de_usuario = @usuario

			IF @cant_intentos_fallidos + 1 = 3
				return 4 -- FALLA NRO 3
			ELSE
				return 1 -- CONTRASEÑA INVALIDA
          END
      END
    ELSE
      return 0 -- USUARIO INVALIDO
  END
GO

CREATE FUNCTION PEAKY_BLINDERS.verificar_contrasenna (
@id_usuario int,
@contrasenna varchar(30)
) RETURNS bit
AS
  BEGIN
	DECLARE @retorno bit

	IF EXISTS(SELECT * FROM PEAKY_BLINDERS.usuarios
				WHERE id_usuario = @id_usuario AND password_hash = HASHBYTES('SHA2_256', @contrasenna))
		SET @retorno = 1
	ELSE
		SET @retorno = 0
	RETURN @retorno
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.actualizar_contrasenna
@id_usuario int,
@contrasenna varchar(30)
AS
	UPDATE PEAKY_BLINDERS.usuarios SET
		password_hash = HASHBYTES('SHA2_256', @contrasenna),
		nuevo = 0
	WHERE id_usuario = @id_usuario
GO

CREATE PROCEDURE PEAKY_BLINDERS.crear_cliente
@usuario varchar(30),
@contrasenna varchar(30),
@nombre varchar(60),
@apellido varchar(60),
@descripcion_tipo_de_documento varchar(10),
@numero_de_documento int,
@cuil varchar(12),
@fecha_nacimiento datetime,
@calle varchar(60),
@numero varchar(6),
@piso tinyint,
@depto char(1),
@codigo_postal varchar(4),
@localidad varchar(60),
@mail varchar(60),
@telefono varchar(10),
@tarjeta_de_credito_asociada varchar(16),
@fecha_creacion datetime
AS
  BEGIN
	IF EXISTS(SELECT * FROM PEAKY_BLINDERS.usuarios WHERE nombre_de_usuario = @usuario)
		RETURN 0
	ELSE
	  BEGIN
		INSERT INTO PEAKY_BLINDERS.usuarios (nombre_de_usuario, password_hash, nuevo)
		VALUES (@usuario, HASHBYTES('SHA2_256', @contrasenna), 1)
	
		DECLARE @id_usuario int
		SELECT @id_usuario = id_usuario FROM PEAKY_BLINDERS.usuarios WHERE nombre_de_usuario = @usuario

		DECLARE @id_tipo_de_documento tinyint
		SELECT @id_tipo_de_documento = id_tipo_de_documento
		FROM PEAKY_BLINDERS.tipos_de_documento
		WHERE descripcion = @descripcion_tipo_de_documento

		INSERT INTO PEAKY_BLINDERS.clientes (
			id_usuario,
			nombre,
			apellido,
			id_tipo_de_documento,
			numero_de_documento,
			cuil,
			fecha_nacimiento,
			calle,
			numero,
			piso,
			depto,
			codigo_postal,
			localidad,
			mail,
			telefono,
			tarjeta_de_credito_asociada,
			fecha_creacion)
		VALUES (
			@id_usuario,
			@nombre,
			@apellido,
			@id_tipo_de_documento,
			@numero_de_documento,
			@cuil,
			@fecha_nacimiento,
			@calle,
			@numero,
			@piso,
			@depto,
			@codigo_postal,
			@localidad,
			@mail,
			@telefono,
			@tarjeta_de_credito_asociada,
			@fecha_creacion)

		DECLARE @id_rol int
		SELECT @id_rol = id_rol FROM PEAKY_BLINDERS.roles WHERE descripcion = 'Cliente'

		INSERT INTO PEAKY_BLINDERS.roles_por_usuario (id_usuario, id_rol)
		VALUES (@id_usuario, @id_rol)

		RETURN 1
	  END
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.modificar_cliente
@id_cliente int,
@nombre varchar(60),
@apellido varchar(60),
@descripcion_tipo_de_documento varchar(10),
@numero_de_documento int,
@cuil varchar(12),
@fecha_nacimiento datetime,
@calle varchar(60),
@numero varchar(6),
@piso tinyint,
@depto char(1),
@codigo_postal varchar(4),
@localidad varchar(60),
@mail varchar(60),
@telefono varchar(10),
@tarjeta_de_credito_asociada varchar(16)
AS
  BEGIN
	IF (SELECT COUNT(*) FROM PEAKY_BLINDERS.clientes WHERE cuil = @cuil) > 1
		RETURN 0
	ELSE
	  BEGIN	
		DECLARE @id_tipo_de_documento tinyint
		SELECT @id_tipo_de_documento = id_tipo_de_documento
		FROM PEAKY_BLINDERS.tipos_de_documento
		WHERE descripcion = @descripcion_tipo_de_documento

		UPDATE PEAKY_BLINDERS.clientes SET
			nombre = @nombre,
			apellido = @apellido,
			id_tipo_de_documento = @id_tipo_de_documento,
			numero_de_documento = @numero_de_documento,
			cuil = @cuil,
			fecha_nacimiento = @fecha_nacimiento,
			calle = @calle,
			numero = @numero,
			piso = @piso,
			depto = @depto,
			codigo_postal = @codigo_postal,
			localidad = @localidad,
			mail = @mail,
			telefono = @telefono,
			tarjeta_de_credito_asociada = @tarjeta_de_credito_asociada
		WHERE id_cliente = @id_cliente

		RETURN 1
	  END
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.eliminar_cliente
@numero_de_documento int
AS
  BEGIN
	DECLARE @id_usuario int
	SELECT @id_usuario = id_usuario FROM PEAKY_BLINDERS.clientes WHERE numero_de_documento = @numero_de_documento
	UPDATE PEAKY_BLINDERS.usuarios SET habilitado = 0 WHERE id_usuario = @id_usuario
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.crear_empresa
@usuario varchar(30),
@contrasenna varchar(30),
@razon_social varchar(60),
@cuit varchar(12),
@calle varchar(60),
@numero varchar(6),
@piso tinyint,
@depto char(1),
@codigo_postal varchar(4),
@localidad varchar(60),
@mail varchar(60),
@telefono varchar(10)
AS
  BEGIN
	IF EXISTS(SELECT * FROM PEAKY_BLINDERS.usuarios WHERE nombre_de_usuario = @usuario)
		RETURN 0
	ELSE
	  BEGIN
		INSERT INTO PEAKY_BLINDERS.usuarios (nombre_de_usuario, password_hash, nuevo)
		VALUES (@usuario, HASHBYTES('SHA2_256', @contrasenna), 1)
	
		DECLARE @id_usuario int
		SELECT @id_usuario = id_usuario FROM PEAKY_BLINDERS.usuarios WHERE nombre_de_usuario = @usuario

		INSERT INTO PEAKY_BLINDERS.empresas (
			id_usuario,
			razon_social,
			cuit,
			calle,
			numero,
			piso,
			depto,
			codigo_postal,
			localidad,
			mail,
			telefono)
		VALUES (
			@id_usuario,
			@razon_social,
			@cuit,
			@calle,
			@numero,
			@piso,
			@depto,
			@codigo_postal,
			@localidad,
			@mail,
			@telefono)

		DECLARE @id_rol int
		SELECT @id_rol = id_rol FROM PEAKY_BLINDERS.roles WHERE descripcion = 'Empresa'

		INSERT INTO PEAKY_BLINDERS.roles_por_usuario (id_usuario, id_rol)
		VALUES (@id_usuario, @id_rol)

		RETURN 1
	  END
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.modificar_empresa
@id_empresa int,
@razon_social varchar(60),
@cuit varchar(12),
@calle varchar(60),
@numero varchar(6),
@piso tinyint,
@depto char(1),
@codigo_postal varchar(4),
@localidad varchar(60),
@mail varchar(60),
@telefono varchar(10)
AS
  BEGIN
	IF (SELECT COUNT(*) FROM PEAKY_BLINDERS.empresas WHERE cuit = @cuit) > 1
		RETURN 0
	ELSE
	  BEGIN	
		UPDATE PEAKY_BLINDERS.empresas SET
			razon_social = @razon_social,
			cuit = @cuit,
			calle = @calle,
			numero = @numero,
			piso = @piso,
			depto = @depto,
			codigo_postal = @codigo_postal,
			localidad = @localidad,
			mail = @mail,
			telefono = @telefono
		WHERE id_empresa = @id_empresa
		RETURN 1
	  END
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.eliminar_empresa
@cuit varchar(14)
AS
  BEGIN
	DECLARE @id_usuario int
	SELECT @id_usuario = id_usuario FROM PEAKY_BLINDERS.empresas WHERE cuit = @cuit
	UPDATE PEAKY_BLINDERS.usuarios SET habilitado = 0 WHERE id_usuario = @id_usuario
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.crear_rol
@descripcion varchar(30)
AS
  BEGIN
	IF EXISTS(SELECT * FROM PEAKY_BLINDERS.roles WHERE descripcion = @descripcion)
		RETURN 0
	ELSE
	  BEGIN
		INSERT INTO PEAKY_BLINDERS.roles VALUES (@descripcion, 1)
		RETURN 1
	  END
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.modificar_rol
@descripcion_anterior varchar(30),
@descripcion varchar(30)
AS
  BEGIN
	IF EXISTS(SELECT * FROM PEAKY_BLINDERS.roles WHERE descripcion = @descripcion)
		RETURN 0
	ELSE
	  BEGIN
		UPDATE PEAKY_BLINDERS.roles SET descripcion = @descripcion WHERE descripcion = @descripcion_anterior
		RETURN 1
	  END
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.actualizar_rol_habilitado
@descripcion varchar(30),
@habilitado bit
AS
	UPDATE PEAKY_BLINDERS.roles SET habilitado = @habilitado WHERE descripcion = @descripcion
GO

CREATE PROCEDURE PEAKY_BLINDERS.borrar_funcionalidades_por_rol
@descripcion varchar(30)
AS
  BEGIN
	DECLARE @id_rol int
	SELECT @id_rol = id_rol FROM PEAKY_BLINDERS.roles WHERE descripcion = @descripcion

	DELETE FROM PEAKY_BLINDERS.funcionalidades_por_rol WHERE id_rol = @id_rol
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.actualizar_funcionalidades_por_rol
@descripcion_rol varchar(30),
@descripcion_funcionalidad varchar(50)
AS
  BEGIN
    DECLARE @id_rol int
	SELECT @id_rol = id_rol FROM PEAKY_BLINDERS.roles WHERE descripcion = @descripcion_rol

	DECLARE @id_funcionalidad int
	SELECT @id_funcionalidad = id_funcionalidad FROM PEAKY_BLINDERS.funcionalidades WHERE descripcion = @descripcion_funcionalidad

	INSERT INTO PEAKY_BLINDERS.funcionalidades_por_rol (
		id_rol,
		id_funcionalidad
	) VALUES (
		@id_rol,
		@id_funcionalidad
	)
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.generar_publicacion
@descripcion varchar(200),
@fecha_publicacion datetime,
@descripcion_rubro varchar(15),
@calle varchar(50),
@numero varchar(6),
@codigo_postal varchar(4),
@localidad varchar(60),
@id_empresa int,
@descripcion_estado varchar(25)
AS
  BEGIN
	DECLARE @id_estado int
	SELECT @id_estado = id_estado FROM PEAKY_BLINDERS.estados WHERE descripcion = @descripcion_estado

	DECLARE @id_rubro int
	SELECT @id_rubro = id_rubro FROM PEAKY_BLINDERS.rubros WHERE descripcion = @descripcion_rubro

	DECLARE @id_grado int -- siempre asigna el mínimo grado -?-
	SELECT TOP 1 @id_grado = id_grado FROM PEAKY_BLINDERS.grados ORDER BY muliplicador ASC

	INSERT INTO PEAKY_BLINDERS.publicaciones (
		descripcion,
		fecha_publicacion,
		id_rubro,
		calle,
		numero,
		codigo_postal,
		localidad,
		id_grado,
		id_empresa,
		id_estado		
	) VALUES (
		@descripcion,
		@fecha_publicacion,
		@id_rubro,
		@calle,
		@numero,
		@codigo_postal,
		@localidad,
		@id_grado,
		@id_empresa,
		@id_estado
	)
	RETURN @@IDENTITY
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.modificar_publicacion
@id_publicacion int,
@descripcion varchar(200),
@fecha_publicacion datetime,
@descripcion_rubro varchar(15),
@calle varchar(50),
@numero varchar(6),
@codigo_postal varchar(4),
@localidad varchar(60),
@descripcion_estado varchar(25)
AS
  BEGIN
	DECLARE @id_estado int
	SELECT @id_estado = id_estado FROM PEAKY_BLINDERS.estados WHERE descripcion = @descripcion_estado

	DECLARE @id_rubro int
	SELECT @id_rubro = id_rubro FROM PEAKY_BLINDERS.rubros WHERE descripcion = @descripcion_rubro

	UPDATE PEAKY_BLINDERS.publicaciones SET
		descripcion = @descripcion,
		fecha_publicacion = @fecha_publicacion,
		id_rubro = @id_rubro,
		calle = @calle,
		numero = @numero,
		codigo_postal = @codigo_postal,
		localidad = @localidad,
		id_estado = @id_estado
	WHERE id_publicacion = @id_publicacion

	RETURN @id_estado
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.finalizar_publicacion
@id_publicacion int
AS
  BEGIN
	DECLARE @id_estado int
	SELECT @id_estado = id_estado FROM PEAKY_BLINDERS.estados WHERE descripcion = 'Finalizada'
	UPDATE PEAKY_BLINDERS.publicaciones SET id_estado = @id_estado WHERE id_publicacion = @id_publicacion
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.generar_presentacion
@id_publicacion int,
@fecha_presentacion datetime
AS
  BEGIN
	INSERT INTO PEAKY_BLINDERS.presentaciones (
		id_publicacion,
		fecha_presentacion,
		fecha_vencimiento
	) VALUES (
		@id_publicacion,
		@fecha_presentacion,
		@fecha_presentacion - 7
	)
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.generar_ubicacion
@id_publicacion int,
@id_tipo_de_ubicacion int,
@fila varchar(3),
@asiento tinyint,
@precio int
AS
	INSERT INTO PEAKY_BLINDERS.Ubicaciones (
		id_publicacion,
		id_tipo_de_ubicacion,
		fila,
		asiento,
		precio
	) VALUES (
		@id_publicacion,
		@id_tipo_de_ubicacion,
		@fila,
		@asiento,
		@precio
	)
GO

CREATE PROCEDURE PEAKY_BLINDERS.actualizar_grado
@id_publicacion int,
@descripcion_grado varchar(15)
AS
  BEGIN
	DECLARE @id_grado int
	SELECT @id_grado = id_grado FROM PEAKY_BLINDERS.grados WHERE descripcion = @descripcion_grado
	UPDATE PEAKY_BLINDERS.publicaciones SET id_grado = @id_grado WHERE id_publicacion = @id_publicacion
  END