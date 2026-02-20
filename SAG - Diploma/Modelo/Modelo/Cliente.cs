using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public DateOnly? FechaAlta { get; set; }

    public int? IdPersona { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }

    public virtual ICollection<Progreso> Progresos { get; set; } = new List<Progreso>();

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();

    public virtual ICollection<Rutina> Rutinas { get; set; } = new List<Rutina>();

    public virtual ICollection<Suscripcione> Suscripciones { get; set; } = new List<Suscripcione>();
}
