﻿using System;
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

                     
                     contadorCarrito.Text = cantidadArticulos.ToString();

                    
                    int cantidadEnCarrito = ObtenerCantidadCarrito(); 

                    contadorCarrito.Text = cantidadEnCarrito.ToString();
                }
            }

           
        }
       
        public static int ObtenerCantidadCarrito()
        {
            if (HttpContext.Current.Session["Seleccionados"] != null)
            {
                List<Articulo> seleccionados = (List<Articulo>)HttpContext.Current.Session["Seleccionados"];
                return seleccionados.Count;
            }
            else
            {
                return 0;
            }
        }


    }
}