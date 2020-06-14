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

        }
    }
}