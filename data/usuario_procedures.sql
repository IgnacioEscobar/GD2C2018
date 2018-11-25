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