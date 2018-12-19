CREATE PROCEDURE PEAKY_BLINDERS.generar_factura
@fecha datetime,
@total int
AS
  BEGIN
	DECLARE @nro_factura int
	SELECT @nro_factura = MAX(nro_factura) + 1
	FROM PEAKY_BLINDERS.facturas

	INSERT INTO PEAKY_BLINDERS.facturas (
		nro_factura,
		fecha,
		total
	) VALUES (
		@nro_factura,
		@fecha,
		@total
	)

	RETURN @@IDENTITY
  END
GO

CREATE PROCEDURE PEAKY_BLINDERS.agregar_item
@id_factura int,
@descripcion varchar(100),
@id_compra int,
@cantidad tinyint,
@comision decimal(6, 2)
AS
	INSERT INTO PEAKY_BLINDERS.items (
		id_factura,
		descripcion,
		id_compra,
		cantidad,
		comision
	) VALUES (
		@id_factura,
		@descripcion,
		@id_compra,
		@cantidad,
		@comision
	)