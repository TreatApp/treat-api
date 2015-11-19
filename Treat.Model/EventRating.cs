using System;

namespace Treat.Model
{
    public class EventRating
    {
        public long EventId { get; set; }
        public User User { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Created { get; set; }
    }
}
