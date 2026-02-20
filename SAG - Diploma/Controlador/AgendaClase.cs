using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class AgendaClase
    {
        public int IdHorarioClase {  get; set; }
        public string NombreClase { get; set; }
        public string NombreProfesor { get; set; }
        public string HorarioClase { get; set; }
        public int CupoTotal { get; set; }
        public int Inscritos { get; set; }

        //calculos
        public int CuposDisponibles => CupoTotal - Inscritos;
        public string Estado => CuposDisponibles > 0 ? "DISPONIBLE" : "LLENO";
        public bool EstaLleno => CuposDisponibles <= 0;
    }
}
