using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using MODELO;

namespace CONTROLADOR
{
    public class OrdenControlador
    {
        static public void CrearOrden(Orden orden, List<CarritoItem> carrito, Usuario usuario)
        {
            try
            {
                OrdenModelo.InsertarOrden(usuario.id, orden.id_pago, orden.id_direccion);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public static List<Orden> ObtenerOrdenes()
        {

            try
            {
                return OrdenModelo.ObtenerOrdenes();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<Orden> ObtenerOrdenesDeUsuario(Usuario usuario)
        {

            try
            {
                if (UsuarioModelo.BuscarUsuarioPorID(usuario.id) == null)
                {
                    throw new Exception("Usuario no valido");
                }
                return OrdenModelo.ObtenerOrdenesDeUsuario(usuario);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
