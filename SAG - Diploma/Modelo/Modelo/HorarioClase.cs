using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class HorarioClase
{
    public int IdHorarioClase { get; set; }

    public int IdClase { get; set; }

    public int IdDiaSemana { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public virtual Clase IdClaseNavigation { get; set; } = null!;

    public virtual DiasSemana IdDiaSemanaNavigation { get; set; } = null!;

    public virtual ICollection<ReservaIndividual> ReservaIndividuals { get; set; } = new List<ReservaIndividual>();

    public virtual ICollection<ReservaRecurrente> ReservaRecurrentes { get; set; } = new List<ReservaRecurrente>();
}
