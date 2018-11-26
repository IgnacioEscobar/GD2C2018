CREATE PROCEDURE PEAKY_BLINDERS.crear_usuario
@usuario     varchar(30),
@contrasenna varchar(30)
AS
  insert into PEAKY_BLINDERS.usuarios (nombre_de_usuario, password_hash) values (
    @usuario, HASHBYTES('SHA2_256', @contrasenna)
  )
GO

CREATE PROCEDURE PEAKY_BLINDERS.autenticar_usuario
@usuario     varchar(30),
@contrasenna varchar(30),
@id int output
AS
  BEGIN
    DECLARE @esperada binary(32);

    select top 1
      @esperada = password_hash, @id = id_usuario
    from PEAKY_BLINDERS.usuarios
    where nombre_de_usuario = @usuario and intentos_fallidos <= 3

    IF @esperada IS NOT NULL
      BEGIN
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
            set intentos_fallidos = intentos_fallidos + 1
            where nombre_de_usuario = @usuario
            return 0
          END
      END
    ELSE
      return 2
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.eliminar_empresa
@cuit varchar(14)
AS
BEGIN
	UPDATE PEAKY_BLINDERS.empresas
	SET borrado = 1
	WHERE cuit = @cuit
END
GO

CREATE PROCEDURE PEAKY_BLINDERS.eliminar_cliente
@cuit varchar(14)
AS
BEGIN
	UPDATE PEAKY_BLINDERS.clientes
	SET borrado = 1
	WHERE cuit = @cuit
END
GO

CREATE PROCEDURE PEAKY_BLINDERS.modificar_cliente
  @id_cliente int,
  @nombre varchar(60),
  @apellido varchar(60),
  @tipo_de_documento varchar(10),
  @numero_de_documento int,
  @cuil varchar(14),
  @mail varchar(60),
  @telefono varchar(10),
  @calle varchar(60),
  @numero smallint,
  @piso tinyint,
  @depto char,
  @localidad varchar(60),
  @codigo_postal varchar(4),
  @fecha_nacimiento datetime,
  @tarjeta_de_credito_asociada varchar(16)
AS
BEGIN
	UPDATE PEAKY_BLINDERS.clientes
	SET nombre = @nombre,
		apellido = @apellido,
		id_tipo_de_documento = (SELECT id_tipo_de_documento FROM PEAKY_BLINDERS.tipos_de_documento WHERE descripcion = @tipo_de_documento),
		numero_de_documento = @numero_de_documento,
		cuil = @cuil,
		mail = @mail,
		telefono = @telefono,
		calle = @calle,
		numero = @numero,
		piso = @piso,
		depto = @depto,
		localidad = @localidad,
		codigo_postal = @codigo_postal,
		fecha_nacimiento = @fecha_nacimiento,
		tarjeta_de_credito_asociada = @tarjeta_de_credito_asociada
	WHERE id_cliente = @id_cliente
END
GO

