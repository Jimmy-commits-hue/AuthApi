using System.ComponentModel.DataAnnotations;

namespace AuthApiBackend.DTOs
{

    public class RegisterDto
    {

        [Required]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "Invalid Id Number")]
        public string IdNumber { get; set; } = string.Empty;

        [Required]
        public string FirstName = string.Empty;

        public string firstName
        {
            set => FirstName = value.Split(' ')[0];
            get => FirstName;
        }

        [Required]
        public string Surname { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email required")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirm email")]
        [EmailAddress]
        [Compare("Email", ErrorMessage = "Email mismatch")]
        public string confirmEmail { get; set; } = string.Empty;

    }

}
