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
    }
}