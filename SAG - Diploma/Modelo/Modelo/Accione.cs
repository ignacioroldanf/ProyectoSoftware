using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Accione
{
    public int IdAccion { get; set; }

    public string NombreAccion { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? IdFormulario { get; set; }

    public virtual Formulario? IdFormularioNavigation { get; set; }

    public virtual ICollection<Grupo> IdGrupos { get; set; } = new List<Grupo>();

    public virtual ICollection<Usuario> IdUsuarios { get; set; } = new List<Usuario>();
}
