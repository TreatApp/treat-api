using System;
using System.Collections.Generic;
using Treat.Model;

namespace Treat.Repository
{
    public class EventRepository : IEventRepository
    {
        public IList<Event> GetEvents()
        {
            return new List<Event>
            {
                GetDummyEvent()
            };
        }

        private static Event GetDummyEvent()
        {
            return new Event
            {
                Title = "Pasta carbonara",
                Description = "Authentic italian meal",
                Start = DateTime.Today.AddDays(5).AddHours(17),
                Host = GetDummyUser(),
                Location = GetDummyLocation(),
                Categories = GetDummyCategories(),
                Price = 50,
                Slots = 5
            };
        }

        private static User GetDummyUser()
        {
            return new User
            {
                FirstName = "Victor",
                LastName = "Stodell",
                Email = "victor@stodell.se",
                Description = "Amateur chef"
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
