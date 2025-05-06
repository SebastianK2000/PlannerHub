using System.ComponentModel.DataAnnotations;

namespace PlannerAPI.Models
{
    public class TripUser
    {
        [Key]
        public int IDtripUser { get; set; }
        public int IDuser { get; set; }
        public DateTime JoinDate { get; set; }

    }
}
