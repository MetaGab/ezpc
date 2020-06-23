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
    public partial class producto : System.Web.UI.Page
    {
        Producto product;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (id != null)
            {
                product = ProductoControlador.ObtenerProductoPorID(Convert.ToInt32(id));
                if (product != null)
                {
                    lblNombreBreadcrumb.Text = product.nombre;
                    lblNombreBanner.Text = product.nombre;
                    lblNombreContenido.Text = product.nombre;
                    litDescripcion.Text = product.descripcion;
                    lblPrecio.Text = product.precio_real.ToString();
                    if (product.precio_real != product.precio)
                    {
                        litOriginal.Visible = true;
                        litOriginal.Text = "$ "+product.precio.ToString();
                    }
                    if (product.stock > 0)
                    {
                        lblDisponibilidad.Text = "En Stock";
                    }
                    else
                    {
                        lblDisponibilidad.Text = "Agotado";
                    }
                    lblCategoria.Text = product.Categoria.nombre;
                    imgProduct.ImageUrl = "Include/img/product/" + product.imagen;
                }
                else
                {
                    Response.Redirect("tienda.aspx");
                }
            }
            else
            {
                Response.Redirect("tienda.aspx");
            }
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                CarritoItem objCarritoItem = new CarritoItem();
                objCarritoItem.cantidad = Convert.ToInt32(txtNumber.Text);
                string id = Request.QueryString["id"];
                objCarritoItem.id_producto = Convert.ToInt32(id);
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario != null)
                {
                    objCarritoItem.id_usuario = usuario.id;
                    CarritoControlador.CrearCarritoItem(objCarritoItem);
                }
                else
                {

                    Response.Redirect("login.aspx?redirect=producto.aspx?id=" + Request.QueryString["id"]);
                }
                Response.Redirect("carrito.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "error('" + ex.Message + "');", true);
            }
        }

    }
}