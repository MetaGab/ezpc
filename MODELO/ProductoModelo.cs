using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ProductoModelo
    {
        static public List<Producto> ObtenerProductos()
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    return contextoEntidades.Productos.Include("Categoria").Include("Oferta").ToList();
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
                                    where p.id == id && p.activo == true
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
                Producto producto = new Producto() { id = productoMod.id };
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Productos.Attach(producto);
                    producto.descripcion = productoMod.descripcion;
                    producto.id_categoria = productoMod.id_categoria;
                    producto.nombre = productoMod.nombre;
                    producto.precio = productoMod.precio;
                    producto.stock = productoMod.stock;
                    producto.activo = productoMod.activo;
                    producto.imagen = productoMod.imagen;
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
