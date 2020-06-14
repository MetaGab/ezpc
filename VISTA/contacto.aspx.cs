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
    public partial class contacto1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlPais.DataSource = PaisControlador.ObtenerPaises();
                ddlPais.DataTextField = "nombre";
                ddlPais.DataValueField = "id";
                ddlPais.DataBind();
                ddlPais.Items.Insert(0, new ListItem("Selecciona...", "0"));
            }
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlEstado.DataSource = PaisControlador.BuscarPaisPorID(Convert.ToInt32(ddlPais.SelectedValue)).Estado.OrderBy(s => s.nombre);
                ddlEstado.DataTextField = "nombre";
                ddlEstado.DataValueField = "id";
                ddlEstado.DataBind();

                ddlEstado.Items.Insert(0, new ListItem("Selecciona...", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlCiudad.DataSource = EstadoControlador.BuscarEstadoPorID(Convert.ToInt32(ddlEstado.SelectedValue)).Ciudad.OrderBy(s => s.nombre);
                ddlCiudad.DataTextField = "nombre";
                ddlCiudad.DataValueField = "id";
                ddlCiudad.DataBind();

                ddlCiudad.Items.Insert(0, new ListItem("Selecciona...", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                Contacto contacto = new Contacto();
                contacto.id_ciudad = Convert.ToInt32(ddlCiudad.SelectedValue);
                contacto.email = txtCorreo.Text;
                contacto.direccion = txtAddress.Text;
                contacto.nombre = txtNombre.Text;
                contacto.num_ext = txtNumExterior.Text;
                contacto.primer_apellido = txtApellido1.Text;
                contacto.segundo_apellido = txtApellido2.Text;
                contacto.sugerencia = txtSugerencia.Text;
                contacto.telefono = txtTelefono.Text;
                ContactoControlador.CrearContacto(contacto);
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Mensaje enviado');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }
    }
}