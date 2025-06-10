namespace PlannerAPI.Models
{
    namespace PlannerAPI.DTOs
    {
        public class AccommodationDto
        {
            public int? IDuser { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string Address { get; set; }
            public decimal Price { get; set; }
            public DateTime Date { get; set; }
        }
    }

}
