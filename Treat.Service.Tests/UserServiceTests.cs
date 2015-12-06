using System;
using System.Collections.Generic;
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
            var userRepository = new UserRepository();
            _userService = new UserService(userRepository);
        }

        [TestMethod]
        public void Should_get_user()
        {
            var user = _userService.GetUser(7);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void Should_create_user()
        {
            _userService.CreateUser(GetDummyUser());                
        }

        [TestMethod]
        public void Should_update_user()
        {
            var user = _userService.GetUser(7);
            Assert.IsNotNull(user);

            user.ExternalId = DateTime.Now.Ticks.ToString();
            _userService.UpdateUser(user);
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