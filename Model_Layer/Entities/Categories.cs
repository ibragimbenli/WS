using System.ComponentModel.DataAnnotations.Schema;

namespace Model_Layer.Entities
{
    [Table("Categories")]
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = "";
        public string Description { get; set; } = "";

        // 1 kategori = birden çok ürün
        //public List<Product>? Products { get; set; }
    }
}