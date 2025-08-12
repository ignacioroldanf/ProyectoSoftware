using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int DniCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? ApellidoCliente { get; set; }

    public string? MailCliente { get; set; }

    public DateOnly? FechaAlta { get; set; }

    public virtual ICollection<Progreso> Progresos { get; set; } = new List<Progreso>();

    public virtual ICollection<Rutina> Rutinas { get; set; } = new List<Rutina>();

    public virtual ICollection<Suscripcione> Suscripciones { get; set; } = new List<Suscripcione>();
}
