using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using PetaPoco;

namespace Treat.Model
{
    [DataContract]
    public class Event
    {
        public Event()
        {
            Categories = new List<Category>();
            Images = new List<EventImage>();
        }

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
        public decimal Rating { get; set; }

        [DataMember]
        public int SlotsAvailable { get; set; }

        [Ignore]
        [DataMember]
        public User User { get; set; }

        [Ignore]
        [DataMember]
        public Location Location { get; set; }

        [Ignore]
        [DataMember]
        public IList<Category> Categories { get; set; }

        [Ignore]
        [DataMember]
        public IList<EventImage> Images { get; set; }
    }
}
