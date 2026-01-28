using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class EstadoReserva
{
    public int IdEstadoReserva { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
