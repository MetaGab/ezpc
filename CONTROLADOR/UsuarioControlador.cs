using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using MODELO;

namespace CONTROLADOR
{
    public static class UsuarioControlador
    {
        public static byte[] GenerarSal()
        {
            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            rngCsp.GetBytes(salt);
            return salt;
        }
		
        public static byte[] EncriptarContraseña(string password, byte[] salt)
        {
            int iterations = 40000;
            byte[] hash;

            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            hash = pbkdf2.GetBytes(32);
            return hash;
        }
		
        public static void EnviarCorreo(string email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("humanware.ith@gmail.com", "*******");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            mail.From = new MailAddress("humanware.ith@gmail.com");
            mail.To.Add(email);
            mail.Subject = "Bienvenido a EZPC";
            mail.Body = "Hola";
            client.Send(mail);
        }
		
        public static void CrearUsuario(Usuario objUsuario)
        {
            try
            {

                if (string.IsNullOrEmpty(objUsuario.nombre) || string.IsNullOrEmpty(objUsuario.primer_apellido))
                {
                    throw new Exception("Nombre o apellido faltante");
                }
                if (string.IsNullOrEmpty(objUsuario.email) || string.IsNullOrEmpty(objUsuario.contraseña))
                {
                    throw new Exception("Email o contraseña nulos");
                }

                if (UsuarioModelo.BuscarUsuarioPorEmail(objUsuario.email) != null)
                {
                    throw new Exception("Email ya existente");
                }

                EnviarCorreo(objUsuario.email);
                byte[] salt = GenerarSal();
                objUsuario.contraseña = Convert.ToBase64String(salt) +"!"+ Convert.ToBase64String(EncriptarContraseña(objUsuario.contraseña, salt));

                UsuarioModelo.InsertarUsuario(objUsuario);

                if (UsuarioModelo.BuscarUsuarioPorEmail(objUsuario.email) == null)
                {
                    throw new Exception("Error en creación de usuario");
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static void ModificarUsuario(Usuario objUsuario)
        {
            try
            {
                if (string.IsNullOrEmpty(objUsuario.nombre) || string.IsNullOrEmpty(objUsuario.primer_apellido))
                {
                    throw new Exception("Nombre o apellido faltante");
                }
                if (string.IsNullOrEmpty(objUsuario.email) )
                {
                    throw new Exception("Email faltante");
                }

                if (UsuarioModelo.BuscarUsuarioPorEmail(objUsuario.email).id != objUsuario.id)
                {
                    throw new Exception("Email ya existente");
                }

                UsuarioModelo.ModificarUsuario(objUsuario);

                if (UsuarioModelo.BuscarUsuarioPorEmail(objUsuario.email) == null)
                {
                    throw new Exception("Error en modificación de usuario");
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
		
        public static void CambiarContraseña(Usuario objUsuario)
        {
            try
            {
                if (string.IsNullOrEmpty(objUsuario.email) || string.IsNullOrEmpty(objUsuario.contraseña))
                {
                    throw new Exception("Email o contraseña nulos");
                }

                if (UsuarioModelo.BuscarUsuarioPorID(objUsuario.id) == null)
                {
                    throw new Exception("Usuario no existente");
                }

                byte[] salt = GenerarSal();
                
                objUsuario.contraseña = Convert.ToBase64String(salt) +"!"+ Convert.ToBase64String(EncriptarContraseña(objUsuario.contraseña, salt));

                UsuarioModelo.ModificarUsuario(objUsuario);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
		
        public static void CambiarEmail(Usuario objUsuario)
        {
            try
            {
                if (string.IsNullOrEmpty(objUsuario.email) || string.IsNullOrEmpty(objUsuario.contraseña))
                {
                    throw new Exception("Email o contraseña nulos");
                }

                if (UsuarioModelo.BuscarUsuarioPorID(objUsuario.id) == null)
                {
                    throw new Exception("Usuario no existente");
                }

                UsuarioModelo.ModificarUsuario(objUsuario);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
		
        public static Usuario LogIn(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    throw new Exception("Email o contraseña nulos");
                }

                Usuario objUsuario = UsuarioModelo.BuscarUsuarioPorEmail(email);

                if (objUsuario == null)
                {
                    throw new Exception("Email o contraseña incorrectos");
                }

                string[] contraseña = objUsuario.contraseña.Split('!');

                byte[] salt = Convert.FromBase64String(contraseña[0]);
                byte[] hash = Convert.FromBase64String(contraseña[1]);
                byte[] newhash = EncriptarContraseña(password, salt);

                if (hash.SequenceEqual(newhash))
                {
                    return objUsuario;
                }
                else
                {
                    throw new Exception("Email o contraseña incorrectos");
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
                return UsuarioModelo.BuscarUsuarioPorCriterios(criterios, estado);

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
                return UsuarioModelo.BuscarUsuarioPorEmail(email);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}