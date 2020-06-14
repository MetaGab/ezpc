using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace CONTROLADOR
{
    public class ProductoControlador
    {

        public static void InsertarProducto(Producto producto)
        {
            try
            {
                if (string.IsNullOrEmpty(producto.nombre))
                {
                    throw new Exception("Nombre faltante");
                }

                if (producto.precio < 0)
                {
                    throw new Exception("Precio no valido");
                }

                if (producto.stock < 0)
                {
                    throw new Exception("Existencias no validas");
                }

                if (producto.id_categoria == 0)
                {
                    throw new Exception("Falta categoría");
                }

                ProductoModelo.InsertarProducto(producto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void ModificarProducto(Producto producto)
        {
            try
            {
                if (string.IsNullOrEmpty(producto.nombre))
                {
                    throw new Exception("Nombre faltante");
                }

                if (producto.precio < 0)
                {
                    throw new Exception("Precio no valido");
                }

                if (producto.stock < 0)
                {
                    throw new Exception("Existencias no validas");
                }

                if (producto.id_categoria == 0)
                {
                    throw new Exception("Falta categoría");
                }


                ProductoModelo.ModificarProducto(producto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void EliminarProducto(Producto producto)
        {
            try
            {
                if (ProductoModelo.RevisarOrdenItem(producto))
                {
                    throw new Exception("Este producto ya ha sido comprado");
                }

                ProductoModelo.EliminarProducto(producto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<Producto> ObtenerProductos()
        {
            try
            {
                return ProductoModelo.ObtenerProductos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<Producto> ObtenerProductosPorCategoria(string categoria)
        {
            try
            {
                if (CategoriaModelo.ObtenerCategoriaPorNombre(categoria) == null)
                {
                    throw new Exception("Categoria no valida");
                }
                return ProductoModelo.ObtenerProductosPorCategoria(categoria);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Producto ObtenerProductoPorID(int id)
        {

            try
            {
                if (id <= 0)
                {
                    throw new Exception("ID no valido");
                }
                return ProductoModelo.ObtenerProductoPorID(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
