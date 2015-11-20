using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Treat.Model;

namespace Treat.Service.Tests
{
    [TestClass]
    public class EventServiceTests
    {
        private readonly IEventService _eventService;

        public EventServiceTests()
        {
            _eventService = new EventService();
        }

        [TestMethod]
        public void Should_create_event()
        {
            try
            {
                _eventService.CreateEvent(GetDummyEvent());                
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
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
                new Category { Name = "Italian" },
                new Category { Name = "Traditional" },
                new Category { Name = "Amateur" }
            };
        }
    }
}
