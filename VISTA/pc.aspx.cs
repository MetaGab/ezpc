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
    public partial class pc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lstCategorias.DataSource = CategoriaControlador.ObtenerCategorias(true);
            lstCategorias.DataBind();

        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            string values = hdnValues.Value;

            Usuario usuario = (Usuario)Session["usuario"];
            if (usuario == null) { 
                Response.Redirect("login.aspx?redirect=pc.aspx");
                return;
            }
            foreach (string value in values.Split(','))
            {
                CarritoItem objCarritoItem = new CarritoItem();
                objCarritoItem.cantidad = 1;
                objCarritoItem.id_producto = Convert.ToInt32(value);
                objCarritoItem.id_usuario = usuario.id;
                CarritoControlador.CrearCarritoItem(objCarritoItem);
            }
            Response.Redirect("carrito.aspx");
        }
    }
}