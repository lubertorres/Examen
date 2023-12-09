using System;
using System.Collections.Generic;

namespace Examen.Models;

public partial class BookingEntity
{
    public Guid BookingId { get; set; }

    public DateTime DateB { get; set; }

    public Guid CustomerId { get; set; }

    public int SeatId { get; set; }

    public Guid BillboardId { get; set; }

    public bool? Estado { get; set; }

    public virtual BillboardEntity Billboard { get; set; } = null!;

    public virtual SeatEntity Seat { get; set; } = null!;
}
