using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Treat.Repository;
using Treat.Service;

namespace Treat.Api
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventRepository>().As<IEventRepository>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();

            builder.RegisterType<BraintreeService>().As<IPaymentService>().SingleInstance();
            builder.RegisterType<EventService>().As<IEventService>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
