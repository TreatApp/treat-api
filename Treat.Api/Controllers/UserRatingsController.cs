using System.Web.Http;
using Treat.Api.Authentication;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    [BasicAuthenticationFilter]
    public class UserRatingsController : ApiController
    {
        private readonly IUserService _userService;

        public UserRatingsController()
        {
            _userService = new UserService();
        }

        public void Post(int id, [FromBody]UserRating userRating)
        {
            userRating.EventId = id;
            _userService.CreateUserRating(userRating);
        }
    }
}