using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Clase
{
    public int IdClase { get; set; }

    public string NombreClase { get; set; } = null!;

    public string? DescripcionClase { get; set; }

    public int CupoMaximo { get; set; }

    public int? IdProfesor { get; set; }

    public virtual ICollection<HorarioClase> HorarioClases { get; set; } = new List<HorarioClase>();

    public virtual Profesore? IdProfesorNavigation { get; set; }
}
