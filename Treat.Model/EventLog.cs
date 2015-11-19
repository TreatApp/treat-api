using System;

namespace Treat.Model
{
    public class EventLog
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public User User { get; set; }
        public EventLogType Type { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
    }
}
