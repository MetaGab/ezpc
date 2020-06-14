using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace CONTROLADOR
{
    public class CarritoControlador
    {
        public static void CrearCarritoItem(CarritoItem objCarritoItem)
        {
            try
            {
                Producto product = ProductoModelo.ObtenerProductoPorID((int)objCarritoItem.id_producto);
                if (objCarritoItem.cantidad <= 0)
                {
                    throw new Exception("Cantidad no valida");
                }
                else if (objCarritoItem.cantidad > product.stock)
                {
                    throw new Exception("No tenemos tanto producto, revisa más tarde");
                }
                CarritoItem existente = CarritoModelo.RevisarExistente(objCarritoItem.id_usuario, objCarritoItem.id_producto);
                if (existente != null)
                {
                    existente.cantidad += objCarritoItem.cantidad;
                    ModificarCarrito(existente.Usuario, existente);
                    return;
                }
                CarritoModelo.InsertarCarritoItem(objCarritoItem);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void ModificarCarrito(Usuario usuario, CarritoItem objCarritoItem)
        {
            try
            {
                CarritoItem item = CarritoModelo.ObtenerCarritoItemPorID(objCarritoItem.id);
                if (objCarritoItem.cantidad < 0)
                {
                    throw new Exception("Cantidad no valida");
                }
                else if (objCarritoItem.cantidad > item.Producto.stock)
                {
                    throw new Exception("No tenemos tanto producto, revisa más tarde");
                }
                if (usuario.id != item.id_usuario)
                {
                    throw new Exception("Usuario no valido");
                }
                if (objCarritoItem.cantidad == 0)
                {
                    CarritoModelo.EliminarCarritoItem(objCarritoItem);
                }
                else
                {
                    CarritoModelo.ModificarCarrito(objCarritoItem);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static List<CarritoItem> ObtenerCarritoPorUsuario(Usuario usuario)
        {

            try
            {
                if (UsuarioModelo.BuscarUsuarioPorID(usuario.id)==null)
                {
                    throw new Exception("Usuario no valido");
                }
                return CarritoModelo.ObtenerCarritoPorUsuario(usuario);

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
                if (id <= 0)
                {
                    throw new Exception("ID no valido");
                }
                return CarritoModelo.ObtenerCarritoItemPorID(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
