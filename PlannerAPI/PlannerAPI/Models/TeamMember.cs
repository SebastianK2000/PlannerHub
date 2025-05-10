using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlannerAPI.Models
{
    public class TeamMember
    {
        [Key]
        public int IDteamMember { get; set; }

        public int IDuser { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime JoinDate { get; set; } = DateTime.Now;
    }
}
