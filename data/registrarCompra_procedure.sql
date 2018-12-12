-- set @puntos = (select sum(MP.variacion) from PEAKY_BLINDERS.movimientos_de_puntos MP
-- 	where MP.fecha_vencimiento > GETDATE() and MP.id_cliente = @id_cliente)
-- insert into PEAKY_BLINDERS.movimientos_de_puntos (id_cliente, variacion, fecha_vencimiento)
-- 		values (@id_cliente, -1000, DATEADD(year, 100, GETDATE()));

create procedure PEAKY_BLINDERS.registrarCompra
@id_cliente int,
@id_medio_de_pago tinyint,
@id_presentacion int,
@id_publicacion int,
@id_ubicacion int,
@id_premio int,
@monto int
as
  begin
	declare @puntos as int
	declare @monto_a_cobrar as int
	declare @multiplicador_premio as decimal(2,2)
	set @multiplicador_premio = 1
	if @id_premio != -1
		set @multiplicador_premio = (select multiplicador from PEAKY_BLINDERS.premios P
		where P.id_cliente = @id_cliente and usado = 0 and P.id_premio = @id_premio)
  
	set @monto_a_cobrar = @monto * @multiplicador_premio
  -- registra compra con monto correspondiente, fecha actual y cantidad = 1
  insert into PEAKY_BLINDERS.compras (id_cliente, id_medio_de_pago, id_presentacion, id_publicacion, id_ubicacion, monto)
  values (@id_cliente, @id_medio_de_pago, @id_presentacion, @id_publicacion, @id_ubicacion, @monto_a_cobrar);

  update PEAKY_BLINDERS.premios
  set usado = 1
  where id_cliente = @id_cliente and id_premio = @id_premio

  -- se suman 50 puntos por compra
  insert into PEAKY_BLINDERS.movimientos_de_puntos (id_cliente, variacion)
  values (@id_cliente, 50);
  end
go