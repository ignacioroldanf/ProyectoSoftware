using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class EjerciciosAsignado
{
    public int IdEjercicioAsignado { get; set; }

    public int? Series { get; set; }

    public int? Repeticiones { get; set; }

    public double? Peso { get; set; }

    public int? Orden { get; set; }

    public int? IdEjercicio { get; set; }

    public int? IdDiaRutina { get; set; }

    public virtual DiasRutina? IdDiaRutinaNavigation { get; set; }

    public virtual Ejercicio? IdEjercicioNavigation { get; set; }

    public virtual ICollection<Progreso> Progresos { get; set; } = new List<Progreso>();
}
