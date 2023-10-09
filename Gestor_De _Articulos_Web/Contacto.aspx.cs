using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gestor_De__Articulos_Web
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            
            lblMensajeConfirmacion.Text = "Mensaje enviado. Gracias por contactarse con nosotros.";
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtMensaje.Text = "";
        }
    }
}