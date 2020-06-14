using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class CarritoModelo
    {
        static public void InsertarCarritoItem(CarritoItem objCarritoItem)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.CarritoItems.Add(objCarritoItem);
                    contextoEntidades.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static CarritoItem ObtenerCarritoItemPorID(int id)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var item = from i in contextoEntidades.CarritoItems.Include("Producto.Oferta")
                               where i.id == id
                                   select i;
                    return item.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static CarritoItem RevisarExistente(int usuario, int producto)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var item = from i in contextoEntidades.CarritoItems.Include("Usuario")
                               where usuario == i.id_usuario && producto == i.id_producto
                               select i; 
                    return item.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void ModificarCarrito(CarritoItem carritoItem)
        {
            try
            {
                CarritoItem item = new CarritoItem() { id = carritoItem.id };
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.CarritoItems.Attach(item);
                    item.cantidad = carritoItem.cantidad;
                    contextoEntidades.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static public List<CarritoItem> ObtenerCarritoPorUsuario(Usuario objUsuario)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var items = from i in contextoEntidades.CarritoItems.Include("Producto.Oferta")
                                    where i.Usuario.id == objUsuario.id
                                    select i;
                    return items.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static public void EliminarCarritoItem(CarritoItem carritoItem)
        {
            try
            {
                CarritoItem item = new CarritoItem() { id = carritoItem.id };
                using (var contextoBanco = new EZPCEntidades())
                {
                    contextoBanco.CarritoItems.Attach(item);
                    contextoBanco.CarritoItems.Remove(item);
                    contextoBanco.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

