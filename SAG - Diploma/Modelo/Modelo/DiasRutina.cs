using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class DiasRutina
{
    public int IdDiaRutina { get; set; }

    public int? IdRutina { get; set; }

    public int? NumeroDia { get; set; }

    public virtual ICollection<EjerciciosAsignado> EjerciciosAsignados { get; set; } = new List<EjerciciosAsignado>();

    public virtual Rutina? IdRutinaNavigation { get; set; }
}
