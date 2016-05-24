using System;
using System.Linq;
using Treat.Model;

namespace Treat.Repository.Mappers
{
    public class EventMapper
    {
        private Event _currentEvent;

        public Func<Event, User, Location, EventImage, Category, Event> Map => MapEvent;

        public Type[] Types => new[] { typeof(Event), typeof(User), typeof(Location), typeof(EventImage), typeof(Category) };

        private Event MapEvent(Event @event, User user, Location location, EventImage image, Category category)
        {
            if (@event == null)
                return _currentEvent;

            Event returnEvent = null;
            if (_currentEvent == null || _currentEvent.Id != @event.Id)
            {
                returnEvent = _currentEvent;
                _currentEvent = @event;
            }
            
            if (_currentEvent.User == null)
                _currentEvent.User = user;

            if (_currentEvent.Location == null)
                _currentEvent.Location = location;

            if (image != null && _currentEvent.Images.All(i => i.Id != image.Id))
                _currentEvent.Images.Add(image);

            if (category != null && _currentEvent.Categories.All(c => c.Id != category.Id))
                _currentEvent.Categories.Add(category);

            return returnEvent;
        }
    }
}