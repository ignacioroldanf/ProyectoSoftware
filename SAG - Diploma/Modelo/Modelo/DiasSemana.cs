using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class DiasSemana
{
    public int IdDiaSemana { get; set; }

    public string NombreDia { get; set; } = null!;

    public virtual ICollection<HorarioClase> HorarioClases { get; set; } = new List<HorarioClase>();
}
