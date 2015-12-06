using System.Collections.Generic;
using System.Web.Http;
using Treat.Api.Authentication;
using Treat.Model;
using Treat.Service;

namespace Treat.Api.Controllers
{
    [BasicAuthenticationFilter]
    public class EventLogsController : ApiController
    {
        private readonly IEventService _eventService;

        public EventLogsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public IEnumerable<EventLog> Get(int id)
        {
            return _eventService.GetEventLogs(id);
        }

        public void Post(int id, [FromBody]EventLog eventLog)
        {
            eventLog.EventId = id;
            eventLog.Type = EventLogType.Comment;
            _eventService.CreateEventLog(eventLog);
        }
    }
}