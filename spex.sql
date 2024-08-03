select * from Compras.productos
select * from Compras.categorias

sp_listarProductos 
sp_listarCategorias

Create procedure sp_listarCategorias
as
begin
select * from Compras.categorias
end
go 

Create procedure sp_listarProductos
as
begin
select * from Compras.productos
end
go

CREATE PROCEDURE usp_ProductoCategoria 
@nomProducto varchar(40), 
@idCategoria int 
AS
BEGIN
    SELECT 
        p.IdProducto, 
        p.NomProducto, 
        pr.NomProveedor, 
        c.NombreCategoria, 
        p.CantxUnidad, 
        p.PrecioUnidad, 
        p.UnidadesEnExistencia, 
        p.UnidadesEnPedido
    FROM 
        Compras.productos p 
    INNER JOIN 
        Compras.categorias c ON p.IdCategoria = c.IdCategoria
    INNER JOIN 
        Compras.proveedores pr ON p.IdProveedor = pr.IdProveedor
    WHERE 
        p.NomProducto LIKE '%' + @nomProducto + '%' AND 
        c.IdCategoria = @idCategoria
    ORDER BY 
        p.IdProducto ASC
END
EXEC usp_ProductoCategoria @nomProducto = 'queso', @idCategoria = 4


-------------------------------------------------------------------

CREATE PROCEDURE  sp_ListarCategorias
AS
BEGIN
    SELECT IdCategoria, NombreCategoria
    FROM Compras.categorias
END
GO

exec procedure sp_ListarCategorias

 ------------------------------------------------------------------


CREATE PROCEDURE  usp_EmpleadosDistrito
    @idDistrito int
AS
BEGIN
    SELECT 
        e.IdEmpleado,
		e.ApeEmpleado,
		e.NomEmpleado,
		e.FecNac,
		e.DirEmpleado,
		d.nomDistrito,
		e.fonoEmpleado, 
		e.idCargo,
		e.FecContrata
    FROM 
       RRHH.empleados e
    INNER JOIN 
        RRHH.Distritos d ON e.idDistrito = d.idDistrito
    WHERE 
        d.idDistrito = @idDistrito;
END

exec usp_EmpleadosDistrito '2'

select * from RRHH.Cargos

-------------------------------------------------------

SELECT * FROM Compras.proveedores
SELECT * FROM Compras.categorias

------------------------------------


CREATE PROCEDURE  usp_EmpleadosDistrito 
@idDistrito int 
AS
BEGIN
    SELECT 
        e.IdEmpleado, 
        e.ApeEmpleado, 
        e.NomEmpleado, 
        e.FecNac, 
        e.DirEmpleado, 
        d.nomDistrito, 
        e.fonoEmpleado, 
        c.desCargo, 
        e.FecContrata
    FROM 
        RRHH.empleados e 
    INNER JOIN 
        RRHH.Distritos d ON e.idDistrito = d.idDistrito
    INNER JOIN 
        RRHH.Cargos c ON e.idCargo = c.idCargo
    WHERE 
        d.idDistrito = @idDistrito
END
