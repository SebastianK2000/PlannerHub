using System.ComponentModel.DataAnnotations;

namespace PlannerAPI.Models
{
    public class Booking
    {
        [Key]
        public int IDbooking { get; set; }
        public int IDuser { get; set; }
        public int IDaccommodation { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int? TotalPrice { get; set; }
        public string Status { get; set; }
    }
}
