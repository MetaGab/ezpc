using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class OfertaModelo
    {
        static public void InsertarOferta(Oferta objOferta)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Ofertas.Add(objOferta);
                    contextoEntidades.SaveChanges();
                }
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
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var ofertas = from o in contextoEntidades.Ofertas.Include("Producto")
                                  select o;
                    return ofertas.ToList();
                }
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
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var ofertas = from o in contextoEntidades.Ofertas.Include("Producto") where o.id_producto == prod.id
                                  select o;
                    return ofertas.FirstOrDefault();
                }
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
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var ofertas = from o in contextoEntidades.Ofertas.Include("Producto")
                                  where o.id == id
                                  select o;
                    return ofertas.FirstOrDefault();
                }
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
                Oferta of = new Oferta() { id = ofMod.id };
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Ofertas.Attach(of);
                    of.descuento = ofMod.descuento;
                    of.expiracion = ofMod.expiracion;
                    of.id_producto = ofMod.id_producto;
                    contextoEntidades.SaveChanges();

                }
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
                Oferta of = new Oferta() { id = objOf.id };
                using (var contextoBanco = new EZPCEntidades())
                {
                    contextoBanco.Ofertas.Attach(of);
                    contextoBanco.Ofertas.Remove(of);
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
