using System;
using System.Collections.Generic;

namespace Trabjobs.Models;

public partial class LoginEmpresa
{
    public int Id { get; set; }

    public string? CorreoEmpresa { get; set; }

    public string? ContraseñaEmpresa { get; set; }

    public int? EmpresaId { get; set; }

    public virtual Empresa? Empresa { get; set; }
}
