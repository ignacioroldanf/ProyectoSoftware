using System;
using System.Collections.Generic;

namespace Modelo.Modelo;

public partial class Suscripcione
{
    public int IdSuscripcion { get; set; }

    public int? IdCliente { get; set; }

    public int? IdPlan { get; set; }

    public int? IdEstadoSuscripcion { get; set; }

    public DateOnly? Inicio { get; set; }

    public DateOnly? Fin { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual EstadoSuscripcion? IdEstadoSuscripcionNavigation { get; set; }

    public virtual Plane? IdPlanNavigation { get; set; }
}
