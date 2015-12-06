using System.Collections.Generic;
using System.Web.Http;
using Treat.Api.Authentication;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    [BasicAuthenticationFilter]
    public class EventRatingsController : ApiController
    {
        private readonly IEventService _eventService;

        public EventRatingsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public void Post(int id, [FromBody]EventRating eventRating)
        {
            eventRating.EventId = id;
            _eventService.CreateEventRating(eventRating);
        }
    }
}