using System;
using System.Collections.Generic;

namespace Examen.Models;

public partial class Producto
{
    public Guid IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public DateTime FechaCreacion { get; set; }

    public Guid IdEstadoProducto { get; set; }

    public virtual EstadoProducto IdEstadoProductoNavigation { get; set; } = null!;
}
