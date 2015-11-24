using System;
using System.Collections.Generic;
using System.Threading;
using Treat.Model;
using Treat.Repository;

namespace Treat.Service
{
    public class EventService : IEventService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEventRepository _eventRepository;

        public EventService()
        {
            _userRepository = new UserRepository();
            _eventRepository = new EventRepository();
        }

        public IList<Event> GetEvents()
        {
            return _eventRepository.GetEvents();
        }

        public Event GetEvent(long id)
        {
            return _eventRepository.GetEvent(id);
        }

        public void CreateEvent(Event @event)
        {
            var existingUser = _userRepository.GetUserByExternalId(Thread.CurrentPrincipal.Identity.Name);

            @event.Created = DateTime.Now;
            @event.UserId = existingUser.Id;
            @event.Location.Country = "Sweden";

            _eventRepository.CreateEvent(@event);
        }

        public void UpdateEvent(Event @event)
        {
            _eventRepository.UpdateEvent(@event);
        }

        public void DeleteEvent(long id)
        {
            _eventRepository.DeleteEvent(id);
        }

        public void CreateEventLog(EventLog eventLog)
        {
            _eventRepository.CreateEventLog(eventLog);
        }

        public void CreateEventRequest(EventRequest eventRequest)
        {
            _eventRepository.CreateEventRequest(eventRequest);
        }

        public void CreateEventRating(EventRating eventRating)
        {
            _eventRepository.CreateEventRating(eventRating);
        }

        public IList<Category> GetCategories()
        {
            return _eventRepository.GetCategories();
        }
    }
}
