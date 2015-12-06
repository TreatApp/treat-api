using System;
using Treat.Model;
using Treat.Repository;

namespace Treat.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(long? id = null)
        {
            return id == null
                ? UserIdentity.Current.User
                : _userRepository.GetUser(id.Value);
        }

        public User GetUserByExternalId(string externalId)
        {
            return _userRepository.GetUserByExternalId(externalId);
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

        public void CreateUserRating(UserRating userRating)
        {
            userRating.Created = DateTime.Now;

            _userRepository.CreateUserRating(userRating);
        }

        public void CreatePaymentMethod(PaymentMethod paymentMethod)
        {
            _userRepository.CreatePaymentMethod(paymentMethod);
        }

        public void UpdatePaymentMethod(PaymentMethod paymentMethod)
        {
            _userRepository.UpdatePaymentMethod(paymentMethod);
        }

        public void DeletePaymentMethod(long id)
        {
            _userRepository.DeletePaymentMethod(id);
        }
    }
}