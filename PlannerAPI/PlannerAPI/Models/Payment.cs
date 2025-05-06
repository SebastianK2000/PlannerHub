using System.ComponentModel.DataAnnotations;

namespace PlannerAPI.Models
{
    public class Payment
    {
        [Key]
        public int IDpayment { get; set; }
        public int IDbooking { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }
}
