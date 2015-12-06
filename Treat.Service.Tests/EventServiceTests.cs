using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Treat.Model;
using Treat.Repository;

namespace Treat.Service.Tests
{
    [TestClass]
    public class EventServiceTests
    {
        private readonly IEventService _eventService;

        public EventServiceTests()
        {
            var eventRepository = new EventRepository();
            _eventService = new EventService(eventRepository);
        }

        [TestMethod]
        public void Should_get_events()
        {
            var events = _eventService.GetEvents();
            Assert.IsNotNull(events);
        }

        [TestMethod]
        public void Should_create_event()
        {
            _eventService.CreateEvent(GetDummyEvent());                
        }

        private static Event GetDummyEvent()
        {
            return new Event
            {
                Title = "Pasta carbonara",
                Description = "Authentic italian meal",
                Start = DateTime.Today.AddDays(5).AddHours(17),
                User = GetDummyUser(),
                Location = GetDummyLocation(),
                Categories = GetDummyCategories(),
                Price = 50,
                Slots = 5,
                Created = DateTime.Now
            };
        }

        private static User GetDummyUser()
        {
            return new User
            {
                ExternalId = "12345",
                FirstName = "Victor",
                LastName = "Stodell",
                Email = "victor@stodell.se",
                Description = "Amateur chef",
                Created = DateTime.Now
            };
        }

        private static Location GetDummyLocation()
        {
            return new Location
            {
                Address = "Infinity Lane 1",
                City = "Stockholm",
                Country = "Sweden"
            };
        }

        private static IList<Category> GetDummyCategories()
        {
            return new List<Category>
            {
                new Category { Name = "Italian" },
                new Category { Name = "Traditional" },
                new Category { Name = "Amateur" }
            };
        }
    }
}
