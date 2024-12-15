using System.ComponentModel.DataAnnotations;

namespace BanDoNoiThat.Models
{
    public class Account
    {
        [Key]
        public int account_id { get; set; }
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int? role_id { get; set; }
        public Role? Role { get; set; }
    }
}
