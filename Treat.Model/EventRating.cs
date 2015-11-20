using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treat.Model
{
    [Table("EventRating")]
    public class EventRating
    {
        [Column(Order = 0)]
        [Key, ForeignKey("Event")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EventId { get; set; }

        [Column(Order = 1)]
        [Key, ForeignKey("User")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }
        
        public int Rating { get; set; }

        public string Comment { get; set; }
        
        public DateTime Created { get; set; }

        public virtual User User { get; set; }

        public virtual Event Event { get; set; }
    }
}

