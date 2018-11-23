CREATE PROCEDURE PEAKY_BLINDERS.crear_usuario 
@usuario     varchar(30),
@contrasenna varchar(30)
AS
	INSERT INTO PEAKY_BLINDERS.Usuario VALUES (
		@usuario, -- username
		HASHBYTES('SHA2_256',@contrasenna), -- contraseña hasheada
		0, -- intentos fallidos
		1  -- usuario habilitado
	)
GO

CREATE PROCEDURE PEAKY_BLINDERS.autenticar_usuario 
@usuario     varchar(30),
@contrasenna varchar(30),
@id int output
AS
	BEGIN  
		DECLARE @esperada	binary(32);

		SELECT TOP 1 @esperada = contrasenna, @id = ID
		FROM PEAKY_BLINDERS.Usuario
		WHERE usuario=@usuario AND cant_fallos <= 3

		IF @esperada IS NOT NULL
			BEGIN
				IF HASHBYTES ('SHA2_256', @contrasenna) = @esperada
					BEGIN
						UPDATE PEAKY_BLINDERS.Usuario
						SET cant_fallos = 0
						WHERE usuario = @usuario
						RETURN 1
					END
				ELSE
					BEGIN
						UPDATE PEAKY_BLINDERS.Usuario
						SET cant_fallos = cant_fallos + 1
						WHERE usuario = @usuario
						RETURN 0
					END
			END
		ELSE
			RETURN 2
	END
GO