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
                db.SaveChanges();
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
    }
}