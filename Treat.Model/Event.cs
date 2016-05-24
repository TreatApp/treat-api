using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    public class Event
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public long UserId { get; set; }

        [Required]
        [DataMember]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Slots { get; set; }

        [DataMember]
        public DateTime Start { get; set; }

        [DataMember]
        public DateTime? End { get; set; }

        [DataMember]
        public decimal Price { get; set; }
        
        [DataMember]
        public long LocationId { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public User User { get; set; }

        [DataMember]
        public Location Location { get; set; }

        [DataMember]
        public decimal Rating { get; set; }

        [DataMember]
        public int SlotsAvailable { get; set; }

        [DataMember]
        public IEnumerable<EventCategory> Categories { get; set; }

        [DataMember]
        public IEnumerable<EventImage> EventImages { get; set; }
    }
}
