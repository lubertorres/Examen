namespace Examen.Dtos
{
    public class BilboardEntityGetAll
    {
        public Guid BillboardId { get; set; }

        public DateTime DateB { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Guid MovieId { get; set; }

        public Guid RoomId { get; set; }

        public bool Estado { get; set; }
    }
}
