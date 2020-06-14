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
    public partial class signup1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {

                Usuario nuevoUsuario = new Usuario();
                if (txtContraseña.Text != txtContraseñaConfirmar.Text)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Las contraseñas no coinciden');", true);
                }
                nuevoUsuario.email = txtEmail.Text;
                nuevoUsuario.contraseña = txtContraseña.Text;
                nuevoUsuario.nombre = txtNombre.Text;
                nuevoUsuario.primer_apellido = txtPrimerApellido.Text;
                nuevoUsuario.segundo_apellido = txtSegundoApellido.Text;
                nuevoUsuario.telefono = txtTelefono.Text;
                nuevoUsuario.activo = true;
                nuevoUsuario.id_tipo = 1;
                UsuarioControlador.CrearUsuario(nuevoUsuario);
                Session["usuario"] = UsuarioControlador.BuscarUsuarioPorEmail(nuevoUsuario.email);
                Response.Redirect("index.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }
    }
}