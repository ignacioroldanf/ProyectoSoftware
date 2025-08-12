using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class EstadoSuscripcion
{
    public int IdEstadoSuscripcion { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Suscripcione> Suscripciones { get; set; } = new List<Suscripcione>();
}
