using System;
using System.Collections.Generic;

namespace Examen.Models;

public partial class Roles
{
    public Guid IdRol { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
