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
    public partial class ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Orden> ordenes = OrdenControlador.ObtenerOrdenes();
            var estadistica = ordenes.GroupBy(x => x.fecha_compra.Date).Select(x => new
            {
                Count = x.Count(),
                Date = x.Key.Date.ToString("dd/MM/yyyy")
            }).ToList();
            estadistica.Add(new {Count=0,Date="30/05/2020" });
            estadistica.Add(new { Count = 0, Date = "29/05/2020" });
            estadistica.Add(new { Count = 0, Date = "28/05/2020" });
            estadistica.Add(new { Count = 0, Date = "27/05/2020" });
            estadistica.Add(new { Count = 0, Date = "26/05/2020" });
            lstData.DataSource = estadistica.OrderBy(i => Convert.ToDateTime(i.Date));
            lstLabels.DataSource = estadistica.OrderBy(i => Convert.ToDateTime(i.Date));
            lstData.DataBind();
            lstLabels.DataBind();

            var estadistica2 = ordenes.GroupBy(x => x.fecha_compra.Date).Select(x => new
            {
                Sum = (decimal)x.Sum(i => i.costo_total),
                Date = x.Key.Date.ToString("dd/MM/yyyy")
            }).ToList();
            estadistica2.Add(new { Sum = 0m, Date = "30/05/2020" });
            estadistica2.Add(new { Sum = 0m, Date = "29/05/2020" });
            estadistica2.Add(new { Sum = 0m, Date = "28/05/2020" });
            estadistica2.Add(new { Sum = 0m, Date = "27/05/2020" });
            estadistica2.Add(new { Sum = 0m, Date = "26/05/2020" });
            lstData2.DataSource = estadistica2.OrderBy(i => Convert.ToDateTime(i.Date));
            lstLabels2.DataSource = estadistica2.OrderBy(i => Convert.ToDateTime(i.Date));
            lstData2.DataBind();
            lstLabels2.DataBind();

        }
    }
}