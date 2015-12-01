using System.Collections.Generic;
using Treat.Model;

namespace Treat.Service
{
    public interface IEventService
    {
        IList<Event> GetEvents();
        Event GetEvent(long id);
        void CreateEvent(Event @event);
        void UpdateEvent(Event @event);
        void DeleteEvent(long id);
        void CreateEventLog(EventLog eventLog);
        void CreateEventRequest(EventRequest eventRequest);
        void UpdateEventRequest(EventRequest eventRequest);
        void CreateEventRating(EventRating eventRating);
        IList<Category> GetCategories();
        IList<EventLog> GetEventLogs(int eventId);
        IList<EventRequest> GetEventRequests(int eventId);
    }
}