using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    [Table("EventLog")]
    public class EventLog
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long EventId { get; set; }

        public long UserId { get; set; }

        [DataMember]
        public EventLogType Type { get; set; }

        [Required]
        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public virtual User User { get; set; }

        public virtual Event Event { get; set; }
    }
}
