using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class ReservaRecurrente
{
    public int IdReserva { get; set; }

    public int IdHorarioClase { get; set; }

    public int IdTipoRecurrencia { get; set; }

    public virtual HorarioClase IdHorarioClaseNavigation { get; set; } = null!;

    public virtual Reserva IdReservaNavigation { get; set; } = null!;

    public virtual TipoRecurrencium IdTipoRecurrenciaNavigation { get; set; } = null!;
}
