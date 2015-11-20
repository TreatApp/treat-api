using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Treat.Model
{
    [Table("EventLog")]
    public class EventLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long EventId { get; set; }

        public long UserId { get; set; }
        
        public EventLogType Type { get; set; }

        [Required]
        public string Text { get; set; }
        
        public DateTime Created { get; set; }

        public virtual User User { get; set; }

        public virtual Event Event { get; set; }
    }
}
