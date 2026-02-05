using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int Dni { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Profesore> Profesores { get; set; } = new List<Profesore>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
