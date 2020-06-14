using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class DireccionModelo
    {
        static public void InsertarDireccion(Direccion objDireccion)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Direcciones.Add(objDireccion);
                    contextoEntidades.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static public List<Direccion> ObtenerDireccionesDeEnvioDeUsuario(Usuario usuario)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var direcciones = from d in contextoEntidades.Direcciones
                               where d.Usuario.id == usuario.id && d.Orden.Count() > 0
                               select d;
                    return direcciones.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
