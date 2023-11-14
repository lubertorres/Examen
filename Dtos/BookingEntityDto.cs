namespace Examen.Dtos
{
    public class BookingEntityDto
    {
        public Guid CustomerId { get; set; }

        public int SeatId { get; set; }

        public Guid BillboardId { get; set; }
        public bool? Estado { get; set; }

    }
}
