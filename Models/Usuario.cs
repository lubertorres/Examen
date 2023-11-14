using System;
using System.Collections.Generic;

namespace Examen.Models;

public partial class Usuario
{
    public Guid IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Cedula { get; set; } = null!;

    public int Edad { get; set; }

    public DateTime FechaCreacion { get; set; }

    public Guid IdRol { get; set; }

    public virtual Roles IdRolNavigation { get; set; } = null!;
}
