using Microsoft.EntityFrameworkCore;
using Modelo.Modelo;


namespace Controlador
{
    public class CtrlGestionarSesiones
    {
        public static class Sesion
        {
            public static Usuario? UsuarioActual { get; set; }
            public static string NombreRol { get; set; } = "Sin Rol";
            private static List<string> _permisos = new List<string>();
            public static bool TienePermiso(string nombreAccion)
            {
                if (UsuarioActual == null)
                    return false;

                return _permisos.Contains(nombreAccion);
            }

            public static void CargarPermisos(List<string> listaPermisos)
            {
                _permisos = new List<string>(listaPermisos);
            }

            public static void CerrarSesion()
            {
                UsuarioActual = null;
                NombreRol = "Sin Rol";
                _permisos.Clear();
            }

            public static bool EstaLogueado()
            {
                return UsuarioActual != null;
            }
        }

        public Usuario? IniciarSesion(string nombreUsuario, string password)
        {
            string passHash = Seguridad.GetSHA256(password);

            using (var db = new DiplomaContext())
            {
                var usuario = db.Usuarios
                                .Include(u => u.IdPersonaNavigation)
                                .Include(u => u.IdEstadoUsuarioNavigation)
                                .Include(u => u.IdGrupos)
                                    .ThenInclude(g => g.IdAccions)
                                .Include(u => u.IdAccions)
                                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario
                                              && u.ClaveUsuario == passHash
                                              && u.IdEstadoUsuario == 1);

                if (usuario == null) return null;

                var permisosRol = usuario.IdGrupos.SelectMany(g => g.IdAccions).Select(a => a.NombreAccion);
                var permisosExtra = usuario.IdAccions.Select(a => a.NombreAccion);
                var todosLosPermisos = permisosRol.Union(permisosExtra).ToList();

                Sesion.UsuarioActual = usuario;

                var grupo = usuario.IdGrupos.FirstOrDefault();
                Sesion.NombreRol = (grupo != null) ? grupo.NombreGrupo : "Acceso Especial";

                Sesion.CargarPermisos(todosLosPermisos);

                return usuario;
            }
        }

        public void CerrarSesion()
        {
            Sesion.CerrarSesion();
        }

        public void CambiarClave(string claveActual, string nuevaClave, string confirmacion)
        {
            if (!Sesion.EstaLogueado())
                throw new Exception("No hay sesión activa.");

            if (nuevaClave != confirmacion)
                throw new Exception("La nueva clave y su confirmación no coinciden.");

            if (!Seguridad.ValidarClave(nuevaClave))
            {
                throw new Exception("La clave no es segura. Debe tener 8 caracteres, mayúscula, minúscula, número y símbolo.");
            }

            using (var db = new DiplomaContext())
            {
                var usuario = db.Usuarios.Find(Sesion.UsuarioActual.IdUsuario);

                if (usuario == null) throw new Exception("Usuario no encontrado.");

                string hashActual = Seguridad.GetSHA256(claveActual);
                if (usuario.ClaveUsuario != hashActual)
                {
                    throw new Exception("La clave actual ingresada es incorrecta.");
                }

                usuario.ClaveUsuario = Seguridad.GetSHA256(nuevaClave); // <--- ENCRIPTACIÓN [cite: 183]

                db.SaveChanges();
            }
        }
    }
}

