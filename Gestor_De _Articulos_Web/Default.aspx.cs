using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using manager;
using dominio;
using System.Web.Services.Description;

namespace Gestor_De__Articulos_Web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloManager negocio = new ArticuloManager();
            ListaArticulos = negocio.listaParaImagenes();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListaArticulos;
                repRepetidor.DataBind();

            }
            
        }

        protected void btnAgregarAlCarrito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int articuloId = Convert.ToInt32(btn.CommandArgument);

            ArticuloManager negocio = new ArticuloManager();
            ListaArticulos = negocio.listaParaImagenes();

            
            List<Articulo> seleccionados;
            if (Session["Seleccionados"] == null)
            {
                seleccionados = new List<Articulo>();
            }
            else
            {
                seleccionados = (List<Articulo>)Session["Seleccionados"];
            }

            foreach (Articulo item in ListaArticulos)
            {
                if (articuloId == item.Id)
                {
                    seleccionados.Add(item);
                }
            }

           
            Session["Seleccionados"] = seleccionados;
        }
    }
}