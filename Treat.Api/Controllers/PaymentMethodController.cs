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

        public void Post([FromBody]string paymentMethod)
        {
            _paymentService.CreatePaymentMethod(UserIdentity.Current.User.PaymentId, paymentMethod);
        }

        public void Delete(int id)
        {
            _userService.DeletePaymentMethod(id);
        }
    }
}