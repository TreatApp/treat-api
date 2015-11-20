using System.Collections;
using System.Collections.Generic;
using Treat.Model;

namespace Treat.Service
{
    public interface IEventService
    {
        IList<Event> GetEvents();

        void CreateEvent(Event @event);
    }
}