using Treat.Model;

namespace Treat.Service
{
    public interface IPaymentService
    {
        void Pay(Payment payment);
    }
}