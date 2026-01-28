using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class TipoRecurrencium
{
    public int IdTipoRecurrencia { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<ReservaRecurrente> ReservaRecurrentes { get; set; } = new List<ReservaRecurrente>();
}
