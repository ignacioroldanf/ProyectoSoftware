using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Profesore
{
    public int IdProfesor { get; set; }

    public int IdPersona { get; set; }

    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual ICollection<Especialidade> IdEspecialidads { get; set; } = new List<Especialidade>();
}
