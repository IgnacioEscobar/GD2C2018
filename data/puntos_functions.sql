ALTER FUNCTION PEAKY_BLINDERS.obtener_puntos (
@id_usuario int,
@fecha_actual datetime
) RETURNS int
AS
  BEGIN
	DECLARE @variacion int
	DECLARE @total int
	SET @total = 0

	DECLARE c_puntos CURSOR FOR
		SELECT MP.variacion
		FROM PEAKY_BLINDERS.movimientos_de_puntos MP
            JOIN PEAKY_BLINDERS.clientes C ON MP.id_cliente = C.id_cliente
        WHERE C.id_usuario = @id_usuario AND MP.fecha_vencimiento >= @fecha_actual
		ORDER BY MP.fecha ASC

	OPEN c_puntos
	FETCH NEXT FROM c_puntos INTO @variacion

	WHILE @@FETCH_STATUS = 0
	  BEGIN
		SET @total += @variacion
		IF @total < 0
			SET @total = 0
		FETCH NEXT FROM c_puntos INTO @variacion
	  END

	CLOSE c_puntos
	DEALLOCATE c_puntos

	RETURN @total
  END
GO

ALTER FUNCTION PEAKY_BLINDERS.obtener_puntos_vencidos (
@id_cliente int,
@ano int,
@mesDesde int,
@mesHasta int,
@fecha_actual datetime
) RETURNS int
AS
  BEGIN
	DECLARE @variacion int
	DECLARE @total int
	SET @total = 0

	DECLARE c_puntos CURSOR FOR
		SELECT MP.variacion
		FROM PEAKY_BLINDERS.movimientos_de_puntos MP
        WHERE MP.id_cliente = @id_cliente
			AND MP.fecha_vencimiento < @fecha_actual
			AND YEAR(MP.fecha) = @ano
			AND MONTH(MP.fecha) BETWEEN @mesDesde AND @mesHasta
		ORDER BY MP.fecha ASC

	OPEN c_puntos
	FETCH NEXT FROM c_puntos INTO @variacion

	WHILE @@FETCH_STATUS = 0
	  BEGIN
		SET @total += @variacion
		IF @total < 0
			SET @total = 0
		FETCH NEXT FROM c_puntos INTO @variacion
	  END

	CLOSE c_puntos
	DEALLOCATE c_puntos

	RETURN @total
  END
GO