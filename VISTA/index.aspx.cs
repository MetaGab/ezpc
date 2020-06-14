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
    public partial class index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            lstNewProd.DataSource = ProductoControlador.ObtenerProductos().OrderBy(i => rnd.Next()).Take(8);
            lstNewProd.DataBind();
            Producto prod = ProductoControlador.ObtenerProductos().Where(p => p.Oferta.Count > 0).OrderBy(p => p.Oferta.First().expiracion).First();
            imgProducto.ImageUrl = "~/Include/img/product/" + prod.imagen;
            lbtAñadir.CommandArgument = prod.id.ToString();
            lblNombre.Text = prod.nombre;
            lblPrecio.Text = "$" + prod.precio_real;
            lblOriginal.Text = "$" + prod.precio;
            litFecha.Text = '"' + prod.Oferta.First().expiracion.ToString("MMMM dd, yyyy") +'"';
            lstOfertas.DataSource = ProductoControlador.ObtenerProductos().Where(p => p.Oferta.Count > 0);
            lstOfertas.DataBind();
        }

        protected void lbtAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lbt = (LinkButton)sender;
                CarritoItem objCarritoItem = new CarritoItem();
                objCarritoItem.cantidad = 1;
                objCarritoItem.id_producto = Convert.ToInt32(lbt.CommandArgument);
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario != null)
                {
                    objCarritoItem.id_usuario = usuario.id;
                    CarritoControlador.CrearCarritoItem(objCarritoItem);
                }
                else
                {

                    Response.Redirect("login.aspx");
                }
                Response.Redirect("carrito.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }
    }
}