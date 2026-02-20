using Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Sesion
    {
        private static Sesion _instancia;

        public Usuario UsuarioActual { get; set; }
        public string NombreRol { get; set; }
        public List<string> Permisos { get; private set; } = new List<string>(); //permisos puntuales
        public HashSet<string> FormsHabilitados { get; private set; } = new HashSet<string>(); //forms habilitados
        public static Sesion Instancia
        {
            get
            {
                if (_instancia == null) _instancia = new Sesion();
                return _instancia;
            }
        }

        public bool TienePermiso(string nombreAccion)
        {
            if (UsuarioActual != null && UsuarioActual.NombreUsuario == "admin") return true;
            return Permisos.Contains(nombreAccion);
        }
        public bool PuedeAccederFormulario(string nombreFormulario)
        {
            if (UsuarioActual != null && UsuarioActual.NombreUsuario == "admin") return true;

            return FormsHabilitados.Contains(nombreFormulario);
        }

        public void CargarPermisos(List<string> acciones, List<string> formularios)
        {
            Permisos = acciones;
            FormsHabilitados = new HashSet<string>(formularios);
        }
        public void Logout()
        {
            UsuarioActual = null;
            Permisos.Clear();
            FormsHabilitados.Clear();
        }
    }
}
