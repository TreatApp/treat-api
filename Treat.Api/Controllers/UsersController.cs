using System.Web.Http;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController()
        {
            _userService = new UserService();
        }

        public User Get(int id)
        {
            return _userService.GetUser(id);
        }

        public void Post([FromBody]User user)
        {
           _userService.CreateUser(user);
        }

        public void Put([FromBody]User user)
        {
            _userService.UpdateUser(user);
        }
    }
}