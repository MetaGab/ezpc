using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace CONTROLADOR
{
    public class ContactoControlador
    {
        public static void CrearContacto(Contacto objContacto)
        {
            try
            {
                if (string.IsNullOrEmpty(objContacto.email) )
                {
                    throw new Exception("Correo faltante");
                }

                ContactoModelo.InsertarContacto(objContacto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<Contacto> ObtenerContactos()
        {
            try
            {
               return ContactoModelo.ObtenerContactos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
