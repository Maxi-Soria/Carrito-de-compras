
CREATE PROCEDURE storedListar AS 
SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion 
AS ArticuloDescripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, I.ImagenUrl 
FROM ARTICULOS A, MARCAS M, CATEGORIAS C, IMAGENES I WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id AND A.Id = I.IdArticulo