namespace Examen.Dtos
{
    public class EditCustomerDto
    {
        public Guid DocumentNumber { get; set; }

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int Age { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public bool Estado { get; set; }
    }
}
