﻿using System;
using System.Collections.Generic;
using System.Linq;
using Treat.Model;
using Treat.Repository.Mappers;

namespace Treat.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly ISettings _settings;

        public EventRepository(ISettings settings)
        {
            _settings = settings;
        }

        private const string SelectEvents =
            "select * from [Event] " +
            "join [User] on [Event].UserId = [User].Id " +
            "join [Location] on [Event].LocationId = [Location].Id " +
            "left join [EventImage] on [Event].Id = [EventImage].EventId " +
            "left join [EventCategory] on [Event].Id = [EventCategory].EventId " +
            "left join [Category] on [EventCategory].CategoryId = [Category].Id ";

        public IList<Event> GetEvents()
        {
            return GetEvents(SelectEvents + "where [Event].Start > @0", DateTime.Now).ToList();
        }

        public IList<Event> GetUserEvents(long userId)
        {
            return GetEvents(SelectEvents + "where [Event].UserId = @0", userId).ToList();
        }

        public Event GetEvent(long id)
        {
            return GetEvents(SelectEvents + "where [Event].Id = @0", id).FirstOrDefault();
        }

        private IEnumerable<Event> GetEvents(string sql, params object[] parameters)
        {
            using (var db = new Database(_settings))
            {
                var mapper = new EventMapper();
                return db.Query<Event>(mapper.Types, mapper.Map, sql, parameters);
            }
        } 

        public void CreateEvent(Event @event)
        {
            using (var db = new Database(_settings))
            using (var transaction = db.GetTransaction())
            {
                db.Insert(@event.Location);

                @event.LocationId = @event.Location.Id;
                @event.SlotsAvailable = @event.Slots;
                db.Insert(@event);

                foreach (var eventImage in @event.Images)
                {
                    eventImage.EventId = @event.Id;
                    db.Insert(eventImage);
                }

                foreach (var category in @event.Categories)
                {
                    db.Insert(new EventCategory
                    {
                        EventId = @event.Id,
                        CategoryId = category.Id
                    });
                }

                transaction.Complete();
            }
        }

        public void CreateEventLog(EventLog eventLog)
        {
            using (var db = new Database(_settings))
            {
                db.Insert(eventLog);
            }
        }

        public void CreateEventRequest(EventRequest eventRequest)
        {
            using (var db = new Database(_settings))
            {
                db.Insert(eventRequest);
            }
        }

        public void UpdateEventRequest(EventRequest eventRequest)
        {
            using (var db = new Database(_settings))
            using (var transaction = db.GetTransaction())
            {
                db.Update<EventRequest>("set Status = @2 where EventId = @0 and UserId = @1", eventRequest.EventId, eventRequest.UserId, eventRequest.Status);
                    
                if (eventRequest.Status == EventRequestStatus.Approved)
                    db.Update<Event>("set SlotsAvailable = SlotsAvailable - 1 where Id = @0", eventRequest.EventId);

                else if (eventRequest.Status == EventRequestStatus.Cancelled)
                    db.Update<Event>("set SlotsAvailable = SlotsAvailable + 1 where Id = @0", eventRequest.EventId);
                
                transaction.Complete();
            }
        }

        public void CreateEventRating(EventRating eventRating)
        {
            using (var db = new Database(_settings))
            using (var transaction = db.GetTransaction())
            {
                db.Insert(eventRating);
                var rating = Convert.ToDecimal(db.Query<EventRating>("where EventId = @0", eventRating.EventId).Average(r => r.Rating));
                db.Update<Event>("set Rating = @1 where Id = @0", eventRating.EventId, rating);
                transaction.Complete();
            }
        }

        public IList<Category> GetCategories()
        {
            using (var db = new Database(_settings))
            {
                return db.Query<Category>(string.Empty).ToList();
            }
        }

        public IList<EventLog> GetEventLogs(int eventId)
        {
            using (var db = new Database(_settings))
            {
                return db.Query<EventLog>("where EventId = @0", eventId).ToList();
            }
        }

        public IList<EventRequest> GetEventRequests(int eventId)
        {
            using (var db = new Database(_settings))
            {
                return db.Query<EventRequest>("where EventId = @0", eventId).ToList();
            }
        }

        public void UpdateEvent(Event @event)
        {
            using (var db = new Database(_settings))
            {
                db.Update<Event>("set Title = @1, Description = @2, Start = @3, End = @4, Price = @5, Slots = @6 where Id = @0",
                    @event.Id, @event.Title, @event.Description, @event.Start, @event.End, @event.Price, @event.Slots);
            }
        }

        public void DeleteEvent(long id)
        {
            using (var db = new Database(_settings))
            {
                db.Delete<Event>("where Id = @0", id);
            }
        }
    }
}
