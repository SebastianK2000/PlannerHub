using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlannerAPI.Models
{
    public class Payment
    {
        [Key]
        public int IDpayment { get; set; }

        public int IDbooking { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime PaymentDate { get; set; } = DateTime.Now;

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

        public string Status { get; set; }
    }
}
