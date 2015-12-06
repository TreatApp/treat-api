using Treat.Model;

namespace Treat.Repository
{
    public interface IUserRepository
    {
        User GetUser(long id);
        User GetUserByExternalId(string externalId);
        void CreateUser(User user);
        void UpdateUser(User user);
        void CreateUserRating(UserRating userRating);
        void CreatePaymentMethod(PaymentMethod paymentMethod);
        void UpdatePaymentMethod(PaymentMethod paymentMethod);
        void DeletePaymentMethod(long id);
    }
}