using System.Collections.Generic;
using System.Web.Http;
using Treat.Api.Authentication;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    [BasicAuthenticationFilter]
    public class EventRequestsController : ApiController
    {
        private readonly IEventService _eventService;

        public EventRequestsController()
        {
            _eventService = new EventService();
        }

        public IEnumerable<EventRequest> Get(int id)
        {
            return _eventService.GetEventRequests(id);
        }

        public void Post(int id, [FromBody]EventRequest eventRequest)
        {
            eventRequest.EventId = id;
            _eventService.CreateEventRequest(eventRequest);
        }

        public void Put(int id, [FromBody]EventRequest eventRequest)
        {
            eventRequest.EventId = id;
            eventRequest.UserId = eventRequest.User.Id;
            _eventService.UpdateEventRequest(eventRequest);
        }
    }
}