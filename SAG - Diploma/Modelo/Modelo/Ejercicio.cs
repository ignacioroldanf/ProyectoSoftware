using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Ejercicio
{
    public int IdEjercicio { get; set; }

    public string? NombreEjercicio { get; set; }

    public string? DescripEjercicio { get; set; }

    public virtual ICollection<EjerciciosAsignado> EjerciciosAsignados { get; set; } = new List<EjerciciosAsignado>();
}
