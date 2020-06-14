using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;

namespace CONTROLADOR
{
    public class DireccionControlador
    {
        public static List<Direccion> ObtenerDireccionesDeEnvioDeUsuario(Usuario usuario)
        {

            try
            {
                if (UsuarioModelo.BuscarUsuarioPorID(usuario.id) == null)
                {
                    throw new Exception("Usuario no valido");
                }
                return DireccionModelo.ObtenerDireccionesDeEnvioDeUsuario(usuario);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
