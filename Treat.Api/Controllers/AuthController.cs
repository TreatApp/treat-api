using System.Web.Http;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public void Login([FromBody] User user)
        {
            _userService.Login(user);
        }
    }
}