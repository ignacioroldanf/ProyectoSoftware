using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Progreso
{
    public int IdProgreso { get; set; }

    public int? IdCliente { get; set; }

    public int? IdEjercicioAsignado { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? SeriesHechas { get; set; }

    public int? RepesHechas { get; set; }

    public decimal? PesoUsado { get; set; }

    public string? Observaciones { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual EjerciciosAsignado? IdEjercicioAsignadoNavigation { get; set; }
}
