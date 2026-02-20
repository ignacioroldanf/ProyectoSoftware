using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Grupo
{
    public int IdGrupo { get; set; }

    public string NombreGrupo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int IdEstadoGrupo { get; set; }

    public virtual EstadoGrupo IdEstadoGrupoNavigation { get; set; } = null!;

    public virtual ICollection<Accione> IdAccions { get; set; } = new List<Accione>();

    public virtual ICollection<Usuario> IdUsuarios { get; set; } = new List<Usuario>();
}
