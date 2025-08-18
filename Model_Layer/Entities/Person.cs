using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Model_Layer.Entities
{
    [Table("Employees")]
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        //public string? Email { get; set; }
        public DateTime BirthDate { get; set; }
        // Navigation Property
        public List<Product>? Products { get; set; }
    }

    public class Tarim
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? National_Identity_Number { get; set; }
        public string? SurName { get; set; }
        //public string? Email { get; set; }
        public DateTime Birth_Date { get; set; }
        // Navigation Property
        public int Kimlik_İlce { get; set; }
    }
}
