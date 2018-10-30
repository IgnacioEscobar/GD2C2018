USE GD2C2018

-- Variables correspondientes a las columnas de la tabla maestra incial
DECLARE @Espec_Empresa_Razon_Social nvarchar (255)
DECLARE @Espec_Empresa_Cuit nvarchar (255)
DECLARE @Espec_Empresa_Fecha_Creacion datetime
DECLARE @Espec_Empresa_Mail nvarchar (50)
DECLARE @Espec_Empresa_Dom_Calle nvarchar (50)
DECLARE @Espec_Empresa_Nro_Calle numeric (18,0)
DECLARE @Espec_Empresa_Piso numeric (18,0)
DECLARE @Espec_Empresa_Depto nvarchar (50)
DECLARE @Espec_Empresa_Cod_Postal nvarchar (50)
DECLARE @Espectaculo_Cod numeric (18,0)
DECLARE @Espectaculo_Descripcion nvarchar (255)
DECLARE @Espectaculo_Fecha datetime
DECLARE @Espectaculo_Fecha_Venc datetime
DECLARE @Espectaculo_Rubro_Descripcion nvarchar (255)
DECLARE @Espectaculo_Estado nvarchar (255)
DECLARE @Ubicacion_Fila varchar (3)
DECLARE @Ubicacion_Asiento numeric (18,0)
DECLARE @Ubicacion_Sin_numerar bit 
DECLARE @Ubicacion_Precio numeric (18,0)
DECLARE @Ubicacion_Tipo_Codigo numeric (18,0)
DECLARE @Ubicacion_Tipo_Descripcion nvarchar (255)
DECLARE @Cli_Dni numeric (18,0)
DECLARE @Cli_Apeliido nvarchar (255)
DECLARE @Cli_Nombre nvarchar (255)
DECLARE @Cli_Fecha_Nac datetime
DECLARE @Cli_Mail nvarchar (255)
DECLARE @Cli_Dom_Calle nvarchar (255)
DECLARE @Cli_Nro_Calle numeric (18,0)
DECLARE @Cli_Piso numeric (18,0)
DECLARE @Cli_Depto nvarchar (255)
DECLARE @Cli_Cod_Postal nvarchar (255)
DECLARE @Compra_Fecha datetime
DECLARE @Compra_Cantidad numeric (18,0)
DECLARE @Item_Factura_Monto numeric (18,2)
DECLARE @Item_Factura_Cantidad numeric (18,0)
DECLARE @Item_Factura_Descripcion nvarchar (60)
DECLARE @Factura_Nro numeric (18,0)
DECLARE @Factura_Fecha datetime
DECLARE @Factura_Total numeric (18,2)
DECLARE @Forma_Pago_Desc nvarchar (255)

-- Creacion de cursor de migracion
DECLARE migration_cursor CURSOR FOR
SELECT  Espec_Empresa_Razon_Social,
		Espec_Empresa_Cuit,
		Espec_Empresa_Fecha_Creacion,
		Espec_Empresa_Mail,
		Espec_Empresa_Dom_Calle,
		Espec_Empresa_Nro_Calle,
		Espec_Empresa_Piso,
		Espec_Empresa_Depto,
		Espec_Empresa_Cod_Postal,
		Espectaculo_Cod,
		Espectaculo_Descripcion,
		Espectaculo_Fecha,
		Espectaculo_Fecha_Venc,
		Espectaculo_Rubro_Descripcion,
		Espectaculo_Estado,
		Ubicacion_Fila,
		Ubicacion_Asiento,
		Ubicacion_Sin_numerar,
		Ubicacion_Precio,
		Ubicacion_Tipo_Codigo,
		Ubicacion_Tipo_Descripcion,
		Cli_Dni,
		Cli_Apeliido,
		Cli_Nombre,
		Cli_Fecha_Nac,
		Cli_Mail,
		Cli_Dom_Calle,
		Cli_Nro_Calle,
		Cli_Piso,
		Cli_Depto,
		Cli_Cod_Postal,
		Compra_Fecha,
		Compra_Cantidad,
		Item_Factura_Monto,
		Item_Factura_Cantidad,
		Item_Factura_Descripcion,
		Factura_Nro,
		Factura_Fecha,
		Factura_Total,
		Forma_Pago_Desc
