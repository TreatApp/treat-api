using System.Web.Http;
using Treat.Api.Authentication;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUserService _userService;

        public AuthController()
        {
            _userService = new UserService();
        }

        [HttpPost]
        public void Login([FromBody] User user)
        {
            _userService.Login(user);
        }
    }
}