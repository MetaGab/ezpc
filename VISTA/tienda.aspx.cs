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
    public partial class tienda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstCategorias.DataSource = CategoriaControlador.ObtenerCategorias(true);
                lstCategorias.DataBind();
            }
            string categoria = Request.QueryString["cat"];
            string oferta = Request.QueryString["ofertas"];
            if (categoria != null)
            {
                lstProductos.DataSource = ProductoControlador.ObtenerProductosPorCategoria(categoria);
            }
            else if (oferta != null)
            {
                lstProductos.DataSource = ProductoControlador.ObtenerProductos(true).Where(p => p.Oferta.Count > 0 && p.Oferta.First().expiracion > DateTime.Now).ToList();
            }
            else
            {
                lstProductos.DataSource = ProductoControlador.ObtenerProductos(true);
            }
            lstProductos.DataBind();
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

                    Response.Redirect("login.aspx?redirect=tienda.aspx");
                }
                Response.Redirect("carrito.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "error('" + ex.Message + "');", true);
            }
        }


        protected void tpfPage_PagerCommand(object sender, DataPagerCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Next":
                    e.NewStartRowIndex = e.Item.Pager.StartRowIndex + e.Item.Pager.PageSize;
                    e.NewMaximumRows = e.Item.Pager.MaximumRows;
                    break;
                case "Prev":
                    e.NewStartRowIndex = e.Item.Pager.StartRowIndex - e.Item.Pager.PageSize;
                    e.NewMaximumRows = e.Item.Pager.MaximumRows;
                    break;
            }
        }

        protected void lstProductos_PagePropertiesChanged(object sender, EventArgs e)
        {
            lstProductos.DataBind();
        }

        protected void ddlPage2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPage.SelectedIndex = ddlPage2.SelectedIndex;
            dpgPage2.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            dpgTienda.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
        }

        protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlPage2.SelectedIndex = ddlPage.SelectedIndex;
            dpgPage2.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
            dpgTienda.PageSize = Convert.ToInt32(ddlPage.SelectedValue);
        }

        protected void ddlOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrder.SelectedValue != "0")
            {
                switch (ddlOrder.SelectedValue)
                {
                    case "1":
                        lstProductos.DataSource = ((List<Producto>)lstProductos.DataSource).OrderBy(i => i.nombre).ToList();
                        break;
                    case "3":
                        lstProductos.DataSource = ((List<Producto>)lstProductos.DataSource).OrderBy(i => i.precio).ToList();
                        break;
                    case "2":
                        lstProductos.DataSource = ((List<Producto>)lstProductos.DataSource).OrderBy(i => i.precio).Reverse().ToList();
                        break;
                    default:
                        break;
                }
                lstProductos.DataBind();
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            decimal min = Convert.ToDecimal(hdnMin.Value);
            decimal max = Convert.ToDecimal(hdnMax.Value);
            lstProductos.DataSource = ((List<Producto>)lstProductos.DataSource).Where(i =>max >= i.precio && i.precio >= min).ToList();
            lstProductos.DataBind();
        }
    }
}