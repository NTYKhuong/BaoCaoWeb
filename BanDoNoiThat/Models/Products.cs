using System.ComponentModel.DataAnnotations;

namespace BanDoNoiThat.Models
{
    public class Products
    {
        [Key]
        public int product_id { get; set; }
        public string? product_name { get; set; }
        public string? image_path { get; set; }
        public int? inventory_quantity { get; set; }
        public double? original_price { get; set; }
        public double? unit_price { get; set; }
        public string? description { get; set; }
        public DateTime? create_time { get; set; }
        public DateTime? update_time { get; set; }
        // Thuoc tinh khoa ngoai
        public int category_id { get; set; }
        // Thuoc tinh dieu huong den lop Category
        public Category Category { get; set; }
        // Collection cho moi quan he mot-nhieu
        public ICollection<OrderDetails> Order_details { get; set; } = new List<OrderDetails>();
    }
}
