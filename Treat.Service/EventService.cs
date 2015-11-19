using System.Collections.Generic;
using Treat.Model;
using Treat.Repository;

namespace Treat.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IList<Event> GetEvents()
        {
            return _eventRepository.GetEvents();
        }
    }
}
