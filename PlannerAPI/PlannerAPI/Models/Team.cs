using System.ComponentModel.DataAnnotations;

namespace PlannerAPI.Models
{
    public class Team
    {
        [Key]
        public int IDteam { get; set; }
        public string TeamName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
