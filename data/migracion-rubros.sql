create table rubros (
  id_rubro int PRIMARY KEY NOT NULL IDENTITY(1,1),
  descripcion nvarchar(256)
)

insert into rubros (descripcion)
select distinct Espectaculo_Rubro_Descripcion
from gd_esquema.Maestra

-- hay un solo rubro y no tiene descripcion