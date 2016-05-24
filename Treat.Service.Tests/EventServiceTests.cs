using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading;
using System.Transactions;
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
            var settings = new Settings();
            var eventRepository = new EventRepository(settings);
            _eventService = new EventService(eventRepository);

            Thread.CurrentPrincipal = new GenericPrincipal(UserIdentity.Anonymous, null);
        }

        [TestMethod]
        public void Get_events()
        {
            var events = _eventService.GetEvents();
            Assert.IsNotNull(events);

            var userEvents = _eventService.GetUserEvents();
            Assert.IsNotNull(userEvents);

            var firstEvent = _eventService.GetEvent(events[0].Id);
            Assert.IsNotNull(firstEvent);
        }

        [TestMethod]
        public void Create_event()
        {
            using (var transaction = new TransactionScope())
            {
                var dummyEvent = GetDummyEvent();
                _eventService.CreateEvent(dummyEvent);
                Assert.AreNotEqual(dummyEvent.Id, 0);
            }
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
                new Category { Id = 1 },
                new Category { Id = 2 },
                new Category { Id = 3 }
            };
        }
    }
}
