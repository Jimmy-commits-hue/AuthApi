using System.ComponentModel.DataAnnotations.Schema;

namespace AuthApiBackend.Models
{
    public class Role
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string RoleName { get; set; } = null!;

        public List<User> User { get; set; } = new();

    }

}
