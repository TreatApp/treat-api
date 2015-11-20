using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treat.Model
{
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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        
        public int Slots { get; set; }
        
        public DateTime Start { get; set; }
        
        public DateTime? End { get; set; }
        
        public decimal Price { get; set; }
        
        public long LocationId { get; set; }
        
        public DateTime Created { get; set; }

        public virtual User User { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<EventLog> EventLogs { get; set; }

        public virtual ICollection<EventRating> EventRatings { get; set; }

        public virtual ICollection<EventRequest> EventRequests { get; set; }
    }
}
