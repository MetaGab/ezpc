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
    public partial class checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario usuario = (Usuario)Session["usuario"];
            if (Session["usuario"] != null)
            {
                List<CarritoItem> carrito = CarritoControlador.ObtenerCarritoPorUsuario(usuario);
                lstProductos.DataSource = carrito;
                lstProductos.DataBind();
                litSubtotal.Text = carrito.Sum(i => i.Producto.precio_real * i.cantidad).ToString();
                litTotal.Text = (carrito.Sum(i => i.Producto.precio_real * i.cantidad)+50).ToString();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                List<Pais> paises = PaisControlador.ObtenerPaises();
                ddlPais.DataSource = paises;
                ddlPais.DataTextField = "nombre";
                ddlPais.DataValueField = "id";
                ddlPais.DataBind();
                ddlPais.Items.Insert(0, new ListItem("Selecciona...", "0"));
                ddlPaisEnvio.DataSource = paises;
                ddlPaisEnvio.DataTextField = "nombre";
                ddlPaisEnvio.DataValueField = "id";
                ddlPaisEnvio.DataBind();
                ddlPaisEnvio.Items.Insert(0, new ListItem("Selecciona...", "0"));
                ddlMetodos.DataSource = from x in MetodoPagoControlador.ObtenerMetodosPagoDeUsuario(usuario) select
                                        new { id = x.id, display = "Tarjeta que termina con " + x.numero_tarjeta.Substring(Math.Max(0, +x.numero_tarjeta.Length - 4))};
                ddlMetodos.DataTextField = "display";
                ddlMetodos.DataValueField = "id";
                ddlMetodos.DataBind();
                ddlDirecciones.DataSource = DireccionControlador.ObtenerDireccionesDeEnvioDeUsuario(usuario);
                ddlDirecciones.DataTextField = "direccion1";
                ddlDirecciones.DataValueField = "id";
                ddlDirecciones.DataBind();

                ddlDirecciones.Items.Insert(0, new ListItem("Selecciona...", "0"));
                ddlMetodos.Items.Insert(0, new ListItem("Selecciona...", "0"));
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
        protected void ddlPaisEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlEstadoEnvio.DataSource = PaisControlador.BuscarPaisPorID(Convert.ToInt32(ddlPaisEnvio.SelectedValue)).Estado.OrderBy(s => s.nombre);
                ddlEstadoEnvio.DataTextField = "nombre";
                ddlEstadoEnvio.DataValueField = "id";
                ddlEstadoEnvio.DataBind();

                ddlEstadoEnvio.Items.Insert(0, new ListItem("Selecciona...", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void ddlEstadoEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlCiudadEnvio.DataSource = EstadoControlador.BuscarEstadoPorID(Convert.ToInt32(ddlEstadoEnvio.SelectedValue)).Ciudad.OrderBy(s => s.nombre);
                ddlCiudadEnvio.DataTextField = "nombre";
                ddlCiudadEnvio.DataValueField = "id";
                ddlCiudadEnvio.DataBind();

                ddlCiudadEnvio.Items.Insert(0, new ListItem("Selecciona...", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void chkSame_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSame.Checked)
            {
                if (ddlMetodos.SelectedValue != "0")
                {
                    return;
                }
                txtApellido.Text = txtApellidoPago.Text;
                txtNombre.Text = txtNombrePago.Text;
                txtDireccion.Text = txtDireccionPago.Text;
                txtCP.Text = txtCPPago.Text;
                ddlPaisEnvio.Text = ddlPais.Text;
                ddlPaisEnvio_SelectedIndexChanged(sender, e);
                ddlEstadoEnvio.Text = ddlEstado.Text;
                ddlEstadoEnvio_SelectedIndexChanged(sender, e);
                ddlCiudadEnvio.Text = ddlCiudad.Text;
            }
            else
            {
                txtApellido.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text ="";
                txtCP.Text = "";
                ddlCiudadEnvio.SelectedIndex = 0;
                ddlCiudadEnvio.SelectedIndex = 0;
                ddlCiudadEnvio.SelectedIndex = 0;

            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usuario"];
                Orden orden = new Orden();
                if (ddlDirecciones.SelectedValue != "0" && !chkSame.Checked)
                {
                    orden.id_direccion = Convert.ToInt32(ddlDirecciones.SelectedValue);
                }
                else
                {
                    Direccion direccionEnvio = new Direccion();
                    direccionEnvio.codigo_postal = txtCP.Text;
                    direccionEnvio.direccion1 = txtDireccion.Text;
                    direccionEnvio.num_ext = "0";
                    direccionEnvio.id_ciudad = Convert.ToInt32(ddlCiudadEnvio.SelectedValue);
                    direccionEnvio.id_usuario = usuario.id;
                    orden.Direccion = direccionEnvio;
                }
                if (ddlMetodos.SelectedValue != "0")
                {
                    orden.id_pago = Convert.ToInt32(ddlMetodos.SelectedValue);
                    if (chkSame.Checked)
                    {
                        orden.id_direccion = MetodoPagoControlador.ObtenerMetodosPagoDeUsuario(usuario).Find(i => i.id == orden.id_pago).id_direccion;
                    }
                }
                else
                {
                    MetodoPago metodoPago = new MetodoPago();
                    Direccion direccionPago = new Direccion();
                    direccionPago.codigo_postal = txtCPPago.Text;
                    direccionPago.direccion1 = txtDireccionPago.Text;
                    direccionPago.num_ext = "0";
                    direccionPago.id_ciudad = Convert.ToInt32(ddlCiudad.SelectedValue);
                    direccionPago.id_usuario = usuario.id;
                    metodoPago.activo = true;
                    metodoPago.apellido = txtApellidoPago.Text;
                    metodoPago.codigo_postal = txtCPPago.Text;
                    metodoPago.Direccion = direccionPago;
                    metodoPago.fecha_vencimiento = DateTime.ParseExact(txtExpiracion.Text, "MM/y", null);
                    metodoPago.id_usuario = usuario.id;
                    metodoPago.nombre = txtNombrePago.Text;
                    metodoPago.numero_seguridad = txtNIP.Text;
                    metodoPago.numero_tarjeta = txtTarjeta.Text;
                    orden.MetodoPago = metodoPago;
                }

                List<CarritoItem> carrito = CarritoControlador.ObtenerCarritoPorUsuario(usuario);
                OrdenControlador.CrearOrden(orden, carrito, usuario);
                Response.Redirect("confirmacion.aspx");

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }

        }

        protected void ddlDirecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDirecciones.SelectedValue != "0")
            {
                pnlAddressForm.Visible = false;
            }
            else
            {
                pnlAddressForm.Visible = true;
            }
        }

        protected void ddlMetodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMetodos.SelectedValue != "0")
            {
                pnlPayForm.Visible = false;
            }
            else
            {
                pnlPayForm.Visible = true;
            }
        }
    }
}