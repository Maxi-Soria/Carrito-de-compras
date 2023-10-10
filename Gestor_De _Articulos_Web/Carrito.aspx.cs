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
                    
                    decimal totalCarrito = CalcularTotalCarrito(seleccionados);
                    decimal totalCarrito1 = CalcularTotalCarrito(seleccionados);
                    lblTotalCarrito1.Text = "Total del Carrito1: $" + totalCarrito1.ToString("0.00");
                    lblTotalCarrito.Text = "Total del Carrito: $" + totalCarrito.ToString("0.00");

                }

            }
        }

        protected void btnEliminarDelCarrito_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int articuloId = Convert.ToInt32(btn.CommandArgument);

            List<Articulo> seleccionados;
            if (Session["Seleccionados"] != null) { seleccionados = (List<Articulo>)Session["Seleccionados"]; }
            else { seleccionados = new List<Articulo>();}

            List<Articulo> nuevaLista = new List<Articulo>();
            bool eliminado = false;

            foreach (var articulo in seleccionados)
            {
                if (!eliminado && articulo.Id == articuloId) { eliminado = true;}
                else { nuevaLista.Add(articulo); }
            }

            Session["Seleccionados"] = nuevaLista;

            repEliminar.DataSource = nuevaLista;
            repEliminar.DataBind();
        }


        protected void btnValidar_Click(object sender, EventArgs e)
        {
            string codigoIngresado = txtCodigo.Text.Trim();

            if (codigoIngresado == "GENTES")
            {
                List<Articulo> seleccionados;
                if (Session["Seleccionados"] != null)
                {
                    seleccionados = (List<Articulo>)Session["Seleccionados"];

                    decimal totalCarrito = CalcularTotalCarrito(seleccionados);

                    decimal descuento = totalCarrito * 0.30m;
                    decimal totalConDescuento = totalCarrito - descuento;

                    lblTotalCarrito.Text = "Total del Carrito con Descuento: $" + totalConDescuento.ToString("0.00");
                }
            }
            else
            {
                List<Articulo> seleccionados = (List<Articulo>)Session["Seleccionados"];
                decimal totalCarrito = CalcularTotalCarrito(seleccionados);
                lblTotalCarrito.Text = "Codigo no valido, total: $" + totalCarrito.ToString("0.00");
            }
        }






        private decimal CalcularTotalCarrito(List<Articulo> articulos)
        {
            decimal total = 0;

            foreach (var articulo in articulos)
            {
                total += articulo.Precio;
            }

            return total;
        }
    }
}