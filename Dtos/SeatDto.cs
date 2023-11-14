namespace Examen.Dtos
{
    public class SeatDto
    {
        public int SeatId { get; set; }

        public int RowNumber { get; set; }

        public Guid RoomId { get; set; }

        public bool Estado { get; set; }
    }
}
