using System;
using System.Collections.Generic;
using System.Web.Http;
using Treat.Api.Authentication;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    [BasicAuthenticationFilter]
    public class EventsController : ApiController
    {
        private readonly IEventService _eventService;

        public EventsController()
        {
            _eventService = new EventService();
        }

        public IEnumerable<Event> Get()
        {
            return _eventService.GetEvents();
        }

        public Event Get(int id)
        {
            return _eventService.GetEvent(id);
        }

        public void Post([FromBody]Event @event)
        {
            _eventService.CreateEvent(@event);
        }

        public void Put(int id, [FromBody]Event @event)
        {
            _eventService.UpdateEvent(@event);
        }

        public void Delete(int id)
        {
            _eventService.DeleteEvent(id);
        }
    }
}
