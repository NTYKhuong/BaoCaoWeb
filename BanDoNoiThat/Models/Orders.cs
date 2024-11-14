using System.ComponentModel.DataAnnotations;

namespace BanDoNoiThat.Models
{
    public class Orders
    {
        [Key]
        public int order_id { get; set; }
        public DateTime? order_date { get; set; }
	    public double? total_price { get; set; }
        // Thuoc tinh khoa ngoai
        public int customer_id { get; set; }
        // Thuoc tinh dieu huong den lop Customers
        public Customers Customers { get; set; }
        // Collection cho moi quan he mot-nhieu
        public ICollection<OrderDetails> Order_details { get; set; } = new List<OrderDetails>();
    }
}
