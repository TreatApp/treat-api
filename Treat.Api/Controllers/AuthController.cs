using System.Web.Http;
using Treat.Api.Authentication;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    public class AuthController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IPaymentService _paymentService;

        public AuthController(IUserService userService, IPaymentService paymentService)
        {
            _userService = userService;
            _paymentService = paymentService;
        }

        [HttpPost]
        public void Login([FromBody] User user)
        {
            _userService.Login(user);
        }

        [BasicAuthenticationFilter]
        public UserSession Get()
        {
            var paymentToken = _paymentService.GetClientToken(UserIdentity.Current.User.PaymentId);

            return new UserSession
            {
                Id = UserIdentity.Current.User.Id,
                ExternalId = UserIdentity.Current.User.ExternalId,
                PaymentToken = paymentToken
            };
        }
    }
}