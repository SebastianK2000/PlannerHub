using System.ComponentModel.DataAnnotations;
using System.Data;

namespace PlannerAPI.Models
{
    public class TeamMember
    {
        [Key]
        public int IDteamMember { get; set; }
        public int IDuser { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
