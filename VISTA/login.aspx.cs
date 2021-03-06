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
    public partial class login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario objUsuario = UsuarioControlador.LogIn(txtEmail.Text, txtContraseña.Text);

                Session["usuario"] = objUsuario;
                string redirect = Request.QueryString["redirect"];
                if (objUsuario.TipoUsuario.nombre == "Administrador")
                {
                    Response.Redirect("dashboard.aspx");
                }
                else if (objUsuario.TipoUsuario.nombre == "Cliente")
                {
                    if (redirect != string.Empty )
                    {
                        Response.Redirect(redirect);
                    }
                    else
                    {
                        Response.Redirect("index.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "error('" + ex.Message + "');", true);
            }
        }
    }
}