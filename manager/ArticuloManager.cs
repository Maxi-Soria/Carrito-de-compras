using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace manager
{
    public class ArticuloManager
    {
        private List<Articulo> lista = new List<Articulo>();
        private List<Categoria> listaCategorias = new List<Categoria>();
        private List<Marca> listaMarcas = new List<Marca>();
        private SqlConnection conexion;
        public SqlCommand comando;
        private SqlDataReader lector;
       

        public ArticuloManager()
        {
            AccesoDatos conexion = new AccesoDatos();
            //conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true");
            comando = new SqlCommand();
        }

        public List<Articulo> ListarArticulos()
        {
            List<Articulo> lista = new List<Articulo> ();
            AccesoDatos datos = new AccesoDatos ();

            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion AS ArticuloDescripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, I.ImagenUrl FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int) datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["ArticuloDescripcion"];


                    if (!Convert.IsDBNull(datos.Lector["Marca"]))
                    {
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    else
                    {
                        aux.Marca.Descripcion = "" ;
                    }

                    if (!Convert.IsDBNull(datos.Lector["Categoria"]))
                    {
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    else{
                        aux.Categoria.Descripcion = "https://images.samsung.com/is/image/samsung/co-galaxy-s10-sm-g970-sm-g970fzyjcoo-frontcanaryyellow-thumb-149016542"; 
                    }
                                                

                    aux.Precio = (decimal)datos.Lector["Precio"];

                    if (!Convert.IsDBNull(datos.Lector["ImagenUrl"]))
                    {
                        aux.Imagen = (string)datos.Lector["ImagenUrl"];

                    }
                    else
                    {
                        aux.Imagen = "https://www.timandorra.com/wp-content/uploads/2016/11/Imagen-no-disponible-282x300.png";
                    }

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> ListarArticulosConSP()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {

                //string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion AS ArticuloDescripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, I.ImagenUrl FROM ARTICULOS A, MARCAS M, CATEGORIAS C, IMAGENES I WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id AND A.Id = I.IdArticulo";
                //datos.setearConsulta(consulta);

                datos.setearProcedimiento("storedListar");


                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["ArticuloDescripcion"];


                    if (!Convert.IsDBNull(datos.Lector["Marca"]))
                    {
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    else
                    {
                        aux.Marca.Descripcion = "";
                    }

                    if (!Convert.IsDBNull(datos.Lector["Categoria"]))
                    {
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    else
                    {
                        aux.Categoria.Descripcion = "https://images.samsung.com/is/image/samsung/co-galaxy-s10-sm-g970-sm-g970fzyjcoo-frontcanaryyellow-thumb-149016542";
                    }

                    aux.Precio = (decimal)datos.Lector["Precio"];

                    if (!Convert.IsDBNull(datos.Lector["ImagenUrl"]))
                    {
                        aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    }

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> ListarCodigoArticulo()
        {
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, Precio, ImagenUrl FROM ARTICULOS A, MARCAS M , CATEGORIAS C, IMAGENES I WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id AND I.IdArticulo = A.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                
                    aux.Precio = (decimal)lector["Precio"];
                   

                    lista.Add(aux);
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Articulo> buscarArticulo(string buscar)
        {
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Id, Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio FROM ARTICULOS WHERE Codigo LIKE @Codigo";
                comando.Parameters.AddWithValue("@Codigo", "%" + buscar + "%");
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                List<Articulo> lista = new List<Articulo>();

                while (lector.Read())
                {
                    string codigoArticulo = (string)lector["Codigo"];

                    
                    if (codigoArticulo.Contains(buscar))
                    {
                        Articulo aux = new Articulo();
                        aux.Codigo = codigoArticulo;
                        aux.Nombre = (string)lector["Nombre"];
                        aux.Descripcion = (string)lector["Descripcion"];
                        aux.Marca.Id = (int)lector["IdMarca"];
                        aux.Categoria.Id = (int)lector["IdCategoria"];
                        aux.Precio = (decimal)lector["Precio"];

                        lista.Add(aux);
                    }
                }

                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setearConsulta(string query)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = query;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            
            try
            {
                conexion.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre,valor);
        }

        public void agregarArticulo(dominio.Articulo nuevoArticulo)
        {

            try
            {
                setearConsulta("INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES (@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@Precio)");

                setearParametro("@Codigo", nuevoArticulo.Codigo);
                setearParametro("@Nombre", nuevoArticulo.Nombre);
                setearParametro("@Descripcion", nuevoArticulo.Descripcion);
                setearParametro("@IdMarca", nuevoArticulo.Marca.Id);
                setearParametro("@IdCategoria", nuevoArticulo.Categoria.Id);
                setearParametro("@Precio", nuevoArticulo.Precio);
                

                conexion.Close();
                ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }
 
        public void agregarImagen(Articulo nuevoArticulo)
        {

            Articulo articulo = new Articulo();
            articulo = ListarArticulos().Last();
            
            try
            {
                
                
                int idArticulo = articulo.Id;
                setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                setearParametro("@IdArticulo", idArticulo);
                setearParametro("@ImagenUrl", nuevoArticulo.Imagen);

                conexion.Close();
                ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();
            }

        }

        public bool verificadorDeCodigos(string codigo)
    {
        List<Articulo> lista = new List<Articulo>();
        AccesoDatos datos = new AccesoDatos();
            
            
        try
        {
             
            datos.setearConsulta("SELECT COUNT(*) FROM ARTICULOS WHERE Codigo = @Codigo");
            datos.comando.Parameters.AddWithValue("@Codigo", codigo);
            datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int count = datos.Lector.GetInt32(0);
                    return count > 0;
                }
                else
                {
                    return false;
                }

        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

        public void eliminarArticulo(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id = @Id");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarArticulo(Articulo articulo)
        {

            try
            {
                setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Precio = @Precio, Descripcion = @Descripcion WHERE Id = @Id");
                setearParametro("@Id", articulo.Id);
                setearParametro("@Codigo", articulo.Codigo);
                setearParametro("@Nombre", articulo.Nombre);
                setearParametro("@Descripcion", articulo.Descripcion);
                setearParametro("@Precio", articulo.Precio);
                conexion.Close();
                ejecutarAccion();

                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
        public void modificarCategoriaArticulo(Articulo articulo)
        {
            try
            {
                setearConsulta("UPDATE ARTICULOS SET IdCategoria = @IdCategoria WHERE Id = @IdArticulo");
                setearParametro("@IdArticulo", articulo.Id);
                setearParametro("@IdCategoria", articulo.Categoria.Id);
                conexion.Close();
                ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarMarcaArticulo(Articulo articulo)
        {
            try
            {
                setearConsulta("UPDATE ARTICULOS SET IdMarca = @IdMarca WHERE Id = @IdArticulo");
                setearParametro("@IdArt", articulo.Id);
                setearParametro("@IdMarca", articulo.Marca.Id);
                conexion.Close();
                ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarImagenArticulo(Articulo articulo)
        {
            try
            {
                setearConsulta("UPDATE IMAGENES SET ImagenUrl = @ImagenUrl WHERE Id = (SELECT TOP 1 Id FROM IMAGENES WHERE IdArticulo = @IdA)");
                setearParametro("@IdA", articulo.Id);
                setearParametro("@ImagenUrl", articulo.Imagen);
                conexion.Close();
                ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
               
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion AS ArticuloDescripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, I.ImagenUrl FROM ARTICULOS A, MARCAS M, CATEGORIAS C, IMAGENES I WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id AND A.Id = I.IdArticulo AND ";
                
                switch (campo)
                {
                    case "Codigo":
                        switch (criterio)
                        {
                            case "Comienza con": consulta += "A.Codigo LIKE '" + filtro + "%' ";
                                break;
                            case "Termina con": consulta += "A.Codigo LIKE '%" + filtro + "'";
                                break;
                            case "Contiene": consulta += "A.Codigo LIKE '%" + filtro + "%'";
                                break;                           
                        }
                        break;
                    case "Marca":
                        switch (criterio)
                        {
                            case "Comienza con": consulta += "M.Descripcion LIKE '" + filtro + "%' ";
                                break;
                            case "Termina con": consulta += "M.Descripcion LIKE '%" + filtro + "'";
                                break;
                            case "Contiene": consulta += "M.Descripcion LIKE '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Categoria":
                        switch (criterio)
                        {
                            case "Comienza con": consulta += "C.Descripcion LIKE '" + filtro + "%' ";
                                break;
                            case "Termina con": consulta += "C.Descripcion LIKE '%" + filtro + "'";
                                break;
                            case "Contiene": consulta += "C.Descripcion LIKE '%" + filtro + "%'";
                                break;
                        }
                        break;
                }
               

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["ArticuloDescripcion"];


                    if (!Convert.IsDBNull(datos.Lector["Marca"]))
                    {
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    else
                    {
                        aux.Marca.Descripcion = "";
                    }

                    if (!Convert.IsDBNull(datos.Lector["Categoria"]))
                    {
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    else
                    {
                        aux.Categoria.Descripcion = "https://images.samsung.com/is/image/samsung/co-galaxy-s10-sm-g970-sm-g970fzyjcoo-frontcanaryyellow-thumb-149016542";
                    }

                    aux.Precio = (decimal)datos.Lector["Precio"];

                    if (!Convert.IsDBNull(datos.Lector["ImagenUrl"]))
                    {
                        aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    }

                    lista.Add(aux);
                }

            return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Articulo> listaParaImagenes()
        {
            List<Articulo> listaArticulos = ListarArticulosConSP();

            if (listaArticulos != null && listaArticulos.Count > 0)
            {
                Dictionary<string, Articulo> diccionarioArticulos = new Dictionary<string, Articulo>();

                foreach (var articulo in listaArticulos)
                {
                    if (!diccionarioArticulos.ContainsKey(articulo.Codigo))
                    {
                        diccionarioArticulos.Add(articulo.Codigo, articulo);
                        articulo.Imagenes = new List<string>();
                    }
                    diccionarioArticulos[articulo.Codigo].Imagenes.Add(articulo.Imagen);
                }

                List<Articulo> listaParaDgv = diccionarioArticulos.Values.ToList();
                return listaParaDgv;
            }
            else
            {
                return new List<Articulo>(); 
            }
        }



    }

}


