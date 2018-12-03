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