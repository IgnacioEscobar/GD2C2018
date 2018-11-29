INSERT INTO PEAKY_BLINDERS.usuarios (nombre_de_usuario, password_hash, habilitado, intentos_fallidos)
VALUES ('admin', HASHBYTES ('SHA2_256', 'admin'), 1, 0)
GO

INSERT INTO PEAKY_BLINDERS.usuarios (nombre_de_usuario, password_hash, habilitado, intentos_fallidos)
VALUES ('cliente', HASHBYTES ('SHA2_256', 'cliente'), 1, 0)
GO

INSERT INTO PEAKY_BLINDERS.usuarios (nombre_de_usuario, password_hash, habilitado, intentos_fallidos)
VALUES ('empresa', HASHBYTES ('SHA2_256', 'empresa'), 1, 0)
GO


INSERT INTO PEAKY_BLINDERS.roles_por_usuario (id_usuario, id_rol)
VALUES (1, 2)
GO

INSERT INTO PEAKY_BLINDERS.roles_por_usuario (id_usuario, id_rol)
VALUES (2, 3)
GO

INSERT INTO PEAKY_BLINDERS.roles_por_usuario (id_usuario, id_rol)
VALUES (3, 1)