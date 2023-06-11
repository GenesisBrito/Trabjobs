using System;
using System.Collections.Generic;

namespace Trabjobs.Models;

public partial class RolesEmpresa
{
    public int IdRolesEmpresa { get; set; }

    public string NombreEmpresa { get; set; } = null!;

    public virtual ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();
}
