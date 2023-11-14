using System;
using System.Collections.Generic;

namespace Examen.Models;

public partial class BillboardEntity
{
    public Guid BillboardId { get; set; }

    public DateTime DateB { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public Guid MovieId { get; set; }

    public Guid RoomId { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<BookingEntity> BookingEntity { get; set; } = new List<BookingEntity>();

    public virtual MovieEntity Movie { get; set; } = null!;

    public virtual RoomEntity Room { get; set; } = null!;
}
