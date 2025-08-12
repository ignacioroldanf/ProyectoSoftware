using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Plane
{
    public int IdPlan { get; set; }

    public string? NombrePlan { get; set; }

    public int DuracionMeses { get; set; }

    public bool? Soporte { get; set; }

    public decimal? PrecioMensual { get; set; }

    public string? DescripPlan { get; set; }

    public virtual ICollection<Suscripcione> Suscripciones { get; set; } = new List<Suscripcione>();
}
