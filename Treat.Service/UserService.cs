using System;
using System.Diagnostics;
using System.Threading;
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

        public User GetUser(long? id = null)
        {
            return id == null
                ? _userRepository.GetUserByExternalId(Thread.CurrentPrincipal.Identity.Name)
                : _userRepository.GetUser(id.Value);
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