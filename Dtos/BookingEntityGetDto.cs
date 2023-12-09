namespace Examen.Dtos
{
    public class BookingEntityGetDto
    {
        public Guid BookingId { get; set; }

        public DateTime DateB { get; set; }

        public Guid CustomerId { get; set; }

        public int SeatId { get; set; }

        public Guid BillboardId { get; set; }

        public bool? Estado { get; set; }
    }
}
