if OBJECT_ID('PEAKY_BLINDERS.crear_usuario', 'P') is not null
  drop procedure PEAKY_BLINDERS.crear_usuario;
if OBJECT_ID('PEAKY_BLINDERS.autenticar_usuario', 'P') is not null
  drop procedure PEAKY_BLINDERS.autenticar_usuario;
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
drop schema PEAKY_BLINDERS;
