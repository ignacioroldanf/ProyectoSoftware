using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class AudLoginLogout
{
    public string Usuario { get; set; } = null!;

    public DateTime? FyhMov { get; set; }

    public int IdMov { get; set; }

    public virtual MovLoginLogout IdMovNavigation { get; set; } = null!;
}
