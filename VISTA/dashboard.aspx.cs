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
    public partial class dashboard1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litClientes.Text = UsuarioControlador.BuscarUsuarioPorCriterios("", true).Count().ToString();
            litProductos.Text = ProductoControlador.ObtenerProductos(true).Count().ToString();
            litDinero.Text = OrdenControlador.ObtenerOrdenes().Sum(i => i.costo_total).ToString();
        }
    }
}