namespace Examen.Dtos
{
    public class EditGlobalRoomDto
    {
        public Guid RoomId { get; set; }

        public string Name { get; set; } = null!;

        public int Number { get; set; }
    }
}
