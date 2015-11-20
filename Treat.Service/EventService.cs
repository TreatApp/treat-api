using System.Collections.Generic;
using Treat.Model;
using Treat.Repository;

namespace Treat.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService()
        {
            _eventRepository = new EventRepository();
        }

        public IList<Event> GetEvents()
        {
            return _eventRepository.GetEvents();
        }

        public void CreateEvent(Event @event)
        {
            _eventRepository.CreateEvent(@event);
        }
    }
}
