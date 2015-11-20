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
                    result.ExternalId = user.ExternalId;
                    result.FirstName = user.FirstName;
                    result.LastName = user.LastName;
                    result.Email = user.Email;
                    result.Description = user.Description;
                    db.SaveChanges();
                }
            }
        }
    }
}