using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Carrito
    {
        List<Articulo> listaDeArticulos;


        public void sumarArticuloACarrito(Articulo art)
        {
            listaDeArticulos.Add(art);
        }

    public int articulosEnCarrito()
    {
            return listaDeArticulos.Count();
        }
    }
    
}
