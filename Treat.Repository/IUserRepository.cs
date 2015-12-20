using System.Collections;
using System.Collections.Generic;
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

        IEnumerable<PaymentMethod> GetPaymentMethods(long userId);
        void CreatePaymentMethod(PaymentMethod paymentMethod);
        void UpdatePaymentMethod(PaymentMethod paymentMethod);
        void DeletePaymentMethod(long id);

        IEnumerable<BankAccount> GetBankAccounts(long userId);
        void CreateBankAccount(BankAccount bankAccount);
    }
}