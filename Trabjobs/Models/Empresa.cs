using System;
using System.Collections.Generic;

namespace Trabjobs.Models;

public partial class Empresa
{
    public int IdEmpresa { get; set; }

    public string? NombreEmpresa { get; set; }

    public string? CorreoEmpresa { get; set; }

    public string? ContraseñaEmpresa { get; set; }

    public string? TelefonoEmpresa { get; set; }

    public string? LocacionEmpresa { get; set; }

    public int? RolEmpresaId { get; set; }

    public virtual ICollection<LoginEmpresa> LoginEmpresas { get; set; } = new List<LoginEmpresa>();

    public virtual RolesEmpresa? RolEmpresa { get; set; }
}
