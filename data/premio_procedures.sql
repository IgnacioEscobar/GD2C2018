CREATE PROCEDURE PEAKY_BLINDERS.canjear_premio
@id_usuario int,
@descripcion varchar(100),
@puntos int,
@fecha datetime
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
		variacion,
		fecha,
		fecha_vencimiento
	) VALUES (
		@id_cliente,
		-@puntos,
		@fecha,
		DATEADD(day, 30, @fecha)
	)
  END