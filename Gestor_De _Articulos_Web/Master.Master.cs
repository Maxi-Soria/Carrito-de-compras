using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using manager;
using Gestor_De__Articulos_Web;

namespace Gestor_De__Articulos_Web
{
    public partial class Master : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Seleccionados"] != null)
                {
                    List<Articulo> seleccionados = (List<Articulo>)Session["Seleccionados"];
                    int cantidadArticulos = seleccionados.Count;

                     //Actualizar el enlace contadorCarrito con la cantidad de artículos
                     contadorCarrito.Text = cantidadArticulos.ToString();
                }
            }
        }
    }
}