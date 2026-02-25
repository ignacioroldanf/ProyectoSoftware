using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Reportes
    {
        public class ReporteIngresos
        {
            public string NombrePlan { get; set; }
            public int CantidadSocios { get; set; }
            public decimal TotalIngresos { get; set; }

            public string Categoria { get; set; }
        }

        public class ReporteEstadoClientes
        {
            public string Estado { get; set; }
            public int CantidadClientes { get; set; }
            public string Porcentaje { get; set; }

        }

        public class ReporteEjerciciosPopulares
        {
            public string NombreEjercicio { get; set; }
            public int CantidadUsos { get; set; }
        }
    }
}
