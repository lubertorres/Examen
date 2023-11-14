using System;
using System.Collections.Generic;

namespace Examen.Models;

public partial class EstadoProducto
{
    public Guid IdEstadoProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Producto { get; set; } = new List<Producto>();
}
