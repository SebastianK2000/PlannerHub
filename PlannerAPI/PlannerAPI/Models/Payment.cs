namespace PlannerAPI.Models
{
    public class Payment
    {
        public int IDpayment { get; set; }
        public int IDbooking { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }
}
