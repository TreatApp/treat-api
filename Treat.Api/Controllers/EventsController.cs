using System;
using System.Collections.Generic;
using System.Web.Http;
using Treat.Api.Authentication;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
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

        [BasicAuthenticationFilter]
        public void Post([FromBody]Event @event)
        {
            _eventService.CreateEvent(@event);
        }

        [BasicAuthenticationFilter]
        public void Put(int id, [FromBody]Event @event)
        {
            _eventService.UpdateEvent(@event);
        }

        [BasicAuthenticationFilter]
        public void Delete(int id)
        {
            _eventService.DeleteEvent(id);
        }
    }
}
