using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class PaisModelo
    {
        public static List<Pais> ObtenerPaises()
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    return contextoEntidades.Paises.Include("Estado").ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Pais BuscarPaisPorID(int id)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var pais = from p in contextoEntidades.Paises.Include("Estado")
                                   where p.id == id
                                   select p;
                    return pais.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
