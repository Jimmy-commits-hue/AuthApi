using System.ComponentModel.DataAnnotations;

namespace AuthApiBackend.Models
{

    public class User
    {

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string IdNumber { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public DateOnly RegistrationDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        public ContactDetails ContactDetails { get; set; } = null!;

    }

}
