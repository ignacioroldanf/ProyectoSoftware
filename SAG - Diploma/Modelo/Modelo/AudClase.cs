using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class AudClase
{
    public string? UsuarioAuditoria { get; set; }

    public DateTime? FyhMov { get; set; }

    public string? Movimiento { get; set; }

    public int IdClase { get; set; }

    public string? NombreClase { get; set; }

    public string? DescripcionClase { get; set; }

    public int? CupoMaximo { get; set; }

    public int? IdProfesor { get; set; }
}
