using System;
using System.Collections.Generic;

namespace Examen.Models;

public partial class UsuarioProducto
{
    public Guid IdUsuarioProducto { get; set; }

    public Guid IdUsuario { get; set; }

    public Guid IdProducto { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
