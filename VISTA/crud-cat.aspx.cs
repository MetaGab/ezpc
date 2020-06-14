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
    public partial class crud_cat : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstCats.DataSource = CategoriaControlador.ObtenerCategorias();
                lstCats.DataBind();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                Categoria categoria = CategoriaControlador.ObtenerCategoriaPorID(Convert.ToInt32(btn.Attributes["obj"]));
                hdnProdId.Value = categoria.id.ToString();
                txtNombre.Text = categoria.nombre;
                chkActivo.Checked = categoria.activo;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                Categoria categoria = CategoriaControlador.ObtenerCategoriaPorID(Convert.ToInt32(btn.Attributes["obj"]));
                CategoriaControlador.EliminarCategoria(categoria);
                Response.Redirect("crud-cat.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }

        protected void lbtGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = new Categoria();

                categoria.nombre = txtNombre.Text;
                categoria.activo = chkActivo.Checked ;
                if (hdnProdId.Value != "0")
                {
                    categoria.id = Convert.ToInt32(hdnProdId.Value);
                    CategoriaControlador.ModificarCategoria(categoria);
                }
                else
                {
                    CategoriaControlador.InsertarCategoria(categoria);
                }
                Response.Redirect("crud-cat.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }
    }
}