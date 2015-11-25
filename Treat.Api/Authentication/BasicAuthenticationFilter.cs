using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Authentication
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicAuthenticationFilter : AuthorizationFilterAttribute
    {
        private readonly IUserService _userService;

        public BasicAuthenticationFilter()
        {
            _userService = new UserService();
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var identity = ParseAuthorizationHeader(actionContext);
            if (identity == null)
            {
                Challenge(actionContext);
                return;
            }

            var user = _userService.GetUserByExternalId(identity.ExternalId);
            if (user == null)
            {
                Challenge(actionContext);
                return;
            }

            identity.User = user;
            var principal = new GenericPrincipal(identity, null);
            Thread.CurrentPrincipal = principal;

            base.OnAuthorization(actionContext);
        }

        private UserIdentity ParseAuthorizationHeader(HttpActionContext actionContext)
        {
            string authHeader = null;
            var auth = actionContext.Request.Headers.Authorization;
            if (auth != null && auth.Scheme == "Basic")
                authHeader = auth.Parameter;

            if (string.IsNullOrEmpty(authHeader))
                return null;

            authHeader = Encoding.Default.GetString(Convert.FromBase64String(authHeader));

            var tokens = authHeader.Split(':');
            if (tokens.Length < 2)
                return null;

            return new UserIdentity(tokens[0]);
        }

        private static void Challenge(HttpActionContext actionContext)
        {
            var host = actionContext.Request.RequestUri.DnsSafeHost;
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", host));
        }
    }
}