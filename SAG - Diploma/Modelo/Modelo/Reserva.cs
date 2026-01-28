using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public DateTime FechaAlta { get; set; }

    public int IdCliente { get; set; }

    public int IdEstadoReserva { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual EstadoReserva IdEstadoReservaNavigation { get; set; } = null!;

    public virtual ReservaIndividual? ReservaIndividual { get; set; }

    public virtual ReservaRecurrente? ReservaRecurrente { get; set; }
}
