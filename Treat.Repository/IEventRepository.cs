using System.Collections.Generic;
using Treat.Model;

namespace Treat.Repository
{
    public interface IEventRepository
    {
        IList<Event> GetEvents();
        Event GetEvent(long id);
        void CreateEvent(Event @event);
        void UpdateEvent(Event @event);
        void DeleteEvent(long id);
        void CreateEventLog(EventLog eventLog);
        void CreateEventRequest(EventRequest eventRequest);
        void CreateEventRating(EventRating eventRating);
        IList<Category> GetCategories();
    }
}