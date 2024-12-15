using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BanDoNoiThat.Models
{
    public class Role
    {
        [Key]
        public int role_id { get; set; }
        public string? roleName { get; set; }
        [JsonIgnore]
        public ICollection<Account>? Accounts { get; set; }
    }
}
