using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class EstadoGrupo
{
    public int IdEstadoGrupo { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();
}
