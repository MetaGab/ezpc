using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODELO;
using CONTROLADOR;

namespace VISTA.Include
{
    public partial class crud_prod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lstProds.DataSource = ProductoControlador.ObtenerProductos(rbtEstado.SelectedIndex == 0);
            lstProds.DataBind();
            if (!IsPostBack)
            {
                ddlCat.DataSource = CategoriaControlador.ObtenerCategorias(true);
                ddlCat.DataTextField = "nombre";
                ddlCat.DataValueField = "id";
                ddlCat.DataBind();
                ddlCat.Items.Insert(0, new ListItem("Selecciona...", "0"));
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                Producto producto = ProductoControlador.ObtenerProductoPorID(Convert.ToInt32(btn.Attributes["obj"]));
                txtDesc.Text = producto.descripcion;
                ddlCat.SelectedValue = producto.id_categoria.ToString();
                txtNombre.Text = producto.nombre;
                chkActivo.Checked = producto.activo;
                lblImagen.Text = producto.imagen;
                txtPrecio.Text = producto.precio.ToString();
                txtStock.Text = producto.stock.ToString();
                hdnProdId.Value = producto.id.ToString();
                lblModal.InnerText = "Editar";
                string javascript = "mostrarModal()";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javascript, true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "error('" + ex.Message + "');", true);
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                Producto producto = ProductoControlador.ObtenerProductoPorID(Convert.ToInt32(btn.Attributes["obj"]));
                ProductoControlador.EliminarProducto(producto);
                Page_Load(null, null);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "error('" + ex.Message + "');", true);
            }
        }

        protected void lbtGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = new Producto();
                
                producto.activo = true;
                producto.descripcion = txtDesc.Text;
                producto.id_categoria = Convert.ToInt32(ddlCat.SelectedValue);
                producto.nombre = txtNombre.Text;
                producto.activo = chkActivo.Checked;
                producto.precio = Convert.ToDecimal(txtPrecio.Text);
                producto.stock = Convert.ToInt32(txtStock.Text);
                if (fupImagen.HasFile && (System.IO.Path.GetExtension(fupImagen.FileName) == ".jpg" || System.IO.Path.GetExtension(fupImagen.FileName) == ".png"))
                {
                    fupImagen.SaveAs(Server.MapPath("~/Include/img/product/") + Server.HtmlEncode(fupImagen.FileName));
                    producto.imagen = Server.HtmlEncode(fupImagen.FileName);
                }
                else
                {
                    producto.imagen = lblImagen.Text;
                }
                if (hdnProdId.Value != "0")
                {
                    producto.id = Convert.ToInt32(hdnProdId.Value);
                    ProductoControlador.ModificarProducto(producto);
                }
                else
                {
                    ProductoControlador.InsertarProducto(producto);
                }
                Page_Load(null, null);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "error('" + ex.Message + "');", true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            txtDesc.Text = "";
            ddlCat.SelectedValue = "0";
            txtNombre.Text = "";
            lblImagen.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            hdnProdId.Value = "0";
            chkActivo.Checked = true;
            lblModal.InnerText = "Agregar";
            string javascript = "mostrarModal()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javascript, true);
            Page_Load(null, null);
        }
    }
}