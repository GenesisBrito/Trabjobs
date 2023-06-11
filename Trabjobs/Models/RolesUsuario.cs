using System;
using System.Collections.Generic;

namespace Trabjobs.Models;

public partial class RolesUsuario
{
    public int IdRolesUsuario { get; set; }

    public string NombreRolesUsuario { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
