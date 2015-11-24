using System.Web.Http;
using Treat.Api.Authentication;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    [BasicAuthenticationFilter]
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