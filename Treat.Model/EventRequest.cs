using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    public class EventRequest
    {
        [Required]
        [DataMember]
        public long EventId { get; set; }

        [Required]
        [DataMember]
        public long UserId { get; set; }

        [DataMember]
        public EventRequestStatus Status { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public User User { get; set; }
    }
}
