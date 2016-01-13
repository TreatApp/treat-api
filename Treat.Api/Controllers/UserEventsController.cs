using System.Collections.Generic;
using System.Web.Http;
using Treat.Api.Authentication;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    [BasicAuthenticationFilter]
    public class UserEventsController : ApiController
    {
        private readonly IEventService _eventService;

        public UserEventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IEnumerable<Event> Get()
        {
            return _eventService.GetUserEvents();
        }
    }
}