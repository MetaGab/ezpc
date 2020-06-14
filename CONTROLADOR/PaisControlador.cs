using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace CONTROLADOR
{
    public class PaisControlador
    {
        public static List<Pais> ObtenerPaises()
        {
            try
            {
                return PaisModelo.ObtenerPaises();

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
                if (id <= 0)
                {
                    throw new Exception("ID no valido");
                }
                return PaisModelo.BuscarPaisPorID(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
