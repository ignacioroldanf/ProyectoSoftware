using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Modelo;


namespace Controlador
{
    public class CtrlGestionarSesiones
    {
        public Usuario IniciarSesion(string nombreUsuario, string password)
        {
            string passHash = Seguridad.GetSHA256(password);

            using (var db = new DiplomaContext())
            {
                // 1. Traemos TODO (Incluyendo la navegación al Formulario)
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

                // 2. Recolectar Acciones (Strings)
                var accionesGrupo = usuario.IdGrupos.Where(g => g.IdEstadoGrupo == 1)
                                           .SelectMany(g => g.IdAccions);
                var accionesDirectas = usuario.IdAccions;

                // Unimos todas las acciones (objetos completos)
                var todasLasAccionesObj = accionesGrupo.Concat(accionesDirectas).ToList();

                // Lista de nombres de permisos (para los botones internos)
                var nombresPermisos = todasLasAccionesObj.Select(a => a.NombreAccion).Distinct().ToList();

                // 3. Recolectar Nombres de Formularios (para el Menú Principal)
                // Aquí decimos: "Si tiene la acción 'Agregar Cliente', guardamos el formulario 'FormGestionarClientes'"
                var nombresFormularios = todasLasAccionesObj
                                            .Where(a => a.IdFormularioNavigation != null)
                                            .Select(a => a.IdFormularioNavigation.NombreFormulario)
                                            .Distinct()
                                            .ToList();

                // 4. Cargar Sesión
                Sesion.Instancia.UsuarioActual = usuario;
                Sesion.Instancia.NombreRol = usuario.IdGrupos.FirstOrDefault()?.NombreGrupo ?? "Sin Grupo";

                // Pasamos AMBAS listas
                Sesion.Instancia.CargarPermisos(nombresPermisos, nombresFormularios);

                return usuario;
            }
        }

        public void CerrarSesion()
        {
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
    }
}

