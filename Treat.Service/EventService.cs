using System;
using System.Collections.Generic;
using System.Threading;
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

        public Event GetEvent(long id)
        {
            return _eventRepository.GetEvent(id);
        }

        public void CreateEvent(Event @event)
        {
            @event.Created = DateTime.Now;
            @event.UserId = UserIdentity.Current.User.Id;
            @event.Location.Country = "Sweden";

            _eventRepository.CreateEvent(@event);
        }

        public void UpdateEvent(Event @event)
        {
            @event.UserId = UserIdentity.Current.User.Id;
            @event.Location.Country = "Sweden";

            _eventRepository.UpdateEvent(@event);
        }

        public void DeleteEvent(long id)
        {
            _eventRepository.DeleteEvent(id);
        }

        public void CreateEventLog(EventLog eventLog)
        {
            eventLog.Created = DateTime.Now;
            eventLog.UserId = UserIdentity.Current.User.Id;

            _eventRepository.CreateEventLog(eventLog);
        }

        public void CreateEventRequest(EventRequest eventRequest)
        {
            eventRequest.Created = DateTime.Now;
            eventRequest.UserId = UserIdentity.Current.User.Id;

            _eventRepository.CreateEventRequest(eventRequest);
        }

        public void UpdateEventRequest(EventRequest eventRequest)
        {
            _eventRepository.UpdateEventRequest(eventRequest);
        }

        public void CreateEventRating(EventRating eventRating)
        {
            eventRating.Created = DateTime.Now;
            eventRating.UserId = UserIdentity.Current.User.Id;
            
            _eventRepository.CreateEventRating(eventRating);
        }

        public IList<Category> GetCategories()
        {
            return _eventRepository.GetCategories();
        }

        public IList<EventLog> GetEventLogs(int eventId)
        {
            return _eventRepository.GetEventLogs(eventId);
        }

        public IList<EventRequest> GetEventRequests(int eventId)
        {
            return _eventRepository.GetEventRequests(eventId);
        }
    }
}
