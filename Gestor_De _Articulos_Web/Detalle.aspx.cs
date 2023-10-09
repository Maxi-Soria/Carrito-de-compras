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
    public partial class Detalle : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloManager negocio = new ArticuloManager();

            ListaArticulos = negocio.listaParaImagenes();
            if (!IsPostBack)
            {
                repDetalle.DataSource = ListaArticulos;
                repDetalle.DataBind();

            }
        }


        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            int articuloId = Convert.ToInt32(btn.CommandArgument);

            ArticuloManager negocio = new ArticuloManager();
            ListaArticulos = negocio.listaParaImagenes();
            List<Articulo> detalle = new List<Articulo>();

            
            foreach (Articulo item in ListaArticulos)
            {
                if (articuloId == item.Id)
                {
                    detalle.Add(item);
                }
            }

           
            Session["Seleccionados"] = detalle;
            
        }
    }
}