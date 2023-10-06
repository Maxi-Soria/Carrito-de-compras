using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public Articulo()
        {
            Id = 0;
            Codigo = "";
            Nombre = "";
            Descripcion = "";
            Marca = new Marca();
            Categoria = new Categoria();
            Imagen = "";
            Precio = 0;
        }

        public Articulo(string codigoArt, string nombreArt, string descripcionArt, Marca marcaArt, Categoria categoriaArt, string imagenes, decimal precio)
        {
            Codigo = codigoArt;
            Nombre = nombreArt;
            Descripcion = descripcionArt;
            Marca = marcaArt;
            Categoria = categoriaArt;
            Imagen = imagenes;
            Precio = precio;
        }
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }

        public List<string> Imagenes { get; set; }

        public string Imagen { get; set; }
        public decimal Precio { get; set; }

    }
}