FROM gd_esquema.Maestra

-- Loop de migracion
OPEN migration_cursor
FETCH NEXT FROM migration_cursor INTO   @Espec_Empresa_Razon_Social,
										@Espec_Empresa_Cuit,
										@Espec_Empresa_Fecha_Creacion,
										@Espec_Empresa_Mail,
										@Espec_Empresa_Dom_Calle,
										@Espec_Empresa_Nro_Calle,
										@Espec_Empresa_Piso,
										@Espec_Empresa_Depto,
										@Espec_Empresa_Cod_Postal,
										@Espectaculo_Cod,
										@Espectaculo_Descripcion,
										@Espectaculo_Fecha,
										@Espectaculo_Fecha_Venc,
										@Espectaculo_Rubro_Descripcion,
										@Espectaculo_Estado,
										@Ubicacion_Fila,
										@Ubicacion_Asiento,
										@Ubicacion_Sin_numerar,
										@Ubicacion_Precio,
										@Ubicacion_Tipo_Codigo,
										@Ubicacion_Tipo_Descripcion,
										@Cli_Dni,
										@Cli_Apeliido,
										@Cli_Nombre,
										@Cli_Fecha_Nac,
										@Cli_Mail,
										@Cli_Dom_Calle,
										@Cli_Nro_Calle,
										@Cli_Piso,
										@Cli_Depto,
										@Cli_Cod_Postal,
										@Compra_Fecha,
										@Compra_Cantidad,
										@Item_Factura_Monto,
										@Item_Factura_Cantidad,
										@Item_Factura_Descripcion,
										@Factura_Nro,
										@Factura_Fecha,
										@Factura_Total,
										@Forma_Pago_Desc

WHILE @@FETCH_STATUS = 0  
BEGIN
	-- Migracion

	-- Migracion de empresas de espectaculo
	IF NOT EXISTS(	SELECT cuit from PEAKY_BLINDERS.Empresa 
					WHERE cuit=@Espec_Empresa_Cuit)
		INSERT INTO PEAKY_BLINDERS.Empresa VALUES (
			NULL							,
			@Espec_Empresa_Razon_Social		,
			@Espec_Empresa_Cuit				,
			@Espec_Empresa_Mail				,
			NULL							,
			@Espec_Empresa_Fecha_Creacion	,
			NULL							,
			@Espec_Empresa_Cod_Postal		,
			@Espec_Empresa_Dom_Calle		,
			@Espec_Empresa_Nro_Calle		,
			@Espec_Empresa_Piso				,
			@Espec_Empresa_Depto			
		)
	-- /Migracion de empresas de espectaculo
	--/Migracion
	FETCH NEXT FROM migration_cursor INTO   @Espec_Empresa_Razon_Social,
											@Espec_Empresa_Cuit,
											@Espec_Empresa_Fecha_Creacion,
											@Espec_Empresa_Mail,
											@Espec_Empresa_Dom_Calle,
											@Espec_Empresa_Nro_Calle,
											@Espec_Empresa_Piso,
											@Espec_Empresa_Depto,
											@Espec_Empresa_Cod_Postal,
											@Espectaculo_Cod,
											@Espectaculo_Descripcion,
											@Espectaculo_Fecha,
											@Espectaculo_Fecha_Venc,
											@Espectaculo_Rubro_Descripcion,
											@Espectaculo_Estado,
											@Ubicacion_Fila,
											@Ubicacion_Asiento,
											@Ubicacion_Sin_numerar,
											@Ubicacion_Precio,
											@Ubicacion_Tipo_Codigo,
											@Ubicacion_Tipo_Descripcion,
											@Cli_Dni,
											@Cli_Apeliido,
											@Cli_Nombre,
											@Cli_Fecha_Nac,
											@Cli_Mail,
											@Cli_Dom_Calle,
											@Cli_Nro_Calle,
											@Cli_Piso,
											@Cli_Depto,
											@Cli_Cod_Postal,
											@Compra_Fecha,
											@Compra_Cantidad,
											@Item_Factura_Monto,
											@Item_Factura_Cantidad,
											@Item_Factura_Descripcion,
											@Factura_Nro,
											@Factura_Fecha,
											@Factura_Total,
											@Forma_Pago_Desc
END

CLOSE migration_cursor  
DEALLOCATE migration_cursor