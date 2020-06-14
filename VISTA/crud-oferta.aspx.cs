using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CONTROLADOR;
using MODELO;

namespace VISTA
{
    public partial class crud_oferta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstOff.DataSource = OfertaControlador.ObtenerOfertas();
                lstOff.DataBind();
                ddlProd.DataSource = ProductoControlador.ObtenerProductos();
                ddlProd.DataTextField = "nombre";
                ddlProd.DataValueField = "id";
                ddlProd.DataBind();
                ddlProd.Items.Insert(0, new ListItem("Selecciona...", "0"));
            }
        }


        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                Oferta oferta = OfertaControlador.ObtenerOfertaPorID(Convert.ToInt32(btn.Attributes["obj"]));
                txtDesc.Text = oferta.descuento.ToString();
                ddlProd.SelectedValue = oferta.id_producto.ToString();
                txtExp.Text = oferta.expiracion.ToString();
                hdnProdId.Value = oferta.id.ToString();
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
                Oferta oferta = OfertaControlador.ObtenerOfertaPorID(Convert.ToInt32(btn.Attributes["obj"]));
                OfertaControlador.EliminarOferta(oferta);
                Response.Redirect("crud-oferta.aspx");
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
                Oferta oferta = new Oferta();

                oferta.descuento = Convert.ToDecimal(txtDesc.Text);
                oferta.expiracion = Convert.ToDateTime(txtExp.Text);
                oferta.id_producto = Convert.ToInt32(ddlProd.SelectedValue);
                if (hdnProdId.Value != "0")
                {
                    oferta.id = Convert.ToInt32(hdnProdId.Value);
                    OfertaControlador.ModificarOferta(oferta);
                }
                else
                {
                    OfertaControlador.InsertarOferta(oferta);
                }
                Response.Redirect("crud-oferta.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }
    }
}