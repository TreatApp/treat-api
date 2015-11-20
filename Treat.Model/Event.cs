using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    [Table("Event")]
    public class Event
    {
        public Event()
        {
            Categories = new HashSet<Category>();
            EventLogs = new HashSet<EventLog>();
            EventRatings = new HashSet<EventRating>();
            EventRequests = new HashSet<EventRequest>();
        }

        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

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
        
        public long LocationId { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public virtual User User { get; set; }

        [DataMember]
        public virtual Location Location { get; set; }

        [DataMember]
        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<EventLog> EventLogs { get; set; }

        public virtual ICollection<EventRating> EventRatings { get; set; }

        public virtual ICollection<EventRequest> EventRequests { get; set; }
    }
}
