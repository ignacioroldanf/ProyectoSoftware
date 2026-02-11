using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ClaveUsuario { get; set; } = null!;

    public int IdEstadoUsuario { get; set; }

    public int? IdPersona { get; set; }

    public string? TokenRecuperacion { get; set; }

    public DateTime? ExpiracionToken { get; set; }

    public virtual EstadoUsuario IdEstadoUsuarioNavigation { get; set; } = null!;

    public virtual Persona? IdPersonaNavigation { get; set; }

    public virtual ICollection<Accione> IdAccions { get; set; } = new List<Accione>();

    public virtual ICollection<Grupo> IdGrupos { get; set; } = new List<Grupo>();
}
