using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Modelo;
using System.Net.Mime;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace Controlador
{
    public class CtrlGestionarSesiones
    {
        public Usuario IniciarSesion(string nombreUsuario, string password)
        {
            string passHash = Seguridad.GetSHA256(password);

            using (var db = new DiplomaContext())
            {
                var usuario = db.Usuarios
                                .Include(u => u.IdEstadoUsuarioNavigation)
                                .Include(u => u.IdGrupos)
                                    .ThenInclude(g => g.IdAccions)
                                        .ThenInclude(a => a.IdFormularioNavigation)
                                .Include(u => u.IdAccions)
                                    .ThenInclude(a => a.IdFormularioNavigation)
                                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario
                                              && u.ClaveUsuario == passHash
                                              && u.IdEstadoUsuario == 1);

                if (usuario == null) return null;

                var accionesGrupo = usuario.IdGrupos.Where(g => g.IdEstadoGrupo == 1)
                                           .SelectMany(g => g.IdAccions);
                var accionesDirectas = usuario.IdAccions;

                var todasLasAccionesObj = accionesGrupo.Concat(accionesDirectas).ToList();

                var nombresPermisos = todasLasAccionesObj.Select(a => a.NombreAccion).Distinct().ToList();

                var nombresFormularios = todasLasAccionesObj
                                            .Where(a => a.IdFormularioNavigation != null)
                                            .Select(a => a.IdFormularioNavigation.NombreFormulario)
                                            .Distinct()
                                            .ToList();

                Sesion.Instancia.UsuarioActual = usuario;
                Sesion.Instancia.NombreRol = usuario.IdGrupos.FirstOrDefault()?.NombreGrupo ?? "Sin Grupo";

                Sesion.Instancia.CargarPermisos(nombresPermisos, nombresFormularios);

                try
                {
                    db.Database.ExecuteSqlRaw(
                        "INSERT INTO Aud_login_logout (Usuario, Fyh_mov, Id_mov) VALUES ({0}, GETDATE(), {1})",
                        usuario.NombreUsuario, 1);
                }
                catch (Exception ex)
                {

                }

                return usuario;
            }
        }

        public void CerrarSesion()
        {
            if (Sesion.Instancia.UsuarioActual != null)
            {
                using (var db = new DiplomaContext())
                {
                    try
                    {
                        db.Database.ExecuteSqlRaw(
                            "INSERT INTO Aud_login_logout (Usuario, Fyh_mov, Id_mov) VALUES ({0}, GETDATE(), {1})",
                            Sesion.Instancia.UsuarioActual.NombreUsuario, 2);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            Sesion.Instancia.Logout();
        }
        public static Sesion SesionActual
        {
            get { return Sesion.Instancia; }
        }

        public void CambiarClave(string claveActual, string nuevaClave, string confirmacion)
        {
            if (nuevaClave != confirmacion)
                throw new Exception("La nueva clave y su confirmación no coinciden.");

            if (!Seguridad.ValidarClave(nuevaClave))
            {
                throw new Exception("La clave no es segura. Debe tener 8 caracteres, mayúscula, minúscula, número y símbolo.");
            }

            using (var db = new DiplomaContext())
            {
                var usuario = db.Usuarios.Find(Sesion.Instancia.UsuarioActual.IdUsuario);

                if (usuario == null) throw new Exception("Usuario no encontrado.");

                string hashActual = Seguridad.GetSHA256(claveActual);

                if (usuario.ClaveUsuario != hashActual)
                {
                    throw new Exception("La clave actual ingresada es incorrecta.");
                }

                usuario.ClaveUsuario = Seguridad.GetSHA256(nuevaClave);

                db.SaveChanges();
            }
        }

        public void SolicitarRecuperacion(string emailIngresado)
        {
            using (var db = new DiplomaContext())
            {
                var usuario = db.Usuarios
                                .Include(u => u.IdPersonaNavigation)
                                .FirstOrDefault(u => u.IdPersonaNavigation.Email == emailIngresado);
                if (usuario == null)
                    throw new Exception("No se encontró un usuario asociado a ese email.");

                string token = new Random().Next(100000, 999999).ToString();

                usuario.TokenRecuperacion = token;
                usuario.ExpiracionToken = DateTime.Now.AddMinutes(30);

                db.SaveChanges();

                try
                {
                    EnviarEmail(usuario.IdPersonaNavigation.Email, "Código de Recuperación",
                        $"Hola {usuario.NombreUsuario}, tu código de recuperación es: {token}");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al enviar el correo: " + ex.Message);
                }
            }
        }

        public void ValidarToken(string token)
        {
            using (var db = new DiplomaContext())
            {
                var usuario = db.Usuarios.FirstOrDefault(u => u.TokenRecuperacion == token);

                if (usuario == null)
                    throw new Exception("El código ingresado es incorrecto.");

                if (usuario.ExpiracionToken < DateTime.Now)
                    throw new Exception("El código ha expirado. Por favor solicite uno nuevo.");
            }
        }

        public void RestablecerContrasena(string token, string nuevaClave, string confirmacion)
        {
            if (nuevaClave != confirmacion)
                throw new Exception("Las contraseñas no coinciden.");

            if (!Seguridad.ValidarClave(nuevaClave))
                throw new Exception("La clave no cumple con los requisitos de seguridad.");

            using (var db = new DiplomaContext())
            {
                var usuario = db.Usuarios.FirstOrDefault(u => u.TokenRecuperacion == token);

                if (usuario == null)
                    throw new Exception("El código ingresado es inválido.");

                if (usuario.ExpiracionToken < DateTime.Now)
                    throw new Exception("El código ha expirado. Por favor solicite uno nuevo.");

                usuario.ClaveUsuario = Seguridad.GetSHA256(nuevaClave);

                usuario.TokenRecuperacion = null;
                usuario.ExpiracionToken = null;

                db.SaveChanges();
            }
        }

        private void EnviarEmail(string destinatario, string asunto, string cuerpo)
        {

            string remitente = "saggym.contacto@gmail.com";
            string passwordSmtp = "uwcgvnizougacqtq";
            string host = "smtp.gmail.com";
            int puerto = 587;

            using (MailMessage mm = new MailMessage(remitente, destinatario))
            {
                mm.Subject = asunto;
                mm.Body = cuerpo;
                mm.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient(host, puerto))
                {

                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(remitente, passwordSmtp);
                    smtp.EnableSsl = true;

                    try
                    {
                        smtp.Send(mm);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error SMTP: " + ex.Message);
                    }
                }
            }
        }
    }
}

