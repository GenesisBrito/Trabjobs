using System;
using System.Collections.Generic;

namespace Trabjobs.Models;

public partial class PostulacionesEmpleo
{
    public int IdPostulacion { get; set; }

    public int IdEmpleo { get; set; }

    public int IdUsuario { get; set; }

    public DateTime FechaPostulacion { get; set; }

    public virtual Empleo IdEmpleoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
