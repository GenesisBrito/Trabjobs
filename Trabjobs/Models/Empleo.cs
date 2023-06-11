using System;
using System.Collections.Generic;

namespace Trabjobs.Models;

public partial class Empleo
{
    public int IdEmpleo { get; set; }

    public string TituloEmpleo { get; set; } = null!;

    public string DescripcionEmpleo { get; set; } = null!;

    public string UbicacionEmpleo { get; set; } = null!;

    public decimal SalarioEmpleo { get; set; }

    public DateTime FechaPublicacion { get; set; }

    public virtual ICollection<PostulacionesEmpleo> PostulacionesEmpleos { get; set; } = new List<PostulacionesEmpleo>();

}
