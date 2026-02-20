using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Modulo
{
    public int IdModulo { get; set; }

    public string NombreModulo { get; set; } = null!;

    public virtual ICollection<Formulario> Formularios { get; set; } = new List<Formulario>();
}
