using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class EstadoUsuario
{
    public int IdEstadoUsuario { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
