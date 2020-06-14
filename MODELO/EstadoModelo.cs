using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class EstadoModelo
    {
        static public List<Estado> ObtenerEstados()
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    return contextoEntidades.Estados.Include("Ciudad").ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Estado BuscarEstadoPorID(int id)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var estados = from e in contextoEntidades.Estados.Include("Ciudad")
                                   where e.id == id select e;
                    return estados.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
