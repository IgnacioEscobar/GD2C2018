ALTER PROCEDURE PEAKY_BLINDERS.generar_publicacion
@descripcion varchar(200),
@fecha_publicacion datetime,
@descripcion_rubro varchar(15),
@calle varchar(50),
@numero smallint,
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

ALTER PROCEDURE PEAKY_BLINDERS.modificar_publicacion
@id_publicacion int,
@descripcion varchar(200),
@fecha_publicacion datetime,
@descripcion_rubro varchar(15),
@calle varchar(50),
@numero smallint,
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

ALTER PROCEDURE PEAKY_BLINDERS.generar_presentacion
@id_publicacion int,
@fecha_presentacion datetime
AS
  BEGIN
	INSERT INTO PEAKY_BLINDERS.presentaciones (
		id_publicacion,
		fecha_presentacion
	) VALUES (
		@id_publicacion,
		@fecha_presentacion
	)
  END
GO

ALTER PROCEDURE PEAKY_BLINDERS.generar_ubicacion
@id_publicacion int,
@id_tipo_de_ubicacion int,
@fila char(1),
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