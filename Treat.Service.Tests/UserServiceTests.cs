using System;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Treat.Model;
using Treat.Repository;

namespace Treat.Service.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            var settings = new Settings();
            var userRepository = new UserRepository(settings);
            _userService = new UserService(userRepository);
        }

        [TestMethod]
        public void Create_read_and_update_user()
        {
            using (var transaction = new TransactionScope())
            {
                var user = GetDummyUser();

                _userService.CreateUser(user);
                Assert.AreNotEqual(user.Id, 0);

                var newUser = _userService.GetUser(user.Id);
                Assert.IsNotNull(newUser);

                user.Description = "Updated description";
                _userService.UpdateUser(user);

                var updatedUser = _userService.GetUser(user.Id);
                Assert.AreEqual(user.Description, updatedUser.Description);
            }
        }
        
        private static User GetDummyUser()
        {
            return new User
            {
                ExternalId = "12345",
                FirstName = "Victor",
                LastName = "Stodell",
                Email = "victor@stodell.se",
                Description = "Amateur chef",
                Created = DateTime.Now
            };
        }
    }
}