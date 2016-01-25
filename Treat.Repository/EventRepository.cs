using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Treat.Model;

namespace Treat.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly ISettings _settings;

        public EventRepository(ISettings settings)
        {
            _settings = settings;
        }

        public IList<Event> GetEvents()
        {
            using (var db = new Database(_settings))
            {
                var events = from e in GetEvents(db)
                    where e.Start > DateTime.Now
                    select e;

                return events.ToList();
            }
        }

        public IList<Event> GetUserEvents(long userId)
        {
            using (var db = new Database(_settings))
            {
                var events = from e in GetEvents(db)
                             where e.UserId == userId || e.EventRequests.Any(r => r.UserId == userId)
                             select e;

                return events.ToList();
            }
        }

        public Event GetEvent(long id)
        {
            using (var db = new Database(_settings))
            {
                return GetEvents(db).FirstOrDefault(e => e.Id == id);
            }
        }

        private IQueryable<Event> GetEvents(Database db)
        {
            return db.Events
                .Include(e => e.User)
                .Include(e => e.Location)
                .Include(e => e.Categories)
                .Include(e => e.EventImages);
        }

        public void CreateEvent(Event @event)
        {
            using (var db = new Database(_settings))
            {
                var categoryIds = @event.Categories.Select(c => c.Id).ToList();

                @event.Categories.Clear();
                foreach (var category in db.Categories.Where(c => categoryIds.Contains(c.Id)))
                {
                    @event.Categories.Add(category);
                }

                @event.SlotsAvailable = @event.Slots;

                db.Events.Add(@event);
                db.SaveChanges();
            }
        }

        public void CreateEventLog(EventLog eventLog)
        {
            using (var db = new Database(_settings))
            {
                db.EventLogs.Add(eventLog);
                db.SaveChanges();
            }
        }

        public void CreateEventRequest(EventRequest eventRequest)
        {
            using (var db = new Database(_settings))
            {
                db.EventRequests.Add(eventRequest);
                db.SaveChanges();
            }
        }

        public void UpdateEventRequest(EventRequest eventRequest)
        {
            using (var db = new Database(_settings))
            {
                var result = db.EventRequests.FirstOrDefault(e => e.EventId == eventRequest.EventId && e.UserId == eventRequest.UserId);
                if (result != null)
                {
                    result.Status = eventRequest.Status;
                    
                    if (result.Status == EventRequestStatus.Approved)
                        result.Event.SlotsAvailable -= 1;

                    else if (result.Status == EventRequestStatus.Cancelled)
                        result.Event.SlotsAvailable += 1;
                    
                    db.SaveChanges();
                }
            }
        }

        public void CreateEventRating(EventRating eventRating)
        {
            using (var db = new Database(_settings))
            {
                db.EventRatings.Add(eventRating);
                db.SaveChanges();

                var result = db.Events.FirstOrDefault(e => e.Id == eventRating.EventId);
                if (result != null)
                {
                    result.Rating = Convert.ToDecimal(db.EventRatings.Where(e => e.EventId == eventRating.EventId).Average(e => e.Rating));
                    db.SaveChanges();
                }
            }
        }

        public IList<Category> GetCategories()
        {
            using (var db = new Database(_settings))
            {
                return db.Categories.ToList();
            }
        }

        public IList<EventLog> GetEventLogs(int eventId)
        {
            using (var db = new Database(_settings))
            {
                return db.EventLogs.Include(e => e.User).Where(e => e.EventId == eventId).ToList();
            }
        }

        public IList<EventRequest> GetEventRequests(int eventId)
        {
            using (var db = new Database(_settings))
            {
                return db.EventRequests.Include(e => e.User).Where(e => e.EventId == eventId).ToList();
            }
        }

        public void UpdateEvent(Event @event)
        {
            using (var db = new Database(_settings))
            {
                var result = db.Events.FirstOrDefault(e => e.Id == @event.Id);
                if (result != null)
                {
                    var slotsTaken = result.Slots - result.SlotsAvailable;
                    if (@event.Slots < slotsTaken)
                        throw new ArgumentOutOfRangeException("Slots");

                    result.Title = @event.Title;
                    result.Description = @event.Description;
                    result.Start = @event.Start;
                    result.End = @event.End;
                    result.Price = @event.Price;
                    result.Slots = @event.Slots;
                    result.SlotsAvailable = @event.Slots - slotsTaken;
                    result.Location = @event.Location;
                    result.Categories = @event.Categories;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteEvent(long id)
        {
            using (var db = new Database(_settings))
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
