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
        public static void EnviarCorreo(string email, Orden orden)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("humanware.ith@gmail.com", "*********");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            mail.From = new MailAddress("humanware.ith@gmail.com");
            mail.To.Add(email);
            mail.Subject = "Confirmación de Orden";
            mail.Body = "Por tu compra se te ha deducido $"+orden.costo_total+" de tu cuenta de BancoHumanware";
            client.Send(mail);
        }
        static public void CrearOrden(Orden orden, List<CarritoItem> carrito, Usuario usuario)
        {
            try
            {
                foreach (CarritoItem item in carrito)
                {
                    OrdenItem o_item = new OrdenItem();
                    o_item.cantidad = item.cantidad;
                    o_item.id_producto = item.id_producto;
                    o_item.precio = item.Producto.precio_real;
                    orden.OrdenItem.Add(o_item);
                    CarritoModelo.EliminarCarritoItem(item);
                    Producto prod = ProductoModelo.ObtenerProductoPorID((int)o_item.id_producto);
                    prod.stock -= o_item.cantidad;
                    ProductoModelo.ModificarProducto(prod);
                }
                orden.id_usuario = usuario.id;
                orden.fecha_compra = DateTime.Now;
                orden.costo_total = carrito.Sum(i => i.Producto.precio_real * i.cantidad)+ 50;
                OrdenModelo.InsertarOrden(orden);
                EnviarCorreo(usuario.email, orden);

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
