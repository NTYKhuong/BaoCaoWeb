using System.ComponentModel.DataAnnotations;

namespace BanDoNoiThat.Models
{
    public class OrderDetails
    {
        [Key]
        public int detail_id { get; set; }
        public int? total_quantity { get; set; }
	    public double? sale_price { get; set; }
        // Thuoc tinh khoa ngoai
        public int order_id { get; set; }
        public int product_id { get; set; }
        // Thuoc tinh dieu huong den lop Products
        public Orders Orders { get; set; }
        public Products Products { get; set; }
    }
}
