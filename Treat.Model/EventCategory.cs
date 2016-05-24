using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    public class EventCategory
    {
        [DataMember]
        public long EventId { get; set; }
        
        [DataMember]
        public long CategoryId { get; set; }
    }
}