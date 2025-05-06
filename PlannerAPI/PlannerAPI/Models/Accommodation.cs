using System.ComponentModel.DataAnnotations;

namespace PlannerAPI.Models
{
    public class Accommodation
    {
        [Key]
        public int IDaccommodation { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
