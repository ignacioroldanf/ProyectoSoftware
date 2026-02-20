using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public static class Permisos
    {
        // MÓDULOS (Para FormInicio)
        public const string MENU_USUARIOS = "Gestionar Usuarios";
        public const string MENU_GRUPOS = "Gestionar Grupos";
        public const string MENU_CLIENTES = "Gestionar Clientes";
        public const string MENU_PLANES = "Gestionar Planes";
        public const string MENU_RUTINAS = "Gestionar Rutinas";
        public const string MENU_CLASES = "Gestionar Clases";


        // ACCIONES (Para dentro de los formularios)
        public const string USR_ALTA = "Agregar Usuario";
        public const string USR_BAJA = "Eliminar Usuario";
        public const string USR_MODIF = "Modificar Usuario";
        public const string USR_RESET = "Resetear Clave Usuario";
    }
}
