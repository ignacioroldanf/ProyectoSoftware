using Modelo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public static class RutinaFactory
    {
        public static Rutina CrearRutina(int cantDias)
        {
            Rutina rutina = new Rutina
            {
                FechaAsignacion = DateOnly.FromDateTime(DateTime.Now),
                DiasRutinas = new List<DiasRutina>()
            };

            for (int i = 1; i <= cantDias; i++)
            {
                rutina.DiasRutinas.Add(new DiasRutina
                {
                    NumeroDia = i,
                    EjerciciosAsignados = new List<EjerciciosAsignado>()
                });
            }
            return rutina;
        }
    }
}
