using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using Treat.Api.Authentication;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    [BasicAuthenticationFilter]
    public class PaymentMethodController : ApiController
    {
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;

        public PaymentMethodController(IPaymentService paymentService, IUserService userService)
        {
            _paymentService = paymentService;
            _userService = userService;
        }

        public IEnumerable<PaymentMethod> Get()
        {
            return _userService.GetPaymentMethods();
        }

        public void Post([FromBody]PaymentMethod paymentMethod)
        {
            var user = UserIdentity.Current.User;

            if (user.PaymentId == null)
            {
                user.PaymentId = _paymentService.CreateCustomer(user.FirstName, user.LastName);
                _userService.SetPaymentId(user.Id, user.PaymentId);
            }

            var token = _paymentService.CreatePaymentMethod(user.PaymentId, paymentMethod.ExternalId);
            
            paymentMethod.UserId = user.Id;
            paymentMethod.ExternalId = token;
            _userService.CreatePaymentMethod(paymentMethod);
        }

        public void Delete(int id)
        {
            _userService.DeletePaymentMethod(id);
        }
    }
}