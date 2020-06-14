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
    public partial class confirmacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            if (Session["usuario"] != null)
            {
                Orden orden = OrdenControlador.ObtenerOrdenesDeUsuario(usuario).Last();
                litCiudad.Text = orden.Direccion.Ciudad.nombre;
                litCiudadPago.Text = orden.MetodoPago.Direccion.Ciudad.nombre;
                litCP.Text = orden.Direccion.codigo_postal;
                litCPPago.Text = orden.MetodoPago.Direccion.codigo_postal;
                litDireccion.Text = orden.Direccion.direccion1;
                litDireccionPago.Text = orden.MetodoPago.Direccion.direccion1;
                litFecha.Text = orden.fecha_compra.ToString();
                litOrdenID.Text = orden.id.ToString();
                litPago.Text = "Tarjeta que termina en " + orden.MetodoPago.numero_tarjeta.Substring(Math.Max(0, +orden.MetodoPago.numero_tarjeta.Length - 4));
                litPais.Text = orden.Direccion.Ciudad.Estado.Pais.nombre;
                litPaisPago.Text = orden.MetodoPago.Direccion.Ciudad.Estado.Pais.nombre;
                litSubtotal.Text = (orden.costo_total - 50).ToString();
                litTotal.Text = orden.costo_total.ToString();
                litTotal1.Text = orden.costo_total.ToString();
                lstItems.DataSource = orden.OrdenItem;
                lstItems.DataBind();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}