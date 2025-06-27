namespace Model_Layer.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = "";
        public decimal UnitPrice { get; set; }

        // Foreign Key
        public int PersonId { get; set; }
        public Person? Person { get; set; }

        // Category ilişkisi
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
    }
}