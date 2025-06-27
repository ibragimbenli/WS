namespace App_Service_Layer.DTOs
{
    public class CreatePersonDto
    {
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime BirthDate { get; set; }
    }
}
