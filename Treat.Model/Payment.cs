namespace Treat.Model
{
    public class Payment
    {
        public long UserId { get; set; }
        public long EventId { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
    }
}