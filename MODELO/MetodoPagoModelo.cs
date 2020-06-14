using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class MetodoPagoModelo
    {

        static public void InsertarMetodoPago(MetodoPago objMetodoPago)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.MetodosPago.Add(objMetodoPago);
                    contextoEntidades.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<MetodoPago> ObtenerMetodosPagoDeUsuario(Usuario usuario)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var pago = from m in contextoEntidades.MetodosPago
                                where m.Usuario.id == usuario.id
                                select m;
                    return pago.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
