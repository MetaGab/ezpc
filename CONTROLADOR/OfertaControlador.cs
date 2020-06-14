using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace CONTROLADOR
{
    public class OfertaControlador
    {
        static public void InsertarOferta(Oferta objOferta)
        {
            try
            {
                if (objOferta.id_producto < 0 || ProductoModelo.ObtenerProductoPorID((int)objOferta.id_producto)==null)
                {
                    throw new Exception("Producto no valido");
                }

                if (objOferta.descuento <= 0 || objOferta.descuento >= 1)
                {
                    throw new Exception("Descuento no valido");
                }

                OfertaModelo.InsertarOferta(objOferta);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static public List<Oferta> ObtenerOfertas()
        {
            try
            {
                return OfertaModelo.ObtenerOfertas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static public Oferta ObtenerOfertaPorID(int id)
        {
            try
            {
                if (id <= 0 )
                {
                    throw new Exception("ID no valido");
                }
                return OfertaModelo.ObtenerOfertaPorID(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        static public Oferta ObtenerOfertasDeProducto(Producto prod)
        {
            try
            {
                if (prod.id < 0 || ProductoModelo.ObtenerProductoPorID((int)prod.id) == null)
                {
                    throw new Exception("Producto no valido");
                }
                return OfertaModelo.ObtenerOfertasDeProducto(prod);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ModificarOferta(Oferta ofMod)
        {
            try
            {

                if (ofMod.id_producto < 0 || ProductoModelo.ObtenerProductoPorID((int)ofMod.id_producto) == null)
                {
                    throw new Exception("Producto no valido");
                }

                if (ofMod.descuento <= 0 || ofMod.descuento >= 100)
                {
                    throw new Exception("Descuento no valido");
                }
                OfertaModelo.ModificarOferta(ofMod);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static public void EliminarOferta(Oferta objOf)
        {
            try
            {
                OfertaModelo.EliminarOferta(objOf);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
