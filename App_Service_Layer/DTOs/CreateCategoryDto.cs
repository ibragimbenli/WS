namespace App_Service_Layer.DTOs
{
    public class CreateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
