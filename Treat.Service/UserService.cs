using System;
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

        public void Login(User user)
        {
            var existingUser = _userRepository.GetUserByExternalId(user.ExternalId);

            if (existingUser == null)
            {
                user.Created = DateTime.Now;
                _userRepository.CreateUser(user);                
            }
        }
    }
}