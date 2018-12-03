DELETE FROM PEAKY_BLINDERS.roles_por_usuario;
DELETE FROM PEAKY_BLINDERS.usuarios;
GO

DBCC CHECKIDENT ('PEAKY_BLINDERS.usuarios', RESEED, 0);
DBCC CHECKIDENT ('PEAKY_BLINDERS.roles_por_usuario', RESEED, 0);
GO

SET IDENTITY_INSERT PEAKY_BLINDERS.usuarios ON;
INSERT INTO PEAKY_BLINDERS.usuarios (id_usuario, nombre_de_usuario, password_hash, habilitado, intentos_fallidos) VALUES
	(1, 'admin', HASHBYTES ('SHA2_256', 'admin'), 1, 0),
	(2, 'cliente', HASHBYTES ('SHA2_256', 'cliente'), 1, 0),
	(3, 'empresa', HASHBYTES ('SHA2_256', 'empresa'), 1, 0)
SET IDENTITY_INSERT PEAKY_BLINDERS.usuarios OFF;
GO

INSERT INTO PEAKY_BLINDERS.roles_por_usuario (id_usuario, id_rol) VALUES
	(1, 1),
	(2, 2),
	(3, 3)