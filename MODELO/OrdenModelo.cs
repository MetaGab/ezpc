using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class OrdenModelo
    {
        static public void InsertarOrden(int usuario, int pago, int direccion)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Crear_Orden(usuario, pago, direccion);
                    contextoEntidades.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static public List<Orden> ObtenerOrdenes()
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var ordenes = from o in contextoEntidades.Ordenes.Include("OrdenItem.Producto").Include("Direccion.Ciudad.Estado.Pais").Include("Usuario")
                                  select o;
                    return ordenes.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static public List<Orden> ObtenerOrdenesDeUsuario(Usuario usuario)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var ordenes = from o in contextoEntidades.Ordenes.Include("OrdenItem.Producto").Include("Direccion.Ciudad.Estado.Pais").Include("MetodoPago.Direccion.Ciudad.Estado.Pais")
                               where o.Usuario.id == usuario.id
                               select o;
                    return ordenes.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
