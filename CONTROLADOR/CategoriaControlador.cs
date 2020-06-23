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

                CategoriaModelo.EliminarCategoria(categoria);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<Categoria> ObtenerCategorias(bool estado)
        {
            try
            {
                return CategoriaModelo.ObtenerCategorias(estado);
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
