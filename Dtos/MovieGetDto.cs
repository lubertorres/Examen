namespace Examen.Dtos
{
    public class MovieGetDto
    {
        public Guid MovieId { get; set; }

        public string Name { get; set; } = null!;

        public string Genero { get; set; } = null!;

        public int AllowedAge { get; set; }

        public int LengthMinutes { get; set; }

        public DateTime DateB { get; set; }
    }
}
