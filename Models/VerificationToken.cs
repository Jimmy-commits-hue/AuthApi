using System.ComponentModel.DataAnnotations;

namespace AuthApiBackend.Models
{

    public class VerificationToken
    {

        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserId { get; set; } = null!;

        public User User { get; set; } = null!;

        public string Token { get; set; } = null!;

        public DateTime ExpiresAt { get; set; }

        public bool IsExpired
        {
            get
            {
                return ExpiresAt > DateTime.UtcNow;
            }
        }

        public bool IsActive { get; set; } = false;

    }

}
