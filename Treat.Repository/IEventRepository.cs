using System.Collections;
using System.Collections.Generic;
using Treat.Model;

namespace Treat.Repository
{
    public interface IEventRepository
    {
        IList<Event> GetEvents();
        void CreateEvent(Event @event);
    }
}