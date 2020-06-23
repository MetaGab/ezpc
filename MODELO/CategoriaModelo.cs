using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class CategoriaModelo
    {
        static public List<Categoria> ObtenerCategorias(bool estado)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    return contextoEntidades.Categorias.Include("Producto").Where(c => c.activo == estado).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static public Categoria ObtenerCategoriaPorID(int id)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var categorias = from c in contextoEntidades.Categorias
                                    where c.id == id
                                    select c;
                    return categorias.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static public Categoria ObtenerCategoriaPorNombre(string categoria)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var categorias = from c in contextoEntidades.Categorias
                                    where c.nombre == categoria
                                    select c;
                    return categorias.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ModificarCategoria(Categoria catMod)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Entry(catMod).State = System.Data.Entity.EntityState.Modified;
                    contextoEntidades.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static public void EliminarCategoria(Categoria objCat)
        {
            try
            {
                Categoria cat = new Categoria() { id = objCat.id };
                using (var contextoBanco = new EZPCEntidades())
                {
                    contextoBanco.Categorias.Attach(cat);
                    contextoBanco.Categorias.Remove(cat);
                    contextoBanco.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void InsertarCategoria(Categoria objCat)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Categorias.Add(objCat);
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
