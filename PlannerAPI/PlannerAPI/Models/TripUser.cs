using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlannerAPI.Models
{
    public class TripUser
    {
        [Key]
        public int IDtripUser { get; set; }

        [Required]
        public int IDuser { get; set; }

        [Required]
        public int IDtrip { get; set; }

        [ForeignKey("IDuser")]
        public User? User { get; set; }

        [ForeignKey("IDtrip")]
        public Trip? Trip { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime JoinDate { get; set; } = DateTime.Now;
    }
}
