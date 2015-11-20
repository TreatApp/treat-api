using System.Collections.Generic;
using System.Web.Http;
using Treat.Model;
using Treat.Repository;
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

        // GET api/events
        public IEnumerable<Event> Get()
        {
            return _eventService.GetEvents();
        }

        // GET api/events/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/events
        public void Post([FromBody]string value)
        {
        }

        // PUT api/events/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/events/5
        public void Delete(int id)
        {
        }
    }
}
