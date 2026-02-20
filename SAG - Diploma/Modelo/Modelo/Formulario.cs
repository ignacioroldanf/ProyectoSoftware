using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Formulario
{
    public int IdFormulario { get; set; }

    public string NombreFormulario { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? IdModulo { get; set; }

    public virtual ICollection<Accione> Acciones { get; set; } = new List<Accione>();

    public virtual Modulo? IdModuloNavigation { get; set; }
}
