using Treat.Model;

namespace Treat.Repository
{
    public interface IUserRepository
    {
        User GetUser(long id);
        User GetUserByExternalId(string externalId);
        void CreateUser(User user);
        void UpdateUser(User user);
    }
}