using Treat.Model;
using Treat.Repository;

namespace Treat.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public User GetUser(long id)
        {
            return _userRepository.GetUser(id);
        }

        public void CreateUser(User user)
        {
            _userRepository.CreateUser(user);            
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);            
        }
    }
}