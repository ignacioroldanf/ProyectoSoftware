using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Especialidade
{
    public int IdEspecialidad { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Profesore> IdProfesors { get; set; } = new List<Profesore>();
}
