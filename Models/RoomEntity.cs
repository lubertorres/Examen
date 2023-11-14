using System;
using System.Collections.Generic;

namespace Examen.Models;

public partial class RoomEntity
{
    public Guid RoomId { get; set; }

    public string Name { get; set; } = null!;

    public int Number { get; set; }

    public virtual ICollection<BillboardEntity> BillboardEntity { get; set; } = new List<BillboardEntity>();

    public virtual ICollection<SeatEntity> SeatEntity { get; set; } = new List<SeatEntity>();
}
