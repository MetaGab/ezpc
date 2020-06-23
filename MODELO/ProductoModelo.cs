using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ProductoModelo
    {
        static public List<Producto> ObtenerProductos(bool estado)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    return contextoEntidades.Productos.Include("Categoria").Include("Oferta").Where(p => p.activo == estado).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static public List<Producto> ObtenerProductosPorCategoria(string categoria)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var productos = from p in contextoEntidades.Productos.Include("Oferta")
                                    where p.Categoria.nombre.Contains(categoria) && p.activo == true
                                   select p;
                    return productos.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static public Producto ObtenerProductoPorID(int id)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var productos = from p in contextoEntidades.Productos.Include("Categoria").Include("Oferta")
                                    where p.id == id
                                    select p;
                    return productos.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static public bool RevisarOrdenItem(Producto producto)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var ordenitem = from p in contextoEntidades.Productos.Include("Oferta")
                                    where p.id == producto.id
                                    select p.OrdenItem;
                    return ordenitem.Count() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void InsertarProducto(Producto objProducto)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Productos.Add(objProducto);
                    contextoEntidades.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ModificarProducto(Producto productoMod)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Entry(productoMod).State = System.Data.Entity.EntityState.Modified;
                    contextoEntidades.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static public void EliminarProducto(Producto objProducto)
        {
            try
            {
                Producto prod = new Producto() { id = objProducto.id };
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Productos.Attach(prod);
                    foreach (var carrito in prod.CarritoItem)
                    {
                        contextoEntidades.CarritoItems.Attach(carrito);
                        contextoEntidades.CarritoItems.Remove(carrito);
                    }
                    contextoEntidades.Productos.Remove(prod);
                    contextoEntidades.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
