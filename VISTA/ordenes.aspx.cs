﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MODELO;
using CONTROLADOR;
namespace VISTA
{
    public partial class ordenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lstOrdenes.DataSource = OrdenControlador.ObtenerOrdenes();
            lstOrdenes.DataBind();
        }
    }
}