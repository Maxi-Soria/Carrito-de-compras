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


        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloManager manager = new ArticuloManager();
            List<Articulo> lista = new List<Articulo>();
            lista = manager.listaParaImagenes();
            List<String> imagenes = new List<String>();

            Articulo elegido = new Articulo();
            

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                   
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    elegido = lista[id - 1];

                    cont.Text = id.ToString();

                    imagenes = elegido.Imagenes;

                }
                txtNombre.Text = elegido.Nombre;
                txtDescripcion.Text = elegido.Descripcion;
                txtImporte.Text = elegido.Precio.ToString();

                repDetalle.DataSource = imagenes;
                repDetalle.DataBind();
            }
        }


        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {



        }

    }
}