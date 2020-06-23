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
            lstCats.DataSource = CategoriaControlador.ObtenerCategorias(rbtEstado.SelectedIndex == 0);
            lstCats.DataBind();
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
                lblModal.InnerText = "Editar";
                string javascript = "mostrarModal()";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javascript, true);
                Page_Load(null, null);
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
                Categoria categoria = CategoriaControlador.ObtenerCategoriaPorID(Convert.ToInt32(btn.Attributes["obj"]));
                CategoriaControlador.EliminarCategoria(categoria);
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
                Categoria categoria = new Categoria();

                categoria.nombre = txtNombre.Text;
                categoria.activo = chkActivo.Checked;
                if (hdnProdId.Value != "0")
                {
                    categoria.id = Convert.ToInt32(hdnProdId.Value);
                    CategoriaControlador.ModificarCategoria(categoria);
                }
                else
                {
                    CategoriaControlador.InsertarCategoria(categoria);
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
            txtNombre.Text = "";
            chkActivo.Checked = true;
            lblModal.InnerText = "Agregar";
            string javascript = "mostrarModal()";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javascript, true);
            Page_Load(null, null);
        }
    }
}