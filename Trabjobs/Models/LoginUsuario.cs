using System;
using System.Collections.Generic;

namespace Trabjobs.Models;

public partial class LoginUsuario
{
    public int Id { get; set; }

    public string? CorreoUsuarios { get; set; }

    public string? ContraseñaUsuarios { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
