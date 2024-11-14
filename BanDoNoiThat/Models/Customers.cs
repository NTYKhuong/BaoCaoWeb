using System.ComponentModel.DataAnnotations;

namespace BanDoNoiThat.Models
{
    public class Customers
    {
        [Key]
        public int customer_id { get; set; }
        public string? customer_name { get; set; }
	    public string? address { get; set; }
        public string? phone_number { get; set; }
        // Collection cho moi quan he mot-nhieu
        public ICollection<Orders> Orders { get; set; } = new List<Orders>();
    }
}
