using System.Data;

namespace PlannerAPI.Models
{
    public class TeamMember
    {
        public int IDteam { get; set; }
        public int IDuser { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
