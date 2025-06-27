using Model_Layer.Entities;

namespace App_Service_Layer.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; } = "";
        public decimal Price { get; set; }

        public Category? Category { get; set; }
    }
}
