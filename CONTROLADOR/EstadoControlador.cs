using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace CONTROLADOR
{
    public class EstadoControlador
    {
        public static List<Estado> ObtenerEstados()
        {
            try
            {
                return EstadoModelo.ObtenerEstados();

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
                if (id <= 0)
                {
                    throw new Exception("ID no valido");
                }
                return EstadoModelo.BuscarEstadoPorID(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
