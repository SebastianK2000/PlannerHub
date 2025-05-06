namespace PlannerAPI.Models
{
    public class Trip
    {
        public int IDtrip { get; set; }
        public int IDuser { get; set; }
        public string TripName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Destination { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
