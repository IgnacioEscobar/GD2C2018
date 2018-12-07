/*
CREATE PROCEDURE PEAKY_BLINDERS.generar_publicacion
@descripcion_estado varchar(25),
@descripcion_rubro varchar(15),
@descripcion varchar(200),
@stock smallint,
@calle varchar(50),
@numero smallint,
@codigo_postal varchar(4),
@localidad varchar(60)
AS
  BEGIN
	DECLARE @no_hago_nada
  END
GO
*/

ALTER PROCEDURE PEAKY_BLINDERS.autenticar_usuario
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
			return 4 -- USUARIO INHABILITADO
        IF HASHBYTES ('SHA2_256', @contrasenna) = @esperada
          BEGIN
            update PEAKY_BLINDERS.usuarios
            set intentos_fallidos = 0
            where nombre_de_usuario = @usuario

			IF @nuevo = 1
				return 2 -- USUARIO NUEVO (CAMBIO DE PASS)
			ELSE
				return 1 -- TODO OK
          END
        ELSE
          BEGIN
            update PEAKY_BLINDERS.usuarios
            set intentos_fallidos = @cant_intentos_fallidos + 1
            where nombre_de_usuario = @usuario

			IF @cant_intentos_fallidos + 1 = 3
				return 3 -- FALLA NRO 3
			ELSE
				return 0 -- CONTRASEÑA INVALIDA
          END
      END
    ELSE
      return -1 -- USUARIO INVALIDO
  END
GO

ALTER FUNCTION PEAKY_BLINDERS.verificar_contrasenna (
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

ALTER PROCEDURE PEAKY_BLINDERS.actualizar_contrasenna
@id_usuario int,
@contrasenna varchar(30)
AS
	UPDATE PEAKY_BLINDERS.usuarios SET
		password_hash = HASHBYTES('SHA2_256', @contrasenna),
		nuevo = 0
	WHERE id_usuario = @id_usuario
GO

ALTER PROCEDURE PEAKY_BLINDERS.crear_cliente
@usuario varchar(30),
@contrasenna varchar(30),
@nombre varchar(60),
@apellido varchar(60),
@descripcion_tipo_de_documento varchar(10),
@numero_de_documento int,
@cuil varchar(11),
@fecha_nacimiento datetime,
@calle varchar(60),
@numero smallint,
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

ALTER PROCEDURE PEAKY_BLINDERS.modificar_cliente
@id_cliente int,
@nombre varchar(60),
@apellido varchar(60),
@descripcion_tipo_de_documento varchar(10),
@numero_de_documento int,
@cuil varchar(11),
@fecha_nacimiento datetime,
@calle varchar(60),
@numero smallint,
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

ALTER PROCEDURE PEAKY_BLINDERS.crear_empresa
@usuario varchar(30),
@contrasenna varchar(30),
@razon_social varchar(60),
@cuit varchar(11),
@calle varchar(60),
@numero smallint,
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

ALTER PROCEDURE PEAKY_BLINDERS.modificar_empresa
@id_empresa int,
@razon_social varchar(60),
@cuit varchar(11),
@calle varchar(60),
@numero smallint,
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