namespace Examen.Dtos
{
    public class MovieDto
    {
        public string Name { get; set; } = null!;

        public string Genero { get; set; } = null!;

        public int AllowedAge { get; set; }

        public int LengthMinutes { get; set; }
    }
}
