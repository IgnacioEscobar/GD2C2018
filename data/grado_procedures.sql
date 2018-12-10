CREATE PROCEDURE PEAKY_BLINDERS.actualizar_grado
@id_publicacion int,
@descripcion_grado varchar(15)
AS
  BEGIN
	DECLARE @id_grado int
	SELECT @id_grado = id_grado FROM PEAKY_BLINDERS.grados WHERE descripcion = @descripcion_grado
	UPDATE PEAKY_BLINDERS.publicaciones SET id_grado = @id_grado WHERE id_publicacion = @id_publicacion
  END
