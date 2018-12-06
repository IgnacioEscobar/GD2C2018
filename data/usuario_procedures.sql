ALTER PROCEDURE PEAKY_BLINDERS.crear_usuario
@usuario     varchar(30),
@contrasenna varchar(30)
AS
  insert into PEAKY_BLINDERS.usuarios (nombre_de_usuario, password_hash) values (
    @usuario, HASHBYTES('SHA2_256', @contrasenna)
  )
GO
	
ALTER PROCEDURE PEAKY_BLINDERS.autenticar_usuario
@usuario     varchar(30),
@contrasenna varchar(30),
@id int output
AS
  BEGIN
    DECLARE @esperada binary(32);
	DECLARE @cant_intentos_fallidos tinyint;

    select top 1
      @esperada = password_hash, @id = id_usuario, @cant_intentos_fallidos = intentos_fallidos
    from PEAKY_BLINDERS.usuarios
    where nombre_de_usuario = @usuario and habilitado = 1

    IF @esperada IS NOT NULL
      BEGIN
		IF @cant_intentos_fallidos >= 3
			return 3
        IF HASHBYTES ('SHA2_256', @contrasenna) = @esperada
          BEGIN
            update PEAKY_BLINDERS.usuarios
            set intentos_fallidos = 0
            where nombre_de_usuario = @usuario
            return 1
          END
        ELSE
          BEGIN
            update PEAKY_BLINDERS.usuarios
            set intentos_fallidos = @cant_intentos_fallidos + 1
            where nombre_de_usuario = @usuario

			IF @cant_intentos_fallidos + 1 = 3
				return 2
			ELSE
				return 0
          END
      END
    ELSE
      return -1
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.crear_cliente
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
	DECLARE @id_tipo_de_documento tinyint
	SELECT @id_tipo_de_documento = id_tipo_de_documento
	FROM PEAKY_BLINDERS.tipos_de_documento
	WHERE descripcion = @descripcion_tipo_de_documento

	INSERT INTO PEAKY_BLINDERS.clientes (nombre, apellido, id_tipo_de_documento, numero_de_documento, cuil, fecha_nacimiento,
		calle, numero, piso, depto, codigo_postal, localidad, mail, telefono, tarjeta_de_credito_asociada, fecha_creacion)
	VALUES (@nombre, @apellido, @id_tipo_de_documento, @numero_de_documento, @cuil, @fecha_nacimiento, @calle, @numero,
		@piso, @depto, @codigo_postal, @localidad, @mail, @telefono, @tarjeta_de_credito_asociada, @fecha_creacion)
END
GO

CREATE PROCEDURE PEAKY_BLINDERS.crear_empresa
@razon_social varchar(60),
@cuit varchar(11),
@calle varchar(60),
@numero smallint,
@piso tinyint,
@depto char(1),
@codigo_postal varchar(4),
@localidad varchar(60),
@mail varchar(60),
@telefono varchar(10),
AS
	INSERT INTO PEAKY_BLINDERS.empresas (razon_social, cuit, calle, numero, piso, depto, codigo_postal, localidad,
		mail, telefono)
	VALUES (@razon_social, @cuit, @calle, @numero, @piso, @depto, @codigo_postal, @localidad, @mail, @telefono)
GO