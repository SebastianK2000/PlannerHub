using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlannerAPI.Models
{
    public class Booking
    {
        [Key]
        public int IDbooking { get; set; }

        public int IDuser { get; set; }

        public int IDaccommodation { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime BookingDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime CheckInDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime CheckOutDate { get; set; } = DateTime.Now.AddDays(1);

        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = "New";
    }
}
