namespace Examen.Dtos
{
    public class EditBookingDto
    {
        public Guid BookingId { get; set; }

        public Guid CustomerId { get; set; }

        public int SeatId { get; set; }

        public Guid BillboardId { get; set; }

        public bool? Estado { get; set; }
    }
}
