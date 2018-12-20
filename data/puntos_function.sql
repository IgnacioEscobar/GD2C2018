CREATE FUNCTION PEAKY_BLINDERS.obtener_puntos (
@id_cliente int,
@fecha datetime
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
        WHERE C.id_usuario = @id_cliente AND MP.fecha_vencimiento >= @fecha
		ORDER BY MP.fecha_vencimiento ASC

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