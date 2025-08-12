using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Rutina
{
    public int IdRutina { get; set; }

    public DateOnly? FechaAsignacion { get; set; }

    public int? CantDias { get; set; }

    public int? IdCliente { get; set; }

    public virtual ICollection<DiasRutina> DiasRutinas { get; set; } = new List<DiasRutina>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}
