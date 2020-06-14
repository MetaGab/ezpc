using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODELO;
using CONTROLADOR;

namespace VISTA
{
    public partial class Back : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            if (usuario == null || usuario.TipoUsuario.nombre != "Administrador")
            {
                Response.Redirect("index.aspx");
            }
            lblUsuario.Text = usuario.nombre + usuario.primer_apellido;
            
        }
    }
}