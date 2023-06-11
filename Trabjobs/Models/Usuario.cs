using System;
using System.Collections.Generic;

namespace Trabjobs.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreUsuarios { get; set; }

    public string? ApellidoUsuarios { get; set; }

    public string? CorreoUsuarios { get; set; }

    public string? ContraseñaUsuarios { get; set; }

    public string? TelefonoUsuarios { get; set; }

    public int? RolUsuarioId { get; set; }

    public virtual ICollection<LoginUsuario> LoginUsuarios { get; set; } = new List<LoginUsuario>();

    public virtual ICollection<PostulacionesEmpleo> PostulacionesEmpleos { get; set; } = new List<PostulacionesEmpleo>();

    public virtual RolesUsuario? RolUsuario { get; set; }
}
