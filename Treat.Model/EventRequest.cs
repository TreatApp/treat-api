using System;

namespace Treat.Model
{
    public class EventRequest
    {
        public long EventId { get; set; }
        public User User { get; set; }
        public EventRequestStatus Status { get; set; }
        public DateTime Created { get; set; }
    }
}
