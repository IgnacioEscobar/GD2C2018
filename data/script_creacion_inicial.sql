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
  cuit varchar(12),
  activo bit
);

insert into PEAKY_BLINDERS.empresas (
  razon_social,
  mail,
  calle,
  numero,
  piso,
  depto,
  codigo_postal,
  cuit,
  activo
)
select distinct
  Espec_Empresa_Razon_Social,
  Espec_Empresa_Mail,
  Espec_Empresa_Dom_Calle,
  Espec_Empresa_Nro_Calle,
  Espec_Empresa_Piso,
  Espec_Empresa_Depto,
  Espec_Empresa_Cod_Postal,
  (select replace(Espec_Empresa_Cuit, '-', '')),
  1
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

insert into PEAKY_BLINDERS.rubros values ('Otros');

-- Grados --
create table PEAKY_BLINDERS.grados (
  id_grado tinyint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(15),
  multiplicador decimal(2, 2)
)

set IDENTITY_INSERT PEAKY_BLINDERS.grados ON;
insert into PEAKY_BLINDERS.grados (id_grado, descripcion, multiplicador) values
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
  tarjeta_de_credito_asociada varchar(16),
  activo bit
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
  fecha_nacimiento,
  activo
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
  Cli_Fecha_Nac,
  1
from gd_esquema.Maestra
where Cli_Dni is not null;

-- Movimientos de puntos
create table PEAKY_BLINDERS.movimientos_de_puntos (
  id_movimiento int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_cliente int REFERENCES PEAKY_BLINDERS.clientes (id_cliente),
  variacion int,
  fecha datetime default GETDATE(),
  fecha_vencimiento datetime default DATEADD(day, 30, GETDATE())
)

-- Tipos de premios
create table PEAKY_BLINDERS.tipos_de_premios (
  id_tipo_de_premio tinyint PRIMARY KEY NOT NULL IDENTITY(1, 1),
  descripcion varchar(100),
  puntos int,
  multiplicador decimal(3, 2)
)

insert into PEAKY_BLINDERS.tipos_de_premios
values ('Entrada 100% OFF', 1000, 0),
  ('Entrada 50% OFF', 700, 0.5),
  ('Entrada 25% OFF', 400, 0.75)

-- Premios
create table PEAKY_BLINDERS.premios (
  id_premio int PRIMARY KEY NOT NULL IDENTITY(1, 1),
  id_tipo_de_premio tinyint REFERENCES PEAKY_BLINDERS.tipos_de_premios (id_tipo_de_premio),
  id_cliente int REFERENCES PEAKY_BLINDERS.clientes (id_cliente),
  usado bit default 0
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
  total int
);

insert into PEAKY_BLINDERS.facturas (
  nro_factura,
  fecha,
  total
)
select distinct
  Factura_Nro,
  Factura_Fecha,
  Factura_Total
from gd_esquema.Maestra

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
  fecha datetime default GETDATE(),
  cantidad tinyint default 1,
  id_presentacion int REFERENCES PEAKY_BLINDERS.presentaciones (id_presentacion),
  id_publicacion int REFERENCES PEAKY_BLINDERS.publicaciones (id_publicacion),
  -- ^^ desnormalizacion para hacer mas simple la migración y cualquier consulta futura
  id_ubicacion int REFERENCES PEAKY_BLINDERS.ubicaciones (id_ubicacion),
  monto int,
  facturada bit default 0
);

insert into PEAKY_BLINDERS.compras (
  id_cliente,
  id_medio_de_pago,
  fecha,
  cantidad,
  id_presentacion,
  id_publicacion,
  id_ubicacion,
  monto,
  facturada
)
select distinct
  C.id_cliente,
  1, -- todo lo que venia de la base era en efectivo
  M.Compra_Fecha,
  M.Compra_Cantidad,
  PRS.id_presentacion,
  M.Espectaculo_Cod,
  U.id_ubicacion,
  M.Ubicacion_Precio,
  1
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

-- Crear usuarios para clientes
insert into PEAKY_BLINDERS.usuarios (nombre_de_usuario, password_hash)
select
	concat(left(nombre, 1), apellido, '#', id_cliente),
	HASHBYTES('SHA2_256',
    concat(
      right(concat('0', day(fecha_nacimiento)), 2),
      right(concat('0', month(fecha_nacimiento)), 2),
      year(fecha_nacimiento)
    )
  )
from PEAKY_BLINDERS.clientes;

insert into PEAKY_BLINDERS.roles_por_usuario (id_usuario, id_rol)
select id_usuario, 2 from PEAKY_BLINDERS.usuarios
where nombre_de_usuario like '%#%';

