using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MODELO;
using CONTROLADOR;
namespace VISTA
{
    public partial class carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                if (!IsPostBack)
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    List<CarritoItem> carrito = CarritoControlador.ObtenerCarritoPorUsuario(usuario);
                    lstCarrito.DataSource = carrito;
                    lstCarrito.DataBind();
                    lblTotal.Text = carrito.Sum(i => i.Producto.precio_real * i.cantidad).ToString();

                }
            }
            else
            {
                Response.Redirect("login.aspx?redirect=carrito.aspx");
            }
        }
        protected void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                HtmlButton btn = (HtmlButton)sender;
                CarritoItem  objCarritoItem = CarritoControlador.ObtenerCarritoItemPorID(Convert.ToInt32(btn.Attributes["product_id"]));
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario != null)
                {
                    objCarritoItem.cantidad--;
                    CarritoControlador.ModificarCarrito(usuario, objCarritoItem);
                    Response.Redirect("carrito.aspx");
                }
                else
                {
                    Response.Redirect("login.aspx?redirect=carrito.aspx");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "error('"+ex.Message+"');", true);
            }
        }

        protected void btnUp_Click(object sender, EventArgs e)
        {

            try
            {
                HtmlButton btn = (HtmlButton)sender;
                CarritoItem objCarritoItem = CarritoControlador.ObtenerCarritoItemPorID(Convert.ToInt32(btn.Attributes["product_id"]));
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario != null)
                {
                    objCarritoItem.cantidad++;
                    CarritoControlador.ModificarCarrito(usuario, objCarritoItem);
                    Response.Redirect("carrito.aspx");
                }
                else
                {

                    Response.Redirect("login.aspx?redirect=carrito.aspx");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "error('" + ex.Message + "');", true);
            }
        }

        protected void txtNumber_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                CarritoItem objCarritoItem = CarritoControlador.ObtenerCarritoItemPorID(Convert.ToInt32(txt.Attributes["product_id"]));
                Usuario usuario = (Usuario)Session["usuario"];
                if (usuario != null)
                {
                    objCarritoItem.cantidad = Convert.ToInt32(txt.Text);
                    CarritoControlador.ModificarCarrito(usuario, objCarritoItem);
                    Response.Redirect("carrito.aspx");
                }
                else
                {

                    Response.Redirect("login.aspx?redirect=carrito.aspx");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "error('" + ex.Message + "');", true);
            }

        }
    }
}