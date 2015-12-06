using System.Web;
using System.Web.Http;

namespace Treat.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            AutofacConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}
