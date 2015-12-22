using Treat.Model;

namespace Treat.Service
{
    public interface IPaymentService
    {
        string GetClientToken(string customerId = null);
        string CreateCustomer(string firstName, string lastName);
        string CreatePaymentMethod(string customerId, string paymentMethod);
        string CreatePayment(string customerId, string token, decimal amount);
    }
}