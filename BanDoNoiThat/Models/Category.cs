using System.ComponentModel.DataAnnotations;

namespace BanDoNoiThat.Models
{
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set; }
        // Collection cho moi quan he mot-nhieu
        public ICollection<Products> Products { get; set; }
    }
}
