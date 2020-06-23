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
    public partial class usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lstUsuarios.DataSource = UsuarioControlador.BuscarUsuarioPorCriterios("", true);
            lstUsuarios.DataBind();
        }

        protected void btnTipo_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                Usuario usuario = UsuarioModelo.BuscarUsuarioPorID(Convert.ToInt32(btn.Attributes["obj"]));
                usuario.id_tipo = usuario.id_tipo == 1 ? 2 : 1;
                UsuarioControlador.ModificarUsuario(usuario);
                Page_Load(null, null);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "error('" + ex.Message + "');", true);
            }
        }
    }
}