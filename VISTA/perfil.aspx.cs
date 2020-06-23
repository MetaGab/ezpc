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
    public partial class perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario == null)
                {
                    Response.Redirect("login.aspx?redirect=perfil.aspx");
                    return;
                }
                litEmail.Text = usuario.email;
                litNombre.Text = String.Format("{0} {1} {2}", usuario.nombre, usuario.primer_apellido, usuario.segundo_apellido);
                litTelefono.Text = usuario.telefono;
                txtNombre.Text = usuario.nombre;
                txtCorreo.Text = usuario.email;
                txtPrimerApellido.Text = usuario.primer_apellido;
                txtSegundoApellido.Text = usuario.segundo_apellido;
                txtTelefono.Text = usuario.telefono;
                lstOrdenes.DataSource = OrdenControlador.ObtenerOrdenesDeUsuario(usuario);
                lstOrdenes.DataBind();

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                Usuario usuario = (Usuario)Session["usuario"];
                usuario.telefono = txtTelefono.Text;
                usuario.nombre = txtNombre.Text;
                usuario.primer_apellido = txtPrimerApellido.Text;
                usuario.segundo_apellido = txtSegundoApellido.Text;
                usuario.email = txtCorreo.Text;
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