using System.Collections.Generic;
using System.Web.Http;
using Treat.Api.Authentication;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    [BasicAuthenticationFilter]
    public class CategoriesController : ApiController
    {
        private readonly IEventService _eventService;

        public CategoriesController()
        {
            _eventService = new EventService();
        }

        public IList<Category> Get()
        {
            return _eventService.GetCategories();
        }
    }
}