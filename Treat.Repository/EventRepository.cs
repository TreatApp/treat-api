using System;
using System.Collections.Generic;
using System.Linq;
using Treat.Model;

namespace Treat.Repository
{
    public class EventRepository : IEventRepository
    {
        public IList<Event> GetEvents()
        {
            using (var db = new Database())
            {
                var events = from e in db.Events
                    where e.Start > DateTime.Now
                    select e;

                return events.ToList();
            }
        }

        public void CreateEvent(Event @event)
        {
            using (var db = new Database())
            {
                db.Events.Add(@event);
                db.SaveChanges();
            }
        }
    }
}