update PEAKY_BLINDERS.clientes
set id_usuario = U.id_usuario
from PEAKY_BLINDERS.usuarios U join
	PEAKY_BLINDERS.clientes C on concat(left(C.nombre, 1), C.apellido, '#', C.id_cliente) = U.nombre_de_usuario

-- Crear usuarios para empresas
insert into PEAKY_BLINDERS.usuarios (nombre_de_usuario, password_hash)
select
	concat(
		'empresa',
		right(
      concat('0',right(razon_social, len(razon_social) - 16)),
      2
    )
	),
	HASHBYTES('SHA2_256', cuit)
from PEAKY_BLINDERS.empresas;

insert into PEAKY_BLINDERS.roles_por_usuario (id_usuario, id_rol)
select id_usuario, 3 from PEAKY_BLINDERS.usuarios
where nombre_de_usuario like 'empresa%';

update PEAKY_BLINDERS.empresas
set id_usuario = U.id_usuario
from PEAKY_BLINDERS.usuarios U join
	PEAKY_BLINDERS.empresas E on
  concat('empresa',right(concat('0',right(razon_social, len(razon_social) - 16)),2)) = U.nombre_de_usuario

-- Crear un usuario para un admin
insert into PEAKY_BLINDERS.usuarios (nombre_de_usuario, password_hash)
values ('admin', HASHBYTES('SHA2_256', 'admin'));

insert into PEAKY_BLINDERS.roles_por_usuario (id_usuario, id_rol)
select id_usuario, 1 from PEAKY_BLINDERS.usuarios
where nombre_de_usuario = 'admin';

go


-- Creacion de procedures

CREATE PROCEDURE PEAKY_BLINDERS.autenticar_usuario
@usuario     varchar(30),
@contrasenna varchar(30),
@id int output
AS
  BEGIN
    DECLARE @esperada binary(32)
	DECLARE @habilitado bit
	DECLARE @nuevo bit

    select top 1
      @esperada = password_hash, @id = id_usuario, @habilitado = habilitado, @nuevo = nuevo
    from PEAKY_BLINDERS.usuarios
    where nombre_de_usuario = @usuario

    IF @esperada IS NOT NULL
      BEGIN
		IF @habilitado = 0
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
            set intentos_fallidos += 1
            where nombre_de_usuario = @usuario

			DECLARE @intentos_fallidos tinyint
			select @intentos_fallidos = intentos_fallidos
			from PEAKY_BLINDERS.usuarios
			WHERE nombre_de_usuario = @usuario

			IF @intentos_fallidos = 3
			  BEGIN
			    update PEAKY_BLINDERS.usuarios
				set habilitado = 0
				where nombre_de_usuario = @usuario

				return 4 -- FALLA NRO 3
			  END
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

CREATE PROCEDURE PEAKY_BLINDERS.actualizar_estado_usuario
@id_usuario int,
@habilitado bit
AS
	UPDATE PEAKY_BLINDERS.usuarios SET habilitado = @habilitado, intentos_fallidos = 0 WHERE id_usuario = @id_usuario
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

CREATE PROCEDURE PEAKY_BLINDERS.baja_cliente
@id_cliente int
AS
  BEGIN
	DECLARE @id_usuario int
	SELECT @id_usuario = ISNULL(id_usuario, -1) FROM PEAKY_BLINDERS.clientes WHERE id_cliente = @id_cliente
	IF @id_usuario = -1
		RETURN 0
	ELSE
		UPDATE PEAKY_BLINDERS.usuarios SET habilitado = 0 WHERE id_usuario = @id_usuario
		RETURN 1
  END
GO

CREATE FUNCTION PEAKY_BLINDERS.cliente_habilitado (
@id_cliente int
) RETURNS int
AS
  BEGIN
	DECLARE @resultado int

	DECLARE @id_usuario int
	SELECT @id_usuario = ISNULL(id_usuario, -1) FROM PEAKY_BLINDERS.clientes WHERE id_cliente = @id_cliente
	IF @id_usuario = -1
		SET @resultado = -1
	ELSE
		SELECT @resultado = habilitado FROM PEAKY_BLINDERS.usuarios WHERE id_usuario = @id_usuario

	RETURN @resultado
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.registrar_tarjeta
@id_cliente int,
@numero_tarjeta varchar(16)
AS
	UPDATE PEAKY_BLINDERS.clientes SET tarjeta_de_credito_asociada = @numero_tarjeta WHERE id_cliente = @id_cliente
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

CREATE PROCEDURE PEAKY_BLINDERS.baja_empresa
@id_empresa int
AS
  BEGIN
	DECLARE @id_usuario int
	SELECT @id_usuario = ISNULL(id_usuario, -1) FROM PEAKY_BLINDERS.empresas WHERE id_empresa = @id_empresa
	IF @id_usuario = -1
		RETURN 0
	ELSE
		UPDATE PEAKY_BLINDERS.usuarios SET habilitado = 0 WHERE id_usuario = @id_usuario
		RETURN 1
  END
