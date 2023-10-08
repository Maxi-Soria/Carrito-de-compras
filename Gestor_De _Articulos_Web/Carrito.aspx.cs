using dominio;
using manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestor_De__Articulos_Web
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Seleccionados"] != null)
            {
                List<Articulo> seleccionados = (List<Articulo>)Session["Seleccionados"];

                if (!IsPostBack)
                {
                    repEliminar.DataSource = seleccionados;
                    repEliminar.DataBind();

                }

            }
        }

        protected void btnEliminarDelCarrito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int articuloId = Convert.ToInt32(btn.CommandArgument);

            
            List<Articulo> seleccionados;
            if (Session["Seleccionados"] == null)
            {
                seleccionados = new List<Articulo>();
            }
            else
            {
                seleccionados = (List<Articulo>)Session["Seleccionados"];
            }

           
            for (int i = seleccionados.Count - 1; i >= 0; i--)
            {
                if (articuloId == seleccionados[i].Id)
                {
                    seleccionados.RemoveAt(i);
                }
            }

            Session["Seleccionados"] = seleccionados;

        }
    }
}