using System;
using System.Collections.Generic;
using System.Linq;
using Treat.Model;

namespace Treat.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ISettings _settings;

        public UserRepository(ISettings settings)
        {
            _settings = settings;
        }

        public User GetUser(long id)
        {
            using (var db = new Database(_settings))
            {
                return db.SingleOrDefault<User>("where Id = @0", id);
            }
        }

        public User GetUserByExternalId(string externalId)
        {
            using (var db = new Database(_settings))
            {
                return db.SingleOrDefault<User>("where ExternalId = @0", externalId);
            }
        }

        public void CreateUser(User user)
        {
            using (var db = new Database(_settings))
            {
                db.Insert(user);
            }
        }

        public void UpdateUser(User user)
        {
            using (var db = new Database(_settings))
            {
                db.Update<User>("set Email = @1, Description = @2 where Id = @0", user.Id, user.Email, user.Description);
            }
        }

        public void CreateUserRating(UserRating userRating)
        {
            using (var db = new Database(_settings))
            using (var transaction = db.GetTransaction())
            {
                db.Insert(userRating);
                var rating = Convert.ToDecimal(db.Query<UserRating>("where UserId = @0", userRating.UserId).Average(r => r.Rating));
                db.Update<User>("set Rating = @1 where Id = @0", userRating.UserId, rating);
                transaction.Complete();
            }
        }

        public void SetPaymentId(long userId, string paymentId)
        {
            using (var db = new Database(_settings))
            {
                db.Update<User>("set PaymentId = @1 where Id = @0", userId, paymentId);
            }
        }

        public IEnumerable<PaymentMethod> GetPaymentMethods(long userId)
        {
            using (var db = new Database(_settings))
            {
                return db.Query<PaymentMethod>("where UserId = @0", userId);
            }
        }

        public void CreatePaymentMethod(PaymentMethod paymentMethod)
        {
            using (var db = new Database(_settings))
            {
                db.Insert(paymentMethod);
            }
        }

        public void UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            using (var db = new Database(_settings))
            {
                db.Update<PaymentMethod>("set ExternalId = @1 where Id = @0", paymentMethod.Id, paymentMethod.ExternalId);
            }
        }

        public void DeletePaymentMethod(long id)
        {
            using (var db = new Database(_settings))
            {
                db.Delete<PaymentMethod>("where Id = @0", id);
            }
        }

        public IEnumerable<BankAccount> GetBankAccounts(long userId)
        {
            using (var db = new Database(_settings))
            {
                return db.Query<BankAccount>("where UserId = @0", userId);
            }
        }

        public void CreateBankAccount(BankAccount bankAccount)
        {
            using (var db = new Database(_settings))
            {
                db.Insert(bankAccount);
            }
        }

        public void UpdateBankAccount(BankAccount bankAccount)
        {
            using (var db = new Database(_settings))
            {
                db.Update<BankAccount>("set Name = @1, Number = @2 where Id = @0", bankAccount.Id, bankAccount.Name, bankAccount.Number);
            }
        }

        public void DeleteBankAccount(long id)
        {
            using (var db = new Database(_settings))
            {
                db.Delete<BankAccount>("where Id = @0", id);
            }
        }
    }
}