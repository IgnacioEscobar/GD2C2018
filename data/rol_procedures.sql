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

ALTER PROCEDURE PEAKY_BLINDERS.modificar_rol
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