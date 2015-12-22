using System;
using System.Collections.Generic;
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

        public void SetPaymentId(long userId, string paymentId)
        {
            _userRepository.SetPaymentId(userId, paymentId);
        }

        public IEnumerable<PaymentMethod> GetPaymentMethods()
        {
            return _userRepository.GetPaymentMethods(UserIdentity.Current.User.Id);
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

        public IEnumerable<BankAccount> GetBankAccounts()
        {
            return _userRepository.GetBankAccounts(UserIdentity.Current.User.Id);
        }

        public void CreateBankAccount(BankAccount bankAccount)
        {
            bankAccount.UserId = UserIdentity.Current.User.Id;

            _userRepository.CreateBankAccount(bankAccount);
        }

        public void UpdateBankAccount(BankAccount bankAccount)
        {
            _userRepository.UpdateBankAccount(bankAccount);
        }

        public void DeleteBankAccount(long id)
        {
            _userRepository.DeleteBankAccount(id);
        }
    }
}