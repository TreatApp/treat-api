using System.Collections.Generic;
using Treat.Model;

namespace Treat.Service
{
    public interface IUserService
    {
        User GetUser(long? id);
        User GetUserByExternalId(string externalId);
        void CreateUser(User user);
        void UpdateUser(User user);
        void Login(User user);
        void CreateUserRating(UserRating userRating);
        void CreatePaymentMethod(PaymentMethod paymentMethod);
        void UpdatePaymentMethod(PaymentMethod paymentMethod);
        void DeletePaymentMethod(long id);
        IEnumerable<PaymentMethod> GetPaymentMethods();
        IEnumerable<BankAccount> GetBankAccounts();
        void CreateBankAccount(BankAccount bankAccount);
    }
}