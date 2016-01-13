using System.Collections.Generic;
using System.Linq;
using Treat.Model;

namespace Treat.Repository
{
    public class UserRepository : IUserRepository
    {
        public User GetUser(long id)
        {
            using (var db = new Database())
            {
                return db.Users.FirstOrDefault(u => u.Id == id);
            }
        }

        public User GetUserByExternalId(string externalId)
        {
            using (var db = new Database())
            {
                return db.Users.FirstOrDefault(u => u.ExternalId == externalId);
            }
        }

        public void CreateUser(User user)
        {
            using (var db = new Database())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void UpdateUser(User user)
        {
            using (var db = new Database())
            {
                var result = db.Users.FirstOrDefault(u => u.Id == user.Id);
                if (result != null)
                {
                    result.Email = user.Email;
                    result.Description = user.Description;
                    db.SaveChanges();
                }
            }
        }

        public void CreateUserRating(UserRating userRating)
        {
            using (var db = new Database())
            {
                db.UserRatings.Add(userRating);

                var result = db.Users.FirstOrDefault(e => e.Id == userRating.UserId);
                if (result != null)
                    result.Rating = db.UserRatings.Where(u => u.UserId == userRating.UserId).Average(u => u.Rating);

                db.SaveChanges();
            }
        }

        public void SetPaymentId(long userId, string paymentId)
        {
            using (var db = new Database())
            {
                var result = db.Users.FirstOrDefault(u => u.Id == userId);
                if (result != null)
                {
                    result.PaymentId = paymentId;
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<PaymentMethod> GetPaymentMethods(long userId)
        {
            using (var db = new Database())
            {
                return db.PaymentMethods.Where(u => u.UserId == userId).ToList();
            }
        }

        public void CreatePaymentMethod(PaymentMethod paymentMethod)
        {
            using (var db = new Database())
            {
                db.PaymentMethods.Add(paymentMethod);
                db.SaveChanges();
            }
        }

        public void UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            using (var db = new Database())
            {
                var result = db.PaymentMethods.FirstOrDefault(p => p.Id == paymentMethod.Id);
                if (result != null)
                {
                    result.ExternalId = paymentMethod.ExternalId;
                    db.SaveChanges();
                }
            }
        }

        public void DeletePaymentMethod(long id)
        {
            using (var db = new Database())
            {
                var result = db.PaymentMethods.FirstOrDefault(u => u.Id == id);
                if (result != null)
                {
                    db.PaymentMethods.Remove(result);
                    db.SaveChanges();
                }
            }
        }

        public IEnumerable<BankAccount> GetBankAccounts(long userId)
        {
            using (var db = new Database())
            {
                return db.BankAccounts.Where(u => u.UserId == userId).ToList();
            }
        }

        public void CreateBankAccount(BankAccount bankAccount)
        {
            using (var db = new Database())
            {
                db.BankAccounts.Add(bankAccount);
                db.SaveChanges();
            }
        }

        public void UpdateBankAccount(BankAccount bankAccount)
        {
            using (var db = new Database())
            {
                var result = db.BankAccounts.FirstOrDefault(p => p.Id == bankAccount.Id);
                if (result != null)
                {
                    result.Name = bankAccount.Name;
                    result.Number = bankAccount.Number;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteBankAccount(long id)
        {
            using (var db = new Database())
            {
                var result = db.BankAccounts.FirstOrDefault(u => u.Id == id);
                if (result != null)
                {
                    db.BankAccounts.Remove(result);
                    db.SaveChanges();
                }
            }
        }
    }
}