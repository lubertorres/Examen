namespace Examen.Dtos
{
    public class EditMovieDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string Genero { get; set; } = null!;

        public int AllowedAge { get; set; }

        public int LengthMinutes { get; set; }
    }
}
