if OBJECT_ID('PEAKY_BLINDERS.autenticar_usuario', 'P') is not null
  drop procedure PEAKY_BLINDERS.autenticar_usuario;
if OBJECT_ID('PEAKY_BLINDERS.verificar_contrasenna', N'FN') is not null
  drop function PEAKY_BLINDERS.verificar_contrasenna;
if OBJECT_ID('PEAKY_BLINDERS.actualizar_contrasenna', 'P') is not null
  drop procedure PEAKY_BLINDERS.actualizar_contrasenna;
if OBJECT_ID('PEAKY_BLINDERS.actualizar_estado_usuario', 'P') is not null
  drop procedure PEAKY_BLINDERS.actualizar_estado_usuario;
if OBJECT_ID('PEAKY_BLINDERS.crear_cliente', 'P') is not null
  drop procedure PEAKY_BLINDERS.crear_cliente;
if OBJECT_ID('PEAKY_BLINDERS.modificar_cliente', 'P') is not null
  drop procedure PEAKY_BLINDERS.modificar_cliente;
if OBJECT_ID('PEAKY_BLINDERS.eliminar_cliente', 'P') is not null
  drop procedure PEAKY_BLINDERS.eliminar_cliente;
if OBJECT_ID('PEAKY_BLINDERS.cliente_habilitado', N'FN') is not null
  drop function PEAKY_BLINDERS.cliente_habilitado;
if OBJECT_ID('PEAKY_BLINDERS.crear_empresa', 'P') is not null
  drop procedure PEAKY_BLINDERS.crear_empresa;
if OBJECT_ID('PEAKY_BLINDERS.modificar_empresa', 'P') is not null
  drop procedure PEAKY_BLINDERS.modificar_empresa;
if OBJECT_ID('PEAKY_BLINDERS.eliminar_empresa', 'P') is not null
  drop procedure PEAKY_BLINDERS.eliminar_empresa;
if OBJECT_ID('PEAKY_BLINDERS.empresa_habilitada', N'FN') is not null
  drop function PEAKY_BLINDERS.empresa_habilitada;
if OBJECT_ID('PEAKY_BLINDERS.crear_rol', 'P') is not null
  drop procedure PEAKY_BLINDERS.crear_rol;
if OBJECT_ID('PEAKY_BLINDERS.modificar_rol', 'P') is not null
  drop procedure PEAKY_BLINDERS.modificar_rol;
if OBJECT_ID('PEAKY_BLINDERS.actualizar_rol_habilitado', 'P') is not null
  drop procedure PEAKY_BLINDERS.actualizar_rol_habilitado;
if OBJECT_ID('PEAKY_BLINDERS.borrar_funcionalidades_por_rol', 'P') is not null
  drop procedure PEAKY_BLINDERS.borrar_funcionalidades_por_rol;
if OBJECT_ID('PEAKY_BLINDERS.actualizar_funcionalidades_por_rol', 'P') is not null
  drop procedure PEAKY_BLINDERS.actualizar_funcionalidades_por_rol;
if OBJECT_ID('PEAKY_BLINDERS.generar_publicacion', 'P') is not null
  drop procedure PEAKY_BLINDERS.generar_publicacion;
if OBJECT_ID('PEAKY_BLINDERS.modificar_publicacion', 'P') is not null
  drop procedure PEAKY_BLINDERS.modificar_publicacion;
  if OBJECT_ID('PEAKY_BLINDERS.finalizar_publicacion', 'P') is not null
  drop procedure PEAKY_BLINDERS.finalizar_publicacion;
if OBJECT_ID('PEAKY_BLINDERS.generar_presentacion', 'P') is not null
  drop procedure PEAKY_BLINDERS.generar_presentacion;
if OBJECT_ID('PEAKY_BLINDERS.generar_ubicacion', 'P') is not null
  drop procedure PEAKY_BLINDERS.generar_ubicacion;
if OBJECT_ID('PEAKY_BLINDERS.actualizar_grado', 'P') is not null
  drop procedure PEAKY_BLINDERS.actualizar_grado;
if OBJECT_ID('PEAKY_BLINDERS.items', 'U') is not null
  drop table PEAKY_BLINDERS.items;
if OBJECT_ID('PEAKY_BLINDERS.compras', 'U') is not null
  drop table PEAKY_BLINDERS.compras;
if OBJECT_ID('PEAKY_BLINDERS.ubicaciones', 'U') is not null
  drop table PEAKY_BLINDERS.ubicaciones;
if OBJECT_ID('PEAKY_BLINDERS.tipos_de_ubicacion', 'U') is not null
  drop table PEAKY_BLINDERS.tipos_de_ubicacion;
if OBJECT_ID('PEAKY_BLINDERS.facturas', 'U') is not null
  drop table PEAKY_BLINDERS.facturas;
if OBJECT_ID('PEAKY_BLINDERS.medios_de_pago', 'U') is not null
  drop table PEAKY_BLINDERS.medios_de_pago;
if OBJECT_ID('PEAKY_BLINDERS.movimientos_de_puntos', 'U') is not null
  drop table PEAKY_BLINDERS.movimientos_de_puntos;
if OBJECT_ID('PEAKY_BLINDERS.clientes', 'U') is not null
  drop table PEAKY_BLINDERS.clientes;
if OBJECT_ID('PEAKY_BLINDERS.funcionalidades_por_rol', 'U') is not null
  drop table PEAKY_BLINDERS.funcionalidades_por_rol;
if OBJECT_ID('PEAKY_BLINDERS.funcionalidades', 'U') is not null
  drop table PEAKY_BLINDERS.funcionalidades;
if OBJECT_ID('PEAKY_BLINDERS.roles_por_usuario', 'U') is not null
  drop table PEAKY_BLINDERS.roles_por_usuario;
if OBJECT_ID('PEAKY_BLINDERS.roles', 'U') is not null
  drop table PEAKY_BLINDERS.roles;
if OBJECT_ID('PEAKY_BLINDERS.tipos_de_documento', 'U') is not null
  drop table PEAKY_BLINDERS.tipos_de_documento;
if OBJECT_ID('PEAKY_BLINDERS.presentaciones', 'U') is not null
  drop table PEAKY_BLINDERS.presentaciones;
if OBJECT_ID('PEAKY_BLINDERS.publicaciones', 'U') is not null
  drop table PEAKY_BLINDERS.publicaciones;
if OBJECT_ID('PEAKY_BLINDERS.grados', 'U') is not null
  drop table PEAKY_BLINDERS.grados;
if OBJECT_ID('PEAKY_BLINDERS.rubros', 'U') is not null
  drop table PEAKY_BLINDERS.rubros;
if OBJECT_ID('PEAKY_BLINDERS.estados', 'U') is not null
  drop table PEAKY_BLINDERS.estados;
if OBJECT_ID('PEAKY_BLINDERS.empresas', 'U') is not null
  drop table PEAKY_BLINDERS.empresas;
if OBJECT_ID('PEAKY_BLINDERS.usuarios', 'U') is not null
  drop table PEAKY_BLINDERS.usuarios;
-- Drops schema
drop schema PEAKY_BLINDERS;
