using Microsoft.EntityFrameworkCore;
using Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class CtrlGestionarUsuarios
    {
        private DiplomaContext _context;

        public CtrlGestionarUsuarios(DiplomaContext context)
        {
            _context = context;
        }

        public List<Usuario> ListarUsuarios()
        {
            return _context.Usuarios
                .AsNoTracking()
                .Include(u => u.IdEstadoUsuarioNavigation)
                .Include(u => u.IdPersonaNavigation)
                .Include(u => u.IdGrupos)
                .ToList();
        }
        public List<EstadoUsuario> ListarEstados()   
        {
            return _context.EstadoUsuarios.ToList();
        }

        public void AgregarUsuario(Usuario nuevoUsuario, string passwordPlana)
        {
            if (_context.Usuarios.Any(u => u.NombreUsuario == nuevoUsuario.NombreUsuario))
            {
                throw new Exception("El nombre de usuario ya existe.");
            }

            nuevoUsuario.ClaveUsuario = Seguridad.GetSHA256(passwordPlana); 

            nuevoUsuario.IdEstadoUsuario = 1; 

            _context.Usuarios.Add(nuevoUsuario);
            _context.SaveChanges();

        }

        public void ModificarUsuario(Usuario usuarioModificado)
        {
            var usuarioExistente = _context.Usuarios
                            .Include(u => u.IdPersonaNavigation)
                            .FirstOrDefault(u => u.IdUsuario == usuarioModificado.IdUsuario);

            if (usuarioExistente != null)
            {
                usuarioExistente.NombreUsuario = usuarioModificado.NombreUsuario;

                if (usuarioExistente.IdPersonaNavigation != null && usuarioModificado.IdPersonaNavigation != null)
                {
                    usuarioExistente.IdPersonaNavigation.Nombre = usuarioModificado.IdPersonaNavigation.Nombre;
                    usuarioExistente.IdPersonaNavigation.Apellido = usuarioModificado.IdPersonaNavigation.Apellido;
                    usuarioExistente.IdPersonaNavigation.Dni = usuarioModificado.IdPersonaNavigation.Dni;
                    usuarioExistente.IdPersonaNavigation.Email = usuarioModificado.IdPersonaNavigation.Email;
                    usuarioExistente.IdEstadoUsuario = usuarioModificado.IdEstadoUsuario;
                }

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Usuario no encontrado.");
            }
        }
        public void DesactivarUsuario(int idUsuario)
        {
            var usuario = _context.Usuarios.Find(idUsuario);
            if (usuario != null)
            {
                usuario.IdEstadoUsuario = 0;
                _context.SaveChanges();
            }
        }
        public void ActivarUsuario(int idUsuario)
        {
            var usuario = _context.Usuarios.Find(idUsuario);
            if (usuario != null)
            {
                usuario.IdEstadoUsuario = 1;
                _context.SaveChanges();
            }
        }

        public string ResetearClave(int idUsuario)
        {
            var usuario = _context.Usuarios.Find(idUsuario);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado.");
            }
            string nuevaClave = Seguridad.GenerarClaveAleatoria();
            usuario.ClaveUsuario = Seguridad.GetSHA256(nuevaClave);
            _context.SaveChanges();

            return nuevaClave;
        }

        public void GuardarNuevaClave(int idUsuario, string nuevaClavePlana)
        {
            var usuario = _context.Usuarios.Find(idUsuario);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            usuario.ClaveUsuario = Seguridad.GetSHA256(nuevaClavePlana);

            _context.SaveChanges();
        }

        public List<Accione> ObtenerAccionesDelUsuario(int idUsuario)
        {
            var usuario = _context.Usuarios
                .Include(u => u.IdAccions)
                .FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (usuario == null) return new List<Accione>();

            return usuario.IdAccions.ToList();
        }

        public void GuardarPermisosDelUsuario(int idUsuario, List<int> idsAccionesSeleccionadas)
        {
            var usuario = _context.Usuarios
                .Include(u => u.IdAccions)
                .FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (usuario == null) throw new Exception("Usuario no encontrado");

            usuario.IdAccions.Clear();

            var accionesNuevas = _context.Acciones
                .Where(a => idsAccionesSeleccionadas.Contains(a.IdAccion))
                .ToList();


            foreach (var accion in accionesNuevas)
            {
                usuario.IdAccions.Add(accion);
            }

            _context.SaveChanges();
        }
        public List<Grupo> ObtenerGruposDelUsuario(int idUsuario)
        {
            var usuario = _context.Usuarios
                .Include(u => u.IdGrupos)
                .FirstOrDefault(u => u.IdUsuario == idUsuario);

            return usuario != null ? usuario.IdGrupos.ToList() : new List<Grupo>();
        }

        public void GuardarGruposUsuario(int idUsuario, List<int> idsGruposSeleccionados)
        {
            var usuario = _context.Usuarios
                .Include(u => u.IdGrupos)
                .FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (usuario == null) throw new Exception("Usuario no encontrado");

            usuario.IdGrupos.Clear();

            var gruposNuevos = _context.Grupos
                .Where(g => idsGruposSeleccionados.Contains(g.IdGrupo))
                .ToList();

            foreach (var g in gruposNuevos)
            {
                usuario.IdGrupos.Add(g);
            }

            _context.SaveChanges();
        }
    }
}
