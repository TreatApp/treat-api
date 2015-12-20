using System.Collections.Generic;
using System.Web.Http;
using Treat.Api.Authentication;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    [BasicAuthenticationFilter]
    public class BankAccountController : ApiController
    {
        private readonly IUserService _userService;

        public BankAccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IEnumerable<BankAccount> Get()
        {
            return _userService.GetBankAccounts();
        }

        public void Post([FromBody]BankAccount bankAccount)
        {
            _userService.CreateBankAccount(bankAccount);
        }
    }
}