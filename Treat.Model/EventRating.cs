using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treat.Model
{
    [Table("EventRating")]
    public class EventRating
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EventId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }
        
        public int Rating { get; set; }

        public string Comment { get; set; }
        
        public DateTime Created { get; set; }

        public virtual User User { get; set; }

        public virtual Event Event { get; set; }
    }
}

