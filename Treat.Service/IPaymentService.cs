using Treat.Model;

namespace Treat.Service
{
    public interface IPaymentService
    {
        string GetClientToken(string customerId = null);
        string CreateCustomer(string email, string description, string token);
        string CreatePaymentMethod(string customerId, string paymentMethod);
        string CreatePayment(string customerId, string token, decimal amount);
        void CancelPayment(string transactionId);
        void RefundPayment(string transactionId);
    }
}