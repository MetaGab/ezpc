using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELO
{

    public class UsuarioModelo
    {
        public static void InsertarUsuario(Usuario nuevoUsuario)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Usuarios.Add(nuevoUsuario);
                    contextoEntidades.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<Usuario> BuscarUsuarioPorCriterios(string criterios, bool estado)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var usuarios = from u in contextoEntidades.Usuarios.Include("TipoUsuario")
                                   where (u.email.Contains(criterios) ||
                                   u.nombre.Contains(criterios) || u.primer_apellido.Contains(criterios)
                                   || u.segundo_apellido.Contains(criterios) || u.telefono.Contains(criterios)
                                   || u.TipoUsuario.nombre.Contains(criterios)) && u.activo == estado
                                   select u;
                    return usuarios.ToList();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static Usuario BuscarUsuarioPorID(int id)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var usuarios = from u in contextoEntidades.Usuarios
                                   where u.id == id
                                   select u;
                    return usuarios.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Usuario BuscarUsuarioPorEmail(string email)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var usuarios = from u in contextoEntidades.Usuarios.Include("TipoUsuario")
                                   where u.email == email
                                   select u;
                    return usuarios.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void ModificarUsuario(Usuario usuarioModificado)
        {
            try
            {
                Usuario usuario = new Usuario() { id = usuarioModificado.id };
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Usuarios.Attach(usuario);
                    usuario.email = usuarioModificado.email;
                    usuario.nombre = usuarioModificado.nombre;
                    usuario.primer_apellido = usuarioModificado.primer_apellido;
                    usuario.segundo_apellido = usuarioModificado.segundo_apellido;
                    usuario.telefono = usuarioModificado.telefono;
                    contextoEntidades.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CambiarEstadoUsuario(int id, bool estado)
        {
            try
            {
                Usuario usuario = new Usuario() { id = id };
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Usuarios.Attach(usuario);
                    usuario.activo = estado;
                    contextoEntidades.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void CambiarContraseña(int id, string contraseña)
        {
            try
            {
                Usuario usuario = new Usuario() { id = id };
                using (var contextoEntidades = new EZPCEntidades())
                {
                    contextoEntidades.Usuarios.Attach(usuario);
                    usuario.contraseña = contraseña;
                    contextoEntidades.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static Usuario IngresarSistem(Usuario usuario)
        {
            try
            {
                using (var contextoEntidades = new EZPCEntidades())
                {
                    var resultado = from us in contextoEntidades.Usuarios
                                    where us.contraseña == usuario.contraseña && us.email == usuario.email
                                    && us.activo == true
                                    select us;
                    return resultado.FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