GO

CREATE FUNCTION PEAKY_BLINDERS.empresa_habilitada (
@id_empresa int
) RETURNS int
AS
  BEGIN
	DECLARE @resultado int

	DECLARE @id_usuario int
	SELECT @id_usuario = ISNULL(id_usuario, -1) FROM PEAKY_BLINDERS.empresas WHERE id_empresa = @id_empresa
	IF @id_usuario = -1
		SET @resultado = -1
	ELSE
		SELECT @resultado = habilitado FROM PEAKY_BLINDERS.usuarios WHERE id_usuario = @id_usuario

	RETURN @resultado
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
	SELECT TOP 1 @id_grado = id_grado FROM PEAKY_BLINDERS.grados ORDER BY multiplicador ASC

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
GO

create procedure PEAKY_BLINDERS.registrarCompra
@id_cliente int,
@id_medio_de_pago tinyint,
@id_presentacion int,
@id_publicacion int,
@id_ubicacion int,
@id_premio int,
@fecha datetime
as
  begin
	declare @monto_a_cobrar as int
	declare @multiplicador_premio as decimal(3,2)
	set @multiplicador_premio = 1

  set @monto_a_cobrar = (select U.precio from PEAKY_BLINDERS.ubicaciones U where U.id_ubicacion = @id_ubicacion)

	if @id_premio != -1
		set @multiplicador_premio = (
      select TP.multiplicador from PEAKY_BLINDERS.premios P
      join PEAKY_BLINDERS.tipos_de_premios TP on P.id_tipo_de_premio = TP.id_tipo_de_premio
		  where P.id_cliente = @id_cliente and usado = 0 and P.id_premio = @id_premio
    )
  
	set @monto_a_cobrar = @monto_a_cobrar * @multiplicador_premio
  -- registra compra con monto correspondiente, fecha actual y cantidad = 1
  insert into PEAKY_BLINDERS.compras (id_cliente, id_medio_de_pago, id_presentacion, id_publicacion, id_ubicacion, monto, fecha)
  values (@id_cliente, @id_medio_de_pago, @id_presentacion, @id_publicacion, @id_ubicacion, @monto_a_cobrar, @fecha);

  update PEAKY_BLINDERS.premios
  set usado = 1
  where id_cliente = @id_cliente and id_premio = @id_premio

  -- se suman 50 puntos por compra
  insert into PEAKY_BLINDERS.movimientos_de_puntos (id_cliente, variacion)
  values (@id_cliente, 50);
  end
go

CREATE PROCEDURE PEAKY_BLINDERS.canjear_premio
@id_usuario int,
@descripcion varchar(100),
@puntos int
AS
  BEGIN
	DECLARE @id_tipo_de_premio int
	SELECT @id_tipo_de_premio = id_tipo_de_premio FROM PEAKY_BLINDERS.tipos_de_premios WHERE descripcion = @descripcion

	DECLARE @id_cliente int
	SELECT @id_cliente = id_cliente FROM PEAKY_BLINDERS.clientes WHERE id_usuario = @id_usuario

	INSERT INTO PEAKY_BLINDERS.premios (
		id_tipo_de_premio,
		id_cliente,
		usado
	) VALUES (
		@id_tipo_de_premio,
		@id_cliente,
		0
	)

	INSERT INTO PEAKY_BLINDERS.movimientos_de_puntos (
		id_cliente,
		variacion
	) VALUES (
		@id_cliente,
		-@puntos
	)
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.generar_factura
@fecha datetime,
@total int
AS
  BEGIN
	DECLARE @nro_factura int
	SELECT @nro_factura = MAX(nro_factura) + 1
	FROM PEAKY_BLINDERS.facturas

	INSERT INTO PEAKY_BLINDERS.facturas (
		nro_factura,
		fecha,
		total
	) VALUES (
		@nro_factura,
		@fecha,
		@total
	)

	RETURN @@IDENTITY
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.agregar_item
@id_factura int,
@descripcion varchar(100),
@id_compra int,
@cantidad tinyint,
@comision decimal(6, 2)
AS
  BEGIN
	INSERT INTO PEAKY_BLINDERS.items (
		id_factura,
		descripcion,
		id_compra,
		cantidad,
		comision
	) VALUES (
		@id_factura,
		@descripcion,
		@id_compra,
		@cantidad,
		@comision
	)

	UPDATE PEAKY_BLINDERS.compras SET facturada = 1 WHERE id_compra = @id_compra
  END