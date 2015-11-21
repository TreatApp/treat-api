using System;
using System.Data.Entity;
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
                var events = from e in GetEvents(db)
                    where e.Start > DateTime.Now
                    select e;

                return events.ToList();
            }
        }

        public Event GetEvent(long id)
        {
            using (var db = new Database())
            {
                return GetEvents(db).FirstOrDefault(e => e.Id == id);
            }
        }

        private IQueryable<Event> GetEvents(Database db)
        {
            return db.Events
                .Include(e => e.User)
                .Include(e => e.Location)
                .Include(e => e.Categories);
        }

        public void CreateEvent(Event @event)
        {
            using (var db = new Database())
            {
                db.Events.Add(@event);
                db.SaveChanges();
            }
        }

        public void CreateEventLog(EventLog eventLog)
        {
            using (var db = new Database())
            {
                db.EventLogs.Add(eventLog);
                db.SaveChanges();
            }
        }

        public void CreateEventRequest(EventRequest eventRequest)
        {
            using (var db = new Database())
            {
                db.EventRequests.Add(eventRequest);
                db.SaveChanges();
            }
        }

        public void CreateEventRating(EventRating eventRating)
        {
            using (var db = new Database())
            {
                db.EventRatings.Add(eventRating);
                db.SaveChanges();
            }
        }

        public IList<Category> GetCategories()
        {
            using (var db = new Database())
            {
                return db.Categories.ToList();
            }
        }

        public void UpdateEvent(Event @event)
        {
            using (var db = new Database())
            {
                var result = db.Events.FirstOrDefault(e => e.Id == @event.Id);
                if (result != null)
                {
                    result.Title = @event.Title;
                    result.Description = @event.Description;
                    result.Start = @event.Start;
                    result.End = @event.End;
                    result.Price = @event.Price;
                    result.Slots = @event.Slots;
                    result.Location = @event.Location;
                    result.Categories = @event.Categories;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteEvent(long id)
        {
            using (var db = new Database())
            {
                var result = db.Events.FirstOrDefault(e => e.Id == id);
                if (result != null)
                {
                    db.Events.Remove(result);
                    db.SaveChanges();   
                }
            }
        }
    }
}
