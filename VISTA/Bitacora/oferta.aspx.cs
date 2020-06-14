using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODELO;
namespace VISTA.Bitacora
{
    public partial class oferta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lstBitacora.DataSource = BitacoraModelo.VerBitacoraOferta();
            lstBitacora.DataBind();
        }
    }
}