namespace AuthApiBackend.DTOs.TemplatesDto
{

    public class NotificationDto
    {

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Subject { get; set; } = null!;

        public string ToEmail { get; set; } = null!;

        public string VerificationLink { get; set; } = string.Empty; 

        public string VerificationType { get; set; } = null!;

        public string? AccountNumber { get; set; } = string.Empty;

    }

}
