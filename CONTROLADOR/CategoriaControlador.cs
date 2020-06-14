using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace CONTROLADOR
{
    public class CategoriaControlador
    {

        public static void InsertarCategoria(Categoria categoria)
        {
            try
            {
                if (string.IsNullOrEmpty(categoria.nombre))
                {
                    throw new Exception("Nombre faltante");
                }

                CategoriaModelo.InsertarCategoria(categoria);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void ModificarCategoria(Categoria categoria)
        {
            try
            {
                if (string.IsNullOrEmpty(categoria.nombre))
                {
                    throw new Exception("Nombre faltante");
                }

                CategoriaModelo.ModificarCategoria(categoria);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void EliminarCategoria(Categoria categoria)
        {
            try
            {
                if (categoria.Producto.Count() > 0)
                {
                    throw new Exception("Existen productos asociados a esta categoría");
                }

                CategoriaModelo.EliminarCategoria(categoria);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<Categoria> ObtenerCategorias()
        {
            try
            {
                return CategoriaModelo.ObtenerCategorias();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static Categoria ObtenerCategoriaPorID(int id)
        {

            try
            {
                if (id <= 0)
                {
                    throw new Exception("ID no valido");
                }
                return CategoriaModelo.ObtenerCategoriaPorID(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
