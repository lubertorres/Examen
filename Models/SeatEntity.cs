using System;
using System.Collections.Generic;

namespace Examen.Models;

public partial class SeatEntity
{
    public int SeatId { get; set; }

    public int RowNumber { get; set; }

    public Guid RoomId { get; set; }

    public bool Estado { get; set; }

    public virtual ICollection<BookingEntity> BookingEntity { get; set; } = new List<BookingEntity>();

    public virtual RoomEntity Room { get; set; } = null!;
}
