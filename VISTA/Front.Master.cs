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
    public partial class Front : System.Web.UI.MasterPage
    {
        public bool enSesion;
        public Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["usuario"];
            enSesion = usuario != null;
            if (enSesion)
            {
                lblNombre.Text = usuario.nombre;
            }
        }

        protected void lbtSalir_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("index.aspx");
        }
    }
}