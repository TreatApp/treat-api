using Treat.Model;

namespace Treat.Service
{
    public interface IUserService
    {
        User GetUser();
        void CreateUser(User user);
        void UpdateUser(User user);
    }
}