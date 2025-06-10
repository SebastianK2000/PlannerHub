using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlannerAPI.Models
{
    public class Booking
    {
        [Key]
        public int IDbooking { get; set; }

        [Required]
        public int IDuser { get; set; }

        [Required]
        public int IDaccommodation { get; set; }

        // opcjonalnie, jeśli chcesz pobierać relacje podczas GET:
        [ForeignKey("IDuser")]
        public User? User { get; set; }

        [ForeignKey("IDaccommodation")]
        public Accommodation? Accommodation { get; set; }

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
