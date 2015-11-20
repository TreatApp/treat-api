using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Treat.Model
{
    [DataContract]
    [Table("EventRequest")]
    public class EventRequest
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EventId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long UserId { get; set; }

        [DataMember]
        public EventRequestStatus Status { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public virtual User User { get; set; }

        public virtual Event Event { get; set; }
    }
}
