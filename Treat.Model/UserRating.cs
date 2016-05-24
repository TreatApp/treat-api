using System;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    public class UserRating
    {
        [DataMember]
        public long UserId { get; set; }

        [DataMember]
        public long EventId { get; set; }
        
        [DataMember]
        public int Rating { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public DateTime Created { get; set; }
    }
}