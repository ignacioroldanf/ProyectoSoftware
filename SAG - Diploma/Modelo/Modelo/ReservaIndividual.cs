using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class ReservaIndividual
{
    public int IdReserva { get; set; }

    public int IdHorarioClase { get; set; }

    public DateOnly FechaReserva { get; set; }

    public virtual HorarioClase IdHorarioClaseNavigation { get; set; } = null!;

    public virtual Reserva IdReservaNavigation { get; set; } = null!;
}
