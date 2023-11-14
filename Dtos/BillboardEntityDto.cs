namespace Examen.Dtos
{
    public class BillboardEntityDto
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Guid MovieId { get; set; }

        public Guid RoomId { get; set; }

        public bool Estado { get; set; }
    }
}
