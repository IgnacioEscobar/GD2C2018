create procedure PEAKY_BLINDERS.registrarCompra
@id_cliente int,
@id_medio_de_pago tinyint,
@id_presentacion int,
@id_publicacion int,
@id_ubicacion int,
@monto int
as
  begin
	declare @puntos as int
	declare @monto_a_cobrar as int

  -- Puntos que tiene
	set @puntos = (select sum(MP.variacion) from PEAKY_BLINDERS.movimientos_de_puntos MP
	where MP.fecha_vencimiento > GETDATE() and MP.id_cliente = @id_cliente)

  -- Si tiene 1000 mas se lleva entrada gratis
	if @puntos >= 1000
		set @monto_a_cobrar = 0;
    -- monto = 0 y se restan 1000 puntos
		insert into PEAKY_BLINDERS.movimientos_de_puntos (id_cliente, variacion, fecha, fecha_vencimiento)
		values (@id_cliente, -1000, GETDATE(), DATEADD(year, 100, GETDATE()));
	else
    -- mismo monto que cuesta la entrada
		set @monto_a_cobrar = @monto;

  -- registra compra con monto correspondiente, fecha actual y cantidad = 1
	insert into PEAKY_BLINDERS.compras (id_cliente, id_medio_de_pago, fecha, cantidad, id_presentacion, id_publicacion, id_ubicacion, monto)
	values (@id_cliente, @id_medio_de_pago, GETDATE(), 1, @id_presentacion, @id_publicacion, @id_ubicacion, @monto_a_cobrar);

  -- se suman 50 puntos por compra
	insert into PEAKY_BLINDERS.movimientos_de_puntos (id_cliente, variacion, fecha, fecha_vencimiento)
	values (@id_cliente, 50, GETDATE(), DATEADD(day, 15, GETDATE()));
  end
go