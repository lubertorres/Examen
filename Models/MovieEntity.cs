using System;
using System.Collections.Generic;

namespace Examen.Models;

public partial class MovieEntity
{
    public Guid MovieId { get; set; }

    public string Name { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public int AllowedAge { get; set; }

    public int LengthMinutes { get; set; }

    public DateTime DateB { get; set; }

    public virtual ICollection<BillboardEntity> BillboardEntity { get; set; } = new List<BillboardEntity>();
}
