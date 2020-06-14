using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{
    public class ContactoModelo
    {
        static public void InsertarContacto(Contacto objContacto)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Contactos.Add(objContacto);
                    contextoEntidades.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static public List<Contacto> ObtenerContactos()
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    return contextoEntidades.Contactos.Include("Ciudad").ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
