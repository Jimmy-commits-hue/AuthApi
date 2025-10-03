using AuthApiBackend.Enums;
using System.ComponentModel.DataAnnotations;

namespace AuthApiBackend.Models
{

    public class Account
    {

        [Key]
        public string UserId { get; set; } = string.Empty;

        public User User { get; set; } = null!;

        public string AccountNumber { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsActive
        {
            get
            {
                return !string.IsNullOrEmpty(AccountNumber);
            }
        }

        public int FailedLoginAttempts {  get; set; } = 0;

        public bool IsLocked
        {
            get
            {
                return LockOutUntilDate.HasValue && LockOutUntilDate.Value > DateTime.UtcNow;
            }
        }

        public DateTime? LockOutUntilDate { get; set; } = null;

        public AccountStatus Status { get; set; } = AccountStatus.Pending;

        public DateTime? ExpectedDeleteDate { get; set; } = null;

    }

}
